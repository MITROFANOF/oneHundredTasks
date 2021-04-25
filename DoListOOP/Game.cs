using System;
using System.Collections.Generic;
using System.Linq;

namespace oneHundredTasks.DoListOOP
{
    // ReSharper disable once InconsistentNaming
    public static class Game
    {
        public static void Play()
        {
            var goalsLists = new List<GoalList>
            {
                new GoalList("Личный"), 
                new GoalList("Рабочий"), 
                new GoalList("Семейный")
            };


            while (true)
            {
                Console.Clear();

                DrawTable(goalsLists);
                NewGoalDialog(goalsLists);
            }

            // ReSharper disable once FunctionNeverReturns
        }

        private static void NewGoalDialog(IEnumerable<GoalList> lists)
        {
            Console.WriteLine("Куда вы хотите добавить цель?");
            var listName = Console.ReadLine()?.ToLower(); //то что введёт пользователь переведённое в нижний регистр
            Console.WriteLine("Что это за цель?");
            var goal = Console.ReadLine();

            foreach (var list in lists)
                if (string.Equals(list.Name, listName, StringComparison.CurrentCultureIgnoreCase))
                    list.AddGoal(goal);
        }

        private static void DrawTable(IReadOnlyCollection<GoalList> lists)
        {
            foreach (var list in lists) Console.Write(list.Name + " | ");
            Console.WriteLine();

            var max = Max(lists);

            for (var i = 0; i < max; i++)
            {
                Print(lists, i);
                Console.WriteLine();
            }
        }

        private static int Max(IEnumerable<GoalList> lists)
        {
            return lists.Select(list => list.Goals.Count).Prepend(0).Max();
        }

        private static void Print(IEnumerable<GoalList> lists, int goal)
        {
            foreach (var list in lists)
            {
                if (list.Goals.Count > goal) Console.Write(list.Goals[goal] + " | ");
                else Console.Write("Empty | ");    
            }
            
        }
    }
}