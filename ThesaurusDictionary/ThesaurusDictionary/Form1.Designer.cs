
namespace ThesaurusDictionary
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.R_WordName = new System.Windows.Forms.TextBox();
            this.R_WordPhonetics = new System.Windows.Forms.TextBox();
            this.R_WordMeaning = new System.Windows.Forms.RichTextBox();
            this.R_WordSynonym = new System.Windows.Forms.TextBox();
            this.R_WordAntonym = new System.Windows.Forms.TextBox();
            this.R_WordHyperonym = new System.Windows.Forms.TextBox();
            this.R_WordHyponym = new System.Windows.Forms.TextBox();
            this.R_WordSynonymLabel = new System.Windows.Forms.Label();
            this.R_WordAntonymLabel = new System.Windows.Forms.Label();
            this.R_WordHyperonymLabel = new System.Windows.Forms.Label();
            this.R_WordHyponymText = new System.Windows.Forms.Label();
            this.R_WordExampleLabel = new System.Windows.Forms.Label();
            this.R_WordExample = new System.Windows.Forms.RichTextBox();
            this.R_ButtonAdd = new System.Windows.Forms.Button();
            this.L_ButtonSerialize = new System.Windows.Forms.Button();
            this.L_ButtonDeserialize = new System.Windows.Forms.Button();
            this.L_List = new System.Windows.Forms.ListView();
            this.AllWords = new System.Windows.Forms.ColumnHeader();
            this.R_ButtonClear = new System.Windows.Forms.Button();
            this.L_ButtonDeleteString = new System.Windows.Forms.Button();
            this.R_WordType = new System.Windows.Forms.ComboBox();
            this.R_WordSoul = new System.Windows.Forms.ComboBox();
            this.R_WordGen = new System.Windows.Forms.ComboBox();
            this.L_ListSearch = new System.Windows.Forms.TextBox();
            this.L_ListSearchLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // R_WordName
            // 
            this.R_WordName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.R_WordName.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.R_WordName.Font = new System.Drawing.Font("Segoe UI", 21F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.R_WordName.Location = new System.Drawing.Point(323, 23);
            this.R_WordName.Name = "R_WordName";
            this.R_WordName.Size = new System.Drawing.Size(549, 47);
            this.R_WordName.TabIndex = 0;
            this.R_WordName.Text = "слово";
            this.R_WordName.TextChanged += new System.EventHandler(this.R_WordName_TextChanged);
            // 
            // R_WordPhonetics
            // 
            this.R_WordPhonetics.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.R_WordPhonetics.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.R_WordPhonetics.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.R_WordPhonetics.ForeColor = System.Drawing.SystemColors.GrayText;
            this.R_WordPhonetics.Location = new System.Drawing.Point(323, 76);
            this.R_WordPhonetics.Name = "R_WordPhonetics";
            this.R_WordPhonetics.Size = new System.Drawing.Size(549, 24);
            this.R_WordPhonetics.TabIndex = 2;
            this.R_WordPhonetics.Text = "обозначение звучания";
            this.R_WordPhonetics.TextChanged += new System.EventHandler(this.R_WordPhonetics_TextChanged);
            // 
            // R_WordMeaning
            // 
            this.R_WordMeaning.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.R_WordMeaning.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.R_WordMeaning.Location = new System.Drawing.Point(323, 153);
            this.R_WordMeaning.Name = "R_WordMeaning";
            this.R_WordMeaning.Size = new System.Drawing.Size(549, 131);
            this.R_WordMeaning.TabIndex = 6;
            this.R_WordMeaning.Text = "Толкование";
            this.R_WordMeaning.TextChanged += new System.EventHandler(this.R_WordMeaning_TextChanged);
            // 
            // R_WordSynonym
            // 
            this.R_WordSynonym.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.R_WordSynonym.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.R_WordSynonym.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.R_WordSynonym.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.R_WordSynonym.ForeColor = System.Drawing.SystemColors.ControlText;
            this.R_WordSynonym.Location = new System.Drawing.Point(448, 289);
            this.R_WordSynonym.Name = "R_WordSynonym";
            this.R_WordSynonym.Size = new System.Drawing.Size(424, 27);
            this.R_WordSynonym.TabIndex = 7;
            this.R_WordSynonym.Text = "синоним";
            this.R_WordSynonym.TextChanged += new System.EventHandler(this.R_WordSynonym_TextChanged);
            // 
            // R_WordAntonym
            // 
            this.R_WordAntonym.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.R_WordAntonym.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.R_WordAntonym.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.R_WordAntonym.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.R_WordAntonym.ForeColor = System.Drawing.SystemColors.ControlText;
            this.R_WordAntonym.Location = new System.Drawing.Point(448, 323);
            this.R_WordAntonym.Name = "R_WordAntonym";
            this.R_WordAntonym.Size = new System.Drawing.Size(424, 27);
            this.R_WordAntonym.TabIndex = 8;
            this.R_WordAntonym.Text = "антоним";
            this.R_WordAntonym.TextChanged += new System.EventHandler(this.R_WordAntonym_TextChanged);
            // 
            // R_WordHyperonym
            // 
            this.R_WordHyperonym.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.R_WordHyperonym.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.R_WordHyperonym.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.R_WordHyperonym.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.R_WordHyperonym.ForeColor = System.Drawing.SystemColors.ControlText;
            this.R_WordHyperonym.Location = new System.Drawing.Point(448, 356);
            this.R_WordHyperonym.Name = "R_WordHyperonym";
            this.R_WordHyperonym.Size = new System.Drawing.Size(425, 27);
            this.R_WordHyperonym.TabIndex = 9;
            this.R_WordHyperonym.Text = "гипероним";
            this.R_WordHyperonym.TextChanged += new System.EventHandler(this.R_WordHyperonym_TextChanged);
            // 
            // R_WordHyponym
            // 
            this.R_WordHyponym.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.R_WordHyponym.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.R_WordHyponym.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.R_WordHyponym.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.R_WordHyponym.ForeColor = System.Drawing.SystemColors.ControlText;
            this.R_WordHyponym.Location = new System.Drawing.Point(448, 388);
            this.R_WordHyponym.Name = "R_WordHyponym";
            this.R_WordHyponym.Size = new System.Drawing.Size(423, 27);
            this.R_WordHyponym.TabIndex = 10;
            this.R_WordHyponym.Text = "гипоним";
            this.R_WordHyponym.TextChanged += new System.EventHandler(this.R_WordHyponym_TextChanged);
            // 
            // R_WordSynonymLabel
            // 
            this.R_WordSynonymLabel.AutoSize = true;
            this.R_WordSynonymLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.R_WordSynonymLabel.Location = new System.Drawing.Point(319, 289);
            this.R_WordSynonymLabel.Name = "R_WordSynonymLabel";
            this.R_WordSynonymLabel.Size = new System.Drawing.Size(104, 28);
            this.R_WordSynonymLabel.TabIndex = 11;
            this.R_WordSynonymLabel.Text = "Синоним:";
            this.R_WordSynonymLabel.Click += new System.EventHandler(this.R_WordSynonymLabel_Click);
            // 
            // R_WordAntonymLabel
            // 
            this.R_WordAntonymLabel.AutoSize = true;
            this.R_WordAntonymLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.R_WordAntonymLabel.Location = new System.Drawing.Point(319, 323);
            this.R_WordAntonymLabel.Name = "R_WordAntonymLabel";
            this.R_WordAntonymLabel.Size = new System.Drawing.Size(102, 28);
            this.R_WordAntonymLabel.TabIndex = 12;
            this.R_WordAntonymLabel.Text = "Антоним:";
            // 
            // R_WordHyperonymLabel
            // 
            this.R_WordHyperonymLabel.AutoSize = true;
            this.R_WordHyperonymLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.R_WordHyperonymLabel.Location = new System.Drawing.Point(319, 356);
            this.R_WordHyperonymLabel.Name = "R_WordHyperonymLabel";
            this.R_WordHyperonymLabel.Size = new System.Drawing.Size(123, 28);
            this.R_WordHyperonymLabel.TabIndex = 13;
            this.R_WordHyperonymLabel.Text = "Гипероним:";
            // 
            // R_WordHyponymText
            // 
            this.R_WordHyponymText.AutoSize = true;
            this.R_WordHyponymText.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.R_WordHyponymText.Location = new System.Drawing.Point(319, 388);
            this.R_WordHyponymText.Name = "R_WordHyponymText";
            this.R_WordHyponymText.Size = new System.Drawing.Size(100, 28);
            this.R_WordHyponymText.TabIndex = 14;
            this.R_WordHyponymText.Text = "Гипоним:";
            // 
            // R_WordExampleLabel
            // 
            this.R_WordExampleLabel.AutoSize = true;
            this.R_WordExampleLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.R_WordExampleLabel.Location = new System.Drawing.Point(319, 437);
            this.R_WordExampleLabel.Name = "R_WordExampleLabel";
            this.R_WordExampleLabel.Size = new System.Drawing.Size(244, 28);
            this.R_WordExampleLabel.TabIndex = 15;
            this.R_WordExampleLabel.Text = "Пример использования:";
            // 
            // R_WordExample
            // 
            this.R_WordExample.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.R_WordExample.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.R_WordExample.Location = new System.Drawing.Point(322, 476);
            this.R_WordExample.Name = "R_WordExample";
            this.R_WordExample.Size = new System.Drawing.Size(549, 96);
            this.R_WordExample.TabIndex = 16;
            this.R_WordExample.Text = "Пример использования";
            this.R_WordExample.TextChanged += new System.EventHandler(this.R_WordExample_TextChanged);
            // 
            // R_ButtonAdd
            // 
            this.R_ButtonAdd.BackColor = System.Drawing.Color.RoyalBlue;
            this.R_ButtonAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.R_ButtonAdd.FlatAppearance.BorderSize = 0;
            this.R_ButtonAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.R_ButtonAdd.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.R_ButtonAdd.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.R_ButtonAdd.Location = new System.Drawing.Point(480, 579);
            this.R_ButtonAdd.Name = "R_ButtonAdd";
            this.R_ButtonAdd.Size = new System.Drawing.Size(392, 44);
            this.R_ButtonAdd.TabIndex = 18;
            this.R_ButtonAdd.Text = "Добавить слово";
            this.R_ButtonAdd.UseVisualStyleBackColor = false;
            this.R_ButtonAdd.Click += new System.EventHandler(this.R_ButtonAdd_Click);
            // 
            // L_ButtonSerialize
            // 
            this.L_ButtonSerialize.BackColor = System.Drawing.SystemColors.ControlLight;
            this.L_ButtonSerialize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.L_ButtonSerialize.FlatAppearance.BorderSize = 0;
            this.L_ButtonSerialize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.L_ButtonSerialize.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.L_ButtonSerialize.Location = new System.Drawing.Point(14, 579);
            this.L_ButtonSerialize.Name = "L_ButtonSerialize";
            this.L_ButtonSerialize.Size = new System.Drawing.Size(286, 44);
            this.L_ButtonSerialize.TabIndex = 19;
            this.L_ButtonSerialize.Text = "Сохранить словарь";
            this.L_ButtonSerialize.UseVisualStyleBackColor = false;
            this.L_ButtonSerialize.Click += new System.EventHandler(this.L_ButtonSerialize_Click);
            // 
            // L_ButtonDeserialize
            // 
            this.L_ButtonDeserialize.BackColor = System.Drawing.Color.Gainsboro;
            this.L_ButtonDeserialize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.L_ButtonDeserialize.FlatAppearance.BorderSize = 0;
            this.L_ButtonDeserialize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.L_ButtonDeserialize.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.L_ButtonDeserialize.Location = new System.Drawing.Point(14, 529);
            this.L_ButtonDeserialize.Name = "L_ButtonDeserialize";
            this.L_ButtonDeserialize.Size = new System.Drawing.Size(286, 44);
            this.L_ButtonDeserialize.TabIndex = 20;
            this.L_ButtonDeserialize.Text = "Загрузить словарь";
            this.L_ButtonDeserialize.UseVisualStyleBackColor = false;
            this.L_ButtonDeserialize.Click += new System.EventHandler(this.L_ButtonDeserialize_Click);
            // 
            // L_List
            // 
            this.L_List.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.L_List.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.L_List.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.AllWords});
            this.L_List.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.L_List.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.L_List.HideSelection = false;
            this.L_List.Location = new System.Drawing.Point(14, 69);
            this.L_List.MultiSelect = false;
            this.L_List.Name = "L_List";
            this.L_List.Size = new System.Drawing.Size(285, 404);
            this.L_List.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.L_List.TabIndex = 21;
            this.L_List.UseCompatibleStateImageBehavior = false;
            this.L_List.View = System.Windows.Forms.View.Details;
            this.L_List.Click += new System.EventHandler(this.L_List_SelectedIndexChanged);
            // 
            // AllWords
            // 
            this.AllWords.Tag = "word";
            this.AllWords.Text = "";
            this.AllWords.Width = 250;
            // 
            // R_ButtonClear
            // 
            this.R_ButtonClear.BackColor = System.Drawing.SystemColors.ControlLight;
            this.R_ButtonClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.R_ButtonClear.FlatAppearance.BorderSize = 0;
            this.R_ButtonClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.R_ButtonClear.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.R_ButtonClear.ForeColor = System.Drawing.SystemColors.MenuText;
            this.R_ButtonClear.Location = new System.Drawing.Point(323, 579);
            this.R_ButtonClear.Name = "R_ButtonClear";
            this.R_ButtonClear.Size = new System.Drawing.Size(151, 44);
            this.R_ButtonClear.TabIndex = 22;
            this.R_ButtonClear.Text = "Очистить поля";
            this.R_ButtonClear.UseVisualStyleBackColor = false;
            this.R_ButtonClear.Click += new System.EventHandler(this.R_ButtonClear_Click);
            // 
            // L_ButtonDeleteString
            // 
            this.L_ButtonDeleteString.BackColor = System.Drawing.Color.OrangeRed;
            this.L_ButtonDeleteString.Cursor = System.Windows.Forms.Cursors.Hand;
            this.L_ButtonDeleteString.FlatAppearance.BorderSize = 0;
            this.L_ButtonDeleteString.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.L_ButtonDeleteString.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.L_ButtonDeleteString.ForeColor = System.Drawing.Color.White;
            this.L_ButtonDeleteString.Location = new System.Drawing.Point(14, 479);
            this.L_ButtonDeleteString.Name = "L_ButtonDeleteString";
            this.L_ButtonDeleteString.Size = new System.Drawing.Size(286, 44);
            this.L_ButtonDeleteString.TabIndex = 23;
            this.L_ButtonDeleteString.Text = "Удалить выбранное слово";
            this.L_ButtonDeleteString.UseVisualStyleBackColor = false;
            this.L_ButtonDeleteString.Click += new System.EventHandler(this.L_ButtonDeleteString_Click);
            // 
            // R_WordType
            // 
            this.R_WordType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.R_WordType.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.R_WordType.ForeColor = System.Drawing.SystemColors.GrayText;
            this.R_WordType.FormattingEnabled = true;
            this.R_WordType.Items.AddRange(new object[] {
            "существительное",
            "прилагательное",
            "глагол",
            "причастие",
            "наречие",
            "числительное"});
            this.R_WordType.Location = new System.Drawing.Point(320, 105);
            this.R_WordType.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.R_WordType.Name = "R_WordType";
            this.R_WordType.Size = new System.Drawing.Size(179, 31);
            this.R_WordType.TabIndex = 24;
            this.R_WordType.SelectedIndexChanged += new System.EventHandler(this.R_WordType_SelectedIndexChanged);
            // 
            // R_WordSoul
            // 
            this.R_WordSoul.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.R_WordSoul.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.R_WordSoul.ForeColor = System.Drawing.SystemColors.GrayText;
            this.R_WordSoul.FormattingEnabled = true;
            this.R_WordSoul.Items.AddRange(new object[] {
            "одушевленное",
            "неодушевленное",
            "-"});
            this.R_WordSoul.Location = new System.Drawing.Point(506, 105);
            this.R_WordSoul.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.R_WordSoul.Name = "R_WordSoul";
            this.R_WordSoul.Size = new System.Drawing.Size(179, 31);
            this.R_WordSoul.TabIndex = 25;
            this.R_WordSoul.SelectedIndexChanged += new System.EventHandler(this.R_WordSoul_SelectedIndexChanged);
            // 
            // R_WordGen
            // 
            this.R_WordGen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.R_WordGen.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.R_WordGen.ForeColor = System.Drawing.SystemColors.GrayText;
            this.R_WordGen.FormattingEnabled = true;
            this.R_WordGen.Items.AddRange(new object[] {
            "мужской род",
            "женский род",
            "средний род",
            "-"});
            this.R_WordGen.Location = new System.Drawing.Point(693, 105);
            this.R_WordGen.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.R_WordGen.Name = "R_WordGen";
            this.R_WordGen.Size = new System.Drawing.Size(179, 31);
            this.R_WordGen.TabIndex = 26;
            this.R_WordGen.SelectedIndexChanged += new System.EventHandler(this.R_WordGen_SelectedIndexChanged);
            // 
            // L_ListSearch
            // 
            this.L_ListSearch.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.L_ListSearch.Location = new System.Drawing.Point(88, 24);
            this.L_ListSearch.Margin = new System.Windows.Forms.Padding(7, 4, 3, 4);
            this.L_ListSearch.Name = "L_ListSearch";
            this.L_ListSearch.Size = new System.Drawing.Size(211, 34);
            this.L_ListSearch.TabIndex = 27;
            this.L_ListSearch.TextChanged += new System.EventHandler(this.L_ListSearch_TextChanged);
            // 
            // L_ListSearchLabel
            // 
            this.L_ListSearchLabel.AutoSize = true;
            this.L_ListSearchLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.L_ListSearchLabel.Location = new System.Drawing.Point(8, 28);
            this.L_ListSearchLabel.Name = "L_ListSearchLabel";
            this.L_ListSearchLabel.Size = new System.Drawing.Size(77, 28);
            this.L_ListSearchLabel.TabIndex = 28;
            this.L_ListSearchLabel.Text = "Поиск:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(885, 639);
            this.Controls.Add(this.L_ListSearchLabel);
            this.Controls.Add(this.L_ListSearch);
            this.Controls.Add(this.R_WordGen);
            this.Controls.Add(this.R_WordSoul);
            this.Controls.Add(this.R_WordType);
            this.Controls.Add(this.L_ButtonDeleteString);
            this.Controls.Add(this.R_ButtonClear);
            this.Controls.Add(this.L_List);
            this.Controls.Add(this.L_ButtonDeserialize);
            this.Controls.Add(this.L_ButtonSerialize);
            this.Controls.Add(this.R_ButtonAdd);
            this.Controls.Add(this.R_WordExample);
            this.Controls.Add(this.R_WordExampleLabel);
            this.Controls.Add(this.R_WordHyponymText);
            this.Controls.Add(this.R_WordHyperonymLabel);
            this.Controls.Add(this.R_WordAntonymLabel);
            this.Controls.Add(this.R_WordSynonymLabel);
            this.Controls.Add(this.R_WordHyponym);
            this.Controls.Add(this.R_WordHyperonym);
            this.Controls.Add(this.R_WordAntonym);
            this.Controls.Add(this.R_WordSynonym);
            this.Controls.Add(this.R_WordMeaning);
            this.Controls.Add(this.R_WordPhonetics);
            this.Controls.Add(this.R_WordName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Словарь-тезаурус";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox R_WordName;
        private System.Windows.Forms.TextBox R_WordPhonetics;
        private System.Windows.Forms.RichTextBox R_WordMeaning;
        private System.Windows.Forms.TextBox R_WordSynonym;
        private System.Windows.Forms.TextBox R_WordAntonym;
        private System.Windows.Forms.TextBox R_WordHyperonym;
        private System.Windows.Forms.TextBox R_WordHyponym;
        private System.Windows.Forms.Label R_WordSynonymLabel;
        private System.Windows.Forms.Label R_WordAntonymLabel;
        private System.Windows.Forms.Label R_WordHyperonymLabel;
        private System.Windows.Forms.Label R_WordHyponymText;
        private System.Windows.Forms.Label R_WordExampleLabel;
        private System.Windows.Forms.RichTextBox R_WordExample;
        private System.Windows.Forms.Button R_ButtonAdd;
        private System.Windows.Forms.Button L_ButtonSerialize;
        private System.Windows.Forms.Button L_ButtonDeserialize;
        private System.Windows.Forms.ListView L_List;
        private System.Windows.Forms.Button R_ButtonClear;
        private System.Windows.Forms.Button L_ButtonDeleteString;
        private System.Windows.Forms.ComboBox R_WordType;
        private System.Windows.Forms.ComboBox R_WordSoul;
        private System.Windows.Forms.ComboBox R_WordGen;
        private System.Windows.Forms.TextBox L_ListSearch;
        private System.Windows.Forms.ColumnHeader AllWords;
        private System.Windows.Forms.Label L_ListSearchLabel;
    }
}

