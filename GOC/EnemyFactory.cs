using System;
using System.Collections.Generic;
using System.Net.Security;
using System.Runtime.InteropServices;
using System.Text;

namespace GOC
{
    public class EnemyFactory
    {
        private int _areaLevel;
        public int AreaLevel { get => _areaLevel; }

        private Stack<Giant> _giantsPool = new Stack<Giant>();
        private Stack<Zombie> _zombiesPool = new Stack<Zombie>();
        private Stack<Werewolf> _werewolfsPool = new Stack<Werewolf>();

        public EnemyFactory(int areaLevel)
        {
            _areaLevel = areaLevel;
            PreLoadGiants();
            PreLoadWerewolfs();
            PreLoadZombies();
        }

        private void PreLoadWerewolfs()
        {
            int count;
            int health;
            int armor;
            int level;

            (health, level, armor) = GetWerewolfStatus(_areaLevel);

            if (_areaLevel < 3) { count = 5; } 
            else if (_areaLevel >= 3 && _areaLevel < 10) { count = 10; }
            else { count = 20; }

            for (int i = 0; i < count; i++)
            {
                _werewolfsPool.Push(new Werewolf(health, level, armor));
            }
        }

        private void PreLoadGiants()
        {
            int count;
            int health;
            int armor;
            int level;

            (health, level, armor) = GetGiantStatus(_areaLevel);

            if (_areaLevel < 3) { count = 5; }
            else if (_areaLevel >= 3 && _areaLevel < 10) { count = 10; }
            else { count = 20; }

            for (int i = 0; i < count; i++)
            {
                _giantsPool.Push(new Giant(health, level, armor));
            }
        }

        private void PreLoadZombies()
        {
            int count;
            int health;
            int armor;
            int level;

            (health, level, armor) = GetZombieStatus(_areaLevel);

            if (_areaLevel < 3) {count = 5;}
            else if (_areaLevel >= 3 && _areaLevel < 10){count = 10;}
            else {count = 20;}

            for (int i = 0; i < count; i++)
            {
                _zombiesPool.Push(new Zombie(health, level, armor));
            }
        }

        public void ReclaimZombie(Zombie zombie)
        {
            (int health, int level, int armor) = GetZombieStatus(_areaLevel);
            zombie.Health = health;
            zombie.Armor = armor;
            _zombiesPool.Push(zombie);
        }

        public void ReclaimGiant(Giant giant)
        {
            (int health, int level, int armor) = GetGiantStatus(_areaLevel);
            giant.Health = health;
            giant.Armor = armor;
            _giantsPool.Push(giant);
        }

        public void ReclaimWerewolf(Werewolf werewolf)
        {
            (int health, int level, int armor) = GetWerewolfStatus(_areaLevel);
            werewolf.Health = health;
            werewolf.Armor = armor;
            _werewolfsPool.Push(werewolf);
        }

        private (int health, int level, int armor) GetZombieStatus(int areaLvl) 
        {
            int health, armor, level;
            if (areaLvl < 3)
            {
                health = 150;
                level = 2;
                armor = 10;
            }
            else if (areaLvl >= 3 && areaLvl < 10)
            {
                health = 300;
                level = 7;
                armor = 20;
            }
            else
            {
                health = 600;
                level = 11;
                armor = 35;
            }

            return (health, level, armor);
        }

        private (int health, int level, int armor) GetGiantStatus(int areaLvl)
        {
            int health, level, armor;

            if (areaLvl < 3)
            {
                health = 150;
                level = 2;
                armor = 10;
            }
            else if (areaLvl >= 3 && areaLvl < 10)
            {
                health = 300;
                level = 7;
                armor = 20;
            }
            else
            {
                health = 600;
                level = 11;
                armor = 35;
            }

            return (health, level, armor);
        }

        private (int health, int level, int armor) GetWerewolfStatus(int areaLvl)
        {

            int health, level, armor;

            if (areaLvl < 3)
            {
                health = 66;
                level = 2;
                armor = 15;
            }
            else if (areaLvl >= 3 && areaLvl < 10)
            {
                health = 116;
                level = 7;
                armor = 35;
            }
            else
            {
                health = 206;
                level = 11;
                armor = 55;
            }

            return (health, level, armor);

        }

        // with each method different types of enemies can be generated
        public Werewolf SpawnWerewolf()
        {
            if (_werewolfsPool.Count > 0)
            {
                return _werewolfsPool.Pop();
            }
            else
            {
                throw new Exception("Zombie pool depleted");
            }
        }
        public Giant SpawnGiant()
        {
            if (_giantsPool.Count > 0)
            {
                return _giantsPool.Pop();
            }
            else
            {
                throw new Exception("Zombie pool depleted");
            }
        }
        public Zombie SpawnZombie()
        {
            if(_zombiesPool.Count > 0)
            {
                return _zombiesPool.Pop();
            }
            else
            {
                throw new Exception("Zombie pool depleted");
            }
        }
    }
}
