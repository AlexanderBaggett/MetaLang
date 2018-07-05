using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MetaLanguage
{
    public enum TerminalType
    {
        If,
        Else,
        ElseIf,
        Equals,
        EqualsEquals,
        NotEquals,
        Number,  //sometimes we don't know the number's type without context
        Float,
        Long,
        Decimal,
        Double,
        Byte,
        Integer,
        UnsignedLong,
        String,
        Identifier,
        CompilerError,
        Colon,
        DoubleColon,
        BigInteger,
        OpenBrace,
        CloseBrace,
        OpenBracket,
        CloseBracket,
        OpenParens,
        CloseParens,
        DoubleLeftAngelBracket,
        DoubleRightAngleBracket,
        TripleLeftAngleBracket,
        TripleRightAngleBracket,
        GreaterThan,
        LessThan,
        LessthanEqualTo,
        GreaterthanEqualTo,
        SingleQuote,
        Comma,
        Asterick,
        Not,
        Plus,
        Minus,
        PlusPlus,
        MinusMinus,
        TimesEquals,
        Modulus,
        ModulusEquals,
        PlusEquals,
        MinusEquals,
        BitshiftLeftEquals,
        BitshiftRightEquals,
        AndEquals,
        PowerEquals,
        OrEquals,
        ForwardPipe,
        BackwardPipe,
        Public,
        Private,
        Protected,
        Internal,
        Virtual,
        Static,
        Class,
        Override,
        Enum,
        NameSpace,
        Using,
        Var,
        StackTypeInteger,
        StackTypeDouble,
        StackTypeFloat,
        StackTypeDecimal,
        StackTypeStuct,
        StackTypeByte,
        StackTypeLong,
        StackTypeBool,
        StackTypeNull,
        StackTypeStruct,
        True,
        False,
        Dot,
        DotDot,
        Question,
        DoubleQuestion,
        DotQuestion,
        And,
        Bar,
        AndAnd,
        BarBar,
        Switch,
        Case,
        For,
        Foreach,
        ParallelForeach,
        In,
        Do,
        Then,
        While,




    }
    public  class Terminals
    {
        private static Dictionary<string, TerminalType> StringToTerminal = new Dictionary<string, TerminalType>();
        
        public Terminals()
        {
            StringToTerminal.Add("if", TerminalType.If);
            StringToTerminal.Add("else", TerminalType.Else);
            StringToTerminal.Add("elseif", TerminalType.ElseIf);
            StringToTerminal.Add("case", TerminalType.Case);
            StringToTerminal.Add("for", TerminalType.For);
            StringToTerminal.Add("foreach", TerminalType.Foreach);
            StringToTerminal.Add("pforeach", TerminalType.Foreach);
            StringToTerminal.Add("in", TerminalType.In);
            StringToTerminal.Add("do", TerminalType.Do);
            StringToTerminal.Add("while", TerminalType.While);
            StringToTerminal.Add("=", TerminalType.Equals);
            StringToTerminal.Add("==", TerminalType.EqualsEquals);
            StringToTerminal.Add("!=", TerminalType.NotEquals);
            StringToTerminal.Add(":", TerminalType.Colon);
            StringToTerminal.Add("::", TerminalType.DoubleColon);
            StringToTerminal.Add("[", TerminalType.OpenBrace);
            StringToTerminal.Add("]", TerminalType.CloseBrace);
            StringToTerminal.Add("{", TerminalType.OpenBracket);
            StringToTerminal.Add("}", TerminalType.CloseBracket);
            StringToTerminal.Add("(", TerminalType.OpenParens);
            StringToTerminal.Add(")", TerminalType.CloseParens);
            StringToTerminal.Add("<<", TerminalType.DoubleLeftAngelBracket);
            StringToTerminal.Add(">>", TerminalType.DoubleRightAngleBracket);
            StringToTerminal.Add("<<<", TerminalType.TripleLeftAngleBracket);
            StringToTerminal.Add(">>>", TerminalType.TripleRightAngleBracket);
            StringToTerminal.Add(">", TerminalType.GreaterThan);
            StringToTerminal.Add("<", TerminalType.LessThan);
            StringToTerminal.Add(">=", TerminalType.GreaterthanEqualTo);
            StringToTerminal.Add("<=", TerminalType.LessthanEqualTo);
            StringToTerminal.Add("'", TerminalType.SingleQuote);
            StringToTerminal.Add(",", TerminalType.Comma);
            StringToTerminal.Add("*", TerminalType.Asterick);
            StringToTerminal.Add("!", TerminalType.Not);
            StringToTerminal.Add("+", TerminalType.Plus);
            StringToTerminal.Add("-", TerminalType.Minus);
            StringToTerminal.Add("++", TerminalType.PlusPlus);
            StringToTerminal.Add("*=", TerminalType.TimesEquals);
            StringToTerminal.Add("%", TerminalType.Modulus);
            StringToTerminal.Add("%=", TerminalType.ModulusEquals);
            StringToTerminal.Add("+=", TerminalType.PlusEquals);
            StringToTerminal.Add("-=", TerminalType.MinusEquals);
            StringToTerminal.Add("<<=", TerminalType.BitshiftLeftEquals);
            StringToTerminal.Add(">>=", TerminalType.BitshiftRightEquals);
            StringToTerminal.Add("&=", TerminalType.AndEquals);
            StringToTerminal.Add("^=", TerminalType.PowerEquals);
            StringToTerminal.Add("|=", TerminalType.DoubleRightAngleBracket);
            StringToTerminal.Add("|>", TerminalType.ForwardPipe);
            StringToTerminal.Add("<|", TerminalType.BackwardPipe);
            StringToTerminal.Add(".", TerminalType.Dot);
            StringToTerminal.Add("..", TerminalType.DotDot);
            StringToTerminal.Add("?", TerminalType.Question);
            StringToTerminal.Add("??", TerminalType.DoubleQuestion);
            StringToTerminal.Add(".?", TerminalType.DoubleQuestion);
            StringToTerminal.Add("&", TerminalType.And);
            StringToTerminal.Add("&&", TerminalType.AndAnd);
            StringToTerminal.Add("|", TerminalType.Bar);
            StringToTerminal.Add("||", TerminalType.BarBar);
            StringToTerminal.Add("public", TerminalType.Public);
            StringToTerminal.Add("private", TerminalType.Private);
            StringToTerminal.Add("protected", TerminalType.Protected);
            StringToTerminal.Add("internal", TerminalType.Internal);
            StringToTerminal.Add("virtual", TerminalType.Virtual);
            StringToTerminal.Add("override", TerminalType.Override);
            StringToTerminal.Add("class", TerminalType.Class);
            StringToTerminal.Add("static", TerminalType.Internal);
            StringToTerminal.Add("enum", TerminalType.Enum);
            StringToTerminal.Add("namespace", TerminalType.NameSpace);
            StringToTerminal.Add("using", TerminalType.NameSpace);
            StringToTerminal.Add("var", TerminalType.Var);
            StringToTerminal.Add("int", TerminalType.StackTypeInteger);
            StringToTerminal.Add("long", TerminalType.StackTypeLong);
            StringToTerminal.Add("byte", TerminalType.StackTypeByte);
            StringToTerminal.Add("double", TerminalType.StackTypeDouble);
            StringToTerminal.Add("float", TerminalType.StackTypeFloat);
            StringToTerminal.Add("decimal", TerminalType.StackTypeDecimal);
            StringToTerminal.Add("byte", TerminalType.StackTypeByte);
            StringToTerminal.Add("struct", TerminalType.StackTypeStruct);
            StringToTerminal.Add("null", TerminalType.StackTypeNull);






        }

        public  TerminalType this [string TokenValue]
        {
            get
            {   //It's a number
                if (TokenValue.StartsWithMulti(new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" }))
                {
                    char end = TokenValue[TokenValue.Length - 1];
                    
                    switch (end)
                    {
                        case 'f': return TerminalType.Float;
                        case 'l': return TerminalType.Long;
                        case 'd': return TerminalType.Double;
                        case 'm': return TerminalType.Decimal;
                        case 'b': return TerminalType.Byte;
                        case 'i': return TerminalType.Integer;
                        case 'I': return TerminalType.BigInteger;
                        case '0': case '1': case '2': case '3': case '4': case '5': case '6': case'7': case '8': case '9': return TerminalType.Number;
                        //case 'ul': return TerminalType.UnsignedLong;
                    }
                } //It's a string
                else if (TokenValue.StartsWithMulti(new string[] { "\"","@"}))
                {
                    return TerminalType.String;
                }
                else
                {
                    try
                    {  // It's a known terminal
                        return StringToTerminal[TokenValue];
                    }
                    catch
                    {       
                        if (TokenValue.StartsWithMulti(new string[] { "!", "#", "%", "^", "&", "*", "_", "-","$" }))
                        {
                            return TerminalType.CompilerError;
                        }
                        //It's an identifier.
                        return TerminalType.Identifier;
                    }
                }
                return TerminalType.CompilerError;
            }
        }

   
    }

}
