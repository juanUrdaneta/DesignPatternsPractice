using System;
using System.Collections.Generic;
using System.Text;

namespace GOC
{
    class IceStaff : IWeapon
    {
        private int _damage;
        private int _paralizedTime;

        public int Damage { get => _damage; }
        public int ArmorDamage { get => _paralizedTime; }

        public IceStaff(int damage, int paralizedTime)
        {
            _damage = damage;
            _paralizedTime = paralizedTime;
        }

        public void Use(IEnemy enemy)
        {
            enemy.Health -= Damage;
            enemy.Paralyzed = true;
            enemy.ParalyzedFor = _paralizedTime;
        }
    }
}
