﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClienteWCF.ServicoWCF {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Produto", Namespace="http://schemas.datacontract.org/2004/07/ExemploServicoWCF")]
    [System.SerializableAttribute()]
    public partial class Produto : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string nomeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private decimal precoField;
        
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
        public string nome {
            get {
                return this.nomeField;
            }
            set {
                if ((object.ReferenceEquals(this.nomeField, value) != true)) {
                    this.nomeField = value;
                    this.RaisePropertyChanged("nome");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public decimal preco {
            get {
                return this.precoField;
            }
            set {
                if ((this.precoField.Equals(value) != true)) {
                    this.precoField = value;
                    this.RaisePropertyChanged("preco");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServicoWCF.IServico01")]
    public interface IServico01 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServico01/DoWork", ReplyAction="http://tempuri.org/IServico01/DoWorkResponse")]
        string DoWork();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServico01/DoWork", ReplyAction="http://tempuri.org/IServico01/DoWorkResponse")]
        System.Threading.Tasks.Task<string> DoWorkAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServico01/PromocaoDia", ReplyAction="http://tempuri.org/IServico01/PromocaoDiaResponse")]
        ClienteWCF.ServicoWCF.Produto PromocaoDia();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServico01/PromocaoDia", ReplyAction="http://tempuri.org/IServico01/PromocaoDiaResponse")]
        System.Threading.Tasks.Task<ClienteWCF.ServicoWCF.Produto> PromocaoDiaAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServico01Channel : ClienteWCF.ServicoWCF.IServico01, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Servico01Client : System.ServiceModel.ClientBase<ClienteWCF.ServicoWCF.IServico01>, ClienteWCF.ServicoWCF.IServico01 {
        
        public Servico01Client() {
        }
        
        public Servico01Client(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Servico01Client(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Servico01Client(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Servico01Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string DoWork() {
            return base.Channel.DoWork();
        }
        
        public System.Threading.Tasks.Task<string> DoWorkAsync() {
            return base.Channel.DoWorkAsync();
        }
        
        public ClienteWCF.ServicoWCF.Produto PromocaoDia() {
            return base.Channel.PromocaoDia();
        }
        
        public System.Threading.Tasks.Task<ClienteWCF.ServicoWCF.Produto> PromocaoDiaAsync() {
            return base.Channel.PromocaoDiaAsync();
        }
    }
}
