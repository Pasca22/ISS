using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iss.Entity
{
    public class Ad
    {
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
    }
}
