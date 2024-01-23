using QRCoder;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Png;
using System;
using System.IO;
using ClinicNest.Core.Extensions;
using ClinicNest.Core.Interface.Base;
using ClinicNest.Infra.ApiClients.Resources;

namespace ClinicNest.Infra.ApiClients.Apis
{
    public class QrCodeGenerator<T> : IQrCodeGenerator<T> 
        where T : class
    {
        public byte[] GenerateImage(T obj)
        {
            var qrGenerator = new QRCodeGenerator();
            var dados = obj.ToJson();
            var qrCodeData = qrGenerator.CreateQrCode(dados, QRCodeGenerator.ECCLevel.Q);
            var qrCode = new QRCode(qrCodeData);
            var tkeLogo = Image.Load(new MemoryStream(Convert.FromBase64String(QrCodeResources._qrCodeTkeLogoBase64)));
            
            byte[] qrCodeImage = ImageToBytes(qrCode.GetGraphic(20, Color.Black, Color.White, tkeLogo, 25, 1));
            
            return qrCodeImage;
        }

        private static byte[] ImageToBytes(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, new PngEncoder());
                return ms.ToArray();
            }
        }
    }
}