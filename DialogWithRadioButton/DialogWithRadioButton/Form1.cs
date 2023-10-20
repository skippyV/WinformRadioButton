using CustomWinformControlLib;

namespace DialogWithRadioButton
{
    public partial class Form1 : Form
    {
        private readonly string TwoStateDoubleButtonName = "TwoStateDoubleButton";
        private TwoStateDoubleButton TwoStateDoubleButtonInstance;
        private Label StateLabel;

        public Form1()
        {
            InitializeComponent();
            //AddTwoModeScrollBarButton();
            AddTwoModeButton();
            AddCheckedStateLabel();
        }

        private void AddCheckedStateLabel()
        {
            StateLabel = new Label
            {
                Location = new Point(230, 40),
            };
            StateLabel.Size = new Size(350, StateLabel.Size.Height);
            TwoStateDoubleButton contrl = (TwoStateDoubleButton)Controls[TwoStateDoubleButtonName];
            StateLabel.Text = contrl.GetButtonsStates();
            Controls.Add(StateLabel);
        }

        private void DisplayState(object? sender, StateChangedEventArgs e)
        {
            StateLabel.Text = "state: " + e.IsSelected;
        }

        private void AddTwoModeButton()
        {
            TwoStateDoubleButtonInstance = new TwoStateDoubleButton("1234567", "1234567890123");
            TwoStateDoubleButtonInstance.Name = TwoStateDoubleButtonName;
            TwoStateDoubleButtonInstance.Location = new Point(30, 40);
            TwoStateDoubleButtonInstance.StateChanged += DisplayState;
            Controls.Add(TwoStateDoubleButtonInstance);
        }

        private void AddTwoModeScrollBarButton() // gave up on this idea
        {
            TwoModeHorizontalSelectorScrollBar twoModeScrollButton = new TwoModeHorizontalSelectorScrollBar();
            twoModeScrollButton.Location = new Point(30, 40);
            twoModeScrollButton.Size = new Size(130, 30);
            twoModeScrollButton.Visible = true;
            twoModeScrollButton.BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(twoModeScrollButton);
            // TODO - how to update this text? how to bind to an event of a sub-control button?
            // somehow have to expose that event?  TODO TODO
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var list = new List<string>() { "a", "b", "c" };
            LeiYangVersion dlg = new LeiYangVersion(list);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string selected = dlg.selectedString;
                MessageBox.Show(selected);
            }
        }



 
    }
}