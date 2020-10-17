using System;
using System.Collections.Generic;
using System.Text;

namespace GOC
{
    public class Werewolf : IEnemy
    {
        private int _health;
        private int _level;

        public int Health { get => _health; set => _health = value; }

        public int Level => _level;

        public int OvertimeDamage { get; set; }
        public int Armor { get; set; }
        public bool Paralyzed { get; set; }
        public int ParalyzedFor { get; set; }

        public Werewolf(int health, int level, int armor)
        {
            _health = health;
            _level = level;
            Armor = level;
        }

        public void Attack(PrimaryPlayer player)
        {
            Console.WriteLine("Werewolf attacking: " + player.Name);
        }

        public void Defend(PrimaryPlayer player)
        {
            Console.WriteLine("Werewolf defending from: " + player.Name);
        }
    }
}
