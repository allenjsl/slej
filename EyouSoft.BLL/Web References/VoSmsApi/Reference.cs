﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:2.0.50727.5472
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

// 
// 此源代码是由 Microsoft.VSDesigner 2.0.50727.5472 版自动生成。
// 
#pragma warning disable 1591

namespace EyouSoft.BLL.VoSmsApi {
    using System.Diagnostics;
    using System.Web.Services;
    using System.ComponentModel;
    using System.Web.Services.Protocols;
    using System;
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.5420")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="ServiceSoap", Namespace="http://tempuri.org/")]
    public partial class Service : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback SendOperationCompleted;
        
        private System.Threading.SendOrPostCallback SendSmsOperationCompleted;
        
        private System.Threading.SendOrPostCallback SendSms2OperationCompleted;
        
        private System.Threading.SendOrPostCallback SendSms3OperationCompleted;
        
        private System.Threading.SendOrPostCallback IsIncludeKeyWordOperationCompleted;
        
        private System.Threading.SendOrPostCallback QuerySMSLeftOperationCompleted;
        
        private System.Threading.SendOrPostCallback ChangePWdOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetMoOperationCompleted;
        
        private System.Threading.SendOrPostCallback SendSmsByFileOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public Service() {
            this.Url = global::EyouSoft.BLL.Properties.Settings.Default.EyouSoft_BLL_VoSmsApi_Service;
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
        public event SendCompletedEventHandler SendCompleted;
        
        /// <remarks/>
        public event SendSmsCompletedEventHandler SendSmsCompleted;
        
        /// <remarks/>
        public event SendSms2CompletedEventHandler SendSms2Completed;
        
        /// <remarks/>
        public event SendSms3CompletedEventHandler SendSms3Completed;
        
        /// <remarks/>
        public event IsIncludeKeyWordCompletedEventHandler IsIncludeKeyWordCompleted;
        
        /// <remarks/>
        public event QuerySMSLeftCompletedEventHandler QuerySMSLeftCompleted;
        
        /// <remarks/>
        public event ChangePWdCompletedEventHandler ChangePWdCompleted;
        
        /// <remarks/>
        public event GetMoCompletedEventHandler GetMoCompleted;
        
        /// <remarks/>
        public event SendSmsByFileCompletedEventHandler SendSmsByFileCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/Send", RequestNamespace="http://tempuri.org/send", ResponseElementName="arithmeticMeanResponse", ResponseNamespace="http://tempuri.org/send", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public int Send(string enterpriseid, string mobile, string content, string account, string pwd) {
            object[] results = this.Invoke("Send", new object[] {
                        enterpriseid,
                        mobile,
                        content,
                        account,
                        pwd});
            return ((int)(results[0]));
        }
        
        /// <remarks/>
        public void SendAsync(string enterpriseid, string mobile, string content, string account, string pwd) {
            this.SendAsync(enterpriseid, mobile, content, account, pwd, null);
        }
        
        /// <remarks/>
        public void SendAsync(string enterpriseid, string mobile, string content, string account, string pwd, object userState) {
            if ((this.SendOperationCompleted == null)) {
                this.SendOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSendOperationCompleted);
            }
            this.InvokeAsync("Send", new object[] {
                        enterpriseid,
                        mobile,
                        content,
                        account,
                        pwd}, this.SendOperationCompleted, userState);
        }
        
        private void OnSendOperationCompleted(object arg) {
            if ((this.SendCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.SendCompleted(this, new SendCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <summary>
        /// 返回0，发送成功
        /// </summary>
        /// <param name="enterpriseid"></param>
        /// <param name="mobile"></param>
        /// <param name="content"></param>
        /// <param name="account"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/SendSms", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public int SendSms(string enterpriseid, string mobile, string content, string account, string pwd) {
            object[] results = this.Invoke("SendSms", new object[] {
                        enterpriseid,
                        mobile,
                        content,
                        account,
                        pwd});
            return ((int)(results[0]));
        }
        
        /// <remarks/>
        public void SendSmsAsync(string enterpriseid, string mobile, string content, string account, string pwd) {
            this.SendSmsAsync(enterpriseid, mobile, content, account, pwd, null);
        }
        
        /// <remarks/>
        public void SendSmsAsync(string enterpriseid, string mobile, string content, string account, string pwd, object userState) {
            if ((this.SendSmsOperationCompleted == null)) {
                this.SendSmsOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSendSmsOperationCompleted);
            }
            this.InvokeAsync("SendSms", new object[] {
                        enterpriseid,
                        mobile,
                        content,
                        account,
                        pwd}, this.SendSmsOperationCompleted, userState);
        }
        
        private void OnSendSmsOperationCompleted(object arg) {
            if ((this.SendSmsCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.SendSmsCompleted(this, new SendSmsCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/SendSms2", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public int SendSms2(string enterpriseId, string mobile, string content, string account, string pwd, string subservicecode) {
            object[] results = this.Invoke("SendSms2", new object[] {
                        enterpriseId,
                        mobile,
                        content,
                        account,
                        pwd,
                        subservicecode});
            return ((int)(results[0]));
        }
        
        /// <remarks/>
        public void SendSms2Async(string enterpriseId, string mobile, string content, string account, string pwd, string subservicecode) {
            this.SendSms2Async(enterpriseId, mobile, content, account, pwd, subservicecode, null);
        }
        
        /// <remarks/>
        public void SendSms2Async(string enterpriseId, string mobile, string content, string account, string pwd, string subservicecode, object userState) {
            if ((this.SendSms2OperationCompleted == null)) {
                this.SendSms2OperationCompleted = new System.Threading.SendOrPostCallback(this.OnSendSms2OperationCompleted);
            }
            this.InvokeAsync("SendSms2", new object[] {
                        enterpriseId,
                        mobile,
                        content,
                        account,
                        pwd,
                        subservicecode}, this.SendSms2OperationCompleted, userState);
        }
        
        private void OnSendSms2OperationCompleted(object arg) {
            if ((this.SendSms2Completed != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.SendSms2Completed(this, new SendSms2CompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/SendSms3", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public int SendSms3(string enterpriseid, string subservicecode, string mobile, string content, string account, string pwd, string smsid) {
            object[] results = this.Invoke("SendSms3", new object[] {
                        enterpriseid,
                        subservicecode,
                        mobile,
                        content,
                        account,
                        pwd,
                        smsid});
            return ((int)(results[0]));
        }
        
        /// <remarks/>
        public void SendSms3Async(string enterpriseid, string subservicecode, string mobile, string content, string account, string pwd, string smsid) {
            this.SendSms3Async(enterpriseid, subservicecode, mobile, content, account, pwd, smsid, null);
        }
        
        /// <remarks/>
        public void SendSms3Async(string enterpriseid, string subservicecode, string mobile, string content, string account, string pwd, string smsid, object userState) {
            if ((this.SendSms3OperationCompleted == null)) {
                this.SendSms3OperationCompleted = new System.Threading.SendOrPostCallback(this.OnSendSms3OperationCompleted);
            }
            this.InvokeAsync("SendSms3", new object[] {
                        enterpriseid,
                        subservicecode,
                        mobile,
                        content,
                        account,
                        pwd,
                        smsid}, this.SendSms3OperationCompleted, userState);
        }
        
        private void OnSendSms3OperationCompleted(object arg) {
            if ((this.SendSms3Completed != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.SendSms3Completed(this, new SendSms3CompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/IsIncludeKeyWord", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string IsIncludeKeyWord(string content) {
            object[] results = this.Invoke("IsIncludeKeyWord", new object[] {
                        content});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void IsIncludeKeyWordAsync(string content) {
            this.IsIncludeKeyWordAsync(content, null);
        }
        
        /// <remarks/>
        public void IsIncludeKeyWordAsync(string content, object userState) {
            if ((this.IsIncludeKeyWordOperationCompleted == null)) {
                this.IsIncludeKeyWordOperationCompleted = new System.Threading.SendOrPostCallback(this.OnIsIncludeKeyWordOperationCompleted);
            }
            this.InvokeAsync("IsIncludeKeyWord", new object[] {
                        content}, this.IsIncludeKeyWordOperationCompleted, userState);
        }
        
        private void OnIsIncludeKeyWordOperationCompleted(object arg) {
            if ((this.IsIncludeKeyWordCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.IsIncludeKeyWordCompleted(this, new IsIncludeKeyWordCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/QuerySMSLeft", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public int QuerySMSLeft(string enterpriseid, string account, string pwd) {
            object[] results = this.Invoke("QuerySMSLeft", new object[] {
                        enterpriseid,
                        account,
                        pwd});
            return ((int)(results[0]));
        }
        
        /// <remarks/>
        public void QuerySMSLeftAsync(string enterpriseid, string account, string pwd) {
            this.QuerySMSLeftAsync(enterpriseid, account, pwd, null);
        }
        
        /// <remarks/>
        public void QuerySMSLeftAsync(string enterpriseid, string account, string pwd, object userState) {
            if ((this.QuerySMSLeftOperationCompleted == null)) {
                this.QuerySMSLeftOperationCompleted = new System.Threading.SendOrPostCallback(this.OnQuerySMSLeftOperationCompleted);
            }
            this.InvokeAsync("QuerySMSLeft", new object[] {
                        enterpriseid,
                        account,
                        pwd}, this.QuerySMSLeftOperationCompleted, userState);
        }
        
        private void OnQuerySMSLeftOperationCompleted(object arg) {
            if ((this.QuerySMSLeftCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.QuerySMSLeftCompleted(this, new QuerySMSLeftCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/ChangePWd", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public int ChangePWd(string enterpriseid, string account, string oldpwd, string newpwd) {
            object[] results = this.Invoke("ChangePWd", new object[] {
                        enterpriseid,
                        account,
                        oldpwd,
                        newpwd});
            return ((int)(results[0]));
        }
        
        /// <remarks/>
        public void ChangePWdAsync(string enterpriseid, string account, string oldpwd, string newpwd) {
            this.ChangePWdAsync(enterpriseid, account, oldpwd, newpwd, null);
        }
        
        /// <remarks/>
        public void ChangePWdAsync(string enterpriseid, string account, string oldpwd, string newpwd, object userState) {
            if ((this.ChangePWdOperationCompleted == null)) {
                this.ChangePWdOperationCompleted = new System.Threading.SendOrPostCallback(this.OnChangePWdOperationCompleted);
            }
            this.InvokeAsync("ChangePWd", new object[] {
                        enterpriseid,
                        account,
                        oldpwd,
                        newpwd}, this.ChangePWdOperationCompleted, userState);
        }
        
        private void OnChangePWdOperationCompleted(object arg) {
            if ((this.ChangePWdCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ChangePWdCompleted(this, new ChangePWdCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetMo", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string GetMo(string enterpriseid) {
            object[] results = this.Invoke("GetMo", new object[] {
                        enterpriseid});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void GetMoAsync(string enterpriseid) {
            this.GetMoAsync(enterpriseid, null);
        }
        
        /// <remarks/>
        public void GetMoAsync(string enterpriseid, object userState) {
            if ((this.GetMoOperationCompleted == null)) {
                this.GetMoOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetMoOperationCompleted);
            }
            this.InvokeAsync("GetMo", new object[] {
                        enterpriseid}, this.GetMoOperationCompleted, userState);
        }
        
        private void OnGetMoOperationCompleted(object arg) {
            if ((this.GetMoCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetMoCompleted(this, new GetMoCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/SendSmsByFile", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string SendSmsByFile(string enterpriseid, string account, string pwd, [System.Xml.Serialization.XmlElementAttribute(DataType="base64Binary")] byte[] fileContent, string content) {
            object[] results = this.Invoke("SendSmsByFile", new object[] {
                        enterpriseid,
                        account,
                        pwd,
                        fileContent,
                        content});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void SendSmsByFileAsync(string enterpriseid, string account, string pwd, byte[] fileContent, string content) {
            this.SendSmsByFileAsync(enterpriseid, account, pwd, fileContent, content, null);
        }
        
        /// <remarks/>
        public void SendSmsByFileAsync(string enterpriseid, string account, string pwd, byte[] fileContent, string content, object userState) {
            if ((this.SendSmsByFileOperationCompleted == null)) {
                this.SendSmsByFileOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSendSmsByFileOperationCompleted);
            }
            this.InvokeAsync("SendSmsByFile", new object[] {
                        enterpriseid,
                        account,
                        pwd,
                        fileContent,
                        content}, this.SendSmsByFileOperationCompleted, userState);
        }
        
        private void OnSendSmsByFileOperationCompleted(object arg) {
            if ((this.SendSmsByFileCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.SendSmsByFileCompleted(this, new SendSmsByFileCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.5420")]
    public delegate void SendCompletedEventHandler(object sender, SendCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.5420")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class SendCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal SendCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public int Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((int)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.5420")]
    public delegate void SendSmsCompletedEventHandler(object sender, SendSmsCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.5420")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class SendSmsCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal SendSmsCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public int Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((int)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.5420")]
    public delegate void SendSms2CompletedEventHandler(object sender, SendSms2CompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.5420")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class SendSms2CompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal SendSms2CompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public int Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((int)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.5420")]
    public delegate void SendSms3CompletedEventHandler(object sender, SendSms3CompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.5420")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class SendSms3CompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal SendSms3CompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public int Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((int)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.5420")]
    public delegate void IsIncludeKeyWordCompletedEventHandler(object sender, IsIncludeKeyWordCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.5420")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class IsIncludeKeyWordCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal IsIncludeKeyWordCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.5420")]
    public delegate void QuerySMSLeftCompletedEventHandler(object sender, QuerySMSLeftCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.5420")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class QuerySMSLeftCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal QuerySMSLeftCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public int Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((int)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.5420")]
    public delegate void ChangePWdCompletedEventHandler(object sender, ChangePWdCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.5420")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ChangePWdCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ChangePWdCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public int Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((int)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.5420")]
    public delegate void GetMoCompletedEventHandler(object sender, GetMoCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.5420")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetMoCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetMoCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.5420")]
    public delegate void SendSmsByFileCompletedEventHandler(object sender, SendSmsByFileCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.5420")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class SendSmsByFileCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal SendSmsByFileCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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