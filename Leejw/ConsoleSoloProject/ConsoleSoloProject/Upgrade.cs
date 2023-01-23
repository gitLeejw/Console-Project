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
        public static int X;
        public static int Y;
        public static int Gold = 0;
        public static int Damage = 5;
        public static int Hp = 5;

        public static string goldErrorText = "골드가 부족합니다.";
        public static string damageUpgradeText = "업그레이드 성공.";

        public void goldUpgrade(TextPosition text)
        {
                if (Gold >= 10)
                {
                    Gold -= 10;
                    Damage++;

                    text.Position(text.damageTextX, text.damageTextY, damageUpgradeText);

                }
                else
                {
                    text.Position(text.goldTextX, text.goldTextY, goldErrorText);
                }
            
               
        }
    }
}

