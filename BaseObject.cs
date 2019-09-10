using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Kapitan_test
{
    public delegate void Message();
    abstract class BaseObject : ICollision
    {
        protected Point Pos;
        protected Point Dir;
        protected Size Size;
        protected Image NewImage;



        protected BaseObject(Point pos, Point dir, Size size, Image newImage)
        {
            Pos = pos;
            Dir = dir;
            Size = size;
            NewImage = newImage;
        }
        public abstract void Draw();
        public abstract void Update();
        public abstract void Boom();

        public bool Collision(ICollision o) => o.Rect.IntersectsWith(this.Rect);
        public Rectangle Rect => new Rectangle(Pos, Size);
    }
}