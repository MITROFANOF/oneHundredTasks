namespace oneHundredTasks.BossAttackOOP
{
    public class Player
    {
        public Player(int health, int armor)
        {
            Health = health;
            Armor = armor;
        }

        public int Health { get; private set; }
        private int Armor { get; }

        public void TakeDamage(int damage)
        {
            Health -= damage - Armor;
        }
    }
}