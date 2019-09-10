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
    //public delegate void Message();


    class Ship : BaseObject
    {
        public static event Message MessageDie;
        public static event Message MessageChat;
        public static event Message MessageGold;
        private int _energy = 95;
        private int _shield = 0;
        private int _maxshield = 100;
        private int _maxEnergy = 100;
        private string name = "Nostromo";
        public string Name => name; 

        public int Energy { get => _energy; set => _energy = value; }
        public int Shield { get => _shield; set => _shield = value; }




    public Point Pozition()
        {
            return Pos;
        }

        public void EnergyLow(int n)
        {
            if (Shield > 0) Shield -= n;
            else Energy -= n;
        }
        public void EnergyUp(int n)
        {
            Energy += n;
            if (Energy > 100)
            {
                Energy = _maxEnergy;
                Shield += n;
                if (Shield > 100) Shield = _maxshield;
            }
        }



        public Ship(Point pos, Point dir, Size size, Image newImage) : base(pos, dir, size, newImage) { }
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(NewImage, Pos.X, Pos.Y);
            //Game.Buffer.Graphics.DrawRectangle(Pens.OrangeRed, Pos.X, Pos.Y, Size.Width, Size.Height);
        }


        public void ShipHpToscreen()
        {
            Game.Buffer.Graphics.DrawString("Energy:" + Energy, SystemFonts.DefaultFont, Brushes.White, Rect.X - 10, Rect.Y + 80);
            Game.Buffer.Graphics.DrawString("Hunted:" + Game.Hunted, SystemFonts.DefaultFont, Brushes.White, Rect.X - 0, Rect.Y + 93);

            int currentHp = Energy;
            int currentShield =Shield;

            var N = Brushes.White;
            var A = Brushes.Aqua;
            var W = Brushes.White;
            var R = Brushes.Red;
            var G = Brushes.Green;
            var O = Brushes.Orange;

            if (Energy > 0 && Energy <= 20) W = R;
            if (Energy > 20 && Energy <= 50) W = O;
            if (Energy > 50) W = G;
            if (Shield > 0) N = A;

            Game.Buffer.Graphics.FillRectangle(Brushes.White, Rect.X - 10, Rect.Y + 70, 104, 10);
            Game.Buffer.Render();
            Game.Buffer.Graphics.FillRectangle(Brushes.Black, Rect.X - 9, Rect.Y + 71, 102, 8);
            Game.Buffer.Render();
            Game.Buffer.Graphics.FillRectangle(W, Rect.X - 8, Rect.Y + 72, currentHp, 6);
            Game.Buffer.Render();
            Game.Buffer.Graphics.FillRectangle(N, Rect.X - 8, Rect.Y + 72, currentShield, 6);
            Game.Buffer.Render();
        }



        public void MoneyMaker()
        {
            MessageGold?.Invoke();
        }
        
        public override void Update()
        {
            Pos.X = Pos.X;
            Pos.Y = Pos.Y;
        }

        public void Up()
        {
            Pos.Y = Pos.Y - Dir.Y;
            if (Pos.Y < 0) Pos.Y = Game.Height + Size.Height;
        }

        public void Down()
        {
            Pos.Y = Pos.Y + Dir.Y;
            if (Pos.Y > Game.Height) Pos.Y = 0 + Size.Height;
        }
        public void Left()
        {
            Pos.X = Pos.X - Dir.X;
            if (Pos.X < 0) Pos.X = Game.Width + Size.Height;
        }
        public void Right()
        {
            Pos.X = Pos.X + Dir.X;
            if (Pos.X > Game.Width) Pos.X = 0 + Size.Height;
        }
        public void Die()
        {
            //NewImage = Properties.Resources.bb;
            MessageDie?.Invoke();
        }
        public void StartChat()
        {
            //NewImage = Properties.Resources.bb;
            MessageChat?.Invoke();
        }
        public void lvlUp()
        {
            if (Energy > 95 && Energy <= 100)
                NewImage = Properties.Resources.sps2;
            if (Shield > 30 && Shield < 60)
                NewImage = Properties.Resources.sps3;
            if (Shield > 60 && Shield < 100)
                NewImage = Properties.Resources.sps4;
        }

        public override void Boom()
        {
        }



    }
}
