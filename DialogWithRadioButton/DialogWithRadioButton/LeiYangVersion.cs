using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// https://stackoverflow.com/questions/44427395/how-to-create-dialog-box-with-radio-buttons-and-return-value

namespace DialogWithRadioButton
{
    public class LeiYangVersion : Form
    {
        public string selectedString;
        public LeiYangVersion()
        {
            InitializeComponent();
        }
        public LeiYangVersion(IList<string> lst)
        {
            InitializeComponent();
            for (int i = 0; i < lst.Count; i++)
            {
                RadioButton rdb = new RadioButton();
                rdb.Text = lst[i];
                rdb.Size = new Size(100, 30);
                this.Controls.Add(rdb);
                rdb.Location = new Point(20, 20 + 35 * i);
                rdb.CheckedChanged += (s, ee) =>
                {
                    var r = s as RadioButton;
                    if (r.Checked)
                        this.selectedString = r.Text;
                };
            }
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void InitializeComponent()
        {
            //this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "Form1";
        }
    }
}
