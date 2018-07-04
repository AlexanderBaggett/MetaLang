using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaLanguage
{
    class Program
    {
        static void Main(string[] args)
        {

            var lexer = new Lexer("sample.txt");
            lexer.Lex();
            var x = 10;

        }
    }
}
