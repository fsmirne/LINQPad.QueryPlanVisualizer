using System.Xml.Linq;

namespace QueryPlanVisualizer.LinqPad6.Helpers
{
    static class XmlUtils
    {
        public static string AttributeValue(this XElement element, string attribute)
        {
            return element.Attribute(attribute).Value;
        }

        public static string ElementValue(this XElement element, string attribute)
        {
            return element.Element(attribute)?.Value;
        }

        public static XName WithName(this XNamespace @namespace, string name)
        {
            return @namespace + name;
        }
    }
}