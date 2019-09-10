using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kapitan_test
{
    static class Log
    {
        public static List<string> logList = new List<string>();

        public static void Add(string msg)
        {
            logList.Add(msg);
            if (logList.Count > 5) Remove();
        }

        private static void Remove()
        {
            logList.RemoveAt(0);
        }

        public static void PrintToWindow()
        {
            for (int i = 0; i < logList.Count; i++)
                Game.Buffer.Graphics.DrawString(logList[i], SystemFonts.DefaultFont, Brushes.White, 630, 920 + (i * 15));
        }
    }
}
