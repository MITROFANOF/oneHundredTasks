using System;
using System.Threading;

namespace oneHundredTasks
{
    public static class BossAttack
    {
        private static int _health = 1000;
        private const int Armor = 20;

        public static void Do()
        {

            var isRandomAttack = GetRandomFromZeroTo(2) == 0;

            PrintMessage("Босс может атаковать в двух режимах: все атаки по очереди и случайной атакой", ConsoleColor.Yellow);
            PrintMessage("Босс будет атаковать: " + (isRandomAttack ? "случайно" : "все атаки по очереди"), ConsoleColor.Yellow);
            PrintMessage("Нажмите enter для начала боя", ConsoleColor.Green);
            Console.ReadLine();

            var attackNumber = 0;
            
            while (_health > 0)
            {
                Console.Clear();
                PrintMessage("У вас здоровья: " + _health, ConsoleColor.Red);

                if (isRandomAttack)
                {
                    Attack(GetRandomFromZeroTo(3));
                }
                else
                {
                    Attack(attackNumber%3);

                    attackNumber++;
                }

                Thread.Sleep(4000);
            }
            PrintMessage("Бой закончен, вы погибли", ConsoleColor.DarkGray);

        }

        private static int GetRandomFromZeroTo(int number)
        {
            return DateTime.Now.Millisecond % number;
        }

        private static void Attack(int attackNumber)
        {
            switch (attackNumber)
            {
                case 0:
                    PrintMessage("Босс атаковал с немыслимой яростью своими руками", ConsoleColor.DarkRed);
                    TakeDamage(100);
                    break;
                case 1:
                    PrintMessage("Босс исполнил новый альбом Ольги бузовой", ConsoleColor.DarkMagenta);
                    TakeDamage(140);
                    break;
                case 2:
                    PrintMessage(
                        "Босс паник и рассказал вам о своём долгом пути и дал пару советов, после выпил ритуальный стопарь боярки",
                        ConsoleColor.DarkGray);
                    TakeDamage(80);
                    break;
            }
        }

        private static void TakeDamage(int damage)
        {
            _health -= (damage - Armor);
        }

        private static void PrintMessage(string text, ConsoleColor color)
        {
            var oldColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ForegroundColor = oldColor;
        }
    }
}