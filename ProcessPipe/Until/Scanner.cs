using BaiTapLyThuyetHeDieuHanh.Enum;
using System;
using System.Text;

namespace BaiTapLyThuyetHeDieuHanh
{
    class Scanner
    {
        const char EOF = '\0';
        string _input;
        int _index = -1;
        char _ch;

        public Scanner(string input)
        {
            _input = input;
        }
        private void Read()
        {
            _index++;
            if (_index < _input.Length)
                _ch = _input[_index];
            else
                _ch = EOF;
        }

        public Token Next()
        {
            Read();

            if (_index < _input.Length)
            {
                while (Char.IsWhiteSpace(_ch))
                {
                    Read();
                }

                if (char.IsDigit(_ch)) // number
                {
                    StringBuilder str = new StringBuilder();

                    while (Char.IsDigit(_ch) || _ch == '.')
                    {
                        str.Append(_ch);
                        Read();
                    }
                    _index--;

                    return new Token(str.ToString(), TokenType.Number);
                }
                else
                {
                    switch (_ch)
                    {
                        case '+':
                            return Token.Add;
                        case '-':
                            return Token.Subtract;
                        case '*':
                            return Token.Multiply;
                        case '/':
                            return Token.Divide;
                        case '(':
                            return Token.LParen;
                        case ')':
                            return Token.RParen;
                        case '=':
                            Read();
                            if (_ch == '=') return Token.Equal;
                            throw new InvalidOperationException("equalily operator must be '=='");
                        case '>':
                            Read();
                            if (_ch == '=') return Token.GreaterThanOrEqual;
                            _index--;
                            return Token.GreaterThan;
                        case '<':
                            Read();
                            if (_ch == '=') return Token.LessThanOrEqual;
                            _index--;
                            return Token.LessThan;
                        default:
                            throw new Exception("Invalid character: " + _ch);
                    }

                }

            }
            return Token.EOF;

        }

    }
}