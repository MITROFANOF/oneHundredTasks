using System;
using System.Threading;

namespace oneHundredTasks.BossAttackOOP
{
    // ReSharper disable once InconsistentNaming

    public static class Game
    {
        private static readonly Player MainPlayer = new Player(1000, 20);


        public static void Play()
        {
            var boss1 = new Boss(GetRandomFromZeroTo(2) == 0);

            PrintMessage("Босс может атаковать в двух режимах: все атаки по очереди и случайной атакой",
                ConsoleColor.Yellow);
            PrintMessage("Босс будет атаковать: " + (boss1.RandomAttacks ? "случайно" : "все атаки по очереди"),
                ConsoleColor.Yellow);
            PrintMessage("Нажмите enter для начала боя", ConsoleColor.Green);
            Console.ReadLine();
            while (MainPlayer.Health > 0)
            {
                Console.Clear();
                PrintMessage("У вас здоровья: " + MainPlayer.Health, ConsoleColor.Red);
                boss1.PrepareAttack();
                PrintMessage($"[{boss1.CurrentAttack.Name}]", ConsoleColor.Yellow);
                PrintMessage(boss1.CurrentAttack.Description, boss1.CurrentAttack.Color);
                boss1.Attack(MainPlayer);
                Thread.Sleep(4000);
            }

            PrintMessage("Бой закончен, вы погибли", ConsoleColor.DarkGray);
        }

        public static int GetRandomFromZeroTo(int number)
        {
            return DateTime.Now.Millisecond % number;
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