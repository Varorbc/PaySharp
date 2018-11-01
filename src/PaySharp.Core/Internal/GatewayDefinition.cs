//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace PaySharp.Core.Internal
//{
//    public class GatewayDefinition
//    {
//        public virtual string Name { get; set; }
//        public IGatewayOption Option { get; set; }

//        public virtual Func<IServiceProvider,GatewayDefinition> Create { get; set; }
//    }

//    public class GatewayDefinition<T> :GatewayDefinition where T : IGatewayOption
//    {
//        public new T Option
//        {
//            get
//            {
//                if(base.Option is T t)
//                {
//                    return t;
//                }
//                return default(T);
//            }
//        }

//        public new Func<IServiceProvider, GatewayDefinition<T>> Create
//        {
//            get
//            {
//                return base.Create as Func<IServiceProvider, GatewayDefinition<T>>;
//            }
//            set
//            {
//                base.Create = value;
//            }
//        }
//    }

   
//}
