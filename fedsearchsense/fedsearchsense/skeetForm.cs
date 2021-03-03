// Decompiled with JetBrains decompiler
// Type: SkeetUI.skeetForm
// Assembly: SkeetUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A8981399-0D5A-4A7D-BBCC-C3689C257763
// Assembly location: C:\Users\simon\Desktop\cockbox\FemboyWare\FemboyLoader\SkrtLoader MEMORIES#8221\API Example\bin\Debug\Release\SkeetUI.dll

using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SkeetUI
{
  public class skeetForm : Form
  {
    private bool skeetGradient = true;
    private Color skeetGradient1 = Color.FromArgb(55, 177, 218);
    private Color skeetGradient2 = Color.FromArgb(204, 91, 184);
    private Color skeetGradient3 = Color.FromArgb(204, 227, 53);
    private Bitmap gradientUpline = new Bitmap(3, 1);
    private Bitmap gradientDownline = new Bitmap(3, 1);
    public const int WM_NCLBUTTONDOWN = 161;
    public const int HT_CAPTION = 2;
    private const int WM_NCLBUTTONDBLCLK = 163;
    private const int WM_NCHITTEST = 132;
    private const int HTCLIENT = 1;
    private const int HTCAPTION = 2;
    private bool m_aeroEnabled;
    private const int CS_DROPSHADOW = 131072;
    private const int WM_NCPAINT = 133;
    private const int WM_ACTIVATEAPP = 28;
    private skeetForm.UITheme skeetTheme;
    private bool skeetResizable;

    [DllImport("dwmapi.dll")]
    public static extern int DwmExtendFrameIntoClientArea(
      IntPtr hWnd,
      ref skeetForm.MARGINS pMarInset);

    [DllImport("dwmapi.dll")]
    public static extern int DwmSetWindowAttribute(
      IntPtr hwnd,
      int attr,
      ref int attrValue,
      int attrSize);

    [DllImport("dwmapi.dll")]
    public static extern int DwmIsCompositionEnabled(ref int pfEnabled);

    [DllImport("Gdi32.dll")]
    private static extern IntPtr CreateRoundRectRgn(
      int nLeftRect,
      int nTopRect,
      int nRightRect,
      int nBottomRect,
      int nWidthEllipse,
      int nHeightEllipse);

    protected override CreateParams CreateParams
    {
      get
      {
        this.m_aeroEnabled = this.CheckAeroEnabled();
        CreateParams createParams = base.CreateParams;
        if (!this.m_aeroEnabled)
          createParams.ClassStyle |= 131072;
        return createParams;
      }
    }

    private bool CheckAeroEnabled()
    {
      if (Environment.OSVersion.Version.Major < 6)
        return false;
      int pfEnabled = 0;
      skeetForm.DwmIsCompositionEnabled(ref pfEnabled);
      return pfEnabled == 1;
    }

    protected override void WndProc(ref Message m)
    {
      switch (m.Msg)
      {
        case 132:
          base.WndProc(ref m);
          if ((int) m.Result != 1)
            return;
          if (this.skeetResizable)
          {
            Point client = this.PointToClient(new Point(m.LParam.ToInt32()));
            if (client.Y <= 10)
            {
              if (client.X <= 10)
              {
                m.Result = (IntPtr) 13;
                return;
              }
              if (client.X < this.Size.Width - 10)
              {
                m.Result = (IntPtr) 12;
                return;
              }
              m.Result = (IntPtr) 14;
              return;
            }
            int y = client.Y;
            Size size = this.Size;
            int num1 = size.Height - 10;
            if (y <= num1)
            {
              if (client.X <= 10)
              {
                m.Result = (IntPtr) 10;
                return;
              }
              int x = client.X;
              size = this.Size;
              int num2 = size.Width - 10;
              if (x < num2)
              {
                m.Result = (IntPtr) 2;
                return;
              }
              m.Result = (IntPtr) 11;
              return;
            }
            if (client.X <= 10)
            {
              m.Result = (IntPtr) 16;
              return;
            }
            int x1 = client.X;
            size = this.Size;
            int num3 = size.Width - 10;
            if (x1 < num3)
            {
              m.Result = (IntPtr) 15;
              return;
            }
            m.Result = (IntPtr) 17;
            return;
          }
          m.Result = (IntPtr) 2;
          return;
        case 133:
          if (this.m_aeroEnabled)
          {
            int attrValue = 2;
            skeetForm.DwmSetWindowAttribute(this.Handle, 2, ref attrValue, 4);
            skeetForm.MARGINS pMarInset = new skeetForm.MARGINS()
            {
              bottomHeight = 1,
              leftWidth = 0,
              rightWidth = 0,
              topHeight = 0
            };
            skeetForm.DwmExtendFrameIntoClientArea(this.Handle, ref pMarInset);
            break;
          }
          break;
      }
      if (m.Msg == 163)
      {
        m.Result = IntPtr.Zero;
      }
      else
      {
        base.WndProc(ref m);
        if (m.Msg != 132 || (int) m.Result != 1)
          return;
        m.Result = (IntPtr) 2;
      }
    }

    [DllImport("user32.dll")]
    public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

    [DllImport("user32.dll")]
    public static extern bool ReleaseCapture();

    [Description("Theme of the form")]
    [Category("SkeetUI - Form")]
    [DefaultValue(null)]
    public skeetForm.UITheme Theme
    {
      get
      {
        return this.skeetTheme;
      }
      set
      {
        this.skeetTheme = value;
        this.drawTheme();
      }
    }

    [Description("If form is resizable")]
    [Category("SkeetUI - Form")]
    [DefaultValue(false)]
    public bool Resizable
    {
      get
      {
        return this.skeetResizable;
      }
      set
      {
        this.skeetResizable = value;
      }
    }

    [Description("If gradient line is drawn")]
    [Category("SkeetUI - Form")]
    [DefaultValue(true)]
    public bool GradientLine
    {
      get
      {
        return this.skeetGradient;
      }
      set
      {
        this.skeetGradient = value;
      }
    }

    [Description("First color of the gradient")]
    [Category("SkeetUI - Form")]
    [DefaultValue(null)]
    public Color GradientColor1
    {
      get
      {
        return this.skeetGradient1;
      }
      set
      {
        this.skeetGradient1 = value;
        this.drawGradient();
        this.drawTheme();
      }
    }

    [Description("Second color of the gradient")]
    [Category("SkeetUI - Form")]
    [DefaultValue(null)]
    public Color GradientColor2
    {
      get
      {
        return this.skeetGradient2;
      }
      set
      {
        this.skeetGradient2 = value;
        this.drawGradient();
        this.drawTheme();
      }
    }

    [Description("Third color of the gradient")]
    [Category("SkeetUI - Form")]
    [DefaultValue(null)]
    public Color GradientColor3
    {
      get
      {
        return this.skeetGradient3;
      }
      set
      {
        this.skeetGradient3 = value;
        this.drawGradient();
        this.drawTheme();
      }
    }

    protected override void OnResize(EventArgs e)
    {
      base.OnResize(e);
      this.drawTheme();
    }

    public skeetForm()
    {
      this.FormBorderStyle = FormBorderStyle.None;
      this.DoubleBuffered = true;
      this.drawGradient();
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

    private void drawGradient()
    {
      this.gradientUpline.SetPixel(0, 0, this.skeetGradient1);
      this.gradientUpline.SetPixel(1, 0, this.skeetGradient2);
      this.gradientUpline.SetPixel(2, 0, this.skeetGradient3);
      this.gradientDownline.SetPixel(0, 0, skeetForm.changeColorBrightness(this.skeetGradient1, -0.5f));
      this.gradientDownline.SetPixel(1, 0, skeetForm.changeColorBrightness(this.skeetGradient2, -0.5f));
      this.gradientDownline.SetPixel(2, 0, skeetForm.changeColorBrightness(this.skeetGradient3, -0.5f));
    }

    private Color offsetColor(skeetForm.UITheme type, int offset)
    {
      if (type == skeetForm.UITheme.DARK)
        return Color.FromArgb(offset, offset, offset);
      return type == skeetForm.UITheme.LIGHT ? Color.FromArgb(240 - offset, 240 - offset, 240 - offset) : Color.Black;
    }

    private Color offsetColor(skeetForm.UITheme type, int offsetR, int offsetG, int offsetB)
    {
      if (type == skeetForm.UITheme.DARK)
        return Color.FromArgb(offsetR, offsetG, offsetB);
      return type == skeetForm.UITheme.LIGHT ? Color.FromArgb(240 - offsetR, 240 - offsetG, 240 - offsetB) : Color.Black;
    }

    public void drawTheme()
    {
      Bitmap bitmap = new Bitmap(this.Width, this.Height);
      using (Graphics graphics = Graphics.FromImage((Image) bitmap))
      {
        graphics.Clear(this.offsetColor(this.skeetTheme, 17));
        graphics.InterpolationMode = InterpolationMode.Bilinear;
        graphics.PixelOffsetMode = PixelOffsetMode.Half;
        if (this.skeetGradient)
        {
          graphics.DrawImage((Image) this.gradientUpline, 7, 7, bitmap.Width - 7, 1);
          graphics.DrawImage((Image) this.gradientDownline, 7, 8, bitmap.Width - 7, 1);
        }
        graphics.InterpolationMode = InterpolationMode.Bilinear;
        graphics.PixelOffsetMode = PixelOffsetMode.Default;
        Pen pen1 = new Pen((Brush) new SolidBrush(this.offsetColor(this.skeetTheme, 0)));
        graphics.DrawRectangle(pen1, 0, 0, bitmap.Width - 1, bitmap.Height - 1);
        Pen pen2 = new Pen((Brush) new SolidBrush(this.offsetColor(this.skeetTheme, 56)));
        graphics.DrawRectangle(pen2, 1, 1, bitmap.Width - 3, bitmap.Height - 3);
        Pen pen3 = new Pen((Brush) new SolidBrush(this.offsetColor(this.skeetTheme, 43)));
        graphics.DrawRectangle(pen3, 2, 2, bitmap.Width - 5, bitmap.Height - 5);
        Pen pen4 = new Pen((Brush) new SolidBrush(this.offsetColor(this.skeetTheme, 40)));
        graphics.DrawRectangle(pen4, 3, 3, bitmap.Width - 7, bitmap.Height - 7);
        graphics.DrawRectangle(pen4, 4, 4, bitmap.Width - 9, bitmap.Height - 9);
        Pen pen5 = new Pen((Brush) new SolidBrush(this.offsetColor(this.skeetTheme, 43)));
        graphics.DrawRectangle(pen5, 5, 5, bitmap.Width - 11, bitmap.Height - 11);
        Pen pen6 = new Pen((Brush) new SolidBrush(this.offsetColor(this.skeetTheme, 52)));
        graphics.DrawRectangle(pen6, 6, 6, bitmap.Width - 13, bitmap.Height - 13);
      }
      this.BackgroundImage = (Image) bitmap;
    }

    public struct MARGINS
    {
      public int leftWidth;
      public int rightWidth;
      public int topHeight;
      public int bottomHeight;
    }

    public enum UITheme
    {
      DARK,
      LIGHT,
    }
  }
}
