using System;
using System.Collections.Generic;
using System.Security.Claims;
using _02_Claims;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static _02_Claims.Claims;

namespace _02_Claims_Unit_Tests
{
    [TestClass]
    public class Claims_Tests
    {
        public readonly List<Claims> _claims = new List<Claims>();
        public readonly ClaimsRepository _repo = new ClaimsRepository();
        public void SeedClaimsList()
        {
            //Queue<Claims> _queueClaim = new Queue<Claims>();

            Claims claim1 = new Claims(int.Parse("1"), ClaimType.car, "fender bender", float.Parse("400.00"), DateTime.Parse("8/25/2020"), DateTime.Parse("9/27/2020"), bool.Parse("true"));

            Claims claim2 = new Claims(int.Parse("2"), ClaimType.home, "house fire in kitchen", float.Parse("1800.00"), DateTime.Parse("6/19/19"), DateTime.Parse("7/1/19"), bool.Parse("true"));

            Claims claim3 = new Claims(int.Parse("3"), ClaimType.theft, "Radio removed", float.Parse("100.00"), DateTime.Parse("9/27/2020"), DateTime.Parse("9/23/2020"), bool.Parse("false"));

            _repo.AddNewClaim(claim1);
            _repo.AddNewClaim(claim2);
            _repo.AddNewClaim(claim3);



        }

            [TestMethod]
            public void ShowNextClaim_ShouldShowNextClaimInQueue()
            {
            //arrange
             ClaimsRepository _repo = new ClaimsRepository();
             List<Claims> _claims = new List<Claims>();
             Claims claim1= new Claims(int.Parse("1"), ClaimType.car, "fender bender", float.Parse("400.00"), DateTime.Parse("8/25/2020"), DateTime.Parse("9/27/2020"), bool.Parse("true"));
            Claims claim2 = new Claims(int.Parse("2"), ClaimType.home, "house fire in kitchen", float.Parse("1800.00"), DateTime.Parse("6/19/19"), DateTime.Parse("7/1/19"), bool.Parse("true"));
            //Act
            _repo.AddNewClaim(claim1);
            _repo.AddNewClaim(claim2);

            var nextClaim = _repo.GetNextClaim();

            //Assert
            Assert.AreEqual(nextClaim, claim1);


            }


        [TestMethod]
        public void AddNewClaim_ShouldAddNewClaim()
        {
            //Arrange
            int startingCount = _claims.Count;
            //Act
            Claims claim5 = new Claims(int.Parse("5"), ClaimType.car, "accident on 69", float.Parse("800"), DateTime.Parse("4/25/18"), DateTime.Parse("4/27/18"), bool.Parse("true"));
            _claims.Add(claim5);
            int afterAddingCount = _claims.Count;
            //Assert
            Assert.AreNotEqual(startingCount, afterAddingCount);
        }


        [TestMethod]
        public void ShowAllClaims_ShouldShowAllClaims()
        {
            //ARRANGE
            Claims claim1 = new Claims(int.Parse("1"), ClaimType.car, "fender bender", float.Parse("400.00"), DateTime.Parse("8/25/2020"), DateTime.Parse("9/27/2020"), bool.Parse("true"));

            Claims claim2 = new Claims(int.Parse("2"), ClaimType.home, "house fire in kitchen", float.Parse("1800.00"), DateTime.Parse("6/19/19"), DateTime.Parse("7/1/19"), bool.Parse("true"));

            Claims claim3 = new Claims(int.Parse("3"), ClaimType.theft, "Radio removed", float.Parse("100.00"), DateTime.Parse("9/27/2020"), DateTime.Parse("9/23/2020"), bool.Parse("false"));

            _repo.AddNewClaim(claim1);
            _repo.AddNewClaim(claim2);
            _repo.AddNewClaim(claim3);

            //ACT
            int totalCount = _repo.GetAllClaims().Count;
            int expectedCountFromSeedData = 3;

            //ASSERT
            Assert.AreEqual(totalCount, expectedCountFromSeedData);
        }
        

    } 
}


