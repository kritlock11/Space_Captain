using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace Kapitan_test
{
    class Bullet : BaseObject
    {
        public Bullet(Point pos, Point dir, Size size, Image newImage) : base(pos, dir, size, newImage){}
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(NewImage, Pos.X, Pos.Y);
            //Game.Buffer.Graphics.DrawRectangle(Pens.OrangeRed, Pos.X, Pos.Y, Size.Width, Size.Height);
        }
        public override void Update()
        {
            Pos.X = Pos.X+ Dir.X;
            //if (Pos.X > Game.Width) ;
            //if (Pos.X > Game.Width) Pos.X = 0 + Size.Width;

        }

        public override void Boom()
        {
            //Random y = new Random();
            //Pos.X = 0;
            //Pos.Y = y.Next(0, Game.Height);
            //int l = y.Next(0, 6);
            //switch (l)
            //{
            //    case 1: NewImage = Properties.Resources.sps1; break;
            //    case 2: NewImage = Properties.Resources.sps2; break;
            //    case 3: NewImage = Properties.Resources.sps3; break;
            //    case 4: NewImage = Properties.Resources.sps4; break;
            //    case 5: NewImage = Properties.Resources.sps5; break;
            //}
        }

    }
}
