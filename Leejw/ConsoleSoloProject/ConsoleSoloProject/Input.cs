using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSoloProject
{
    internal class Input
    {
       public static ConsoleKey _key;

        public static void InputKey()
        {
                _key = default;
            if (Console.KeyAvailable)
            {
                _key = Console.ReadKey().Key;
            }

        }

        public static bool IsKeyDown(ConsoleKey key)
        {
            if(_key == key )
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
