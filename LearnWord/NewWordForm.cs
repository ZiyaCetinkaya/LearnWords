using DataAccessService;
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
    public partial class NewWordForm : Form
    {
        bool dragging;
        Point offset;
        Profile currentProfile;
        List<WordType> wordTypes;
        WordAccessService was = new WordAccessService();
        WordTypeAccessService wtas = new WordTypeAccessService();

        public NewWordForm(Profile profile)
        {
            currentProfile = profile;
            InitializeComponent();
            this.Load += NewWordForm_Load;
        }

        private void btnNwSaveWord_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNwFirstLang.Text == string.Empty || txtNwSecondLang.Text == string.Empty || cbNwWordType.SelectedIndex < 0)
                    throw new Exception("Tüm alanları doldurmalısınız.");

                was.Insert(new Word()
                {
                    wordFirstLang = txtNwFirstLang.Text,
                    wordSecondLang = txtNwSecondLang.Text,
                    typeID = (int)cbNwWordType.SelectedValue,
                    profileID = currentProfile.ProfileID
                });

                Height = 70;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void NewWordForm_Load(object sender, EventArgs e)
        {
            wordTypes = wtas.Select(wt => wt.profileID == currentProfile.ProfileID);
            lblNwProfileName.Text = currentProfile.ProfileName;
            lblNwFirstLang.Text = currentProfile.ProfileFirstLang;
            lblNwSecondLang.Text = currentProfile.ProfileSecondLang;

            cbNwWordType.DataSource = wordTypes;
            cbNwWordType.DisplayMember = "typeName";
            cbNwWordType.ValueMember = "typeID";
        }

        private void NewWordForm_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            offset = e.Location;
        }

        private void NewWordForm_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void NewWordForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point currentScreenPos = PointToScreen(e.Location);
                Location = new Point(currentScreenPos.X - offset.X, currentScreenPos.Y - offset.Y);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Height = 341;
            txtNwFirstLang.Text = string.Empty;
            txtNwSecondLang.Text = string.Empty;
            cbNwWordType.SelectedIndex = -1;
        }

        private void btnNwCancelWord_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm mainForm = new MainForm();
            mainForm.Show();
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            offset = e.Location;
        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point currentScreenPos = PointToScreen(e.Location);
                Location = new Point(currentScreenPos.X - offset.X, currentScreenPos.Y - offset.Y);
            }
        }

        private void label1_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void btnSetSmallForm_Click(object sender, EventArgs e)
        {
            Height = 70;
        }
    }
}
