using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyDesingPatternLogin
{
    class ProxyImage
    {
        private IImage imageLoader;
        public ProxyImage(bool userIsRegistered)
        {
            if(userIsRegistered)
            imageLoader =  new RealLoader();
            else
            imageLoader = new DummyLoader();
        }
        public Image LoadImage(string path)
        {
            return imageLoader.LoadImage(path);
        }

    }
}
