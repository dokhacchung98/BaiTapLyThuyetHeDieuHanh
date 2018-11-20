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
        private string _result = "";
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
            thread = new Thread(new ThreadStart(ListenMessageQeue));
            thread.Start();

            this.FormClosed += new FormClosedEventHandler(Form_Closed);
        }

        [SecurityPermissionAttribute(SecurityAction.Demand, ControlThread = true)]
        void Form_Closed(object sender, FormClosedEventArgs e)
        {
            if (thread != null && thread.IsAlive)
            {
                thread.Abort();
                thread = null;
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

                txtState.Text = TextState.STATESEND;
                new Thread(() =>
                {
                    Thread.Sleep(500);
                    txtState.Text = TextState.STATENOTSEND;
                }).Start();
            }

        }

        private void ListenMessageQeue()
        {
            using (MessageQueue msgQueue = new MessageQueue())
            {
                msgQueue.Path = @".\private$\baitaplthdhSend";
                if (!MessageQueue.Exists(msgQueue.Path))
                {
                    MessageQueue.Create(msgQueue.Path);
                }
                while (true)
                {
                    System.Messaging.Message message = new System.Messaging.Message();
                    message = msgQueue.Receive();
                    message.Formatter = new XmlMessageFormatter(new string[] { "System.String, mscorlib" });
                    string m = message.Body.ToString();
                    txtReciver.Text = TextState.TXTRECIVER + m;
                    _recive = m;
                    Caculation();
                }
            }
        }

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

                SendResult();
            }
            catch (Exception e)
            {
                _result = e.Message;
                txtResult.Text = e.Message;
                SendResult();
            }
        }

        private void SetupText()
        {
            txtReciver.Text = TextState.TXTRECIVER;
            txtResult.Text = TextState.TXTRESULT;
            txtState.Text = TextState.STATENOTSEND;
        }
    }
}
