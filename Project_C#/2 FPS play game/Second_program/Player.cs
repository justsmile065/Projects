using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Second_program
{
    class Player : NPC
    {
        public Player(int player_health)
            : base(player_health)
        {
            player_health = Healths;
        }

        public override void position(int x, int y)
        {
            base.position(x, y);

        }


        public override void render()
        {
            base.render();
            Console.SetCursorPosition(x, y);
            Console.Write((char)1);
        }

        public void PlayerUpdate()
        {
            Console.SetCursorPosition(x, y);
        }

        int p_x;
        int p_y;

        public void player_to()
        {
            this.x = p_x;
            this.y = p_y;

            ConsoleKeyInfo k;
            k = Console.ReadKey(true);
            Console.CursorVisible = false;

            if (k.Key == ConsoleKey.UpArrow)
                p_x++;
            else if (k.Key == ConsoleKey.DownArrow)
                p_x--;
            else if (k.Key == ConsoleKey.LeftArrow)
                p_y++;
            else if (k.Key == ConsoleKey.RightArrow)
                p_y--;

            Console.Clear();


        }

    }
}
