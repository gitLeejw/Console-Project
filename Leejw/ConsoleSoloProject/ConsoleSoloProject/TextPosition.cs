using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSoloProject
{
    internal class TextPosition
    {
        
        public int timeX = 58;
        public int timeY = 2;

        public int monsterNumberX = 58;
        public int monsterHpY = 3;
        public int monsterNumberY = 1;

        public int damageX = 58;
        public int damageY = 4;
        public int damageTextX = 72;
        public int damageTextY = 4;

        public int goldX = 58;
        public int goldY = 5;
        public int goldTextX = 68;
        public int goldTextY = 5;

        public void Position(int X, int Y, string Icon)
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(Icon);
        }

    }
}
