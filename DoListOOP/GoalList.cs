using System.Collections.Generic;

namespace oneHundredTasks.DoListOOP
{
    public class GoalList
    {
        public GoalList(string name)
        {
            Name = name;
        }

        public List<string> Goals { get; set; }
        public string Name { get; set; }
        public void AddGoal(string goal)
        {
            Goals.Add(goal);
        }
    }
    
    
}