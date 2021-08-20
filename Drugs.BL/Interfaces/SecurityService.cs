using System;
using System.Collections.Generic;
using System.Text;

namespace Drugs.BL.Interfaces
{
    public class SecurityService : ISecurityService
    {
        public bool Authenticate(string userName, string password)
        {
            return (userName == "Artztest") && (password == "Artztest") ;
          
        }
    }
}
