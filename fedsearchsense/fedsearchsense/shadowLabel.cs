// Decompiled with JetBrains decompiler
// Type: SkeetUI.shadowLabel
// Assembly: SkeetUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A8981399-0D5A-4A7D-BBCC-C3689C257763
// Assembly location: C:\Users\simon\Desktop\cockbox\FemboyWare\FemboyLoader\SkrtLoader MEMORIES#8221\API Example\bin\Debug\Release\SkeetUI.dll

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SkeetUI
{
  public class shadowLabel : Label
  {
    private Color _shadowColor = Color.LightGray;
    private int _shadowOffset = 1;
    private shadowLabel.Angles _angle;
    private bool _enableShadow;

    public shadowLabel()
    {
      this.SetStyle(ControlStyles.SupportsTransparentBackColor | ControlStyles.OptimizedDoubleBuffer, true);
    }

    [Description("Sets of the shadow")]
    public Color ShadowColor
    {
      get
      {
        return this._shadowColor;
      }
      set
      {
        this._shadowColor = value;
        this.Invalidate();
      }
    }

    [Description("Sets the offset of the shadow. Positives move right and down, negatives move left and up.")]
    public int ShadowOffset
    {
      get
      {
        return this._shadowOffset;
      }
      set
      {
        this._shadowOffset = value;
        this.Invalidate();
      }
    }

    [Description("Enables to shadow.")]
    public bool EnableShadow
    {
      get
      {
        return this._enableShadow;
      }
      set
      {
        this._enableShadow = value;
        this.Invalidate();
      }
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      if (this._enableShadow)
      {
        Rectangle rectangle = new Rectangle(this._shadowOffset, this._shadowOffset, this.Width, this.Height);
        SolidBrush solidBrush = new SolidBrush(Color.FromArgb((int) byte.MaxValue, this._shadowColor));
        e.Graphics.DrawString(this.Text, this.Font, (Brush) solidBrush, (RectangleF) rectangle, shadowLabel.ContentAlignmentToStringAlignment(this.TextAlign));
      }
      SizeF size = e.Graphics.VisibleClipBounds.Size;
      switch (this._angle)
      {
        case shadowLabel.Angles.LeftToRight:
          e.Graphics.TranslateTransform(0.0f, 0.0f);
          e.Graphics.RotateTransform(0.0f);
          e.Graphics.DrawString(this.Text, this.Font, (Brush) new SolidBrush(Color.FromArgb((int) byte.MaxValue, this.ForeColor)), new RectangleF(0.0f, 0.0f, size.Width, size.Height), shadowLabel.ContentAlignmentToStringAlignment(this.TextAlign));
          e.Graphics.ResetTransform();
          break;
        case shadowLabel.Angles.TopToBottom:
          e.Graphics.TranslateTransform(size.Width, 0.0f);
          e.Graphics.RotateTransform(90f);
          e.Graphics.DrawString(this.Text, this.Font, (Brush) new SolidBrush(Color.FromArgb((int) byte.MaxValue, this.ForeColor)), new RectangleF(0.0f, 0.0f, size.Height, size.Width), shadowLabel.ContentAlignmentToStringAlignment(this.TextAlign));
          e.Graphics.ResetTransform();
          break;
        case shadowLabel.Angles.RightToLeft:
          e.Graphics.TranslateTransform(size.Width, size.Height);
          e.Graphics.RotateTransform(180f);
          e.Graphics.DrawString(this.Text, this.Font, (Brush) new SolidBrush(Color.FromArgb((int) byte.MaxValue, this.ForeColor)), new RectangleF(0.0f, 0.0f, size.Width, size.Height), shadowLabel.ContentAlignmentToStringAlignment(this.TextAlign));
          e.Graphics.ResetTransform();
          break;
        case shadowLabel.Angles.BottomToTop:
          e.Graphics.TranslateTransform(0.0f, size.Height);
          e.Graphics.RotateTransform(270f);
          e.Graphics.DrawString(this.Text, this.Font, (Brush) new SolidBrush(Color.FromArgb((int) byte.MaxValue, this.ForeColor)), new RectangleF(0.0f, 0.0f, size.Height, size.Width), shadowLabel.ContentAlignmentToStringAlignment(this.TextAlign));
          e.Graphics.ResetTransform();
          break;
        default:
          throw new ArgumentOutOfRangeException();
      }
    }

    private static StringFormat ContentAlignmentToStringAlignment(ContentAlignment ca)
    {
      StringFormat stringFormat = new StringFormat();
      int num = (int) Math.Log((double) ca, 2.0);
      stringFormat.LineAlignment = (StringAlignment) (num / 4);
      stringFormat.Alignment = (StringAlignment) (num % 4);
      return stringFormat;
    }

    public enum Angles
    {
      LeftToRight = 0,
      TopToBottom = 90, // 0x0000005A
      RightToLeft = 180, // 0x000000B4
      BottomToTop = 270, // 0x0000010E
    }
  }
}
