using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace KolmVormid
{
    public partial class MainForm : Form
    {
        private PictureBox _pictureBox1;
        private FlowLayoutPanel _flowLayoutPanel1;
        private Button _showButton;
        private Button _clearButton;
        private Button _backgroundButton;
        private Button _closeButton;
        private OpenFileDialog _openFileDialog1;
        private ColorDialog _colorDialog1;
        private FlowLayoutPanel _flowLayoutPanel2;
        private CheckBox _stretchCheckbox;
        private CheckBox _monochromeCheckbox;
        private TableLayoutPanel _tableLayoutPanel1;
        private CheckBox _spiralCheckbox;
        private Image _originalImage;
        private Button _drawButton;

        private bool _isDrawing = false;
        private bool _imageConverted = false;
        private Color _drawColor = Color.White;

        public MainForm()
        {
            InitializeComponent();
            Text = "MainForm";
        }

        private void InitializeComponent()
        {
            _tableLayoutPanel1 = new TableLayoutPanel();
            _pictureBox1 = new PictureBox();
            _flowLayoutPanel1 = new FlowLayoutPanel();
            _showButton = new Button();
            _clearButton = new Button();
            _backgroundButton = new Button();
            _closeButton = new Button();
            _flowLayoutPanel2 = new FlowLayoutPanel();
            _stretchCheckbox = new CheckBox();
            _monochromeCheckbox = new CheckBox();
            _spiralCheckbox = new CheckBox();
            _openFileDialog1 = new OpenFileDialog();
            _colorDialog1 = new ColorDialog();
            _drawButton = new Button();
            _tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(_pictureBox1)).BeginInit();
            _flowLayoutPanel1.SuspendLayout();
            _flowLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            _tableLayoutPanel1.ColumnCount = 2;
            _tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            _tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(System.Windows.Forms.SizeType.Percent, 85F));
            _tableLayoutPanel1.Controls.Add(_pictureBox1, 0, 0);
            _tableLayoutPanel1.Controls.Add(_flowLayoutPanel1, 1, 1);
            _tableLayoutPanel1.Controls.Add(_flowLayoutPanel2, 0, 1);
            _tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            _tableLayoutPanel1.Location = new Point(0, 0);
            _tableLayoutPanel1.Name = "tableLayoutPanel1";
            _tableLayoutPanel1.RowCount = 2;
            _tableLayoutPanel1.RowStyles.Add(new RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            _tableLayoutPanel1.RowStyles.Add(new RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            _tableLayoutPanel1.RowStyles.Add(new RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            _tableLayoutPanel1.Size = new Size(784, 561);
            _tableLayoutPanel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            _tableLayoutPanel1.SetColumnSpan(_pictureBox1, 2);
            _pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            _pictureBox1.Location = new Point(3, 3);
            _pictureBox1.Name = "pictureBox1";
            _pictureBox1.Size = new Size(778, 442);
            _pictureBox1.TabIndex = 0;
            _pictureBox1.TabStop = false;
            _pictureBox1.MouseDown += new MouseEventHandler(pictureBox1_MouseDown);
            _pictureBox1.MouseMove += new MouseEventHandler(pictureBox1_MouseMove);
            _pictureBox1.MouseUp += new MouseEventHandler(pictureBox1_MouseUp);
            // 
            // flowLayoutPanel1
            // 
            _flowLayoutPanel1.Controls.Add(_showButton);
            _flowLayoutPanel1.Controls.Add(_clearButton);
            _flowLayoutPanel1.Controls.Add(_backgroundButton);
            _flowLayoutPanel1.Controls.Add(_closeButton);
            _flowLayoutPanel1.Controls.Add(_drawButton);
            _flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            _flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            _flowLayoutPanel1.Location = new Point(120, 451);
            _flowLayoutPanel1.Name = "flowLayoutPanel1";
            _flowLayoutPanel1.Size = new Size(661, 107);
            _flowLayoutPanel1.TabIndex = 2;
            // 
            // showButton
            // 
            _showButton.AutoSize = true;
            _showButton.Location = new Point(570, 3);
            _showButton.Name = "showButton";
            _showButton.Size = new Size(88, 23);
            _showButton.TabIndex = 0;
            _showButton.Text = "Show a picture";
            _showButton.UseVisualStyleBackColor = true;
            _showButton.Click += new EventHandler(showButton_Click);
            // 
            // clearButton
            // 
            _clearButton.AutoSize = true;
            _clearButton.Location = new Point(470, 3);
            _clearButton.Name = "clearButton";
            _clearButton.Size = new Size(94, 23);
            _clearButton.TabIndex = 1;
            _clearButton.Text = "Clear the picture";
            _clearButton.UseVisualStyleBackColor = true;
            _clearButton.Click += new EventHandler(clearButton_Click);
            // 
            // backgroundButton
            // 
            _backgroundButton.AutoSize = true;
            _backgroundButton.Location = new Point(327, 3);
            _backgroundButton.Name = "backgroundButton";
            _backgroundButton.Size = new Size(137, 23);
            _backgroundButton.TabIndex = 2;
            _backgroundButton.Text = "Set the background color";
            _backgroundButton.UseVisualStyleBackColor = true;
            _backgroundButton.Click += new EventHandler(backgroundButton_Click);
            // 
            // closeButton
            // 
            _closeButton.AutoSize = true;
            _closeButton.Location = new Point(246, 3);
            _closeButton.Name = "closeButton";
            _closeButton.Size = new Size(75, 23);
            _closeButton.TabIndex = 3;
            _closeButton.Text = "Close";
            _closeButton.UseVisualStyleBackColor = true;
            _closeButton.Click += new EventHandler(closeButton_Click);
            // 
            // flowLayoutPanel2
            // 
            _flowLayoutPanel2.Controls.Add(_stretchCheckbox);
            _flowLayoutPanel2.Controls.Add(_monochromeCheckbox);
            _flowLayoutPanel2.Controls.Add(_spiralCheckbox);
            _flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            _flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            _flowLayoutPanel2.Location = new Point(3, 451);
            _flowLayoutPanel2.Name = "flowLayoutPanel2";
            _flowLayoutPanel2.Size = new Size(111, 107);
            _flowLayoutPanel2.TabIndex = 3;
            // 
            // stretchCheckbox
            // 
            _stretchCheckbox.AutoSize = true;
            _stretchCheckbox.Location = new Point(3, 3);
            _stretchCheckbox.Name = "stretchCheckbox";
            _stretchCheckbox.Size = new Size(60, 17);
            _stretchCheckbox.TabIndex = 2;
            _stretchCheckbox.Text = "Stretch";
            _stretchCheckbox.UseVisualStyleBackColor = true;
            _stretchCheckbox.CheckedChanged += new EventHandler(stretchCheckbox_CheckedChanged_1);
            // 
            // monochromeCheckbox
            // 
            _monochromeCheckbox.AutoSize = true;
            _monochromeCheckbox.Location = new Point(3, 26);
            _monochromeCheckbox.Name = "monochromeCheckbox";
            _monochromeCheckbox.Size = new Size(88, 17);
            _monochromeCheckbox.TabIndex = 3;
            _monochromeCheckbox.Text = "Monochrome";
            _monochromeCheckbox.UseVisualStyleBackColor = true;
            _monochromeCheckbox.CheckedChanged += new EventHandler(monochromeCheckbox_CheckedChanged);
            // 
            // spiralCheckbox
            // 
            _spiralCheckbox.AutoSize = true;
            _spiralCheckbox.Location = new Point(3, 49);
            _spiralCheckbox.Name = "spiralCheckbox";
            _spiralCheckbox.Size = new Size(52, 17);
            _spiralCheckbox.TabIndex = 4;
            _spiralCheckbox.Text = "Spiral";
            _spiralCheckbox.UseVisualStyleBackColor = true;
            _spiralCheckbox.CheckedChanged += new EventHandler(spiralCheckbox_CheckedChanged);
            // 
            // openFileDialog1
            // 
            _openFileDialog1.FileName = "openFileDialog1";
            _openFileDialog1.Filter = "All files (*.*)|*.*|JPEG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif|PNG Files (*" +
    ".png)|*.png|BMP Files (*.bmp)|*.bmp";
            _openFileDialog1.Title = "Select a picture file";
            // 
            // drawButton
            // 
            _drawButton.Location = new Point(165, 3);
            _drawButton.Name = "drawButton";
            _drawButton.Size = new Size(75, 23);
            _drawButton.TabIndex = 4;
            _drawButton.Text = "Draw!";
            _drawButton.UseVisualStyleBackColor = true;
            _drawButton.Click += new EventHandler(drawButton_Click);
            // 
            // MainForm
            // 
            ClientSize = new Size(784, 561);
            Controls.Add(_tableLayoutPanel1);
            Name = "MainForm";
            _tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(_pictureBox1)).EndInit();
            _flowLayoutPanel1.ResumeLayout(false);
            _flowLayoutPanel1.PerformLayout();
            _flowLayoutPanel2.ResumeLayout(false);
            _flowLayoutPanel2.PerformLayout();
            ResumeLayout(false);

        }

        private Image ApplyMonochromeFilter(Image image)
        {
            var monochromeImage = new Bitmap(image);
            for (var x = 0; x < monochromeImage.Width; x++)
            {
                for (var y = 0; y < monochromeImage.Height; y++)
                {
                    var originalColor = monochromeImage.GetPixel(x, y);
                    var grayValue = (int)(originalColor.R * 0.3 + originalColor.G * 0.59 + originalColor.B * 0.11);
                    var grayColor = Color.FromArgb(grayValue, grayValue, grayValue);
                    monochromeImage.SetPixel(x, y, grayColor);
                }
            }

            return monochromeImage;
        }

        private Bitmap ApplySpiralTransform(Bitmap source)
        {
            var width = source.Width;
            var height = source.Height;
            var result = new Bitmap(width, height);

            var centerX = width / 2.0;
            var centerY = height / 2.0;
            var spiralFactor = 0.02;

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    var dx = x - centerX;
                    var dy = y - centerY;
                    var r = Math.Sqrt(dx * dx + dy * dy);
                    var theta = Math.Atan2(dy, dx);

                    var newTheta = theta + spiralFactor * r;

                    var srcX = (int)(centerX + r * Math.Cos(newTheta));
                    var srcY = (int)(centerY + r * Math.Sin(newTheta));

                    if (srcX >= 0 && srcX < width && srcY >= 0 && srcY < height)
                    {
                        Color color = source.GetPixel(srcX, srcY);
                        result.SetPixel(x, y, color);
                    }
                    else
                    {
                        result.SetPixel(x, y, Color.Black);
                    }
                }
            }

            return result;
        }


        private void showButton_Click(object sender, EventArgs e)
        {
            if (_openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                _pictureBox1.Load(_openFileDialog1.FileName);
                _originalImage = _pictureBox1.Image;
                _imageConverted = false;
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            _pictureBox1.Image = null;
        }

        private void backgroundButton_Click(object sender, EventArgs e)
        {
            if (_colorDialog1.ShowDialog() == DialogResult.OK)
                _pictureBox1.BackColor = _colorDialog1.Color;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void stretchCheckbox_CheckedChanged_1(object sender, EventArgs e)
        {
            if (_stretchCheckbox.Checked)
                _pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            else
                _pictureBox1.SizeMode = PictureBoxSizeMode.Normal;
        }

        private void monochromeCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (_pictureBox1.Image == null)
                return;
            
            if (_monochromeCheckbox.Checked)
                _pictureBox1.Image = ApplyMonochromeFilter(_pictureBox1.Image);
            else
                _pictureBox1.Image = _originalImage;
        }

        private void spiralCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (_pictureBox1.Image == null)
                return;

            if (_spiralCheckbox.Checked)
            {
                var bmp = new Bitmap(_pictureBox1.Image);
                _pictureBox1.Image = ApplySpiralTransform(bmp);
            }
            else
            {
                _pictureBox1.Image = _originalImage;
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            _isDrawing = true;
            var p = _pictureBox1.SizeMode == PictureBoxSizeMode.Normal
                    ? e.Location
                    : TranslateToImageCoordinates(e.X, e.Y);
            DrawCircle(p, 3);
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isDrawing)
            {
                var p = _pictureBox1.SizeMode == PictureBoxSizeMode.Normal 
                    ? e.Location
                    : TranslateToImageCoordinates(e.X, e.Y);
                DrawCircle(p, 3);
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            _isDrawing = false;
        }

        private void DrawCircle(Point center, int radius)
        {
            if (_pictureBox1.Image == null || !_imageConverted)
                return;

            using (Graphics g = Graphics.FromImage(_pictureBox1.Image))
            using (SolidBrush brush = new SolidBrush(_drawColor))
            {
                g.FillEllipse(brush, center.X - radius, center.Y - radius, radius * 2, radius * 2);
            }
            _pictureBox1.Invalidate();
        }

        // cannot draw on indexed images, so convert all images to non-indexed
        private Bitmap ConvertToNonIndexed(Image img)
        {
            var newBitmap = new Bitmap(img.Width, img.Height, PixelFormat.Format32bppArgb);
            using (var g = Graphics.FromImage(newBitmap))
            {
                g.DrawImage(img, new Rectangle(0, 0, newBitmap.Width, newBitmap.Height));
            }
            return newBitmap;
        }

        private void drawButton_Click(object sender, EventArgs e)
        {
            if (_colorDialog1.ShowDialog() != DialogResult.OK)
                return;

            _drawColor = _colorDialog1.Color;
            if (_pictureBox1.Image != null)
            {
                _pictureBox1.Image = ConvertToNonIndexed(_pictureBox1.Image);
                _imageConverted = true;
            }
        }

        // when image is streched, coordinates need to be translated
        private Point TranslateToImageCoordinates(int x, int y)
        {
            if (_pictureBox1.Image == null)
                return Point.Empty;

            var imageWidth = _pictureBox1.Image.Width;
            var imageHeight = _pictureBox1.Image.Height;
            var boxWidth = _pictureBox1.Width;
            var boxHeight = _pictureBox1.Height;

            var scaleX = (float)imageWidth / boxWidth;
            var scaleY = (float)imageHeight / boxHeight;

            var imgX = (int)(x * scaleX);
            var imgY = (int)(y * scaleY);

            return new Point(imgX, imgY);
        }
    }
}
