// Decompiled with JetBrains decompiler
// Type: SkeetUI.skeetButton
// Assembly: SkeetUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A8981399-0D5A-4A7D-BBCC-C3689C257763
// Assembly location: C:\Users\simon\Desktop\cockbox\FemboyWare\FemboyLoader\SkrtLoader MEMORIES#8221\API Example\bin\Debug\Release\SkeetUI.dll

using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SkeetUI
{
  public class skeetButton : UserControl
  {
    private string skeetText = nameof (skeetButton);
    private bool skeetEnabled = true;
    private bool hovering;
    private IContainer components;

    [Description("Text that is drawn in the button")]
    [Category("SkeetUI - Button")]
    [DefaultValue("")]
    public string ButtonText
    {
      get
      {
        return this.skeetText;
      }
      set
      {
        this.skeetText = value;
        this.drawButton();
      }
    }

    [Description("If button is enabled or not. Disables hovering and text gets darker")]
    [Category("SkeetUI - Button")]
    [DefaultValue("")]
    public bool ButtonEnabled
    {
      get
      {
        return this.skeetEnabled;
      }
      set
      {
        this.skeetEnabled = value;
        this.drawButton();
      }
    }

    public skeetButton()
    {
      this.InitializeComponent();
      this.DoubleBuffered = true;
      this.drawButton();
    }

    private void drawButton()
    {
      Bitmap bitmap = new Bitmap(this.Width, this.Height);
      using (Graphics graphics = Graphics.FromImage((Image) bitmap))
      {
        using (Brush brush = (Brush) new SolidBrush(Color.FromArgb(0, 0, 0)))
        {
          Pen pen = new Pen(brush);
          graphics.DrawRectangle(pen, 0, 0, this.Width - 1, this.Height - 1);
        }
        Color color = Color.FromArgb(50, 50, 50);
        if (this.hovering)
          color = Color.FromArgb(65, 65, 65);
        using (Brush brush = (Brush) new SolidBrush(color))
        {
          Pen pen = new Pen(brush);
          graphics.DrawRectangle(pen, 1, 1, this.Width - 3, this.Height - 3);
        }
        Rectangle rect = new Rectangle(2, 2, this.Width - 4, this.Height - 4);
        using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rect, Color.FromArgb(35, 35, 35), Color.FromArgb(25, 25, 25), 90f))
          graphics.FillRectangle((Brush) linearGradientBrush, rect);
        Rectangle rectangle = new Rectangle(0, 0, this.Width, this.Height);
        Font font = new Font("Tahoma", 7f, FontStyle.Bold);
        SizeF sizeF = graphics.MeasureString(this.skeetText, font, rectangle.Width);
        PointF point = new PointF((float) rectangle.X + (float) (((double) rectangle.Width - (double) sizeF.Width) / 2.0), (float) rectangle.Y + (float) (((double) rectangle.Height - (double) sizeF.Height) / 2.0));
        Brush brush1 = (Brush) new SolidBrush(Color.Black);
        graphics.DrawString(this.skeetText, font, brush1, point.X + 1f, point.Y + 1f);
        Brush brush2 = (Brush) new SolidBrush(Color.FromArgb(203, 203, 203));
        if (!this.skeetEnabled)
          brush2 = (Brush) new SolidBrush(Color.FromArgb(150, 150, 150));
        graphics.DrawString(this.skeetText, font, brush2, point);
      }
      this.BackgroundImage = (Image) bitmap;
    }

    private void skeetButton_Resize(object sender, EventArgs e)
    {
      this.drawButton();
    }

    private void skeetButton_MouseEnter(object sender, EventArgs e)
    {
      if (!this.skeetEnabled)
        return;
      this.hovering = true;
      this.drawButton();
    }

    private void skeetButton_MouseLeave(object sender, EventArgs e)
    {
      if (!this.skeetEnabled)
        return;
      this.hovering = false;
      this.drawButton();
    }

    protected override void OnClick(EventArgs e)
    {
      if (!this.skeetEnabled)
        return;
      base.OnClick(e);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.SuspendLayout();
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.Name = nameof (skeetButton);
      this.Size = new Size(139, 40);
      this.MouseEnter += new EventHandler(this.skeetButton_MouseEnter);
      this.MouseLeave += new EventHandler(this.skeetButton_MouseLeave);
      this.Resize += new EventHandler(this.skeetButton_Resize);
      this.ResumeLayout(false);
    }
  }
}
