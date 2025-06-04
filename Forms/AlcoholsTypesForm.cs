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

        private void loadFormData(object sender, EventArgs e)
        {

            List<AlcoholsTypesResource> sourceData = getSourceData();

            DataGridView alcoholsTypesGrid = alcoholsTypeForm;
            alcoholsTypesGrid.AutoGenerateColumns = false;

            var alcoholTypeColumn = new DataGridViewTextBoxColumn();
            alcoholTypeColumn.DataPropertyName = "TypeName";
            alcoholTypeColumn.HeaderText = "Rodzaj alkoholu";
            alcoholTypeColumn.ReadOnly = true;

            var alcoholDifferentTypesCount = new DataGridViewTextBoxColumn();
            alcoholDifferentTypesCount.DataPropertyName = "Count";
            alcoholDifferentTypesCount.HeaderText = "Ilość różnych produktów";
            alcoholDifferentTypesCount.ReadOnly = true;

            alcoholsTypesGrid.Columns.Add(alcoholTypeColumn);
            alcoholsTypesGrid.Columns.Add(alcoholDifferentTypesCount);

            alcoholsTypesGrid.DataSource = sourceData;
        }

        private List<AlcoholsTypesResource> getSourceData()
        {
            AlcoholRepository alcoholRepository = new AlcoholRepository();
            Dictionary<AlcoholType, List<Alcohol>> alcoholsByTypes = new Dictionary<AlcoholType, List<Alcohol>>();
            bool errorsOccured = false;

            foreach (AlcoholType type in Enum.GetValues(typeof(AlcoholType)))
            {
                try
                {
                    List<AlcoholEntity> alcoholEntities = alcoholRepository.getAllAlcoholsByType(type);
                    List<Alcohol> alcohols = AlcoholFromEntityMaker.make(alcoholEntities);
                    alcoholsByTypes.Add(type, alcohols);
                }
                catch (Exception ex)
                {
                    errorsOccured = true;
                    Debug.Write(ex.ToString());
                }

            }

            if (errorsOccured)
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
                    AlcoholsTypesResource resource = new AlcoholsTypesResource(
                        (int)type,
                        alcoholTypeList.Count,
                        alcoholTypeList[0].TypeName
                    );
                    alcoholsTypesResources.Add(resource);
                }
                else
                {
                    AlcoholsTypesResource resource = new AlcoholsTypesResource(
                        (int)type,
                        0,
                        type.ToString()
                    );
                    alcoholsTypesResources.Add(resource);
                }
            }


            return alcoholsTypesResources;
        }
    }
}
