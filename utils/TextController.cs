using byteRunner.basic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml;
using System.Xml.Linq;

namespace byteRunner.utils {

    public enum Lang {DEFAULT, PL, EN};


    class TextController {

        private Dictionary<string,TextComponent> A;
        private Lang lang;

        public TextController(Lang lang){
            setLang(lang);
        }

        public TextController(){
            XmlDocument xml = new XmlDocument();
            xml.Load(@"settings.xml");
            string value = xml.SelectSingleNode("settings/lang").InnerText;
            Lang l;
            Enum.TryParse(value, out l);
            setLang(l);
        }

        public void setLang(Lang lang){
            XmlDocument xml = new XmlDocument();
            switch (lang){
                case Lang.DEFAULT:
                    xml.Load(@"lang\default.xml");
                    break;
                case Lang.PL:
                    xml.Load(@"lang\pl.xml");
                    break;
                case Lang.EN:
                    xml.Load(@"lang\en.xml");
                    break;
            }
            this.A = XmlController.GetDict(xml);
            this.lang = lang;
        }

        public Lang GetLang(){
            return this.lang;
        }
        public void Get(params string[] key){
            for(int i = 0; i < key.Length; i++)
                A[key[i]].display();
        }

    }
}
