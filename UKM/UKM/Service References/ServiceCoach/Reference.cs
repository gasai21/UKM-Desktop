﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UKM.ServiceCoach {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Account", Namespace="http://schemas.datacontract.org/2004/07/UKMService")]
    [System.SerializableAttribute()]
    public partial class Account : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string AddressField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string BatchField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FacultyField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string GenderField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string JobField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MajorField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NimField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PasswordField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PhoneNumberField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UsernameField;
        
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
        public string Address {
            get {
                return this.AddressField;
            }
            set {
                if ((object.ReferenceEquals(this.AddressField, value) != true)) {
                    this.AddressField = value;
                    this.RaisePropertyChanged("Address");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Batch {
            get {
                return this.BatchField;
            }
            set {
                if ((object.ReferenceEquals(this.BatchField, value) != true)) {
                    this.BatchField = value;
                    this.RaisePropertyChanged("Batch");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Faculty {
            get {
                return this.FacultyField;
            }
            set {
                if ((object.ReferenceEquals(this.FacultyField, value) != true)) {
                    this.FacultyField = value;
                    this.RaisePropertyChanged("Faculty");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Gender {
            get {
                return this.GenderField;
            }
            set {
                if ((object.ReferenceEquals(this.GenderField, value) != true)) {
                    this.GenderField = value;
                    this.RaisePropertyChanged("Gender");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Id {
            get {
                return this.IdField;
            }
            set {
                if ((object.ReferenceEquals(this.IdField, value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Job {
            get {
                return this.JobField;
            }
            set {
                if ((object.ReferenceEquals(this.JobField, value) != true)) {
                    this.JobField = value;
                    this.RaisePropertyChanged("Job");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Major {
            get {
                return this.MajorField;
            }
            set {
                if ((object.ReferenceEquals(this.MajorField, value) != true)) {
                    this.MajorField = value;
                    this.RaisePropertyChanged("Major");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Nim {
            get {
                return this.NimField;
            }
            set {
                if ((object.ReferenceEquals(this.NimField, value) != true)) {
                    this.NimField = value;
                    this.RaisePropertyChanged("Nim");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Password {
            get {
                return this.PasswordField;
            }
            set {
                if ((object.ReferenceEquals(this.PasswordField, value) != true)) {
                    this.PasswordField = value;
                    this.RaisePropertyChanged("Password");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PhoneNumber {
            get {
                return this.PhoneNumberField;
            }
            set {
                if ((object.ReferenceEquals(this.PhoneNumberField, value) != true)) {
                    this.PhoneNumberField = value;
                    this.RaisePropertyChanged("PhoneNumber");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Username {
            get {
                return this.UsernameField;
            }
            set {
                if ((object.ReferenceEquals(this.UsernameField, value) != true)) {
                    this.UsernameField = value;
                    this.RaisePropertyChanged("Username");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="StudentUKM", Namespace="http://schemas.datacontract.org/2004/07/UKMService")]
    [System.SerializableAttribute()]
    public partial class StudentUKM : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string IdAccountField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string StatusField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UkmidField;
        
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
        public string Id {
            get {
                return this.IdField;
            }
            set {
                if ((object.ReferenceEquals(this.IdField, value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string IdAccount {
            get {
                return this.IdAccountField;
            }
            set {
                if ((object.ReferenceEquals(this.IdAccountField, value) != true)) {
                    this.IdAccountField = value;
                    this.RaisePropertyChanged("IdAccount");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Status {
            get {
                return this.StatusField;
            }
            set {
                if ((object.ReferenceEquals(this.StatusField, value) != true)) {
                    this.StatusField = value;
                    this.RaisePropertyChanged("Status");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Ukmid {
            get {
                return this.UkmidField;
            }
            set {
                if ((object.ReferenceEquals(this.UkmidField, value) != true)) {
                    this.UkmidField = value;
                    this.RaisePropertyChanged("Ukmid");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="Coach", Namespace="http://schemas.datacontract.org/2004/07/UKMService")]
    [System.SerializableAttribute()]
    public partial class Coach : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string AddressField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string GenderField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PhoneField;
        
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
        public string Address {
            get {
                return this.AddressField;
            }
            set {
                if ((object.ReferenceEquals(this.AddressField, value) != true)) {
                    this.AddressField = value;
                    this.RaisePropertyChanged("Address");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Gender {
            get {
                return this.GenderField;
            }
            set {
                if ((object.ReferenceEquals(this.GenderField, value) != true)) {
                    this.GenderField = value;
                    this.RaisePropertyChanged("Gender");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Id {
            get {
                return this.IdField;
            }
            set {
                if ((object.ReferenceEquals(this.IdField, value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Phone {
            get {
                return this.PhoneField;
            }
            set {
                if ((object.ReferenceEquals(this.PhoneField, value) != true)) {
                    this.PhoneField = value;
                    this.RaisePropertyChanged("Phone");
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
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceCoach.IService1")]
    public interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/doLoginAdmin", ReplyAction="http://tempuri.org/IService1/doLoginAdminResponse")]
        int doLoginAdmin(string username, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/doDeleteAdmin", ReplyAction="http://tempuri.org/IService1/doDeleteAdminResponse")]
        int doDeleteAdmin(string id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/doUpdateAdmin", ReplyAction="http://tempuri.org/IService1/doUpdateAdminResponse")]
        int doUpdateAdmin(UKM.ServiceCoach.Account acc);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/convertukm", ReplyAction="http://tempuri.org/IService1/convertukmResponse")]
        string convertukm(string ukm);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetCaptain", ReplyAction="http://tempuri.org/IService1/GetCaptainResponse")]
        UKM.ServiceCoach.Account[] GetCaptain(string Name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/doInsertCaptainAdmin", ReplyAction="http://tempuri.org/IService1/doInsertCaptainAdminResponse")]
        int doInsertCaptainAdmin(UKM.ServiceCoach.Account acc, UKM.ServiceCoach.StudentUKM ukm);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/doDeleteCoach", ReplyAction="http://tempuri.org/IService1/doDeleteCoachResponse")]
        int doDeleteCoach(string id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/doUpdateCoach", ReplyAction="http://tempuri.org/IService1/doUpdateCoachResponse")]
        int doUpdateCoach(UKM.ServiceCoach.Coach acc);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetCoach", ReplyAction="http://tempuri.org/IService1/GetCoachResponse")]
        UKM.ServiceCoach.Coach[] GetCoach(string Name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/doInsertCoach", ReplyAction="http://tempuri.org/IService1/doInsertCoachResponse")]
        int doInsertCoach(UKM.ServiceCoach.Coach acc);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : UKM.ServiceCoach.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<UKM.ServiceCoach.IService1>, UKM.ServiceCoach.IService1 {
        
        public Service1Client() {
        }
        
        public Service1Client(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Service1Client(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public int doLoginAdmin(string username, string password) {
            return base.Channel.doLoginAdmin(username, password);
        }
        
        public int doDeleteAdmin(string id) {
            return base.Channel.doDeleteAdmin(id);
        }
        
        public int doUpdateAdmin(UKM.ServiceCoach.Account acc) {
            return base.Channel.doUpdateAdmin(acc);
        }
        
        public string convertukm(string ukm) {
            return base.Channel.convertukm(ukm);
        }
        
        public UKM.ServiceCoach.Account[] GetCaptain(string Name) {
            return base.Channel.GetCaptain(Name);
        }
        
        public int doInsertCaptainAdmin(UKM.ServiceCoach.Account acc, UKM.ServiceCoach.StudentUKM ukm) {
            return base.Channel.doInsertCaptainAdmin(acc, ukm);
        }
        
        public int doDeleteCoach(string id) {
            return base.Channel.doDeleteCoach(id);
        }
        
        public int doUpdateCoach(UKM.ServiceCoach.Coach acc) {
            return base.Channel.doUpdateCoach(acc);
        }
        
        public UKM.ServiceCoach.Coach[] GetCoach(string Name) {
            return base.Channel.GetCoach(Name);
        }
        
        public int doInsertCoach(UKM.ServiceCoach.Coach acc) {
            return base.Channel.doInsertCoach(acc);
        }
    }
}
