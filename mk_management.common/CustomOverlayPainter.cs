using DevExpress.XtraSplashScreen;
using DevExpress.Utils.Drawing;
using System.Drawing;
using System;
//... 
internal class CustomOverlayPainter : OverlayWindowPainterBase
{
    // Defines the string’s font. 
    static readonly Font drawFont;
    static CustomOverlayPainter()
    {
        drawFont = new Font("Tahoma", 18);
    }
    protected override void Draw(OverlayWindowCustomDrawContext context)
    {

        context.Handled = true;
        GraphicsCache cache = context.DrawArgs.Cache;
        cache.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
        Rectangle bounds = context.DrawArgs.Bounds;
        context.DrawBackground();

        String drawString = "Please wait...";

        Brush drawBrush = Brushes.Black;

        SizeF textSize = cache.CalcTextSize(drawString, drawFont);

        PointF drawPoint = new PointF(
            bounds.Left + bounds.Width / 2 - textSize.Width / 2,
            bounds.Top + bounds.Height / 2 - textSize.Height / 2
            );

        cache.Graphics.DrawString(drawString, drawFont, drawBrush, drawPoint);
    }

   
}