namespace LearnWord
{
    partial class NewWordForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtNwFirstLang = new System.Windows.Forms.TextBox();
            this.lblNwFirstLang = new System.Windows.Forms.Label();
            this.txtNwSecondLang = new System.Windows.Forms.TextBox();
            this.lblNwSecondLang = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbNwWordType = new System.Windows.Forms.ComboBox();
            this.btnNwSaveWord = new System.Windows.Forms.Button();
            this.btnNwCancelWord = new System.Windows.Forms.Button();
            this.lblNwProfileName = new System.Windows.Forms.Label();
            this.btnSetSmallForm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.DarkOrange;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(-8, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(100, 10, 100, 10);
            this.label1.Size = new System.Drawing.Size(319, 43);
            this.label1.TabIndex = 0;
            this.label1.Text = "Yeni Kelime";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label1_MouseDown);
            this.label1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.label1_MouseMove);
            this.label1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.label1_MouseUp);
            // 
            // txtNwFirstLang
            // 
            this.txtNwFirstLang.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNwFirstLang.Location = new System.Drawing.Point(12, 103);
            this.txtNwFirstLang.MaxLength = 50;
            this.txtNwFirstLang.Name = "txtNwFirstLang";
            this.txtNwFirstLang.Size = new System.Drawing.Size(270, 31);
            this.txtNwFirstLang.TabIndex = 0;
            // 
            // lblNwFirstLang
            // 
            this.lblNwFirstLang.AutoSize = true;
            this.lblNwFirstLang.Location = new System.Drawing.Point(8, 78);
            this.lblNwFirstLang.Name = "lblNwFirstLang";
            this.lblNwFirstLang.Size = new System.Drawing.Size(84, 22);
            this.lblNwFirstLang.TabIndex = 2;
            this.lblNwFirstLang.Text = "Kelime 1";
            // 
            // txtNwSecondLang
            // 
            this.txtNwSecondLang.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNwSecondLang.Location = new System.Drawing.Point(12, 162);
            this.txtNwSecondLang.MaxLength = 50;
            this.txtNwSecondLang.Name = "txtNwSecondLang";
            this.txtNwSecondLang.Size = new System.Drawing.Size(270, 31);
            this.txtNwSecondLang.TabIndex = 1;
            // 
            // lblNwSecondLang
            // 
            this.lblNwSecondLang.AutoSize = true;
            this.lblNwSecondLang.Location = new System.Drawing.Point(8, 137);
            this.lblNwSecondLang.Name = "lblNwSecondLang";
            this.lblNwSecondLang.Size = new System.Drawing.Size(84, 22);
            this.lblNwSecondLang.TabIndex = 2;
            this.lblNwSecondLang.Text = "Kelime 2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 196);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 22);
            this.label4.TabIndex = 2;
            this.label4.Text = "Kelime Tipi";
            // 
            // cbNwWordType
            // 
            this.cbNwWordType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNwWordType.FormattingEnabled = true;
            this.cbNwWordType.Location = new System.Drawing.Point(12, 221);
            this.cbNwWordType.Name = "cbNwWordType";
            this.cbNwWordType.Size = new System.Drawing.Size(270, 30);
            this.cbNwWordType.TabIndex = 2;
            // 
            // btnNwSaveWord
            // 
            this.btnNwSaveWord.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnNwSaveWord.FlatAppearance.BorderSize = 0;
            this.btnNwSaveWord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNwSaveWord.ForeColor = System.Drawing.Color.White;
            this.btnNwSaveWord.Location = new System.Drawing.Point(12, 257);
            this.btnNwSaveWord.Name = "btnNwSaveWord";
            this.btnNwSaveWord.Size = new System.Drawing.Size(130, 40);
            this.btnNwSaveWord.TabIndex = 3;
            this.btnNwSaveWord.Text = "Kaydet";
            this.btnNwSaveWord.UseVisualStyleBackColor = false;
            this.btnNwSaveWord.Click += new System.EventHandler(this.btnNwSaveWord_Click);
            // 
            // btnNwCancelWord
            // 
            this.btnNwCancelWord.BackColor = System.Drawing.Color.Crimson;
            this.btnNwCancelWord.FlatAppearance.BorderSize = 0;
            this.btnNwCancelWord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNwCancelWord.ForeColor = System.Drawing.Color.White;
            this.btnNwCancelWord.Location = new System.Drawing.Point(152, 257);
            this.btnNwCancelWord.Name = "btnNwCancelWord";
            this.btnNwCancelWord.Size = new System.Drawing.Size(130, 40);
            this.btnNwCancelWord.TabIndex = 4;
            this.btnNwCancelWord.Text = "Çıkış";
            this.btnNwCancelWord.UseVisualStyleBackColor = false;
            this.btnNwCancelWord.Click += new System.EventHandler(this.btnNwCancelWord_Click);
            // 
            // lblNwProfileName
            // 
            this.lblNwProfileName.AutoSize = true;
            this.lblNwProfileName.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.lblNwProfileName.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblNwProfileName.ForeColor = System.Drawing.Color.White;
            this.lblNwProfileName.Location = new System.Drawing.Point(0, 43);
            this.lblNwProfileName.Name = "lblNwProfileName";
            this.lblNwProfileName.Padding = new System.Windows.Forms.Padding(5, 5, 200, 5);
            this.lblNwProfileName.Size = new System.Drawing.Size(286, 27);
            this.lblNwProfileName.TabIndex = 0;
            this.lblNwProfileName.Text = "Yeni Kelime";
            // 
            // btnSetSmallForm
            // 
            this.btnSetSmallForm.BackColor = System.Drawing.Color.DarkOrange;
            this.btnSetSmallForm.FlatAppearance.BorderSize = 0;
            this.btnSetSmallForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetSmallForm.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSetSmallForm.ForeColor = System.Drawing.Color.White;
            this.btnSetSmallForm.Location = new System.Drawing.Point(-2, 303);
            this.btnSetSmallForm.Name = "btnSetSmallForm";
            this.btnSetSmallForm.Size = new System.Drawing.Size(298, 38);
            this.btnSetSmallForm.TabIndex = 3;
            this.btnSetSmallForm.Text = "İPTAL";
            this.btnSetSmallForm.UseVisualStyleBackColor = false;
            this.btnSetSmallForm.Click += new System.EventHandler(this.btnSetSmallForm_Click);
            // 
            // NewWordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(294, 70);
            this.Controls.Add(this.btnNwCancelWord);
            this.Controls.Add(this.btnSetSmallForm);
            this.Controls.Add(this.btnNwSaveWord);
            this.Controls.Add(this.cbNwWordType);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblNwSecondLang);
            this.Controls.Add(this.txtNwSecondLang);
            this.Controls.Add(this.lblNwFirstLang);
            this.Controls.Add(this.txtNwFirstLang);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblNwProfileName);
            this.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "NewWordForm";
            this.Text = "NewWordForm";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.NewWordForm_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.NewWordForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.NewWordForm_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.NewWordForm_MouseUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNwFirstLang;
        private System.Windows.Forms.Label lblNwFirstLang;
        private System.Windows.Forms.TextBox txtNwSecondLang;
        private System.Windows.Forms.Label lblNwSecondLang;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbNwWordType;
        private System.Windows.Forms.Button btnNwSaveWord;
        private System.Windows.Forms.Button btnNwCancelWord;
        private System.Windows.Forms.Label lblNwProfileName;
        private System.Windows.Forms.Button btnSetSmallForm;
    }
}