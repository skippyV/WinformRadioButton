// https://stackoverflow.com/questions/4325452/customize-windows-form-scrollbar/4326046#4326046

// I'm just trying to get a two position toggle type slider button for the two game 
// modes of my number picker winform. But using a scrollbar seems like a large task
// for this simple control.
// mayb it is better with a set of radio buttons interconnected so that one is opposite the other
// and both are using the button "format" as opposed to the radio button selector (typical) format 

namespace DialogWithRadioButton
{
    partial class TwoModeHorizontalSelectorScrollBar
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        }

        #endregion
    }
}
