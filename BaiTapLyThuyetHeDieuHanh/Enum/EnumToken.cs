using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLyThuyetHeDieuHanh.Enum
{
    enum TokenType
    {
        EOF = 0,

        Number,

        Add, // +
        Subtract, // -
        Multiply, // *
        Divide, // '/'
        LParen, // (
        RParen, // )
        Equal, // ==
        GreaterThan, // >
        GreaterThanOrEqual, // >=
        LessThan, // <
        LessThanOrEqual, //<=
    }
}
