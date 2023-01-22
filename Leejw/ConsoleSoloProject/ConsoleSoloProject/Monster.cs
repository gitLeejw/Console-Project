using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ConsoleSoloProject
{
    internal class Monster
    {
        public int X;
        public int Y;
        public int Hp;
        public int Count = 0;
        public int Unit = 15;
        public string Icon = "o";

        public void MonsterNumber(int x, int y, int num)
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine($"몬스터 : {num}");
        }

        public void MonsterMove()
        {
            if (X == 13 && Y <= 9 && Y != 3)
            {
                Console.SetCursorPosition(X, Y--);
                Console.Write(Icon);
            }
            else if ( Y == 9 && X <= 42)
            {
                Console.SetCursorPosition(X--, Y);
                Console.Write(Icon);
            }
            else if (X == 42)
            {
                Console.SetCursorPosition(X, Y++);
                Console.Write(Icon);

            }
            else if (X <= 42 && Y == 3)
            {
                Console.SetCursorPosition(X++, Y);
                Console.Write(Icon);
                
            }  

        }
    }

}
