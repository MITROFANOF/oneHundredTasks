using System;
using System.Linq;

namespace oneHundredTasks
{
    public static class DoList
    {
        public static void Do()
        {
            string[] goalsIndividual = new string[0],
                goalsWork = new string[0],
                goalsFamilly = new string[0];

            while (true)
            {
                Console.Clear();

                DrawTable(goalsIndividual, goalsWork, goalsFamilly);
                NewGoalDialog(ref goalsIndividual, ref goalsWork, ref goalsFamilly);
            }

            // ReSharper disable once FunctionNeverReturns
        }

        private static void NewGoalDialog(ref string[] goalsIndividual, ref string[] goalsWork,
            ref string[] goalsFamilly)
        {
            Console.WriteLine("Куда вы хотите добавить цель?");
            var listName = Console.ReadLine()?.ToLower(); //то что введёт пользователь переведённое в нижний регистр
            Console.WriteLine("Что это за цель?");
            var goal = Console.ReadLine();

            switch (listName)
            {
                case "личный":
                {
                    AddGoal(ref goalsIndividual, goal);
                    break;
                }
                case "рабочий":
                {
                    AddGoal(ref goalsWork, goal);
                    break;
                }
                case "семейный":
                {
                    AddGoal(ref goalsFamilly, goal);
                    break;
                }
            }
        }

        private static void DrawTable(string[] goalsIndividual, string[] goalsWork, string[] goalsFamilly)
        {
            var max = Max(goalsIndividual, goalsWork, goalsFamilly);

            Console.WriteLine("Личный | Рабочий | Семейный");
            for (var i = 0; i < max; i++)
            {
                Print(goalsIndividual, i);
                Print(goalsWork, i);
                Print(goalsFamilly, i);
                Console.WriteLine();
            }
        }

        private static int Max(params string[][] arrays)
        {
            return arrays.Select(array => array.Length).Prepend(0).Max();
        }

        private static void Print(string[] goals, int i)
        {
            if (goals.Length > i) Console.Write(goals[i] + " | ");
            else Console.Write("Empty | ");
        }

        private static void AddGoal(ref string[] goalsList, string goal)
        {
            var goalsListNew = new string[goalsList.Length + 1];
            for (var j = 0; j < goalsList.Length; j++) goalsListNew[j] = goalsList[j];

            goalsListNew[goalsListNew.Length - 1] = goal;
            goalsList = goalsListNew;
        }
    }
}