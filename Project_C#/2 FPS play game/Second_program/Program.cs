using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Second_program
{
    class Program
    {


        static void Main(string[] args)
        {
            Game game = new Game();
            Player pl = new Player(150);

            game.loop();

            
        }
    }
}
