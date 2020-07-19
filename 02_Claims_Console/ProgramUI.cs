using _02_Claims;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static _02_Claims.Claims;

namespace _02_Claims_Console
{
    class ProgramUI
    {


        //Claims _claimsRepo = new Claims();
        private readonly ClaimsRepository _repo = new ClaimsRepository();
        //Queue<Claims> _queueClaim = new Queue<Claims>();


        public void Run()
        {
            SeedClaimsList();
            RunMenu();
        }

        private void RunMenu()
        {
            //   string input = "";
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine(
                    "Please select a number from below: \n" +
                    "1. Show all claims \n" +
                    "2. Take care of next claim \n" +
                    "3. Add new claim \n" +
                    "4. Exit");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        //show all
                        ShowAllClaims();
                        break;
                    case "2":
                        //find by claimID
                        ShowNextClaim();
                        break;
                    case "3":
                        //Add new 
                        AddNewClaim();
                        break;
                    case "4":
                        //exit
                        continueToRun = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number between 1 and 5. \n" +
                            "Press any key to continue....");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void AddNewClaim()
        {
            Console.Clear();
            Claims newClaim  = new Claims();

            // claims ID number
            Console.WriteLine("Please enter the Claims ID Number: ");
            
            newClaim.ClaimID = int.Parse(Console.ReadLine());

            //claim type
            Console.WriteLine("Please enter the type of claim: \n" +
                "1. Home \n" +
                "2. Car \n" +
                "3. Theft \n");
            // _claimsRepo.TypeOfClaim = Console.ReadLine();
            string claimInput = Console.ReadLine();
            int claimNumber = int.Parse(claimInput);
            newClaim.TypeOfClaim = (ClaimType)claimNumber; 

            //description
            Console.WriteLine("Please enter the claim description: ");
            newClaim.Description = Console.ReadLine();

            Console.WriteLine("Please enter the amount of the claim: ");
            newClaim.ClaimAmount = int.Parse(Console.ReadLine());

            Console.WriteLine("Please enter the date of the accident: ");
            newClaim.DateOfIncident = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Please enter the date of the claim: ");
            newClaim.DateOfClaim = DateTime.Parse(Console.ReadLine());

            
            _repo.AddNewClaim(newClaim);
        }
        private void ShowAllClaims()
        {
            Console.Clear();
                foreach (Claims contentItem in _repo.GetAllClaims())
            {
                DisplayContent(contentItem);
                Console.WriteLine("---------------------");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        private void ShowNextClaim()
        {
            Claims nextClaim = _repo.GetNextClaim();
            DisplayContent(nextClaim);
            Console.WriteLine("do you want to take care of this claim? y or n?");
            string answer = Console.ReadLine();
                if(answer == "y")
                {
                _repo.DeleteExistingClaim(nextClaim);
                }
                else if(answer =="n")
                    {
                    RunMenu();
                }
                else
                {
                    Console.WriteLine("Please enter y or n" );
                    Console.ReadLine();
                }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

        }


        private void DisplayContent(Claims content)
        {
            Console.WriteLine($"Claim Number: {content.ClaimID} " +
                $"Type: {content.TypeOfClaim} " +
                $"Description: {content.Description} " +
                $"Amount: {content.ClaimAmount} " +
                $"DateOfAccident: {content.DateOfIncident} " +
                $"DateOfAccident: {content.DateOfClaim} " +
                $"IsValid: {content.IsValid} ");
        }


        public void SeedClaimsList()
        {
            //Queue<Claims> _queueClaim = new Queue<Claims>();
            Claims claim1 = new Claims(int.Parse("1"), ClaimType.car, "fender bender", float.Parse("400.00"), DateTime.Parse("8/25/2020"), DateTime.Parse("9/27/2020"), bool.Parse("true"));

            Claims claim2 = new Claims(int.Parse("2"), ClaimType.home, "house fire in kitchen", float.Parse("1800.00"), DateTime.Parse("6/19/19"), DateTime.Parse("7/1/19"), bool.Parse("true"));

            Claims claim3 = new Claims(int.Parse("3"), ClaimType.theft, "Radio removed", float.Parse("100.00"), DateTime.Parse("4/27/18"), DateTime.Parse("6/01/18"), bool.Parse("false"));

            _repo.AddNewClaim(claim1);
            _repo.AddNewClaim(claim2);
            _repo.AddNewClaim(claim3);



        }
    }
}
