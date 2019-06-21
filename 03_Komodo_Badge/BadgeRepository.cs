using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Komodo_Badge
{
    public class BadgeRepository
    {
        private Dictionary<int, List<string>> _badgeDictionary = new Dictionary<int, List<string>>();

        public Dictionary<int, List<string>> ViewAllBadges()
        {
            return _badgeDictionary;
        }

        public void CreateNewBadge(int badgeID, List<string> doorNames)
        {
            _badgeDictionary.Add(badgeID, doorNames);
        }

        public void AddBadgeDoors(int badgeID, string newDoor)
        {
            _badgeDictionary[badgeID].Add(newDoor);
        }

        public void DeleteBadgeDoors(int badgeID, string doorName)
        {
            _badgeDictionary[badgeID].Remove(doorName);
        }

        public List<string> GetBadgeDoorsByID(int badgeID)
        {
            List<string> doorNames = _badgeDictionary[badgeID];
            return doorNames;
        }
    }
}

//A badge repository that will have methods that do the following:
//1. Create a dictionary of badges.
//2. The key for the dictionary will be the BadgeID.
//3. The value for the dictionary will be the List of Door Names.

//The Program will allow a security staff member to do the following:
//----create a new badge
//----update doors on an existing badge.
//----delete all doors from an existing badge.
//----show a list with all badge numbers and door access, like this: