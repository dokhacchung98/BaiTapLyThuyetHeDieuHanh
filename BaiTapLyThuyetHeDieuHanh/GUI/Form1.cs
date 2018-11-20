using MaterialSkin;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Messaging;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace BaiTapLyThuyetHeDieuHanh
{
    public partial class FormMain : MaterialSkin.Controls.MaterialForm
    {
        private StringBuilder stringBuilder;
        private int _communicationType;

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

            SetupButton();
        }

        private void handleUsingKeyboard()
        {
            while (true)
            {
                Console.WriteLine("a");
                Thread.Sleep(10000);
            }
        }

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

        private void SetupFont()
        {

        }

        private void FormMain_Load(object sender, EventArgs e)
        {

        }

        #region XuLyClick
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


        /*Gửi dữ liệu giữa 2 process sử dụng message queue*/
        private void SendWithMessageQueue()
        {

            var anotherProcess = new Process
            {
                StartInfo =
                {
                    FileName = @"C:\Users\hp\Desktop\Bài tập\BaiTapLyThuyetHeDieuHanh\BaiTapLyThuyetHeDieuHanh\ProcessMessageQueue\bin\Debug\ProcessMessageQueue.exe",
                    CreateNoWindow = true,
                    UseShellExecute = false
                }
            };

            anotherProcess.Start();

            using (MessageQueue msgQueue = new MessageQueue())
            {
                msgQueue.Path = @".\private$\baitaplthdhSend";
                if (!MessageQueue.Exists(msgQueue.Path))
                {
                    MessageQueue.Create(msgQueue.Path);
                }
                System.Messaging.Message message = new System.Messaging.Message();
                message.Body = stringBuilder.ToString();
                message.BodyType = 1;
                msgQueue.Send(message);

                ListeningResultMessageQueue(anotherProcess);
            }
        }

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
            }
        }

        private void SendWithSharedMemory()
        {

        }

        private void ListenResultShareMemory()
        {

        }

        private void SendWithPipe()
        {

        }

        private void ListenResultPipe()
        {

        }

    }
}
