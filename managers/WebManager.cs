using byteRunner.basic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace byteRunner.managers {

    class WebManager {

        private string surl = "http://byterunner.keep.pl";
        private DFile[] files;
        private WebClient client;

        public WebManager(){
            this.files = new DFile[] {
                new DFile(@"/levels/s1/byteRunner.exe","stage1.exe","/"),
                new DFile(@"/levels/s1/pl.xml","pl.xml","/lang/"),
                new DFile(@"/levels/s1/en.xml","en.xml","/lang/"),
            };
            client = new WebClient();
        }

        public WebManager Download(){
            Program.A.Get("dls");
            foreach(DFile f in this.files){
                if (!Directory.Exists(f.GetDir())) Directory.CreateDirectory(f.GetDir());
                string durl = this.surl + f.GetDDir();
                try{
                    client.DownloadFile(durl, f.GetAbsoluteDir());
                } catch(Exception e) {
                    Console.WriteLine("An error has occured while downloading a file, quiting in 5sec");
                    Thread.Sleep(5000);
                    System.Environment.Exit(1);
                }
            }
            Program.A.Get("dle");
            return this;
        }

    }
}
