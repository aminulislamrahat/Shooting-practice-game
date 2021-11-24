using shooting_01.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shooting_01
{
    class CMole : CImageBase
    {
        private Rectangle _moleHotSpot = new Rectangle();
        public CMole()
            : base(Resources.Mole)
        {
            _moleHotSpot.X = Left - 8;
            _moleHotSpot.Y = Top + 30;
            _moleHotSpot.Width = 50;
            _moleHotSpot.Height = 50;
        }
        
        public void Update(int X,int Y)
        {
            Left = X;
            Top = Y;
            _moleHotSpot.X = Left - 8;
            _moleHotSpot.Y = Top + 30;
        }
        public bool Hit (int X, int Y)
        {
            Rectangle c = new Rectangle(X, Y, 0, 0); //create a cursor rect - quick way to check for list.
            if(_moleHotSpot.Contains(c))
            {
                return true;
            }
            return false;
        }
    }
}
