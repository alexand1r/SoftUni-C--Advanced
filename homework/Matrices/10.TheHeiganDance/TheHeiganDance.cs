using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.TheHeiganDance
{
    class TheHeiganDance
    {
        private static int MIN_LIMIT = 0;
        private static int MAX_LIMIT = 14;
        private static int CLOUD_DAMAGE = 3500;
        private static int ERUPTION_DAMAGE = 6000;
        private static Dictionary<string, int> damagePositions;

        static void Main(string[] args)
        {
            double heigan = 3000000d;
            bool isHeiganDefeated = false;
            int player = 18500;
            bool isPlayerDefeated = false;
            bool hasCloud = false;
            string causeOfDeath = string.Empty;

            int[] playerPosition = {7, 7};

            double averageDamage = double.Parse(Console.ReadLine());
            while (true)
            {
                string[] attackArgs = Console.ReadLine().Split(' ');
                int row = int.Parse(attackArgs[1]);
                int col = int.Parse(attackArgs[2]);

                heigan -= averageDamage;
                isHeiganDefeated = heigan <= 0;

                if (hasCloud)
                {
                    player -= CLOUD_DAMAGE;
                    hasCloud = false;
                    causeOfDeath = "Plague Cloud";
                    isPlayerDefeated = player <= 0;
                }

                if (isHeiganDefeated || isPlayerDefeated)
                {
                    break;
                }

                getDamageArea(row, col);
                if (isPlayerInDamageZone(playerPosition))
                {
                    if (playerPosition[0] > MIN_LIMIT && playerPosition[0] == damagePositions["minRow"])
                        playerPosition[0]--;
                    else if (playerPosition[0] < MAX_LIMIT && playerPosition[0] == damagePositions["maxRow"])
                        playerPosition[0]++;
                    else if (playerPosition[1] > MIN_LIMIT && playerPosition[1] == damagePositions["minCol"])
                        playerPosition[1]--;
                    else if (playerPosition[1] < MAX_LIMIT && playerPosition[1] == damagePositions["maxCol"])
                        playerPosition[1]++;
                }

                if (isPlayerInDamageZone(playerPosition))
                {
                    if (attackArgs[0].Equals("Cloud"))
                    {
                        player -= CLOUD_DAMAGE;
                        hasCloud = true;
                        causeOfDeath = "Plague Cloud";
                    }
                    else
                    {
                        player -= ERUPTION_DAMAGE;
                        causeOfDeath = "Eruption";
                    }
                }

                isPlayerDefeated = player <= 0;

                if (isPlayerDefeated) break;
            }

            if (isHeiganDefeated)
                Console.WriteLine("Heigan: Defeated!");
            else
                Console.WriteLine("Heigan: {0:F2}", heigan);

            if (isPlayerDefeated)
                Console.WriteLine("Player: Killed by {0}", causeOfDeath);
            else
                Console.WriteLine("Player: {0}", player);

            Console.WriteLine("Final position: {0}, {1}", playerPosition[0], playerPosition[1]);
        }

        private static void getDamageArea(int row, int col)
        {
            damagePositions = new Dictionary<string, int>();
            damagePositions.Add("minRow", row - 1);
            damagePositions.Add("maxRow", row + 1);
            damagePositions.Add("minCol", col - 1);
            damagePositions.Add("maxCol", col + 1);
        }

        private static bool isPlayerInDamageZone(int[] playerPosition)
        {
            bool isInHitRow = playerPosition[0] >= damagePositions["minRow"] && playerPosition[0] <= damagePositions["maxRow"];
            bool isInHitCol = playerPosition[1] >= damagePositions["minCol"] && playerPosition[1] <= damagePositions["maxCol"];

            return isInHitRow && isInHitCol;
        }
    }
}

//10000
//Cloud 7 7
//Eruption 6 7
//Eruption 8 7
//Eruption 8 7
