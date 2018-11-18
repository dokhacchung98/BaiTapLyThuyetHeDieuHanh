using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTapLyThuyetHeDieuHanh
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            try
            {
                string input = "2+3-4+2-4*(2  +1)";
                Scanner scanner = new Scanner(input);
                Parser parser = new Parser(scanner);
                Expression expr = parser.Parse();

                Delegate func = Expression.Lambda(expr).Compile();

                Console.WriteLine("ket qua:  " + func.DynamicInvoke());

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
        }
    }
}
