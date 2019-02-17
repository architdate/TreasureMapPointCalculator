using System;

namespace TMPointCalc
{
    public class CalcCore
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Select Option");
            Console.WriteLine("How many runs I need for X points? [1]");
            Console.WriteLine("How many points I get after X runs? [2]");

            int option = Convert.ToInt32(Console.ReadLine());

            TreasureMap tm = CreateMap();
            
            Team[] teams = CreateTeams(tm.invasion);

            double pointsreached;
            Console.WriteLine("Current points (0 at start): ");
            pointsreached = Convert.ToInt32(Console.ReadLine());
            

            switch (option)
            {
                case 1:
                    Console.WriteLine("Target Points: ");
                    int pointstotal = Convert.ToInt32(Console.ReadLine());
                    int index = 1;

                    while (pointsreached < pointstotal)
                    {
                        pointsreached = pointsreached + tm.pointmultiplier * ((tm.bosspoints * teams[4].booster) + (tm.minibosspoints * teams[0].booster) + (tm.minibosspoints * teams[1].booster) + (tm.minibosspoints * teams[2].booster) + (tm.minibosspoints * teams[3].booster) + (tm.invasionbosspoints * teams[5].booster));
                        tm.Run();
                        index++;
                        Console.WriteLine($"Nav Level: {index} Points: {pointsreached}");
                    }
                    break;
                case 2:
                    Console.WriteLine("Target Runs: ");
                    int runs = Convert.ToInt32(Console.ReadLine());
                    int currrun = 0;

                    while (currrun < runs)
                    {
                        pointsreached = pointsreached + tm.pointmultiplier * ((tm.bosspoints * teams[4].booster) + (tm.minibosspoints * teams[0].booster) + (tm.minibosspoints * teams[1].booster) + (tm.minibosspoints * teams[2].booster) + (tm.minibosspoints * teams[3].booster) + (tm.invasionbosspoints * teams[5].booster));
                        tm.Run();
                        Console.WriteLine($"Nav Level: {currrun + 1} Points: {pointsreached}");
                        currrun++;
                    }
                    Console.WriteLine($"You should have {pointsreached} points");
                    break;
            }
            

            Console.ReadKey();
        }

        private static double[] updatepoints(double[]list, double increment)
        {
            for (int i=0; i<list.Length; i++)
            {
                list[i] += increment;
            }
            return list;
        }

        private static TreasureMap CreateMap()
        {
            bool invasion = getBoolInputValue("Is this TM an invasion (yes/no): ");

            int bosspoints;
            Console.WriteLine("Initial boss points: ");
            bosspoints = Convert.ToInt32(Console.ReadLine());

            int bossincrease;
            Console.WriteLine("Boss point increase: ");
            bossincrease = Convert.ToInt32(Console.ReadLine());

            int minibosspoints;
            Console.WriteLine($"Initial Miniboss points: ");
            minibosspoints = Convert.ToInt32(Console.ReadLine());

            int minibossincrease;
            Console.WriteLine("Miniboss point increase: ");
            minibossincrease = Convert.ToInt32(Console.ReadLine());

            int pointboost = 1;

            if (invasion)
            {
                int invasionbosspoints;
                Console.WriteLine($"Initial Invasion boss points: ");
                invasionbosspoints = Convert.ToInt32(Console.ReadLine());

                int invasionbossincrease;
                Console.WriteLine("Invasion boss point increase: ");
                invasionbossincrease = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Invasion item TM point boost (eg: Croquembouche = 2 for Big Mom TM): ");
                pointboost = Convert.ToInt32(Console.ReadLine());

                return new TreasureMap(bosspoints, minibosspoints, bossincrease, minibossincrease, invasion, pointboost, invasionbosspoints, invasionbossincrease);
            }

            return new TreasureMap(bosspoints, minibosspoints, bossincrease, minibossincrease, invasion, pointboost);
        }

        private static Team[] CreateTeams(bool invasion)
        {
            Team[] teams = new Team[6];
            if (invasion)
            {
                // Invasion is an extra team possible
                Console.WriteLine("Invasion Boss boost: ");
                teams[5] = new Team(Convert.ToDouble(Console.ReadLine()));
            }
            else
            {
                teams[5] = new Team(0); // 0x multiplier on invasion if no invasion exists
            }
            
            Console.WriteLine("TM  boss boost: ");
            teams[4] = new Team(Convert.ToDouble(Console.ReadLine()));

            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine($"TM  miniboss {i+1} boost: ");
                teams[i] = new Team(Convert.ToDouble(Console.ReadLine()));
            }

            return teams;
        }

        private static bool getBoolInputValue(string input)
        {
            bool value;
            bool valid = false;
            do
            {
                Console.WriteLine(input);
                var inputString = Console.ReadLine();
                if (String.IsNullOrEmpty(inputString))
                {
                    continue;
                }
                if (string.Equals(inputString, "yes"))
                {
                    value = true;
                    valid = true;
                    return value;
                }
                else if (string.Equals(inputString, "no"))
                {
                    value = false;
                    valid = true;
                    return value;
                }

            } while (!valid);

            return false;
        }
    }
}
