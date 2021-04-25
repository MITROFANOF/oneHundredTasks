using System;

namespace oneHundredTasks.CharacterLevelingOOP
{
    public static class Game
    {
        public static void Play()
        {
            var player = new Player(0, 25, new Skill("Сила"), new Skill("Ловкость"), new Skill("Интеллект"));

            Console.WriteLine("Добро пожаловать в меню выбора создания персонажа!");
            Console.WriteLine("У вас есть 25 очков, которые вы можете распределить по умениям");
            Console.WriteLine("Нажмите любую клавишу чтобы продолжить...");
            Console.ReadKey();

            while (player.SkillPoints > 0)
            {
                Console.Clear();
                player.ShowStats();

                Console.WriteLine("Какую характеристику вы хотите изменить?");
                var subject = Console.ReadLine();

                Console.WriteLine(@"Что вы хотите сделать? +\-");
                var operation = Console.ReadLine();

                Console.WriteLine(@"Колличество поинтов которые следует {0}",
                    operation == "+" ? "прибавить" : "отнять");
                var operandPoints = ParseInt();

                foreach (var skill in player.Skills)
                    if (subject?.ToLower() == skill.Name?.ToLower())
                        player.DistributePoints(skill, operandPoints, operation);
            }

            Console.WriteLine("Вы распределили все очки. Введите возраст персонажа:");
            player.Age = ParseInt();

            Console.Clear();
            player.ShowStats();
        }

        private static int ParseInt()
        {
            int parsedInt;
            string operandPointsRaw;
            do
            {
                operandPointsRaw = Console.ReadLine();
            } while (!int.TryParse(operandPointsRaw, out parsedInt));

            return parsedInt;
        }
    }
}