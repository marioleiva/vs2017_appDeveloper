using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using ZXing;
using ZXing.QrCode;

namespace Shop.Presentation.WebPage.Models
{
    public class Boleta
    {
        public string Serie { get; set; }
        public string NombreCliente { get; set; }
        public DateTime FechaDeVenta { get; set; }
        public double Monto { get; set; }
        public IEnumerable<Detalle> Detalles { get; set; }
        public string QREnBase64 { get; set; }

        public void CargarQr()
        {
            var options = new QrCodeEncodingOptions
            {
                DisableECI = true,
                CharacterSet = "UTF-8",
                Width = 250,
                Height = 250
            };
            var barcodeWriter = new BarcodeWriter();
            barcodeWriter.Options = options;
            barcodeWriter.Format = BarcodeFormat.QR_CODE;
            var bitmat = new Bitmap(barcodeWriter.Write(this.Serie));
            ImageConverter converter = new ImageConverter();
            var bitmapEnBase64 = Convert.ToBase64String((byte[])converter.ConvertTo(bitmat,typeof(byte[])));
            this.QREnBase64 = String.Format("data:image/gif;base64,{0}", bitmapEnBase64);
        }

    }

    public class Detalle
    {
        public string Descripcion { get; set; }
        public double SubTotal { get; set; }
    }
}