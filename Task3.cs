using System;
using System.Linq;

namespace oneHundredTasks
{
    public static class Task3
    {
        public static void Do()
        {
            var numbers = new int[3];
            numbers[0] = 1;
            numbers[1] = 15;
            numbers[2] = 2;
            var sum = numbers.Sum();
            Console.Out.Write(sum);
        }
    }
}