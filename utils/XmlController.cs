using byteRunner.basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace byteRunner.utils {
    class XmlController {

        public static bool getBool(string v){
            return v == "1" ? true : false;
        }

        public static Dictionary<string,TextComponent> GetDict(XmlDocument document){
            Dictionary<string, TextComponent> R = new Dictionary<string,TextComponent>();
            foreach(XmlNode node in document.DocumentElement){
                XmlAttributeCollection A = node.Attributes;
                R.Add(node.Name, new TextComponent(
                   node.InnerText,
                   A[0] != null ? getBool(A[0].InnerText) : false,
                   A[1] != null ? Convert.ToInt16(A[1].InnerText) : 0, A[2] != null ? Convert.ToInt16(A[2].InnerText) : 0
                ));
            }
            return R;
        }

    }
}
