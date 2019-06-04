namespace LearnWord
{
    partial class ReminderForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReminderForm));
            this.lblWrFirstLang = new System.Windows.Forms.Label();
            this.txtWrFirstLang = new System.Windows.Forms.TextBox();
            this.lblWrSecondLang = new System.Windows.Forms.Label();
            this.txtWrSecondLang = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnWrGetSecondLang = new System.Windows.Forms.Button();
            this.lblWrWordType = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnWrCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblWrFirstLang
            // 
            resources.ApplyResources(this.lblWrFirstLang, "lblWrFirstLang");
            this.lblWrFirstLang.ForeColor = System.Drawing.Color.Black;
            this.lblWrFirstLang.Name = "lblWrFirstLang";
            // 
            // txtWrFirstLang
            // 
            this.txtWrFirstLang.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.txtWrFirstLang, "txtWrFirstLang");
            this.txtWrFirstLang.Name = "txtWrFirstLang";
            this.txtWrFirstLang.ReadOnly = true;
            // 
            // lblWrSecondLang
            // 
            resources.ApplyResources(this.lblWrSecondLang, "lblWrSecondLang");
            this.lblWrSecondLang.ForeColor = System.Drawing.Color.Black;
            this.lblWrSecondLang.Name = "lblWrSecondLang";
            // 
            // txtWrSecondLang
            // 
            this.txtWrSecondLang.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.txtWrSecondLang, "txtWrSecondLang");
            this.txtWrSecondLang.Name = "txtWrSecondLang";
            this.txtWrSecondLang.ReadOnly = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::LearnWord.Properties.Resources.owl;
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // btnWrGetSecondLang
            // 
            this.btnWrGetSecondLang.BackgroundImage = global::LearnWord.Properties.Resources.sign_down_icon;
            resources.ApplyResources(this.btnWrGetSecondLang, "btnWrGetSecondLang");
            this.btnWrGetSecondLang.FlatAppearance.BorderSize = 0;
            this.btnWrGetSecondLang.Name = "btnWrGetSecondLang";
            this.btnWrGetSecondLang.UseVisualStyleBackColor = true;
            this.btnWrGetSecondLang.Click += new System.EventHandler(this.btnWrGetSecondLang_Click);
            // 
            // lblWrWordType
            // 
            resources.ApplyResources(this.lblWrWordType, "lblWrWordType");
            this.lblWrWordType.ForeColor = System.Drawing.Color.Black;
            this.lblWrWordType.Name = "lblWrWordType";
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnOK.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btnOK, "btnOK");
            this.btnOK.ForeColor = System.Drawing.Color.White;
            this.btnOK.Name = "btnOK";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnWrCancel
            // 
            this.btnWrCancel.BackColor = System.Drawing.Color.DarkGreen;
            this.btnWrCancel.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btnWrCancel, "btnWrCancel");
            this.btnWrCancel.ForeColor = System.Drawing.Color.White;
            this.btnWrCancel.Name = "btnWrCancel";
            this.btnWrCancel.UseVisualStyleBackColor = false;
            this.btnWrCancel.Click += new System.EventHandler(this.btnWrCancel_Click);
            // 
            // ReminderForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumAquamarine;
            this.Controls.Add(this.btnWrCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnWrGetSecondLang);
            this.Controls.Add(this.txtWrSecondLang);
            this.Controls.Add(this.lblWrSecondLang);
            this.Controls.Add(this.txtWrFirstLang);
            this.Controls.Add(this.lblWrWordType);
            this.Controls.Add(this.lblWrFirstLang);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ReminderForm";
            this.Load += new System.EventHandler(this.ReminderForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblWrFirstLang;
        private System.Windows.Forms.TextBox txtWrFirstLang;
        private System.Windows.Forms.Button btnWrGetSecondLang;
        private System.Windows.Forms.Label lblWrSecondLang;
        private System.Windows.Forms.TextBox txtWrSecondLang;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblWrWordType;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnWrCancel;
    }
}