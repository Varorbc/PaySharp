using System;
using System.Collections;
using System.Text;
using System.Web;

namespace tenpay
{
	/// <summary>
	/// RequestHandler 的摘要说明。
	/// </summary>
	public class RequestHandler
	{
		public RequestHandler(HttpContext httpContext)
		{
			parameters = new Hashtable();

			this.httpContext = httpContext;

			this.setGateUrl("https://www.tenpay.com/cgi-bin/v1.0/service_gate.cgi");
		}

		/** 网关url地址 */
		private string gateUrl;
		
		/** 密钥 */
		private string key;
		
		/** 请求的参数 */
		protected Hashtable parameters;
		
		/** debug信息 */
		private string debugInfo;

		protected HttpContext httpContext;
		
		/** 初始化函数。*/
		public virtual void init() 
		{
			//nothing to do
		}

		/** 获取入口地址,不包含参数值 */
		public String getGateUrl() 
		{
			return gateUrl;
		}

		/** 设置入口地址,不包含参数值 */
		public void setGateUrl(String gateUrl) 
		{
			this.gateUrl = gateUrl;
		}

		/** 获取密钥 */
		public String getKey() 
		{
			return key;
		}

		/** 设置密钥 */
		public void setKey(string key) 
		{
			this.key = key;
		}

		/** 获取带参数的请求URL  @return String */
		public virtual string getRequestURL()
		{
			this.createSign();

			StringBuilder sb = new StringBuilder();
			ArrayList akeys=new ArrayList(parameters.Keys); 
			akeys.Sort();
			foreach(string k in akeys)
			{
				string v = (string)parameters[k];
                if (null != v && "key".CompareTo(k) != 0 && "spbill_create_ip".CompareTo(k)!=0) 
				{
					sb.Append(k + "=" + TenpayUtil.UrlEncode(v, getCharset()) + "&");
				} else if("spbill_create_ip".CompareTo(k) == 0){
					sb.Append(k + "=" + v.Replace(".", "%2E") + "&");
                    
				}
			}

			//去掉最后一个&
			if(sb.Length > 0)
			{
				sb.Remove(sb.Length-1, 1);
			}
							
			return this.getGateUrl() + "?" + sb.ToString();
		}

		/**
		* 创建md5摘要,规则是:按参数名称a-z排序,遇到空值的参数不参加签名。
		*/
		protected virtual void createSign() 
		{
			StringBuilder sb = new StringBuilder();

			ArrayList akeys=new ArrayList(parameters.Keys); 
			akeys.Sort();

			foreach(string k in akeys)
			{
				string v = (string)parameters[k];
				if(null != v && "".CompareTo(v) != 0
					&& "sign".CompareTo(k) != 0 && "key".CompareTo(k) != 0) 
				{
					sb.Append(k + "=" + v + "&");
				}
			}

			sb.Append("key=" + this.getKey());
			string sign = MD5Util.GetMD5(sb.ToString(), getCharset()).ToLower();
		
			this.setParameter("sign", sign);
		
			//debug信息
			this.setDebugInfo(sb.ToString() + " => sign:" + sign);		
		}

		/** 获取参数值 */
		public string getParameter(string parameter) 
		{
			string s = (string)parameters[parameter];
			return (null == s) ? "" : s;
		}

		/** 设置参数值 */
		public void setParameter(string parameter,string parameterValue) 
		{
			if(parameter != null && parameter != "")
			{
				if(parameters.Contains(parameter))
				{
					parameters.Remove(parameter);
				}
	
				parameters.Add(parameter,parameterValue);		
			}
		}

		public void doSend()
		{
			this.httpContext.Response.Redirect(this.getRequestURL());
		}
			
		/** 获取debug信息 */
		public String getDebugInfo() 
		{
			return debugInfo;
		}

		/** 设置debug信息 */
		public void setDebugInfo(String debugInfo) 
		{
			this.debugInfo = debugInfo;
		}

		public Hashtable getAllParameters()
		{
			return this.parameters;
		}

		protected virtual string getCharset()
		{
			return this.httpContext.Request.ContentEncoding.BodyName;
		}
	}
}
