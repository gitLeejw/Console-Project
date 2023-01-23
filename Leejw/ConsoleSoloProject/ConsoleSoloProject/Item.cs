using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSoloProject
{
    internal class Item
    {
        public static bool itemFriendOnOff = false;
        public static int friendX = 12;
        public static int friendY = 9;
        public static string friendIcon = "=";

        public static int playerWeaponY = 3;
        public static int playerFire = 42;


        public static void Friend(TextPosition text)
        {
            if (itemFriendOnOff)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                text.Position(friendX, friendY, friendIcon);
                Console.ForegroundColor = ConsoleColor.Blue;
                text.Position(text.itemTextX , text.itemTextY, "동료");
            }
        }
}
}
