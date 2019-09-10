using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kapitan_test
{
    class PowerUps : BaseObject, IComparable
    {
        public static event Message OnPowerUp;

        public int Power { get; set; } = 3;
        public PowerUps(Point pos, Point dir, Size size, Image newImage) : base(pos, dir, size, newImage)
        {
            Power = 1;
        }

        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(NewImage, Pos.X, Pos.Y);
        }


        public override void Update()
        {
            Random y = new Random();
            Pos.X = Pos.X + Dir.X;
            if (Pos.X < -Size.Width)
            {
                Pos.X = Game.Width + Size.Width;
                Pos.Y = y.Next(0, Game.Height - 450);
            }
        }

        public  void powerUP()
        {

            OnPowerUp?.Invoke();
        }

        public override void Boom()
        {
            Random y = new Random();
            Pos.X = Game.Width;
            Pos.Y = y.Next(0, Game.Height - 450);
            int l = y.Next(0, 5);
            switch (l)
            {
                case 1: NewImage = Properties.Resources.UPs10; break;
                case 2: NewImage = Properties.Resources.UPs11; break;
                //case 3: NewImage = Properties.Resources.UPs7; break;
                //case 4: NewImage = Properties.Resources.UPs8; break;
            }
        }

        int IComparable.CompareTo(object obj)
        {
            if (obj is PowerUps temp)
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
    }
}
