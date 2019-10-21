using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharable
{
    public class Class1
    {
        public static void Test()
        {
            Bitmap bit = new Bitmap(@"test.png");
            for(int y = 0; y <= bit.Height; y++)
            {
                for(int x = 0; x <= bit.Width; x++)
                {
                    var pixel = bit.GetPixel(x, y);
                    
                }
            }
        }
    }
}
