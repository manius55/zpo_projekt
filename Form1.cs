using System.Diagnostics;
using System.Windows.Forms;
using zpo_projekt.Alcohols;
using zpo_projekt.Entities;

namespace zpo_projekt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Load += loadFormData;
        }

        private void loadFormData(object sender, EventArgs e)
        {
            var context = new AlcoholsDbContext();
            List<AlcoholEntity> alcoholsEntities = context.Alcohols.ToList();
            List<Alcohol> alcohols = new List<Alcohol>();

            foreach(AlcoholEntity alcoholEntity in alcoholsEntities)
            {
                Alcohol alcohol = AlcoholFactory.get(alcoholEntity);
                alcohols.Add(alcohol);
            }

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

            alcoholsGridView.Columns.Add(idColumn);
            alcoholsGridView.Columns.Add(typeColumn);
            alcoholsGridView.Columns.Add(nameColumn);
            alcoholsGridView.Columns.Add(percentageColumn);

            alcoholsGridView.DataSource = alcohols;
        }
    }
}
