using BaiTapLyThuyetHeDieuHanh.Enum;
using System;
using System.Linq.Expressions;

namespace BaiTapLyThuyetHeDieuHanh
{
    class Parser
    {
        private Scanner _scanner;
        private Token _token;


        public static string EOF = "EOF";
        public static string ADD = "+";
        public static string SUB = "-";
        public static string MULTI = "*";
        public static string DIVIDE = "/";
        public static string LPAREN = "(";
        public static string RPAREN = ")";
        public static string GREATERTHAN = ">";
        public static string GREATERTHANORQUEAL = ">=";
        public static string LESSTHAN = "<";
        public static string LESSTHANOREQUAL = "<=";
        public static string EQUAL = "==";


        public Parser(Scanner scanner)
        {
            this._scanner = scanner;
        }

        public Expression Parse()
        {
            _token = _scanner.Next();

            Expression expr = CompareExpression();

            Check(Token.EOF);

            return expr;
        }

        private bool Read()
        {
            if (_token.Type == TokenType.EOF)
                return false;

            _token = _scanner.Next();

            return _token.Type != TokenType.EOF;
        }

        private bool Check(Token token)
        {
            if (!_token.Equals(token))
                throw new Exception("'" + token + "' expected.");

            return Read();
        }

        private Expression CompareExpression()
        {
            Expression lhs = AddExpression();

            if (_token.Type == TokenType.Equal ||
                _token.Type == TokenType.GreaterThan || _token.Type == TokenType.LessThan ||
                _token.Type == TokenType.GreaterThanOrEqual || _token.Type == TokenType.LessThanOrEqual)
            {
                TokenType type = _token.Type;

                Read();

                Expression rhs = CompareExpression();

                switch (type)
                {
                    case TokenType.Equal:
                        lhs = Expression.Equal(lhs, rhs);
                        break;
                    case TokenType.GreaterThan:
                        lhs = Expression.GreaterThan(lhs, rhs);
                        break;
                    case TokenType.GreaterThanOrEqual:
                        lhs = Expression.GreaterThanOrEqual(lhs, rhs);
                        break;
                    case TokenType.LessThan:
                        lhs = Expression.LessThan(lhs, rhs);
                        break;
                    case TokenType.LessThanOrEqual:
                        lhs = Expression.LessThanOrEqual(lhs, rhs);
                        break;
                }

            }

            return lhs;
        }

        private Expression AddExpression()
        {
            Expression lhs = MultiplyExpression();

            while (_token.Type == TokenType.Add || _token.Type == TokenType.Subtract)
            {
                TokenType type = _token.Type;

                Read();

                Expression rhs = MultiplyExpression();

                lhs = type == TokenType.Add ? Expression.Add(lhs, rhs) : Expression.Subtract(lhs, rhs);

            }

            return lhs;
        }

        private Expression MultiplyExpression()
        {
            Expression lhs = UnaryExpression();

            while (_token.Type == TokenType.Multiply || _token.Type == TokenType.Divide)
            {
                TokenType type = _token.Type;

                Read();

                Expression rhs = UnaryExpression();

                lhs = type == TokenType.Multiply ? Expression.Multiply(lhs, rhs) : Expression.Divide(lhs, rhs);

            }

            return lhs;
        }

        private Expression UnaryExpression()
        {
            Expression ret = null;

            if (_token.Type == TokenType.Add || _token.Type == TokenType.Subtract)
            {
                TokenType type = _token.Type;
                Read();

                Expression expr = UnaryExpression();

                ret = type == TokenType.Add ? Expression.UnaryPlus(expr) : Expression.Negate(expr);
            }
            else
                ret = ValueExpression();

            return ret;
        }

        private Expression ValueExpression()
        {
            Expression ret = null;

            if (_token.Type == TokenType.Number)
            {
                ret = Expression.Constant(double.Parse(_token.Value));

                Read();
            }
            else if (_token.Type == TokenType.LParen)
            {
                Read();

                ret = CompareExpression();

                Check(Token.RParen);
            }
            else
                throw new Exception("Unexpected token: " + _token);

            return ret;
        }
    }
}