using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

using Microsoft.WindowsAPICodePack;
using Microsoft.WindowsAPICodePack.Dialogs;
using Microsoft.WindowsAPICodePack.Shell;

namespace Replace_or_Append_To_Filenames
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private readonly string[] defaults = { "STRING TO REPLACE", "STRING TO ADD", "STRING TO ADD", "STRING TO FIND", "STRING TO FIND" };

        #region TextBoxClearing
        private void StringToReplace_Enter(object sender, EventArgs e)
        {
            for (int i = 0; i < defaults.Length; i++)
                if (StringToWorkWith.Text == defaults[i])
                {
                    StringToWorkWith.Clear();
                    return;
                }
        }

        private void ReplacementText_Enter(object sender, EventArgs e)
        {
            if (ReplacementText.Text == "REPLACEMENT")
                ReplacementText.Clear();
        }
        #endregion

        private enum Choices
        {
            FindAndReplace,
            AppendStart,
            AppendEnd,
            RemoveAfter,
            RemoveBefore
        }

        private void Options_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Unchecked)
            {
                if (Options.CheckedIndices.Count != 1)
                    return;

                for (int i = 0; i < Controls.Count; i++)
                    if (Controls[i].Name != "Options" && Controls[i].Visible)
                        Controls[i].Visible = false;

                return;
            }


            if (Options.CheckedIndices.Count > 0)
            {
                // ReSharper disable once ConvertIfStatementToConditionalTernaryExpression
                if (e.Index == Options.CheckedIndices[0])
                    Options.SetItemChecked(Options.CheckedIndices[1], false);
                else
                    Options.SetItemChecked(Options.CheckedIndices[0], false);
            }

            HandleIndexChange((Choices)e.Index);
        }

        private void HandleIndexChange(Choices index)
        {
            for (int i = 0; i < Controls.Count; i++)
                if (Controls[i].Name != "Options" && Controls[i].Visible)
                    Controls[i].Visible = false;

            StringToWorkWith.Text = defaults[(int)index];

            switch (index)
            {
                case Choices.FindAndReplace:
                {
                    ReplacementText.Text = "REPLACEMENT";
                    ReplacementText.Visible = true;
                    CaseSens.Visible = true;
                    ReplaceAllOccurrences.Visible = true;
                    break;
                }
                default:
                {
                    ReplacementText.Visible = false;
                    CaseSens.Visible = false;
                    ReplaceAllOccurrences.Visible = false;
                    break;
                }
            }

            StringToWorkWith.Visible = true;
            StartButton.Visible = true;
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            var UseDirectory = MessageBox.Show("Would you like to select directories? Answering no means you're selecting files.", "Directory or files?",
                      MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if (UseDirectory == DialogResult.Cancel)
                return;

            char[] notValid = { '\\', '/', ':', '*', '?', '\"', '<', '>', '|' };

            if ((Choices)Options.CheckedIndices[0] == Choices.FindAndReplace)
            {
                int index = ReplacementText.Text.IndexOfAny(notValid);

                while (index != -1)
                {
                    ReplacementText.Text = ReplacementText.Text.Insert(index, "_");
                    ReplacementText.Text = ReplacementText.Text.Remove(index + 1, 1);

                    index = ReplacementText.Text.IndexOfAny(notValid);
                }
            }
            else
            {
                int index = StringToWorkWith.Text.IndexOfAny(notValid);

                while (index != -1)
                {
                    StringToWorkWith.Text = StringToWorkWith.Text.Insert(index, "_");
                    StringToWorkWith.Text = StringToWorkWith.Text.Remove(index + 1, 1);

                    index = StringToWorkWith.Text.IndexOfAny(notValid);
                }
            }

            string[] files = { };
            string[] paths = { };

            if (UseDirectory == DialogResult.Yes)
            {
                using CommonOpenFileDialog diag = new CommonOpenFileDialog()
                {
                    Title = "Select Folder",
                    IsFolderPicker = true,
                    RestoreDirectory = true,
                    InitialDirectory = Environment.SpecialFolder.MyDocuments.ToString()
                };
                diag.ShowDialog();
                if (string.IsNullOrWhiteSpace(diag.FileName))
                    return;

                files = Directory.GetFiles(diag.FileName);
                paths = Directory.GetFiles(diag.FileName);

                for (int i = 0; i < files.Length; i++)
                    files[i] = files[i].Substring(files[i].LastIndexOf("\\") + 1);
            }
            else if (UseDirectory == DialogResult.No)
            {
                using OpenFileDialog diag = new OpenFileDialog()
                {
                    Title = "Select Files",
                    Multiselect = true,
                    RestoreDirectory = true,
                    SupportMultiDottedExtensions = true,
                    InitialDirectory = Environment.SpecialFolder.MyDocuments.ToString()
                };
                diag.ShowDialog();
                if (string.IsNullOrWhiteSpace(diag.FileName))
                    return;

                files = diag.SafeFileNames;
                paths = diag.FileNames;
            }

            for (int i = 0; i < files.Length; i++)
            {
                switch ((Choices)Options.CheckedIndices[0])
                {
                    case Choices.FindAndReplace:
                    {
                        if (!(CaseSens.Checked ? files[i].Contains(StringToWorkWith.Text) : files[i].ToLower().Contains(StringToWorkWith.Text.ToLower())))
                            continue;


                        if (ReplaceAllOccurrences.Checked)
                        {
                            if (CaseSens.Checked)
                                files[i] = files[i].Replace(StringToWorkWith.Text, ReplacementText.Text);
                            else
                            {
                                Regex reggie = new Regex(StringToWorkWith.Text, RegexOptions.Compiled | RegexOptions.IgnoreCase);
                                var matches = reggie.Matches(files[i]);

                                foreach (Match match in matches)
                                {
                                    var find = match.Index;

                                    files[i] = files[i].Remove(find, StringToWorkWith.Text.Length);
                                    files[i] = files[i].Insert(find, ReplacementText.Text);
                                }
                            }
                        }
                        else
                        {
                            int index = files[i].ToLower().IndexOf(StringToWorkWith.Text.ToLower());

                            files[i] = files[i].Remove(index, StringToWorkWith.Text.Length);

                            files[i] = files[i].Insert(index, ReplacementText.Text);
                        }
                        // insert the new text at the index of the old, then remove the old text
                        // im doing ToLower() regardless of CaseSens's setting as to not have to worry about checking it again (all we're doing is getting the index)

                        break;
                    }
                    case Choices.AppendStart:
                    {
                        files[i] = files[i].Insert(0, $"{StringToWorkWith.Text} ");
                        break;
                    }
                    case Choices.AppendEnd:
                    {
                        string ext = files[i].Substring(files[i].LastIndexOf("."));

                        files[i] = files[i].Substring(0, files[i].LastIndexOf(ext)) + $" {StringToWorkWith.Text}" + ext;
                        break;
                    }
                    case Choices.RemoveAfter:
                    {
                        string ext = files[i].Substring(files[i].LastIndexOf("."));

                        int lengthPlusIndex = files[i].IndexOf(StringToWorkWith.Text) + StringToWorkWith.Text.Length;

                        files[i] = files[i].Remove(lengthPlusIndex, files[i].Length - lengthPlusIndex) + ext;
                        break;
                    }
                    case Choices.RemoveBefore:
                    {
                        files[i] = files[i].Remove(0, files[i].IndexOf(StringToWorkWith.Text));
                        break;
                    }
                }

                try
                {
                    File.Move(paths[i], paths[i].Substring(0, paths[i].LastIndexOf("\\") + 1) + files[i]);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            StringToWorkWith.Text = defaults[Options.CheckedIndices[0]];
            ReplacementText.Text = "REPLACEMENT";
        }
    }
}
