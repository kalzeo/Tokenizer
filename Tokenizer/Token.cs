namespace Tokenizer
{
    public class Token
    {
        public Token(TokenType type, string text, int position)
        {
            Type = type;
            Position = position;
            Text = text;
        }

        public TokenType Type { get; }
        public int Position { get; }
        public string Text { get; }

        public override string ToString()
        {
            return $"[{Type}]: {Text}\n";
        }
    }
}
