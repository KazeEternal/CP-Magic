using Sharable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLI_CP_Magic
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ImageHandler imageHandler = new ImageHandler(@"test.png");

            imageHandler.WriteChannel(@"testA.png", 
                ImageHandler.Channels.Green, 
                ImageHandler.Channels.Red | ImageHandler.Channels.Blue | ImageHandler.Channels.Green,
                ImageHandler.Format.PNG);
        }
    }
}
