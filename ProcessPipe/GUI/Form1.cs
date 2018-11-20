using BaiTapLyThuyetHeDieuHanh;
using MaterialSkin;
using PipesClientTest;
using PipesServerTest;
using ProcessMessageQueue.Until;
using System;
using System.Collections;
using System.Linq.Expressions;
using System.Text;
using System.Windows.Forms;

namespace ProcessPipe
{
    public partial class Form1 : MaterialSkin.Controls.MaterialForm
    {
        //đây là tên server mà bên process chính gửi tới
        private static string nameServerSend = "serverLTHDH1";
        //đây là tên server sẽ nhận kết quả sau khi tính toán
        private static string nameServerReceiver = "serverLTHDH2";
        private string _receiver = "";
        private string _result = "";
        private PipeServer _pipeServer;
        private PipeClient _pipeClient;

        public object StringBuider { get; private set; }

        public delegate void NewMessageDelegate(string NewMessage);

        public Form1()
        {
            InitializeComponent();
            MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;

            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Blue400, Primary.Blue500,
                Primary.Blue500, Accent.LightBlue200,
                TextShade.WHITE
            );

            SetupText();

            //khởi tạo server
            _pipeServer = new PipeServer();
            _pipeServer.PipeMessage += new DelegateMessage(PipesMessageHandler);
        }

        //Hàm tính toán
        private void Caculation()
        {
            try
            {
                Scanner scanner = new Scanner(_receiver);
                Parser parser = new Parser(scanner);
                Expression expr = parser.Parse();
                Delegate func = Expression.Lambda(expr).Compile();
                //kết quả
                _result = func.DynamicInvoke().ToString();
                txtResult.Text = TextState.TXTRESULT + _result;
                SendResult();
            }
            catch (Exception e)
            {
                _result = e.Message;
                txtResult.Text = e.Message;
                SendResult();
            }
        }

        //gửi lại giá trị cho process chính khi thực hiện tính toán thành công
        private void SendResult()
        {
            _pipeClient = new PipeClient();
            _pipeClient.Send(_result, nameServerReceiver, 1000);
        }

        //khơi tạo text của label lúc đầu
        private void SetupText()
        {
            txtReceiver.Text = TextState.TXTRECIVER;
            txtResult.Text = TextState.TXTRESULT;
            txtState.Text = TextState.STATENOTSEND;
        }

        //Khi đóng form sẽ set lại các giá trị là null
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _pipeClient = null;
            _pipeServer.PipeMessage -= new DelegateMessage(PipesMessageHandler);
            _pipeServer = null;
        }


        //lắng nghe nếu có tin nhắn mới
        private void PipesMessageHandler(string message)
        {
            try
            {
                //không được yêu cầu sẽ nhảy vào if, còn không thì sẽ hiển thị màn hình và thực hiện tính toán
                if (this.InvokeRequired)
                {
                    this.Invoke(new NewMessageDelegate(PipesMessageHandler), message);
                }
                else
                {
                    _receiver = message;
                    _receiver = FormatString(_receiver);
                    txtReceiver.Text = TextState.TXTRECIVER + _receiver;
                    Caculation();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("EXception: " + ex.Message);
            }

        }

        //Sử lý chuỗi có ký tự đặc biệt
        private string FormatString(String s)
        {
            ArrayList k = new ArrayList();
            k.Add('0');
            k.Add('1');
            k.Add('2');
            k.Add('3');
            k.Add('4');
            k.Add('5');
            k.Add('6');
            k.Add('7');
            k.Add('8');
            k.Add('9');
            k.Add('/');
            k.Add('*');
            k.Add('-');
            k.Add('+');
            k.Add('=');
            k.Add('(');
            k.Add(')');
            k.Add('<');
            k.Add('>');
            k.Add('.');
            foreach (char i in k)
            {
                Console.Write(i + ". ");
            }
            char[] t = s.ToCharArray();
            for (int i = 0; i < t.Length; i++)
            {
                if (!k.Contains(t[i]))
                {
                    t[i] = ' ';
                }
            }
            StringBuilder stringBuilder = new StringBuilder("");
            foreach (char i in t)
            {
                stringBuilder.Append(i);
                Console.Write(i + ", ");
            }
            stringBuilder.Replace(" ", "");
            return stringBuilder.ToString();
        }

        //lúc đầu khi tạo form sẽ thực hiện tạo luôn server để lắng nghe dữ liệu từ process chính gửi tới
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                _pipeServer.Listen(nameServerSend);
                Console.WriteLine("Listening success");
            }
            catch (Exception)
            {
                Console.WriteLine("Listening faild");
            }
        }
    }
}
