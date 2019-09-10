using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace Kapitan_test
{
    class Game
    {
        private static Timer timer = new Timer { Interval = 50 };
        public static Random Rnd = new Random();
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;
        public static int Width { get; set; }
        public static int Height { get; set; }
        static Game() { }



        public static void Init(Form form)
        {
            Graphics g;

            _context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();
            Width = form.ClientSize.Width;
            Height = form.ClientSize.Height;
            Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));
            Load();

            timer.Start();
            timer.Tick += Timer_Tick;

            PowerUps.OnPowerUp += PowUp;
            Ship.MessageDie += Finish;
            Ship.MessageChat += ChatStarts;
            Ship.MessageGold += MoneyCount;
            form.KeyDown += Form_KeyDown;
            form.KeyUp += Form_KeyUp;

        }

        public static void Finish()
        {
            timer.Stop();
            Buffer.Graphics.DrawImage(imgGameOwer, 860, 450);
            Buffer.Render();
        }


        public static void PowUp()
        {
            isDoubleShotActive = true;
        }


        public static void Cloz()
        {
            Form.ActiveForm.Close();
        }


        private static bool isDoubleShotActive = false;
        private static bool isPressSpace = false;
        private static bool isAsteroidCollised = false;
        private static bool isPowerupsOn = false;
        private static bool isAsteroidDead = false;
        private static bool isPressW = false;
        private static bool isPressS = false;
        private static bool isPressA = false;
        private static bool isPressD = false;
        private static void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space && !isDoubleShotActive)
            {
                bullet.Add(new Bullet(new Point(ship.Rect.X + 50, ship.Rect.Y), new Point(30, 0), new Size(22, 22), imgBullet));

                isPressSpace = true;
                ship.StartChat();
            }


            if (e.KeyCode == Keys.Space && isDoubleShotActive)
            {
                bullet.Add(new Bullet(new Point(ship.Rect.X + 50, ship.Rect.Y - 20), new Point(30, 0), new Size(22, 22), imgBullet));
                bullet.Add(new Bullet(new Point(ship.Rect.X + 50, ship.Rect.Y + 20), new Point(30, 0), new Size(22, 22), imgBullet));

                isPressSpace = true;
                ship.StartChat();
            }

            if (e.KeyCode == Keys.W) isPressW = true;
            if (e.KeyCode == Keys.S) isPressS = true;
            if (e.KeyCode == Keys.A) isPressA = true;
            if (e.KeyCode == Keys.D) isPressD = true;
            if (e.KeyCode == Keys.Escape) Cloz();
        }
        private static void Form_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W) isPressW = false;
            if (e.KeyCode == Keys.S) isPressS = false;
            if (e.KeyCode == Keys.A) isPressA = false;
            if (e.KeyCode == Keys.D) isPressD = false;
            if (e.KeyCode == Keys.Space) isPressSpace = false;
        }

        //                                         ТИПА ТУТ ЛОГИ НА СКРИНЕ МОГРАЮТ, НЕ ЗНАЮ КАК СДЕЛАТЬ АЛЯ ЧАТ-ЛОГ ВОВА
        //                                         НО  В ТХТ ФАЙЛ ПИШУТСЯ НОРМАЛЬНО
        //                                         ПИШЕТ ХП И ЩИТ КОРАБЛЯ, АТАКУ, УНИЧТОЖЕНИЕ АСТЕРОЙДА, RОЛИЗИЮ КОРАБЛЯ С ХИЛКАМИ И АСТЕРОЙДАМИ


        public static void ChatStarts()
        {
            using (StreamWriter sw = new StreamWriter($@"C:\Users\Maksim\source\repos\Kapitan_test\Resources\Log.txt", true))
            {
                if (isPressSpace) Log.Add($"Log: {ship.Name} shipEnergy: {ship.Energy} shipShield: {ship.Shield} {ship.Pozition()}  >>>Attacks<<<<");
                sw.WriteLine($"Log: {ship.Name} [shipEnergy: {ship.Energy}] [shipShield: {ship.Shield}] {ship.Pozition()}  >>>Attacks<<<<");
                if (isAsteroidDead) Log.Add($"Log: {ship.Name} shipEnergy: {ship.Energy} shipShield: {ship.Shield} {ship.Pozition()}  >>>Destroyed Asteroid!<<<<");
                sw.WriteLine($"Log: {ship.Name} [shipEnergy: {ship.Energy}] [shipShield: {ship.Shield}] {ship.Pozition()}  >>>Destroyed Asteroid!<<<");
                if (isAsteroidCollised) Log.Add($"Log: {ship.Name} [shipEnergy: {ship.Energy}] [shipShield: {ship.Shield}] {ship.Pozition()}  >>>Collised Asteroid!<<<");
                sw.WriteLine($"Log: {ship.Name} [shipEnergy: {ship.Energy}] [shipShield: {ship.Shield}] {ship.Pozition()}  >>>Collised Asteroid!<<<");
                if (isPowerupsOn) Log.Add($"Log: {ship.Name} shipEnergy: {ship.Energy} shipShield: {ship.Shield} {ship.Pozition()}  >>>PowerUp ON!<<<");
                sw.WriteLine($"Log: {ship.Name} [shipEnergy: {ship.Energy}] [shipShield: {ship.Shield}] {ship.Pozition()}  >>>PowerUp ON!<<<");
            }
        }

        public static void MoneyCount()
        {
            Buffer.Graphics.DrawImage(imgMoney, ship.Rect.X - 10, ship.Rect.Y - 80);
            Buffer.Render();
        }


        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
            if (isPressW) ship.Up();
            if (isPressS) ship.Down();
            if (isPressA) ship.Left();
            if (isPressD) ship.Right();
        }

        private static Image imgLvlup;
        private static Image imgBb;
        private static Image imgStart;
        private static Image imgGameOwer;
        private static Image imgBullet;
        private static List<Image> imgShield;
        private static Image imgMoney;
        private static Image imgBoom;
        private static Image imgShip;
        private static Image imgSun;
        private static Image imgCity;
        private static Image imgStation;
        private static Image imgEarth;
        private static Image imgStar;
        private static Image imgStar1;
        private static Image imgStar2;
        private static Image imgStar3;
        private static Image imgStar4;
        private static Image imgStar5;
        private static Image imgStar6;
        private static Image imgStar7;
        private static Image imgStar8;
        private static Image imgAsteroids;
        private static Image imgPowerUps;

        private static Ship ship;
        private static Sun sun;
        private static Cow cow;
        private static Earth earth;
        private static List<Asteroid> asteroids;
        private static List<PowerUps> powerups;
        private static List<Bullet> bullet;
        private static List<BaseObject> baseStars;

        private static int asteroidsCount = 10;
        private static int powerupsCount = 10;
        public static int Hunted = 0;

        //private static List<Star> stars;
        //private static Bullet bullet;
        private static int starCount = 50;

        public static void Load()
        {
            imgBoom = Properties.Resources.boom;

            imgMoney = Properties.Resources.money;
            
            imgPowerUps = Properties.Resources.UPs12;
            imgLvlup = Properties.Resources.lvlup;
            imgStart = Properties.Resources.start;
            imgBb = Properties.Resources.bb;
            imgBullet = Properties.Resources.FIRE;
            //imgShield = Properties.Resources.shield;
            imgShip = Properties.Resources.s1;
            imgSun = Properties.Resources._6;
            imgCity = Properties.Resources.bck;
            imgEarth = Properties.Resources.ego1;
            imgGameOwer = Properties.Resources.goame_ower;
            imgStation = Properties.Resources.rules1;
            imgStar = Properties.Resources._20;
            imgStar1 = Properties.Resources._22;
            imgStar2 = Properties.Resources._24;
            imgStar3 = Properties.Resources._19;
            imgStar4 = Properties.Resources._28;
            imgStar5 = Properties.Resources._30;
            imgStar6 = Properties.Resources._31;
            imgStar7 = Properties.Resources._32;
            imgStar8 = Properties.Resources._33;
            imgAsteroids = Properties.Resources._1;

            var d = new Random();
            int starSpeed;
            int x;
            int y;
            int l;
            int m;

            //bullet = new Bullet(new Point(0, 500), new Point(5, 0), new Size(15, 5), imgBullet);
            ship = new Ship(new Point(850, 750), new Point(20, 20), new Size(30, 30), imgShip);


            imgShield = new List<Image>();
            for (int i = 1; i < 12; i++)
            {
                Image image = Image.FromFile($@"C:\Users\Maksim\source\repos\Kapitan_test\Resources\sh{i}.png");
                imgShield.Add(image);
            }



            sun = new Sun(new Point(1000, 100), new Point(0, 0), new Size(90, 90), imgSun);
            cow = new Cow(new Point(1230, 691), new Point(0, 0), new Size(10, 10), imgCity);
            earth = new Earth(new Point(600, 200), new Point(1, 0), new Size(170, 170), imgEarth);

            bullet = new List<Bullet>();

            baseStars = new List<BaseObject>();
            for (int i = 0; i < starCount; i++)
            {

                starSpeed = d.Next(1, 3);
                x = d.Next(0, Game.Width);
                y = d.Next(0, Game.Height);
                switch (Rnd.Next(0, 3))
                {
                    case 0: baseStars.Add(new Star(new Point(x, y), new Point(-starSpeed, 0), new Size(30, 30), imgStar)); break;
                    case 1: baseStars.Add(new Star(new Point(x, y), new Point(-starSpeed, 0), new Size(30, 30), imgStar1)); break;
                    case 2: baseStars.Add(new Star(new Point(x, y), new Point(-starSpeed, 0), new Size(30, 30), imgStar2)); break;
                }
            }

            for (var i = 0; i < 200; i++)
            {
                starSpeed = d.Next(0, 0);
                x = d.Next(0, Game.Width);
                y = d.Next(0, Game.Height);
                l = d.Next(0, 2);
                switch (l)
                {
                    case 0: baseStars.Add(new Star(new Point(x, y), new Point(-starSpeed, 0), new Size(3, 3), imgStar3)); break;
                    case 1: baseStars.Add(new Star(new Point(x, y), new Point(-starSpeed, 0), new Size(3, 3), imgStar4)); break;

                }
            }

            for (var i = 0; i < 40; i++)
            {
                starSpeed = d.Next(0, 0);
                x = d.Next(0, Game.Width);
                y = d.Next(0, Game.Height);
                m = d.Next(0, 4);
                switch (m)
                {
                    case 0: baseStars.Add(new Star(new Point(x, y), new Point(-starSpeed, 0), new Size(3, 3), imgStar5)); break;
                    case 1: baseStars.Add(new Star(new Point(x, y), new Point(-starSpeed, 0), new Size(3, 3), imgStar6)); break;
                    case 2: baseStars.Add(new Star(new Point(x, y), new Point(-starSpeed, 0), new Size(3, 3), imgStar7)); break;
                    case 3: baseStars.Add(new Star(new Point(x, y), new Point(-starSpeed, 0), new Size(3, 3), imgStar8)); break;
                }
            }

            asteroids = new List<Asteroid>();
            for (var i = 0; i < asteroidsCount; i++)
            {
                int asteroidsSpeed = d.Next(5, 25);
                x = d.Next(0, Game.Width);
                y = d.Next(0, Game.Height - 400);
                asteroids.Add(new Asteroid(new Point(x, y), new Point(-asteroidsSpeed, 0), new Size(85, 85), imgAsteroids));
            }

            powerups = new List<PowerUps>();
            for (var i = 0; i < powerupsCount; i++)
            {
                int powerupsSpeed = d.Next(5, 10);
                x = d.Next(0, Game.Width);
                y = d.Next(0, Game.Height - 400);
                powerups.Add(new PowerUps(new Point(x, y), new Point(-powerupsSpeed, 0), new Size(60, 60), imgPowerUps));

            }

        }
        public static int imageIndex = 0;
        public static void Draw()
        {
            Buffer.Graphics.Clear(Color.Black);
            //Buffer.Graphics.DrawImage(imgStation, 0, 792);
            Buffer.Graphics.DrawImage(imgStation, 20, 675);
            Buffer.Render();
            Log.PrintToWindow();





            //foreach (Star obj in stars)
            foreach (BaseObject obj in baseStars)

                obj.Draw();
            earth.Draw();
            sun.Draw();
            foreach (PowerUps obj in powerups)
                obj.Draw();
            foreach (Asteroid obj in asteroids)
            {
                if (obj != null)
                {
                    obj?.Draw();
                }
                //if (obj != null && obj.Collision(ship))
                //{
                //    Hunted++;
                //    Buffer.Graphics.DrawImage(imgBb, ship.Rect.X + 15, ship.Rect.Y - 40);
                //}
            }

            cow.Draw();
            //bullet?.Draw();
            foreach (Bullet obj in bullet)
                if (obj != null)
                {
                    obj?.Draw();
                }
            ship?.Draw();


            if (ship.Shield > 0)
            {
                if (imageIndex < 11)
                {
                    Buffer.Graphics.DrawImage(imgShield[imageIndex], ship.Rect.X - 50, ship.Rect.Y - 47);
                    imageIndex++;
                    Buffer.Render();
                }
                if (imageIndex == 11)
                {
                    imageIndex = 0;
                }
                //Buffer.Graphics.DrawImage(imgShield, ship.Rect.X - 50, ship.Rect.Y - 47);
                //Buffer.Render();
            }





            if (ship != null)
            {
                ship.ShipHpToscreen();
                Buffer.Render();
            }
        }





        public static void Update()
        {

            foreach (BaseObject obj in baseStars)

                obj.Update();
            earth.Update();
            sun.Update();
            cow.Update();
            foreach (Bullet obj in bullet)
                obj?.Update();

            for (var i = 0; i < asteroids.Count; i++)
            {
                isAsteroidCollised = false;
                if (asteroids[i] == null) continue;
                asteroids[i]?.Update();

                for (int j = 0; j < bullet.Count; j++)
                {
                    if (bullet[j] == null) continue;
                    isAsteroidDead = false;
                    if (bullet[j] != null && asteroids[i] != null && bullet[j].Collision(asteroids[i]))
                    {
                        System.Media.SystemSounds.Beep.Play();
                        Hunted++;
                        isAsteroidDead = true;
                        ship.StartChat();
                        Buffer.Graphics.DrawImage(imgBoom, asteroids[i].Rect.X, asteroids[i].Rect.Y);
                        Buffer.Render();
                        asteroids[i].Power--;
                        if (asteroids[i].Power == 0)
                        {
                            asteroids[i].Boom();
                            ship.MoneyMaker(); 
                        }
                        bullet[j] = null;

                        continue;
                    }
                }

                if (asteroids[i] == null || !ship.Collision(asteroids[i])) continue;
                var rnd = new Random();
                ship?.EnergyLow(rnd.Next(1, 10));
                isAsteroidCollised = true;
                ship.StartChat();
                asteroids[i]?.Boom();
                System.Media.SystemSounds.Hand.Play();

                if (ship.Energy <= 0) ship?.Die();
            }

            for (var i = 0; i < powerups.Count; i++)
            {
                isPowerupsOn = false;
                if (powerups[i] == null) continue;
                powerups[i].Update();
                if (!ship.Collision(powerups[i])) continue;

                var rnd = new Random();
                isPowerupsOn = true;
                ship.StartChat();
                powerups[i].powerUP();
                ship?.EnergyUp(rnd.Next(1, 5));
                powerups[i].Boom();
                System.Media.SystemSounds.Asterisk.Play();


            }
            ship.Update();
            if (ship.Energy < 110 && ship.Energy > 99) ship?.lvlUp();
            if (ship.Energy < 120 && ship.Energy > 110) ship?.lvlUp();
            if (ship.Energy < 130 && ship.Energy > 120) ship?.lvlUp();
            if (ship.Energy < 140 && ship.Energy > 130) ship?.lvlUp();
        }
    }
}
