namespace zpo_projekt.Forms
{
    partial class AlcoholsTypesForm
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
            alcoholsTypeForm = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)alcoholsTypeForm).BeginInit();
            SuspendLayout();
            // 
            // alcoholsTypeForm
            // 
            alcoholsTypeForm.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            alcoholsTypeForm.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            alcoholsTypeForm.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            alcoholsTypeForm.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            alcoholsTypeForm.Location = new Point(98, 49);
            alcoholsTypeForm.Name = "alcoholsTypeForm";
            alcoholsTypeForm.RowHeadersWidth = 51;
            alcoholsTypeForm.Size = new Size(754, 421);
            alcoholsTypeForm.TabIndex = 1;
            // 
            // AlcoholsTypesForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(970, 529);
            Controls.Add(alcoholsTypeForm);
            Name = "AlcoholsTypesForm";
            Text = "AlcoholsTypesForm";
            ((System.ComponentModel.ISupportInitialize)alcoholsTypeForm).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView alcoholsTypeForm;
    }
}