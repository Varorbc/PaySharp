#if NET45
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Xml;

namespace PaySharp.Core
{
    public class ConfigurationHandler : IConfigurationSectionHandler
    {
        public object Create(object parent, object configContext, XmlNode section)
        {
            List<Hashtable> list = new List<Hashtable>();

            foreach (XmlNode child in section.ChildNodes)
            {
                var hashtable = new Hashtable();
                if (child.Attributes["gatewayUrl"] != null)
                {
                    hashtable.Add("gatewayUrl", child.Attributes["gatewayUrl"].Value);
                }

                foreach (XmlNode grandChild in child.ChildNodes)
                {
                    hashtable.Add(grandChild.Name, grandChild.InnerText);
                }

                list.Add(hashtable);
            }

            return list;
        }
    }
}
#endif
