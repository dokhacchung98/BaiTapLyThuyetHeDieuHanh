using BaiTapLyThuyetHeDieuHanh;
using MaterialSkin;
using ProcessMessageQueue.Until;
using System;
using System.IO.MemoryMappedFiles;
using System.Linq.Expressions;
using System.Text;

namespace ProcessSharedMemory
{
    public partial class Form1 : MaterialSkin.Controls.MaterialForm
    {
        private string _receiver = "";
        private string _result = "";
        private static string fileSend = "file-send";
        private static string fileReceiver = "file-reiceiver";

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
                            Console.WriteLine("giatri: " + text);
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

                SendResult();
            }
            catch (Exception e)
            {
                _result = e.Message;
                txtResult.Text = e.Message;
                SendResult();
            }
        }

        private void SendResult()
        {
            using (MemoryMappedFile memoryMappedFile = MemoryMappedFile.CreateNew(fileReceiver, 10000))
            {
                using (MemoryMappedViewAccessor viewAccessor = memoryMappedFile.CreateViewAccessor())
                {
                    byte[] textBytes = Encoding.UTF8.GetBytes(_result);
                    viewAccessor.WriteArray(0, textBytes, 0, textBytes.Length);
                }
                //Thread.Sleep(100);
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
