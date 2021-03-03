// Decompiled with JetBrains decompiler
// Type: SkeetUI.skeetSlider
// Assembly: SkeetUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A8981399-0D5A-4A7D-BBCC-C3689C257763
// Assembly location: C:\Users\simon\Desktop\cockbox\FemboyWare\FemboyLoader\SkrtLoader MEMORIES#8221\API Example\bin\Debug\Release\SkeetUI.dll

using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Reflection;
using System.Windows.Forms;

namespace SkeetUI
{
  public class skeetSlider : UserControl
  {
    private bool skeetShowTitle = true;
    private string skeetTitle = nameof (skeetSlider);
    private bool skeetShowValue = true;
    private string skeetValueSuffix = "";
    private string skeetValuePrefix = "";
    private Color sliderColor = Color.FromArgb(154, 197, 39);
    private Color sliderBack = Color.FromArgb(52, 52, 52);
    private double skeetMax = 2.0;
    private double skeetMin = 1.0;
    private double skeetValue = 1.5;
    private int skeetFormatLen = 2;
    private Bitmap sliderback = new Bitmap(1, 6);
    private Bitmap slidercolor = new Bitmap(1, 6);
    private bool invertTitleColor;
    private int offset;
    private IContainer components;
    private Panel panel1;
    private Panel pnlSlider;
    private outlineLabel lbSliderValue;
    private transparentPanel pnlSliderBox;
    private shadowLabel lbTitle;

    [Description("Inverts the ForeColor of the labels")]
    [Category("SkeetUI - Texts")]
    [DefaultValue(false)]
    public bool InvertTitleColor
    {
      get
      {
        return this.invertTitleColor;
      }
      set
      {
        this.invertTitleColor = value;
        Color black = Color.Black;
        Color color = Color.FromArgb(190, 190, 190);
        if (value)
        {
          this.lbTitle.ForeColor = black;
          this.lbTitle.ShadowColor = color;
        }
        else
        {
          this.lbTitle.ForeColor = color;
          this.lbTitle.ShadowColor = black;
        }
      }
    }

    [Description("Show title above slider")]
    [Category("SkeetUI - Texts")]
    [DefaultValue(true)]
    public bool ShowTitle
    {
      get
      {
        return this.skeetShowTitle;
      }
      set
      {
        this.skeetShowTitle = value;
        this.lbTitle.Visible = value;
      }
    }

    [Description("Text of the title")]
    [Category("SkeetUI - Texts")]
    [DefaultValue("skeetSlider")]
    public string Title
    {
      get
      {
        return this.skeetTitle;
      }
      set
      {
        if (!string.IsNullOrEmpty(value))
          this.skeetTitle = value;
        this.lbTitle.Text = this.skeetTitle;
      }
    }

    [Description("Show value of the slider beside it")]
    [Category("SkeetUI - Texts")]
    [DefaultValue(true)]
    public bool ShowValue
    {
      get
      {
        return this.skeetShowValue;
      }
      set
      {
        this.skeetShowValue = value;
        this.lbSliderValue.Visible = value;
      }
    }

    [Description("Suffix that should get together with the value")]
    [Category("SkeetUI - Texts")]
    [DefaultValue("")]
    public string ValueSuffix
    {
      get
      {
        return this.skeetValueSuffix;
      }
      set
      {
        this.skeetValueSuffix = value;
        this.updateValue();
      }
    }

    [Description("Prefix that should get together with the value")]
    [Category("SkeetUI - Texts")]
    [DefaultValue("")]
    public string ValuePrefix
    {
      get
      {
        return this.skeetValuePrefix;
      }
      set
      {
        this.skeetValuePrefix = value;
        this.updateValue();
      }
    }

    [Description("Color of the slider")]
    [Category("SkeetUI - Slider")]
    [DefaultValue(null)]
    public Color SliderColor
    {
      get
      {
        return this.sliderColor;
      }
      set
      {
        this.sliderColor = value;
        this.updateColor();
      }
    }

    [Description("Color of the background of the slider")]
    [Category("SkeetUI - Slider")]
    [DefaultValue(null)]
    public Color SliderBackgroundColor
    {
      get
      {
        return this.sliderBack;
      }
      set
      {
        this.sliderBack = value;
        this.updateColor();
      }
    }

    [Description("Amount of decimal places that value shows")]
    [Category("SkeetUI - Slider")]
    [DefaultValue(2)]
    public int FormatDecimal
    {
      get
      {
        return this.skeetFormatLen;
      }
      set
      {
        if (value >= 0)
          this.skeetFormatLen = value;
        this.updateValue();
      }
    }

    [Description("Current slider value")]
    [Category("SkeetUI - Slider")]
    [DefaultValue(1.5)]
    public double Value
    {
      get
      {
        return this.skeetValue;
      }
      set
      {
        double num1 = value;
        if (num1 >= this.skeetMin && this.skeetMax >= num1)
        {
          this.skeetValue = value;
          this.updateValue();
        }
        else
        {
          int num2 = (int) MessageBox.Show("Value can't be lower than minimum or higher than maximum.");
        }
      }
    }

    [Description("Max value that the slider can reach")]
    [Category("SkeetUI - Slider")]
    [DefaultValue(2.0)]
    public double MaxValue
    {
      get
      {
        return this.skeetMax;
      }
      set
      {
        double num1 = value;
        if (num1 >= this.skeetMin)
        {
          if (num1 >= this.skeetValue)
          {
            this.skeetMax = value;
            if (!this.DesignMode)
              this.skeetValue = value;
            this.updateValue();
          }
          else
          {
            int num2 = (int) MessageBox.Show("Current value can't be higher than maximum value (" + (object) this.skeetValue + ">" + (object) num1 + ")");
          }
        }
        else
        {
          int num3 = (int) MessageBox.Show("Max value can't be lower than minimum value (" + (object) num1 + ">" + (object) this.skeetMin + ")");
        }
      }
    }

    [Description("Minimum value that the slider needs")]
    [Category("SkeetUI - Slider")]
    [DefaultValue(1.0)]
    public double MinValue
    {
      get
      {
        return this.skeetMin;
      }
      set
      {
        double num1 = value;
        if (num1 <= this.skeetMax)
        {
          if (this.skeetValue >= num1)
          {
            this.skeetMin = value;
            this.updateValue();
          }
          else
          {
            int num2 = (int) MessageBox.Show("Current value can't be lower than minimum value (" + (object) num1 + ">" + (object) this.skeetValue + ")");
          }
        }
        else
        {
          int num3 = (int) MessageBox.Show("Minimum value can't be higher than maximum value (" + (object) num1 + ">" + (object) this.skeetMax + ")");
        }
      }
    }

    public static Color changeColorBrightness(Color color, float correctionFactor)
    {
      float r = (float) color.R;
      float g = (float) color.G;
      float b = (float) color.B;
      float num1;
      float num2;
      float num3;
      if ((double) correctionFactor < 0.0)
      {
        correctionFactor = 1f + correctionFactor;
        num1 = r * correctionFactor;
        num2 = g * correctionFactor;
        num3 = b * correctionFactor;
      }
      else
      {
        num1 = ((float) byte.MaxValue - r) * correctionFactor + r;
        num2 = ((float) byte.MaxValue - g) * correctionFactor + g;
        num3 = ((float) byte.MaxValue - b) * correctionFactor + b;
      }
      return Color.FromArgb((int) color.A, (int) num1, (int) num2, (int) num3);
    }

    private void updateColor()
    {
      this.sliderback.SetPixel(0, 0, this.sliderBack);
      this.slidercolor.SetPixel(0, 0, this.sliderColor);
      int y = 1;
      float correctionFactor = 0.02f;
      while (0.100000001490116 >= (double) correctionFactor)
      {
        this.sliderback.SetPixel(0, y, skeetSlider.changeColorBrightness(this.sliderBack, correctionFactor));
        this.slidercolor.SetPixel(0, y, skeetSlider.changeColorBrightness(this.sliderColor, (float) (-(double) correctionFactor * 2.0)));
        correctionFactor += 0.02f;
        ++y;
      }
      this.updateSlider();
    }

    private void updateValue()
    {
      this.offset = 0;
      Size size = TextRenderer.MeasureText(this.skeetValuePrefix + string.Format("{0:F" + (object) this.skeetFormatLen + "}", (object) this.skeetMax) + this.skeetValueSuffix, new Font("Verdana", 7.2f, FontStyle.Bold));
      if (size.Width / 2 > 15)
      {
        int x = size.Width / 2;
        this.pnlSliderBox.Location = new Point(x, this.pnlSliderBox.Location.Y);
        this.lbTitle.Location = new Point(x + 1, this.lbTitle.Location.Y);
        this.offset = x;
      }
      else
      {
        this.offset = 15;
        this.pnlSliderBox.Location = new Point(15, 0);
        this.lbTitle.Location = new Point(15, 1);
      }
      this.lbSliderValue.Text = this.skeetValuePrefix + string.Format("{0:F" + (object) this.skeetFormatLen + "}", (object) this.skeetValue) + this.skeetValueSuffix;
      this.pnlSliderBox.Width = this.Width - this.offset * 2;
      this.updateSlider();
    }

    public skeetSlider()
    {
      this.InitializeComponent();
      this.DoubleBuffered = true;
      skeetSlider.SetDoubleBuffered((Control) this.pnlSlider);
      this.updateColor();
      this.updateValue();
      this.MinimumSize = new Size(100, 40);
    }

    private void updateSlider()
    {
      double num = (this.skeetValue - this.skeetMin) / ((this.skeetMax - this.skeetMin) / (double) (this.pnlSliderBox.Width - 2));
      this.pnlSlider.BackgroundImage = (Image) this.drawSlider((Control) this.pnlSliderBox, Convert.ToInt32(num));
      this.lbSliderValue.Location = new Point(Convert.ToInt32(num) + this.offsetValueSwitch(this.lbSliderValue.Text.Length), this.lbSliderValue.Location.Y);
    }

    public static void SetDoubleBuffered(Control c)
    {
      if (SystemInformation.TerminalServerSession)
        return;
      typeof (Control).GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic).SetValue((object) c, (object) true, (object[]) null);
    }

    private int offsetValueSwitch(int i)
    {
      switch (i)
      {
        case 1:
          return 9;
        case 2:
          return 5;
        case 3:
          return 3;
        default:
          return 1;
      }
    }

    private Bitmap drawSlider(Control panel, int x)
    {
      Bitmap bitmap = new Bitmap(panel.Width + this.offset, panel.Height);
      if (x >= 0 && 3 >= x || -1 >= x)
        x = 3;
      if (x >= bitmap.Width)
        x = bitmap.Width;
      using (Graphics graphics = Graphics.FromImage((Image) bitmap))
      {
        graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
        graphics.DrawImage((Image) this.sliderback, 1 + this.offset, 1, (bitmap.Width - this.offset) * 2 - 4, bitmap.Height - 2);
        int num = 6;
        if (x >= bitmap.Width / 2)
          num = 2;
        graphics.DrawImage((Image) this.slidercolor, 1 + this.offset, 1, x * 2 - num, bitmap.Height - 2);
        using (Brush brush = (Brush) new SolidBrush(Color.FromArgb(0, 0, 0)))
        {
          Pen pen = new Pen(brush);
          graphics.DrawRectangle(pen, this.offset, 0, bitmap.Width - this.offset - 1, bitmap.Height - 1);
        }
      }
      return bitmap;
    }

    protected override void SetBoundsCore(
      int x,
      int y,
      int width,
      int height,
      BoundsSpecified specified)
    {
      if (this.DesignMode)
        base.SetBoundsCore(x, y, width, 40, specified);
      else
        base.SetBoundsCore(x, y, width, height, specified);
    }

    private void skeetSlider_Load(object sender, EventArgs e)
    {
    }

    private void pnlClick()
    {
      Point client = this.pnlSliderBox.PointToClient(Cursor.Position);
      this.pnlSlider.BackgroundImage = (Image) this.drawSlider((Control) this.pnlSliderBox, client.X);
      this.lbSliderValue.Location = new Point(client.X + this.offsetValueSwitch(this.lbSliderValue.Text.Length), this.lbSliderValue.Location.Y);
      double skeetMax = this.skeetMax;
      double skeetMin = this.skeetMin;
      double num1 = skeetMin;
      double num2 = (skeetMax - num1) / (double) (this.pnlSliderBox.Width - 2);
      int num3 = client.X;
      if (num3 >= this.pnlSliderBox.Width - 2)
        num3 = this.pnlSliderBox.Width - 2;
      if (num3 < 0)
        return;
      this.skeetValue = skeetMin + (double) num3 * num2;
      this.lbSliderValue.Text = this.skeetValuePrefix + string.Format("{0:F" + (object) this.skeetFormatLen + "}", (object) this.skeetValue) + this.skeetValueSuffix;
    }

    private void skeetSlider_Resize(object sender, EventArgs e)
    {
      this.pnlSliderBox.Width = this.Width - this.offset * 2;
      this.pnlSlider.Width = this.Width;
      this.updateSlider();
    }

    private void pnlSliderBox_Click(object sender, EventArgs e)
    {
      if (!this.pnlSliderBox.ClientRectangle.Contains(this.pnlSliderBox.PointToClient(Control.MousePosition)))
        return;
      this.pnlClick();
    }

    private void pnlSliderBox_MouseMove(object sender, MouseEventArgs e)
    {
      if (e.Button != MouseButtons.Left || !this.pnlSliderBox.ClientRectangle.Contains(this.pnlSliderBox.PointToClient(Control.MousePosition)))
        return;
      this.pnlClick();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.pnlSlider = new Panel();
      this.lbTitle = new shadowLabel();
      this.pnlSliderBox = new transparentPanel();
      this.lbSliderValue = new outlineLabel();
      this.pnlSlider.SuspendLayout();
      this.SuspendLayout();
      this.pnlSlider.BackColor = Color.Transparent;
      this.pnlSlider.BackgroundImageLayout = ImageLayout.None;
      this.pnlSlider.Controls.Add((Control) this.pnlSliderBox);
      this.pnlSlider.Controls.Add((Control) this.lbSliderValue);
      this.pnlSlider.Location = new Point(0, 17);
      this.pnlSlider.Name = "pnlSlider";
      this.pnlSlider.Size = new Size(158, 23);
      this.pnlSlider.TabIndex = 1;
      this.lbTitle.AutoSize = true;
      this.lbTitle.EnableShadow = true;
      this.lbTitle.Font = new Font("Tahoma", 7.23f);
      this.lbTitle.ForeColor = Color.FromArgb(190, 190, 190);
      this.lbTitle.Location = new Point(15, 2);
      this.lbTitle.Name = "lbTitle";
      this.lbTitle.ShadowColor = Color.Black;
      this.lbTitle.ShadowOffset = 1;
      this.lbTitle.Size = new Size(53, 12);
      this.lbTitle.TabIndex = 7;
      this.lbTitle.Text = nameof (skeetSlider);
      this.pnlSliderBox.BackColor = Color.Fuchsia;
      this.pnlSliderBox.Location = new Point(14, 0);
      this.pnlSliderBox.Name = "pnlSliderBox";
      this.pnlSliderBox.Size = new Size(128, 8);
      this.pnlSliderBox.TabIndex = 6;
      this.pnlSliderBox.Click += new EventHandler(this.pnlSliderBox_Click);
      this.pnlSliderBox.MouseMove += new MouseEventHandler(this.pnlSliderBox_MouseMove);
      this.lbSliderValue.AutoSize = true;
      this.lbSliderValue.Font = new Font("Verdana", 7.2f, FontStyle.Bold);
      this.lbSliderValue.ForeColor = Color.FromArgb(190, 190, 190);
      this.lbSliderValue.Location = new Point(65, 0);
      this.lbSliderValue.Name = "lbSliderValue";
      this.lbSliderValue.OutlineForeColor = Color.Black;
      this.lbSliderValue.OutlineWidth = 1.5f;
      this.lbSliderValue.Size = new Size(37, 12);
      this.lbSliderValue.TabIndex = 5;
      this.lbSliderValue.Text = "1.523";
      this.lbSliderValue.TextAlign = ContentAlignment.TopCenter;
      this.BackColor = Color.FromArgb(20, 20, 20);
      this.Controls.Add((Control) this.lbTitle);
      this.Controls.Add((Control) this.pnlSlider);
      this.Font = new Font("Verdana", 7.5f, FontStyle.Bold);
      this.Name = nameof (skeetSlider);
      this.Size = new Size(158, 40);
      this.Resize += new EventHandler(this.skeetSlider_Resize);
      this.pnlSlider.ResumeLayout(false);
      this.pnlSlider.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
