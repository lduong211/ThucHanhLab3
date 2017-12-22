using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimBoiVaUocChung.Forms
{
    public partial class TimBoiVaUoc : Form
    {
        public TimBoiVaUoc()
        {
            InitializeComponent();
        }
        private int numA;
        private int numB;
        string errormessage;
        private void btnResult_Click_1(object sender, EventArgs e)
        {
            string strA = txtNumA.Text;
            string strB = txtNumB.Text;
            //Kiem tra A va B co hop le khong
            if (IsValidNumber(strA, strB))
            {
                if(!rdUCLN.Checked && !rdBCNN.Checked)
                {
                    MessageBox.Show("Vui long chon phep tinh");
                    return;
                }
                //tinh theo phep tinh da chon
                int result;
                if (rdUCLN.Checked)
                    result = TimUCLN();
                else
                    result = TimBCNN();
                //hien ket qua len textbox
                txtResult.Text = result.ToString();
            }
            else
                MessageBox.Show(errormessage);
        }

        private int TimBCNN()
        {
            return (numA * numB) / TimUCLN();
        }

        private int TimUCLN()
        {
            while(numA != numB)
            {
                if (numA > numB)
                    numA -= numB;
                else
                    numB -= numA;
            }
            return numA;
        }

        /// <summary>
        /// Ham kiem tra A va B co hop le khong
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private bool IsValidNumber(string a, string b)
        {
            errormessage = "";
            if(string.IsNullOrEmpty(a))
            {
                errormessage += "Vui long nhap so A\n";
            }
            if (string.IsNullOrEmpty(b))
            {
                errormessage += "Vui long nhap so B\n";
            }
            try
            {
                numA = int.Parse(a);
                numB = int.Parse(b);
            }
            catch (Exception)
            {
                errormessage += "A hoac B khong phai la so\n";
            }
            //neu A va B la so tra ve true, nguoc lai la false
            return (errormessage == "") ? true : false;
        }
    }
}
