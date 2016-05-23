using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Second_program
{
    class Warior : NPC
    {


        public Warior(int War_hp)
            : base(War_hp)
        {
            War_hp = Healths;
        }


        public override void position(int x, int y)
        {
            base.position(x, y);
        }


        public override void render()
        {
            base.render();
            Console.Write((char)4);
        }


        Player pl = new Player(150);
        string ask;
        public string[] asked = { "Как дела ?", "Ты жалок!", "Выход" };

        public override void Action()
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine("Чего тебе ? ");
            Console.SetCursorPosition(x, ++y);
            Console.WriteLine("1 - {0}, 2 - {1}, 3 - {2}", asked[0], asked[1], asked[2]);
            Console.SetCursorPosition(x, y + 2);

            ask = Console.ReadLine();
            switch (ask)
            {
                case "1":
                    Console.SetCursorPosition(x, y + 2);
                    Console.WriteLine("Проваливай");
                    break;
                case "2":
                    Console.SetCursorPosition(x, y + 2);
                    Console.WriteLine("Вы получиили урон, здоровье равно {0}", pl.TakeDamage(90));
                    if (pl.Healths <= 0)
                    {
                        Console.SetCursorPosition(x, y + 3);
                        Console.WriteLine("Вы мертвы");
                        Console.Read();
                        Environment.Exit(0);
                    }
                    break;
                case "3":
                    break;
            }

        }
    }
}

