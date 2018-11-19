using BaiTapLyThuyetHeDieuHanh.CallBack;
using MaterialSkin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTapLyThuyetHeDieuHanh
{
    public partial class FormMain : MaterialSkin.Controls.MaterialForm
    {
        private string expressMath = "";
        private StringBuilder stringBuilder;

        public FormMain()
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


            stringBuilder = new StringBuilder(expressMath);

            Font font = new Font("", 22);
            txtMathExpression.Font = font;

            SetupButton();
        }

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
        }

        private void SetupFont()
        {

        }

        private void FormMain_Load(object sender, EventArgs e)
        {

        }

        private void callProcess()
        {

        }

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
    }
}
