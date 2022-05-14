namespace LibraryDBEvolution
{
    partial class BookInfo
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.ButtonDelete = new System.Windows.Forms.Button();
            this.buttonChange = new System.Windows.Forms.Button();
            this.ButtonAdd = new System.Windows.Forms.Button();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxIDbook = new System.Windows.Forms.TextBox();
            this.textBoxNameBook = new System.Windows.Forms.TextBox();
            this.dataGridViewBook = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.buttonSaveAuthor = new System.Windows.Forms.Button();
            this.buttonDelAuthor = new System.Windows.Forms.Button();
            this.buttonChangeAuthor = new System.Windows.Forms.Button();
            this.dataGridViewAuthor = new System.Windows.Forms.DataGridView();
            this.textBoxPatr = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxSur = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonAddAuthor = new System.Windows.Forms.Button();
            this.textBoxID = new System.Windows.Forms.TextBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBook)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAuthor)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(527, 301);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.checkBox1);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.buttonSave);
            this.tabPage1.Controls.Add(this.ButtonDelete);
            this.tabPage1.Controls.Add(this.buttonChange);
            this.tabPage1.Controls.Add(this.ButtonAdd);
            this.tabPage1.Controls.Add(this.textBoxSearch);
            this.tabPage1.Controls.Add(this.listBox1);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.textBoxIDbook);
            this.tabPage1.Controls.Add(this.textBoxNameBook);
            this.tabPage1.Controls.Add(this.dataGridViewBook);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(519, 275);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Книга";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(274, 148);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(75, 17);
            this.checkBox1.TabIndex = 54;
            this.checkBox1.Text = "Доступно";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 175);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 13);
            this.label6.TabIndex = 53;
            this.label6.Text = "Название";
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(357, 175);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 52;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // ButtonDelete
            // 
            this.ButtonDelete.Location = new System.Drawing.Point(357, 146);
            this.ButtonDelete.Name = "ButtonDelete";
            this.ButtonDelete.Size = new System.Drawing.Size(75, 23);
            this.ButtonDelete.TabIndex = 51;
            this.ButtonDelete.Text = "Удалить";
            this.ButtonDelete.UseVisualStyleBackColor = true;
            this.ButtonDelete.Click += new System.EventHandler(this.ButtonDelete_Click);
            // 
            // buttonChange
            // 
            this.buttonChange.Location = new System.Drawing.Point(438, 175);
            this.buttonChange.Name = "buttonChange";
            this.buttonChange.Size = new System.Drawing.Size(75, 23);
            this.buttonChange.TabIndex = 50;
            this.buttonChange.Text = "Изменить";
            this.buttonChange.UseVisualStyleBackColor = true;
            this.buttonChange.Click += new System.EventHandler(this.buttonChange_Click);
            // 
            // ButtonAdd
            // 
            this.ButtonAdd.Location = new System.Drawing.Point(438, 146);
            this.ButtonAdd.Name = "ButtonAdd";
            this.ButtonAdd.Size = new System.Drawing.Size(75, 23);
            this.ButtonAdd.TabIndex = 49;
            this.ButtonAdd.Text = "Добавить";
            this.ButtonAdd.UseVisualStyleBackColor = true;
            this.ButtonAdd.Click += new System.EventHandler(this.ButtonAdd_Click);
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Location = new System.Drawing.Point(377, 6);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(136, 20);
            this.textBoxSearch.TabIndex = 48;
            this.textBoxSearch.TextChanged += new System.EventHandler(this.textBoxSearch_TextChanged);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(377, 32);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(136, 108);
            this.listBox1.TabIndex = 47;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 149);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 46;
            this.label1.Text = "ID";
            // 
            // textBoxIDbook
            // 
            this.textBoxIDbook.Location = new System.Drawing.Point(69, 146);
            this.textBoxIDbook.Name = "textBoxIDbook";
            this.textBoxIDbook.Size = new System.Drawing.Size(199, 20);
            this.textBoxIDbook.TabIndex = 44;
            // 
            // textBoxNameBook
            // 
            this.textBoxNameBook.Location = new System.Drawing.Point(69, 172);
            this.textBoxNameBook.Name = "textBoxNameBook";
            this.textBoxNameBook.Size = new System.Drawing.Size(199, 20);
            this.textBoxNameBook.TabIndex = 45;
            // 
            // dataGridViewBook
            // 
            this.dataGridViewBook.AllowUserToAddRows = false;
            this.dataGridViewBook.AllowUserToDeleteRows = false;
            this.dataGridViewBook.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBook.Location = new System.Drawing.Point(6, 6);
            this.dataGridViewBook.Name = "dataGridViewBook";
            this.dataGridViewBook.ReadOnly = true;
            this.dataGridViewBook.Size = new System.Drawing.Size(365, 134);
            this.dataGridViewBook.TabIndex = 43;
            this.dataGridViewBook.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellClick);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.buttonSaveAuthor);
            this.tabPage2.Controls.Add(this.buttonDelAuthor);
            this.tabPage2.Controls.Add(this.buttonChangeAuthor);
            this.tabPage2.Controls.Add(this.dataGridViewAuthor);
            this.tabPage2.Controls.Add(this.textBoxPatr);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.textBoxSur);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.buttonAddAuthor);
            this.tabPage2.Controls.Add(this.textBoxID);
            this.tabPage2.Controls.Add(this.textBoxName);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(519, 275);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Автор";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // buttonSaveAuthor
            // 
            this.buttonSaveAuthor.Location = new System.Drawing.Point(328, 225);
            this.buttonSaveAuthor.Name = "buttonSaveAuthor";
            this.buttonSaveAuthor.Size = new System.Drawing.Size(75, 23);
            this.buttonSaveAuthor.TabIndex = 45;
            this.buttonSaveAuthor.Text = "Save";
            this.buttonSaveAuthor.UseVisualStyleBackColor = true;
            this.buttonSaveAuthor.Click += new System.EventHandler(this.buttonSaveAuthor_Click);
            // 
            // buttonDelAuthor
            // 
            this.buttonDelAuthor.Location = new System.Drawing.Point(409, 223);
            this.buttonDelAuthor.Name = "buttonDelAuthor";
            this.buttonDelAuthor.Size = new System.Drawing.Size(75, 23);
            this.buttonDelAuthor.TabIndex = 44;
            this.buttonDelAuthor.Text = "Удалить";
            this.buttonDelAuthor.UseVisualStyleBackColor = true;
            this.buttonDelAuthor.Click += new System.EventHandler(this.buttonDelAuthor_Click);
            // 
            // buttonChangeAuthor
            // 
            this.buttonChangeAuthor.Location = new System.Drawing.Point(409, 196);
            this.buttonChangeAuthor.Name = "buttonChangeAuthor";
            this.buttonChangeAuthor.Size = new System.Drawing.Size(75, 23);
            this.buttonChangeAuthor.TabIndex = 43;
            this.buttonChangeAuthor.Text = "Изменить";
            this.buttonChangeAuthor.UseVisualStyleBackColor = true;
            this.buttonChangeAuthor.Click += new System.EventHandler(this.buttonChangeAuthor_Click);
            // 
            // dataGridViewAuthor
            // 
            this.dataGridViewAuthor.AllowUserToAddRows = false;
            this.dataGridViewAuthor.AllowUserToDeleteRows = false;
            this.dataGridViewAuthor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAuthor.Location = new System.Drawing.Point(6, 6);
            this.dataGridViewAuthor.Name = "dataGridViewAuthor";
            this.dataGridViewAuthor.ReadOnly = true;
            this.dataGridViewAuthor.Size = new System.Drawing.Size(478, 134);
            this.dataGridViewAuthor.TabIndex = 42;
            this.dataGridViewAuthor.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // textBoxPatr
            // 
            this.textBoxPatr.Location = new System.Drawing.Point(78, 225);
            this.textBoxPatr.Name = "textBoxPatr";
            this.textBoxPatr.Size = new System.Drawing.Size(199, 20);
            this.textBoxPatr.TabIndex = 41;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 201);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 36;
            this.label4.Text = "Фамилия";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 228);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 37;
            this.label5.Text = "Отчество";
            // 
            // textBoxSur
            // 
            this.textBoxSur.Location = new System.Drawing.Point(78, 198);
            this.textBoxSur.Name = "textBoxSur";
            this.textBoxSur.Size = new System.Drawing.Size(199, 20);
            this.textBoxSur.TabIndex = 40;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 175);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 35;
            this.label3.Text = "Имя";
            // 
            // buttonAddAuthor
            // 
            this.buttonAddAuthor.Location = new System.Drawing.Point(409, 167);
            this.buttonAddAuthor.Name = "buttonAddAuthor";
            this.buttonAddAuthor.Size = new System.Drawing.Size(75, 23);
            this.buttonAddAuthor.TabIndex = 2;
            this.buttonAddAuthor.Text = "Добавить";
            this.buttonAddAuthor.UseVisualStyleBackColor = true;
            this.buttonAddAuthor.Click += new System.EventHandler(this.buttonAddAuthor_Click);
            // 
            // textBoxID
            // 
            this.textBoxID.Location = new System.Drawing.Point(78, 146);
            this.textBoxID.Name = "textBoxID";
            this.textBoxID.Size = new System.Drawing.Size(199, 20);
            this.textBoxID.TabIndex = 38;
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(78, 172);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(199, 20);
            this.textBoxName.TabIndex = 39;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 149);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 13);
            this.label2.TabIndex = 34;
            this.label2.Text = "ID";
            // 
            // BookInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 328);
            this.Controls.Add(this.tabControl1);
            this.Name = "BookInfo";
            this.Text = "BookInfo";
            this.Load += new System.EventHandler(this.BookInfo_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBook)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAuthor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button buttonAddAuthor;
        private System.Windows.Forms.TextBox textBoxPatr;
        private System.Windows.Forms.TextBox textBoxSur;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonDelAuthor;
        private System.Windows.Forms.Button buttonChangeAuthor;
        private System.Windows.Forms.DataGridView dataGridViewAuthor;
        private System.Windows.Forms.Button buttonSaveAuthor;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxIDbook;
        private System.Windows.Forms.TextBox textBoxNameBook;
        private System.Windows.Forms.DataGridView dataGridViewBook;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button ButtonDelete;
        private System.Windows.Forms.Button buttonChange;
        private System.Windows.Forms.Button ButtonAdd;
    }
}