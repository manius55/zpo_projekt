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

        public SingleAlcoholTypeForm(AlcoholType alcoholType)
        {
            this.AlcoholType = alcoholType;
            InitializeComponent();
            this.Load += loadFormData;
        }

        private void loadFormData(object sender, EventArgs e)
        {
            List<AlcoholEntity> alcoholsEntities = (new AlcoholRepository()).getAllAlcoholsByType(AlcoholType);
            List<Alcohol> alcohols = AlcoholFromEntityMaker.make(alcoholsEntities);


            DataGridView alcoholsGridView = alcoholsList;
            alcoholsGridView.AutoGenerateColumns = false;

            var idColumn = new DataGridViewTextBoxColumn();
            idColumn.DataPropertyName = "Id";
            idColumn.Visible = false; //bez sensu pokazywac uzytkownikowi id

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


            alcoholsGridView.Columns.Add(idColumn);
            alcoholsGridView.Columns.Add(typeColumn);
            alcoholsGridView.Columns.Add(nameColumn);
            alcoholsGridView.Columns.Add(percentageColumn);
            alcoholsGridView.Columns.Add(productsCount);

            alcoholsGridView.DataSource = alcohols;
        }

        private void AddAlcohol_Click(object sender, EventArgs e)
        {
            var addAlcoholForm = new AddEditAlcoholForm(this.AlcoholType, this);
            addAlcoholForm.ShowDialog();
        }
    }
}
