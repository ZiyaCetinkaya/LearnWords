using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LearnWord
{
    public partial class ReminderForm : Form
    {
        private Word currentWord;
        private WordType currentWordType;
        private Profile currentProfile;
        public ReminderForm(Word word, WordType wordType, Profile profile)
        {
            InitializeComponent();
            currentWord = word;
            currentWordType = wordType;
            currentProfile = profile;
        }

        private void ReminderForm_Load(object sender, EventArgs e)
        {
            lblWrFirstLang.Text = currentProfile.ProfileFirstLang;
            lblWrSecondLang.Text = currentProfile.ProfileSecondLang;
            txtWrFirstLang.Text = currentWord.wordFirstLang;
            txtWrSecondLang.Text = currentWord.wordSecondLang;
            lblWrWordType.Text = currentWordType.typeName;
        }

        private void btnWrGetSecondLang_Click(object sender, EventArgs e)
        {
            Height = 319;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnWrCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm mainForm = new MainForm(false);
            mainForm.Show();
        }
    }
}
