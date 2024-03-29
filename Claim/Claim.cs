﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Claims
{
    public enum TypeOfClaim
    {
        Car,
        Home,
        Theft
    }
    public class Claim
    {
        public Claim() { }

        public int ClaimID { get; set; }
        public TypeOfClaim ClaimType { get; set; }
        public string ClaimDescription { get; set; }
        public decimal ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid { get {
                TimeSpan month = new TimeSpan(30, 0, 0, 0);
                TimeSpan diff = DateOfClaim.Subtract(DateOfIncident);
                if (diff <= month)
                  { return true; }
                else{ return false; }
                } }

        public Claim(int claimID, TypeOfClaim claimType, string claimDescription, decimal claimAmount, DateTime dateOfIncident, DateTime dateOfClaim)
        {
            ClaimID = claimID;
            ClaimType = claimType;
            ClaimDescription = claimDescription;
            ClaimAmount = claimAmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
        }
    }
}

//A Claim has the following properties:

//ClaimID, ClaimType, Description, ClaimAmount, DateOfIncident, DateOfClaim, IsValid

//Komodo allows an insurance claim to be made up to 30 days after an incident
//took place.If the claim is not in the proper time limit, it is not valid. 

//A ClaimType could be the following:

  //  Car, Home, Theft 