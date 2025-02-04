﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication5.Order {
    using System.Data;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="Order.OrderSoap")]
    public interface OrderSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/AddOrder", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        bool AddOrder(int orderId, string sName, string pName, int pNo, int purchase_Price, int quantity, string discount, int total_Price, string pMethod);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/AddOrder", ReplyAction="*")]
        System.Threading.Tasks.Task<bool> AddOrderAsync(int orderId, string sName, string pName, int pNo, int purchase_Price, int quantity, string discount, int total_Price, string pMethod);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ViewAllOrders", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataTable ViewAllOrders();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ViewAllOrders", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataTable> ViewAllOrdersAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/UpdateOrder", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        bool UpdateOrder(int orderId, string sName, string pName, int pNo, int purchase_Price, int quantity, string discount, int total_Price, string pMethod);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/UpdateOrder", ReplyAction="*")]
        System.Threading.Tasks.Task<bool> UpdateOrderAsync(int orderId, string sName, string pName, int pNo, int purchase_Price, int quantity, string discount, int total_Price, string pMethod);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/DeleteOrder", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        bool DeleteOrder(int orderId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/DeleteOrder", ReplyAction="*")]
        System.Threading.Tasks.Task<bool> DeleteOrderAsync(int orderId);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface OrderSoapChannel : WebApplication5.Order.OrderSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class OrderSoapClient : System.ServiceModel.ClientBase<WebApplication5.Order.OrderSoap>, WebApplication5.Order.OrderSoap {
        
        public OrderSoapClient() {
        }
        
        public OrderSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public OrderSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public OrderSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public OrderSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public bool AddOrder(int orderId, string sName, string pName, int pNo, int purchase_Price, int quantity, string discount, int total_Price, string pMethod) {
            return base.Channel.AddOrder(orderId, sName, pName, pNo, purchase_Price, quantity, discount, total_Price, pMethod);
        }
        
        public System.Threading.Tasks.Task<bool> AddOrderAsync(int orderId, string sName, string pName, int pNo, int purchase_Price, int quantity, string discount, int total_Price, string pMethod) {
            return base.Channel.AddOrderAsync(orderId, sName, pName, pNo, purchase_Price, quantity, discount, total_Price, pMethod);
        }
        
        public System.Data.DataTable ViewAllOrders() {
            return base.Channel.ViewAllOrders();
        }
        
        public System.Threading.Tasks.Task<System.Data.DataTable> ViewAllOrdersAsync() {
            return base.Channel.ViewAllOrdersAsync();
        }
        
        public bool UpdateOrder(int orderId, string sName, string pName, int pNo, int purchase_Price, int quantity, string discount, int total_Price, string pMethod) {
            return base.Channel.UpdateOrder(orderId, sName, pName, pNo, purchase_Price, quantity, discount, total_Price, pMethod);
        }
        
        public System.Threading.Tasks.Task<bool> UpdateOrderAsync(int orderId, string sName, string pName, int pNo, int purchase_Price, int quantity, string discount, int total_Price, string pMethod) {
            return base.Channel.UpdateOrderAsync(orderId, sName, pName, pNo, purchase_Price, quantity, discount, total_Price, pMethod);
        }
        
        public bool DeleteOrder(int orderId) {
            return base.Channel.DeleteOrder(orderId);
        }
        
        public System.Threading.Tasks.Task<bool> DeleteOrderAsync(int orderId) {
            return base.Channel.DeleteOrderAsync(orderId);
        }
    }
}
