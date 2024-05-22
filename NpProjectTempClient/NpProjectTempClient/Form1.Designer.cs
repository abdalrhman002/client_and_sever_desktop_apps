namespace NpProjectTempClient
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.send_msg = new System.Windows.Forms.Button();
            this.browse_dir = new System.Windows.Forms.Button();
            this.get_file = new System.Windows.Forms.Button();
            this.connect = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.close = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(24, 49);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(457, 219);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(24, 312);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(246, 20);
            this.textBox1.TabIndex = 1;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(24, 376);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(246, 20);
            this.textBox2.TabIndex = 2;
            // 
            // send_msg
            // 
            this.send_msg.Enabled = false;
            this.send_msg.Location = new System.Drawing.Point(328, 287);
            this.send_msg.Name = "send_msg";
            this.send_msg.Size = new System.Drawing.Size(153, 45);
            this.send_msg.TabIndex = 3;
            this.send_msg.Text = "Send Msg";
            this.send_msg.UseVisualStyleBackColor = true;
            this.send_msg.Click += new System.EventHandler(this.send_msg_Click);
            // 
            // browse_dir
            // 
            this.browse_dir.Enabled = false;
            this.browse_dir.Location = new System.Drawing.Point(328, 351);
            this.browse_dir.Name = "browse_dir";
            this.browse_dir.Size = new System.Drawing.Size(153, 45);
            this.browse_dir.TabIndex = 4;
            this.browse_dir.Text = "Browse Dir ";
            this.browse_dir.UseVisualStyleBackColor = true;
            this.browse_dir.Click += new System.EventHandler(this.browse_dir_Click);
            // 
            // get_file
            // 
            this.get_file.Enabled = false;
            this.get_file.Location = new System.Drawing.Point(624, 351);
            this.get_file.Name = "get_file";
            this.get_file.Size = new System.Drawing.Size(153, 45);
            this.get_file.TabIndex = 5;
            this.get_file.Text = "Get File";
            this.get_file.UseVisualStyleBackColor = true;
            this.get_file.Click += new System.EventHandler(this.get_file_Click);
            // 
            // connect
            // 
            this.connect.Location = new System.Drawing.Point(624, 49);
            this.connect.Name = "connect";
            this.connect.Size = new System.Drawing.Size(152, 47);
            this.connect.TabIndex = 6;
            this.connect.Text = "Connect";
            this.connect.UseVisualStyleBackColor = true;
            this.connect.Click += new System.EventHandler(this.connect_Click);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(549, 300);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(228, 20);
            this.textBox3.TabIndex = 7;
            // 
            // close
            // 
            this.close.Location = new System.Drawing.Point(624, 221);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(152, 47);
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
            this.Controls.Add(this.connect);
            this.Controls.Add(this.get_file);
            this.Controls.Add(this.browse_dir);
            this.Controls.Add(this.send_msg);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.richTextBox1);
            this.Name = "Form1";
            this.Text = "Client";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button send_msg;
        private System.Windows.Forms.Button browse_dir;
        private System.Windows.Forms.Button get_file;
        private System.Windows.Forms.Button connect;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button close;
    }
}

