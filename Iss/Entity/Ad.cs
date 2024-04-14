using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Iss.Entity
{
    public class Ad
    {
        public string id {  get; set; }
        public string productName { get; set; }
        public string photo { get; set; }
       
        public string description { get; set; }
        public string websiteLink {  get; set; }

        public Ad(string productName, string photo, string description, string websiteLink)
        {
            this.productName = productName;
            this.photo = photo;
            this.description = description;
            this.websiteLink = websiteLink;
        }

        public Ad(string id, string productName, string photo, string description, string websiteLink)
        {
            this.id = id;
            this.productName = productName;
            this.photo = photo;
            this.description = description;
            this.websiteLink = websiteLink;
        }

        public override string ToString()
        {
            return "PRODUCT NAME: "+productName + "-" +"DESCRIPTION: "+ description + "-" + "URL: " + websiteLink;
        }
    }
}
