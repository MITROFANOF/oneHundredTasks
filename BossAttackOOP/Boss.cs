using System;

namespace oneHundredTasks.BossAttackOOP
{
    public class Boss
    {
        private readonly Attack[] _attacks =
        {
            new Attack("Удар ногой", "Босс ударяет ногой в прыжке и выносит тебе еблет", 500, ConsoleColor.Blue),
            new Attack("Удар руками", "Босс атаковал с немыслимой яростью своими руками", 100, ConsoleColor.DarkRed),
            new Attack("Звуковая атака", "Босс исполнил новый альбом Ольги бузовой", 140, ConsoleColor.DarkMagenta),
            new Attack("Психологическая атака",
                "Босс паник и рассказал вам о своём долгом пути и дал пару советов, после выпил ритуальный стопарь боярки",
                80, ConsoleColor.DarkGray)
        };

        private int _attackNumber;
        public Attack CurrentAttack;

        public Boss(bool randomAttacks)
        {
            RandomAttacks = randomAttacks;
        }

        public bool RandomAttacks { get; }

        public void PrepareAttack()
        {
            CurrentAttack = RandomAttacks
                ? _attacks[Game.GetRandomFromZeroTo(_attacks.Length - 1)]
                : _attacks[_attackNumber++ % _attacks.Length];
        }

        public void Attack(Player player)
        {
            player.TakeDamage(CurrentAttack.Damage);
        }
    }
}