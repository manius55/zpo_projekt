using System;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Windows.Forms;
using zpo_projekt.Alcohols;
using zpo_projekt.Entities;
using zpo_projekt.Forms;
using zpo_projekt.Repositories;

namespace zpo_projekt
{
    public partial class SingleAlcoholTypeForm : Form
    {
        private AlcoholType AlcoholType { get; set; }
        AlcoholsTypesForm ParentForm { get; set; }

        public SingleAlcoholTypeForm(AlcoholType alcoholType, AlcoholsTypesForm alcoholsTypesForm)
        {
            this.AlcoholType = alcoholType;
            InitializeComponent();
            this.Load += loadInitialFormData;
            this.ParentForm = alcoholsTypesForm;
        }

        public void ReloadData()
        {
            LoadDataForForm();
            ParentForm.Reload();
        }
        
        private void LoadDataForForm()
        {
            List<AlcoholEntity> alcoholsEntities = (new AlcoholRepository()).getAllAlcoholsByType(AlcoholType);
            List<Alcohol> alcohols = AlcoholsFromEntitiesMaker.make(alcoholsEntities);


            DataGridView alcoholsGridView = alcoholsList;

            alcoholsGridView.DataSource = alcohols;
        }

        private void InitStructure()
        {
            DataGridView alcoholsGridView = alcoholsList;
            alcoholsGridView.AutoGenerateColumns = false;

            var idColumn = new DataGridViewTextBoxColumn();
            idColumn.DataPropertyName = "Id";
            idColumn.Visible = false;
            idColumn.Name = "Id";

            var nameColumn = new DataGridViewTextBoxColumn();
            nameColumn.DataPropertyName = "Name";
            nameColumn.HeaderText = "Nazwa";
            nameColumn.ReadOnly = true;

            var percentageColumn = new DataGridViewTextBoxColumn();
            percentageColumn.DataPropertyName = "Percentage";
            percentageColumn.HeaderText = "Zawartoœæ alkoholu";
            percentageColumn.ReadOnly = true;

            var typeColumn = new DataGridViewTextBoxColumn();
            typeColumn.DataPropertyName = "TypeName";
            typeColumn.HeaderText = "Typ alkoholu";
            typeColumn.ReadOnly = true;


            var productsCount = new DataGridViewTextBoxColumn();
            productsCount.DataPropertyName = "Count";
            productsCount.HeaderText = "Iloœæ produktów";
            productsCount.ReadOnly = true;



            var editButtonColumn = new DataGridViewButtonColumn();
            editButtonColumn.HeaderText = "Edycja";
            editButtonColumn.Text = "Edytuj";
            editButtonColumn.Name = "Edit";
            editButtonColumn.UseColumnTextForButtonValue = true;

            var deleteButton = new DataGridViewButtonColumn();
            deleteButton.HeaderText = "Usuwanie";
            deleteButton.Text = "Usuñ";
            deleteButton.Name = "Remove";
            deleteButton.UseColumnTextForButtonValue = true;

            alcoholsGridView.Columns.Add(idColumn);
            alcoholsGridView.Columns.Add(typeColumn);
            alcoholsGridView.Columns.Add(nameColumn);
            alcoholsGridView.Columns.Add(percentageColumn);
            alcoholsGridView.Columns.Add(productsCount);
            alcoholsGridView.Columns.Add(editButtonColumn);
            alcoholsGridView.Columns.Add(deleteButton);


            alcoholsGridView.CellContentClick += EditButtonClick;
            alcoholsGridView.CellContentClick += DeleteButtonClick;
        }

        private void loadInitialFormData(object sender, EventArgs e)
        {
            InitStructure();
            ReloadData();
        }

        private void AddAlcohol_Click(object sender, EventArgs e)
        {
            var addAlcoholForm = new AddEditAlcoholForm(this.AlcoholType, this);
            addAlcoholForm.ShowDialog();
        }

        private void EditButtonClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == ((DataGridView)sender).Columns["Edit"].Index && e.RowIndex >= 0)
                {
                    string alcoholId = ((DataGridView)sender).Rows[e.RowIndex].Cells["Id"].Value.ToString();
                    int alcoholIdInt = Convert.ToInt32(alcoholId);

                    AlcoholEntity alcoholEntity = (new AlcoholRepository()).getById(alcoholIdInt);
                    var alcohol = AlcoholFromEntityMaker.make(alcoholEntity);

                    var editAlcoholForm = new AddEditAlcoholForm(this.AlcoholType, this, alcohol);
                    editAlcoholForm.ShowDialog();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Wyst¹pi³ niespodziewany wyj¹tek: " + exception.Message);
            }
        }

        private void DeleteButtonClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == ((DataGridView)sender).Columns["Remove"].Index && e.RowIndex >= 0)
                {
                    string alcoholId = ((DataGridView)sender).Rows[e.RowIndex].Cells["Id"].Value.ToString();
                    int alcoholIdInt = Convert.ToInt32(alcoholId);

                    var repository = new AlcoholRepository();
                    AlcoholEntity alcoholEntity = repository.getById(alcoholIdInt);

                    repository.Remove(alcoholEntity);

                    MessageBox.Show("Uda³o siê usun¹æ produkt");
                    this.ReloadData();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Wyst¹pi³ niespodziewany wyj¹tek: " + exception.Message);
            }
        }
    }
}
