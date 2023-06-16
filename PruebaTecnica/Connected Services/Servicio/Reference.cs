﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PruebaTecnica.Servicio {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Persona", Namespace="http://schemas.datacontract.org/2004/07/Services.Model")]
    [System.SerializableAttribute()]
    public partial class Persona : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime Fecha_NacimientoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NombreField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SexoField;
        
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
        public System.DateTime Fecha_Nacimiento {
            get {
                return this.Fecha_NacimientoField;
            }
            set {
                if ((this.Fecha_NacimientoField.Equals(value) != true)) {
                    this.Fecha_NacimientoField = value;
                    this.RaisePropertyChanged("Fecha_Nacimiento");
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
        public string Nombre {
            get {
                return this.NombreField;
            }
            set {
                if ((object.ReferenceEquals(this.NombreField, value) != true)) {
                    this.NombreField = value;
                    this.RaisePropertyChanged("Nombre");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Sexo {
            get {
                return this.SexoField;
            }
            set {
                if ((object.ReferenceEquals(this.SexoField, value) != true)) {
                    this.SexoField = value;
                    this.RaisePropertyChanged("Sexo");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="Servicio.IService1")]
    public interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Consultar", ReplyAction="http://tempuri.org/IService1/ConsultarResponse")]
        PruebaTecnica.Servicio.Persona[] Consultar();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Consultar", ReplyAction="http://tempuri.org/IService1/ConsultarResponse")]
        System.Threading.Tasks.Task<PruebaTecnica.Servicio.Persona[]> ConsultarAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Eliminar", ReplyAction="http://tempuri.org/IService1/EliminarResponse")]
        bool Eliminar(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Eliminar", ReplyAction="http://tempuri.org/IService1/EliminarResponse")]
        System.Threading.Tasks.Task<bool> EliminarAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Adicionar", ReplyAction="http://tempuri.org/IService1/AdicionarResponse")]
        bool Adicionar(PruebaTecnica.Servicio.Persona persona);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Adicionar", ReplyAction="http://tempuri.org/IService1/AdicionarResponse")]
        System.Threading.Tasks.Task<bool> AdicionarAsync(PruebaTecnica.Servicio.Persona persona);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Actualizar", ReplyAction="http://tempuri.org/IService1/ActualizarResponse")]
        bool Actualizar(PruebaTecnica.Servicio.Persona persona);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Actualizar", ReplyAction="http://tempuri.org/IService1/ActualizarResponse")]
        System.Threading.Tasks.Task<bool> ActualizarAsync(PruebaTecnica.Servicio.Persona persona);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/ConsultarID", ReplyAction="http://tempuri.org/IService1/ConsultarIDResponse")]
        PruebaTecnica.Servicio.Persona ConsultarID(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/ConsultarID", ReplyAction="http://tempuri.org/IService1/ConsultarIDResponse")]
        System.Threading.Tasks.Task<PruebaTecnica.Servicio.Persona> ConsultarIDAsync(int id);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : PruebaTecnica.Servicio.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<PruebaTecnica.Servicio.IService1>, PruebaTecnica.Servicio.IService1 {
        
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
        
        public PruebaTecnica.Servicio.Persona[] Consultar() {
            return base.Channel.Consultar();
        }
        
        public System.Threading.Tasks.Task<PruebaTecnica.Servicio.Persona[]> ConsultarAsync() {
            return base.Channel.ConsultarAsync();
        }
        
        public bool Eliminar(int id) {
            return base.Channel.Eliminar(id);
        }
        
        public System.Threading.Tasks.Task<bool> EliminarAsync(int id) {
            return base.Channel.EliminarAsync(id);
        }
        
        public bool Adicionar(PruebaTecnica.Servicio.Persona persona) {
            return base.Channel.Adicionar(persona);
        }
        
        public System.Threading.Tasks.Task<bool> AdicionarAsync(PruebaTecnica.Servicio.Persona persona) {
            return base.Channel.AdicionarAsync(persona);
        }
        
        public bool Actualizar(PruebaTecnica.Servicio.Persona persona) {
            return base.Channel.Actualizar(persona);
        }
        
        public System.Threading.Tasks.Task<bool> ActualizarAsync(PruebaTecnica.Servicio.Persona persona) {
            return base.Channel.ActualizarAsync(persona);
        }
        
        public PruebaTecnica.Servicio.Persona ConsultarID(int id) {
            return base.Channel.ConsultarID(id);
        }
        
        public System.Threading.Tasks.Task<PruebaTecnica.Servicio.Persona> ConsultarIDAsync(int id) {
            return base.Channel.ConsultarIDAsync(id);
        }
    }
}
