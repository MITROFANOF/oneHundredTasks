using System;

namespace oneHundredTasks
{
    public static class Task2
    {
        public static void Do()
        {
            var numbers = new int[3];
            numbers[0] = 1;
            numbers[1] = 15;
            numbers[2] = 2;
            foreach (var variable in numbers) Console.Out.WriteLine(variable);
        }
    }
}