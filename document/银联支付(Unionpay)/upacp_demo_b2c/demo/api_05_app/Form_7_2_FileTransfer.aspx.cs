using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.IO;
using com.unionpay.acp.sdk;
using ICSharpCode.SharpZipLib.Zip;

namespace upacp_demo_app.demo.api_05_app
{
    public partial class Form_7_2_FileTransfer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /**
             * 重要：联调测试时请仔细阅读注释！
             * 
             * 产品：跳转网关支付产品<br>
             * 交易：文件传输类接口：后台获取对账文件交易，只有同步应答 <br>
             * 日期： 2015-09<br>
             * 版本： 1.0.0 
             * 版权： 中国银联<br>
             * 说明：以下代码只是为了方便商户测试而提供的样例代码，商户可以根据自己需要，按照技术文档编写。该代码仅供参考，不提供编码性能规范性等方面的保障<br>
             * 该接口参考文档位置：open.unionpay.com帮助中心 下载  产品接口规范  《网关支付产品接口规范》<br>
             *              《平台接入接口规范-第5部分-附录》（内包含应答码接口规范，全渠道平台银行名称-简码对照表）<br>
             *              《全渠道平台接入接口规范 第3部分 文件接口》（对账文件格式说明）<br>
             * 测试过程中的如果遇到疑问或问题您可以：1）优先在open平台中查找答案：
             * 							        调试过程中的问题或其他问题请在 https://open.unionpay.com/ajweb/help/faq/list 帮助中心 FAQ 搜索解决方案
             *                             测试过程中产生的7位应答码问题疑问请在https://open.unionpay.com/ajweb/help/respCode/respCodeList 输入应答码搜索解决方案
             *                          2） 咨询在线人工支持： open.unionpay.com注册一个用户并登陆在右上角点击“在线客服”，咨询人工QQ测试支持。
             * 交易说明： 对账文件的格式请参考《全渠道平台接入接口规范 第3部分 文件接口》
             *        对账文件示例见目录assets/对账文件样例下的802310048993424_20150905.zip
             *        解析落地后的对账文件可以参考BaseDemo.java中的parseZMFile();parseZMEFile();方法     
             */

            Dictionary<string, string> param = new Dictionary<string, string>();

            //以下信息非特殊情况不需要改动
            param["version"] = SDKConfig.Version;//版本号
            param["encoding"] = "UTF-8";//编码方式
            param["signMethod"] = SDKConfig.SignMethod;//签名方法
            param["txnType"] = "76";//交易类型
            param["txnSubType"] = "01";//交易子类
            param["bizType"] = "000000";//业务类型
            param["accessType"] = "0";//接入类型
            param["channelType"] = "07";//渠道类型
            param["fileType"] = "00";//文件类型

            //TODO 以下信息需要填写
            param["merId"] = Request.Form["merId"].ToString(); param["merId"] = Request.Form["merId"].ToString();//商户代码，请改成自己的测试商户号，此处默认取demo演示页面传递的参数
            param["txnTime"] = Request.Form["txnTime"].ToString();//订单发送时间，取北京时间，格式为YYYYMMDDhhmmss，此处默认取demo演示页面传递的参数
            param["settleDate"] = Request.Form["settleDate"].ToString();//清算日期，格式为MMDD，此处默认取demo演示页面传递的参数

            AcpService.Sign(param, System.Text.Encoding.UTF8);  // 签名
            string url = SDKConfig.FileTransUrl;

            Dictionary<String, String> rspData = AcpService.Post(param, url, System.Text.Encoding.UTF8);

            Response.Write(DemoUtil.GetPrintResult(url, param, rspData));

            if (rspData.Count == 0)
            {
                Response.Write("请求失败<br>\n");
                return;
            }

            if (!AcpService.Validate(rspData, System.Text.Encoding.UTF8)) //验签
            {
                Response.Write("商户端验证返回报文签名失败。<br>\n");
                return;
            }
            Response.Write("商户端验证返回报文签名成功。<br>\n");
            string respcode = rspData["respCode"]; //其他应答参数也可用此方法获取

            if ("98" == respcode)
            {
                //TODO 文件不存在
                Response.Write("文件不存在。<br>\n");
                return;
            }
            else if ("00" != respcode)
            {
                //TODO 其他应答码做以失败处理
                Response.Write("失败：respcode=" + respcode + "。<br>\n");
                return;
            }

            Response.Write("返回成功。<br>\n");

            // 解析返回文件
            string fileContent = rspData["fileContent"];

            if (string.IsNullOrEmpty(fileContent))
            {
                Response.Write("fileContent为空，正常不会出现，请确定是否调错接口？<br>\n");
                return;
            }
            //Base64解码
            byte[] dBase64Byte = Convert.FromBase64String(fileContent);
            //解压缩
            byte[] fileByte = SecurityUtil.Inflater(dBase64Byte);

            string filePath = "D:/file/"; //TODO 【重要】请先确保此路径存在，且有权限写入

            if (AcpService.DeCodeFileContent(rspData, filePath))
                Response.Write("文件成功保存到" + filePath + "目录下。<br>\n");
            else
                Response.Write("文件保存失败，请看下日志文件中的报错信息。<br>\n");

            //=================================================================
            //TODO 下面是调用的方法是分析对账文件的样例代码，请按照自己的需要修改并集成到自己的代码中
            analyzeFile(filePath, rspData["fileName"]);

        }

        private void analyzeFile(string filePath, string fileName)
        {
            //解压文件
            ZipInputStream s = new ZipInputStream(File.OpenRead(filePath + "\\" + fileName));
            ZipEntry theEntry;
            while ((theEntry = s.GetNextEntry()) != null)
            {
                string directoryName = Path.GetDirectoryName(filePath);
                fileName = Path.GetFileName(theEntry.Name);

                //生成解压目录
                Directory.CreateDirectory(directoryName);

                if (fileName != String.Empty)
                {
                    //解压文件到指定的目录
                    FileStream streamWriter = File.Create(filePath + theEntry.Name);

                    int size = 2048;
                    byte[] data = new byte[2048];
                    while (true)
                    {
                        size = s.Read(data, 0, data.Length);
                        if (size > 0)
                        {
                            streamWriter.Write(data, 0, size);
                        }
                        else
                        {
                            break;
                        }
                    }
                    streamWriter.Close();
                }
            }
            s.Close();

            //遍历解压之后目录下的所有文件，对流水文件分析
            foreach (string file in Directory.GetFiles(filePath))
            {
                fileName = file.Substring(filePath.Length);
                List<Dictionary<int, string>> list = null;

                if (fileName.Substring(0, 3) == "INN" && fileName.Substring(11, 3) == "ZM_")
                {
                    list = parseZMFile(file);
                }
                else if (fileName.Substring(0, 3) == "INN" && fileName.Substring(11, 4) == "ZME_")
                {
                    list = parseZMEFile(file);
                }

                if (list != null)
                {
                    Response.Write(fileName + "部分参数读取（读取方式请参考Form_7_2_FileTransfer的代码）:<br>\n");
                    Response.Write("<table border='1'>\n");
                    Response.Write("<tr><th>txnType</th><th>orderId</th><th>txnTime（MMDDhhmmss）</th></tr>");
                    foreach (Dictionary<int, string> dic in list)
                    {
                        //TODO 参看https://open.unionpay.com/ajweb/help?id=258，根据编号获取即可，例如订单号12、交易类型20。
                        //具体写代码时可能边读文件边修改数据库性能会更好，请注意自行根据parseFile中的读取方法修改。
                        Response.Write("<tr>\n");
                        Response.Write("<td>" + dic[20] + "</td>\n");//txnType
                        Response.Write("<td>" + dic[12] + "</td>\n");//orderId
                        Response.Write("<td>" + dic[5] + "</td>\n");//txnTime不带年份
                        Response.Write("</tr>\n");
                    }
                    Response.Write("</table>\n");
                }
            }
        }

        //全渠道商户一般交易明细流水文件 
        private List<Dictionary<int, string>> parseZMFile(string filePath)
        {
            int[] lengthArray = new int[42] { 3, 11, 11, 6, 10, 19, 12, 4, 2, 21, 2, 32, 2, 6, 10, 13, 13, 4, 15, 2, 2, 6, 2, 4, 32, 1, 21, 15, 1, 15, 32, 13, 13, 8, 32, 13, 13, 12, 2, 1, 32, 98 };
            return parseFile(filePath, lengthArray);
        }

        //全渠道商户差错交易明细流水文件 
        private List<Dictionary<int, string>> parseZMEFile(string filePath)
        {
            int[] lengthArray = new int[22] { 3, 11, 11, 6, 10, 19, 12, 4, 2, 2, 6, 10, 4, 12, 13, 13, 15, 15, 1, 12, 2, 135 };
            return parseFile(filePath, lengthArray);
        }

        private List<Dictionary<int, string>> parseFile(string filePath, int[] lengthArray)
        {
            if (!File.Exists(filePath))
            {
                return null;
            }

            //解析的结果MAP，key为对账文件列序号，value为解析的值
            List<Dictionary<int, string>> dataList = new List<Dictionary<int, string>>();

            // Open the file to read from.
            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            using (StreamReader sr = new StreamReader(fs, Encoding.GetEncoding("GBK")))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    byte[] bs = Encoding.GetEncoding("GBK").GetBytes(s);
                    Dictionary<int, string> dataMap = new Dictionary<int, string>();
                    //左侧游标
                    int leftIndex = 0;
                    //右侧游标
                    int rightIndex = 0;
                    for (int i = 0; i < lengthArray.Length; i++)
                    {
                        int length = lengthArray[i];
                        rightIndex = leftIndex + length;
                        byte[] target = new byte[length];
                        Array.Copy(bs, leftIndex, target, 0, length);
                        String filed = Encoding.GetEncoding("GBK").GetString(target);
                        //String filed = s.Substring(leftIndex, lengthArray[i]);
                        leftIndex = rightIndex + 1;
                        dataMap.Add(i + 1, filed);
                    }
                    dataList.Add(dataMap);
                }
            }
            return dataList;
        }
    }
}