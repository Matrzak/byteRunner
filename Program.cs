using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using byteRunner.utils;
using byteRunner.basic;
using System.Xml.Linq;
using byteRunner.managers;

namespace byteRunner{
    class Program{

        public static string logo_ascii = @"  _           _       ____                              
 | |__  _   _| |_ ___|  _ \ _   _ _ __  _ __   ___ _ __ 
 | '_ \| | | | __/ _ \ |_) | | | | '_ \| '_ \ / _ \ '__|
 | |_) | |_| | ||  __/  _ <| |_| | | | | | | |  __/ |   
 |_.__/ \__, |\__\___|_| \_\\__,_|_| |_|_| |_|\___|_|   
        |___/                                           ";

        private static String dir = Directory.GetCurrentDirectory();
        public static TextController A = new TextController(Lang.DEFAULT);

        static bool SettingsExists() {
            return File.Exists(dir + @"/settings.xml") ? true : false;
        }

        static void removeOldExe(){
            if (File.Exists(dir + @"/stage2.exe")){
                File.Delete(dir + @"/stage2.exe");
            }
        }

        static void CreateSettings(){
            new XDocument(
                new XElement("settings",
                    new XElement("lang", A.GetLang().ToString())
                )
            ).Save("settings.xml");
        }

        static Lang ReadPlayerLanguage(){
            while (true){
                string input = Console.ReadLine();
                switch (input){
                    case "PL":
                        return Lang.PL;
                    case "EN":
                        return Lang.EN;
                    default:
                        A.Get("lang");
                        break;
                }
            }
        }

        static void Main(string[] args){
            removeOldExe();
            Console.WriteLine(logo_ascii);
            if (!SettingsExists()){
                A.Get("settings","lang");
                A = new TextController(ReadPlayerLanguage());
                CreateSettings();
            } else A = new TextController();

            A.Get("desc","scene");
            new CommandsManager();

        }
    }
}
