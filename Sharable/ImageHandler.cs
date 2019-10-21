using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharable
{
    public class ImageHandler
    {
        public enum Channels
        {
            Red = 0x1,
            Green = 0x2,
            Blue = 0x4,
            Alpha = 0x8
        }

        public enum Format
        {
            PNG
        }

        private Bitmap m_ToConvert = null;
        public bool IsLoaded { get; private set; } = false;
        public ImageHandler(string path)
        {
            FileInfo fInfo = new FileInfo(path);
            if (fInfo.Exists)
            {
                m_ToConvert = new Bitmap(path);
                IsLoaded = true;
            }
        }

        public bool WriteChannel(string output, Channels channelToWrite, Channels outputChannels, Format format)
        {
            bool retValueSuccess = false;
            if (IsLoaded)
            {
                Bitmap outputMap = new Bitmap(m_ToConvert.Width, m_ToConvert.Height);
                
                for (int y = 0; y < m_ToConvert.Height; y++)
                {
                    for (int x = 0; x < m_ToConvert.Width; x++)
                    {
                        int pixel = RetrieveDesiredChannel(m_ToConvert.GetPixel(x, y), channelToWrite);
                        
                        outputMap.SetPixel(x, y, CreateColor(pixel, outputChannels));
                    }
                }

                try
                {
                    FileInfo outputInfo = new FileInfo(output);
                    outputMap.Save(outputInfo.OpenWrite(), ImageFormat.Png);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return retValueSuccess;
                }

                retValueSuccess = true;
            }
            return retValueSuccess;
        }

        private Color CreateColor(int pixel, Channels outputChannels)
        {
            int blue = 0;
            int green = 0;
            int red = 0;

            if ((outputChannels & Channels.Blue) > 0)
            {
                blue = pixel;
            }

            if ((outputChannels & Channels.Red) > 0)
            {
                red = pixel;
            }

            if ((outputChannels & Channels.Green) > 0)
            {
                green = pixel;
            }

            return Color.FromArgb(red, green, blue);
        }

        private int RetrieveDesiredChannel(Color color, Channels channel)
        {
            int retVal = 255;
            switch(channel)
            {
                case Channels.Red:
                    retVal = (int)color.R;
                    break;
                case Channels.Green:
                    retVal = (int)color.G;
                    break;
                case Channels.Blue:
                    retVal = (int)color.B;
                    break;
                case Channels.Alpha:
                    retVal = (int)color.A;
                    break;
            }
            return retVal;
        }
    }
}
