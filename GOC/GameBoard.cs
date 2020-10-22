using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Security;
using System.Text;
using System.Linq;
using Newtonsoft.Json;
using Common;
using System.Threading.Tasks;

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

        public async Task PlayArea(int lvl)
        {
            _player.Cards = (await FetchCards()).ToArray();
            Console.WriteLine("Ready to play?");
            Console.ReadKey();
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
        private static async Task<IEnumerable<Card>> FetchCards()
        {
            using (var http = new HttpClient())
            {
                var cardJson = await http.GetStringAsync("http://localhost:64837/api/cards");
                return JsonConvert.DeserializeObject<IEnumerable<Card>>(cardJson);

            }
        }
    }
}
