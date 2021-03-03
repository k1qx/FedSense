// Decompiled with JetBrains decompiler
// Type: transparentPanel
// Assembly: SkeetUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A8981399-0D5A-4A7D-BBCC-C3689C257763
// Assembly location: C:\Users\simon\Desktop\cockbox\FemboyWare\FemboyLoader\SkrtLoader MEMORIES#8221\API Example\bin\Debug\Release\SkeetUI.dll

using System.Windows.Forms;

public class transparentPanel : Panel
{
  protected override CreateParams CreateParams
  {
    get
    {
      CreateParams createParams = base.CreateParams;
      createParams.ExStyle |= 32;
      return createParams;
    }
  }

  protected override void OnPaintBackground(PaintEventArgs e)
  {
  }
}
