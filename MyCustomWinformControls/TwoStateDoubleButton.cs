using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

// https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.radiobutton?view=windowsdesktop-7.0
// https://stackoverflow.com/questions/24687959/is-it-possible-to-create-a-windows-form-in-a-c-sharp-class-library

namespace CustomWinformControlLib
{
    public partial class TwoStateDoubleButton : UserControl
    {
        readonly GroupBox groupBox1 = new GroupBox();
        RectangleFlatRadioButton radioButton1 = new RectangleFlatRadioButton(true);
        RectangleFlatRadioButton radioButton2 = new RectangleFlatRadioButton(true);
        // RectangleFlatRadioButton radioButton1 = new RectangleFlatRadioButton();
        // RectangleFlatRadioButton radioButton2 = new RectangleFlatRadioButton();
        // this.getSelectedRB = new System.Windows.Forms.Button();

        public TwoStateDoubleButton()
        {
              InitializeComponent(); 
        }

        public TwoStateDoubleButton(string stateA, string stateB)
        {
            InitializeComponent();
            SuspendLayout();

            radioButton1.Text = stateA;
            radioButton1.Name = "radioButton1";
            radioButton1.Checked = true;

            radioButton2.Text = stateB;
            radioButton2.Name = "radioButton2";
            radioButton2.Checked = false;


            // RadioButton AutoSize is false by default, so why does this work?
            // Guess PreferredSize is not dependent upon AutoSize
            radioButton1.Size = new Size(radioButton1.PreferredSize.Width, radioButton1.PreferredSize.Height);
            radioButton2.Size = new Size(radioButton2.PreferredSize.Width, radioButton2.PreferredSize.Height);
            radioButton1.Location = new Point(0, 0);
            radioButton2.Location = new Point(radioButton1.PreferredSize.Width , 0);

            Size = new Size(radioButton1.PreferredSize.Width + radioButton2.PreferredSize.Width +3, radioButton1.PreferredSize.Height + 3);
          //  Size = new Size(radioButton1.PreferredSize.Width + radioButton1.PreferredSize.Width + (Padding * 3), Height);
            Controls.Add(radioButton1);
            Controls.Add(radioButton2);
            // BorderStyle = BorderStyle.FixedSingle;

            AddEventHandlerForRadioButton1Clicking();

            ResumeLayout();
        }

        private void AddEventHandlerForRadioButton1Clicking()
        {
            radioButton1.CheckedChanged += RadioButton1_CheckedChanged;
        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            bool currentStateOfButton1 = ((RectangleFlatRadioButton)sender).Checked;
            Debug.WriteLine("Checked state:" + currentStateOfButton1 + ", Button Name: " + ((RectangleFlatRadioButton)sender).Name );
            
            StateChangedEventArgs args = new StateChangedEventArgs();
            args.IsSelected = currentStateOfButton1;
            OnStateChanged(args);
        }

        public string GetButtonsStates()
        {
            string msg =  radioButton1.GetText() + ", state:" + radioButton1.GetCheckedState();
            msg += " :: " + radioButton2.GetText() + ", state:" + radioButton2.GetCheckedState();
            return msg;
        }

        //public int Height { get; set; } = 25;
        //public int Padding { get; set; } = 6;

        // https://learn.microsoft.com/en-us/dotnet/standard/events/
        // going to create a custom event for when the state changes... nope.
        // instead going to use the .Net built in EventHandler
        // https://learn.microsoft.com/en-us/dotnet/api/system.eventhandler?view=net-7.0

        public event EventHandler<StateChangedEventArgs> StateChanged;

        protected virtual void OnStateChanged(StateChangedEventArgs e)
        {
            StateChanged?.Invoke(this, e);
        }
    }

    public class StateChangedEventArgs : EventArgs
    {
        public bool IsSelected { get; set; }
    }


}
