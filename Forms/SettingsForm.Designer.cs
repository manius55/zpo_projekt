namespace zpo_projekt.Forms
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DatabsePathText = new TextBox();
            MaxAlcoholProductsNumericBox = new NumericUpDown();
            label1 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)MaxAlcoholProductsNumericBox).BeginInit();
            SuspendLayout();
            // 
            // DatabsePathText
            // 
            DatabsePathText.Location = new Point(319, 134);
            DatabsePathText.MaxLength = 2000;
            DatabsePathText.Name = "DatabsePathText";
            DatabsePathText.Size = new Size(535, 27);
            DatabsePathText.TabIndex = 0;
            DatabsePathText.TextChanged += textBox1_TextChanged;
            // 
            // MaxAlcoholProductsNumericBox
            // 
            MaxAlcoholProductsNumericBox.Location = new Point(319, 190);
            MaxAlcoholProductsNumericBox.Maximum = new decimal(new int[] { 5000, 0, 0, 0 });
            MaxAlcoholProductsNumericBox.Name = "MaxAlcoholProductsNumericBox";
            MaxAlcoholProductsNumericBox.Size = new Size(150, 27);
            MaxAlcoholProductsNumericBox.TabIndex = 1;
            MaxAlcoholProductsNumericBox.ValueChanged += numericUpDown1_ValueChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 134);
            label1.Name = "label1";
            label1.Size = new Size(202, 20);
            label1.TabIndex = 2;
            label1.Text = "Ścieżka do pliku bazy danych";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 192);
            label2.Name = "label2";
            label2.Size = new Size(296, 20);
            label2.TabIndex = 3;
            label2.Text = "Maksymalna ilość produktów alkoholowych";
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1052, 579);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(MaxAlcoholProductsNumericBox);
            Controls.Add(DatabsePathText);
            Name = "SettingsForm";
            Text = "SettingsForm";
            ((System.ComponentModel.ISupportInitialize)MaxAlcoholProductsNumericBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox DatabsePathText;
        private NumericUpDown MaxAlcoholProductsNumericBox;
        private Label label1;
        private Label label2;
    }
}