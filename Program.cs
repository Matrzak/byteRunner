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

        public static string logo_ascii = @"                           ######                                     
 #####  #   # ##### ###### #     # #    # #    # #    # ###### #####  
 #    #  # #    #   #      #     # #    # ##   # ##   # #      #    # 
 #####    #     #   #####  ######  #    # # #  # # #  # #####  #    # 
 #    #   #     #   #      #   #   #    # #  # # #  # # #      #####  
 #    #   #     #   #      #    #  #    # #   ## #   ## #      #   #  
 #####    #     #   ###### #     #  ####  #    # #    # ###### #    # 
                                                                     ";

        private static String dir = Directory.GetCurrentDirectory();
        public static TextController A = new TextController(Lang.DEFAULT);

        static bool SettingsExists() {
            return File.Exists(dir + @"/settings.xml") ? true : false;
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
            Console.WriteLine(logo_ascii);
            if (!SettingsExists()){
                A.Get("settings","lang");
                A = new TextController(ReadPlayerLanguage());
                CreateSettings();
            } else A = new TextController();

            if(args.Length == 1 && args[0] == "-herewego"){
                A.Get("done");
                new WebManager().Download();
                return;
            }
            A.Get("lore", "introducing","skills","skills_", "start");
        }
    }
}
