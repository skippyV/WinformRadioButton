using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomWinformControlLib
{
    // https://stackoverflow.com/questions/38366222/circular-radiobutton-list-in-windows-forms
    // https://stackoverflow.com/questions/37484556/c-sharp-winforms-button-with-solid-border-like-3d
    // https://stackoverflow.com/questions/60956354/overridden-event-in-custom-control-executes-after-form-event
    // https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.radiobutton?view=windowsdesktop-7.0
    public class RectangleFlatRadioButton : RadioButton
    {
        private bool showDialog;
        public RectangleFlatRadioButton(bool showDialog = false)
        {
            Appearance = Appearance.Button;
            BackColor = Color.Transparent;
            TextAlign = ContentAlignment.MiddleCenter;
            FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            // this.FlatAppearance.BorderColor = Color.RoyalBlue;
            FlatAppearance.MouseOverBackColor = SystemColors.ControlLight;
            FlatAppearance.BorderSize = 0;
            this.showDialog = showDialog;
        }
        public string GetText()
        {
            return Text;
        }
        public bool GetCheckedState()
        {
            return (Checked ==  true);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            //ControlPaint.DrawBorder(e.Graphics, ClientRectangle,
            //    SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset,        
            //    SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset,
            //    SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset,
            //    SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset);
         //   Debug.WriteLine("OnPaint, Checked:{0}", Checked == true);

            if (Checked == true) // button is down
            {
                //Debug.WriteLine("OnPaint - button is down");
                //ControlPaint.DrawBorder(e.Graphics, ClientRectangle,
                //    System.Drawing.SystemColors.ControlLightLight, 2, ButtonBorderStyle.Outset,
                //    System.Drawing.SystemColors.ControlLightLight, 2, ButtonBorderStyle.Outset,
                //    System.Drawing.SystemColors.ControlLightLight, 2, ButtonBorderStyle.Outset,
                //    System.Drawing.SystemColors.ControlLightLight, 2, ButtonBorderStyle.Outset);



                // ControlPaint.FillReversibleRectangle(ClientRectangle, Color.AliceBlue);

                //SolidBrush brush = new SolidBrush(Color.Red);
                //e.Graphics.FillRectangle(brush, ClientRectangle);
                //brush.Dispose();

                ControlPaint.DrawBorder3D(e.Graphics, ClientRectangle,
                    Border3DStyle.Sunken);

                BackColor = Color.Green;
            }
            else
            {
                //Debug.WriteLine("OnPaint - button is UP");
                //ControlPaint.DrawBorder(e.Graphics, ClientRectangle,
                //    System.Drawing.SystemColors.ControlLightLight, 2, ButtonBorderStyle.Inset,
                //    System.Drawing.SystemColors.ControlLightLight, 2, ButtonBorderStyle.Inset,
                //    System.Drawing.SystemColors.ControlLightLight, 2, ButtonBorderStyle.Inset,
                //    System.Drawing.SystemColors.ControlLightLight, 2, ButtonBorderStyle.Inset);

                ControlPaint.DrawBorder3D(e.Graphics, ClientRectangle,
                    Border3DStyle.Raised);

                BackColor = Color.LightBlue;
            }
        }

        protected override void OnCheckedChanged(EventArgs e)
        {
            base.OnCheckedChanged(e);
            if (Checked == true)
            {
              //  Debug.WriteLine("OnCheckedChanged - Checked is TRUE");

            }
            else
            {
             //   Debug.WriteLine("OnCheckedChanged - Checked is FALSE");
            }
        }

        protected override void OnMouseDown(MouseEventArgs mevent)
        {
          //  Debug.WriteLine("OnMouseDown");
            base.OnMouseDown(mevent);
            // buttonIsDown = true;
            // Invalidate();
        }
        protected override void OnMouseUp(MouseEventArgs mevent)
        {
         //   Debug.WriteLine("OnMouseUp");
            base.OnMouseUp(mevent);
            //  buttonIsDown = false; 
            //  Invalidate();
        }

        protected override void OnClick(EventArgs e)
        {
            // at first was doing this below code from within OnCheckedChanged, but
            // that made the dialog open before the form was created. 
            // The below seemingly hackish workaround was found at 
            // https://stackoverflow.com/questions/3150882/how-to-prevent-value-changed-events-from-firing-on-form-initialization-in-net/3151100#3151100
            // But ultimately was not needed because I needed to add the dialog code
            // to the OnClick event handler.
            //
            //if (!this.IsHandleCreated) // seems hackish
            //{
            //    return;
            //}

            if (showDialog  && Checked != true)
            {
                const string message = "Are you sure? This will reset the number board";
                const string caption = "Reset and Start Over";

                DialogResult result = MessageBox.Show(message, caption,
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Question);

                if (result == DialogResult.No)
                {
                    return;
                }
            }
            base.OnClick(e);
        }
    }
}
