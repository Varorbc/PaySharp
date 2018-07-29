using System;
using System.Collections.Generic;
using Aop.Api.Response;
using Aop.Api.Util;

namespace Aop.Api.Request
{
    /// <summary>
    /// AOP API: alipay.open.agent.mini.create
    /// </summary>
    public class AlipayOpenAgentMiniCreateRequest : IAopUploadRequest<AlipayOpenAgentMiniCreateResponse>
    {
        /// <summary>
        /// 小程序应用类目，参数格式：一级类目_二级类目。  应用类目参考文档：https://docs.alipay.com/isv/10325
        /// </summary>
        public string AppCategoryIds { get; set; }

        /// <summary>
        /// 商户小程序描述信息，简要描述小程序主要功能（20-500个字），例：xx小程序提供了xx功能，主要解决了XX问题。
        /// </summary>
        public string AppDesc { get; set; }

        /// <summary>
        /// 小程序英文名称，长度3~20个字符
        /// </summary>
        public string AppEnglishName { get; set; }

        /// <summary>
        /// 商户小程序应用图标，最大256KB，LOGO不允许涉及政治敏感与色情；图片格式必须为：png、jpeg、jpg，建议上传像素为180*180，LOGO核心图形建议在白色160PX范围内
        /// </summary>
        public FileItem AppLogo { get; set; }

        /// <summary>
        /// 代商户创建的小程序应用名称。名称可以由中文、数字、英文及下划线组成，长度在3-20个字符之间，一个中文字等于2个字符，更多名称规则见：https://docs.alipay.com/mini/operation/name
        /// </summary>
        public string AppName { get; set; }

        /// <summary>
        /// 代商户创建的小程序的简介，请用一句话简要描述小程序提供的服务；应用上架后一个自然月可修改5次（10~32个字符）
        /// </summary>
        public string AppSlogan { get; set; }

        /// <summary>
        /// ISV 代商户操作事务编号，通过事务开启接口alipay.open.agent.create调用返回。
        /// </summary>
        public string BatchNo { get; set; }

        /// <summary>
        /// 商户小程序客服邮箱  商户小程序客服电话和邮箱，可以二选一填写，但不能同时为空
        /// </summary>
        public string ServiceEmail { get; set; }

        /// <summary>
        /// 商户小程序的客服电话，推荐填写  商户小程序客服电话和邮箱，可以二选一填写，但不能同时为空
        /// </summary>
        public string ServicePhone { get; set; }

        #region IAopRequest Members
		private bool needEncrypt=false;
		private string apiVersion = "1.0";
		private string terminalType;
		private string terminalInfo;
        private string prodCode;
		private string notifyUrl;
        private string returnUrl;
		private AopObject bizModel;

    	 public void SetNeedEncrypt(bool needEncrypt){
             this.needEncrypt=needEncrypt;
        }

        public bool GetNeedEncrypt(){

            return this.needEncrypt;
        }

		public void SetNotifyUrl(string notifyUrl){
            this.notifyUrl = notifyUrl;
        }

        public string GetNotifyUrl(){
            return this.notifyUrl;
        }

        public void SetReturnUrl(string returnUrl){
            this.returnUrl = returnUrl;
        }

        public string GetReturnUrl(){
            return this.returnUrl;
        }

		public void SetTerminalType(String terminalType){
			this.terminalType=terminalType;
		}

    	public string GetTerminalType(){
    		return this.terminalType;
    	}

    	public void SetTerminalInfo(String terminalInfo){
    		this.terminalInfo=terminalInfo;
    	}

    	public string GetTerminalInfo(){
    		return this.terminalInfo;
    	}

        public void SetProdCode(String prodCode){
            this.prodCode=prodCode;
        }

        public string GetProdCode(){
            return this.prodCode;
        }

		public void SetApiVersion(string apiVersion){
            this.apiVersion=apiVersion;
        }

        public string GetApiVersion(){
            return this.apiVersion;
        }

        public string GetApiName()
        {
            return "alipay.open.agent.mini.create";
        }

        public IDictionary<string, string> GetParameters()
        {
            AopDictionary parameters = new AopDictionary();
            parameters.Add("app_category_ids", this.AppCategoryIds);
            parameters.Add("app_desc", this.AppDesc);
            parameters.Add("app_english_name", this.AppEnglishName);
            parameters.Add("app_name", this.AppName);
            parameters.Add("app_slogan", this.AppSlogan);
            parameters.Add("batch_no", this.BatchNo);
            parameters.Add("service_email", this.ServiceEmail);
            parameters.Add("service_phone", this.ServicePhone);
            return parameters;
        }
		
		public AopObject GetBizModel()
        {
            return this.bizModel;
        }

        public void SetBizModel(AopObject bizModel)
        {
            this.bizModel = bizModel;
        }

        #endregion

        #region IAopUploadRequest Members

        public IDictionary<string, FileItem> GetFileParameters()
        {
            IDictionary<string, FileItem> parameters = new Dictionary<string, FileItem>();
            parameters.Add("app_logo", this.AppLogo);
            return parameters;
        }

        #endregion
    }
}
