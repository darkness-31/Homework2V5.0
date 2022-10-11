namespace Homework2V5._0
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "Obama",
            "12:30",
            "3"}, -1);
            this.materialMaskedTextBox1 = new MaterialSkin.Controls.MaterialMaskedTextBox();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.ImageList = new System.Windows.Forms.ImageList(this.components);
            this.TabMenu = new MaterialSkin.Controls.MaterialTabControl();
            this.TabMainMenu = new System.Windows.Forms.TabPage();
            this.ListViewLesson = new MaterialSkin.Controls.MaterialListView();
            this.Lesson = new System.Windows.Forms.ColumnHeader();
            this.Time = new System.Windows.Forms.ColumnHeader();
            this.Count = new System.Windows.Forms.ColumnHeader();
            this.ButtonAddLesson = new MaterialSkin.Controls.MaterialButton();
            this.LableColon = new MaterialSkin.Controls.MaterialLabel();
            this.LableMinuts = new MaterialSkin.Controls.MaterialLabel();
            this.LableHour = new MaterialSkin.Controls.MaterialLabel();
            this.ComboBoxMinuts = new MaterialSkin.Controls.MaterialComboBox();
            this.ComboBoxHour = new MaterialSkin.Controls.MaterialComboBox();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.LableNameLesson = new MaterialSkin.Controls.MaterialLabel();
            this.NameLessonTextBox = new MaterialSkin.Controls.MaterialMaskedTextBox();
            this.TabTable = new System.Windows.Forms.TabPage();
            this.TabNewDocument = new System.Windows.Forms.TabPage();
            this.TabOpen = new System.Windows.Forms.TabPage();
            this.TabSave = new System.Windows.Forms.TabPage();
            this.TabSaveAs = new System.Windows.Forms.TabPage();
            this.TabSetting = new System.Windows.Forms.TabPage();
            this.TabQuit = new System.Windows.Forms.TabPage();
            this.TabMenu.SuspendLayout();
            this.TabMainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // materialMaskedTextBox1
            // 
            this.materialMaskedTextBox1.AllowPromptAsInput = true;
            this.materialMaskedTextBox1.AnimateReadOnly = false;
            this.materialMaskedTextBox1.AsciiOnly = false;
            this.materialMaskedTextBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.materialMaskedTextBox1.BeepOnError = false;
            this.materialMaskedTextBox1.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals;
            this.materialMaskedTextBox1.Depth = 0;
            this.materialMaskedTextBox1.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialMaskedTextBox1.HidePromptOnLeave = false;
            this.materialMaskedTextBox1.HideSelection = true;
            this.materialMaskedTextBox1.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Default;
            this.materialMaskedTextBox1.LeadingIcon = null;
            this.materialMaskedTextBox1.Location = new System.Drawing.Point(6, 107);
            this.materialMaskedTextBox1.Mask = "";
            this.materialMaskedTextBox1.MaxLength = 32767;
            this.materialMaskedTextBox1.MouseState = MaterialSkin.MouseState.OUT;
            this.materialMaskedTextBox1.Name = "materialMaskedTextBox1";
            this.materialMaskedTextBox1.PasswordChar = '\0';
            this.materialMaskedTextBox1.PrefixSuffixText = null;
            this.materialMaskedTextBox1.PromptChar = '_';
            this.materialMaskedTextBox1.ReadOnly = false;
            this.materialMaskedTextBox1.RejectInputOnFirstFailure = false;
            this.materialMaskedTextBox1.ResetOnPrompt = true;
            this.materialMaskedTextBox1.ResetOnSpace = true;
            this.materialMaskedTextBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.materialMaskedTextBox1.SelectedText = "";
            this.materialMaskedTextBox1.SelectionLength = 0;
            this.materialMaskedTextBox1.SelectionStart = 0;
            this.materialMaskedTextBox1.ShortcutsEnabled = true;
            this.materialMaskedTextBox1.Size = new System.Drawing.Size(250, 48);
            this.materialMaskedTextBox1.SkipLiterals = true;
            this.materialMaskedTextBox1.TabIndex = 0;
            this.materialMaskedTextBox1.TabStop = false;
            this.materialMaskedTextBox1.Text = "materialMaskedTextBox1";
            this.materialMaskedTextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.materialMaskedTextBox1.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals;
            this.materialMaskedTextBox1.TrailingIcon = null;
            this.materialMaskedTextBox1.UseSystemPasswordChar = false;
            this.materialMaskedTextBox1.ValidatingType = null;
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.Location = new System.Drawing.Point(6, 85);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(107, 19);
            this.materialLabel1.TabIndex = 1;
            this.materialLabel1.Text = "materialLabel1";
            // 
            // ImageList
            // 
            this.ImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.ImageList.Images.SetKeyName(0, "Open File.png");
            this.ImageList.Images.SetKeyName(1, "SaveAs.png");
            this.ImageList.Images.SetKeyName(2, "Home.png");
            this.ImageList.Images.SetKeyName(3, "Save.png");
            this.ImageList.Images.SetKeyName(4, "Create.png");
            this.ImageList.Images.SetKeyName(5, "DB.png");
            this.ImageList.Images.SetKeyName(6, "Settings.png");
            this.ImageList.Images.SetKeyName(7, "Close.png");
            // 
            // TabMenu
            // 
            this.TabMenu.Controls.Add(this.TabMainMenu);
            this.TabMenu.Controls.Add(this.TabTable);
            this.TabMenu.Controls.Add(this.TabNewDocument);
            this.TabMenu.Controls.Add(this.TabOpen);
            this.TabMenu.Controls.Add(this.TabSave);
            this.TabMenu.Controls.Add(this.TabSaveAs);
            this.TabMenu.Controls.Add(this.TabSetting);
            this.TabMenu.Controls.Add(this.TabQuit);
            this.TabMenu.Depth = 0;
            this.TabMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabMenu.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TabMenu.ImageList = this.ImageList;
            this.TabMenu.Location = new System.Drawing.Point(3, 64);
            this.TabMenu.MouseState = MaterialSkin.MouseState.HOVER;
            this.TabMenu.Multiline = true;
            this.TabMenu.Name = "TabMenu";
            this.TabMenu.SelectedIndex = 0;
            this.TabMenu.Size = new System.Drawing.Size(768, 422);
            this.TabMenu.TabIndex = 0;
            // 
            // TabMainMenu
            // 
            this.TabMainMenu.BackColor = System.Drawing.Color.White;
            this.TabMainMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.TabMainMenu.Controls.Add(this.ListViewLesson);
            this.TabMainMenu.Controls.Add(this.ButtonAddLesson);
            this.TabMainMenu.Controls.Add(this.LableColon);
            this.TabMainMenu.Controls.Add(this.LableMinuts);
            this.TabMainMenu.Controls.Add(this.LableHour);
            this.TabMainMenu.Controls.Add(this.ComboBoxMinuts);
            this.TabMainMenu.Controls.Add(this.ComboBoxHour);
            this.TabMainMenu.Controls.Add(this.materialLabel2);
            this.TabMainMenu.Controls.Add(this.LableNameLesson);
            this.TabMainMenu.Controls.Add(this.NameLessonTextBox);
            this.TabMainMenu.ImageKey = "Home.png";
            this.TabMainMenu.Location = new System.Drawing.Point(4, 74);
            this.TabMainMenu.Name = "TabMainMenu";
            this.TabMainMenu.Padding = new System.Windows.Forms.Padding(3);
            this.TabMainMenu.Size = new System.Drawing.Size(760, 344);
            this.TabMainMenu.TabIndex = 0;
            this.TabMainMenu.Text = "Главная";
            // 
            // ListViewLesson
            // 
            this.ListViewLesson.AutoSizeTable = false;
            this.ListViewLesson.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ListViewLesson.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ListViewLesson.CheckBoxes = true;
            this.ListViewLesson.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Lesson,
            this.Time,
            this.Count});
            this.ListViewLesson.Depth = 0;
            this.ListViewLesson.Dock = System.Windows.Forms.DockStyle.Right;
            this.ListViewLesson.FullRowSelect = true;
            listViewItem1.StateImageIndex = 0;
            this.ListViewLesson.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.ListViewLesson.Location = new System.Drawing.Point(454, 3);
            this.ListViewLesson.MinimumSize = new System.Drawing.Size(200, 100);
            this.ListViewLesson.MouseLocation = new System.Drawing.Point(-1, -1);
            this.ListViewLesson.MouseState = MaterialSkin.MouseState.OUT;
            this.ListViewLesson.Name = "ListViewLesson";
            this.ListViewLesson.OwnerDraw = true;
            this.ListViewLesson.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ListViewLesson.Size = new System.Drawing.Size(303, 338);
            this.ListViewLesson.TabIndex = 5;
            this.ListViewLesson.UseCompatibleStateImageBehavior = false;
            this.ListViewLesson.View = System.Windows.Forms.View.Details;
            // 
            // Lesson
            // 
            this.Lesson.Text = "Lesson";
            this.Lesson.Width = 100;
            // 
            // Time
            // 
            this.Time.Text = "Time";
            this.Time.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Time.Width = 100;
            // 
            // Count
            // 
            this.Count.Text = "Count";
            this.Count.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Count.Width = 100;
            // 
            // ButtonAddLesson
            // 
            this.ButtonAddLesson.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ButtonAddLesson.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.ButtonAddLesson.Depth = 0;
            this.ButtonAddLesson.HighEmphasis = true;
            this.ButtonAddLesson.Icon = null;
            this.ButtonAddLesson.Location = new System.Drawing.Point(25, 267);
            this.ButtonAddLesson.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.ButtonAddLesson.MouseState = MaterialSkin.MouseState.HOVER;
            this.ButtonAddLesson.Name = "ButtonAddLesson";
            this.ButtonAddLesson.NoAccentTextColor = System.Drawing.Color.Empty;
            this.ButtonAddLesson.Size = new System.Drawing.Size(155, 36);
            this.ButtonAddLesson.TabIndex = 4;
            this.ButtonAddLesson.Text = "Внести в список";
            this.ButtonAddLesson.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            this.ButtonAddLesson.UseAccentColor = false;
            this.ButtonAddLesson.UseVisualStyleBackColor = true;
            this.ButtonAddLesson.Click += new System.EventHandler(this.materialButton1_Click);
            // 
            // LableColon
            // 
            this.LableColon.AutoSize = true;
            this.LableColon.Depth = 0;
            this.LableColon.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.LableColon.Location = new System.Drawing.Point(152, 208);
            this.LableColon.MouseState = MaterialSkin.MouseState.HOVER;
            this.LableColon.Name = "LableColon";
            this.LableColon.Size = new System.Drawing.Size(5, 19);
            this.LableColon.TabIndex = 3;
            this.LableColon.Text = ":";
            // 
            // LableMinuts
            // 
            this.LableMinuts.AutoSize = true;
            this.LableMinuts.Depth = 0;
            this.LableMinuts.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.LableMinuts.Location = new System.Drawing.Point(195, 173);
            this.LableMinuts.MouseState = MaterialSkin.MouseState.HOVER;
            this.LableMinuts.Name = "LableMinuts";
            this.LableMinuts.Size = new System.Drawing.Size(61, 19);
            this.LableMinuts.TabIndex = 3;
            this.LableMinuts.Text = "Минуты";
            // 
            // LableHour
            // 
            this.LableHour.AutoSize = true;
            this.LableHour.Depth = 0;
            this.LableHour.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.LableHour.Location = new System.Drawing.Point(61, 173);
            this.LableHour.MouseState = MaterialSkin.MouseState.HOVER;
            this.LableHour.Name = "LableHour";
            this.LableHour.Size = new System.Drawing.Size(41, 19);
            this.LableHour.TabIndex = 3;
            this.LableHour.Text = "Часы";
            // 
            // ComboBoxMinuts
            // 
            this.ComboBoxMinuts.AutoResize = false;
            this.ComboBoxMinuts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ComboBoxMinuts.Depth = 0;
            this.ComboBoxMinuts.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.ComboBoxMinuts.DropDownHeight = 174;
            this.ComboBoxMinuts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxMinuts.DropDownWidth = 121;
            this.ComboBoxMinuts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ComboBoxMinuts.Font = new System.Drawing.Font("Roboto Medium", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.ComboBoxMinuts.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ComboBoxMinuts.FormattingEnabled = true;
            this.ComboBoxMinuts.IntegralHeight = false;
            this.ComboBoxMinuts.ItemHeight = 43;
            this.ComboBoxMinuts.Location = new System.Drawing.Point(163, 195);
            this.ComboBoxMinuts.MaxDropDownItems = 4;
            this.ComboBoxMinuts.MouseState = MaterialSkin.MouseState.OUT;
            this.ComboBoxMinuts.Name = "ComboBoxMinuts";
            this.ComboBoxMinuts.Size = new System.Drawing.Size(121, 49);
            this.ComboBoxMinuts.StartIndex = 0;
            this.ComboBoxMinuts.TabIndex = 2;
            // 
            // ComboBoxHour
            // 
            this.ComboBoxHour.AutoResize = false;
            this.ComboBoxHour.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ComboBoxHour.Depth = 0;
            this.ComboBoxHour.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.ComboBoxHour.DropDownHeight = 174;
            this.ComboBoxHour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxHour.DropDownWidth = 121;
            this.ComboBoxHour.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ComboBoxHour.Font = new System.Drawing.Font("Roboto Medium", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.ComboBoxHour.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ComboBoxHour.FormattingEnabled = true;
            this.ComboBoxHour.IntegralHeight = false;
            this.ComboBoxHour.ItemHeight = 43;
            this.ComboBoxHour.Location = new System.Drawing.Point(25, 195);
            this.ComboBoxHour.MaxDropDownItems = 4;
            this.ComboBoxHour.MouseState = MaterialSkin.MouseState.OUT;
            this.ComboBoxHour.Name = "ComboBoxHour";
            this.ComboBoxHour.Size = new System.Drawing.Size(121, 49);
            this.ComboBoxHour.StartIndex = 0;
            this.ComboBoxHour.TabIndex = 2;
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel2.Location = new System.Drawing.Point(25, 138);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(122, 19);
            this.materialLabel2.TabIndex = 1;
            this.materialLabel2.Text = "Названия урока";
            // 
            // LableNameLesson
            // 
            this.LableNameLesson.AutoSize = true;
            this.LableNameLesson.Depth = 0;
            this.LableNameLesson.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.LableNameLesson.Location = new System.Drawing.Point(25, 36);
            this.LableNameLesson.MouseState = MaterialSkin.MouseState.HOVER;
            this.LableNameLesson.Name = "LableNameLesson";
            this.LableNameLesson.Size = new System.Drawing.Size(122, 19);
            this.LableNameLesson.TabIndex = 1;
            this.LableNameLesson.Text = "Названия урока";
            // 
            // NameLessonTextBox
            // 
            this.NameLessonTextBox.AllowPromptAsInput = true;
            this.NameLessonTextBox.AnimateReadOnly = false;
            this.NameLessonTextBox.AsciiOnly = false;
            this.NameLessonTextBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.NameLessonTextBox.BeepOnError = false;
            this.NameLessonTextBox.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals;
            this.NameLessonTextBox.Depth = 0;
            this.NameLessonTextBox.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.NameLessonTextBox.HidePromptOnLeave = false;
            this.NameLessonTextBox.HideSelection = true;
            this.NameLessonTextBox.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Default;
            this.NameLessonTextBox.LeadingIcon = null;
            this.NameLessonTextBox.Location = new System.Drawing.Point(25, 70);
            this.NameLessonTextBox.Mask = "";
            this.NameLessonTextBox.MaxLength = 32767;
            this.NameLessonTextBox.MouseState = MaterialSkin.MouseState.OUT;
            this.NameLessonTextBox.Name = "NameLessonTextBox";
            this.NameLessonTextBox.PasswordChar = '\0';
            this.NameLessonTextBox.PrefixSuffixText = null;
            this.NameLessonTextBox.PromptChar = '_';
            this.NameLessonTextBox.ReadOnly = false;
            this.NameLessonTextBox.RejectInputOnFirstFailure = false;
            this.NameLessonTextBox.ResetOnPrompt = true;
            this.NameLessonTextBox.ResetOnSpace = true;
            this.NameLessonTextBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.NameLessonTextBox.SelectedText = "";
            this.NameLessonTextBox.SelectionLength = 0;
            this.NameLessonTextBox.SelectionStart = 0;
            this.NameLessonTextBox.ShortcutsEnabled = true;
            this.NameLessonTextBox.Size = new System.Drawing.Size(358, 48);
            this.NameLessonTextBox.SkipLiterals = true;
            this.NameLessonTextBox.TabIndex = 0;
            this.NameLessonTextBox.TabStop = false;
            this.NameLessonTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.NameLessonTextBox.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals;
            this.NameLessonTextBox.TrailingIcon = null;
            this.NameLessonTextBox.UseSystemPasswordChar = false;
            this.NameLessonTextBox.ValidatingType = null;
            // 
            // TabTable
            // 
            this.TabTable.BackColor = System.Drawing.Color.White;
            this.TabTable.ImageKey = "DB.png";
            this.TabTable.Location = new System.Drawing.Point(4, 74);
            this.TabTable.Name = "TabTable";
            this.TabTable.Padding = new System.Windows.Forms.Padding(3);
            this.TabTable.Size = new System.Drawing.Size(760, 344);
            this.TabTable.TabIndex = 1;
            this.TabTable.Text = "Таблица";
            // 
            // TabNewDocument
            // 
            this.TabNewDocument.BackColor = System.Drawing.Color.White;
            this.TabNewDocument.ImageKey = "Create.png";
            this.TabNewDocument.Location = new System.Drawing.Point(4, 74);
            this.TabNewDocument.Name = "TabNewDocument";
            this.TabNewDocument.Size = new System.Drawing.Size(760, 344);
            this.TabNewDocument.TabIndex = 2;
            this.TabNewDocument.Text = "Создать";
            // 
            // TabOpen
            // 
            this.TabOpen.BackColor = System.Drawing.Color.White;
            this.TabOpen.ImageKey = "Open File.png";
            this.TabOpen.Location = new System.Drawing.Point(4, 74);
            this.TabOpen.Name = "TabOpen";
            this.TabOpen.Size = new System.Drawing.Size(760, 344);
            this.TabOpen.TabIndex = 3;
            this.TabOpen.Text = "Открыть";
            // 
            // TabSave
            // 
            this.TabSave.BackColor = System.Drawing.Color.White;
            this.TabSave.ImageKey = "Save.png";
            this.TabSave.Location = new System.Drawing.Point(4, 74);
            this.TabSave.Name = "TabSave";
            this.TabSave.Size = new System.Drawing.Size(760, 344);
            this.TabSave.TabIndex = 4;
            this.TabSave.Text = "Сохранить";
            // 
            // TabSaveAs
            // 
            this.TabSaveAs.BackColor = System.Drawing.Color.White;
            this.TabSaveAs.ImageKey = "SaveAs.png";
            this.TabSaveAs.Location = new System.Drawing.Point(4, 74);
            this.TabSaveAs.Name = "TabSaveAs";
            this.TabSaveAs.Size = new System.Drawing.Size(760, 344);
            this.TabSaveAs.TabIndex = 5;
            this.TabSaveAs.Text = "Сохранить как...";
            // 
            // TabSetting
            // 
            this.TabSetting.BackColor = System.Drawing.Color.White;
            this.TabSetting.ImageKey = "Settings.png";
            this.TabSetting.Location = new System.Drawing.Point(4, 74);
            this.TabSetting.Name = "TabSetting";
            this.TabSetting.Size = new System.Drawing.Size(760, 344);
            this.TabSetting.TabIndex = 6;
            this.TabSetting.Text = "Настройки";
            // 
            // TabQuit
            // 
            this.TabQuit.BackColor = System.Drawing.Color.White;
            this.TabQuit.ImageKey = "Close.png";
            this.TabQuit.Location = new System.Drawing.Point(4, 74);
            this.TabQuit.Name = "TabQuit";
            this.TabQuit.Size = new System.Drawing.Size(760, 344);
            this.TabQuit.TabIndex = 7;
            this.TabQuit.Text = "Выйти";
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(774, 489);
            this.Controls.Add(this.TabMenu);
            this.DrawerShowIconsWhenHidden = true;
            this.DrawerTabControl = this.TabMenu;
            this.Name = "MainForm";
            this.Text = "Расписание";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.TabMenu.ResumeLayout(false);
            this.TabMainMenu.ResumeLayout(false);
            this.TabMainMenu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialMaskedTextBox materialMaskedTextBox1;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private ImageList ImageList;
        private MaterialSkin.Controls.MaterialTabControl TabMenu;
        private TabPage TabMainMenu;
        private TabPage TabTable;
        private TabPage TabNewDocument;
        private TabPage TabOpen;
        private TabPage TabSave;
        private TabPage TabSaveAs;
        private TabPage TabSetting;
        private TabPage TabQuit;
        private MaterialSkin.Controls.MaterialLabel LableNameLesson;
        private MaterialSkin.Controls.MaterialMaskedTextBox NameLessonTextBox;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialComboBox ComboBoxHour;
        private MaterialSkin.Controls.MaterialLabel LableHour;
        private MaterialSkin.Controls.MaterialLabel LableColon;
        private MaterialSkin.Controls.MaterialLabel LableMinuts;
        private MaterialSkin.Controls.MaterialComboBox ComboBoxMinuts;
        private MaterialSkin.Controls.MaterialListView ListViewLesson;
        private MaterialSkin.Controls.MaterialButton ButtonAddLesson;
        private ColumnHeader Lesson;
        private ColumnHeader Time;
        private ColumnHeader Count;
    }
}