using _03_Badge;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Badge_Console
{
    class ProgramUI
    {
        readonly Badge _BadgeRepo = new Badge();
        //BadgeRepository _repo = new BadgeRepository(int BadgeID, List<string> doorList);
        //BadgeRepository _repo2 = new BadgeRepository(BadgeID, doorList);

        BadgeRepository _repo = new BadgeRepository();

        protected readonly Dictionary<int, List<string>> _dictBadges = new Dictionary<int, List<string>>();
        public void Run()
        {
            SeedBadges();
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
                    "1. Show all Badges \n" +
                    "2. Update door list for a Badge \n" +
                    "3. Add new Badge \n" +
                    "4. Remove Badge \n" +
                    "5. Exit");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        //show all
                        ShowAllBadges();
                        break;
                    case "2":
                        //update door list
                        Console.WriteLine("Press 1 to add a door \n" +
                            "Press 2 to delete a door");
                        int doorUpdate = int.Parse(Console.ReadLine());
                        if (doorUpdate == 1)
                        {
                            AddADoorToList();
                        }
                        else
                        {
                            DeleteADoorFromList();
                        }
                        break;
                    case "3":
                        //Add new 
                        AddToBadge();
                        //add all properties of Badge here
                        break;
                    case "4":
                        //remove
                        DeleteExistingBadge();
                        break;
                    case "5":
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

        private void AddToBadge()
        {
            Console.Clear();
            Badge _badge = new Badge();//-------new instance of Badge = _badge

            // badge number
            Console.WriteLine("Please enter the BadgeID: ");
            int newBadgeID = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the list of doors: ");
            List<string> newDoorList = new List<string>();
            newDoorList.Add(Console.ReadLine());
            _repo.AddToBadge(newBadgeID, newDoorList);

        }
        private void ShowAllBadges()
        {
            Console.Clear();
            var allBadges = _repo.GetContents();
            //foreach (KeyValuePair<int, List<string>> contentItem in _repo.GetContents())
            foreach (Badge contentItem in _repo.GetContents())

            {
                DisplayContent(contentItem);
                Console.WriteLine("---------------------");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private void DeleteExistingBadge()
        {
            Console.WriteLine("Enter the BadgeID you would you like to be removed?");
            int badgeID = int.Parse(Console.ReadLine());
            _repo.DeleteExistingBadge(badgeID);
            Console.WriteLine("Press any key to continue....");
            Console.ReadKey();
        }

        private void AddADoorToList()
        {
            Console.WriteLine("Enter the BadgeID to add doors to list?");
            int badge_ID = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the door to be added");
            string newDoor = Console.ReadLine();
            _repo.AddADoorToList(badge_ID, newDoor);
        }

        private void DeleteADoorFromList()
        {
            Console.WriteLine("Enter the BadgeID to remove door from list?");
            int badge_ID = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the door to be removed");
            string removeDoor = Console.ReadLine();
            _repo.AddADoorToList(badge_ID, removeDoor);


        }
        private void DisplayContent(Badge content)
        {
            Console.WriteLine($"Badge ID: {content.BadgeID} " +
                $"Door Name(s): {content.DoorName} ");
        }
        public void SeedBadges()
        {

            _repo.AddToBadge(int.Parse("77"), new List<string> { "M22", "K11" });
            _repo.AddToBadge(int.Parse("437"), new List<string> { "M22", "K11" });
            _repo.AddToBadge(int.Parse("48"), new List<string> { "M22", "K11" });
        }
    }
}
