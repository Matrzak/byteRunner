using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace byteRunner.basic {

    class DFile {

        private string ddir,name,dir;

        public DFile(params string[] values){
            this.ddir = values[0];
            this.name = values[1];
            this.dir = values[2];
        }

        public string GetAbsoluteDir(){
            return Directory.GetCurrentDirectory() + this.dir + this.name;
        }

        public string GetDir(){
            return Directory.GetCurrentDirectory() + this.dir;
        }

        public string GetDDir(){
            return this.ddir;
        }

    }
}
