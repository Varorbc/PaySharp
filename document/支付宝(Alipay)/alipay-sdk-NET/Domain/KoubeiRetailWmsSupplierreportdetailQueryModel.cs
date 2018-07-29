using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// KoubeiRetailWmsSupplierreportdetailQueryModel Data Structure.
    /// </summary>
    [Serializable]
    public class KoubeiRetailWmsSupplierreportdetailQueryModel : AopObject
    {
        /// <summary>
        /// 供货商盘点单id
        /// </summary>
        [XmlElement("supplier_report_id")]
        public string SupplierReportId { get; set; }
    }
}
