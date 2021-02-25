using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace Pdf417lib
{
    public class cPDF417
    {
        public static Image ObtenerImagenCodigo(string texto, int ancho)
        {
            Pdf417lib pd = new Pdf417lib();
            pd.setText(texto);
            pd.Options = Pdf417lib.PDF417_INVERT_BITMAP;
            pd.paintCode();
            Image img = pd.DrawBarcodeImage(ancho);            
            return img;
        }
        
        public static Image EscalarImagen(Image img, int ancho)
        {
            int sourceWidth = img.Width; //Ancho de la imagen que queremos escalar
            int sourceHeight = img.Height; //Altura de la imagen que queremos escalar
            float Percent = (float)(100 * ancho) / (float)sourceWidth; //Calculamos el porcentaje de ancho que debemos reducir la imagen

            float nPercent = ((float)Percent / 100);

            int sourceX = 0;
            int sourceY = 0;

            int destX = 0;
            int destY = 0;
            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);

            Bitmap bmPhoto = new Bitmap(destWidth, destHeight,  PixelFormat.Format1bppIndexed);
            bmPhoto.SetResolution(img.HorizontalResolution, img.VerticalResolution);

            Graphics grPhoto = Graphics.FromImage(bmPhoto);
            grPhoto.InterpolationMode = InterpolationMode.Bicubic;

            grPhoto.FillRectangle(Brushes.White, destX, destY, destWidth, destHeight);

            grPhoto.DrawImage(img,
            new Rectangle(destX, destY, destWidth, destHeight),
            new Rectangle(sourceX, sourceY, sourceWidth, sourceHeight),
            GraphicsUnit.Pixel);

            img.Dispose();
            grPhoto.Dispose();

            return bmPhoto;
        }
    }
}
