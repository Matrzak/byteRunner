using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace byteRunner.managers {
    class CommandsManager {

        public CommandsManager(){
            Program.A.Get("acmds");
            while (true){
                string[] c = Console.ReadLine().Split(' ');
                switch (c[0]){
                    case "akta":
                        System.Diagnostics.Process.Start("https://www.google.com/maps/@39.7368934,-105.0040631,3a,75y,183.36h,88.51t/data=!3m7!1e1!3m5!1sCPcsU6OesCaIq5ZxNybYKA!2e0!6s%2F%2Fgeo0.ggpht.com%2Fcbk%3Fpanoid%3DCPcsU6OesCaIq5ZxNybYKA%26output%3Dthumbnail%26cb_client%3Dmaps_sv.tactile.gps%26thumb%3D2%26w%3D203%26h%3D100%26yaw%3D323.34113%26pitch%3D0%26thumbfov%3D100!7i13312!8i6656");
                        break;
                    case "sms":
                        if(c.Length <= 1) break;
                        if(!string.Equals("#7D1B1B", c[1], StringComparison.OrdinalIgnoreCase)){
                            Program.A.Get("badcode");
                            break;
                        }
                        Program.A.Get("goodcode");
                        Thread.Sleep(2000);

                        return;
                }
            }
        }

    }
}
