using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyTimer {
    public partial class SelectTimeSpanForm : Form {
        internal TimeSpan defaultTimeSpan;
        internal TimeSpan returnedTimeSpan;
        private static string lastInputString = "";

        public SelectTimeSpanForm() {
            InitializeComponent();

        }

        private void SelectTimeSpanForm_Load(object sender, EventArgs e) {
            btnDefaultTime.SupplementalExplanation = Form1.getTimeSpanDescription(defaultTimeSpan);
            inputTimeTextBox.Text = lastInputString;
            inputTimeTextBox_TextChanged(null, null);
        }
        private void btnDefaultTime_Click(object sender, EventArgs e) {
            returnedTimeSpan = defaultTimeSpan;
        }

        private void btn3min_Click(object sender, EventArgs e) {
            returnedTimeSpan = new TimeSpan(0, 3, 0);
            Hide();
        }

        private void btn10min_Click(object sender, EventArgs e) {
            returnedTimeSpan = new TimeSpan(0, 10, 0);
            Hide();
        }
        private void btnCustom_Click(object sender, EventArgs e) {
            Hide();
        }

        private void inputTimeTextBox_TextChanged(object sender, EventArgs e) {
            lastInputString = inputTimeTextBox.Text;
            if (lastInputString.Length > 0 || lastInputString.Length <= 8) {
                bool isAllNumbers = true;
                for (int i = 0; i < lastInputString.Length; i++) {
                    if (lastInputString[i] < '0' || lastInputString[i] > '9') {
                        isAllNumbers = false;
                        break;
                    }
                }
                if (isAllNumbers) {
                    returnedTimeSpan = Form1.parseTimeString(lastInputString);
                    btnCustom.Enabled = true;
                    btnCustom.SupplementalExplanation = Form1.getTimeSpanDescription(returnedTimeSpan);
                } else {
                    btnCustom.Enabled = false;
                    btnCustom.SupplementalExplanation = "无效输入";
                }
            }
            else {
                btnCustom.Enabled = false;
                if (lastInputString.Length == 0)
                    btnCustom.SupplementalExplanation = "";
                else
                    btnCustom.SupplementalExplanation = "不能超过8个数字";
            }
        }
    }
}
