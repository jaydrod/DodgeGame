namespace DodgeGame
{
    partial class ScoreScreen
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
            this.scoreoutputLable = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // scoreoutputLable
            // 
            this.scoreoutputLable.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.scoreoutputLable.Location = new System.Drawing.Point(0, 0);
            this.scoreoutputLable.Name = "scoreoutputLable";
            this.scoreoutputLable.Size = new System.Drawing.Size(294, 264);
            this.scoreoutputLable.TabIndex = 0;
            // 
            // ScoreScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.Controls.Add(this.scoreoutputLable);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ScoreScreen";
            this.Size = new System.Drawing.Size(294, 264);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.ScoreScreen_PreviewKeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label scoreoutputLable;
    }
}
