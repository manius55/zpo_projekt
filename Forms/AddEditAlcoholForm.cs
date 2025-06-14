﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using zpo_projekt.Alcohols;
using zpo_projekt.Entities;
using zpo_projekt.Exceptions;
using zpo_projekt.Repositories;

namespace zpo_projekt.Forms
{
    public partial class AddEditAlcoholForm : Form
    {
        private Alcohol alcohol { get; set; }
        private bool isEditing { get; set; } = false;
        private AlcoholType AlcoholType { get; set; }
        private SingleAlcoholTypeForm ParentForm;

        public AddEditAlcoholForm(AlcoholType alcoholType, SingleAlcoholTypeForm parentForm)
        {
            InitializeComponent();
            this.AlcoholType = alcoholType;
            this.ParentForm = parentForm;
        }

        public AddEditAlcoholForm(AlcoholType alcoholType, SingleAlcoholTypeForm parentForm, Alcohol alcohol)
        {
            InitializeComponent();
            this.alcohol = alcohol;
            this.ParentForm = parentForm;
            this.AlcoholType = alcoholType;
            this.Load += LoadAlcoholInitialDataForEdit;
            this.isEditing = true;
        }

        private void LoadAlcoholInitialDataForEdit(object sender, EventArgs e)
        {
            AlcoholNameTextBox.Text = alcohol.Name;
            AlcoholCountNumericBox.Value = alcohol.Count;
            AlcoholPercentageNumericBox.Value = Math.Round((decimal)alcohol.Percentage, 1);
            alcoholDescriptionTextBox.Text = alcohol.Description;
        }

        private void AlcoholSaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                AlcoholEntity alcoholEntity = this.isEditing ? this.alcohol.AlcoholEntity : new AlcoholEntity();

                AlcoholRepository alcoholRepository = new AlcoholRepository();
                FillEntityDataFromForm(ref alcoholEntity);

                var alcoholFromEntityMaker = new AlcoholFromEntityMaker();
                Alcohol alcohol = alcoholFromEntityMaker.make(alcoholEntity);

                try
                {
                    alcohol.ValidateOrThrow();
                }
                catch(ZeroAlcoholPercentageNotAllowedException ex)
                {
                    MessageBox.Show("Dla tego typu alkoholu nie jest dozwolone 0 jako zawartość % alkoholu");
                    return;
                }
                catch(AlcoholPercentageIsTooBigException ex)
                {
                    MessageBox.Show("Wprowadzona zawartość alkoholu jest za duża dla tego typu alkoholu");
                    return;
                }
                catch(AlcoholPercentageIsTooLowException ex)
                {
                    MessageBox.Show("Wprowadzona zawartość alkoholu jest za mała dla tego typu alkoholu");
                    return;
                }
                catch(MaxProducsFromConfigExceededException ex)
                {
                    MessageBox.Show("Przekroczono dopuszczalna liczbe napojow alkoholowych. Sprawdź config");
                    return;
                }
               

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

                ParentForm.ReloadData();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystąpił nieoczekiwany błąd: " + ex.Message);
            }
        }

        private void FillEntityDataFromForm(ref AlcoholEntity alcoholEntity)
        {
            alcoholEntity.Type = (int)this.AlcoholType;
            alcoholEntity.Name = AlcoholNameTextBox.Text;
            alcoholEntity.Percentage = Math.Round((double)AlcoholPercentageNumericBox.Value, 1);
            alcoholEntity.Description = alcoholDescriptionTextBox.Text;
            alcoholEntity.Count = (int)AlcoholCountNumericBox.Value;
        }

        private void AddAlcoholCancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
