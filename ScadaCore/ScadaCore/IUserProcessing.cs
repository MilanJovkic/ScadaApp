using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ScadaCore
{
    [ServiceContract]
    public interface IUserProcessing
    {
        [OperationContract]
        void RegisterUser(String username, String password);

        [OperationContract]
        bool Login(string username, string password);

        [OperationContract]
        void Logout(string username);
    }
}
