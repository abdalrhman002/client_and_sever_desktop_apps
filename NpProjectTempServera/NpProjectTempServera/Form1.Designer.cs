namespace NpProjectTempServera
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
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.send_msg = new System.Windows.Forms.Button();
            this.send_dir_contant = new System.Windows.Forms.Button();
            this.send_file = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.listen = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.close = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(18, 30);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(479, 232);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // send_msg
            // 
            this.send_msg.Enabled = false;
            this.send_msg.Location = new System.Drawing.Point(357, 289);
            this.send_msg.Name = "send_msg";
            this.send_msg.Size = new System.Drawing.Size(140, 37);
            this.send_msg.TabIndex = 1;
            this.send_msg.Text = "Send Msg";
            this.send_msg.UseVisualStyleBackColor = true;
            this.send_msg.Click += new System.EventHandler(this.send_msg_Click);
            // 
            // send_dir_contant
            // 
            this.send_dir_contant.Enabled = false;
            this.send_dir_contant.Location = new System.Drawing.Point(357, 360);
            this.send_dir_contant.Name = "send_dir_contant";
            this.send_dir_contant.Size = new System.Drawing.Size(140, 37);
            this.send_dir_contant.TabIndex = 2;
            this.send_dir_contant.Text = "Send Dir Contant";
            this.send_dir_contant.UseVisualStyleBackColor = true;
            this.send_dir_contant.Click += new System.EventHandler(this.send_dir_contant_Click);
            // 
            // send_file
            // 
            this.send_file.Enabled = false;
            this.send_file.Location = new System.Drawing.Point(635, 360);
            this.send_file.Name = "send_file";
            this.send_file.Size = new System.Drawing.Size(140, 37);
            this.send_file.TabIndex = 3;
            this.send_file.Text = "Send File";
            this.send_file.UseVisualStyleBackColor = true;
            this.send_file.Click += new System.EventHandler(this.send_file_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(18, 306);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(268, 20);
            this.textBox1.TabIndex = 4;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(18, 377);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(268, 20);
            this.textBox2.TabIndex = 5;
            // 
            // listen
            // 
            this.listen.Location = new System.Drawing.Point(635, 30);
            this.listen.Name = "listen";
            this.listen.Size = new System.Drawing.Size(140, 41);
            this.listen.TabIndex = 6;
            this.listen.Text = "Listen";
            this.listen.UseVisualStyleBackColor = true;
            this.listen.Click += new System.EventHandler(this.listen_Click);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(547, 306);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(228, 20);
            this.textBox3.TabIndex = 7;
            // 
            // close
            // 
            this.close.Location = new System.Drawing.Point(635, 221);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(140, 41);
            this.close.TabIndex = 8;
            this.close.Text = "Close";
            this.close.UseVisualStyleBackColor = true;
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.close);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.listen);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.send_file);
            this.Controls.Add(this.send_dir_contant);
            this.Controls.Add(this.send_msg);
            this.Controls.Add(this.richTextBox1);
            this.Name = "Form1";
            this.Text = "Server";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button send_msg;
        private System.Windows.Forms.Button send_dir_contant;
        private System.Windows.Forms.Button send_file;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button listen;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button close;
    }
}

