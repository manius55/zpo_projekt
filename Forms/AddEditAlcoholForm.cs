using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using zpo_projekt.Alcohols;
using zpo_projekt.Entities;
using zpo_projekt.Repositories;

namespace zpo_projekt.Forms
{
    public partial class AddEditAlcoholForm : Form
    {
        private Alcohol alcohol;
        private bool isEditing = false;

        public AddEditAlcoholForm()
        {
            InitializeComponent();
        }

        public AddEditAlcoholForm(Alcohol alcohol)
        {
            InitializeComponent();
            this.alcohol = alcohol;
            this.Load += LoadAlcoholInitialDataForEdit;
            this.isEditing = true;
        }

        private void LoadAlcoholInitialDataForEdit(object sender, EventArgs e)
        {
            AlcoholNameTextBox.Text = alcohol.Name;
            AlcoholCountNumericBox.Value = alcohol.Count;
            alcoholPercentageTextBox.Text = alcohol.Percentage.ToString();
            alcoholDescriptionTextBox.Text = alcohol.Description;
        }

        private void AlcoholSaveButton_Click(object sender, EventArgs e)
        {
            AlcoholEntity alcoholEntity = this.isEditing ? this.alcohol.AlcoholEntity : new AlcoholEntity();
            
            AlcoholRepository alcoholRepository = new AlcoholRepository();

            if (this.isEditing)
            {
                alcoholRepository.Update(alcoholEntity);
                MessageBox.Show("Udało się zaktualizować produkt");
            }
            else
            {
                alcoholRepository.Add(alcoholEntity);
                MessageBox.Show("Udało się utworzyć produkt");
            }

            this.Close();
        }

        private void AddAlcoholCancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
