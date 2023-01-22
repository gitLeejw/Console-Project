using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSoloProject
{
    internal class Upgrade
    {
        public int X;
        public int Y;
        public int Gold = 0;
        public int Damage = 5; 

        public void GoldPosition(int X, int Y)
        {
            Console.SetCursorPosition(X, Y);
            Console.Write($"골드 : {Gold}");
        }

        public void DamagePosition(int X, int Y)
        {
            Console.SetCursorPosition(X, Y);
            Console.Write($"공격력 : {Damage}");
        }
        public void GoldError(int X, int Y)
        {
            Console.SetCursorPosition(X, Y);
            Console.Write("골드가 부족합니다");
        }
        public void DamageText(int X, int Y)
        {
            Console.SetCursorPosition(X, Y);
            Console.WriteLine("업그레이드 성공" );
        }
    }
}
