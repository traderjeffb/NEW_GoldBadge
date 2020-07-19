using System;
using _02_Claims;
using _03_Badge;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _03_Badge_Unit_Tests
{
    [TestClass]
    public class Badge_Tests
    {
        public readonly ClaimsRepository _repo = new ClaimsRepository();
        public readonly BadgeRepository _repo = new BadgeRepository();
        [TestMethod]
        public void ShowAllBadges_ShouldShowAllBadges()
        {
            //ARRANGE

            //ACT

            //ASSERT

        }

        [TestMethod]
        public void AddADoor_ShouldAddADoorToBadge()
        {
            //ARRANGE

            //ACT

            //ASSERT

        }

        [TestMethod]
        public void DeleteADoor_ShouldRemoveADoor()
        {
            //ARRANGE

            //ACT

            //ASSERT

        }
        [TestMethod]
        public void AddtoBadges()
        {
            //ARRANGE

            //ACT

            //ASSERT

        }
        [TestMethod]
        public void DeleteExistingBadge()
        {
            //ARRANGE

            //ACT

            //ASSERT
        }
    }
}
