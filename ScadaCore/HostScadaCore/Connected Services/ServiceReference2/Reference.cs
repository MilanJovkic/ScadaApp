﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HostScadaCore.ServiceReference2 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference2.ITagProcessing")]
    public interface ITagProcessing {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITagProcessing/AddTag", ReplyAction="http://tempuri.org/ITagProcessing/AddTagResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ScadaCore.DITag))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ScadaCore.AITag))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ScadaCore.DOTag))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ScadaCore.AOTag))]
        void AddTag(ScadaCore.Tag tag);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITagProcessing/AddTag", ReplyAction="http://tempuri.org/ITagProcessing/AddTagResponse")]
        System.Threading.Tasks.Task AddTagAsync(ScadaCore.Tag tag);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITagProcessing/RemoveTag", ReplyAction="http://tempuri.org/ITagProcessing/RemoveTagResponse")]
        void RemoveTag(string tagName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITagProcessing/RemoveTag", ReplyAction="http://tempuri.org/ITagProcessing/RemoveTagResponse")]
        System.Threading.Tasks.Task RemoveTagAsync(string tagName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITagProcessing/SetTagValue", ReplyAction="http://tempuri.org/ITagProcessing/SetTagValueResponse")]
        bool SetTagValue(string tagName, double value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITagProcessing/SetTagValue", ReplyAction="http://tempuri.org/ITagProcessing/SetTagValueResponse")]
        System.Threading.Tasks.Task<bool> SetTagValueAsync(string tagName, double value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITagProcessing/GetTagValue", ReplyAction="http://tempuri.org/ITagProcessing/GetTagValueResponse")]
        double GetTagValue(string tagName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITagProcessing/GetTagValue", ReplyAction="http://tempuri.org/ITagProcessing/GetTagValueResponse")]
        System.Threading.Tasks.Task<double> GetTagValueAsync(string tagName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITagProcessing/TurnScanOnOff", ReplyAction="http://tempuri.org/ITagProcessing/TurnScanOnOffResponse")]
        void TurnScanOnOff(string tagName, bool onOff);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITagProcessing/TurnScanOnOff", ReplyAction="http://tempuri.org/ITagProcessing/TurnScanOnOffResponse")]
        System.Threading.Tasks.Task TurnScanOnOffAsync(string tagName, bool onOff);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ITagProcessingChannel : HostScadaCore.ServiceReference2.ITagProcessing, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class TagProcessingClient : System.ServiceModel.ClientBase<HostScadaCore.ServiceReference2.ITagProcessing>, HostScadaCore.ServiceReference2.ITagProcessing {
        
        public TagProcessingClient() {
        }
        
        public TagProcessingClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public TagProcessingClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TagProcessingClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TagProcessingClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void AddTag(ScadaCore.Tag tag) {
            base.Channel.AddTag(tag);
        }
        
        public System.Threading.Tasks.Task AddTagAsync(ScadaCore.Tag tag) {
            return base.Channel.AddTagAsync(tag);
        }
        
        public void RemoveTag(string tagName) {
            base.Channel.RemoveTag(tagName);
        }
        
        public System.Threading.Tasks.Task RemoveTagAsync(string tagName) {
            return base.Channel.RemoveTagAsync(tagName);
        }
        
        public bool SetTagValue(string tagName, double value) {
            return base.Channel.SetTagValue(tagName, value);
        }
        
        public System.Threading.Tasks.Task<bool> SetTagValueAsync(string tagName, double value) {
            return base.Channel.SetTagValueAsync(tagName, value);
        }
        
        public double GetTagValue(string tagName) {
            return base.Channel.GetTagValue(tagName);
        }
        
        public System.Threading.Tasks.Task<double> GetTagValueAsync(string tagName) {
            return base.Channel.GetTagValueAsync(tagName);
        }
        
        public void TurnScanOnOff(string tagName, bool onOff) {
            base.Channel.TurnScanOnOff(tagName, onOff);
        }
        
        public System.Threading.Tasks.Task TurnScanOnOffAsync(string tagName, bool onOff) {
            return base.Channel.TurnScanOnOffAsync(tagName, onOff);
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference2.IUserProcessing")]
    public interface IUserProcessing {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserProcessing/RegisterUser", ReplyAction="http://tempuri.org/IUserProcessing/RegisterUserResponse")]
        bool RegisterUser(string username, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserProcessing/RegisterUser", ReplyAction="http://tempuri.org/IUserProcessing/RegisterUserResponse")]
        System.Threading.Tasks.Task<bool> RegisterUserAsync(string username, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserProcessing/Login", ReplyAction="http://tempuri.org/IUserProcessing/LoginResponse")]
        bool Login(string username, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserProcessing/Login", ReplyAction="http://tempuri.org/IUserProcessing/LoginResponse")]
        System.Threading.Tasks.Task<bool> LoginAsync(string username, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserProcessing/Logout", ReplyAction="http://tempuri.org/IUserProcessing/LogoutResponse")]
        void Logout(string username);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserProcessing/Logout", ReplyAction="http://tempuri.org/IUserProcessing/LogoutResponse")]
        System.Threading.Tasks.Task LogoutAsync(string username);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IUserProcessingChannel : HostScadaCore.ServiceReference2.IUserProcessing, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class UserProcessingClient : System.ServiceModel.ClientBase<HostScadaCore.ServiceReference2.IUserProcessing>, HostScadaCore.ServiceReference2.IUserProcessing {
        
        public UserProcessingClient() {
        }
        
        public UserProcessingClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public UserProcessingClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UserProcessingClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UserProcessingClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public bool RegisterUser(string username, string password) {
            return base.Channel.RegisterUser(username, password);
        }
        
        public System.Threading.Tasks.Task<bool> RegisterUserAsync(string username, string password) {
            return base.Channel.RegisterUserAsync(username, password);
        }
        
        public bool Login(string username, string password) {
            return base.Channel.Login(username, password);
        }
        
        public System.Threading.Tasks.Task<bool> LoginAsync(string username, string password) {
            return base.Channel.LoginAsync(username, password);
        }
        
        public void Logout(string username) {
            base.Channel.Logout(username);
        }
        
        public System.Threading.Tasks.Task LogoutAsync(string username) {
            return base.Channel.LogoutAsync(username);
        }
    }
}
