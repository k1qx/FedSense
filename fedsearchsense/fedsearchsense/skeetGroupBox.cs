// Decompiled with JetBrains decompiler
// Type: SkeetUI.skeetGroupBox
// Assembly: SkeetUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A8981399-0D5A-4A7D-BBCC-C3689C257763
// Assembly location: C:\Users\simon\Desktop\cockbox\FemboyWare\FemboyLoader\SkrtLoader MEMORIES#8221\API Example\bin\Debug\Release\SkeetUI.dll

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SkeetUI
{
  public class skeetGroupBox : Panel
  {
    private string skeetTitle = nameof (skeetGroupBox);
    private IContainer components;

    [Description("Title that is drawn on the box")]
    [Category("SkeetUI - GroupBox")]
    [DefaultValue("")]
    public string ButtonText
    {
      get
      {
        return this.skeetTitle;
      }
      set
      {
        this.skeetTitle = value;
        this.drawBox();
      }
    }

    public skeetGroupBox()
    {
      this.InitializeComponent();
      this.DoubleBuffered = true;
      this.drawBox();
    }

    private void drawBox()
    {
      Bitmap bitmap = new Bitmap(this.Width, this.Height);
      using (Graphics graphics = Graphics.FromImage((Image) bitmap))
      {
        using (Brush brush = (Brush) new SolidBrush(Color.FromArgb(0, 0, 0)))
        {
          Pen pen = new Pen(brush);
          graphics.DrawRectangle(pen, 0, 3, this.Width - 1, this.Height - 4);
        }
        using (Brush brush = (Brush) new SolidBrush(Color.FromArgb(48, 48, 48)))
        {
          Pen pen = new Pen(brush);
          graphics.DrawRectangle(pen, 1, 4, this.Width - 3, this.Height - 6);
        }
        if (!string.IsNullOrWhiteSpace(this.skeetTitle))
        {
          Font font = new Font("Tahoma", 7f, FontStyle.Bold);
          SizeF sizeF = graphics.MeasureString(this.skeetTitle, font);
          bitmap.SetPixel(10, 3, Color.Transparent);
          for (int x = 11; (double) x < (double) sizeF.Width + 15.0; ++x)
          {
            bitmap.SetPixel(x, 3, Color.Transparent);
            bitmap.SetPixel(x, 4, Color.Transparent);
          }
          Brush brush1 = (Brush) new SolidBrush(Color.Black);
          graphics.DrawString(this.skeetTitle, font, brush1, 15f, 0.0f);
          Brush brush2 = (Brush) new SolidBrush(Color.FromArgb(203, 203, 203));
          graphics.DrawString(this.skeetTitle, font, brush2, 14f, -1f);
        }
      }
      this.BackgroundImage = (Image) bitmap;
    }

    private void skeetGroupBox_Resize(object sender, EventArgs e)
    {
      this.drawBox();
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
      this.Name = nameof (skeetGroupBox);
      this.Size = new Size(247, 274);
      this.Resize += new EventHandler(this.skeetGroupBox_Resize);
      this.ResumeLayout(false);
    }
  }
}
