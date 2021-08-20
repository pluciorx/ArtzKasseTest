using System;
using System.Collections.Generic;
using System.Text;

namespace Drugs.BL.Interfaces
{
    public interface ISecurityService
    {
        bool Authenticate(string userName, string password);

    }
}
