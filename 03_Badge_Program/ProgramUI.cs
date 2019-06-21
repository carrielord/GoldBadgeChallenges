using _03_Komodo_Badge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Badge_Program
{
    class ProgramUI
    {
        private BadgeRepository _badgeRepository = new BadgeRepository();

        public void Run()
        {
            SeedBadges();
            RunProgram();
        }

        private void RunProgram()
        {
            bool continueToRunMenu = true;

            while (continueToRunMenu)
            {
                Console.Clear();
                Console.WriteLine("Hello Security Admin, what would you like to do?\n" +
                    "1.Add a badge\n" +
                    "2.Edit a badge\n" +
                    "3.List all badges\n" +
                    "4. Exit");
                string actionSelection = Console.ReadLine();
                int selectionInt;
                bool success = Int32.TryParse(actionSelection, out selectionInt);
                if (success)
                {
                    switch (selectionInt)
                    {
                        case 1:
                            AddBadge();
                            break;
                        case 2:
                            EditBadge();
                            break;
                        case 3:
                            ListAllBadges();
                            break;
                        case 4:
                            continueToRunMenu = false;
                            break;
                        default:
                            Console.WriteLine("Please select valid number 1 through 4.\n" +
                                "Press any key to continue");
                            Console.ReadKey();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Please enter number only.\n" +
                        "Press any key to continue...");
                    Console.ReadKey();
                }
            }
        }

        private void AddBadge()
        {
            Badge newBadge = new Badge();
            List<string> newBadgeDoors = new List<string>();
            Console.Write("What is the number on the badge?");
            string badgeIDString = Console.ReadLine();
            int badgeID;
            bool badgeIDParse = false;
            while (!badgeIDParse)
            {
                badgeIDParse = int.TryParse(badgeIDString, out badgeID);
                if (badgeIDParse)
                {
                    newBadge.BadgeID = badgeID;
                }
                else
                {
                    Console.Write("Please enter a number only");
                    badgeIDString = Console.ReadLine();
                }
            }
            Console.Write("List a door that it needs access to:");
            newBadgeDoors.Add(Console.ReadLine());
            string otherDoors = "y";
            while(otherDoors != "n")
            {
                Console.Write("Any other doors(y/n)?");
                otherDoors = Console.ReadLine().ToLower();
                if(otherDoors == "y")
                {
                    Console.Write("List a door that it needs access to:");
                    newBadgeDoors.Add(Console.ReadLine());
                }
                else if (otherDoors == "n")
                {
                    break;
                }
                else
                {
                    Console.Write("Invalid entry. Please enter y or n only:");
                    otherDoors = Console.ReadLine().ToLower();
                }
            }
            newBadge.DoorName = newBadgeDoors;
            _badgeRepository.CreateNewBadge(newBadge.BadgeID, newBadge.DoorName);
        }

        private void EditBadge()
        {
            Console.Write("What is the badge number to update?");
            string badgeIDString = Console.ReadLine();
            int badgeID = 0;
            bool badgeIDParse = false;
            List<string> doorNames = new List<string>();
            while (!badgeIDParse)
            {
                badgeIDParse = int.TryParse(badgeIDString, out badgeID);
                if (badgeIDParse)
                {
                    doorNames = _badgeRepository.GetBadgeDoorsByID(badgeID);
                }
                else
                {
                    Console.Write("Please enter a number only");
                    badgeIDString = Console.ReadLine();
                }
            }
            Console.Write($"{badgeIDString} has access to doors ");
                foreach(string doorString in doorNames)
            {
                Console.Write(doorString);
            }
                Console.Write("What would you like to do?\n" +
                "1. Remove a door\n" +
                "2. Add a door");
                string actionSelection = Console.ReadLine();
                int selectionInt;
                bool success = Int32.TryParse(actionSelection, out selectionInt);
                if (success)
                {
                    switch (selectionInt)
                    {
                        case 1:
                            Console.Write("Which door would you like to remove?");
                        _badgeRepository.DeleteBadgeDoors(badgeID, Console.ReadLine());
                            Console.Write($"Door removed. \n" +
                                $"{badgeIDString} has access to doors");
                            foreach(in)
                            break;
                        case 2:
                            Console.Write("Which door would you like to add?");
                        _badgeRepository.AddBadgeDoors(badgeID, Console.ReadLine());
                        Console.WriteLine($"Door added. \n" +
                                $"{badgeIDString} has access to doors {doorNamesString}");
                        break;
                        default:
                            Console.WriteLine("Please select valid number 1 or 2.\n" +
                                "Press any key to continue");
                            Console.ReadKey();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Please enter number only.\n" +
                        "Press any key to continue...");
                    Console.ReadKey();
                }
            }

        private void ListAllBadges()
        {
            Dictionary<int, List<string>> badgeDictionary = _badgeRepository.ViewAllBadges();
            Console.WriteLine("{0,-10} {1,-15}", "Badge #", "Door Access");
            foreach(KeyValuePair<int, List<string>> badge in badgeDictionary)
            {
                Console.WriteLine("{0,-10}{1,-15}", badge.Key, badge.Value);
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

       

        private void SeedBadges()
        {
            List<string> firstDoorNames = new List<string>();
            List<string> secondDoorNames = new List<string>();
            List<string> thirdDoorNames = new List<string>();
            firstDoorNames.Add("A2");
            firstDoorNames.Add("A6");
            secondDoorNames.Add("B3");
            thirdDoorNames.Add("A2");
            thirdDoorNames.Add("A1");
            thirdDoorNames.Add("B5");

            Badge firstBadge = new Badge(12345, firstDoorNames);
            Badge secondBadge = new Badge(12354, secondDoorNames);
            Badge thirdBadge = new Badge(12647, thirdDoorNames);

            _badgeRepository.CreateNewBadge(12345, firstDoorNames);
            _badgeRepository.CreateNewBadge(12354, secondDoorNames);
            _badgeRepository.CreateNewBadge(12647, thirdDoorNames);


        }
    }
}
