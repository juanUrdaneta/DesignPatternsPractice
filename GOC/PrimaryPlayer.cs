using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Security;
using System.Text;

namespace GOC
{
    // sealed to prevent inheritance
    public sealed class PrimaryPlayer
    {
        // regular props
        public string Name { get; set; }
        public int Level { get; set; }
        public int Armor { get; set; }
        public int Health { get; set; }

        public IWeapon Weapon { get; set; }

        // internal instance of the class
        private static readonly PrimaryPlayer _instance;

        // private constructor so it is not accesible outside the class def
        private PrimaryPlayer(){}

        // will be initialized right before the first use of a class
        static PrimaryPlayer()
        {
            _instance = new PrimaryPlayer()
            {
                Name = "Raptor",
                Level = 1,
                Armor = 25,
                Health = 200
            };
        }

        // method to use whenever we want to get the unique instance of the class
        public static PrimaryPlayer Instance
        {
            get
            {
                return _instance;
            }
        }
    }
}
