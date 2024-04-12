﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iss.Entity
{
    public class AdAccount
    {
        public string nameOfCompany { get; set; }
        public string domainOfActivity { get; set; }
        public string siteUrl { get; set; }
        public string password { get; set; }
        public string taxIdentificationNumber { get; set; }
        public string headquartersLocation { get; set; }
        public string authorisingInstituion { get; set; }

        public AdAccount(string nameOfCompany, string domainOfActivity, string siteUrl, string password, string taxIdentificationNumber, string headquartersLocation, string authorisingInstituion)
        {
            this.nameOfCompany = nameOfCompany;
            this.domainOfActivity = domainOfActivity;
            this.siteUrl = siteUrl;
            this.password = password;
            this.taxIdentificationNumber = taxIdentificationNumber;
            this.headquartersLocation = headquartersLocation;
            this.authorisingInstituion = authorisingInstituion;
        }
    }
}