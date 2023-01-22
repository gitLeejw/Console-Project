using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSoloProject
{
    internal class Scene
    {
        public int X = 45;
        public int Y = 16;
        public string Icon = "▶";
        public bool mainScene = true;
        
        

        public void TitleScene(ConsoleKey key)
        {
            while (mainScene)
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
                key = Console.ReadKey().Key;



                if (key == ConsoleKey.UpArrow)
                {
                    Y = Math.Max(Y - 1, 15);
                }
                if (key == ConsoleKey.DownArrow)
                {
                    Y = Math.Min(Y + 1, 17);

                }
                if (key == ConsoleKey.RightArrow && Y == 15)
                {
                    mainScene = false;
                }
            }
        }
    }
}
