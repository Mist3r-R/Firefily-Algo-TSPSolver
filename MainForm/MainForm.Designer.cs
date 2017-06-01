namespace MainForm
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Open_File = new System.Windows.Forms.ToolStripMenuItem();
            this.Open_Optimal = new System.Windows.Forms.ToolStripMenuItem();
            this.SavePath = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveTSPdata = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Info_btn = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.открытьToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.OpenPathToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.сохранитьToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.SaveTSPtoolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.FindToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.EditTSPDataToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ClearToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.справкаToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.find_btn = new System.Windows.Forms.Button();
            this.del_btn = new System.Windows.Forms.Button();
            this.richTextBox = new System.Windows.Forms.RichTextBox();
            this.length_label = new System.Windows.Forms.Label();
            this.path_label = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.saveFileDialog2 = new System.Windows.Forms.SaveFileDialog();
            this.EnlargePath = new System.Windows.Forms.Button();
            this.time_label = new System.Windows.Forms.Label();
            this.MyPictureBox = new global::MainForm.MyPictureBox();
            this.settings_gb = new System.Windows.Forms.GroupBox();
            this.checkBox = new System.Windows.Forms.CheckBox();
            this.info_gb = new System.Windows.Forms.GroupBox();
            this.accTxt = new System.Windows.Forms.TextBox();
            this.optTxt = new System.Windows.Forms.TextBox();
            this.minTxt = new System.Windows.Forms.TextBox();
            this.avTxt = new System.Windows.Forms.TextBox();
            this.nTxt = new System.Windows.Forms.TextBox();
            this.acc_label = new System.Windows.Forms.Label();
            this.opt_label = new System.Windows.Forms.Label();
            this.min_label = new System.Windows.Forms.Label();
            this.av_label = new System.Windows.Forms.Label();
            this.n_label = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.EditTSPdata = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.settings_gb.SuspendLayout();
            this.info_gb.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.оПрограммеToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(884, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Open_File,
            this.Open_Optimal,
            this.SavePath,
            this.SaveTSPdata});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // Open_File
            // 
            this.Open_File.Name = "Open_File";
            this.Open_File.Size = new System.Drawing.Size(186, 22);
            this.Open_File.Text = "Открыть";
            this.Open_File.Click += new System.EventHandler(this.Open_File_Click);
            // 
            // Open_Optimal
            // 
            this.Open_Optimal.Name = "Open_Optimal";
            this.Open_Optimal.Size = new System.Drawing.Size(186, 22);
            this.Open_Optimal.Text = "Открыть маршрут";
            this.Open_Optimal.Click += new System.EventHandler(this.Open_Optimal_Click);
            // 
            // SavePath
            // 
            this.SavePath.Name = "SavePath";
            this.SavePath.Size = new System.Drawing.Size(186, 22);
            this.SavePath.Text = "Сохранить маршрут";
            this.SavePath.Click += new System.EventHandler(this.сохранитьКакToolStripMenuItem_Click);
            // 
            // SaveTSPdata
            // 
            this.SaveTSPdata.Name = "SaveTSPdata";
            this.SaveTSPdata.Size = new System.Drawing.Size(186, 22);
            this.SaveTSPdata.Text = "Сохранить TSP";
            this.SaveTSPdata.Click += new System.EventHandler(this.SaveTSPdata_Click);
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Info_btn});
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.оПрограммеToolStripMenuItem.Text = "Справка";
            // 
            // Info_btn
            // 
            this.Info_btn.Name = "Info_btn";
            this.Info_btn.Size = new System.Drawing.Size(152, 22);
            this.Info_btn.Text = "О программе";
            this.Info_btn.Click += new System.EventHandler(this.Info_btn_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            this.openFileDialog.Filter = "TSP Files|*.tsp";
            // 
            // toolStrip
            // 
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьToolStripButton,
            this.OpenPathToolStripButton,
            this.сохранитьToolStripButton,
            this.SaveTSPtoolStripButton,
            this.toolStripSeparator,
            this.FindToolStripButton,
            this.EditTSPDataToolStripButton,
            this.toolStripSeparator2,
            this.ClearToolStripButton,
            this.toolStripSeparator1,
            this.справкаToolStripButton});
            this.toolStrip.Location = new System.Drawing.Point(0, 24);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(884, 31);
            this.toolStrip.TabIndex = 1;
            this.toolStrip.Text = "toolStrip1";
            // 
            // открытьToolStripButton
            // 
            this.открытьToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.открытьToolStripButton.Image = global::MainForm.Properties.Resources.Add_File;
            this.открытьToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.открытьToolStripButton.Name = "открытьToolStripButton";
            this.открытьToolStripButton.Size = new System.Drawing.Size(28, 28);
            this.открытьToolStripButton.Text = "Открыть";
            this.открытьToolStripButton.Click += new System.EventHandler(this.Open_File_Click);
            // 
            // OpenPathToolStripButton
            // 
            this.OpenPathToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.OpenPathToolStripButton.Image = global::MainForm.Properties.Resources.Add_List;
            this.OpenPathToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.OpenPathToolStripButton.Name = "OpenPathToolStripButton";
            this.OpenPathToolStripButton.Size = new System.Drawing.Size(28, 28);
            this.OpenPathToolStripButton.Text = "Открыть маршрут";
            this.OpenPathToolStripButton.Click += new System.EventHandler(this.Open_Optimal_Click);
            // 
            // сохранитьToolStripButton
            // 
            this.сохранитьToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.сохранитьToolStripButton.Image = global::MainForm.Properties.Resources.Save_as;
            this.сохранитьToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.сохранитьToolStripButton.Name = "сохранитьToolStripButton";
            this.сохранитьToolStripButton.Size = new System.Drawing.Size(28, 28);
            this.сохранитьToolStripButton.Text = "Сохранить маршрут";
            this.сохранитьToolStripButton.Click += new System.EventHandler(this.сохранитьКакToolStripMenuItem_Click);
            // 
            // SaveTSPtoolStripButton
            // 
            this.SaveTSPtoolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SaveTSPtoolStripButton.Image = global::MainForm.Properties.Resources.Create_New;
            this.SaveTSPtoolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SaveTSPtoolStripButton.Name = "SaveTSPtoolStripButton";
            this.SaveTSPtoolStripButton.Size = new System.Drawing.Size(28, 28);
            this.SaveTSPtoolStripButton.Text = "Сохранить TSP";
            this.SaveTSPtoolStripButton.Click += new System.EventHandler(this.SaveTSPdata_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 31);
            // 
            // FindToolStripButton
            // 
            this.FindToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.FindToolStripButton.Image = global::MainForm.Properties.Resources.Search;
            this.FindToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.FindToolStripButton.Name = "FindToolStripButton";
            this.FindToolStripButton.Size = new System.Drawing.Size(28, 28);
            this.FindToolStripButton.Text = "Найти путь";
            this.FindToolStripButton.Click += new System.EventHandler(this.find_btn_Click);
            // 
            // EditTSPDataToolStripButton
            // 
            this.EditTSPDataToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.EditTSPDataToolStripButton.Image = global::MainForm.Properties.Resources.View_Details;
            this.EditTSPDataToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.EditTSPDataToolStripButton.Name = "EditTSPDataToolStripButton";
            this.EditTSPDataToolStripButton.Size = new System.Drawing.Size(28, 28);
            this.EditTSPDataToolStripButton.Text = "Информация о сеансе";
            this.EditTSPDataToolStripButton.ToolTipText = "Информация о TSP";
            this.EditTSPDataToolStripButton.Click += new System.EventHandler(this.EditTSPdata_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 31);
            // 
            // ClearToolStripButton
            // 
            this.ClearToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ClearToolStripButton.Image = global::MainForm.Properties.Resources.Delete;
            this.ClearToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ClearToolStripButton.Name = "ClearToolStripButton";
            this.ClearToolStripButton.Size = new System.Drawing.Size(28, 28);
            this.ClearToolStripButton.Text = "Очистить данные";
            this.ClearToolStripButton.Click += new System.EventHandler(this.del_btn_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // справкаToolStripButton
            // 
            this.справкаToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.справкаToolStripButton.Image = global::MainForm.Properties.Resources.Info2;
            this.справкаToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.справкаToolStripButton.Name = "справкаToolStripButton";
            this.справкаToolStripButton.Size = new System.Drawing.Size(28, 28);
            this.справкаToolStripButton.Text = "О программе";
            this.справкаToolStripButton.Click += new System.EventHandler(this.Info_btn_Click);
            // 
            // find_btn
            // 
            this.find_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.find_btn.Location = new System.Drawing.Point(662, 184);
            this.find_btn.Name = "find_btn";
            this.find_btn.Size = new System.Drawing.Size(124, 23);
            this.find_btn.TabIndex = 4;
            this.find_btn.Text = "Найти путь";
            this.find_btn.UseVisualStyleBackColor = true;
            this.find_btn.Click += new System.EventHandler(this.find_btn_Click);
            // 
            // del_btn
            // 
            this.del_btn.Location = new System.Drawing.Point(6, 57);
            this.del_btn.Name = "del_btn";
            this.del_btn.Size = new System.Drawing.Size(124, 23);
            this.del_btn.TabIndex = 5;
            this.del_btn.Text = "Очистить данные";
            this.del_btn.UseVisualStyleBackColor = true;
            this.del_btn.Click += new System.EventHandler(this.del_btn_Click);
            // 
            // richTextBox
            // 
            this.richTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox.Location = new System.Drawing.Point(662, 154);
            this.richTextBox.Name = "richTextBox";
            this.richTextBox.ReadOnly = true;
            this.richTextBox.Size = new System.Drawing.Size(180, 24);
            this.richTextBox.TabIndex = 6;
            this.richTextBox.Text = "";
            // 
            // length_label
            // 
            this.length_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.length_label.AutoSize = true;
            this.length_label.Location = new System.Drawing.Point(659, 79);
            this.length_label.Name = "length_label";
            this.length_label.Size = new System.Drawing.Size(68, 13);
            this.length_label.TabIndex = 7;
            this.length_label.Text = "Длина пути:";
            // 
            // path_label
            // 
            this.path_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.path_label.AutoSize = true;
            this.path_label.Location = new System.Drawing.Point(659, 138);
            this.path_label.Name = "path_label";
            this.path_label.Size = new System.Drawing.Size(115, 13);
            this.path_label.TabIndex = 9;
            this.path_label.Text = "Найденный маршрут:";
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(659, 525);
            this.progressBar.Maximum = 511;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(213, 23);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 13;
            this.progressBar.Visible = false;
            // 
            // saveFileDialog2
            // 
            this.saveFileDialog2.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog2_FileOk);
            // 
            // EnlargePath
            // 
            this.EnlargePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.EnlargePath.Image = ((System.Drawing.Image)(resources.GetObject("EnlargePath.Image")));
            this.EnlargePath.Location = new System.Drawing.Point(844, 149);
            this.EnlargePath.Name = "EnlargePath";
            this.EnlargePath.Size = new System.Drawing.Size(28, 28);
            this.EnlargePath.TabIndex = 10;
            this.EnlargePath.UseVisualStyleBackColor = true;
            this.EnlargePath.Click += new System.EventHandler(this.EnlargePath_Click);
            // 
            // time_label
            // 
            this.time_label.AutoSize = true;
            this.time_label.Location = new System.Drawing.Point(659, 110);
            this.time_label.Name = "time_label";
            this.time_label.Size = new System.Drawing.Size(46, 13);
            this.time_label.TabIndex = 14;
            this.time_label.Text = "Время: ";
            // 
            // MyPictureBox
            // 
            this.MyPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.MyPictureBox.Location = new System.Drawing.Point(13, 59);
            this.MyPictureBox.Name = "MyPictureBox";
            this.MyPictureBox.Size = new System.Drawing.Size(640, 490);
            this.MyPictureBox.TabIndex = 16;
            this.MyPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MyPictureBox_MouseDown);
            // 
            // settings_gb
            // 
            this.settings_gb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.settings_gb.Controls.Add(this.EditTSPdata);
            this.settings_gb.Controls.Add(this.checkBox);
            this.settings_gb.Controls.Add(this.del_btn);
            this.settings_gb.Location = new System.Drawing.Point(659, 401);
            this.settings_gb.Name = "settings_gb";
            this.settings_gb.Size = new System.Drawing.Size(213, 118);
            this.settings_gb.TabIndex = 20;
            this.settings_gb.TabStop = false;
            this.settings_gb.Text = "Настройки";
            // 
            // checkBox
            // 
            this.checkBox.AutoSize = true;
            this.checkBox.Location = new System.Drawing.Point(7, 87);
            this.checkBox.Name = "checkBox";
            this.checkBox.Size = new System.Drawing.Size(181, 17);
            this.checkBox.TabIndex = 20;
            this.checkBox.Text = "Отображать доп. информацию";
            this.checkBox.UseVisualStyleBackColor = true;
            this.checkBox.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // info_gb
            // 
            this.info_gb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.info_gb.Controls.Add(this.accTxt);
            this.info_gb.Controls.Add(this.optTxt);
            this.info_gb.Controls.Add(this.minTxt);
            this.info_gb.Controls.Add(this.avTxt);
            this.info_gb.Controls.Add(this.nTxt);
            this.info_gb.Controls.Add(this.acc_label);
            this.info_gb.Controls.Add(this.opt_label);
            this.info_gb.Controls.Add(this.min_label);
            this.info_gb.Controls.Add(this.av_label);
            this.info_gb.Controls.Add(this.n_label);
            this.info_gb.Location = new System.Drawing.Point(659, 213);
            this.info_gb.Name = "info_gb";
            this.info_gb.Size = new System.Drawing.Size(213, 156);
            this.info_gb.TabIndex = 21;
            this.info_gb.TabStop = false;
            this.info_gb.Text = "Дополнительная информация";
            // 
            // accTxt
            // 
            this.accTxt.Location = new System.Drawing.Point(116, 123);
            this.accTxt.Name = "accTxt";
            this.accTxt.ReadOnly = true;
            this.accTxt.Size = new System.Drawing.Size(91, 20);
            this.accTxt.TabIndex = 29;
            // 
            // optTxt
            // 
            this.optTxt.Location = new System.Drawing.Point(116, 97);
            this.optTxt.Name = "optTxt";
            this.optTxt.ReadOnly = true;
            this.optTxt.Size = new System.Drawing.Size(91, 20);
            this.optTxt.TabIndex = 28;
            // 
            // minTxt
            // 
            this.minTxt.Location = new System.Drawing.Point(116, 71);
            this.minTxt.Name = "minTxt";
            this.minTxt.ReadOnly = true;
            this.minTxt.Size = new System.Drawing.Size(91, 20);
            this.minTxt.TabIndex = 27;
            // 
            // avTxt
            // 
            this.avTxt.Location = new System.Drawing.Point(116, 45);
            this.avTxt.Name = "avTxt";
            this.avTxt.ReadOnly = true;
            this.avTxt.Size = new System.Drawing.Size(91, 20);
            this.avTxt.TabIndex = 26;
            // 
            // nTxt
            // 
            this.nTxt.BackColor = System.Drawing.SystemColors.Control;
            this.nTxt.Location = new System.Drawing.Point(116, 19);
            this.nTxt.Name = "nTxt";
            this.nTxt.ReadOnly = true;
            this.nTxt.Size = new System.Drawing.Size(91, 20);
            this.nTxt.TabIndex = 25;
            // 
            // acc_label
            // 
            this.acc_label.AutoSize = true;
            this.acc_label.Location = new System.Drawing.Point(6, 126);
            this.acc_label.Name = "acc_label";
            this.acc_label.Size = new System.Drawing.Size(57, 13);
            this.acc_label.TabIndex = 24;
            this.acc_label.Text = "Точность:";
            this.toolTip.SetToolTip(this.acc_label, "Отображается при открытом файле с оптимальным путем");
            // 
            // opt_label
            // 
            this.opt_label.AutoSize = true;
            this.opt_label.Location = new System.Drawing.Point(6, 100);
            this.opt_label.Name = "opt_label";
            this.opt_label.Size = new System.Drawing.Size(81, 13);
            this.opt_label.TabIndex = 23;
            this.opt_label.Text = "Оптимальный:";
            this.toolTip.SetToolTip(this.opt_label, "Отображается при открытом файле с оптимальным путем");
            // 
            // min_label
            // 
            this.min_label.AutoSize = true;
            this.min_label.Location = new System.Drawing.Point(6, 74);
            this.min_label.Name = "min_label";
            this.min_label.Size = new System.Drawing.Size(93, 13);
            this.min_label.TabIndex = 22;
            this.min_label.Text = "Мин. найденный:";
            // 
            // av_label
            // 
            this.av_label.AutoSize = true;
            this.av_label.Location = new System.Drawing.Point(6, 48);
            this.av_label.Name = "av_label";
            this.av_label.Size = new System.Drawing.Size(86, 13);
            this.av_label.TabIndex = 21;
            this.av_label.Text = "Средняя длина:";
            // 
            // n_label
            // 
            this.n_label.AutoSize = true;
            this.n_label.Location = new System.Drawing.Point(6, 22);
            this.n_label.Name = "n_label";
            this.n_label.Size = new System.Drawing.Size(59, 13);
            this.n_label.TabIndex = 20;
            this.n_label.Text = "Прогонов:";
            // 
            // EditTSPdata
            // 
            this.EditTSPdata.Location = new System.Drawing.Point(7, 28);
            this.EditTSPdata.Name = "EditTSPdata";
            this.EditTSPdata.Size = new System.Drawing.Size(123, 23);
            this.EditTSPdata.TabIndex = 21;
            this.EditTSPdata.Text = "Данные TSP файла";
            this.EditTSPdata.UseVisualStyleBackColor = true;
            this.EditTSPdata.Click += new System.EventHandler(this.EditTSPdata_Click);
            // 
            // Main_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.info_gb);
            this.Controls.Add(this.settings_gb);
            this.Controls.Add(this.MyPictureBox);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.time_label);
            this.Controls.Add(this.richTextBox);
            this.Controls.Add(this.length_label);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.find_btn);
            this.Controls.Add(this.EnlargePath);
            this.Controls.Add(this.path_label);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(900, 600);
            this.MinimumSize = new System.Drawing.Size(900, 600);
            this.Name = "Main_Form";
            this.Text = "TSP Solver";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.settings_gb.ResumeLayout(false);
            this.settings_gb.PerformLayout();
            this.info_gb.ResumeLayout(false);
            this.info_gb.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton открытьToolStripButton;
        private System.Windows.Forms.ToolStripButton сохранитьToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripButton FindToolStripButton;
        private System.Windows.Forms.ToolStripButton ClearToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton справкаToolStripButton;
        private System.Windows.Forms.Button find_btn;
        private System.Windows.Forms.Button del_btn;
        private System.Windows.Forms.RichTextBox richTextBox;
        private System.Windows.Forms.Label length_label;
        private System.Windows.Forms.ToolStripMenuItem Open_File;
        private System.Windows.Forms.Label path_label;
        private System.Windows.Forms.ToolStripMenuItem SavePath;
        private System.Windows.Forms.ToolStripMenuItem Info_btn;
        private System.Windows.Forms.Button EnlargePath;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.ToolStripMenuItem Open_Optimal;
        private System.Windows.Forms.ToolStripMenuItem SaveTSPdata;
        private System.Windows.Forms.ToolStripButton OpenPathToolStripButton;
        private System.Windows.Forms.ToolStripButton SaveTSPtoolStripButton;
        private System.Windows.Forms.ToolStripButton EditTSPDataToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.SaveFileDialog saveFileDialog2;
        private System.Windows.Forms.Label time_label;
        private global::MainForm.MyPictureBox MyPictureBox;
        private System.Windows.Forms.GroupBox settings_gb;
        private System.Windows.Forms.GroupBox info_gb;
        private System.Windows.Forms.CheckBox checkBox;
        private System.Windows.Forms.Label acc_label;
        private System.Windows.Forms.Label opt_label;
        private System.Windows.Forms.Label min_label;
        private System.Windows.Forms.Label av_label;
        private System.Windows.Forms.Label n_label;
        private System.Windows.Forms.TextBox accTxt;
        private System.Windows.Forms.TextBox optTxt;
        private System.Windows.Forms.TextBox minTxt;
        private System.Windows.Forms.TextBox avTxt;
        private System.Windows.Forms.TextBox nTxt;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Button EditTSPdata;
    }
}

