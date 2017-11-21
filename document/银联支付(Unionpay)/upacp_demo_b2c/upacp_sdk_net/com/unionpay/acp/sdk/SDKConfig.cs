using System.Web.Configuration;
using System.Configuration;
using System.Collections;
using log4net;

namespace com.unionpay.acp.sdk
{

    public class SDKConfig
    {
        private static string signCertPath;// = config.AppSettings.Settings["acpsdk.signCert.path"].Value;  //功能：读取配置文件获取签名证书路径
        private static string signCertPwd;// = config.AppSettings.Settings["acpsdk.signCert.pwd"].Value;//功能：读取配置文件获取签名证书密码
        private static string validateCertDir;// = config.AppSettings.Settings["acpsdk.validateCert.dir"].Value;//功能：读取配置文件获取验签目录
        private static string encryptCert;// = config.AppSettings.Settings["acpsdk.encryptCert.path"].Value;  //功能：加密公钥证书路径

        private static string cardRequestUrl;// = config.AppSettings.Settings["acpsdk.cardRequestUrl"].Value;  //功能：有卡交易路径;
        private static string appRequestUrl;// = config.AppSettings.Settings["acpsdk.appRequestUrl"].Value;  //功能：appj交易路径;
        private static string singleQueryUrl;// = config.AppSettings.Settings["acpsdk.singleQueryUrl"].Value; //功能：读取配置文件获取交易查询地址
        private static string fileTransUrl;// = config.AppSettings.Settings["acpsdk.fileTransUrl"].Value;  //功能：读取配置文件获取文件传输类交易地址
        private static string frontTransUrl;// = config.AppSettings.Settings["acpsdk.frontTransUrl"].Value; //功能：读取配置文件获取前台交易地址
        private static string backTransUrl;// = config.AppSettings.Settings["acpsdk.backTransUrl"].Value;//功能：读取配置文件获取后台交易地址
        private static string batTransUrl;// = config.AppSettings.Settings["acpsdk.batTransUrl"].Value;//功能：读取配批量交易地址

        private static string frontUrl;// = config.AppSettings.Settings["acpsdk.frontUrl"].Value;//功能：读取配置文件获取前台通知地址
        private static string backUrl;// = config.AppSettings.Settings["acpsdk.backUrl"].Value;//功能：读取配置文件获取前台通知地址

        private static string jfCardRequestUrl;// = config.AppSettings.Settings["acpsdk.jf.cardRequestUrl"].Value;  //功能：缴费产品有卡交易路径;
        private static string jfAppRequestUrl;// = config.AppSettings.Settings["acpsdk.jf.appRequestUrl"].Value;  //功能：缴费产品app交易路径;
        private static string jfSingleQueryUrl;// = config.AppSettings.Settings["acpsdk.jf.singleQueryUrl"].Value; //功能：读取配置文件获取缴费产品交易查询地址
        private static string jfFrontTransUrl;// = config.AppSettings.Settings["acpsdk.jf.frontTransUrl"].Value; //功能：读取配置文件获取缴费产品前台交易地址
        private static string jfBackTransUrl;// = config.AppSettings.Settings["acpsdk.jf.backTransUrl"].Value;//功能：读取配置文件获取缴费产品后台交易地址

        private static string ifValidateRemoteCert = "false";// = config.AppSettings.Settings["acpsdk.ifValidateRemoteCert"].Value;//功能：是否验证后台https证书
        private static string ifValidateCNName = "true";// = config.AppSettings.Settings["acpsdk.ifValidateCNName"].Value;//功能：是否验证证书cn
        private static string middleCertPath;// = config.AppSettings.Settings["acpsdk.middleCert.path"].Value;//功能：中级证书路径
        private static string rootCertPath;// = config.AppSettings.Settings["acpsdk.rootCert.path"].Value;//功能：根证书路径
        private static string secureKey;// = config.AppSettings.Settings["acpsdk.secureKey"].Value;//功能：散列方式签名密钥
        private static string signMethod = "01";// = config.AppSettings.Settings["acpsdk.signMethod"].Value;//功能：指定signMethod
        private static string version = "5.0.0";//功能：指定version

        private static readonly ILog log = LogManager.GetLogger(typeof(AcpService));
        static SDKConfig()
        {
            Configuration config = WebConfigurationManager.OpenWebConfiguration("~");
            IList keys = config.AppSettings.Settings.AllKeys;
            
            if (keys.Contains("acpsdk.signCert.path"))
                signCertPath = config.AppSettings.Settings["acpsdk.signCert.path"].Value;  //功能：读取配置文件获取签名证书路径
            if (keys.Contains("acpsdk.signCert.pwd"))
                signCertPwd = config.AppSettings.Settings["acpsdk.signCert.pwd"].Value;//功能：读取配置文件获取签名证书密码
            if (keys.Contains("acpsdk.validateCert.dir"))
                validateCertDir = config.AppSettings.Settings["acpsdk.validateCert.dir"].Value;//功能：读取配置文件获取验签目录
            if (keys.Contains("acpsdk.encryptCert.path"))
                encryptCert = config.AppSettings.Settings["acpsdk.encryptCert.path"].Value;  //功能：加密公钥证书路径

            if (keys.Contains("acpsdk.cardRequestUrl"))
                cardRequestUrl = config.AppSettings.Settings["acpsdk.cardRequestUrl"].Value;  //功能：有卡交易路径;
            if (keys.Contains("acpsdk.appRequestUrl"))
                appRequestUrl = config.AppSettings.Settings["acpsdk.appRequestUrl"].Value;  //功能：appj交易路径;
            if (keys.Contains("acpsdk.singleQueryUrl"))
                singleQueryUrl = config.AppSettings.Settings["acpsdk.singleQueryUrl"].Value; //功能：读取配置文件获取交易查询地址
            if (keys.Contains("acpsdk.fileTransUrl"))
                fileTransUrl = config.AppSettings.Settings["acpsdk.fileTransUrl"].Value;  //功能：读取配置文件获取文件传输类交易地址
            if (keys.Contains("acpsdk.frontTransUrl"))
                frontTransUrl = config.AppSettings.Settings["acpsdk.frontTransUrl"].Value; //功能：读取配置文件获取前台交易地址
            if (keys.Contains("acpsdk.backTransUrl"))
                backTransUrl = config.AppSettings.Settings["acpsdk.backTransUrl"].Value;//功能：读取配置文件获取后台交易地址
            if (keys.Contains("acpsdk.batTransUrl"))
                batTransUrl = config.AppSettings.Settings["acpsdk.batTransUrl"].Value;//功能：读取配批量交易地址

            if (keys.Contains("acpsdk.frontUrl"))
                frontUrl = config.AppSettings.Settings["acpsdk.frontUrl"].Value;//功能：读取配置文件获取前台通知地址
            if (keys.Contains("acpsdk.backUrl"))
                backUrl = config.AppSettings.Settings["acpsdk.backUrl"].Value;//功能：读取配置文件获取前台通知地址

            if (keys.Contains("acpsdk.jf.cardRequestUrl"))
                jfCardRequestUrl = config.AppSettings.Settings["acpsdk.jf.cardRequestUrl"].Value;  //功能：缴费产品有卡交易路径;
            if (keys.Contains("acpsdk.jf.appRequestUrl"))
                jfAppRequestUrl = config.AppSettings.Settings["acpsdk.jf.appRequestUrl"].Value;  //功能：缴费产品app交易路径;
            if (keys.Contains("acpsdk.jf.singleQueryUrl"))
                jfSingleQueryUrl = config.AppSettings.Settings["acpsdk.jf.singleQueryUrl"].Value; //功能：读取配置文件获取缴费产品交易查询地址
            if (keys.Contains("acpsdk.jf.frontTransUrl"))
                jfFrontTransUrl = config.AppSettings.Settings["acpsdk.jf.frontTransUrl"].Value; //功能：读取配置文件获取缴费产品前台交易地址
            if (keys.Contains("acpsdk.jf.backTransUrl"))
                jfBackTransUrl = config.AppSettings.Settings["acpsdk.jf.backTransUrl"].Value;//功能：读取配置文件获取缴费产品后台交易地址

            if (keys.Contains("acpsdk.ifValidateRemoteCert"))
                ifValidateRemoteCert = config.AppSettings.Settings["acpsdk.ifValidateRemoteCert"].Value;//功能：是否验证后台https证书
            if (keys.Contains("acpsdk.ifValidateCNName"))
                ifValidateCNName = config.AppSettings.Settings["acpsdk.ifValidateCNName"].Value;//功能：是否验证证书cn
            if (keys.Contains("acpsdk.middleCert.path"))
                middleCertPath = config.AppSettings.Settings["acpsdk.middleCert.path"].Value;//功能：中级证书路径
            if (keys.Contains("acpsdk.rootCert.path"))
                rootCertPath = config.AppSettings.Settings["acpsdk.rootCert.path"].Value;//功能：根证书路径
            if (keys.Contains("acpsdk.secureKey"))
                secureKey = config.AppSettings.Settings["acpsdk.secureKey"].Value;//功能：散列方式签名密钥
            if (keys.Contains("acpsdk.signMethod"))
                signMethod = config.AppSettings.Settings["acpsdk.signMethod"].Value;//功能：设置signMethod
            if (keys.Contains("acpsdk.version"))
                version = config.AppSettings.Settings["acpsdk.version"].Value;//功能：设置signMethod

        }

        public static string CardRequestUrl
        {
            get { return SDKConfig.cardRequestUrl; }
            set { SDKConfig.cardRequestUrl = value; }
        }
        public static string AppRequestUrl
        {
            get { return SDKConfig.appRequestUrl; }
            set { SDKConfig.appRequestUrl = value; }
        }

        public static string FrontTransUrl
        {
            get { return SDKConfig.frontTransUrl; }
            set { SDKConfig.frontTransUrl = value; }
        }
        public static string EncryptCert
        {
            get { return SDKConfig.encryptCert; }
            set { SDKConfig.encryptCert = value; }
        }


        public static string BackTransUrl
        {
            get { return SDKConfig.backTransUrl; }
            set { SDKConfig.backTransUrl = value; }
        }

        public static string SingleQueryUrl
        {
            get { return SDKConfig.singleQueryUrl; }
            set { SDKConfig.singleQueryUrl = value; }
        }

        public static string FileTransUrl
        {
            get { return SDKConfig.fileTransUrl; }
            set { SDKConfig.fileTransUrl = value; }
        }

        public static string SignCertPath
        {
            get { return SDKConfig.signCertPath; }
            set { SDKConfig.signCertPath = value; }
        }

        public static string SignCertPwd
        {
            get { return SDKConfig.signCertPwd; }
            set { SDKConfig.signCertPwd = value; }
        }

        public static string ValidateCertDir
        {
            get { return SDKConfig.validateCertDir; }
            set { SDKConfig.validateCertDir = value; }
        }
        public static string BatTransUrl
        {
            get { return SDKConfig.batTransUrl; }
            set { SDKConfig.batTransUrl = value; }
        }
        public static string BackUrl
        {
            get { return SDKConfig.backUrl; }
            set { SDKConfig.backUrl = value; }
        }
        public static string FrontUrl
        {
            get { return SDKConfig.frontUrl; }
            set { SDKConfig.frontUrl = value; }
        }
        public static string JfCardRequestUrl
        {
            get { return SDKConfig.cardRequestUrl; }
            set { SDKConfig.cardRequestUrl = value; }
        }
        public static string JfAppRequestUrl
        {
            get { return SDKConfig.jfAppRequestUrl; }
            set { SDKConfig.jfAppRequestUrl = value; }
        }

        public static string JfFrontTransUrl
        {
            get { return SDKConfig.jfFrontTransUrl; }
            set { SDKConfig.jfFrontTransUrl = value; }
        }
        public static string JfBackTransUrl
        {
            get { return SDKConfig.jfBackTransUrl; }
            set { SDKConfig.jfBackTransUrl = value; }
        }
        public static string JfSingleQueryUrl
        {
            get { return SDKConfig.jfSingleQueryUrl; }
            set { SDKConfig.jfSingleQueryUrl = value; }
        }

        public static string IfValidateRemoteCert
        {
            get { return SDKConfig.ifValidateRemoteCert; }
            set { SDKConfig.ifValidateRemoteCert = value; }
        }

        public static string IfValidateCNName
        {
            get { return SDKConfig.ifValidateCNName; }
            set { SDKConfig.ifValidateCNName = value; }
        }

        public static string MiddleCertPath
        {
            get { return SDKConfig.middleCertPath; }
            set { SDKConfig.middleCertPath = value; }
        }

        public static string RootCertPath
        {
            get { return SDKConfig.rootCertPath; }
            set { SDKConfig.rootCertPath = value; }
        }

        public static string SecureKey
        {
            get { return SDKConfig.secureKey; }
            set { SDKConfig.secureKey = value; }
        }

        public static string SignMethod
        {
            get { return SDKConfig.signMethod; }
            set { SDKConfig.signMethod = value; }
        }

        public static string Version
        {
            get { return SDKConfig.version; }
            set { SDKConfig.version = value; }
        }
    }
}