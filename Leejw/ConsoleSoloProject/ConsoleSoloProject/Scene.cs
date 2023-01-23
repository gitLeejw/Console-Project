using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSoloProject
{
    internal class Scene
    {
        public static int X = 45;
        public static int Y = 16;
        public static string Icon = "▶";
        public static bool titleScene = true;
        public static bool gameScene = true;
        public static bool waitScene = true;

        public static ConsoleKey key;

        public static void TitleScene()
        {
            while (titleScene)
            {
                Console.Clear();

                Console.SetCursorPosition(0, 5);
                Console.WriteLine($"  _    _ _____   _____ _____            _____  ______         _____  ______ ______ ______ _   _  _____ ______ \r\n | |  | |  __ \\ / ____|  __ \\     /\\   |  __ \\|  ____|       |  __ \\|  ____|  ____|  ____| \\ | |/ ____|  ____|\r\n | |  | | |__) | |  __| |__) |   /  \\  | |  | | |__          | |  | | |__  | |__  | |__  |  \\| | |    | |__   \r\n | |  | |  ___/| | |_ |  _  /   / /\\ \\ | |  | |  __|         | |  | |  __| |  __| |  __| | . ` | |    |  __|  \r\n | |__| | |    | |__| | | \\ \\  / ____ \\| |__| | |____        | |__| | |____| |    | |____| |\\  | |____| |____ \r\n  \\____/|_|     \\_____|_|  \\_\\/_/    \\_\\_____/|______|       |_____/|______|_|    |______|_| \\_|\\_____|______|\r\n                                                                                                              \r\n                                                                                                             ");

                Console.SetCursorPosition(50, 15);
                Console.WriteLine("게임 시작");
                Console.SetCursorPosition(50, 17);
                Console.WriteLine("게임 종료");

                Console.SetCursorPosition(X, Y);
                Console.WriteLine(Icon);

                TitleSceneMove();

            }
        }

        public static void TitleSceneMove()


        {
            key = Console.ReadKey().Key;

            if (key == ConsoleKey.UpArrow)
            {
                Y = Math.Max(Y - 1, 15);
            }
            if (key == ConsoleKey.DownArrow)
            {
                Y = Math.Min(Y + 1, 17);

            }
            if (key == ConsoleKey.Spacebar && Y == 15)
            {
                waitScene = true;
                titleScene = false;
            }

        }

        public static void TitleReLoad()
        {
            titleScene = true;
            waitScene = true;

            TitleScene();

        }

        public static void EndScene()
        {
            Console.Clear();
            waitScene = false;
            titleScene = true;
                Console.SetCursorPosition(0, 0);
                Console.WriteLine($"   _____                       _      _____                               _ \r\n  / ____|                     | |    / ____|                             | |\r\n | |  __    ___     ___     __| |   | |  __    __ _   _ __ ___     ___   | |\r\n | | |_ |  / _ \\   / _ \\   / _` |   | | |_ |  / _` | | '_ ` _ \\   / _ \\  | |\r\n | |__| | | (_) | | (_) | | (_| |   | |__| | | (_| | | | | | | | |  __/  |_|\r\n  \\_____|  \\___/   \\___/   \\__,_|    \\_____|  \\__,_| |_| |_| |_|  \\___|  (_)\r\n                                                                            \r\n                                                                            ");
                
        }



    }
}
