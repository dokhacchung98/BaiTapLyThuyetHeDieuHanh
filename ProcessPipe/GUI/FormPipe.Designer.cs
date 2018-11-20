namespace ProcessPipe
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtReceiver = new MaterialSkin.Controls.MaterialLabel();
            this.txtResult = new MaterialSkin.Controls.MaterialLabel();
            this.txtState = new MaterialSkin.Controls.MaterialLabel();
            this.SuspendLayout();
            // 
            // txtReceiver
            // 
            this.txtReceiver.Depth = 0;
            this.txtReceiver.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.txtReceiver.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtReceiver.Location = new System.Drawing.Point(26, 81);
            this.txtReceiver.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtReceiver.Name = "txtReceiver";
            this.txtReceiver.Size = new System.Drawing.Size(748, 50);
            this.txtReceiver.TabIndex = 0;
            this.txtReceiver.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtResult
            // 
            this.txtResult.Depth = 0;
            this.txtResult.Font = new System.Drawing.Font("Roboto", 11F);
            this.txtResult.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtResult.Location = new System.Drawing.Point(26, 143);
            this.txtResult.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(748, 50);
            this.txtResult.TabIndex = 1;
            this.txtResult.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtState
            // 
            this.txtState.Depth = 0;
            this.txtState.Font = new System.Drawing.Font("Roboto", 11F);
            this.txtState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtState.Location = new System.Drawing.Point(26, 206);
            this.txtState.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtState.Name = "txtState";
            this.txtState.Size = new System.Drawing.Size(748, 50);
            this.txtState.TabIndex = 2;
            this.txtState.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 283);
            this.Controls.Add(this.txtState);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.txtReceiver);
            this.Name = "Form1";
            this.Text = "Pipe";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel txtReceiver;
        private MaterialSkin.Controls.MaterialLabel txtResult;
        private MaterialSkin.Controls.MaterialLabel txtState;
    }
}

