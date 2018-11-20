namespace ProcessMessageQueue
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
            this.txtReciver = new MaterialSkin.Controls.MaterialLabel();
            this.txtState = new MaterialSkin.Controls.MaterialLabel();
            this.txtResult = new MaterialSkin.Controls.MaterialLabel();
            this.SuspendLayout();
            // 
            // txtReciver
            // 
            this.txtReciver.Depth = 0;
            this.txtReciver.Font = new System.Drawing.Font("Roboto", 11F);
            this.txtReciver.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtReciver.Location = new System.Drawing.Point(32, 73);
            this.txtReciver.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtReciver.Name = "txtReciver";
            this.txtReciver.Size = new System.Drawing.Size(622, 54);
            this.txtReciver.TabIndex = 3;
            this.txtReciver.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtState
            // 
            this.txtState.Depth = 0;
            this.txtState.Font = new System.Drawing.Font("Roboto", 11F);
            this.txtState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtState.Location = new System.Drawing.Point(32, 207);
            this.txtState.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtState.Name = "txtState";
            this.txtState.Size = new System.Drawing.Size(622, 54);
            this.txtState.TabIndex = 4;
            this.txtState.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtResult
            // 
            this.txtResult.Depth = 0;
            this.txtResult.Font = new System.Drawing.Font("Roboto", 11F);
            this.txtResult.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtResult.Location = new System.Drawing.Point(32, 140);
            this.txtResult.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(622, 54);
            this.txtResult.TabIndex = 5;
            this.txtResult.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 280);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.txtState);
            this.Controls.Add(this.txtReciver);
            this.Name = "Form1";
            this.Text = "Message Queue";
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel txtReciver;
        private MaterialSkin.Controls.MaterialLabel txtState;
        private MaterialSkin.Controls.MaterialLabel txtResult;
    }
}

