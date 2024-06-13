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
        public bool SetTagValue(string tagName, double value)
        {
            if (isLoggedIn)
            {
                if (tags.ContainsKey(tagName))
                {
                    if (tags[tagName] is DOTag)
                    {
                        DOTag dOTag = tags[tagName] as DOTag;
                        dOTag.InitialValue = value;
                        tags[tagName] = dOTag;
                        return true;
                    }
                    else if (tags[tagName] is AOTag)
                    {
                        AOTag aOTag = tags[tagName] as AOTag;
                        if (value >= aOTag.LowLimit && value <= aOTag.HighLimit)
                        {
                            aOTag.InitialValue = value;
                            tags[tagName] = aOTag;
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return false;
        }
        public double GetTagValue(string tagName) {
            if (isLoggedIn)
            {
                if (tags.ContainsKey(tagName))
                {
                    if (tags[tagName] is DOTag)
                    {
                        DOTag dOTag = tags[tagName] as DOTag;
                        return dOTag.InitialValue;
                    }

                    if (tags[tagName] is AOTag)
                    {
                        AOTag aOTag = tags[tagName] as AOTag;
                        return aOTag.InitialValue;
                    }
                }
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

        public bool RegisterUser(string username, string password) 
        {
            if (!users.ContainsKey(username))
            {
                users[username] = new User(username, password);
                return true;
            }
            return false;
        } 
        public bool Login(string username, string password) 
        {
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
