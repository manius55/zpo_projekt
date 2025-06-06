using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zpo_projekt.Forms
{
    public partial class SettingsForm : Form
    {
        private AlcoholsTypesForm ParentForm {  get; set; }


        public SettingsForm(AlcoholsTypesForm alcoholsTypesForm)
        {
            InitializeComponent();
            this.Load += LoadFormData;
            this.ParentForm = alcoholsTypesForm;
        }

        private void LoadFormData(object sender, EventArgs e)
        {
            Config config = Config.GetInstance();

            DatabsePathText.Text = config.DatabasePath;
            MaxAlcoholProductsNumericBox.Value = config.MaxProductCount;
        }

        private void SaveSettingsButton_Click(object sender, EventArgs e)
        {
            Config config = Config.GetInstance();
            config.MaxProductCount = Convert.ToInt32(MaxAlcoholProductsNumericBox.Value);
            config.DatabasePath = DatabsePathText.Text;
            config.Save();
            MessageBox.Show("Udało się zaktualizować ustawienia");
            ParentForm.Reload();
            this.Close();
        }

        private void CancelSettingsButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
