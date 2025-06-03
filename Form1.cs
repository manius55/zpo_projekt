using System.Diagnostics;
using System.Windows.Forms;
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
            List<Alcohol> alcohols = context.Alcohols.ToList();

            DataGridView alcoholsGridView = alcoholsList;
            alcoholsGridView.AutoGenerateColumns = false;

            var idColumn = new DataGridViewTextBoxColumn();
            idColumn.DataPropertyName = "Id";
            idColumn.HeaderText="ID";
            idColumn.Visible = false; //bez sensu pokazywac uzytkownikowi id

            var nameColumn = new DataGridViewTextBoxColumn();
            nameColumn.DataPropertyName = "Name";
            nameColumn.HeaderText = "Nazwa";

            var percentageColumn = new DataGridViewTextBoxColumn();
            percentageColumn.DataPropertyName = "Percentage";
            percentageColumn.HeaderText = "Zawartoœæ alkoholu";

            var typeColumn = new DataGridViewTextBoxColumn();
            typeColumn.DataPropertyName = "Type";
            typeColumn.HeaderText = "Typ alkoholu";

            alcoholsGridView.Columns.Add(idColumn);
            alcoholsGridView.Columns.Add(typeColumn);
            alcoholsGridView.Columns.Add(nameColumn);
            alcoholsGridView.Columns.Add(percentageColumn);

            alcoholsGridView.DataSource = alcohols;
        }
    }
}
