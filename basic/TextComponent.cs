using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace byteRunner.basic {
    class TextComponent {

        private string txt;
        private ConsoleColor c;
        private bool clear;
        private int spaces = 0;

        public TextComponent(string txt, bool clear = false, int spaces = 0, int c = 0){
            this.txt = txt;
            this.clear = clear;
            switch (c){
                case 1:
                    this.c = ConsoleColor.DarkBlue;
                    break;
                case 2:
                    this.c = ConsoleColor.Green;
                    break;
                case 4:
                    this.c = ConsoleColor.Red;
                    break;
                case 7:
                    this.c = ConsoleColor.Yellow;
                    break;
            }
            this.spaces = spaces;
        }

        public void display(){
            if (this.clear)
                Console.Clear();
            for (int i = 0; i < this.spaces; i++)
                Console.WriteLine(" ");
            if (this.c != 0)
                Console.ForegroundColor = this.c;

            Console.WriteLine(this.txt);
            Console.ResetColor();

        }

    }
}
