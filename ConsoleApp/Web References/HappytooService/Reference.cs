﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:2.0.50727.3053
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

// 
// 此源代码是由 Microsoft.VSDesigner 2.0.50727.3053 版自动生成。
// 
#pragma warning disable 1591

namespace ConsoleApp.HappytooService {
    using System.Diagnostics;
    using System.Web.Services;
    using System.ComponentModel;
    using System.Web.Services.Protocols;
    using System;
    using System.Xml.Serialization;
    using System.Data;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.3053")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="LineSoap", Namespace="http://www.ws.happytoo.cn/")]
    public partial class Line : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback GetDataLineColumnOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetDataSetLineOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetDataSetLineRoteOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetDataSetLineViewOperationCompleted;
        
        private System.Threading.SendOrPostCallback OrderPostOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public Line() {
            this.Url = global::ConsoleApp.Properties.Settings.Default.ConsoleApp_HappytooService1_Line;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event GetDataLineColumnCompletedEventHandler GetDataLineColumnCompleted;
        
        /// <remarks/>
        public event GetDataSetLineCompletedEventHandler GetDataSetLineCompleted;
        
        /// <remarks/>
        public event GetDataSetLineRoteCompletedEventHandler GetDataSetLineRoteCompleted;
        
        /// <remarks/>
        public event GetDataSetLineViewCompletedEventHandler GetDataSetLineViewCompleted;
        
        /// <remarks/>
        public event OrderPostCompletedEventHandler OrderPostCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.ws.happytoo.cn/GetDataLineColumn", RequestNamespace="http://www.ws.happytoo.cn/", ResponseNamespace="http://www.ws.happytoo.cn/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Data.DataSet GetDataLineColumn(string Key, string ColumnCat) {
            object[] results = this.Invoke("GetDataLineColumn", new object[] {
                        Key,
                        ColumnCat});
            return ((System.Data.DataSet)(results[0]));
        }
        
        /// <remarks/>
        public void GetDataLineColumnAsync(string Key, string ColumnCat) {
            this.GetDataLineColumnAsync(Key, ColumnCat, null);
        }
        
        /// <remarks/>
        public void GetDataLineColumnAsync(string Key, string ColumnCat, object userState) {
            if ((this.GetDataLineColumnOperationCompleted == null)) {
                this.GetDataLineColumnOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetDataLineColumnOperationCompleted);
            }
            this.InvokeAsync("GetDataLineColumn", new object[] {
                        Key,
                        ColumnCat}, this.GetDataLineColumnOperationCompleted, userState);
        }
        
        private void OnGetDataLineColumnOperationCompleted(object arg) {
            if ((this.GetDataLineColumnCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetDataLineColumnCompleted(this, new GetDataLineColumnCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.ws.happytoo.cn/GetDataSetLine", RequestNamespace="http://www.ws.happytoo.cn/", ResponseNamespace="http://www.ws.happytoo.cn/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Data.DataSet GetDataSetLine(string Key, string Z_Id, string City, int State, int Page, int PageSize) {
            object[] results = this.Invoke("GetDataSetLine", new object[] {
                        Key,
                        Z_Id,
                        City,
                        State,
                        Page,
                        PageSize});
            return ((System.Data.DataSet)(results[0]));
        }
        
        /// <remarks/>
        public void GetDataSetLineAsync(string Key, string Z_Id, string City, int State, int Page, int PageSize) {
            this.GetDataSetLineAsync(Key, Z_Id, City, State, Page, PageSize, null);
        }
        
        /// <remarks/>
        public void GetDataSetLineAsync(string Key, string Z_Id, string City, int State, int Page, int PageSize, object userState) {
            if ((this.GetDataSetLineOperationCompleted == null)) {
                this.GetDataSetLineOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetDataSetLineOperationCompleted);
            }
            this.InvokeAsync("GetDataSetLine", new object[] {
                        Key,
                        Z_Id,
                        City,
                        State,
                        Page,
                        PageSize}, this.GetDataSetLineOperationCompleted, userState);
        }
        
        private void OnGetDataSetLineOperationCompleted(object arg) {
            if ((this.GetDataSetLineCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetDataSetLineCompleted(this, new GetDataSetLineCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.ws.happytoo.cn/GetDataSetLineRote", RequestNamespace="http://www.ws.happytoo.cn/", ResponseNamespace="http://www.ws.happytoo.cn/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Data.DataSet GetDataSetLineRote(string L_Id) {
            object[] results = this.Invoke("GetDataSetLineRote", new object[] {
                        L_Id});
            return ((System.Data.DataSet)(results[0]));
        }
        
        /// <remarks/>
        public void GetDataSetLineRoteAsync(string L_Id) {
            this.GetDataSetLineRoteAsync(L_Id, null);
        }
        
        /// <remarks/>
        public void GetDataSetLineRoteAsync(string L_Id, object userState) {
            if ((this.GetDataSetLineRoteOperationCompleted == null)) {
                this.GetDataSetLineRoteOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetDataSetLineRoteOperationCompleted);
            }
            this.InvokeAsync("GetDataSetLineRote", new object[] {
                        L_Id}, this.GetDataSetLineRoteOperationCompleted, userState);
        }
        
        private void OnGetDataSetLineRoteOperationCompleted(object arg) {
            if ((this.GetDataSetLineRoteCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetDataSetLineRoteCompleted(this, new GetDataSetLineRoteCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.ws.happytoo.cn/GetDataSetLineView", RequestNamespace="http://www.ws.happytoo.cn/", ResponseNamespace="http://www.ws.happytoo.cn/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Data.DataSet GetDataSetLineView(string Key, string L_Id) {
            object[] results = this.Invoke("GetDataSetLineView", new object[] {
                        Key,
                        L_Id});
            return ((System.Data.DataSet)(results[0]));
        }
        
        /// <remarks/>
        public void GetDataSetLineViewAsync(string Key, string L_Id) {
            this.GetDataSetLineViewAsync(Key, L_Id, null);
        }
        
        /// <remarks/>
        public void GetDataSetLineViewAsync(string Key, string L_Id, object userState) {
            if ((this.GetDataSetLineViewOperationCompleted == null)) {
                this.GetDataSetLineViewOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetDataSetLineViewOperationCompleted);
            }
            this.InvokeAsync("GetDataSetLineView", new object[] {
                        Key,
                        L_Id}, this.GetDataSetLineViewOperationCompleted, userState);
        }
        
        private void OnGetDataSetLineViewOperationCompleted(object arg) {
            if ((this.GetDataSetLineViewCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetDataSetLineViewCompleted(this, new GetDataSetLineViewCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.ws.happytoo.cn/OrderPost", RequestNamespace="http://www.ws.happytoo.cn/", ResponseNamespace="http://www.ws.happytoo.cn/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string OrderPost(string Key, string L_Id, string CrCount, string XhCount, string YCount, string Or_GuestInfo) {
            object[] results = this.Invoke("OrderPost", new object[] {
                        Key,
                        L_Id,
                        CrCount,
                        XhCount,
                        YCount,
                        Or_GuestInfo});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void OrderPostAsync(string Key, string L_Id, string CrCount, string XhCount, string YCount, string Or_GuestInfo) {
            this.OrderPostAsync(Key, L_Id, CrCount, XhCount, YCount, Or_GuestInfo, null);
        }
        
        /// <remarks/>
        public void OrderPostAsync(string Key, string L_Id, string CrCount, string XhCount, string YCount, string Or_GuestInfo, object userState) {
            if ((this.OrderPostOperationCompleted == null)) {
                this.OrderPostOperationCompleted = new System.Threading.SendOrPostCallback(this.OnOrderPostOperationCompleted);
            }
            this.InvokeAsync("OrderPost", new object[] {
                        Key,
                        L_Id,
                        CrCount,
                        XhCount,
                        YCount,
                        Or_GuestInfo}, this.OrderPostOperationCompleted, userState);
        }
        
        private void OnOrderPostOperationCompleted(object arg) {
            if ((this.OrderPostCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.OrderPostCompleted(this, new OrderPostCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.3053")]
    public delegate void GetDataLineColumnCompletedEventHandler(object sender, GetDataLineColumnCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.3053")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetDataLineColumnCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetDataLineColumnCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public System.Data.DataSet Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((System.Data.DataSet)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.3053")]
    public delegate void GetDataSetLineCompletedEventHandler(object sender, GetDataSetLineCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.3053")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetDataSetLineCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetDataSetLineCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public System.Data.DataSet Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((System.Data.DataSet)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.3053")]
    public delegate void GetDataSetLineRoteCompletedEventHandler(object sender, GetDataSetLineRoteCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.3053")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetDataSetLineRoteCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetDataSetLineRoteCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public System.Data.DataSet Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((System.Data.DataSet)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.3053")]
    public delegate void GetDataSetLineViewCompletedEventHandler(object sender, GetDataSetLineViewCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.3053")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetDataSetLineViewCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetDataSetLineViewCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public System.Data.DataSet Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((System.Data.DataSet)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.3053")]
    public delegate void OrderPostCompletedEventHandler(object sender, OrderPostCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.3053")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class OrderPostCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal OrderPostCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591