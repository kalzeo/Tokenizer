using System;
using System.CodeDom.Compiler;

namespace Tokenizer
{
    public class TokenLexer
    {
        private readonly string text;
        private int position;

        public TokenLexer(string text)
        {
            this.text = text;
        }
        
        // Current character
        public char Current
        {
            get
            {
                try
                {
                    return position >= text.Length ? '\0' : text[position];
                }
                catch (IndexOutOfRangeException)
                {
                    return '\0';
                }
            }
        }

        // Look ahead
        public char PeekNext
        {
            get
            {
                try
                {
                    return position >= text.Length ? '\0' : text[position + 1];
                }
                catch (IndexOutOfRangeException)
                {
                    return text[position];
                }
            }
        }

        // Increment position in the text
        private int Next() => position++;

        // Next token in the text
        public Token NextToken()
        {
            // EOF check
            if (position >= text.Length) return new Token(TokenType.EOF, "\0", position);

            // Capture whitespace
            if (char.IsWhiteSpace(Current))
            {
                int start = position;
                while (char.IsWhiteSpace(Current)) Next();
                return new Token(TokenType.Whitespace, GetSubstring(start, 0), start);
            }

            // Identify keywords and identifiers
            if (char.IsLetter(Current))
            {
                var start = position;
                while (char.IsLetterOrDigit(Current)) Next();


                if (CodeDomProvider.CreateProvider("C#").IsValidIdentifier(GetSubstring(start, 0)))
                    return new Token(TokenType.Indentifier, GetSubstring(start, 0), start);
                return new Token(TokenType.Keyword, GetSubstring(start, 0), start);
            }

            // Check for numbers and floats
            if (char.IsDigit(Current))
            {
                int start = position;
                bool isDecimal = false;

                while (true)
                {

                    if (char.IsDigit(Current)) Next();
                    else if (Current.Equals('.') && !isDecimal && char.IsDigit(PeekNext))
                    {
                        isDecimal = true;
                        Next();
                    }
                    else break;
                }

                return new Token(TokenType.Number, GetSubstring(start, 0), start);
            }

            // Switch symbols that appear to prevent unknown tokens
            TokenType tokenType;
            string symbol;
            switch (Current)
            {
                case '&': tokenType = TokenType.Ampersand; symbol = "&"; break;
                case '*': tokenType = TokenType.Asterisk; symbol = "*"; break;
                case '@': tokenType = TokenType.AtSign; symbol = "@"; break;
                case '\\': tokenType = TokenType.Backslash; symbol = "\\"; break;
                case '^': tokenType = TokenType.CircumflexAccent; symbol = "^"; break;
                case ':': tokenType = TokenType.Colon; symbol = ":"; break;
                case ',': tokenType = TokenType.Comma; symbol = ","; break;
                case '$': tokenType = TokenType.Dollar; symbol = "$"; break;
                case '"': return HandleQuotes();
                case '=': tokenType = TokenType.EqualsSign; symbol = "="; break;
                case '!': tokenType = TokenType.ExplanationMark; symbol = "!"; break;
                case '.': tokenType = TokenType.FullStop; symbol = "."; break;
                case '`': tokenType = TokenType.GraveAccent; symbol = "`"; break;
                case '>': tokenType = TokenType.GreaterThanSign; symbol = ">"; break;
                case '#': tokenType = TokenType.Hash; symbol = "#"; break;
                case '-': tokenType = TokenType.Hyphen; symbol = "-"; break;
                case '[': tokenType = TokenType.LeftBracket; symbol = "["; break;
                case '{': tokenType = TokenType.LeftCurlyBracket; symbol = "{"; break;
                case '(': tokenType = TokenType.LeftParenthesis; symbol = "("; break;
                case '<': tokenType = TokenType.LessThanSign; symbol = "<"; break;
                case '%': tokenType = TokenType.Percent; symbol = "%"; break;
                case '+': tokenType = TokenType.PlusSign; symbol = "+"; break;
                case '£': tokenType = TokenType.PoundSign; symbol = "£"; break;
                case '?': tokenType = TokenType.QuestionMark; symbol = "?"; break;
                case ']': tokenType = TokenType.RightBracket; symbol = "]"; break;
                case '}': tokenType = TokenType.RightCurlyBracket; symbol = "}"; break;
                case ')': tokenType = TokenType.RightParenthesis; symbol = ")"; break;
                case ';': tokenType = TokenType.SemiColon; symbol = ";"; break;
                case '\'': return HandleQuotes();
                case '/': return HandleSlash();
                case '~': tokenType = TokenType.Tilde; symbol = "~"; break;
                case '_': tokenType = TokenType.Underscore; symbol = "_"; break;
                case '|': tokenType = TokenType.VerticalLine; symbol = "|"; break;
                case '¬': tokenType = TokenType.Negation; symbol = "¬"; break;

                default:
                    tokenType = TokenType.Unknown; symbol = text.Substring(position - 1, 1);
                    break;
            }

            return new Token(tokenType, symbol, Next());
        }
        
        // Handle slashes to check if it's a single-line/multi-line comment or just a slash
        private Token HandleSlash()
        {
            int start = position;

            switch(PeekNext)
            {
                case '*':
                    Next();
                    while ((!Current.Equals('*') && !PeekNext.Equals('/')) || (Current.Equals('*') && !PeekNext.Equals('/')))
                        Next();
                    Next(); Next();
                    return new Token(TokenType.Comment, GetSubstring(start, 0), start);

                case '/':
                    while (!Current.Equals('\n'))
                        Next();
                    return new Token(TokenType.Comment, GetSubstring(start, 0), start);

                default:
                    return new Token(TokenType.Slash, "/", start);
            }
        }

        // Handle single and double quote strings
        private Token HandleQuotes()
        {
            int start = position;

            switch(Current)
            {
                case '\'':
                    Next();
                    while (!Current.Equals('\''))
                        Next();
                    Next();
                    return new Token(TokenType.SingleQuotedString, GetSubstring(start, 0), start);

                case '\"':
                    Next();
                    while (!Current.Equals('\"'))
                        Next();
                    Next();
                    return new Token(TokenType.DoubleQuotedString, GetSubstring(start, 0), start);

                default:
                    return new Token(TokenType.Unknown, text.Substring(position - 1, 1), start);
            }
        }

        private string GetSubstring(int start, int additionalNumber) => text.Substring(start, position - start + additionalNumber);
    }
}
