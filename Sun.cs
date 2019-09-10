using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kapitan_test
{
    class Sun: BaseObject
    {
        public Sun(Point pos, Point dir, Size size, Image newImage) : base(pos, dir, size, newImage) { }

        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(NewImage, Pos.X, Pos.Y);
        }

        public override void Update()
        {
            Pos.X = Pos.X- Dir.X;
            if (Pos.X < -Size.Width) Pos.X = Game.Width + Size.Width;
        }

        public override void Boom()
        {

        }
    }
}
