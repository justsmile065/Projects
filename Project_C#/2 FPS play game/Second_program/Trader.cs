using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Second_program
{
    class Trader : NPC
    {

        public Trader(int trader_hp)
            : base(trader_hp)
        {
            trader_hp = Healths;
        }



        public override void position(int x, int y)
        {
            base.position(x, y);
        }



        public override void render()
        {
            base.render();
            Console.Write((char)5);
        }

        public string act;
        string[] items = { "Валенок", "Кувшин", "Чашка" };

        public override void Action()
        {
            int x = 25;
            int y = 0;

            Console.SetCursorPosition(x, y);
            Console.WriteLine("Выбирай товары: {0}, {1}, {2}", items[0], items[1], items[2]);
            Console.SetCursorPosition(x, ++y);
            Console.WriteLine("1 - Купить {0}, 2 - {1}, 3 - {2} 4 - Выход", items[0], items[1], items[2]);
            Console.SetCursorPosition(x, y + 2);

            act = Console.ReadLine();
            switch (act)
            {
                case "1":
                    Console.SetCursorPosition(x, y + 2);
                    Console.WriteLine("Вы купили Валенок");
                    break;
                case "2":
                    Console.SetCursorPosition(x, y + 2);
                    Console.WriteLine("Вы купили Кувшин");
                    break;
                case "3":
                    Console.SetCursorPosition(x, y + 2);
                    Console.WriteLine("Вы купили Чашку");
                    break;
                case "4":
                    break;
            }

        }
    }
}

