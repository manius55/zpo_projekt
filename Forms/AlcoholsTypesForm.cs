using Microsoft.Data.Sqlite;
using SQLitePCL;
using System;
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
    public partial class AlcoholsTypesForm : Form
    {
        public AlcoholsTypesForm()
        {
            InitializeComponent();
            this.Load += loadFormData;
        }

        public void Reload()
        {
            List<AlcoholsTypesResource> sourceData = getSourceData();
            DataGridView alcoholsTypesGrid = alcoholsTypeForm;


            alcoholsTypesGrid.DataSource = sourceData;
        }

        private void loadFormData(object sender, EventArgs e)
        {
            InitStructure();
            Reload();
        }

        private void InitStructure()
        {
            DataGridView alcoholsTypesGrid = alcoholsTypeForm;
            alcoholsTypesGrid.AutoGenerateColumns = false;

            var alcoholTypeNameColumn = new DataGridViewTextBoxColumn();
            alcoholTypeNameColumn.DataPropertyName = "TypeName";
            alcoholTypeNameColumn.HeaderText = "Rodzaj alkoholu";
            alcoholTypeNameColumn.ReadOnly = true;

            var alcoholTypeColumn = new DataGridViewTextBoxColumn();
            alcoholTypeColumn.DataPropertyName = "Type";
            alcoholTypeColumn.Name = "Type";
            alcoholTypeColumn.HeaderText = "Type";
            alcoholTypeColumn.ReadOnly = true;
            alcoholTypeColumn.Visible = false;

            var alcoholDifferentTypesCount = new DataGridViewTextBoxColumn();
            alcoholDifferentTypesCount.DataPropertyName = "DifferentProductsCount";
            alcoholDifferentTypesCount.HeaderText = "Ilość różnych produktów";
            alcoholDifferentTypesCount.ReadOnly = true;

            var alcoholproductsCount = new DataGridViewTextBoxColumn();
            alcoholproductsCount.DataPropertyName = "ProductsCount";
            alcoholproductsCount.HeaderText = "Ilość łączna produktów";
            alcoholproductsCount.ReadOnly = true;

            var buttonColumn = new DataGridViewButtonColumn();
            buttonColumn.HeaderText = "Podgląd";
            buttonColumn.Text = "Podejrzyj";
            buttonColumn.Name = "Show";

            buttonColumn.UseColumnTextForButtonValue = true;


            alcoholsTypesGrid.Columns.Add(alcoholTypeNameColumn);
            alcoholsTypesGrid.Columns.Add(alcoholTypeColumn);
            alcoholsTypesGrid.Columns.Add(alcoholDifferentTypesCount);
            alcoholsTypesGrid.Columns.Add(alcoholproductsCount);
            alcoholsTypesGrid.Columns.Add(buttonColumn);


            alcoholsTypesGrid.CellContentClick += showButtonClick;
        }

        private List<AlcoholsTypesResource> getSourceData()
        {
            AlcoholRepository alcoholRepository = new AlcoholRepository();
            Dictionary<AlcoholType, List<Alcohol>> alcoholsByTypes = new Dictionary<AlcoholType, List<Alcohol>>();
            bool errorsOccured = false;
            bool databaseConnectionErrorOccured = false;

            foreach (AlcoholType type in Enum.GetValues(typeof(AlcoholType)))
            {
                try
                {
                    List<AlcoholEntity> alcoholEntities = alcoholRepository.getAllAlcoholsByType(type);
                    List<Alcohol> alcohols = AlcoholsFromEntitiesMaker.make(alcoholEntities);
                    alcoholsByTypes.Add(type, alcohols);
                }
                catch (SqliteException)
                {
                    errorsOccured = true;
                    databaseConnectionErrorOccured = true;
                }
                catch (Exception ex)
                {
                    errorsOccured = true;
                    Debug.Write(ex.ToString());
                }

            }

            if (errorsOccured && databaseConnectionErrorOccured)
            {
                MessageBox.Show("Wystąpił błąd przy łączeniu z bazą danych, spróbuj zmienić ścieżkę w ustawieniach");
            }
            else if (errorsOccured)
            {
                MessageBox.Show("Wystąpił błąd, niektóre typy alkoholi mogą nie wyświetlać się poprawnie.");
            }

            List<AlcoholsTypesResource> alcoholsTypesResources = new List<AlcoholsTypesResource>();

            foreach (var pair in alcoholsByTypes)
            {
                AlcoholType type = pair.Key;
                List<Alcohol> alcoholTypeList = pair.Value;

                if (alcoholTypeList.Count > 0)
                {
                    int productsCount = 0;
                    foreach (var alcohol in alcoholTypeList)
                    {
                        productsCount += alcohol.Count;
                    }

                    AlcoholsTypesResource resource = new AlcoholsTypesResource(
                        (int)type,
                        alcoholTypeList.Count,
                        alcoholTypeList[0].TypeName,
                        productsCount
                    );
                    alcoholsTypesResources.Add(resource);
                }
                else
                {
                    AlcoholsTypesResource resource = new AlcoholsTypesResource(
                        (int)type,
                        0,
                        GetAlcoholTypeName.Get((int)type),
                        0
                    );
                    alcoholsTypesResources.Add(resource);
                }
            }


            return alcoholsTypesResources;
        }

        private void showButtonClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == ((DataGridView)sender).Columns["Show"].Index && e.RowIndex >= 0)
                {

                    var alcoholTypeString = ((DataGridView)sender).Rows[e.RowIndex].Cells["Type"].Value.ToString();
                    int alcoholTypeInt = int.Parse(alcoholTypeString);
                    AlcoholType alcoholTypeEnum = (AlcoholType)alcoholTypeInt;

                    var singleAlcoholTypeForm = new SingleAlcoholTypeForm(alcoholTypeEnum, this);
                    singleAlcoholTypeForm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystąpił nieoczekiwany błąd: " + ex.Message);
            }
        }

        private void SettingsButton_Click(object sender, EventArgs e)
        {
            var form = new SettingsForm(this);
            form.ShowDialog();
        }
    }
}
