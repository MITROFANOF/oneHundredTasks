using System;
using System.Linq;

namespace oneHundredTasks
{
    public static class Task4
    {
        public static void Do()
        {
            var numbers = new int[3];
            numbers[0] = 1;
            numbers[1] = 15;
            numbers[2] = 2;
            var max = numbers.Max();
            Console.Out.Write(max);
        }
    }
}