using System;
using System.Collections.Generic;
using System.IO;
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
        public static Dictionary<string, Tag> tags = new Dictionary<string, Tag>();
        private Dictionary<string, User> users = new Dictionary<string, User>();
        private bool isLoggedIn = false;
        private UsersContext db = new UsersContext();
        private static readonly string SolutionDirectory1 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..");
        public static readonly string FilePath1 = Path.Combine(SolutionDirectory1, "tags.xml");

        public void AddTag(Tag tag) {
            if (isLoggedIn) {
                tags[tag.Name] = tag;
                XmlSerializationHelper.SerializeTagsToXml(tags, FilePath1);
            }
        }
        public void RemoveTag(string tagName) {
            if (isLoggedIn)
            {
                tags.Remove(tagName);
                XmlSerializationHelper.SerializeTagsToXml(tags, FilePath1);
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
                        XmlSerializationHelper.SerializeTagsToXml(tags, FilePath1);
                        return true;
                    }
                    else if (tags[tagName] is AOTag)
                    {
                        AOTag aOTag = tags[tagName] as AOTag;
                        if (value >= aOTag.LowLimit && value <= aOTag.HighLimit)
                        {
                            aOTag.InitialValue = value;
                            tags[tagName] = aOTag;
                            XmlSerializationHelper.SerializeTagsToXml(tags, FilePath1);
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
                {
                    if (tags[tagName] is AITag)
                    {
                        AITag aITag = tags[tagName] as AITag;
                        aITag.ScanOn = onOff;
                        tags[tagName] = aITag;
                    }
                    else if (tags[tagName] is DITag)
                    {
                        DITag dITag = tags[tagName] as DITag;
                        dITag.ScanOn = onOff;
                        tags[tagName] = dITag;
                    }
                    XmlSerializationHelper.SerializeTagsToXml(tags, FilePath1);
                }
            }
        }

        public bool RegisterUser(string username, string password) 
        {
            if (!users.ContainsKey(username))
            {
                users[username] = new User(username, password);
                db.Users.Add(users[username]);
                db.SaveChanges();
                return true;
            }
            return false;
        } 
        public bool Login(string username, string password) 
        {
            bool isCorrect = db.Users.Any(u => u.Username == username && u.Password == password);
            if (isCorrect) { 
                isLoggedIn = true;
                XmlSerializationHelper.DeserializeTagsFromXml(FilePath1).ToList().ForEach(x => tags.Add(x.Key, x.Value));
            }
            return isCorrect;
        } 
        public void Logout(string username) { 
            isLoggedIn = false;
        }
        //public string GetInputTagValue() {
        //    var dict = new Dictionary<string, object>();
        //    foreach (var tag in tags)
        //    {
        //        if (tag.Value is AITag aiTag)
        //        {
        //            if (aiTag.ScanOn)
        //            {
        //                dict[tag.Key] = RealTimeDriver.RealTimeDriver.ReadValue(aiTag.IOAddress);
        //            }
        //        }
        //        else if (tag.Value is DITag diTag)
        //        {
        //            if (diTag.ScanOn)
        //            {
        //                dict[tag.Key] = RealTimeDriver.RealTimeDriver.ReadValue(diTag.IOAddress);
        //            }
        //        }
        //    }
        //    return GenerateTable(dict);
        //}
        //private string GenerateTable(Dictionary<string, object> data)
        //{
        //    // Initialize the resulting string
        //    string result = "Name\tValue\n";
        //    result += "------------------------\n";

        //    // Iterate through all key-value pairs in the dictionary
        //    foreach (var item in data)
        //    {
        //        // if item value NaN string is no device on the field
        //        if (item.Value.ToString() == "NaN")
        //        {
        //            result += $"{item.Key}\tNo device on the field\n";
        //        }
        //        else
        //        {
        //            result += $"{item.Key}\t{item.Value.ToString()}\n";
        //        }
        //    }

        //    return result;
        //}

    }
}
