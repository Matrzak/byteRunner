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
                    case "szyfruj": case "encrypt":
                        if(c.Length <= 2 || !IsNumeric(c[1])){
                            Program.A.Get("acmds");
                            break;
                        }
                        int l = Convert.ToInt16(c[1]);
                        c = c.Skip(2).ToArray();
                        Console.WriteLine(Enc(String.Join(" ",c),l).Replace('O','ś').Replace('?','ł'));
                        break;
                    case "sms":
                        if (c.Length <= 1){
                            Program.A.Get("acmds");
                            break;
                        }
                        c = c.Skip(1).ToArray();
                        string text = String.Join(" ", c);
                        if (!string.Equals("the die is cast", text, StringComparison.OrdinalIgnoreCase)){
                            Program.A.Get("badcode");
                            break;
                        }
                        Program.A.Get("goodcode");
                        Thread.Sleep(2000);
                        Program.A.Get("done");
                        new WebManager().Download();
                        break;
                    default:
                        Program.A.Get("acmds");
                        break;
                }
            }
        }

    }
}
