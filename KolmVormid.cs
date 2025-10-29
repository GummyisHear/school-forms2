using System;
using System.Drawing;
using System.Windows.Forms;

namespace KolmVormid
{
    public class KolmVormid : Form
    {
        private Button _btnMatchGame;
        private Button _btnMathQuiz;
        private Button _btnPictureViewer;

        public KolmVormid()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            Text = "Kolm Vormid";
            Size = new Size(400, 300);
            StartPosition = FormStartPosition.CenterScreen;

            _btnMatchGame = new Button
            {
                Text = "Match Game",
                Size = new Size(150, 50),
                Location = new Point((ClientSize.Width - 150) / 2, 40)
            };
            _btnMathQuiz = new Button
            {
                Text = "Math Quiz",
                Size = new Size(150, 50),
                Location = new Point((ClientSize.Width - 150) / 2, 110)
            };
            _btnPictureViewer = new Button
            {
                Text = "Picture Viewer",
                Size = new Size(150, 50),
                Location = new Point((ClientSize.Width - 150) / 2, 180)
            };

            _btnMatchGame.Click += BtnMatchGame_Click;
            _btnMathQuiz.Click += BtnMathQuiz_Click;
            _btnPictureViewer.Click += BtnPictureViewer_Click;

            Controls.Add(_btnMatchGame);
            Controls.Add(_btnMathQuiz);
            Controls.Add(_btnPictureViewer);
        }

        private void BtnMatchGame_Click(object sender, EventArgs e)
        {
            var matchGame = new MatchGame();
            matchGame.ShowDialog();
        }

        private void BtnMathQuiz_Click(object sender, EventArgs e)
        {
            var mathQuiz = new MathQuiz();
            mathQuiz.ShowDialog();
        }

        private void BtnPictureViewer_Click(object sender, EventArgs e)
        {
            var pictureViewer = new PictureViewer();
            pictureViewer.ShowDialog();
        }
    }
}
