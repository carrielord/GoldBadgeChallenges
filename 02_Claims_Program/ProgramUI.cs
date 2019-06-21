using _02_Claims;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Claims_Program
{
    class ProgramUI
    {
        private ClaimRepository _claimRepository = new ClaimRepository();

        public void Run()
        {
            SeedClaims();
            RunProgram();
        }

        private void RunProgram()
        {
            bool continueToRunMenu = true;

            while (continueToRunMenu)
            {
                Console.Clear();
                Console.WriteLine("Choose a menu item:\n" +
                    "1.See all claims\n" +
                    "2.Take care of next claim\n" +
                    "3.Enter a new claim\n" +
                    "4. Exit");
                string actionSelection = Console.ReadLine();
                int selectionInt;
                bool success = Int32.TryParse(actionSelection, out selectionInt);
                if (success)
                {
                    switch (selectionInt)
                    {
                        case 1:
                            SeeAllClaims();
                            break;
                        case 2:
                            TakeCareOfNextClaim();
                            break;
                        case 3:
                            EnterNewClaim();
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

        private void EnterNewClaim()
        {
            Claim newClaim = new Claim();
            Console.WriteLine("Please enter claim ID number:");
            string claimIDString = Console.ReadLine();
            int claimIDInt;
            bool claimIDParse = false;
            while (!claimIDParse)
            {
                claimIDParse = int.TryParse(claimIDString, out claimIDInt);
                if (claimIDParse)
                {
                    newClaim.ClaimID = claimIDInt;
                }
                else
                {
                    Console.WriteLine("Please enter a number only");
                    claimIDString = Console.ReadLine();
                }
            }
            Console.WriteLine("Please enter claim type (car, home, or theft)");
            string claimTypeString = Console.ReadLine();
            while(newClaim.ClaimType != TypeOfClaim.Car || newClaim.ClaimType != TypeOfClaim.Home || newClaim.ClaimType != TypeOfClaim.Theft)
            {
                switch (claimTypeString.ToLower())
                {
                    case "car":
                        newClaim.ClaimType = TypeOfClaim.Car;
                        break;
                    case "home":
                        newClaim.ClaimType = TypeOfClaim.Home;
                        break;
                    case "theft":
                        newClaim.ClaimType = TypeOfClaim.Theft;
                        break;
                    default:
                        Console.WriteLine("Please only enter \"car, home, or theft\"");
                        break;
                }
                break;
            }
            Console.WriteLine("Please enter claim description:");
            newClaim.ClaimDescription = Console.ReadLine();
            Console.WriteLine("Please enter claim amount");
            string claimAmountString = Console.ReadLine();
            decimal claimAmountDec;
            bool claimAmountParse = false;
            while (!claimAmountParse)
            {
                claimAmountParse = decimal.TryParse(claimAmountString, out claimAmountDec);
                if (claimAmountParse)
                {
                    newClaim.ClaimAmount = claimAmountDec;
                }
                else
                {
                    Console.WriteLine("Please enter a number only");
                    claimAmountString = Console.ReadLine();
                }
            }
            Console.WriteLine("Please enter the year of the incident date");
            string incidentYearString = Console.ReadLine();
            int incidentYearInt = 0;
            bool incidentYearParse = false;
            while (!incidentYearParse)
            {
                incidentYearParse = int.TryParse(incidentYearString, out incidentYearInt);
                if (!incidentYearParse)
                { 
                    Console.WriteLine("Please enter a number only");
                    incidentYearString = Console.ReadLine();
                }
            }
            Console.WriteLine("Please enter the month of the incident date");
            string incidentMonthString = Console.ReadLine();
            int incidentMonthInt = 0;
            bool incidentMonthParse = false;
            while (!incidentMonthParse)
            {
                incidentMonthParse = int.TryParse(incidentMonthString, out incidentMonthInt);
                if (!incidentMonthParse)
                {
                    Console.WriteLine("Please enter a number only");
                    incidentMonthString = Console.ReadLine();
                }
            }
            Console.WriteLine("Please enter the day of the incident date");
            string incidentDayString = Console.ReadLine();
            int incidentDayInt = 0;
            bool incidentDayParse = false;
            while (!incidentDayParse)
            {
                incidentDayParse = int.TryParse(incidentDayString, out incidentDayInt);
                if (!incidentDayParse)
                {
                    Console.WriteLine("Please enter a number only");
                    incidentYearString = Console.ReadLine();
                }
            }
            newClaim.DateOfIncident = new DateTime(incidentYearInt, incidentMonthInt, incidentDayInt);

            Console.WriteLine("Please enter the year of the claim date");
            string claimYearString = Console.ReadLine();
            int claimYearInt = 0;
            bool claimYearParse = false;
            while (!claimYearParse)
            {
                claimYearParse = int.TryParse(claimYearString, out claimYearInt);
                if (!claimYearParse)
                {
                    Console.WriteLine("Please enter a number only");
                    claimYearString = Console.ReadLine();
                }
            }
            Console.WriteLine("Please enter the month of the claim date");
            string claimMonthString = Console.ReadLine();
            int claimMonthInt = 0;
            bool claimMonthParse = false;
            while (!claimMonthParse)
            {
                claimMonthParse = int.TryParse(claimMonthString, out claimMonthInt);
                if (!claimMonthParse)
                {
                    Console.WriteLine("Please enter a number only");
                    claimMonthString = Console.ReadLine();
                }
            }
            Console.WriteLine("Please enter the day of the claim date");
            string claimDayString = Console.ReadLine();
            int claimDayInt = 0;
            bool claimDayParse = false;
            while (!claimDayParse)
            {
                claimDayParse = int.TryParse(claimDayString, out claimDayInt);
                if (!claimDayParse)
                {
                    Console.WriteLine("Please enter a number only");
                    claimYearString = Console.ReadLine();
                }
            }
            newClaim.DateOfClaim = new DateTime(claimYearInt, claimMonthInt, claimDayInt);

            _claimRepository.AddClaim(newClaim);
            Console.WriteLine("Claim has been added successfully.\n" +
                "Press any key to continue...");
            Console.ReadKey();
        }

        private void TakeCareOfNextClaim()
        {
            Claim nextClaim = _claimRepository.SeeNextClaim();
            Console.Write($"Claim ID: {nextClaim.ClaimID}\n" +
                $"Claim Type: {nextClaim.ClaimType}\n" +
                $"Claim Description: {nextClaim.ClaimDescription}\n" +
                $"Claim Amount: {nextClaim.ClaimAmount}\n" +
                $"Incident Date: {nextClaim.DateOfIncident}\n" +
                $"Claim Date: {nextClaim.DateOfClaim}\n" +
                $"Is claim valid?: {nextClaim.IsValid}\n" +
                "\n" +
                "Would you like to deal with this claim now(y/n)?  ");
            string dealAnswer = Console.ReadLine();
            while (true)
            { if (dealAnswer.ToLower() == "y")
                {
                    _claimRepository.DealWithClaim();
                    break;
                }
                else if (dealAnswer.ToLower() == "n")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter \"y\" or \"n\" only");
                    dealAnswer = Console.ReadLine();
                }
            }
        }

        private void SeeAllClaims()
        {
            Queue<Claim> claimQueue = _claimRepository.ViewClaimQueue();
            Console.WriteLine("{0,-10}{1,-12}{2,-35}{3,-10}{4,-18}{5,-15}{6,10}", "Claim ID", "Claim Type", "Description", "Amount", "Date of Incident", "Date of Claim", "Is Valid");
            foreach (Claim claim in claimQueue)
            {
                Console.WriteLine("{0,-10}{1,-12}{2,-35}{3,-10}{4,-18}{5,-15}{6,10}", claim.ClaimID, claim.ClaimType, claim.ClaimDescription, $"${claim.ClaimAmount}", claim.DateOfIncident.ToString("MM/dd/yy"), claim.DateOfIncident.ToString("mm/dd/yy"), claim.IsValid);
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        private void SeedClaims()
        {
            Claim claimOne = new Claim(1, TypeOfClaim.Car, "Ran into pole.", 837.09m, new DateTime(2018, 12, 19), new DateTime(2018, 12, 25));
            Claim claimTwo = new Claim(2, TypeOfClaim.Home, "Tree fell on roof in monsoon.", 9365.73m, new DateTime(2019, 4, 1), new DateTime(2019, 5, 2));
            Claim claimThree = new Claim(3, TypeOfClaim.Theft, "Cat stolen from porch.", 293m, new DateTime(2019, 3, 3), new DateTime(2019, 3, 4));
            _claimRepository.AddClaim(claimOne);
            _claimRepository.AddClaim(claimTwo);
            _claimRepository.AddClaim(claimThree);
        }
    }
}
