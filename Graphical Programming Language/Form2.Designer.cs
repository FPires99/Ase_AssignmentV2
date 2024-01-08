namespace Graphical_Programming_Language
{
    partial class Form2
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.RunButton2 = new System.Windows.Forms.Button();
            this.SyntaxButton = new System.Windows.Forms.Button();
            this.RunButton1 = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.LoadButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(45, 561);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(330, 20);
            this.textBox1.TabIndex = 15;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.Location = new System.Drawing.Point(540, 113);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(496, 517);
            this.panel1.TabIndex = 14;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(44, 151);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(331, 356);
            this.textBox2.TabIndex = 13;
            // 
            // RunButton2
            // 
            this.RunButton2.Location = new System.Drawing.Point(44, 607);
            this.RunButton2.Name = "RunButton2";
            this.RunButton2.Size = new System.Drawing.Size(75, 23);
            this.RunButton2.TabIndex = 12;
            this.RunButton2.Text = "Run";
            this.RunButton2.UseVisualStyleBackColor = true;
            // 
            // SyntaxButton
            // 
            this.SyntaxButton.Location = new System.Drawing.Point(157, 513);
            this.SyntaxButton.Name = "SyntaxButton";
            this.SyntaxButton.Size = new System.Drawing.Size(75, 23);
            this.SyntaxButton.TabIndex = 11;
            this.SyntaxButton.Text = "Syntax";
            this.SyntaxButton.UseVisualStyleBackColor = true;
            // 
            // RunButton1
            // 
            this.RunButton1.Location = new System.Drawing.Point(44, 513);
            this.RunButton1.Name = "RunButton1";
            this.RunButton1.Size = new System.Drawing.Size(75, 23);
            this.RunButton1.TabIndex = 10;
            this.RunButton1.Text = "Run";
            this.RunButton1.UseVisualStyleBackColor = true;
            this.RunButton1.Click += new System.EventHandler(this.RunButton1_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(157, 113);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 9;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            // 
            // LoadButton
            // 
            this.LoadButton.Location = new System.Drawing.Point(44, 113);
            this.LoadButton.Name = "LoadButton";
            this.LoadButton.Size = new System.Drawing.Size(75, 23);
            this.LoadButton.TabIndex = 8;
            this.LoadButton.Text = "Load";
            this.LoadButton.UseVisualStyleBackColor = true;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1081, 743);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.RunButton2);
            this.Controls.Add(this.SyntaxButton);
            this.Controls.Add(this.RunButton1);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.LoadButton);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button RunButton2;
        private System.Windows.Forms.Button SyntaxButton;
        private System.Windows.Forms.Button RunButton1;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button LoadButton;
    }
}