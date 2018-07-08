using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MetaLanguage
{
    class Lexer
    {
        List<string> CompilerErrors = new List<string>();
        private string Path { get; set; }
        public List<Token> LexedTokens { get; set; }
        public Lexer(string path)
        {
            this.Path = path;
        }
        public void Lex()
        {
            string fileContents = File.ReadAllText(Path);

            fileContents = fileContents.Replace("\t", "");

            var Lines = fileContents.Split(new string[] { System.Environment.NewLine }, StringSplitOptions.None);


            var Tokens = new List<Token>();
            int linenumber = 0;
            foreach (var line in Lines)
            {
                linenumber++;
                //var intermediate = ForceTokenization(line, new string[] {".","(",")","[","]",",","}","{", });

                line.Split(new char[] { ' ' }).ToList()
                    .ForEach(x => Tokens
                    .Add(new Token() {Value=x,LineNumber= linenumber }));
            }
            //remove empty tokens

            var debug2 = Tokens.Select(x => x.Value).ToList();
            RemoveEmptyTokens(ref Tokens);
            RejoinStringsWithSpaces(ref Tokens);
            RemoveEmptyTokens(ref Tokens);
            Tokens  = TokenizeSpecialCharacters(Tokens, new string[] { ".", "(", ")", "[", "]", ",", "}", "{", });

            var Terminals = new Terminals();
            foreach(var token in Tokens)
            {
                token.Terminal = Terminals[token.Value];
            }

            LexedTokens = Tokens;
            var debug = true;
        }
        private static List<Token> TokenizeSpecialCharacters(List<Token> Tokens, string [] SpecialCharacters)
        {
            Dictionary<int, Token> IndexToToken = new Dictionary<int, Token>();
            var TokensToRemove = new List<Token>();
            foreach (var token in Tokens)
            {
                int count = 0;
                int index = Tokens.IndexOf(token); //do not split tokens that are strings or have only 1 character
                if (token.Value.Length > 1 && !token.Value.StartsWith("\"") && token.Value.ContainsOne(SpecialCharacters))
                {
                    token.Value.ToArray().ToList().ForEach(c =>
                    {
                        IndexToToken.Add(index + count, new Token()
                        {
                            Value = c.ToString(),
                            LineNumber = token.LineNumber
                        }
                            );
                        count++;
                    }
                    );
                    TokensToRemove.Add(token);
                }
            }
            foreach (var KVP in IndexToToken)
            {
                Tokens.Insert(KVP.Key, KVP.Value);
            }
            Tokens = Tokens.Except(TokensToRemove).ToList();
            return Tokens;
        }

        private string ForceTokenization(string line, string [] InputPatterns)
        {
            foreach (var s in InputPatterns)
            {
               line =  line.Replace(s, " " + s + " ");
            }
            return line;
        }

        private void RemoveEmptyTokens(ref List<Token> tokens)
        {
            var y = tokens;
            tokens = tokens.Where(x => !String.IsNullOrWhiteSpace(x.Value)).ToList();
            var z = tokens;
        }

        private void RejoinStringsWithSpaces(ref List<Token> Tokens)
        {
            //Concatenate spaces removed from strings adding back in the spaces
            var tokensSeen = new List<Token>();
            var tokensToRemove = new List<Token>();
            List<string> CompilerErrors = new List<string>();
            foreach (var token in Tokens)
            {
                tokensSeen.Add(token);
                if (token.Value.Substring(0, 1) == "\"")
                {
                    try
                    {
                        var nextMatching = Tokens.Except(tokensSeen).Where(x => x.Value.Contains("\"")).First();
                        var currentIndex = Tokens.IndexOf(token);
                        var endIndex = Tokens.IndexOf(nextMatching);
                        StringBuilder sb = new StringBuilder();
                        sb.Append(token.Value);
                        for (int i = currentIndex + 1; i <= endIndex; i++)
                        {
                            sb.Append(" "+ Tokens[i].Value);
                            tokensToRemove.Add(Tokens[i]);
                        }
                        token.Value = sb.ToString();
                        tokensToRemove.Add(nextMatching);
                    }
                    catch
                    {
                        CompilerErrors.Add("No matching \" near " + token.Value + " on line " +token.LineNumber);
                    }
                }
            }
            if (CompilerErrors.Count() != 0)
            {
                HandleCompilerErrors();
            }
            Tokens = Tokens.Except(tokensToRemove).ToList();

        }
        private void HandleCompilerErrors()
        {

        }

    }

    public class Token
    {
        public string Value { get; set; }
        public long LineNumber { get; set; }
        public TerminalType Terminal { get; set; }
    }
}
