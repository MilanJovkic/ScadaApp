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
        private bool isLoggedIn = false;

        public void AddTag(Tag tag) {
            if (isLoggedIn) {
                tags[tag.Name] = tag;
            }
        }
        public void RemoveTag(string tagName) {
            if (isLoggedIn)
            {
                tags.Remove(tagName);
            }
        }
        public void SetTagValue(string tagName, double value)
        {
            if (isLoggedIn)
            {
                if (tags.ContainsKey(tagName))
                    tags[tagName].Value = value;
            }
        }
        public double GetTagValue(string tagName) {
            if (isLoggedIn)
            {
                return tags.ContainsKey(tagName) ? tags[tagName].Value : double.NaN;
            }
            return double.NaN;
        }
        public void TurnScanOnOff(string tagName, bool onOff)
        {
            if (isLoggedIn)
            {
                if (tags.ContainsKey(tagName))
                    tags[tagName].ScanOn = onOff;
            }
        }

        public bool RegisterUser(String username, String password) {
            if (users[username] == null) {
                users[username] = new User(username, password);
                return true;
            }
            return false;
        } 
        public bool Login(string username, string password) {
            bool isCorrect = users.ContainsKey(username) && users[username].Password == password;
            if (isCorrect) { 
                isLoggedIn = true;
            }
            return isCorrect;
        } 
        public void Logout(string username) { 
            isLoggedIn = false;
        }
    }
}
