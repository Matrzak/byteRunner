using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace byteRunner.managers {
    class CommandsManager {
        public string Enc(string strPT, int intK)
        {
            strPT = strPT.ToLower();
            char[] buffer = strPT.ToCharArray();
            for (int i = 0; i < buffer.Length; i++)
            {
                char letter = buffer[i];
                if (letter != ' ')
                {
                    letter = (char)(letter + intK);
                    if (letter > 'z')
                    {
                        letter = (char)(letter - 26);
                    }
                }
                buffer[i] = letter;
            }
            string strCT = new string(buffer);
            return strCT;
        }

        public static bool IsNumeric(object Expression){
            double retNum;

            bool isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
            return isNum;
        }

        public CommandsManager(){
            Program.A.Get("acmds");
            while (true){
                string[] c = Console.ReadLine().Split(' ');
                switch (c[0]){
                    default:
                        Program.A.Get("acmds");
                        break;
                }
            }
        }

    }
}
