using System;

//hello, I did this project in a space-theme again just like our first assignment
//to make it better i also added character dialogues depending on your answers
//if you remember my "writing and storytelling for games" final project, the characters are from there: sylas vortex and aria nova
//i did took some help from chatgpt honestly because instead of just making basic questions i made it more like a short twine game

namespace SpaceGame
{
    class Program
    {
        static void Main(string[] args)
        {
            //declaring first variables
            string playerName;
            double fuel = 75.0;
            Random rng = new Random();

            //starting and introduction
            Console.WriteLine("Welcome to the space exploration adventure!");
            Console.Write("Enter your name: ");
            playerName = Console.ReadLine();
            Console.WriteLine($"\nCommander {playerName}, your mission is to explore galaxies and return to base safely. Fuel management is critical!");
            Console.WriteLine("Your companions: Sylas, an emotionless alien in a black cape and mask, and Aria, a young adventurer girl. Your Fuel: 75");

            //method to take valid inputs
            int GetValidInput()
            {
                int choice;
                while (true)
                {
                    string input = Console.ReadLine();
                    if (int.TryParse(input, out choice) && (choice == 1 || choice == 2))
                    {
                        return choice;
                    }
                    Console.WriteLine("Invalid input! Please enter 1 or 2.");
                }
            }

            //function to check fuel and in case it is 0 or below then the player gets bad ending
            void CheckFuel()
            {
                if (fuel <= 0)
                {
                    Console.WriteLine("\nYou have run out of fuel! Your ship drifts in the cold of space. With no hope, your crew gets lost(maybe even dies) in the dark space along with you.");
                    Console.WriteLine("BAD ENDING: Lost in dark space");
                    Environment.Exit(0);
                }
            }

            //first choice
            Console.WriteLine("\nYour ship is ready to launch. Where will you go?");
            Console.WriteLine("1. Nebula Sector 7 (50 fuel)");
            Console.WriteLine("2. Tranquil System (30 fuel)");
            Console.Write("Enter your choice (1 or 2): ");
            int firstChoice = GetValidInput();

            if (firstChoice == 1)
            {
                fuel -= 50;
                Console.WriteLine("\nYou went to Nebula Sector 7. It’s a long journey.");
            }
            else
            {
                fuel -= 30;
                Console.WriteLine("\nYou went to Tranquil System. A calm and slow journey.");
            }

            Console.WriteLine($"Remaining fuel: {fuel} units");
            CheckFuel();

            //dialogues after 1st choice
            if (firstChoice == 1)
            {
                Console.WriteLine("\nSylas: 'This route consumes more fuel. The probability of success decreases.'");
                Console.WriteLine("Aria: 'Yeah, but look at those stars! Can’t deny this will be an adventure.'");
                Console.WriteLine("Sylas: 'Adventuring is illogical when fuel levels are so low.'");
                Console.WriteLine("Aria: 'Well, I guess we’ll see, huh?'");
            }
            else
            {
                Console.WriteLine("\nSylas: 'This route is more logical. Fuel efficiency is maximized.'");
                Console.WriteLine("Aria: 'I guess we’re taking the safe route this time. But hey, sometimes safety’s good.'");
                Console.WriteLine("Sylas: 'Survival is the only logical path.'");
                Console.WriteLine("Aria: 'Sure, sure… let’s see how this plays out.'");
            }
            Console.WriteLine("------------------------------");
            //i remember you telling us to put "-----..." between passages to make it more clear where the player is, so i did that here

            //second choice: distress signal
            Console.WriteLine("\nAs you continue your journey, a distress signal is detected from a nearby star system.");
            Console.WriteLine("1. Investigate the signal (40 fuel).");
            Console.WriteLine("2. Ignore it and conserve fuel (zero fuel).");
            Console.Write("Enter your choice (1 or 2): ");
            int secondChoice = GetValidInput();

            if (secondChoice == 1)
            {
                fuel -= 40;
                Console.WriteLine("\nYou decide to investigate the signal. It’s an abandoned ship with a small fuel reserve.");
                double fuelGain = rng.Next(10, 21); // Random fuel reward
                fuel += fuelGain;
                Console.WriteLine($"You salvaged {fuelGain} fuel units from the wreckage.");
            }
            else
            {
                Console.WriteLine("\nYou decide to conserve fuel and continue your journey.");
            }

            Console.WriteLine($"Remaining fuel: {fuel} units");
            CheckFuel();

            //2nd choice dialogues
            if (secondChoice == 1)
            {
                Console.WriteLine("\nAria: 'Nice! I knew there had to be something useful. This ship's got some serious treasure.'");
                Console.WriteLine("Sylas: 'This was a statistically sound decision, though not without risk.'");
                Console.WriteLine("Aria: 'Risk? Please, it’s all about the reward! I told you it was worth it.'");
                Console.WriteLine("Sylas: 'The reward was random. The risk was calculated.'");
            }
            else
            {
                Console.WriteLine("\nAria: 'Ugh, such a boring choice. No risk, no fun!'");
                Console.WriteLine("Sylas: 'In space, survival is the only fun worth pursuing.'");
                Console.WriteLine("Aria: 'I guess. But sometimes, I just wanna take the fun route.'");
            }
            Console.WriteLine("------------------------------");

            //third choice: space anomaly
            Console.WriteLine("\nScanners detect a massive space anomaly emitting strange signals.");
            Console.WriteLine("1. Approach the anomaly (35 fuel).");
            Console.WriteLine("2. Avoid the anomaly and chart a safer route (15 fuel).");
            Console.Write("Enter your choice (1 or 2): ");
            int thirdChoice = GetValidInput();

            if (thirdChoice == 1)
            {
                fuel -= 35;
                Console.WriteLine("\nYou approach the anomaly. It destabilizes your ship!");
                double anomalyOutcome = rng.Next(0, 2);
                if (anomalyOutcome == 0)
                {
                    Console.WriteLine("The anomaly caused significant damage, and you barely escaped. No resources were found.");
                }
                else
                {
                    double fuelReward = rng.Next(15, 31);
                    fuel += fuelReward;
                    Console.WriteLine($"The anomaly contained rare fuel particles! You gained {fuelReward} fuel units.");
                }
            }
            else
            {
                fuel -= 15;
                Console.WriteLine("\nYou chart a safer route and avoid the anomaly. It’s a cautious decision.");
            }

            Console.WriteLine($"Remaining fuel: {fuel} units");
            CheckFuel();

            //dialogue after 3rd choice
            if (thirdChoice == 1)
            {
                Console.WriteLine("\nSylas: 'Approaching the anomaly was a logical decision, but the risk was far from optimal.'");
                Console.WriteLine("Aria: 'I love a good thrill! Sure, it was risky, but where’s the adventure in playing it safe?'");
                Console.WriteLine("Sylas: 'Risk in this environment is illogical. I would have chosen the safer path.'");
                Console.WriteLine("Aria: 'Yeah, but that’s not how I roll.'");
            }
            else
            {
                Console.WriteLine("\nSylas: 'Avoiding the anomaly was the optimal choice. The risk was unnecessary.'");
                Console.WriteLine("Aria: 'Boring! But I get it, we needed to conserve fuel.'");
                Console.WriteLine("Sylas: 'Survival first. Adventure later.'");
                Console.WriteLine("Aria: 'Ugh. You and your logic. I’ll find my adventure somehow.'");
            }
            Console.WriteLine("------------------------------");

            //4th choice: alien encounter
            Console.WriteLine("\nAn alien ship appears on your scanners. They seem curious about your ship.");
            Console.WriteLine("1. Attempt communication (20 fuel).");
            Console.WriteLine("2. Prepare to escape (25 fuel).");
            Console.Write("Enter your choice (1 or 2): ");
            int fourthChoice = GetValidInput();

            if (fourthChoice == 1)
            {
                fuel -= 20;
                Console.WriteLine("\nYou attempt to communicate. The aliens share advanced fuel technology.");
                double alienFuel = rng.Next(20, 41);
                fuel += alienFuel;
                Console.WriteLine($"You gain {alienFuel} fuel units from the encounter.");
            }
            else
            {
                fuel -= 25;
                Console.WriteLine("\nYou prepare to escape. The maneuver consumes significant fuel, but you’re safe.");
            }

            Console.WriteLine($"Remaining fuel: {fuel} units");
            CheckFuel();

            //dialogues after 4th choice
            if (fourthChoice == 1)
            {
                Console.WriteLine("\nAria: 'Whoa! Aliens! And they were actually nice? This is amazing!' ");
                Console.WriteLine("Sylas: 'This encounter was not random. Your impulsive nature almost jeopardized us.'");
                Console.WriteLine("Aria: 'Whatever, we got fuel, and that’s what matters!' ");
                Console.WriteLine("Sylas: 'Only because the aliens chose to be beneficial. Do not rely on such kindness again.'");
            }
            else
            {
                Console.WriteLine("\nAria: 'Phew, that was too close! But escaping wasn’t a bad choice after all.'");
                Console.WriteLine("Sylas: 'Escaping was the logical decision. Safety was prioritized.'");
                Console.WriteLine("Aria: 'Yeah, but it would’ve been cool to talk to them! Oh well, another time.'");
            }
            Console.WriteLine("------------------------------");

            //printing the player name and fuel level at the end
            Console.WriteLine($"\nMission Summary for Commander {playerName}:");
            Console.WriteLine($"Final Fuel Level: {fuel} units");

            //there are 2 good endings depends on your fuel level and also the last message thanking you no matter which ending you got
            if (fuel > 10)
            {
                Console.WriteLine("\nYou successfully explored the galaxy and returned with valuable discoveries!");
            }
            else if (fuel > 0)
            {
                Console.WriteLine("\nYou barely made it back to base, but the mission was a success. A close call!");
            }

            Console.WriteLine("\nThank you for playing Space Exploration Adventure!");
        }
    }
}
