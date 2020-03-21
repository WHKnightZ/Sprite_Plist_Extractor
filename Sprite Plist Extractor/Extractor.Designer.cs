namespace Sprite_Plist_Extractor
{
    partial class Extractor
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
            this.btnConvert = new System.Windows.Forms.Button();
            this.btnChoose = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // btnConvert
            // 
            this.btnConvert.Location = new System.Drawing.Point(107, 70);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(75, 23);
            this.btnConvert.TabIndex = 4;
            this.btnConvert.Text = "Extract";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // btnChoose
            // 
            this.btnChoose.Location = new System.Drawing.Point(93, 30);
            this.btnChoose.Name = "btnChoose";
            this.btnChoose.Size = new System.Drawing.Size(99, 23);
            this.btnChoose.TabIndex = 3;
            this.btnChoose.Text = "Choose Plist";
            this.btnChoose.UseVisualStyleBackColor = true;
            this.btnChoose.Click += new System.EventHandler(this.btnChoose_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            this.openFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog_FileOk);
            // 
            // Extractor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 122);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.btnChoose);
            this.Name = "Extractor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sprite Plist Extractor";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.Button btnChoose;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}

