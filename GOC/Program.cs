using System;
using System.Collections.Generic;
using System.Net.Cache;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace GOC
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                TestAPIConnection().Wait();
                GameBoard board = new GameBoard();
                board.PlayArea(PrimaryPlayer.Instance.Level);
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to initialized");
            }
        }
        private static async Task TestAPIConnection()
        {
            int maxAttemps = 20;
            int attempInterval = 2000;

            using (var http = new HttpClient())
            {
                for(int i=0; i<maxAttemps; i++)
                {
                    try
                    {
                        var response = await http.GetAsync("http://localhost:64837/api/cards");
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            return;
                        }
                    }
                    catch(Exception e)
                    {

                    }
                    finally
                    {
                        Console.WriteLine("Lost Connection to the server, Attempting to re-conenct");
                        Thread.Sleep(attempInterval);
                    }
                }

                throw new Exception("Failed to connect to the server");
            }
        }

        
    }
}
