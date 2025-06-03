using System.Diagnostics;

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
            var data = context.Alcohols.ToList();

            // Wyœwietl w konsoli (lub gdzieœ indziej, np. w kontrolce)
            foreach (var alcohol in data)
            {
                Debug.WriteLine($"Id: {alcohol.Id}, Name: {alcohol.Name}");
            }
        }
    }
}
