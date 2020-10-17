using System;
using System.Collections.Generic;
using System.Text;

namespace GOC
{
    public interface IWeapon
    {
        int Damage { get; }
        void Use(IEnemy enemy);
    }
}
