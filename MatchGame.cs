using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace KolmVormid
{
    public enum Difficulty
    {
        Easy,
        Medium,
        Hard
    }

    public partial class MatchGame : Form
    {
        private readonly Random _random = new Random();
        public Color TableBackColor = ColorTranslator.FromHtml("#d63e69");
        public Color TableFontColor = ColorTranslator.FromHtml("#ffffff");

        private TableLayoutPanel _table;
        private TabControl _tabs;
        private TabPage _tabGame;
        private TabPage _tabSolve;

        private Timer _flipTimer;
        private Timer _totalTimer;
        private IContainer _components;

        private Label _firstClicked = null;
        private Label _secondClicked = null;
        private int _elapsed = 0;

        private Difficulty _difficulty;

        public static readonly List<string> Icons = new List<string>
        {
            "!", "N", ",", "k",
            "b", "v", "w", "z",
            "a", "b", "c", "d",
            "e", "f", "g", "h",
            "i", "j", "k", "l",
            "m", "n", "o", "p",
            "q", "r", "s", "t",
            "u", "w", "x", "y"
        };

        public int GridSize = 4;

        public MatchGame()
        {
            ShowDifficultyWindow();
            InitializeComponent();
            _table.Resize += Table_Resize;
            AssignIconsToSquares();
        }

        private void ShowDifficultyWindow()
        {
            var form = new Form
            {
                Text = "Select Difficulty",
                Size = new Size(250, 200),
                StartPosition = FormStartPosition.CenterScreen
            };

            var easy = new RadioButton { Text = "Easy (4x4)", Location = new Point(50, 30), Checked = true };
            var medium = new RadioButton { Text = "Medium (6x6)", Location = new Point(50, 60) };
            var hard = new RadioButton { Text = "Hard (8x8)", Location = new Point(50, 90) };
            var ok = new Button { Text = "OK", Location = new Point(80, 130), Size = new Size(80, 30) };

            ok.Click += (s, e) =>
            {
                if (easy.Checked) _difficulty = Difficulty.Easy;
                else if (medium.Checked) _difficulty = Difficulty.Medium;
                else _difficulty = Difficulty.Hard;

                UpdateDifficulty(_difficulty);

                form.DialogResult = DialogResult.OK;
                form.Close();
            };

            form.Controls.Add(easy);
            form.Controls.Add(medium);
            form.Controls.Add(hard);
            form.Controls.Add(ok);

            form.ShowDialog();
        }

        private void UpdateDifficulty(Difficulty difficulty)
        {
            switch (difficulty)
            {
                case Difficulty.Easy:
                    GridSize = 4;
                    TableBackColor = ColorTranslator.FromHtml("#d63e69");
                    TableFontColor = ColorTranslator.FromHtml("#ffffff");
                    break;
                case Difficulty.Medium:
                    GridSize = 6;
                    TableBackColor = ColorTranslator.FromHtml("#e3b039");
                    TableFontColor = ColorTranslator.FromHtml("#ffffff");
                    break;
                case Difficulty.Hard:
                    GridSize = 8;
                    TableBackColor = ColorTranslator.FromHtml("#000000");
                    TableFontColor = ColorTranslator.FromHtml("#ffffff");
                    break;
            }
        }

        private void InitializeComponent()
        {
            _components = new Container();
            _table = new TableLayoutPanel();
            _flipTimer = new Timer(_components);
            _totalTimer = new Timer(_components);
            _tabs = new TabControl();
            _tabGame = new TabPage("Game");
            _tabSolve = new TabPage("Solve");

            SuspendLayout();

            _table.BackColor = TableBackColor;
            _table.CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset;
            _table.ColumnCount = GridSize;
            _table.RowCount = GridSize;

            for (int i = 0; i < GridSize; i++)
            {
                _table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / GridSize));
                _table.RowStyles.Add(new RowStyle(SizeType.Percent, 100f / GridSize));
            }
            _table.Dock = DockStyle.Fill;

            for (int row = 0; row < GridSize; row++)
            {
                for (int col = 0; col < GridSize; col++)
                {
                    var lbl = new Label();
                    lbl.Dock = DockStyle.Fill;
                    lbl.Font = new Font("Webdings", lbl.Width * 0.8f, FontStyle.Bold, GraphicsUnit.Point, 2);
                    lbl.Text = "c";
                    lbl.TextAlign = ContentAlignment.MiddleCenter;
                    lbl.Click += Label_Click;
                    _table.Controls.Add(lbl, col, row);
                }
            }

            _flipTimer.Interval = 500;
            _flipTimer.Tick += FlipTimer_Tick;
            _totalTimer.Tick += TotalTimer_Tick;

            _tabGame.Controls.Add(_table);
            _tabSolve.BackColor = Color.LightGray;

            _tabs.Dock = DockStyle.Fill;
            _tabs.Controls.Add(_tabGame);
            _tabs.Controls.Add(_tabSolve);
            _tabs.Selecting += Tabs_Selecting;

            ClientSize = new Size(534, 511);
            Controls.Add(_tabs);
            Text = "Matching Game";

            ResumeLayout(false);
        }

        private void AssignIconsToSquares()
        {
            var iconsCopy = Icons.ToList();
            var icons = new List<string>();
            for (var i = 0; i < Math.Ceiling(GridSize * GridSize / 2f); i++)
            {
                if (iconsCopy.Count == 0)
                    iconsCopy = Icons.ToList();

                var randomIndex = _random.Next(iconsCopy.Count);
                icons.Add(iconsCopy[randomIndex]);
                icons.Add(iconsCopy[randomIndex]);
                iconsCopy.RemoveAt(randomIndex);
            }

            foreach (Control control in _table.Controls)
            {
                if (control is Label label)
                {
                    int randomIndex = _random.Next(icons.Count);
                    label.Text = icons[randomIndex];
                    label.ForeColor = label.BackColor;
                    icons.RemoveAt(randomIndex);
                }
            }
        }

        private void Label_Click(object sender, EventArgs e)
        {
            var clickedLabel = sender as Label;
            if (clickedLabel == null || clickedLabel.ForeColor == TableFontColor)
                return;

            if (_flipTimer.Enabled)
                return;

            if (!_totalTimer.Enabled)
                _totalTimer.Start();

            if (_firstClicked == null)
            {
                _firstClicked = clickedLabel;
                clickedLabel.ForeColor = TableFontColor;
                return;
            }

            _secondClicked = clickedLabel;
            _secondClicked.ForeColor = TableFontColor;

            CheckForWinner();

            if (_firstClicked.Text == _secondClicked.Text)
            {
                _firstClicked = null;
                _secondClicked = null;
                return;
            }

            _flipTimer.Start();
        }

        private void FlipTimer_Tick(object sender, EventArgs e)
        {
            _flipTimer.Stop();

            _firstClicked.ForeColor = _firstClicked.BackColor;
            _secondClicked.ForeColor = _secondClicked.BackColor;

            _firstClicked = null;
            _secondClicked = null;
        }

        private void CheckForWinner()
        {
            foreach (Control control in _table.Controls)
            {
                if (control is Label label && label.ForeColor == label.BackColor)
                    return;
            }

            MessageBox.Show(
                $"You matched all the icons!\n" +
                $"It took you {_elapsed / 1000.0:R2} seconds.",
                "Congratulations"
            );
        }

        private void TotalTimer_Tick(object sender, EventArgs e)
        {
            _elapsed += _totalTimer.Interval;
        }

        private void Tabs_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPage == _tabSolve)
            {
                e.Cancel = true;
                SolveGame();
            }
        }

        private void SolveGame()
        {
            foreach (Control control in _table.Controls)
            {
                var label = control as Label;
                if (label != null)
                    label.ForeColor = TableFontColor;
            }

            _totalTimer.Stop();
            CheckForWinner();
        }

        private void Table_Resize(object sender, EventArgs e)
        {
            foreach (Control control in _table.Controls)
            {
                if (control is Label lbl)
                {
                    float size = Math.Min(lbl.Width, lbl.Height) * 0.6f;
                    lbl.Font = new Font("Webdings", size, FontStyle.Bold, GraphicsUnit.Point, 2);
                }
            }
        }
    }
}
