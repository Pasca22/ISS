
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Iss.Entity;
using Iss.Repository;

namespace Iss.Service
{
    internal class CollaborationService
    {

        private CollaborationRepository collaborationRepository = new CollaborationRepository();


        public void addCollaboration(Collaboration collaboration)
        {
            collaborationRepository.createCollaboration(collaboration);
        }

        public List<Collaboration> getCollaborationForAdAccount()
        {
            return collaborationRepository.GetCollaborationsForAdAccount();
        }

        public List<Collaboration> getCollaborationForInfluencer()
        {
            return collaborationRepository.getCollaborationsForInfluencer();
        }

        public List<Collaboration> getActiveCollaborationForAdAccount()
        {

            return collaborationRepository.GetCollaborationsForAdAccount().Where(c => c.status).ToList();
        }
    }
}