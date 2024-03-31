using System;

namespace delegatesAndEvents
{
    public delegate void RaceEventHandler(int winner);

    public class Race
    {

        public event RaceEventHandler RaceEvent;

        public void Racing(int contestants, int laps)
        {
            Console.WriteLine("Ready\nSet\nGo!");
            Random r = new Random();
            int[] participants = new int[contestants];
            bool done = false;
            int champ = -1;

            while (!done)
            {
                for (int i = 0; i < contestants; i++)
                {
                    if (participants[i] <= laps)
                    {
                        participants[i] += r.Next(1, 5);
                    }
                    else
                    {
                        champ = i;
                        done = true;
                        continue;
                    }
                }
            }
            RaceEvent?.Invoke(champ);
        }
    }

    class Program
    {
        public static void Main()
        {

            Race round1 = new Race();

            round1.RaceEvent += footRace;

            round1.Racing(5, 10); 

            round1.RaceEvent += carRace;

            round1.Racing(3, 15);

            round1.RaceEvent += (winner) => { Console.WriteLine($"Biker number {winner} is the winner."); };

            round1.Racing(4, 20); 
        }

        public static void carRace(int winner)
        {
            Console.WriteLine($"Car number {winner} is the winner.");
        }
        public static void footRace(int winner)
        {
            Console.WriteLine($"Racer number {winner} is the winner.");
        }
    }
}

