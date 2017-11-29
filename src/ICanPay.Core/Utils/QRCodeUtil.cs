using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using ZXing;
using ZXing.Common;

namespace ICanPay.Core.Utils
{
    /// <summary>
    /// 二维码工具类
    /// </summary>
    public static class QrCodeUtil
    {

        #region 创建二维码

        /// <summary>
        /// 创建二维码
        /// </summary>
        /// <param name="content">内容</param>
        /// <param name="width">宽度</param>
        /// <param name="height">高度</param>
        /// <returns></returns>
        public static Bitmap Create(string content, int width, int height)
        {
            var qrWriter = new BarcodeWriterPixelData
            {
                Format = BarcodeFormat.QR_CODE,
                Options = new EncodingOptions
                {
                    Height = height,
                    Width = width
                }
            };

            var pixelData = qrWriter.Write(content);

            var bitmap = new Bitmap(pixelData.Width, pixelData.Height, PixelFormat.Format32bppRgb);
            var bitmapData = bitmap.LockBits(new Rectangle(0, 0, pixelData.Width, pixelData.Height),
                ImageLockMode.WriteOnly, PixelFormat.Format32bppRgb);
            try
            {
                Marshal.Copy(pixelData.Pixels, 0, bitmapData.Scan0, pixelData.Pixels.Length);
            }
            finally
            {
                bitmap.UnlockBits(bitmapData);
            }

            return bitmap;
        }

        #endregion 创建二维码

    }
}
