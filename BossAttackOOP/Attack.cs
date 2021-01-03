using System;

namespace oneHundredTasks.BossAttackOOP
{
    public class Attack
    {
        public Attack(string name, string description, int damage, ConsoleColor color)
        {
            Name = name;
            Damage = damage;
            Color = color;
            Description = description;
        }

        public string Name { get; }
        public string Description { get; }
        public int Damage { get; }
        public ConsoleColor Color { get; }
    }
}