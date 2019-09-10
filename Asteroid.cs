using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kapitan_test
{
    class Asteroid : BaseObject, IComparable, ICloneable
    {
        public int Power { get; set; } = 3;
        public Asteroid(Point pos, Point dir, Size size, Image newImage) : base(pos, dir, size, newImage)
        {
            //Power = 1;
        }

        public object Clone()
        {
            Image imgAsteroids = Properties.Resources._1;

            // Создаем копию нашего робота
            Asteroid asteroid = new Asteroid(new Point(Pos.X, Pos.Y), new Point(Dir.X, Dir.Y), new Size(Size.Width, Size.Height), imgAsteroids)
            { Power = Power };
            // Не забываем скопировать новому астероиду Power нашего астероида
            return asteroid;
        }
        int IComparable.CompareTo(object obj)
        {
            if (obj is Asteroid temp)
            {
                if (Power > temp.Power)
                    return 1;
                if (Power < temp.Power)
                    return -1;
                else
                    return 0;
            }
            throw new ArgumentException("Parameter is not а Asteroid!");
        }


        public override void Draw()
        {

            Game.Buffer.Graphics.DrawImage(NewImage, Pos.X, Pos.Y);
            //Game.Buffer.Graphics.FillEllipse(Brushes.White, Pos.X, Pos.Y, Size.Width, Size.Height);
        }


        public override void Update()
        {
            Random y = new Random();
            Pos.X = Pos.X + Dir.X;
            if (Pos.X < -Size.Width)
            {
                Pos.X = Game.Width + Size.Width;
                Pos.Y = y.Next(0, Game.Height-500);
            }
        }

        public override void Boom()
        {
            Random y = new Random();
            Power = 3;
            Pos.X = Game.Width;
            Pos.Y = y.Next(0, Game.Height - 500);
            //NewImage = Properties.Resources.cow1;

            int l = y.Next(0, 7);
            switch (l)
            {

                case 0: NewImage = Properties.Resources.superman; break;
                //case 6: NewImage = Properties.Resources.UPs6; break;
                //case 7: NewImage = Properties.Resources.UPs7; break;
                case 1: NewImage = Properties.Resources.serfer; break;
                case 2: NewImage = Properties.Resources.pacman; break;
                case 3: NewImage = Properties.Resources.aviaseles; break;
                case 4: NewImage = Properties.Resources.cometa; break;
                case 5: NewImage = Properties.Resources._1; break;
                case 6: NewImage = Properties.Resources._9; break;


            }
        }
    }
}
