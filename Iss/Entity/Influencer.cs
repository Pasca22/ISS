using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iss.Entity
{
    public class Influencer
    {
        private int userId;
        private String name;
        private int followerCount;
        private int collaborationPrice;

        public Influencer(int userId, string name, int followerCount, int collaborationPrice)
        {
            this.userId = userId;
            this.name = name;
            this.followerCount = followerCount;
            this.collaborationPrice = collaborationPrice;
        }

        public int getUserId() { return userId; }

        public string getName() { return name; }

        public int getFollowerCount()
        {

            return followerCount;
        }
        public int getCollaborationPrice() {  return collaborationPrice; }
        public void setUserId(int userId)
        {
            this.userId = userId;
        }

        public void setName( String name) { this.name = name;
        
        }

        public void setFollowerCount( int followerCount)
        {
            this.followerCount=followerCount;
        }

        public void setCollaborationPrice( int collaborationPrice)
        {
            this.collaborationPrice=collaborationPrice;
        }
    }
}
