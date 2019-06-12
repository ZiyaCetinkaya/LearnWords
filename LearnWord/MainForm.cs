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
    public partial class MainForm : Form
    {
        ProfileAccessService pas = new ProfileAccessService();
        WordAccessService was = new WordAccessService();
        WordTypeAccessService wtas = new WordTypeAccessService();
        Profile currentProfile;
        private static Timer timerWordReminder = new Timer();

        public MainForm()
        {
            InitializeComponent();
        }

        public MainForm(bool TimerOnOff)
        {
            if (!TimerOnOff)
            {
                timerWordReminder.Dispose();
            }
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

            List<Profile> profileList = pas.Select().ToList();
            /* Oluşturulmuş bir veya daha fazla profil varsa profil eçme ekranı gösteriliyor. Eğer program ilk defa açılıyorsa ve henüz hiç profil yoksa profil oluşturma ekranı 
             gösteriliyor. */
            if (profileList.Count <= 0)
            {
                pnlNewProfile.Visible = true;
                pnlSelectProfile.Visible = false;
            }
            else
            {
                pnlNewProfile.Visible = false;
                pnlSelectProfile.Visible = true;
                lblTimeInterval.Text = tbTimeInterval.Value + " Dk";
                FillProfilesToFlp();
            }
        }

        /* Yeni bir profil oluşturma, var olan bir profili güncelleme ve silme işlemleri burada yapılıyor. */
        private void btnSaveNewProfile_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtProfileName.Text == string.Empty || txtProfileLastName.Text == string.Empty || txtFirstLang.Text == string.Empty || txtSecondLang.Text == string.Empty)
                    throw new Exception("Tüm alanları doldurmalısınız.");

                if (btnSaveNewProfile.Text == "Ekle") // Profil Ekleme
                {
                    pas.Insert(new Profile()
                    {
                        ProfileUserName = txtProfileName.Text,
                        ProfileUserLastName = txtProfileLastName.Text,
                        ProfileFirstLang = txtFirstLang.Text,
                        ProfileSecondLang = txtSecondLang.Text,
                        ProfileTimeInterval = tbTimeInterval.Value,
                        ProfileName = txtProfileName.Text + " " + txtProfileLastName.Text + " (" + txtFirstLang.Text + " - " + txtSecondLang.Text + ")"
                    });

                    SetAlert("Yeni Profil Eklendi.");
                }
                else if (btnSaveNewProfile.Text == "Güncelle") // Profil Güncelleme
                {
                    pas.Update(new Profile()
                    {
                        ProfileID = int.Parse(txtProfileName.Tag.ToString()),
                        ProfileUserName = txtProfileName.Text,
                        ProfileUserLastName = txtProfileLastName.Text,
                        ProfileFirstLang = txtFirstLang.Text,
                        ProfileSecondLang = txtSecondLang.Text,
                        ProfileTimeInterval = tbTimeInterval.Value,
                        ProfileName = txtProfileName.Text + " " + txtProfileLastName.Text + " (" + txtFirstLang.Text + " - " + txtSecondLang.Text + ")"
                    });


                    SetAlert("Profil Güncellendi.");
                }
                /* Profil Silme 
                    Profile tablosu ile word ve wordType tabloları arasında ilişkiler olduğundan profile tablosundan bir veriyi silmek istersek öncelikle ilişkili tablolardan silmek 
                    istediğimiz profile'e ait word ve wordType değerlerini ilgili tablolardan profileID değerlerine göre silmemiz gerekir.
                 */
                else
                {
                    Profile profile = pas.FindByID(int.Parse(txtProfileName.Tag.ToString()));
                    string message = $"{profile.ProfileName} \nProfil Silinsin Mi?\nProfille birlikte ilgili tüm kelime ve kelime tipleri de silinecek.";
                    DialogResult dialogResult = MessageBox.Show(message, "Uyarı", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        List<Word> wordsForRemove = was.Select(w => w.profileID == profile.ProfileID);
                        if (wordsForRemove.Count != 0)
                        {
                            foreach (Word w in wordsForRemove)
                            {
                                was.Delete(w);
                            }
                        }

                        List<WordType> wordTypesForRemove = wtas.Select(w => w.profileID == profile.ProfileID);
                        if (wordTypesForRemove.Count != 0)
                        {
                            foreach (WordType wt in wordTypesForRemove)
                            {
                                wtas.Delete(wt);
                            }
                        }

                        pas.Delete(profile);

                        SetAlert("Profil Silindi.");
                    }
                }
                pnlNewProfile.Visible = false;
                pnlSelectProfile.Visible = true;
                FillProfilesToFlp();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        
        // Veritabanından profiller çekilip FlowLayoutPanel e yazdırılıyor.
        private void FillProfilesToFlp()
        {
            flpProfiles.Controls.Clear();
            List<Profile> profiles = pas.Select().ToList();
            foreach (Profile profile in profiles)
            {
                Button btnProfile = new Button();
                btnProfile.Text = profile.ProfileName;
                btnProfile.Tag = profile.ProfileID.ToString();
                btnProfile.BackColor = SystemColors.HotTrack;
                btnProfile.FlatAppearance.BorderSize = 0;
                btnProfile.FlatStyle = FlatStyle.Flat;
                btnProfile.ForeColor = Color.White;
                btnProfile.Margin = new Padding(2);
                btnProfile.Size = new Size(326, 72);
                btnProfile.UseVisualStyleBackColor = false;
                btnProfile.Click += BtnProfile_Click;
                flpProfiles.Controls.Add(btnProfile);
            }
        }

        // FlowLayoutPanel de button olarak listelediğimiz profillere click event ini ekledik. Burada hangi profile tıklanırsa onunla ilgili özelleştirilmi sayfaya yönlendirme yapılıyor.
        private void BtnProfile_Click(object sender, EventArgs e)
        {
            Button btnProfile = sender as Button;
            int profileID = int.Parse(btnProfile.Tag.ToString());
            Profile profile = pas.FindByID(profileID);
            List<WordType> wordTypes = wtas.Select(wt => wt.profileID == profile.ProfileID);
            currentProfile = profile;
            FillWordsTolistView();

            // Kelime hatırlatıcısı için süre ayarlaması yapıyoruz
            timerWordReminder = new Timer();
            timerWordReminder.Interval = 5000;
            //timerWordReminder.Interval = (int)currentProfile.ProfileTimeInterval * 60000;

            lblProfileName.Text = currentProfile.ProfileName;

            lblFirstLang.Text = profile.ProfileFirstLang;
            lblSecondLang.Text = profile.ProfileSecondLang;

            FillWordTypesToListView(wordTypes);
            FillWordTypesToComboBox(wordTypes);

            pnlProfileHomePage.Visible = true;
            pnlNewProfile.Visible = false;
            pnlSelectProfile.Visible = false;
        }

        // Veritabanından kelimeler çekilip listView e ekliyoruz.
        private void FillWordsTolistView()
        {
            lvWords.Items.Clear();
            lvWords.Columns[0].Text = currentProfile.ProfileFirstLang;
            lvWords.Columns[1].Text = currentProfile.ProfileSecondLang;

            List<Word> wordList = was.Select(w => w.profileID == currentProfile.ProfileID);
            foreach (Word w in wordList)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Tag = w.wordID;
                lvi.Text = w.wordFirstLang;
                lvi.SubItems.Add(w.wordSecondLang);
                lvWords.Items.Add(lvi);
            }
        }

        // Kelime tiplerini veritabanından çekip kullanıcının seçim yapabilmesi için combobox a DataSource olarak veriyoruz.
        private void FillWordTypesToComboBox(List<WordType> wordTypes)
        {
            cbWordType.DataSource = wordTypes;
            cbWordType.ValueMember = "typeID";
            cbWordType.DisplayMember = "typeName";
        }

        // Veritabanından kelime tipleri çekilip listView e ekliyoruz.
        private void FillWordTypesToListView(List<WordType> wordTypes)
        {
            lvWordTypes.Items.Clear();
            foreach (var item in wordTypes)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Tag = item.typeID;
                lvi.Text = item.typeName;
                lvWordTypes.Items.Add(lvi);
            }
        }

        private void btnCancelNewProfile_Click(object sender, EventArgs e)
        {
            pnlNewProfile.Visible = false;
            pnlSelectProfile.Visible = true;
        }

        // Uygulamadan çıkış işlemleri
        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Uygulama Kapatılsın Mı?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                Environment.Exit(-1);
            }
        }

        private void btnNewProfile_Click(object sender, EventArgs e)
        {
            btnSaveNewProfile.Text = "Ekle";
            pnlNewProfile.Visible = true;
            pnlSelectProfile.Visible = false;
        }
        
        // TrackBar controller ının değeri değişirse yan tarafındaki label da değerin gösterilmesini sağlıyoruz.
        private void tbTimeInterval_Scroll(object sender, EventArgs e)
        {
            lblTimeInterval.Text = tbTimeInterval.Value + " Dk";
        }

        private void btnNewWord_Click(object sender, EventArgs e)
        {
            pbWords.Visible = false;
            txtLang1.Text = string.Empty;
            txtLang2.Text = string.Empty;
            cbWordType.SelectedItem = -1;
            btnSaveWord.Text = "Ekle";
        }

        private void btnUpdateWord_Click(object sender, EventArgs e)
        {
            try
            {
                if (lvWords.FocusedItem == null)
                    throw new Exception("Listeden bir kelime seçmelisiniz.");
                else
                {
                    GetWordFromListView();

                    pbWords.Visible = false;
                    btnSaveWord.Text = "Güncelle";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // ListView'den seçili kelimeyi alıp güncelleme ve silme işlemleri için ilgili yerlere alıyoruz.
        private void GetWordFromListView()
        {
            Word word = was.FindByID(int.Parse(lvWords.FocusedItem.Tag.ToString()));
            txtLang1.Tag = word.wordID.ToString();
            txtLang1.Text = word.wordFirstLang;
            txtLang2.Text = word.wordSecondLang;
            cbWordType.SelectedValue = word.typeID;
        }

        private void btnCancelWord_Click(object sender, EventArgs e)
        {
            pbWords.Visible = true;
            lvWords.FocusedItem = null;
        }
        
        /* Yeni bir kelime oluşturma, var olan bir kelimeyi güncelleme ve silme işlemleri burada yapılıyor. */
        private void btnSaveWord_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtLang1.Text == string.Empty || txtLang2.Text == string.Empty || cbWordType.SelectedIndex < 0)
                    throw new Exception("Tüm Alanları Doldurmalsınız.");

                if (btnSaveWord.Text == "Ekle") // Yeni kelime ekleme
                {
                    was.Insert(new Word()
                    {
                        wordFirstLang = txtLang1.Text,
                        wordSecondLang = txtLang2.Text,
                        typeID = (int)cbWordType.SelectedValue,
                        profileID = currentProfile.ProfileID
                    });

                    SetAlert("Yeni kelime eklendi.");
                    FillWordsTolistView();
                    pbWords.Visible = true;
                }
                else if (btnSaveWord.Text == "Güncelle") // Kelime Güncelleme
                {
                    was.Update(new Word()
                    {
                        wordID = int.Parse(txtLang1.Tag.ToString()),
                        wordFirstLang = txtLang1.Text,
                        wordSecondLang = txtLang2.Text,
                        typeID = (int)cbWordType.SelectedValue,
                        profileID = currentProfile.ProfileID
                    });

                    SetAlert("Kelime Güncellendi.");
                    FillWordsTolistView();
                    pbWords.Visible = true;
                }
                else // Kelime Silme
                {
                    was.Delete(was.FindByID(int.Parse(txtLang1.Tag.ToString())));

                    SetAlert("Kelime Silindi.");
                    FillWordsTolistView();
                    pbWords.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnRemoveWord_Click(object sender, EventArgs e)
        {
            try
            {
                if (lvWords.FocusedItem == null)
                    throw new Exception("Listeden bir kelime seçmelisiniz.");
                else
                {
                    GetWordFromListView();
                    pbWords.Visible = false;
                    btnSaveWord.Text = "Sil";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnNewWordType_Click(object sender, EventArgs e)
        {
            txtWordType.Text = string.Empty;
            btnSaveWordType.Text = "Ekle";
            pbWordTypes.Visible = false;
        }

        private void btnUpdateWordType_Click(object sender, EventArgs e)
        {
            try
            {
                if (lvWordTypes.FocusedItem == null)
                    throw new Exception("Listeden bir kelime tipi seçmelisiniz.");
                else
                {
                    GetWordTypeFromListView();
                    btnSaveWordType.Text = "Güncelle";
                    pbWordTypes.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // ListView den WordType deperlerini güncelleme ve silme işlemleri için ilgili yerlere alıyoruz.
        private void GetWordTypeFromListView()
        {
            WordType wordType = wtas.FindByID(int.Parse(lvWordTypes.FocusedItem.Tag.ToString()));
            txtWordType.Tag = wordType.typeID.ToString();
            txtWordType.Text = wordType.typeName;
        }

        private void btnRemoveWordType_Click(object sender, EventArgs e)
        {
            try
            {
                if (lvWordTypes.FocusedItem == null)
                    throw new Exception("Listeden bir kelime tipi seçmelisiniz.");
                else
                {
                    GetWordTypeFromListView();
                    btnSaveWordType.Text = "Sil";
                    pbWordTypes.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        /* Yeni bir kelime tipi oluşturma, var olan bir kelime tipini güncelleme ve silme işlemleri burada yapılıyor. */
        private void btnSaveWordType_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtWordType.Text == string.Empty)
                    throw new Exception("Tüm Alanları Doldurmalsınız.");

                if (btnSaveWordType.Text == "Ekle") // Kelime Tipi Ekleme
                {
                    wtas.Insert(new WordType()
                    {
                        typeName = txtWordType.Text,
                        profileID = currentProfile.ProfileID
                    });

                    SetAlert("Yeni kelime tipi eklendi.");
                    List<WordType> wordTypes = wtas.Select(wt => wt.profileID == currentProfile.ProfileID);
                    FillWordTypesToListView(wordTypes);
                    FillWordTypesToComboBox(wordTypes);
                }
                else if (btnSaveWordType.Text == "Güncelle") // Kelime Tipi Güncelleme
                {
                    wtas.Update(new WordType()
                    {
                        typeID = int.Parse(txtWordType.Tag.ToString()),
                        typeName = txtWordType.Text,
                        profileID = currentProfile.ProfileID
                    });

                    SetAlert("Kelime Tipi Güncellendi.");
                    List<WordType> wordTypes = wtas.Select();
                    FillWordTypesToListView(wordTypes);
                }
                else // Kelime Tipi Silme
                {
                    wtas.Delete(wtas.FindByID(int.Parse(txtWordType.Tag.ToString())));

                    SetAlert("Kelime Tipi Silindi.");
                    List<WordType> wordTypes = wtas.Select(wt => wt.profileID == currentProfile.ProfileID);
                    FillWordTypesToListView(wordTypes);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancelWordType_Click(object sender, EventArgs e)
        {
            pbWordTypes.Visible = true;
            lvWordTypes.FocusedItem = null;
            lvWordTypes.SelectedItems.Clear();
        }

        private void btnWNewProfile_Click(object sender, EventArgs e)
        {
            pnlNewProfile.Visible = true;
            pnlProfileHomePage.Visible = false;
            pnlSelectProfile.Visible = false;

            txtProfileName.Text = string.Empty;
            txtProfileLastName.Text = string.Empty;
            txtFirstLang.Text = string.Empty;
            txtSecondLang.Text = string.Empty;
            tbTimeInterval.Value = 5;
            lblProfileName.Text = string.Empty;
            lblNewProfile.Text = "Yeni Profil";
            btnSaveNewProfile.Text = "Ekle";
        }

        private void btnWUpdateProfile_Click(object sender, EventArgs e)
        {
            pnlNewProfile.Visible = true;
            pnlProfileHomePage.Visible = false;
            pnlSelectProfile.Visible = false;

            txtProfileName.Tag = currentProfile.ProfileID.ToString();
            txtProfileName.Text = currentProfile.ProfileUserName;
            txtProfileLastName.Text = currentProfile.ProfileUserLastName;
            txtFirstLang.Text = currentProfile.ProfileFirstLang;
            txtSecondLang.Text = currentProfile.ProfileSecondLang;
            tbTimeInterval.Value = (int)currentProfile.ProfileTimeInterval;
            lblTimeInterval.Text = tbTimeInterval.Value.ToString() + " Dk";
            btnSaveNewProfile.Text = "Güncelle";
            lblNewProfile.Text = "Profili Düzenle";
            lblProfileName.Text = string.Empty;
        }

        private void btnWRemoveProfile_Click(object sender, EventArgs e)
        {
            pnlNewProfile.Visible = true;
            pnlProfileHomePage.Visible = false;
            pnlSelectProfile.Visible = false;

            txtProfileName.Tag = currentProfile.ProfileID.ToString();
            txtProfileName.Text = currentProfile.ProfileUserName;
            txtProfileLastName.Text = currentProfile.ProfileUserLastName;
            txtFirstLang.Text = currentProfile.ProfileFirstLang;
            txtSecondLang.Text = currentProfile.ProfileSecondLang;
            tbTimeInterval.Value = (int)currentProfile.ProfileTimeInterval;
            lblTimeInterval.Text = tbTimeInterval.Value.ToString() + " Dk";
            btnSaveNewProfile.Text = "Sil";
            lblNewProfile.Text = "Profili Sil";
            lblProfileName.Text = string.Empty;
        }

        private void btnWChangeProfile_Click(object sender, EventArgs e)
        {
            pnlNewProfile.Visible = false;
            pnlProfileHomePage.Visible = false;
            pnlSelectProfile.Visible = true;
            lblProfileName.Text = string.Empty;
        }

        // Ana ekrandaki tarih ve saat değerlerini değişmesini sağlayan timer
        private void timerClock_Tick(object sender, EventArgs e)
        {
            lblClock.Text = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString();
        }

        // Kelime hatırlatıcısının veritabanından çekilen rastgele kelimelerle çalıştırılması sağlanıyor.
        private void btnStartWordReminders_Click(object sender, EventArgs e)
        {
            try
            {
                if (was.Select(w => w.profileID == currentProfile.ProfileID).Count <= 0)
                {
                    throw new Exception("Kelime hatırlatıcıyı çalıştırmadan önce kelime kaydetmelisiniz.");
                }

                Word word = new Word();
                List<Word> wordList = was.Select(w => w.profileID == currentProfile.ProfileID);
                List<int> wordIds = new List<int>();
                foreach (var item in wordList)
                {
                    wordIds.Add(item.wordID);
                }
                Random r = new Random();

                this.Hide();
                timerWordReminder.Tick += (x, a) =>
                {
                    int rastgeleSayi = r.Next(0, wordIds.Count);
                    int rastgeleId = wordIds[rastgeleSayi];
                    word = was.FindByID(rastgeleId);
                    WordType type = new WordType();
                    type = wtas.FindByID(word.typeID);

                    if (Application.OpenForms["ReminderForm"] == null)
                    {
                        ReminderForm reminderForm = new ReminderForm(word, type, currentProfile);
                        reminderForm.ShowDialog();
                    }

                };
                timerWordReminder.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnShowNewWordForm_Click(object sender, EventArgs e)
        {
            this.Hide();
            List<WordType> typeList = wtas.Select(wt => wt.profileID == currentProfile.ProfileID);
            NewWordForm newWordForm = new NewWordForm(currentProfile);
            newWordForm.ShowDialog();
        }
        
        // Uygulamadan çıkış
        private void btnCloseApp_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Uygulama Kapatılsın Mı?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                Environment.Exit(-1);
            }
        }

        private void SetAlert(string messagge)
        {
            MessageBox.Show(messagge, "İşlem Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
