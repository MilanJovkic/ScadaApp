using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ScadaCore
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class SCADACoreService : ITagProcessing, IUserProcessing
    {
        private Dictionary<string, Tag> tags = new Dictionary<string, Tag>();
        private Dictionary<string, User> users = new Dictionary<string, User>();

        public void AddTag(Tag tag) => tags[tag.Name] = tag;
        public void RemoveTag(string tagName) => tags.Remove(tagName);
        public void SetTagValue(string tagName, double value)
        {
            if (tags.ContainsKey(tagName))
                tags[tagName].Value = value;
        }
        public double GetTagValue(string tagName) => tags.ContainsKey(tagName) ? tags[tagName].Value : double.NaN;
        public void TurnScanOnOff(string tagName, bool onOff)
        {
            if (tags.ContainsKey(tagName))
                tags[tagName].ScanOn = onOff;
        }

        public void RegisterUser(String username, String password) => users[username] = new User(username, password);
        public bool Login(string username, string password) => users.ContainsKey(username) && users[username].Password == password;
        public void Logout(string username) { /* Implement logout logic if needed */ }
    }
}
