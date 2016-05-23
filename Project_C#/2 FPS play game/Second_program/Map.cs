using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Second_program
{
    class Map
    {
        Player player = new Player(150);
        NPC warior = new Warior(350);
        NPC trader = new Trader(50);
        NPC[] NPCS = new NPC[2];

        public char[,] Maps;

        public void GenerateMap()
        {
            Maps = new char[10, 10];
            for (int i = 0; i < 10; i++)
            { 
                for (int j = 0; j < 10; j++)
                {
                    Maps[i, j] = '*';
                }
            }

           

            warior.position(3, 3);
            trader.position(5, 5);
            player.position(4, 4);

            NPCS[0] = warior;
            NPCS[1] = trader;

        }

        public void update()
        {
            player.render();
            player.PlayerUpdate();

            foreach (var n in NPCS)
            {
                n.render();
                n.update_NPC();

                if (player.x == n.x && player.y == n.y)
                {
                    n.Action();
                }
            }

            foreach(var p in NPCS)
            {
                
            }
        }
    }
}
