using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Badge
{
    public class BadgeRepository
    {


        protected readonly Dictionary<int, List<string>> _dictBadges = new Dictionary<int, List<string>>();
        public BadgeRepository()
        {

        }

        //CRUD

        //CREATE
        public void AddToBadge(int badgeID, List<string> doorList)
        {
            _dictBadges.Add(badgeID,doorList);  
        }

        //READ
 
        public Dictionary<int, List<string>> GetContents()
        {
            return _dictBadges;
        }

        //DELETE
        public bool DeleteExistingBadge(int badgeID)
        {
            bool deleteResult = _dictBadges.Remove(badgeID);
            return deleteResult;
        }


        //UPDATE
        //ADD A DOOR (UPDATE)
        public void  AddADoorToList(int badgeID, string newDoor)
        {

            _dictBadges[badgeID].Add(newDoor );
        }

        public void DeleteADoorFromList(int badgeID, string removeDoor)
        {
            _dictBadges[badgeID].Remove(removeDoor);
        }
    }

}
