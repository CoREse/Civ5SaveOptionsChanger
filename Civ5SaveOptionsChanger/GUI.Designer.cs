namespace Civ5SaveOptionsChanger
{
    partial class GUI
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
            this.button_open_file = new System.Windows.Forms.Button();
            this.openCiv5SaveFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.OptionList = new System.Windows.Forms.ListView();
            this.OptionName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Save = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.SaveAs = new System.Windows.Forms.Button();
            this.comboBoxLanguage = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // button_open_file
            // 
            this.button_open_file.Location = new System.Drawing.Point(383, 37);
            this.button_open_file.Name = "button_open_file";
            this.button_open_file.Size = new System.Drawing.Size(75, 23);
            this.button_open_file.TabIndex = 1;
            this.button_open_file.Text = "Open";
            this.button_open_file.UseVisualStyleBackColor = true;
            this.button_open_file.Click += new System.EventHandler(this.button_open_file_Click);
            // 
            // openCiv5SaveFileDialog
            // 
            this.openCiv5SaveFileDialog.FileName = "openCiv5SaveFileDialog";
            this.openCiv5SaveFileDialog.Filter = "Civilization V Save Files|*.Civ5Save|All Files|*.*";
            // 
            // OptionList
            // 
            this.OptionList.CheckBoxes = true;
            this.OptionList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.OptionName});
            this.OptionList.FullRowSelect = true;
            this.OptionList.GridLines = true;
            this.OptionList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.OptionList.HideSelection = false;
            this.OptionList.Location = new System.Drawing.Point(32, 37);
            this.OptionList.MultiSelect = false;
            this.OptionList.Name = "OptionList";
            this.OptionList.Size = new System.Drawing.Size(306, 322);
            this.OptionList.TabIndex = 2;
            this.OptionList.UseCompatibleStateImageBehavior = false;
            this.OptionList.View = System.Windows.Forms.View.Details;
            this.OptionList.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.onOptionItemCheckedChange);
            // 
            // OptionName
            // 
            this.OptionName.Text = "Option";
            this.OptionName.Width = 300;
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(383, 98);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(75, 23);
            this.Save.TabIndex = 3;
            this.Save.Text = "Save";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "Civilization V Save Files|*.Civ5Save|All Files|*.*";
            // 
            // SaveAs
            // 
            this.SaveAs.Location = new System.Drawing.Point(383, 159);
            this.SaveAs.Name = "SaveAs";
            this.SaveAs.Size = new System.Drawing.Size(75, 23);
            this.SaveAs.TabIndex = 4;
            this.SaveAs.Text = "Save as";
            this.SaveAs.UseVisualStyleBackColor = true;
            this.SaveAs.Click += new System.EventHandler(this.SaveAs_Click);
            // 
            // comboBoxLanguage
            // 
            this.comboBoxLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLanguage.FormattingEnabled = true;
            this.comboBoxLanguage.Items.AddRange(new object[] {
            "English",
            "简体中文"});
            this.comboBoxLanguage.Location = new System.Drawing.Point(383, 339);
            this.comboBoxLanguage.Name = "comboBoxLanguage";
            this.comboBoxLanguage.Size = new System.Drawing.Size(75, 20);
            this.comboBoxLanguage.TabIndex = 5;
            this.comboBoxLanguage.SelectedIndexChanged += new System.EventHandler(this.onLanguageChange);
            // 
            // GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 402);
            this.Controls.Add(this.comboBoxLanguage);
            this.Controls.Add(this.SaveAs);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.OptionList);
            this.Controls.Add(this.button_open_file);
            this.Name = "GUI";
            this.Text = "GUI";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button_open_file;
        private System.Windows.Forms.OpenFileDialog openCiv5SaveFileDialog;
        private System.Windows.Forms.ListView OptionList;
        private System.Windows.Forms.ColumnHeader OptionName;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Button SaveAs;
        private System.Windows.Forms.ComboBox comboBoxLanguage;
    }
}