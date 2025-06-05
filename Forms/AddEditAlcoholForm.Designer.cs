namespace zpo_projekt.Forms
{
    partial class AddEditAlcoholForm
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
            components = new System.ComponentModel.Container();
            AddAlcoholSaveButton = new Button();
            AddAlcoholCancelButton = new Button();
            contextMenuStrip1 = new ContextMenuStrip(components);
            AlcoholNameTextBox = new TextBox();
            alcoholDescriptionTextBox = new TextBox();
            AlcoholCountNumericBox = new NumericUpDown();
            alcoholNameLabel = new Label();
            alcoholPercentageLabel = new Label();
            alcoholCountLabel = new Label();
            alcoholDescriptionLabel = new Label();
            AlcoholPercentageNumericBox = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)AlcoholCountNumericBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)AlcoholPercentageNumericBox).BeginInit();
            SuspendLayout();
            // 
            // AddAlcoholSaveButton
            // 
            AddAlcoholSaveButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            AddAlcoholSaveButton.Location = new Point(12, 399);
            AddAlcoholSaveButton.Name = "AddAlcoholSaveButton";
            AddAlcoholSaveButton.Size = new Size(157, 39);
            AddAlcoholSaveButton.TabIndex = 0;
            AddAlcoholSaveButton.Text = "Zapisz";
            AddAlcoholSaveButton.UseVisualStyleBackColor = true;
            AddAlcoholSaveButton.Click += AlcoholSaveButton_Click;
            // 
            // AddAlcoholCancelButton
            // 
            AddAlcoholCancelButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            AddAlcoholCancelButton.Location = new Point(631, 399);
            AddAlcoholCancelButton.Name = "AddAlcoholCancelButton";
            AddAlcoholCancelButton.Size = new Size(157, 39);
            AddAlcoholCancelButton.TabIndex = 1;
            AddAlcoholCancelButton.Text = "Anuluj";
            AddAlcoholCancelButton.UseVisualStyleBackColor = true;
            AddAlcoholCancelButton.Click += AddAlcoholCancelButton_Click;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // AlcoholNameTextBox
            // 
            AlcoholNameTextBox.Location = new Point(250, 87);
            AlcoholNameTextBox.MaxLength = 50;
            AlcoholNameTextBox.Name = "AlcoholNameTextBox";
            AlcoholNameTextBox.Size = new Size(462, 27);
            AlcoholNameTextBox.TabIndex = 3;
            // 
            // alcoholDescriptionTextBox
            // 
            alcoholDescriptionTextBox.Location = new Point(250, 234);
            alcoholDescriptionTextBox.Name = "alcoholDescriptionTextBox";
            alcoholDescriptionTextBox.Size = new Size(462, 27);
            alcoholDescriptionTextBox.TabIndex = 4;
            // 
            // AlcoholCountNumericBox
            // 
            AlcoholCountNumericBox.Location = new Point(250, 190);
            AlcoholCountNumericBox.Name = "AlcoholCountNumericBox";
            AlcoholCountNumericBox.Size = new Size(150, 27);
            AlcoholCountNumericBox.TabIndex = 5;
            // 
            // alcoholNameLabel
            // 
            alcoholNameLabel.AutoSize = true;
            alcoholNameLabel.Location = new Point(83, 94);
            alcoholNameLabel.Name = "alcoholNameLabel";
            alcoholNameLabel.Size = new Size(54, 20);
            alcoholNameLabel.TabIndex = 7;
            alcoholNameLabel.Text = "Nazwa";
            // 
            // alcoholPercentageLabel
            // 
            alcoholPercentageLabel.AutoSize = true;
            alcoholPercentageLabel.Location = new Point(83, 148);
            alcoholPercentageLabel.Name = "alcoholPercentageLabel";
            alcoholPercentageLabel.Size = new Size(138, 20);
            alcoholPercentageLabel.TabIndex = 8;
            alcoholPercentageLabel.Text = "Zawartość alkoholu";
            // 
            // alcoholCountLabel
            // 
            alcoholCountLabel.AutoSize = true;
            alcoholCountLabel.Location = new Point(83, 197);
            alcoholCountLabel.Name = "alcoholCountLabel";
            alcoholCountLabel.Size = new Size(39, 20);
            alcoholCountLabel.TabIndex = 9;
            alcoholCountLabel.Text = "Ilość";
            // 
            // alcoholDescriptionLabel
            // 
            alcoholDescriptionLabel.AutoSize = true;
            alcoholDescriptionLabel.Location = new Point(83, 241);
            alcoholDescriptionLabel.Name = "alcoholDescriptionLabel";
            alcoholDescriptionLabel.Size = new Size(39, 20);
            alcoholDescriptionLabel.TabIndex = 10;
            alcoholDescriptionLabel.Text = "Opis";
            // 
            // AlcoholPercentageNumericBox
            // 
            AlcoholPercentageNumericBox.DecimalPlaces = 1;
            AlcoholPercentageNumericBox.Location = new Point(250, 141);
            AlcoholPercentageNumericBox.Name = "AlcoholPercentageNumericBox";
            AlcoholPercentageNumericBox.Size = new Size(150, 27);
            AlcoholPercentageNumericBox.TabIndex = 11;
            // 
            // AddEditAlcoholForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(AlcoholPercentageNumericBox);
            Controls.Add(alcoholDescriptionLabel);
            Controls.Add(alcoholCountLabel);
            Controls.Add(alcoholPercentageLabel);
            Controls.Add(alcoholNameLabel);
            Controls.Add(AlcoholCountNumericBox);
            Controls.Add(alcoholDescriptionTextBox);
            Controls.Add(AlcoholNameTextBox);
            Controls.Add(AddAlcoholCancelButton);
            Controls.Add(AddAlcoholSaveButton);
            Name = "AddEditAlcoholForm";
            Text = "AddAlcoholForm";
            ((System.ComponentModel.ISupportInitialize)AlcoholCountNumericBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)AlcoholPercentageNumericBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button AddAlcoholSaveButton;
        private Button AddAlcoholCancelButton;
        private ContextMenuStrip contextMenuStrip1;
        private TextBox AlcoholNameTextBox;
        private TextBox alcoholDescriptionTextBox;
        private NumericUpDown AlcoholCountNumericBox;
        private Label alcoholNameLabel;
        private Label alcoholPercentageLabel;
        private Label alcoholCountLabel;
        private Label alcoholDescriptionLabel;
        private NumericUpDown AlcoholPercentageNumericBox;
    }
}