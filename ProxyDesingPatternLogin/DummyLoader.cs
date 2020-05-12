using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyDesingPatternLogin
{
    class DummyLoader : IImage
    {
        public Image LoadImage(string path)
        {
            return Properties.Resources.notRegistered;

        }
    }
}
