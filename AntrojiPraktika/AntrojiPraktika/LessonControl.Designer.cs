namespace AntrojiPraktika
{
    partial class LessonControl
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
            this.labelCousename = new System.Windows.Forms.Label();
            this.labelteachername = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelCousename
            // 
            this.labelCousename.AutoSize = true;
            this.labelCousename.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCousename.ForeColor = System.Drawing.Color.Blue;
            this.labelCousename.Location = new System.Drawing.Point(18, 13);
            this.labelCousename.Name = "labelCousename";
            this.labelCousename.Size = new System.Drawing.Size(57, 20);
            this.labelCousename.TabIndex = 0;
            this.labelCousename.Text = "label1";
            // 
            // labelteachername
            // 
            this.labelteachername.AutoSize = true;
            this.labelteachername.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelteachername.ForeColor = System.Drawing.Color.Blue;
            this.labelteachername.Location = new System.Drawing.Point(18, 49);
            this.labelteachername.Name = "labelteachername";
            this.labelteachername.Size = new System.Drawing.Size(57, 20);
            this.labelteachername.TabIndex = 1;
            this.labelteachername.Text = "label2";
            // 
            // LessonControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.Controls.Add(this.labelteachername);
            this.Controls.Add(this.labelCousename);
            this.Name = "LessonControl";
            this.Size = new System.Drawing.Size(228, 77);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelCousename;
        private System.Windows.Forms.Label labelteachername;
    }
}
