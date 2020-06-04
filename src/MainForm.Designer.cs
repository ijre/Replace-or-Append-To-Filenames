namespace Replace_or_Append_To_Filenames
{
    partial class MainForm
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.ReplacementText = new System.Windows.Forms.TextBox();
            this.Options = new System.Windows.Forms.CheckedListBox();
            this.StringToWorkWith = new System.Windows.Forms.TextBox();
            this.StartButton = new System.Windows.Forms.Button();
            this.CaseSens = new System.Windows.Forms.CheckBox();
            this.ReplaceAllOccurrences = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // ReplacementText
            // 
            this.ReplacementText.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ReplacementText.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ReplacementText.Location = new System.Drawing.Point(124, 157);
            this.ReplacementText.Name = "ReplacementText";
            this.ReplacementText.Size = new System.Drawing.Size(150, 20);
            this.ReplacementText.TabIndex = 2;
            this.ReplacementText.Text = "REPLACEMENT";
            this.ReplacementText.Visible = false;
            this.ReplacementText.WordWrap = false;
            this.ReplacementText.Enter += new System.EventHandler(this.ReplacementText_Enter);
            // 
            // Options
            // 
            this.Options.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Options.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Options.CheckOnClick = true;
            this.Options.FormattingEnabled = true;
            this.Options.Items.AddRange(new object[] {
            "Find and Replace",
            "Append to Start",
            "Append to End",
            "Remove Everything After",
            "Remove Everything Before"});
            this.Options.Location = new System.Drawing.Point(124, 12);
            this.Options.Name = "Options";
            this.Options.Size = new System.Drawing.Size(150, 79);
            this.Options.TabIndex = 0;
            this.Options.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.Options_ItemCheck);
            // 
            // StringToWorkWith
            // 
            this.StringToWorkWith.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.StringToWorkWith.BackColor = System.Drawing.SystemColors.ControlDark;
            this.StringToWorkWith.Location = new System.Drawing.Point(124, 126);
            this.StringToWorkWith.Name = "StringToWorkWith";
            this.StringToWorkWith.Size = new System.Drawing.Size(150, 20);
            this.StringToWorkWith.TabIndex = 1;
            this.StringToWorkWith.Visible = false;
            this.StringToWorkWith.WordWrap = false;
            this.StringToWorkWith.Enter += new System.EventHandler(this.StringToReplace_Enter);
            // 
            // StartButton
            // 
            this.StartButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.StartButton.BackColor = System.Drawing.SystemColors.ControlDark;
            this.StartButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StartButton.Location = new System.Drawing.Point(125, 226);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(150, 66);
            this.StartButton.TabIndex = 3;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = false;
            this.StartButton.Visible = false;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // CaseSens
            // 
            this.CaseSens.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CaseSens.AutoSize = true;
            this.CaseSens.Location = new System.Drawing.Point(281, 226);
            this.CaseSens.Name = "CaseSens";
            this.CaseSens.Size = new System.Drawing.Size(102, 17);
            this.CaseSens.TabIndex = 4;
            this.CaseSens.Text = "Case Sensitive?";
            this.CaseSens.UseVisualStyleBackColor = true;
            this.CaseSens.Visible = false;
            // 
            // ReplaceAllOccurrences
            // 
            this.ReplaceAllOccurrences.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ReplaceAllOccurrences.Location = new System.Drawing.Point(281, 249);
            this.ReplaceAllOccurrences.Name = "ReplaceAllOccurrences";
            this.ReplaceAllOccurrences.Size = new System.Drawing.Size(105, 30);
            this.ReplaceAllOccurrences.TabIndex = 4;
            this.ReplaceAllOccurrences.Text = "Replace All Occurrences?";
            this.ReplaceAllOccurrences.UseVisualStyleBackColor = true;
            this.ReplaceAllOccurrences.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(398, 303);
            this.Controls.Add(this.ReplaceAllOccurrences);
            this.Controls.Add(this.CaseSens);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.Options);
            this.Controls.Add(this.ReplacementText);
            this.Controls.Add(this.StringToWorkWith);
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Replace/Append To Filenames";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ReplacementText;
        private System.Windows.Forms.CheckedListBox Options;
        private System.Windows.Forms.TextBox StringToWorkWith;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.CheckBox CaseSens;
        private System.Windows.Forms.CheckBox ReplaceAllOccurrences;
    }
}

