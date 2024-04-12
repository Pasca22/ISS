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
        public List<string> photos { get; set; }
        public List<string> videos { get; set; }
        public string description { get; set; }
        public string websiteLink {  get; set; }

        public Ad(string productName, List<string> photos, List<string> videos, string description, string websiteLink)
        {
            this.productName = productName;
            this.photos = photos;
            this.videos = videos;
            this.description = description;
            this.websiteLink = websiteLink;
        }
    }
}
