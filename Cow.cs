using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kapitan_test
{
    class Cow : BaseObject
    {
        public Cow(Point pos, Point dir, Size size, Image newImage) : base(pos, dir, size, newImage){}
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(NewImage, Pos.X, Pos.Y);
            //Game.Buffer.Graphics.DrawRectangle(Pens.OrangeRed, Pos.X, Pos.Y, Size.Width, Size.Height);
        }
        public override void Update()
        {
            Random y = new Random();
            Pos.X = Pos.X + Dir.X;
            if (Pos.X < 0)
            {
                Pos.X = Game.Width + Size.Width;
                Pos.Y = y.Next(0, Game.Height);
            }

        }

        public override void Boom()
        {
        }

    }
}
