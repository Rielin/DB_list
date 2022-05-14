namespace LibraryDBEvolution
{
    partial class Choice
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
            this.GiveBookBT = new System.Windows.Forms.Button();
            this.ClientInfoBT = new System.Windows.Forms.Button();
            this.BookInfoBT = new System.Windows.Forms.Button();
            this.staffBT = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // GiveBookBT
            // 
            this.GiveBookBT.Location = new System.Drawing.Point(169, 83);
            this.GiveBookBT.Name = "GiveBookBT";
            this.GiveBookBT.Size = new System.Drawing.Size(147, 49);
            this.GiveBookBT.TabIndex = 7;
            this.GiveBookBT.Text = "Выдать книгу";
            this.GiveBookBT.UseVisualStyleBackColor = true;
            this.GiveBookBT.Click += new System.EventHandler(this.GiveBookBT_Click);
            // 
            // ClientInfoBT
            // 
            this.ClientInfoBT.Location = new System.Drawing.Point(169, 28);
            this.ClientInfoBT.Name = "ClientInfoBT";
            this.ClientInfoBT.Size = new System.Drawing.Size(147, 49);
            this.ClientInfoBT.TabIndex = 6;
            this.ClientInfoBT.Text = "Информация о клиентах";
            this.ClientInfoBT.UseVisualStyleBackColor = true;
            this.ClientInfoBT.Click += new System.EventHandler(this.ClientInfoBT_Click);
            // 
            // BookInfoBT
            // 
            this.BookInfoBT.Location = new System.Drawing.Point(16, 83);
            this.BookInfoBT.Name = "BookInfoBT";
            this.BookInfoBT.Size = new System.Drawing.Size(147, 49);
            this.BookInfoBT.TabIndex = 5;
            this.BookInfoBT.Text = "Информация о книгах";
            this.BookInfoBT.UseVisualStyleBackColor = true;
            this.BookInfoBT.Click += new System.EventHandler(this.BookInfoBT_Click);
            // 
            // staffBT
            // 
            this.staffBT.Location = new System.Drawing.Point(16, 28);
            this.staffBT.Name = "staffBT";
            this.staffBT.Size = new System.Drawing.Size(147, 49);
            this.staffBT.TabIndex = 4;
            this.staffBT.Text = "Служащие библеотеки";
            this.staffBT.UseVisualStyleBackColor = true;
            this.staffBT.Click += new System.EventHandler(this.staffBT_Click);
            // 
            // Choice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 158);
            this.Controls.Add(this.GiveBookBT);
            this.Controls.Add(this.ClientInfoBT);
            this.Controls.Add(this.BookInfoBT);
            this.Controls.Add(this.staffBT);
            this.Name = "Choice";
            this.Text = "Choice";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button GiveBookBT;
        private System.Windows.Forms.Button ClientInfoBT;
        private System.Windows.Forms.Button BookInfoBT;
        private System.Windows.Forms.Button staffBT;
    }
}