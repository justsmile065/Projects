using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Second_program
{
    class NPC
    {
        public int Healths;
        public int x, y;
        Random r;
        

        public NPC(int HP)
        {
            Healths = HP;
            r = new Random();
        }

        public int TakeDamage(int damage)
        {
            Healths -= damage;
            return Healths;
        }

        public virtual void Action()
        {

        }

        public virtual void position(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public virtual void render()
        {
            Console.CursorVisible = false;
            Console.SetCursorPosition(x, y);
        }

        public void update_NPC()
        {
            int v = r.Next(0, 100);
            switch (v)
            {
                case 10:
                    this.x += 1;
                    break;
                case 25:
                    this.x -= 1;
                    break;
                case 55:
                    this.y += 1;
                    break;
                case 70:
                    this.y -= 1;
                    break;
            }
        }

    }
}


