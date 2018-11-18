using BaiTapLyThuyetHeDieuHanh.Enum;

namespace BaiTapLyThuyetHeDieuHanh
{
    struct Token
    {
        public string Value;
        public TokenType Type;

        /*
         param: value 
         */
        public Token(string value, TokenType type)
        {
            Value = value;
            Type = type;
        }
        public override string ToString()
        {
            return Value;
        }

        #region Static Properties

        public static Token EOF
        {
            get { return new Token("EOF", TokenType.EOF); }
        }
        public static Token Add
        {
            get { return new Token("+", TokenType.Add); }
        }
        public static Token Subtract
        {
            get { return new Token("-", TokenType.Subtract); }
        }
        public static Token Multiply
        {
            get { return new Token("*", TokenType.Multiply); }
        }
        public static Token Divide
        {
            get { return new Token("/", TokenType.Divide); }
        }
        public static Token LParen
        {
            get { return new Token("(", TokenType.LParen); }
        }
        public static Token RParen
        {
            get { return new Token(")", TokenType.RParen); }
        }
        public static Token Equal
        {
            get { return new Token("==", TokenType.Equal); }
        }
        public static Token GreaterThan
        {
            get { return new Token(">", TokenType.GreaterThan); }
        }
        public static Token GreaterThanOrEqual
        {
            get { return new Token(">=", TokenType.GreaterThanOrEqual); }
        }
        public static Token LessThan
        {
            get { return new Token("<", TokenType.LessThan); }
        }
        public static Token LessThanOrEqual
        {
            get { return new Token("<=", TokenType.LessThanOrEqual); }
        }
        #endregion
    }

}