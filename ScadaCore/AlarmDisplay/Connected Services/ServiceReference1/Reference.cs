﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AlarmDisplay.ServiceReference1 {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="TriggeredAlarm", Namespace="http://schemas.datacontract.org/2004/07/ScadaCore")]
    [System.SerializableAttribute()]
    public partial class TriggeredAlarm : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private AlarmDisplay.ServiceReference1.Alarm AlarmField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime TriggeredAtField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public AlarmDisplay.ServiceReference1.Alarm Alarm {
            get {
                return this.AlarmField;
            }
            set {
                if ((object.ReferenceEquals(this.AlarmField, value) != true)) {
                    this.AlarmField = value;
                    this.RaisePropertyChanged("Alarm");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime TriggeredAt {
            get {
                return this.TriggeredAtField;
            }
            set {
                if ((this.TriggeredAtField.Equals(value) != true)) {
                    this.TriggeredAtField = value;
                    this.RaisePropertyChanged("TriggeredAt");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Alarm", Namespace="http://schemas.datacontract.org/2004/07/ScadaCore")]
    [System.SerializableAttribute()]
    public partial class Alarm : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int PriorityField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TagNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double ThresholdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private AlarmDisplay.ServiceReference1.AlarmType TypeField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Priority {
            get {
                return this.PriorityField;
            }
            set {
                if ((this.PriorityField.Equals(value) != true)) {
                    this.PriorityField = value;
                    this.RaisePropertyChanged("Priority");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string TagName {
            get {
                return this.TagNameField;
            }
            set {
                if ((object.ReferenceEquals(this.TagNameField, value) != true)) {
                    this.TagNameField = value;
                    this.RaisePropertyChanged("TagName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double Threshold {
            get {
                return this.ThresholdField;
            }
            set {
                if ((this.ThresholdField.Equals(value) != true)) {
                    this.ThresholdField = value;
                    this.RaisePropertyChanged("Threshold");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public AlarmDisplay.ServiceReference1.AlarmType Type {
            get {
                return this.TypeField;
            }
            set {
                if ((this.TypeField.Equals(value) != true)) {
                    this.TypeField = value;
                    this.RaisePropertyChanged("Type");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="AlarmType", Namespace="http://schemas.datacontract.org/2004/07/ScadaCore")]
    public enum AlarmType : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        low = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        high = 1,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IAlarmDisplayService", CallbackContract=typeof(AlarmDisplay.ServiceReference1.IAlarmDisplayServiceCallback))]
    public interface IAlarmDisplayService {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IAlarmDisplayService/InitializeAlarmDisplay")]
        void InitializeAlarmDisplay();
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IAlarmDisplayService/InitializeAlarmDisplay")]
        System.Threading.Tasks.Task InitializeAlarmDisplayAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IAlarmDisplayServiceCallback {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IAlarmDisplayService/AlarmTriggered")]
        void AlarmTriggered(AlarmDisplay.ServiceReference1.TriggeredAlarm alarm, double value);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IAlarmDisplayServiceChannel : AlarmDisplay.ServiceReference1.IAlarmDisplayService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class AlarmDisplayServiceClient : System.ServiceModel.DuplexClientBase<AlarmDisplay.ServiceReference1.IAlarmDisplayService>, AlarmDisplay.ServiceReference1.IAlarmDisplayService {
        
        public AlarmDisplayServiceClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public AlarmDisplayServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public AlarmDisplayServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public AlarmDisplayServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public AlarmDisplayServiceClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public void InitializeAlarmDisplay() {
            base.Channel.InitializeAlarmDisplay();
        }
        
        public System.Threading.Tasks.Task InitializeAlarmDisplayAsync() {
            return base.Channel.InitializeAlarmDisplayAsync();
        }
    }
}
