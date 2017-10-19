using System;

namespace ICanPay.Core
{
    /// <summary>
    /// 订单的金额、编号
    /// </summary>
    public class Order
    {

        #region 私有字段

        double amount;
        string id;
        string subject;

        #endregion


        #region 构造函数

        public Order()
        {
        }



        public Order(string id, double orderAmount)
        {
            this.id = id;
            this.amount = orderAmount;
        }

        #endregion


        #region 属性

        /// <summary>
        /// 订单总金额，以元为单位。例如：1.00，1元人民币。0.01，1角人民币。因为支付网关要求的最低支付金额为0.01元，所以amount最低为0.01。
        /// </summary>
        public double Amount
        {
            get
            {
                if (amount < 0.01)
                {
                    throw new ArgumentOutOfRangeException("Amount", "订单金额没有设置");
                }

                return amount;
            }

            set
            {
                if (value < 0.01)
                {
                    throw new ArgumentOutOfRangeException("Amount", "订单金额必须大于或等于0.01");
                }

                amount = value;
            }
        }


        /// <summary>
        /// 订单Id
        /// </summary>
        public string Id
        {
            get
            {
                if (string.IsNullOrEmpty(id))
                {
                    throw new ArgumentNullException("OrderId", "订单订单编号没有设置");
                }

                return id;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("OrderId", "订单订单编号不能为空");
                }

                id = value;
            }
        }


        /// <summary>
        /// 订单主题，订单主题为空时将使用订单Id作为主题
        /// </summary>
        public string Subject
        {
            get
            {
                if (string.IsNullOrEmpty(subject))
                {
                    return id;
                }

                return subject;
            }

            set
            {
                subject = value;
            }
        }

        #endregion

    }
}
