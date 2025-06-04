namespace zpo_projekt
{
    partial class AlcoholTypeView
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            alcoholsList = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)alcoholsList).BeginInit();
            SuspendLayout();
            // 
            // alcoholsList
            // 
            alcoholsList.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            alcoholsList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            alcoholsList.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            alcoholsList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            alcoholsList.Location = new Point(221, 73);
            alcoholsList.Name = "alcoholsList";
            alcoholsList.RowHeadersWidth = 51;
            alcoholsList.Size = new Size(684, 546);
            alcoholsList.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1119, 700);
            Controls.Add(alcoholsList);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)alcoholsList).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView alcoholsList;
    }
}
