﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GOC
{
    class FireStaff : IWeapon
    {
        private int _damage;
        private int _fireDamage;

        public int Damage { get => _damage; }
        public int ArmorDamage { get => _fireDamage; }

        public FireStaff(int damage, int fireDamage)
        {
            _damage = damage;
            _fireDamage = fireDamage;
        }

        public void Use(IEnemy enemy)
        {
            enemy.Health -= Damage;
            enemy.OvertimeDamage -= _fireDamage;
        }   
    }
}
