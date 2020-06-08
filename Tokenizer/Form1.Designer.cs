namespace Tokenizer
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
            this.sourceTextbox = new System.Windows.Forms.RichTextBox();
            this.fileButton = new System.Windows.Forms.Button();
            this.tokenTextbox = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // sourceTextbox
            // 
            this.sourceTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.sourceTextbox.Location = new System.Drawing.Point(43, 47);
            this.sourceTextbox.Name = "sourceTextbox";
            this.sourceTextbox.Size = new System.Drawing.Size(350, 362);
            this.sourceTextbox.TabIndex = 0;
            this.sourceTextbox.Text = "";
            // 
            // fileButton
            // 
            this.fileButton.Location = new System.Drawing.Point(399, 424);
            this.fileButton.Name = "fileButton";
            this.fileButton.Size = new System.Drawing.Size(241, 43);
            this.fileButton.TabIndex = 1;
            this.fileButton.Text = "Load From File";
            this.fileButton.UseVisualStyleBackColor = true;
            this.fileButton.Click += new System.EventHandler(this.fileButton_Click);
            // 
            // tokenTextbox
            // 
            this.tokenTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.tokenTextbox.Location = new System.Drawing.Point(399, 47);
            this.tokenTextbox.Name = "tokenTextbox";
            this.tokenTextbox.Size = new System.Drawing.Size(350, 362);
            this.tokenTextbox.TabIndex = 2;
            this.tokenTextbox.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(173, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 24);
            this.label1.TabIndex = 3;
            this.label1.Text = "SOURCE";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(537, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 24);
            this.label2.TabIndex = 4;
            this.label2.Text = "TOKENS";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(146, 424);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(241, 43);
            this.button1.TabIndex = 5;
            this.button1.Text = "Get Tokens";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 479);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tokenTextbox);
            this.Controls.Add(this.fileButton);
            this.Controls.Add(this.sourceTextbox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox sourceTextbox;
        private System.Windows.Forms.Button fileButton;
        private System.Windows.Forms.RichTextBox tokenTextbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
    }
}

