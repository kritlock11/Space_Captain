﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kapitan_test
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Form form = new Form
            {
                Width = Screen.PrimaryScreen.Bounds.Width,
                Height = Screen.PrimaryScreen.Bounds.Height
            };
            Game.Init(form);


            form.Show();
            Game.Load();
            Game.Draw();
            Application.Run(form);
        }
    }
}
