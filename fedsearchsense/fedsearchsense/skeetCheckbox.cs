// Decompiled with JetBrains decompiler
// Type: SkeetUI.skeetCheckbox
// Assembly: SkeetUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A8981399-0D5A-4A7D-BBCC-C3689C257763
// Assembly location: C:\Users\simon\Desktop\cockbox\FemboyWare\FemboyLoader\SkrtLoader MEMORIES#8221\API Example\bin\Debug\Release\SkeetUI.dll

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SkeetUI
{
  public class skeetCheckbox : UserControl
  {
    private string skeetTitle = nameof (skeetCheckbox);
    private Color checkColor = Color.FromArgb(154, 197, 39);
    private bool boxChecked;
    private IContainer components;
    private shadowLabel shadowLabel;

    [Description("If checkbox is checked")]
    [Category("SkeetUI - Checkbox")]
    [DefaultValue("")]
    public bool Checked
    {
      get
      {
        return this.boxChecked;
      }
      set
      {
        this.boxChecked = value;
        this.drawCheckbox();
      }
    }

    [Description("Color of checkbox when checked")]
    [Category("SkeetUI - Checkbox")]
    [DefaultValue("")]
    public Color ColorChecked
    {
      get
      {
        return this.checkColor;
      }
      set
      {
        this.checkColor = value;
        this.drawCheckbox();
      }
    }

    [Description("Color of checkbox when checked")]
    [Category("SkeetUI - Checkbox")]
    [DefaultValue("")]
    public string CheckBoxTitle
    {
      get
      {
        return this.skeetTitle;
      }
      set
      {
        this.skeetTitle = value;
        this.shadowLabel.Text = this.skeetTitle;
        this.Width = 8 + this.shadowLabel.Width + 13;
        this.drawCheckbox();
      }
    }

    public skeetCheckbox()
    {
      this.InitializeComponent();
      this.DoubleBuffered = true;
      this.drawCheckbox();
    }

    private void drawCheckbox()
    {
      Bitmap bitmap = new Bitmap(8, 12);
      using (Graphics graphics = Graphics.FromImage((Image) bitmap))
      {
        Color color = Color.FromArgb(75, 75, 75);
        Brush brush1 = (Brush) new SolidBrush(color);
        if (this.boxChecked)
        {
          color = this.checkColor;
          brush1 = (Brush) new SolidBrush(color);
        }
        float correctionFactor = -0.02f;
        for (int index = 1; 7 >= index; ++index)
        {
          Pen pen = new Pen(brush1);
          graphics.DrawLine(pen, 1, index + 4, 6, index + 4);
          color = this.ChangeColorBrightness(color, correctionFactor);
          brush1 = (Brush) new SolidBrush(color);
          correctionFactor -= 0.02f;
        }
        using (Brush brush2 = (Brush) new SolidBrush(Color.FromArgb(0, 0, 0)))
        {
          Pen pen = new Pen(brush2);
          graphics.DrawRectangle(pen, 0, 4, 7, 7);
        }
      }
      this.BackgroundImage = (Image) bitmap;
    }

    private Color ChangeColorBrightness(Color color, float correctionFactor)
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

    protected override void SetBoundsCore(
      int x,
      int y,
      int width,
      int height,
      BoundsSpecified specified)
    {
      if ((specified & BoundsSpecified.Height) != BoundsSpecified.None && height != 16)
        return;
      base.SetBoundsCore(x, y, width, 16, specified);
    }

    private void skeetCheckbox_Click(object sender, EventArgs e)
    {
      this.boxChecked = !this.boxChecked;
      this.drawCheckbox();
    }

    private void shadowLabel_Click(object sender, EventArgs e)
    {
      this.boxChecked = !this.boxChecked;
      this.drawCheckbox();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.shadowLabel = new shadowLabel();
      this.SuspendLayout();
      this.shadowLabel.AutoSize = true;
      this.shadowLabel.EnableShadow = true;
      this.shadowLabel.Font = new Font("Tahoma", 7.23f);
      this.shadowLabel.ForeColor = Color.FromArgb(190, 190, 190);
      this.shadowLabel.Location = new Point(19, 1);
      this.shadowLabel.Name = "shadowLabel";
      this.shadowLabel.ShadowColor = Color.Black;
      this.shadowLabel.ShadowOffset = 1;
      this.shadowLabel.Size = new Size(74, 12);
      this.shadowLabel.TabIndex = 0;
      this.shadowLabel.Text = nameof (skeetCheckbox);
      this.shadowLabel.Click += new EventHandler(this.shadowLabel_Click);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackgroundImageLayout = ImageLayout.None;
      this.Controls.Add((Control) this.shadowLabel);
      this.Name = nameof (skeetCheckbox);
      this.Size = new Size(91, 16);
      this.Click += new EventHandler(this.skeetCheckbox_Click);
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
