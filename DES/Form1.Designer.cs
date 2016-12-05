namespace DES
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btn_encrypt = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.btn_decrypt = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.text_string = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.radio_bin = new System.Windows.Forms.RadioButton();
            this.radio_string = new System.Windows.Forms.RadioButton();
            this.btn_convert = new System.Windows.Forms.Button();
            this.text_bin = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(93, 23);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(146, 21);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "Bits or characters";
            // 
            // btn_encrypt
            // 
            this.btn_encrypt.BackColor = System.Drawing.Color.Lime;
            this.btn_encrypt.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_encrypt.Font = new System.Drawing.Font("Tempus Sans ITC", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_encrypt.Location = new System.Drawing.Point(245, 60);
            this.btn_encrypt.Name = "btn_encrypt";
            this.btn_encrypt.Size = new System.Drawing.Size(65, 22);
            this.btn_encrypt.TabIndex = 1;
            this.btn_encrypt.Text = "ENCRYPT";
            this.btn_encrypt.UseVisualStyleBackColor = false;
            this.btn_encrypt.Click += new System.EventHandler(this.btn_encrypt_Click);
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(93, 59);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(146, 21);
            this.textBox2.TabIndex = 2;
            this.textBox2.Tag = "";
            this.textBox2.Text = "16 bits or 2 chars";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DimGray;
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.btn_decrypt);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.textBox3);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.btn_encrypt);
            this.panel1.Location = new System.Drawing.Point(12, 55);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(319, 147);
            this.panel1.TabIndex = 4;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox1.Location = new System.Drawing.Point(255, 26);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(41, 17);
            this.checkBox1.TabIndex = 11;
            this.checkBox1.Text = "BIN";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // btn_decrypt
            // 
            this.btn_decrypt.BackColor = System.Drawing.Color.OrangeRed;
            this.btn_decrypt.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_decrypt.Font = new System.Drawing.Font("Tempus Sans ITC", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_decrypt.Location = new System.Drawing.Point(245, 96);
            this.btn_decrypt.Name = "btn_decrypt";
            this.btn_decrypt.Size = new System.Drawing.Size(65, 22);
            this.btn_decrypt.TabIndex = 10;
            this.btn_decrypt.Text = "DECRYPT";
            this.btn_decrypt.UseVisualStyleBackColor = false;
            this.btn_decrypt.Click += new System.EventHandler(this.btn_decrypt_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Gill Sans Ultra Bold Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 22);
            this.label2.TabIndex = 9;
            this.label2.Text = "Cypher";
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(93, 95);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(146, 21);
            this.textBox3.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Gill Sans Ultra Bold Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(16, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 22);
            this.label3.TabIndex = 6;
            this.label3.Text = "Key";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Gill Sans Ultra Bold Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 22);
            this.label1.TabIndex = 4;
            this.label1.Text = "Message";
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(18, 23);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(205, 100);
            this.listBox1.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DimGray;
            this.panel2.Controls.Add(this.listBox1);
            this.panel2.Location = new System.Drawing.Point(346, 55);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(240, 147);
            this.panel2.TabIndex = 7;
            // 
            // text_string
            // 
            this.text_string.Location = new System.Drawing.Point(21, 12);
            this.text_string.Name = "text_string";
            this.text_string.Size = new System.Drawing.Size(138, 20);
            this.text_string.TabIndex = 5;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel3.Controls.Add(this.radio_bin);
            this.panel3.Controls.Add(this.btn_convert);
            this.panel3.Controls.Add(this.text_bin);
            this.panel3.Controls.Add(this.radio_string);
            this.panel3.Controls.Add(this.text_string);
            this.panel3.Location = new System.Drawing.Point(12, 297);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(181, 119);
            this.panel3.TabIndex = 8;
            // 
            // radio_bin
            // 
            this.radio_bin.AutoSize = true;
            this.radio_bin.ForeColor = System.Drawing.SystemColors.Desktop;
            this.radio_bin.Location = new System.Drawing.Point(20, 63);
            this.radio_bin.Name = "radio_bin";
            this.radio_bin.Size = new System.Drawing.Size(80, 17);
            this.radio_bin.TabIndex = 9;
            this.radio_bin.TabStop = true;
            this.radio_bin.Text = "BinToString";
            this.radio_bin.UseVisualStyleBackColor = true;
            // 
            // radio_string
            // 
            this.radio_string.AutoSize = true;
            this.radio_string.ForeColor = System.Drawing.SystemColors.Desktop;
            this.radio_string.Location = new System.Drawing.Point(20, 38);
            this.radio_string.Name = "radio_string";
            this.radio_string.Size = new System.Drawing.Size(80, 17);
            this.radio_string.TabIndex = 8;
            this.radio_string.TabStop = true;
            this.radio_string.Text = "StringToBin";
            this.radio_string.UseVisualStyleBackColor = true;
            // 
            // btn_convert
            // 
            this.btn_convert.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_convert.Font = new System.Drawing.Font("Lucida Sans Unicode", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_convert.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btn_convert.Location = new System.Drawing.Point(106, 38);
            this.btn_convert.Name = "btn_convert";
            this.btn_convert.Size = new System.Drawing.Size(53, 42);
            this.btn_convert.TabIndex = 7;
            this.btn_convert.Text = "Go";
            this.btn_convert.UseVisualStyleBackColor = true;
            this.btn_convert.Click += new System.EventHandler(this.btn_convert_Click);
            // 
            // text_bin
            // 
            this.text_bin.Location = new System.Drawing.Point(21, 86);
            this.text_bin.Name = "text_bin";
            this.text_bin.Size = new System.Drawing.Size(138, 20);
            this.text_bin.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Tw Cen MT", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(38, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(518, 43);
            this.label4.TabIndex = 12;
            this.label4.Text = "DATA ENCRYPTION STANDARD";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Tw Cen MT", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DarkViolet;
            this.label5.Location = new System.Drawing.Point(237, 401);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(122, 15);
            this.label5.TabIndex = 13;
            this.label5.Text = "By Hristo, Ivana, Dimitar";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::DES.Properties.Resources.wallhaven_23173;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(598, 425);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btn_encrypt;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_decrypt;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox text_string;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton radio_bin;
        private System.Windows.Forms.RadioButton radio_string;
        private System.Windows.Forms.Button btn_convert;
        private System.Windows.Forms.TextBox text_bin;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}

