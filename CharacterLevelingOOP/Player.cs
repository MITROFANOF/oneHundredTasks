using System;
using System.Collections.Generic;
using System.Linq;

namespace oneHundredTasks.CharacterLevelingOOP
{
    public class Player
    {
        public Player(int age, int skillPoints, params Skill[] skills)
        {
            Age = age;
            SkillPoints = skillPoints;
            Skills = skills.ToList().AsReadOnly();
        }

        public IReadOnlyCollection<Skill> Skills { get; }
        public int Age { get; set; }
        public int SkillPoints { get; private set; }

        public void DistributePoints(Skill skill, int points, string operation)
        {
            if (Skills.Contains(skill) == false)
                throw new InvalidOperationException();

            SkillPoints += skill.ChangeValue(points, operation);
        }

        public void ShowStats()
        {
            Console.WriteLine($"Поинтов - {SkillPoints}\nВозраст - {Age}");
            foreach (var skill in Skills)
                BossAttackOOP.Game.PrintMessage($"{skill.Name} - {GetLineForAbility(skill.Value)}", ConsoleColor.Red);
        }

        private static string GetLineForAbility(int value)
        {
            return "".PadLeft(value, '#').PadRight(10, '_');
        }
    }
}