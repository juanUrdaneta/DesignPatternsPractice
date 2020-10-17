using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Net.Security;
using System.Text;

namespace GOC
{
    // Gameboard shouldn't know how to instantiate any of the 
    // enemies or players or what enemies to create.
    // will know details player level and area level
    class GameBoard
    {
        private PrimaryPlayer _player;

        public GameBoard()
        {
            _player = PrimaryPlayer.Instance;
            _player.Weapon = new Sword(10, 4);
        }

        public void PlayArea(int lvl)
        {
            if(lvl == 1)
            {
                PlayFirstLevel();
            }
        }

        private void PlayFirstLevel()
        {
            const int currentLvl = 1;
            EnemyFactory enemyFactory = new EnemyFactory(currentLvl);
            List<IEnemy> enemies = new List<IEnemy>();
            for(int i = 0; i<3; i++)
            {
                enemies.Add(enemyFactory.SpawnZombie());
            }
            for (int i=0; i<3; i++)
            {
                enemies.Add(enemyFactory.SpawnGiant());
            }
            foreach(var enemy in enemies)
            {
                Console.WriteLine(enemy.GetType());
            }

        }
    }
}
