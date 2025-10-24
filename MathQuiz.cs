using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace KolmVormid
{
    public partial class MathQuiz : Form
    {
        private Label _label1;
        private Label _plusLeftLabel;
        private Label _label2;
        private Label _plusRightLabel;
        private Label _label4;
        private NumericUpDown _sum;
        private NumericUpDown _difference;
        private Label _label3;
        private Label _minusRightLabel;
        private Label _label6;
        private Label _minusLeftLabel;
        private NumericUpDown _product;
        private Label _label5;
        private Label _timesRightLabel;
        private Label _label8;
        private Label _timesLeftLabel;
        private NumericUpDown _quotient;
        private Label _label10;
        private Label _dividedRightLabel;
        private Label _label12;
        private Label _dividedLeftLabel;
        private Button _startButton;
        private Button _hintButton;
        private Button _resetButton;
        private Label _timeLabel;

        private MathProblem _plusProblem;
        private MathProblem _minusProblem;
        private MathProblem _multiplyProblem;
        private MathProblem _divideProblem;

        private Timer _timer1;
        private IContainer _components;
        private int _timeLeft;

        public MathQuiz()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            _components = new Container();
            _timeLabel = new Label();
            _label1 = new Label();
            _plusLeftLabel = new Label();
            _label2 = new Label();
            _plusRightLabel = new Label();
            _label4 = new Label();
            _sum = new NumericUpDown();
            _difference = new NumericUpDown();
            _label3 = new Label();
            _minusRightLabel = new Label();
            _label6 = new Label();
            _minusLeftLabel = new Label();
            _product = new NumericUpDown();
            _label5 = new Label();
            _timesRightLabel = new Label();
            _label8 = new Label();
            _timesLeftLabel = new Label();
            _quotient = new NumericUpDown();
            _label10 = new Label();
            _dividedRightLabel = new Label();
            _label12 = new Label();
            _dividedLeftLabel = new Label();
            _startButton = new Button();
            _hintButton = new Button();
            _resetButton = new Button();
            _timer1 = new Timer(_components);

            _plusProblem = new MathProblem(Problem.Plus);
            _minusProblem = new MathProblem(Problem.Minus);
            _divideProblem = new MathProblem(Problem.Divide);
            _multiplyProblem = new MathProblem(Problem.Multiply);

            ((ISupportInitialize)_sum).BeginInit();
            ((ISupportInitialize)_difference).BeginInit();
            ((ISupportInitialize)_product).BeginInit();
            ((ISupportInitialize)_quotient).BeginInit();

            SuspendLayout();

            // Time label
            _timeLabel.BorderStyle = BorderStyle.FixedSingle;
            _timeLabel.Font = new Font("Microsoft Sans Serif", 15.75F);
            _timeLabel.Location = new Point(272, 9);
            _timeLabel.Size = new Size(200, 30);

            // Label1
            _label1.AutoSize = true;
            _label1.Font = new Font("Microsoft Sans Serif", 15.75F);
            _label1.Location = new Point(165, 10);
            _label1.Text = "Time Left";

            // Plus section
            _plusLeftLabel.Font = new Font("Microsoft Sans Serif", 18F);
            _plusLeftLabel.Location = new Point(50, 75);
            _plusLeftLabel.Size = new Size(60, 50);
            _plusLeftLabel.Text = "?";
            _plusLeftLabel.TextAlign = ContentAlignment.MiddleCenter;

            _label2.Font = new Font("Microsoft Sans Serif", 18F);
            _label2.Location = new Point(116, 75);
            _label2.Size = new Size(60, 50);
            _label2.Text = "+";
            _label2.TextAlign = ContentAlignment.MiddleCenter;

            _plusRightLabel.Font = new Font("Microsoft Sans Serif", 18F);
            _plusRightLabel.Location = new Point(182, 75);
            _plusRightLabel.Size = new Size(60, 50);
            _plusRightLabel.Text = "?";
            _plusRightLabel.TextAlign = ContentAlignment.MiddleCenter;

            _label4.Font = new Font("Microsoft Sans Serif", 18F);
            _label4.Location = new Point(248, 75);
            _label4.Size = new Size(60, 50);
            _label4.Text = "=";
            _label4.TextAlign = ContentAlignment.MiddleCenter;

            // Sum
            _sum.Font = new Font("Microsoft Sans Serif", 18F);
            _sum.Location = new Point(314, 84);
            _sum.MaximumSize = new Size(100, 0);
            _sum.Size = new Size(100, 35);
            _sum.Enter += answer_Enter;
            _sum.Click += answer_Enter;
            _sum.Leave += (sender, e) => answer_Leave(sender, e, _plusProblem);

            // Difference
            _difference.Font = new Font("Microsoft Sans Serif", 18F);
            _difference.Location = new Point(314, 134);
            _difference.MaximumSize = new Size(100, 0);
            _difference.Size = new Size(100, 35);
            _difference.Enter += answer_Enter;
            _difference.Click += answer_Enter;
            _difference.Leave += (sender, e) => answer_Leave(sender, e, _minusProblem);

            // Product
            _product.Font = new Font("Microsoft Sans Serif", 18F);
            _product.Location = new Point(314, 184);
            _product.MaximumSize = new Size(100, 0);
            _product.Size = new Size(100, 35);
            _product.Enter += answer_Enter;
            _product.Click += answer_Enter;
            _product.Leave += (sender, e) => answer_Leave(sender, e, _multiplyProblem);

            // Quotient
            _quotient.Font = new Font("Microsoft Sans Serif", 18F);
            _quotient.Location = new Point(314, 234);
            _quotient.MaximumSize = new Size(100, 0);
            _quotient.Size = new Size(100, 35);
            _quotient.Enter += answer_Enter;
            _quotient.Click += answer_Enter;
            _quotient.Leave += (sender, e) => answer_Leave(sender, e, _divideProblem);

            _label3.Font = new Font("Microsoft Sans Serif", 18F);
            _label3.Location = new Point(248, 125);
            _label3.Size = new Size(60, 50);
            _label3.Text = "=";
            _label3.TextAlign = ContentAlignment.MiddleCenter;

            _minusRightLabel.Font = new Font("Microsoft Sans Serif", 18F);
            _minusRightLabel.Location = new Point(182, 125);
            _minusRightLabel.Size = new Size(60, 50);
            _minusRightLabel.Text = "?";
            _minusRightLabel.TextAlign = ContentAlignment.MiddleCenter;

            _label6.Font = new Font("Microsoft Sans Serif", 18F);
            _label6.Location = new Point(116, 125);
            _label6.Size = new Size(60, 50);
            _label6.Text = "-";
            _label6.TextAlign = ContentAlignment.MiddleCenter;

            _minusLeftLabel.Font = new Font("Microsoft Sans Serif", 18F);
            _minusLeftLabel.Location = new Point(50, 125);
            _minusLeftLabel.Size = new Size(60, 50);
            _minusLeftLabel.Text = "?";
            _minusLeftLabel.TextAlign = ContentAlignment.MiddleCenter;

            _label5.Font = new Font("Microsoft Sans Serif", 18F);
            _label5.Location = new Point(248, 175);
            _label5.Size = new Size(60, 50);
            _label5.Text = "=";
            _label5.TextAlign = ContentAlignment.MiddleCenter;

            _timesRightLabel.Font = new Font("Microsoft Sans Serif", 18F);
            _timesRightLabel.Location = new Point(182, 175);
            _timesRightLabel.Size = new Size(60, 50);
            _timesRightLabel.Text = "?";
            _timesRightLabel.TextAlign = ContentAlignment.MiddleCenter;

            _label8.Font = new Font("Microsoft Sans Serif", 18F);
            _label8.Location = new Point(116, 175);
            _label8.Size = new Size(60, 50);
            _label8.Text = "×";
            _label8.TextAlign = ContentAlignment.MiddleCenter;

            _timesLeftLabel.Font = new Font("Microsoft Sans Serif", 18F);
            _timesLeftLabel.Location = new Point(50, 175);
            _timesLeftLabel.Size = new Size(60, 50);
            _timesLeftLabel.Text = "?";
            _timesLeftLabel.TextAlign = ContentAlignment.MiddleCenter;

            _label10.Font = new Font("Microsoft Sans Serif", 18F);
            _label10.Location = new Point(248, 225);
            _label10.Size = new Size(60, 50);
            _label10.Text = "=";
            _label10.TextAlign = ContentAlignment.MiddleCenter;

            _dividedRightLabel.Font = new Font("Microsoft Sans Serif", 18F);
            _dividedRightLabel.Location = new Point(182, 225);
            _dividedRightLabel.Size = new Size(60, 50);
            _dividedRightLabel.Text = "?";
            _dividedRightLabel.TextAlign = ContentAlignment.MiddleCenter;

            _label12.Font = new Font("Microsoft Sans Serif", 18F);
            _label12.Location = new Point(116, 225);
            _label12.Size = new Size(60, 50);
            _label12.Text = "÷";
            _label12.TextAlign = ContentAlignment.MiddleCenter;

            _dividedLeftLabel.Font = new Font("Microsoft Sans Serif", 18F);
            _dividedLeftLabel.Location = new Point(50, 225);
            _dividedLeftLabel.Size = new Size(60, 50);
            _dividedLeftLabel.Text = "?";
            _dividedLeftLabel.TextAlign = ContentAlignment.MiddleCenter;

            // Start button
            _startButton.AutoSize = true;
            _startButton.Font = new Font("Microsoft Sans Serif", 14F);
            _startButton.Location = new Point(170, 315);
            //_startButton.Size = new Size(127, 34);
            _startButton.Text = "Start the quiz";
            _startButton.Click += startButton_Click;

            // Hint button
            _hintButton.AutoSize = true;
            _hintButton.Font = new Font("Microsoft Sans Serif", 14F);
            _hintButton.Location = new Point(300, 315);
            _hintButton.Text = "Hint";
            _hintButton.Click += hintButton_Click;

            // Reset button
            _resetButton.AutoSize = true;
            _resetButton.Font = new Font("Microsoft Sans Serif", 14F);
            _resetButton.Location = new Point(90, 315);
            _resetButton.Text = "Reset";
            _resetButton.Click += resetButton_Click;

            // Timer
            _timer1.Interval = 1000;
            _timer1.Tick += timer1_Tick;

            // Form
            ClientSize = new Size(484, 361);
            Controls.AddRange(new Control[]
            {
                _startButton, _quotient, _label10, _dividedRightLabel, _label12,
                _dividedLeftLabel, _product, _label5, _timesRightLabel, _label8, _timesLeftLabel,
                _difference, _label3, _minusRightLabel, _label6, _minusLeftLabel, _sum, _label4,
                _plusRightLabel, _label2, _plusLeftLabel, _label1, _timeLabel, _hintButton, _resetButton,
            });
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            Name = "MathQuiz";

            ((ISupportInitialize)_sum).EndInit();
            ((ISupportInitialize)_difference).EndInit();
            ((ISupportInitialize)_product).EndInit();
            ((ISupportInitialize)_quotient).EndInit();

            ResumeLayout(false);
            PerformLayout();
        }

        private void InitProblems()
        {
            var rng = new Random();
            _plusProblem.A = rng.Next(51);
            _plusProblem.B = rng.Next(51);
            _minusProblem.A = rng.Next(1, 101);
            _minusProblem.B = rng.Next(1, _minusProblem.A);
            _multiplyProblem.A = rng.Next(2, 11);
            _multiplyProblem.B = rng.Next(2, 11);
            _divideProblem.B = rng.Next(2, 11);
            _divideProblem.A = _divideProblem.B * rng.Next(2, 11);
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            InitProblems();
            _startButton.Enabled = false;

            _plusLeftLabel.Text = _plusProblem.A.ToString();
            _plusRightLabel.Text = _plusProblem.B.ToString();
            _minusLeftLabel.Text = _minusProblem.A.ToString();
            _minusRightLabel.Text = _minusProblem.B.ToString();
            _timesLeftLabel.Text = _multiplyProblem.A.ToString();
            _timesRightLabel.Text = _multiplyProblem.B.ToString();
            _dividedLeftLabel.Text = _divideProblem.A.ToString();
            _dividedRightLabel.Text = _divideProblem.B.ToString();

            _sum.BackColor = Color.White;
            _difference.BackColor = Color.White;
            _product.BackColor = Color.White;
            _quotient.BackColor = Color.White;

            _sum.Value = 0;
            _difference.Value = 0;
            _product.Value = 0;
            _quotient.Value = 0;

            _timeLeft = 30;
            _timeLabel.Text = "30 seconds";
            _timer1.Start();
        }

        private bool CheckTheAnswer()
        {
            return _plusProblem.Solve() == _sum.Value
                && _minusProblem.Solve() == _difference.Value
                && _multiplyProblem.Solve() == _product.Value
                && _divideProblem.Solve() == _quotient.Value;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (CheckTheAnswer())
            {
                _timer1.Stop();
                MessageBox.Show("You got all the answers right!", "Congratulations!", MessageBoxButtons.OK);
                _startButton.Enabled = true;
            }
            else if (_timeLeft > 0)
            {
                _timeLeft--;
                _timeLabel.Text = $"{_timeLeft} seconds";
            }
            else
            {
                _timer1.Stop();
                _timeLabel.Text = "Time's up!";
                MessageBox.Show("You didn't finish in time.", "Sorry!", MessageBoxButtons.OK);
                _sum.Value = _plusProblem.Solve();
                _sum.BackColor = Color.White;
                _difference.Value = _minusProblem.Solve();
                _difference.BackColor = Color.White;
                _product.Value = _multiplyProblem.Solve();
                _product.BackColor = Color.White;
                _quotient.Value = _divideProblem.Solve();
                _quotient.BackColor = Color.White;
                _startButton.Enabled = true;
            }
        }

        private void answer_Enter(object sender, EventArgs e)
        {
            if (sender is NumericUpDown answer)
            {
                int length = answer.Value.ToString().Length;
                answer.Select(0, length);
            }
        }

        private void answer_Leave(object sender, EventArgs e, MathProblem problem)
        {
            if (sender is NumericUpDown answer)
                answer.BackColor = problem.Solve() == answer.Value ? Color.LimeGreen : Color.Red;
        }

        private void hintButton_Click(object sender, EventArgs e)
        {
            if (!_timer1.Enabled)
                return;

            if (_sum.Value != _plusProblem.Solve())
            {
                _sum.Value = _plusProblem.Solve();
                _sum.BackColor = Color.Yellow;
            }
            else if (_difference.Value != _minusProblem.Solve())
            {
                _difference.Value = _minusProblem.Solve();
                _difference.BackColor = Color.Yellow;
            }
            else if (_product.Value != _multiplyProblem.Solve())
            {
                _product.Value = _multiplyProblem.Solve();
                _product.BackColor = Color.Yellow;
            }
            else if (_quotient.Value != _divideProblem.Solve())
            {
                _quotient.Value = _divideProblem.Solve();
                _quotient.BackColor = Color.Yellow;
            }
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            if (!_timer1.Enabled)
                return;

            _timer1.Stop();
            _timeLabel.Text = "Time's up!";
            MessageBox.Show("You didn't finish in time.", "Sorry!", MessageBoxButtons.OK);
            _sum.Value = _plusProblem.Solve();
            _sum.BackColor = Color.White;
            _difference.Value = _minusProblem.Solve();
            _difference.BackColor = Color.White;
            _product.Value = _multiplyProblem.Solve();
            _product.BackColor = Color.White;
            _quotient.Value = _divideProblem.Solve();
            _quotient.BackColor = Color.White;
            _startButton.Enabled = true;
        }
    }
}
