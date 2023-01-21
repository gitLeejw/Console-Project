
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Numerics;

namespace ConsoleSoloProject
{
    class Map
    {
        public static string[] LoadStage()
        {
            //1. 경로를 구성한다.
            string stageFilePath = Path.Combine("Assets", "Stage", "MapStage.txt");

            if (false == File.Exists(stageFilePath))
            {
                Console.WriteLine("스테이지없다");
            }

            return File.ReadAllLines(stageFilePath);


        }

        
    }
}


