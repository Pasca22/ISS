using Iss.Entity;
using Iss.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Iss.User;

namespace Iss.Service
{
    internal class RequestService
    {
        private RequestRepository requestRepository;

        public RequestService()
        {
            this.requestRepository = new RequestRepository();
        }

        public void addRequest(Request request)
        {
            this.requestRepository.addRequest(request);
        }

  
        public void deleteRequest(Request request)
        {
            this.requestRepository.deleteRequest(request);
        }
    }
}
