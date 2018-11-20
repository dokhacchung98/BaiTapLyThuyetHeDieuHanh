using BaiTapLyThuyetHeDieuHanh;
using MaterialSkin;
using ProcessMessageQueue.Until;
using System;
using System.Linq.Expressions;
using System.Messaging;
using System.Security.Permissions;
using System.Threading;
using System.Windows.Forms;

namespace ProcessMessageQueue
{
    public partial class Form1 : MaterialSkin.Controls.MaterialForm
    {
        //kết quả sau khi tính toán
        private string _result = "";
        //thông tin nhận được
        private string _recive = "";
        private Thread thread;
        //public static object objLock
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

            //khởi tạo thread để lắng nghe nhiều tin nhắn chứ không phải 1
            thread = new Thread(new ThreadStart(ListenMessageQeue));
            thread.Start();

            this.FormClosed += new FormClosedEventHandler(Form_Closed);
        }

        //khi đóng form sẽ abort thread
        [SecurityPermissionAttribute(SecurityAction.Demand, ControlThread = true)]
        void Form_Closed(object sender, FormClosedEventArgs e)
        {
            if (thread != null && thread.IsAlive)
            {
                thread.Abort();
                thread = null;
                //khởi tạo messagequeue
                using (MessageQueue msgQueue = new MessageQueue())
                {
                    msgQueue.Path = @".\private$\baitaplthdhSend";
                    if (!MessageQueue.Exists(msgQueue.Path))
                    {
                        MessageQueue.Create(msgQueue.Path);
                    }
                    System.Messaging.Message message = new System.Messaging.Message();
                    message.Body = null;
                    msgQueue.Send(message);
                }
            }
        }

        //sau khi tính toán xong sẽ trả kết quả cho bên main để hiển thị
        private void SendResult()
        {
            using (MessageQueue msgQueue = new MessageQueue())
            {
                msgQueue.Path = @".\private$\baitaplthdhRecive";
                if (!MessageQueue.Exists(msgQueue.Path))
                {
                    MessageQueue.Create(msgQueue.Path);
                }
                System.Messaging.Message message = new System.Messaging.Message();
                message.Body = _result.ToString();
                msgQueue.Send(message);

                //khi gửi thành công sẽ hiển thị trạng thái đã gửi
                txtState.Text = TextState.STATESEND;
                //thread để sau 0.5s sẽ hiển thị lại trạng thái lúc đầu là đang lắng nghe tin mới
                new Thread(() =>
                {
                    Thread.Sleep(500);
                    txtState.Text = TextState.STATENOTSEND;
                }).Start();
            }

        }

        //lắng nghe tin nhắn từ bên process chính gửi sang để tính toán
        private void ListenMessageQeue()
        {
            using (MessageQueue msgQueue = new MessageQueue())
            {
                //khởi tạo messagequeue
                msgQueue.Path = @".\private$\baitaplthdhSend";
                if (!MessageQueue.Exists(msgQueue.Path))
                {
                    MessageQueue.Create(msgQueue.Path);
                }
                while (true)
                {
                    System.Messaging.Message message = new System.Messaging.Message();
                    //nhận tin nhắn
                    message = msgQueue.Receive();
                    //format lại định dạng sang chuỗi acsii
                    message.Formatter = new XmlMessageFormatter(new string[] { "System.String, mscorlib" });
                    string m = message.Body.ToString();
                    //hiển thị tin nhắn lên màn hình
                    txtReciver.Text = TextState.TXTRECIVER + m;
                    _recive = m;
                    Caculation();
                }
            }
        }

        //thực hiện tính toán
        private void Caculation()
        {
            try
            {
                Scanner scanner = new Scanner(_recive);
                Parser parser = new Parser(scanner);
                Expression expr = parser.Parse();
                Delegate func = Expression.Lambda(expr).Compile();
                _result = func.DynamicInvoke().ToString();
                txtResult.Text = TextState.TXTRESULT + _result;
                //tính toán thành công sẽ gửi trả kết quả về bên main
                SendResult();
            }
            catch (Exception e)
            {
                _result = e.Message;
                txtResult.Text = e.Message;
                //gặp định dạng sai sẽ thông báo bên main
                SendResult();
            }
        }

        //khởi tạo text cho label lúc đầu
        private void SetupText()
        {
            txtReciver.Text = TextState.TXTRECIVER;
            txtResult.Text = TextState.TXTRESULT;
            txtState.Text = TextState.STATENOTSEND;
        }
    }
}
