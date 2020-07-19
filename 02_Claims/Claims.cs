﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Claims
{
    public class Claims
    {
        public enum ClaimType
        {
            car,
            home,
            theft

        }

            public int ClaimID { get; set; }
            public ClaimType TypeOfClaim { get; set; }
            public string Description { get; set; }
            public float ClaimAmount { get; set; }
            public DateTime DateOfIncident { get; set; }
            public DateTime DateOfClaim { get; set; }
            public bool IsValid { get; set; }



            public Claims() { }

            public Claims(int claimID, ClaimType typeOfClaim, string description, float claimAmount, DateTime dateOfIncident, DateTime dateOfClaim, bool isValid)

            {
                ClaimID = claimID;
                TypeOfClaim = typeOfClaim;
                Description = description;
                ClaimAmount = claimAmount;
                DateOfIncident = dateOfIncident;
                DateOfClaim = dateOfClaim;
                IsValid = isValid;

            }

        }
}
