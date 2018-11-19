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
            get { return new Token(Parser.EOF, TokenType.EOF); }
        }
        public static Token Add
        {
            get { return new Token(Parser.ADD, TokenType.Add); }
        }
        public static Token Subtract
        {
            get { return new Token(Parser.SUB, TokenType.Subtract); }
        }
        public static Token Multiply
        {
            get { return new Token(Parser.MULTI, TokenType.Multiply); }
        }
        public static Token Divide
        {
            get { return new Token(Parser.DIVIDE, TokenType.Divide); }
        }
        public static Token LParen
        {
            get { return new Token(Parser.LPAREN, TokenType.LParen); }
        }
        public static Token RParen
        {
            get { return new Token(Parser.RPAREN, TokenType.RParen); }
        }
        public static Token Equal
        {
            get { return new Token(Parser.EQUAL, TokenType.Equal); }
        }
        public static Token GreaterThan
        {
            get { return new Token(Parser.GREATERTHAN, TokenType.GreaterThan); }
        }
        public static Token GreaterThanOrEqual
        {
            get { return new Token(Parser.GREATERTHANORQUEAL, TokenType.GreaterThanOrEqual); }
        }
        public static Token LessThan
        {
            get { return new Token(Parser.LESSTHAN, TokenType.LessThan); }
        }
        public static Token LessThanOrEqual
        {
            get { return new Token(Parser.LESSTHANOREQUAL, TokenType.LessThanOrEqual); }
        }
        #endregion
    }

}