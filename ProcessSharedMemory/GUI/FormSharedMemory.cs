using BaiTapLyThuyetHeDieuHanh;
using MaterialSkin;
using ProcessMessageQueue.Until;
using System;
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
        //Tên file send trong shared memory
        private static string fileSend = "file-send";
        //tên file receiver trong shared memory
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

        //lấy dữ liệu từ process cha gửi đến bằng cách đọc file nhớ chung
        private void GetData()
        {
            try
            {
                //khởi tạo memoryMapperFile với tên file là file-send
                using (MemoryMappedFile memoryMappedFile = MemoryMappedFile.OpenExisting(fileSend))
                {
                    //sử dụng viewAccessor để ánh xạ tới bộ nhớ cần truy câp
                    using (MemoryMappedViewAccessor viewAccessor = memoryMappedFile.CreateViewAccessor())
                    {
                        //khởi tạo 1 byte để đọc dữ liệu
                        byte[] bytes = new byte[100];
                        //đọc dữ liệu từ file chung
                        int res = viewAccessor.ReadArray(0, bytes, 0, bytes.Length);
                        //định dạng từ byte thành kiểu string
                        string text = Encoding.UTF8.GetString(bytes).Trim('\0');
                        //đọc nếu dữ liệu ko trống
                        if (text != null && text.Length > 0)
                        {
                            _receiver = text;
                            txtReceiver.Text = TextState.TXTRECIVER + _receiver;
                            lockT = false;
                            Console.WriteLine("giatri: " + text);
                            Caculation();
                        }

                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        //tính toán
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

        //gửi trả dữ liệu về process cha
        private void SendResult()
        {
            new Thread(() =>
            {
                MemoryMappedFile memoryMappedFile = MemoryMappedFile.CreateOrOpen(fileReceiver, 10000);
                MemoryMappedViewAccessor viewAccessor = memoryMappedFile.CreateViewAccessor();
                byte[] textBytes = Encoding.UTF8.GetBytes(_result);
                viewAccessor.WriteArray(0, textBytes, 0, textBytes.Length);
                Close();
            }).Start();
        }
        
        private void SetupText()
        {
            txtReceiver.Text = TextState.TXTRECIVER;
            txtResult.Text = TextState.TXTRESULT;
            txtState.Text = TextState.STATENOTSEND;
        }
    }
}
