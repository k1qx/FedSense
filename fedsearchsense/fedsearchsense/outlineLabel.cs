// Decompiled with JetBrains decompiler
// Type: SkeetUI.outlineLabel
// Assembly: SkeetUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A8981399-0D5A-4A7D-BBCC-C3689C257763
// Assembly location: C:\Users\simon\Desktop\cockbox\FemboyWare\FemboyLoader\SkrtLoader MEMORIES#8221\API Example\bin\Debug\Release\SkeetUI.dll

using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SkeetUI
{
  public class outlineLabel : Label
  {
    public outlineLabel()
    {
      this.OutlineForeColor = Color.Green;
      this.OutlineWidth = 1.5f;
    }

    public Color OutlineForeColor { get; set; }

    public float OutlineWidth { get; set; }

    protected override void OnPaint(PaintEventArgs e)
    {
      e.Graphics.FillRectangle((Brush) new SolidBrush(this.BackColor), this.ClientRectangle);
      using (GraphicsPath path = new GraphicsPath())
      {
        using (Pen pen = new Pen(this.OutlineForeColor, this.OutlineWidth)
        {
          LineJoin = LineJoin.Round
        })
        {
          using (StringFormat format = new StringFormat())
          {
            using (Brush brush = (Brush) new SolidBrush(this.ForeColor))
            {
              path.AddString(this.Text, this.Font.FontFamily, (int) this.Font.Style, this.Font.Size, this.ClientRectangle, format);
              e.Graphics.ScaleTransform(1.3f, 1.35f);
              e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
              e.Graphics.DrawPath(pen, path);
              e.Graphics.FillPath(brush, path);
            }
          }
        }
      }
    }
  }
}
