using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaySharp.Alipay.DI.fake
{
    class AlipayFactory
    {
        public IAlipayClient CreateClient(Merchant merchant)
        {
            throw new NotImplementedException();
        }
        public IAlipayListener CreateListener(Merchant merchant)
        {
            throw new NotImplementedException();
        }
    }
}
