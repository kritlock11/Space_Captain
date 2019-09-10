using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Kapitan_test
{
    class Star: BaseObject
    {
        public Star(Point pos, Point dir, Size size, Image newImage) : base(pos, dir, size, newImage) { }

        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(NewImage, Pos.X, Pos.Y);
        }
        public override void Update()
        {
            Pos.X = Pos.X + Dir.X;
            if (Pos.X < 0) Pos.X = Game.Width + Size.Width;
        }
        public override void Boom()
        {

        }
    }
}
