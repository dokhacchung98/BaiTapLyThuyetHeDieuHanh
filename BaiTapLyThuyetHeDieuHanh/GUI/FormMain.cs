using MaterialSkin;
using PipesClientTest;
using PipesServerTest;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO.MemoryMappedFiles;
using System.Messaging;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace BaiTapLyThuyetHeDieuHanh
{
    public partial class FormMain : MaterialSkin.Controls.MaterialForm
    {
        #region Declare Variable
        //là string mà người dùng nhập
        private StringBuilder stringBuilder;
        //giá trị khi click radio button: 1 là gửi theo message queue, 2 là gửi theo share memory, 3 là gửi theo pipe
        private int _communicationType;
        //đây là tên server mà bên process chính gửi tới
        private static string nameServerSend = "serverLTHDH1";
        //đây là tên server sẽ nhận kết quả sau khi tính toán
        private static string nameServerReceiver = "serverLTHDH2";
        //khởi tọa delegate new message
        public delegate void NewMessageDelegate(string NewMessage);
        //Khởi tạo delegate settext
        delegate void SetTextCallback(string text);
        //server gửi pipe
        private PipeServer _pipeServer;
        //client gửi pipe
        private PipeClient _pipeClient;
        //Tên file send trong shared memory
        private static string fileSend = "file-send";
        //tên file receiver trong shared memory
        private static string fileReceiver = "file-reiceiver";
        //cho phép click vào nút ok
        private bool enableClickOk = true;
        //biến tạm của shared memory
        private bool lockW = true;

        #endregion

        #region Main
        public FormMain()
        {
            InitializeComponent();
            _communicationType = 1;
            MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;

            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Blue400, Primary.Blue500,
                Primary.Blue500, Accent.LightBlue200,
                TextShade.WHITE
            );
            stringBuilder = new StringBuilder("");

            _pipeServer = new PipeServer();
            _pipeServer.PipeMessage += new DelegateMessage(ListenResultPipe);

            SetupButton();
        }
        #endregion

        #region Init Form
        /*Khởi tạo các button, và thay đổi kích thước của chúng*/
        private void SetupButton()
        {
            btnValue1.AutoSize = false;
            btnValue1.Size = new Size(48, 48);
            btnValue2.AutoSize = false;
            btnValue2.Size = new Size(48, 48);
            btnValue3.AutoSize = false;
            btnValue3.Size = new Size(48, 48);
            btnValue4.AutoSize = false;
            btnValue4.Size = new Size(48, 48);
            btnValue5.AutoSize = false;
            btnValue5.Size = new Size(48, 48);
            btnValue6.AutoSize = false;
            btnValue6.Size = new Size(48, 48);
            btnValue7.AutoSize = false;
            btnValue7.Size = new Size(48, 48);
            btnValue8.AutoSize = false;
            btnValue8.Size = new Size(48, 48);
            btnValue9.AutoSize = false;
            btnValue9.Size = new Size(48, 48);
            btnValue0.AutoSize = false;
            btnValue0.Size = new Size(48, 48);
            btnLParen.AutoSize = false;
            btnLParen.Size = new Size(48, 48);
            btnRParen.AutoSize = false;
            btnRParen.Size = new Size(48, 48);
            btnDot.AutoSize = false;
            btnDot.Size = new Size(48, 48);
            btnAdd.AutoSize = false;
            btnAdd.Size = new Size(48, 48);
            btnSub.AutoSize = false;
            btnSub.Size = new Size(48, 48);
            btnMulti.AutoSize = false;
            btnMulti.Size = new Size(48, 48);
            btnDivide.AutoSize = false;
            btnDivide.Size = new Size(48, 48);
            btnOk.AutoSize = false;
            btnOk.Size = new Size(116, 48);
            btnGreaterThan.AutoSize = false;
            btnGreaterThan.Size = new Size(48, 48);
            btnGreaterThanOrEqual.AutoSize = false;
            btnGreaterThanOrEqual.Size = new Size(48, 48);
            btnLessThan.AutoSize = false;
            btnLessThan.Size = new Size(48, 48);
            btnLessThanOrEqual.AutoSize = false;
            btnLessThanOrEqual.Size = new Size(48, 48);
            btnEqual.AutoSize = false;
            btnEqual.Size = new Size(48, 48);
            btnClear.AutoSize = false;
            btnClear.Size = new Size(116, 48);
            btnDelete.AutoSize = false;
            btnDelete.Size = new Size(116, 48);

            txtMathExpression.BorderStyle = BorderStyle.FixedSingle;
            txtResult.BorderStyle = BorderStyle.FixedSingle;

            panelChose.BackColor = Color.FromArgb(242, 242, 242);
            panelNumber.BackColor = Color.FromArgb(242, 242, 242);

            panelChose.BorderStyle = BorderStyle.FixedSingle;
            panelNumber.BorderStyle = BorderStyle.FixedSingle;

        }

        /*Xử lý khi người dùng tiến hành tính toán: tức là click vào button bằng*/
        private void CallProcess()
        {
            switch (_communicationType)
            {
                case 1:
                    SendWithMessageQueue();
                    break;
                case 2:
                    SendWithSharedMemory();
                    break;
                case 3:
                    SendWithPipe();
                    break;
            }
        }

        #region Click Processing
        private void btnValue1_Click(object sender, EventArgs e)
        {
            stringBuilder.Append("1");
            UpdateLaybelExpressMath();
        }

        private void btnValue2_Click(object sender, EventArgs e)
        {
            stringBuilder.Append("2");
            UpdateLaybelExpressMath();
        }

        private void btnValue3_Click(object sender, EventArgs e)
        {
            stringBuilder.Append("3");
            UpdateLaybelExpressMath();
        }

        private void btnValue4_Click(object sender, EventArgs e)
        {
            stringBuilder.Append("4");
            UpdateLaybelExpressMath();
        }

        private void btnValue5_Click(object sender, EventArgs e)
        {
            stringBuilder.Append("5");
            UpdateLaybelExpressMath();
        }

        private void btnValue6_Click(object sender, EventArgs e)
        {
            stringBuilder.Append("6");
            UpdateLaybelExpressMath();
        }

        private void btnValue7_Click(object sender, EventArgs e)
        {
            stringBuilder.Append("7");
            UpdateLaybelExpressMath();
        }

        private void btnValue8_Click(object sender, EventArgs e)
        {
            stringBuilder.Append("8");
            UpdateLaybelExpressMath();
        }

        private void btnValue9_Click(object sender, EventArgs e)
        {
            stringBuilder.Append("9");
            UpdateLaybelExpressMath();
        }

        private void btnValue0_Click(object sender, EventArgs e)
        {
            stringBuilder.Append("0");
            UpdateLaybelExpressMath();
        }

        /*Cập nhật lại giao diện khi người dùng click*/
        private void UpdateLaybelExpressMath()
        {
            txtMathExpression.Text = stringBuilder.ToString();

        }

        private void btnLParen_Click(object sender, EventArgs e)
        {
            stringBuilder.Append(Parser.LPAREN);
            UpdateLaybelExpressMath();
        }

        private void btnRParen_Click(object sender, EventArgs e)
        {
            stringBuilder.Append(Parser.RPAREN);
            UpdateLaybelExpressMath();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            stringBuilder.Append(Parser.ADD);
            UpdateLaybelExpressMath();
        }

        private void btnSub_Click(object sender, EventArgs e)
        {
            stringBuilder.Append(Parser.SUB);
            UpdateLaybelExpressMath();
        }

        private void btnMulti_Click(object sender, EventArgs e)
        {
            stringBuilder.Append(Parser.MULTI);
            UpdateLaybelExpressMath();
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            stringBuilder.Append(Parser.DIVIDE);
            UpdateLaybelExpressMath();
        }

        private void btnGreaterThan_Click(object sender, EventArgs e)
        {
            stringBuilder.Append(Parser.GREATERTHAN);
            UpdateLaybelExpressMath();
        }

        private void btnLessThan_Click(object sender, EventArgs e)
        {
            stringBuilder.Append(Parser.LESSTHAN);
            UpdateLaybelExpressMath();
        }

        private void btnGreaterThanOrEqual_Click(object sender, EventArgs e)
        {
            stringBuilder.Append(Parser.GREATERTHANORQUEAL);
            UpdateLaybelExpressMath();
        }

        private void btnLessThanOrEqual_Click(object sender, EventArgs e)
        {
            stringBuilder.Append(Parser.LESSTHANOREQUAL);
            UpdateLaybelExpressMath();
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            stringBuilder.Append(".");
            UpdateLaybelExpressMath();
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            stringBuilder.Append(Parser.EQUAL);
            UpdateLaybelExpressMath();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (enableClickOk)
                CallProcess();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            stringBuilder = new StringBuilder("");
            txtMathExpression.Text = "0";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string value = stringBuilder.ToString().Trim();
            if (value.Length > 0)
            {
                value = value.Remove(value.Length - 1);
                stringBuilder = new StringBuilder(value);
                UpdateLaybelExpressMath();
            }
            else
            {
                txtMathExpression.Text = "0";
            }
        }

        private void cbMessageQueue_CheckedChanged(object sender, EventArgs e)
        {
            _communicationType = 1;
        }

        private void cbSharedMemory_CheckedChanged(object sender, EventArgs e)
        {
            _communicationType = 2;
        }

        private void cbPipe_CheckedChanged(object sender, EventArgs e)
        {
            _communicationType = 3;
        }

        #endregion
        #endregion

        #region Create Client
        /*Khởi tạo server lắng nge client từ lúc bắt đầu*/
        private void FormMain_Load(object sender, EventArgs e)
        {
            try
            {
                _pipeServer.Listen(nameServerReceiver);
                Console.WriteLine("Listening success");
            }
            catch (Exception)
            {
                Console.WriteLine("Listening faild");
            }
        }
        #endregion

        #region Message Queue
        /*Gửi dữ liệu giữa 2 process sử dụng message queue*/
        private void SendWithMessageQueue()
        {

            var anotherProcess = new Process
            {
                StartInfo =
                {
                    //đường dẫn tới process
                    FileName = @"C:\Users\hp\Desktop\Bài tập\BaiTapLyThuyetHeDieuHanh\BaiTapLyThuyetHeDieuHanh\ProcessMessageQueue\bin\Debug\ProcessMessageQueue.exe",
                    //không hiển thị màn hình process con
                    CreateNoWindow = false,
                    UseShellExecute = false
                }
            };
            //bắt đầu mở process con
            anotherProcess.Start();

            //khởi tạo message queue
            using (MessageQueue msgQueue = new MessageQueue())
            {
                //baitaplthdhSend là tên private queue
                msgQueue.Path = @".\private$\baitaplthdhSend";
                if (!MessageQueue.Exists(msgQueue.Path))
                {
                    //khởi tạo messagequeue
                    MessageQueue.Create(msgQueue.Path);
                }
                //Khởi tạo 1 tin nhắn mới
                System.Messaging.Message message = new System.Messaging.Message();
                //gán thân của tin nhắn là thông tin người dùng nhập
                message.Body = stringBuilder.ToString();
                //gửi sang process processmessagequeue
                msgQueue.Send(message);
                enableClickOk = false;
                ListeningResultMessageQueue(anotherProcess);
            }
        }

        //lắng nghe kết quả trả về từ process thứ 2 sau khi tính toán xong trả về
        private void ListeningResultMessageQueue(Process process)
        {
            using (MessageQueue msgQueue = new MessageQueue())
            {
                msgQueue.Path = @".\private$\baitaplthdhRecive";
                if (!MessageQueue.Exists(msgQueue.Path))
                {
                    MessageQueue.Create(msgQueue.Path);
                }
                System.Messaging.Message message = new System.Messaging.Message();
                message = msgQueue.Receive();
                message.Formatter = new XmlMessageFormatter(new string[] { "System.String, mscorlib" });
                string m = message.Body.ToString();
                txtResult.Text = m;
                process.Kill();
                enableClickOk = true;
            }
        }

        #endregion

        #region Shared Memory
        //gửi bằng giao thức shared memory
        private void SendWithSharedMemory()
        {
            new Thread(new ThreadStart(ListenResultShareMemory)).Start();
            using (MemoryMappedFile memoryMappedFile = MemoryMappedFile.CreateNew(fileSend, 10000))
            {
                using (MemoryMappedViewAccessor viewAccessor = memoryMappedFile.CreateViewAccessor())
                {
                    //Chuyển đổi đoạn string thành byte để chuyển sang process con
                    byte[] textBytes = Encoding.UTF8.GetBytes(stringBuilder.ToString());
                    //ghi vào vùng nhớ chung
                    viewAccessor.WriteArray(0, textBytes, 0, textBytes.Length);
                    var anotherProcess = new Process
                    {
                        StartInfo =
                            {
                                FileName = @"C:\Users\hp\Desktop\Bài tập\BaiTapLyThuyetHeDieuHanh\BaiTapLyThuyetHeDieuHanh\ProcessSharedMemory\bin\Debug\ProcessSharedMemory.exe",
                                CreateNoWindow = true,
                                UseShellExecute = false,
                                RedirectStandardOutput = true
                            }
                    };

                    anotherProcess.Start();
                    anotherProcess.WaitForExit();
                }

                enableClickOk = false;
                Console.WriteLine("dang chay");
            }

        }

        //lắng nghe tin nhắn trả về
        private void ListenResultShareMemory()
        {
            while (lockW)
            {
                try
                {
                    using (MemoryMappedFile memoryMappedFile = MemoryMappedFile.CreateOrOpen(fileReceiver, 10000))
                    {
                        using (MemoryMappedViewAccessor viewAccessor = memoryMappedFile.CreateViewAccessor())
                        {
                            byte[] bytes = new byte[100];
                            int res = viewAccessor.ReadArray(0, bytes, 0, bytes.Length);
                            string text = Encoding.UTF8.GetString(bytes).Trim('\0');
                            if (text != null && text.Length > 0)
                            {
                                lockW = false;
                                SetText(text);
                                enableClickOk = true;
                                Console.WriteLine("doc thanh cong: " + text);
                            }
                            else if (text != null && text.Length == 0)
                            {
                                Console.WriteLine("doc ko thanh cong r");
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("send memory: " + e.Message);
                }
            }
        }

        //Set text cho txtResult
        private void SetText(string text)
        {
            if (this.txtResult.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.txtResult.Text = text;
            }
        }
        #endregion

        #region Pipe
        //gửi bằng giao thức pipe
        private void SendWithPipe()
        {
            var anotherProcess = new Process
            {
                StartInfo =
                    {
                        FileName = @"C:\Users\hp\Desktop\Bài tập\BaiTapLyThuyetHeDieuHanh\BaiTapLyThuyetHeDieuHanh\ProcessPipe\bin\Debug\ProcessPipe.exe",
                        CreateNoWindow = false,
                        UseShellExecute = false
                    }
            };
            //chạy tiến trình con
            anotherProcess.Start();

            //khởi tạo client để gửi
            _pipeClient = new PipeClient();
            _pipeClient.Send(stringBuilder.ToString(), nameServerSend, 1000);
            enableClickOk = false;
        }

        //lắng nghe bên pipe trả kết quả về
        private void ListenResultPipe(string message)
        {
            try
            {
                //nếu không yêu cầu sẽ nhảy vào if, ngược lại sẽ nhảy vào else và hiển thị kết quả
                if (this.InvokeRequired)
                {
                    this.Invoke(new NewMessageDelegate(ListenResultPipe), message);
                }
                else
                {
                    //hiển thị kết quả
                    txtResult.Text = message;
                    enableClickOk = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        #endregion

        #region Exit Application
        //Khi đóng form trả server và client về null
        private void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            _pipeServer.PipeMessage -= new DelegateMessage(ListenResultPipe);
            _pipeServer = null;
            _pipeClient = null;
        }
        #endregion
    }
}
