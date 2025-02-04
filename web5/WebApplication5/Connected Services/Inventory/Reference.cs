﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication5.Inventory {
    using System.Data;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="Inventory.InventorySoap")]
    public interface InventorySoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/AddInventory", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        bool AddInventory(int inventoryId, string sName, string pName, int pNo, int sale_Price, int quantity, string discount, int total_Price, string expire_Date);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/AddInventory", ReplyAction="*")]
        System.Threading.Tasks.Task<bool> AddInventoryAsync(int inventoryId, string sName, string pName, int pNo, int sale_Price, int quantity, string discount, int total_Price, string expire_Date);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ViewAllInventories", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataTable ViewAllInventories();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ViewAllInventories", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataTable> ViewAllInventoriesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/UpdateInventory", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        bool UpdateInventory(int inventoryId, string sName, string pName, int pNo, int sale_Price, int quantity, string discount, int total_price, string expire_Date);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/UpdateInventory", ReplyAction="*")]
        System.Threading.Tasks.Task<bool> UpdateInventoryAsync(int inventoryId, string sName, string pName, int pNo, int sale_Price, int quantity, string discount, int total_price, string expire_Date);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface InventorySoapChannel : WebApplication5.Inventory.InventorySoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class InventorySoapClient : System.ServiceModel.ClientBase<WebApplication5.Inventory.InventorySoap>, WebApplication5.Inventory.InventorySoap {
        
        public InventorySoapClient() {
        }
        
        public InventorySoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public InventorySoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public InventorySoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public InventorySoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public bool AddInventory(int inventoryId, string sName, string pName, int pNo, int sale_Price, int quantity, string discount, int total_Price, string expire_Date) {
            return base.Channel.AddInventory(inventoryId, sName, pName, pNo, sale_Price, quantity, discount, total_Price, expire_Date);
        }
        
        public System.Threading.Tasks.Task<bool> AddInventoryAsync(int inventoryId, string sName, string pName, int pNo, int sale_Price, int quantity, string discount, int total_Price, string expire_Date) {
            return base.Channel.AddInventoryAsync(inventoryId, sName, pName, pNo, sale_Price, quantity, discount, total_Price, expire_Date);
        }
        
        public System.Data.DataTable ViewAllInventories() {
            return base.Channel.ViewAllInventories();
        }
        
        public System.Threading.Tasks.Task<System.Data.DataTable> ViewAllInventoriesAsync() {
            return base.Channel.ViewAllInventoriesAsync();
        }
        
        public bool UpdateInventory(int inventoryId, string sName, string pName, int pNo, int sale_Price, int quantity, string discount, int total_price, string expire_Date) {
            return base.Channel.UpdateInventory(inventoryId, sName, pName, pNo, sale_Price, quantity, discount, total_price, expire_Date);
        }
        
        public System.Threading.Tasks.Task<bool> UpdateInventoryAsync(int inventoryId, string sName, string pName, int pNo, int sale_Price, int quantity, string discount, int total_price, string expire_Date) {
            return base.Channel.UpdateInventoryAsync(inventoryId, sName, pName, pNo, sale_Price, quantity, discount, total_price, expire_Date);
        }
    }
}
