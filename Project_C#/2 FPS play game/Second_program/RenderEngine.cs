using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Second_program
{
    class RenderEngine
    { 
        public void Render(Map map)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Console.SetCursorPosition(i, j);
                    Console.Write(map.Maps[i, j] + "");  
                }
                Console.WriteLine();
            }
        }
    }
}