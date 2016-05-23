using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Second_program
{
    class Game
    {
        RenderEngine RenderObj = new RenderEngine();
        Map map = new Map();

        public void loop()
        {
            const int FPS = 10;
            const int skip_tick = 1000 / FPS;
            int NextGameTick = Environment.TickCount;
            int SleepTime = 0;
            bool GameRunning = true;

            map.GenerateMap();
            

            while (GameRunning)
            {      
                RenderObj.Render(map);
                map.update();

                NextGameTick += skip_tick;
                SleepTime = NextGameTick - Environment.TickCount;

                if (SleepTime >= 0)
                {
                    Thread.Sleep(SleepTime);
                }
              
            }

        }
 
    }
}
