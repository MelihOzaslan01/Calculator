using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator2
{
    public partial class FrmMain : Form
    {
        private enum TOperationtType { OtNone, OtPlus, OtDiff, OtDiv, OtMult };
        private TOperationtType OperationtType = TOperationtType.OtNone;
        private double Result = 0;


        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            DoSetOffButton();
        }

        private void FrmMain_KeyPress(object sender, KeyPressEventArgs e)
        {
            DialogResult dr;
            if (e.KeyChar == 27)
            {
                dr = MessageBox.Show("Çıkmak İstediğinize Emin Misiniz", "Çıkış Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                    Application.Exit();

            }
        }
        private void NumberButtonsClick(object sender, EventArgs e)
        {
            string Anumber = ((Button)sender).Text;
            DoAddTextInfoTxtResult(Anumber);
        }

        private void DoSetOffButton()
        {
            foreach (Control BtnControl in PnlNumber.Controls)
            {
                Button button = BtnControl as Button;
                button.Click += NumberButtonsClick;
                string Number = button.Name.Replace("Btn","").Replace("Dot", ",");
                button.Text = Number;

            }
        }

        private void DoAddTextInfoTxtResult(string Akey)
        {
            if (Akey.Trim() == "")
                return;
            if (Akey == ",")
            {
                if (TxtResult.Text.IndexOf(",") > -1)
                    return;
                if (TxtResult.Text.Length == 0)
                    Akey = "0,";
            }
            if (TxtResult.Text == "0")
                TxtResult.Text = "0,";

            TxtResult.Text += Akey;
        }

        private void DoGetResultFromTxtResult()
        {
            Result = Convert.ToDouble(TxtResult.Text);
            TxtResult.Clear();
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            TxtResult.Clear();
        }

        private void BtnPlus_Click(object sender, EventArgs e)
        {
            OperationtType = TOperationtType.OtPlus;
            DoGetResultFromTxtResult();
        }

        private void BtnDifference_Click(object sender, EventArgs e)
        {
            OperationtType = TOperationtType.OtDiff;
            DoGetResultFromTxtResult();
        }

        private void BtnDiv_Click(object sender, EventArgs e)
        {
            OperationtType = TOperationtType.OtDiv;
            DoGetResultFromTxtResult();
        }

        private void BtnMult_Click(object sender, EventArgs e)
        {
            OperationtType = TOperationtType.OtMult;
            DoGetResultFromTxtResult();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DoCalculate();
        }

        private void DoCalculate()
        {
            switch (OperationtType)
            {
                case TOperationtType.OtNone:
                    break;
                case TOperationtType.OtPlus:
                    DoCalculatePlus();
                    break;
                case TOperationtType.OtDiff:
                    DoCalculateDiff();
                    break;
                case TOperationtType.OtDiv:
                    DoCalculateDiv();
                    break;
                case TOperationtType.OtMult:
                    DoCalculateMult();
                    break;
                default:
                    break;
            }
        }

        private void DoCalculatePlus()
        {
            double Avalue = Convert.ToDouble(TxtResult.Text);
            double AResult = Result + Avalue;
            TxtResult.Text = AResult.ToString();
        }

        private void DoCalculateDiff()
        {
            double Avalue = Convert.ToDouble(TxtResult.Text);
            double AResult = Result - Avalue;
            TxtResult.Text = AResult.ToString();
        }

        private void DoCalculateDiv()
        {
            double Avalue = Convert.ToDouble(TxtResult.Text);
            double AResult = Result / Avalue;
            TxtResult.Text = AResult.ToString();
        }

        private void DoCalculateMult()
        {
            double Avalue = Convert.ToDouble(TxtResult.Text);
            double AResult = Result * Avalue;
            TxtResult.Text = AResult.ToString();
        }

       
    }
}
