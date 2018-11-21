using BaiTapLyThuyetHeDieuHanh;
using MaterialSkin;
using ProcessMessageQueue.Until;
using System;
using System.Diagnostics;
using System.IO.MemoryMappedFiles;
using System.Linq.Expressions;
using System.Text;
using System.Threading;

namespace ProcessSharedMemory
{
    public partial class Form1 : MaterialSkin.Controls.MaterialForm
    {
        private string _receiver = "";
        private string _result = "";
        private static string fileSend = "file-send";
        private static string fileReceiver = "file-reiceiver";
        private static string fileSuccess = "file-success";

        private bool lockT = true;
        private bool lockW = true;

        private Thread threadSuccess;

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
            while (lockT) { GetData(); }

        }

        private void GetData()
        {
            try
            {
                using (MemoryMappedFile memoryMappedFile = MemoryMappedFile.OpenExisting(fileSend))
                {
                    using (MemoryMappedViewAccessor viewAccessor = memoryMappedFile.CreateViewAccessor())
                    {
                        byte[] bytes = new byte[100];
                        int res = viewAccessor.ReadArray(0, bytes, 0, bytes.Length);
                        string text = Encoding.UTF8.GetString(bytes).Trim('\0');
                        _receiver = text;
                        txtReceiver.Text = TextState.TXTRECIVER + _receiver;
                        lockT = false;
                        Console.WriteLine("giatri: " + text);

                        Caculation();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void Caculation()
        {
            try
            {
                Scanner scanner = new Scanner(_receiver);
                Parser parser = new Parser(scanner);
                Expression expr = parser.Parse();

                Delegate func = Expression.Lambda(expr).Compile();

                _result = func.DynamicInvoke().ToString();

                txtResult.Text = TextState.TXTRESULT + _result;

               // SendResult();
            }
            catch (Exception e)
            {
                _result = e.Message;
                txtResult.Text = e.Message;
               // SendResult();
            }
        }

        private void SendResult()
        {
            using (MemoryMappedFile memoryMappedFile = MemoryMappedFile.CreateNew(fileReceiver,10000))
            {
                using (MemoryMappedViewAccessor viewAccessor = memoryMappedFile.CreateViewAccessor())
                {
                    byte[] textBytes = Encoding.UTF8.GetBytes(_result);
                    viewAccessor.WriteArray(0, textBytes, 0, textBytes.Length);
                }
            }
            txtState.Text = _result;
            Thread.Sleep(50000);
        }

        private bool lockS = true;

        private void ListenSuccess()
        {
            while (lockS)
            {
                using (MemoryMappedFile memoryMappedFile = MemoryMappedFile.CreateNew(fileSuccess, 10000))
                {
                    using (MemoryMappedViewAccessor viewAccessor = memoryMappedFile.CreateViewAccessor())
                    {
                        byte[] textBytes = Encoding.UTF8.GetBytes(_result);
                        viewAccessor.WriteArray(0, textBytes, 0, textBytes.Length);
                    }
                    lockS = false;
                    lockW = false;
                    if (threadSuccess != null)
                    {
                        threadSuccess.Abort();
                    }
                }
            }

        }

        private void SetupText()
        {
            txtReceiver.Text = TextState.TXTRECIVER;
            txtResult.Text = TextState.TXTRESULT;
            txtState.Text = TextState.STATENOTSEND;
        }
    }
}
