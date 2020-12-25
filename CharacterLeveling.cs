using System;

namespace oneHundredTasks
{
    public static class CharacterLeveling
    {
        
        public static void Do()
        {
            int age = 0, strength = 0, agility = 0, intelligence = 0, points = 25;
            Console.WriteLine("Добро пожаловать в меню выбора создания персонажа!");
            Console.WriteLine("У вас есть 25 очков, которые вы можете распределить по умениям");
            Console.WriteLine("Нажмите любую клавишу чтобы продолжить...");
            Console.ReadKey();

            while (points > 0)
            {
                Console.Clear();
                ShowStats(points, age, strength, agility, intelligence);

                Console.WriteLine("Какую характеристику вы хотите изменить?");
                var subject = Console.ReadLine();

                Console.WriteLine(@"Что вы хотите сделать? +\-");
                var operation = Console.ReadLine();

                Console.WriteLine(@"Колличество поинтов которые следует {0}", operation == "+" ? "прибавить" : "отнять");
                var operandPoints = ParseInt();

                switch (subject?.ToLower())
                {
                    case "сила":
                        ChangeStat(operandPoints, ref strength, ref points, operation);
                        break;
                    case "ловкость":
                        ChangeStat(operandPoints, ref agility, ref points, operation);
                        break;
                    case "интелект":
                        ChangeStat(operandPoints, ref intelligence, ref points, operation);
                        break;
                }
            }

            Console.WriteLine("Вы распределили все очки. Введите возраст персонажа:");
            age = ParseInt();
            
            Console.Clear();
            ShowStats(points, age, strength, agility, intelligence);

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
        
        private static void ShowStats(int points, int age, int strength, int agility, int intelligence)
        {
            Console.WriteLine("Поинтов - {0}\nВозраст - {1}\nСила - [{2}]\nЛовкость - [{3}]\nИнтелект - [{4}]",points, age, GetLineForAbility(strength), GetLineForAbility(agility), GetLineForAbility(intelligence));
        }
        
        private static string GetLineForAbility(int value)
        {
            return "".PadLeft(value, '#').PadRight(10, '_');
        }
        
        private static int ApplyChangesToAbility(ref int ability, int delta)
        {
            int oldAbility = ability;
            ability = Clamp(ability + delta, 0, 10);
            return oldAbility - ability;
        }

        private static int Clamp(int value, int min, int max)
        {
            if (value > max)
                return max;
            if (value < min)
                return min;

            return value;
        }
        
        private static void ChangeStat(int operandPoints, ref int stat, ref int points, string operation)
        {
            points += ApplyChangesToAbility(ref stat, operandPoints * (operation == "+" ? 1 : -1));
        }
    }
}