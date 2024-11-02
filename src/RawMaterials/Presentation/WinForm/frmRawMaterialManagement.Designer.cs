namespace MW.SAXSAY.RawMaterials.Presentation.WinForm
{
    partial class frmRawMaterialManagement
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRawMaterialManagement));
            btnAdd = new Button();
            btnRemove = new Button();
            btnDisable = new Button();
            tabRawMaterials = new TabControl();
            tpRawMaterials = new TabPage();
            btnEnable = new Button();
            dgvRawMaterials = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colName = new DataGridViewTextBoxColumn();
            colUNSPSC = new DataGridViewTextBoxColumn();
            colUNSPSCDescription = new DataGridViewTextBoxColumn();
            colCreatedAt = new DataGridViewTextBoxColumn();
            colUpdatedAt = new DataGridViewTextBoxColumn();
            colIsEnabled = new DataGridViewCheckBoxColumn();
            mnsMain = new MenuStrip();
            tsmiFile = new ToolStripMenuItem();
            tsmiSave = new ToolStripMenuItem();
            msSeparator = new ToolStripSeparator();
            tsmiClose = new ToolStripMenuItem();
            ssrStatus = new StatusStrip();
            tslblInfo = new ToolStripStatusLabel();
            tslblSpace = new ToolStripStatusLabel();
            tslblContext = new ToolStripStatusLabel();
            tsprgLoading = new ToolStripProgressBar();
            txtTextToSearch = new TextBox();
            grpFilter = new GroupBox();
            label1 = new Label();
            btnSearch = new Button();
            tabRawMaterials.SuspendLayout();
            tpRawMaterials.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRawMaterials).BeginInit();
            mnsMain.SuspendLayout();
            ssrStatus.SuspendLayout();
            grpFilter.SuspendLayout();
            SuspendLayout();
            // 
            // btnAdd
            // 
            btnAdd.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAdd.Font = new Font("Liberation Sans Narrow", 9F);
            btnAdd.Image = Properties.Resources.Add;
            btnAdd.ImageAlign = ContentAlignment.MiddleLeft;
            btnAdd.Location = new Point(673, 6);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(84, 26);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "Agregar";
            btnAdd.TextAlign = ContentAlignment.MiddleRight;
            btnAdd.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnRemove
            // 
            btnRemove.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRemove.AutoSize = true;
            btnRemove.Image = Properties.Resources.Remove;
            btnRemove.ImageAlign = ContentAlignment.MiddleLeft;
            btnRemove.Location = new Point(673, 38);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(84, 26);
            btnRemove.TabIndex = 2;
            btnRemove.Text = "Quitar";
            btnRemove.TextAlign = ContentAlignment.MiddleRight;
            btnRemove.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnRemove.UseVisualStyleBackColor = true;
            btnRemove.Click += btnRemove_Click;
            // 
            // btnDisable
            // 
            btnDisable.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnDisable.Image = Properties.Resources.CheckBoxUnchecked;
            btnDisable.ImageAlign = ContentAlignment.MiddleLeft;
            btnDisable.Location = new Point(673, 359);
            btnDisable.Name = "btnDisable";
            btnDisable.Size = new Size(84, 26);
            btnDisable.TabIndex = 3;
            btnDisable.Text = "Deshabilitar";
            btnDisable.TextAlign = ContentAlignment.MiddleRight;
            btnDisable.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnDisable.UseVisualStyleBackColor = true;
            btnDisable.Click += btnDisable_Click;
            // 
            // tabRawMaterials
            // 
            tabRawMaterials.Controls.Add(tpRawMaterials);
            tabRawMaterials.Location = new Point(12, 107);
            tabRawMaterials.Name = "tabRawMaterials";
            tabRawMaterials.SelectedIndex = 0;
            tabRawMaterials.Size = new Size(771, 418);
            tabRawMaterials.TabIndex = 4;
            // 
            // tpRawMaterials
            // 
            tpRawMaterials.Controls.Add(btnEnable);
            tpRawMaterials.Controls.Add(dgvRawMaterials);
            tpRawMaterials.Controls.Add(btnDisable);
            tpRawMaterials.Controls.Add(btnAdd);
            tpRawMaterials.Controls.Add(btnRemove);
            tpRawMaterials.Location = new Point(4, 23);
            tpRawMaterials.Name = "tpRawMaterials";
            tpRawMaterials.Padding = new Padding(3);
            tpRawMaterials.Size = new Size(763, 391);
            tpRawMaterials.TabIndex = 0;
            tpRawMaterials.Text = "Materia Prima";
            tpRawMaterials.UseVisualStyleBackColor = true;
            // 
            // btnEnable
            // 
            btnEnable.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnEnable.Image = Properties.Resources.CheckBoxChecked;
            btnEnable.ImageAlign = ContentAlignment.MiddleLeft;
            btnEnable.Location = new Point(673, 327);
            btnEnable.Name = "btnEnable";
            btnEnable.Size = new Size(84, 26);
            btnEnable.TabIndex = 20;
            btnEnable.Text = "Habilitar";
            btnEnable.TextAlign = ContentAlignment.MiddleRight;
            btnEnable.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnEnable.UseVisualStyleBackColor = true;
            btnEnable.Click += btnEnable_Click;
            // 
            // dgvRawMaterials
            // 
            dgvRawMaterials.AllowUserToAddRows = false;
            dgvRawMaterials.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Liberation Sans Narrow", 9F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvRawMaterials.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvRawMaterials.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRawMaterials.Columns.AddRange(new DataGridViewColumn[] { colId, colName, colUNSPSC, colUNSPSCDescription, colCreatedAt, colUpdatedAt, colIsEnabled });
            dgvRawMaterials.EditMode = DataGridViewEditMode.EditOnEnter;
            dgvRawMaterials.Location = new Point(6, 6);
            dgvRawMaterials.Name = "dgvRawMaterials";
            dgvRawMaterials.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRawMaterials.Size = new Size(661, 379);
            dgvRawMaterials.TabIndex = 19;
            dgvRawMaterials.KeyPress += dgvRawMaterials_KeyPress;
            // 
            // colId
            // 
            colId.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            colId.HeaderText = "Id";
            colId.Name = "colId";
            colId.ReadOnly = true;
            colId.ToolTipText = "Identificador";
            colId.Width = 120;
            // 
            // colName
            // 
            colName.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            colName.HeaderText = "Descripción";
            colName.Name = "colName";
            colName.Width = 240;
            // 
            // colUNSPSC
            // 
            colUNSPSC.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            colUNSPSC.HeaderText = "Código (UNSPSC)";
            colUNSPSC.Name = "colUNSPSC";
            colUNSPSC.Width = 80;
            // 
            // colUNSPSCDescription
            // 
            colUNSPSCDescription.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            colUNSPSCDescription.HeaderText = "Descripción (UNSPSC)";
            colUNSPSCDescription.Name = "colUNSPSCDescription";
            colUNSPSCDescription.Width = 240;
            // 
            // colCreatedAt
            // 
            colCreatedAt.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            colCreatedAt.HeaderText = "Fec. Registro";
            colCreatedAt.Name = "colCreatedAt";
            colCreatedAt.ReadOnly = true;
            colCreatedAt.ToolTipText = "Fecha de Registro";
            colCreatedAt.Width = 80;
            // 
            // colUpdatedAt
            // 
            colUpdatedAt.HeaderText = "Fec. Actualización";
            colUpdatedAt.Name = "colUpdatedAt";
            colUpdatedAt.ReadOnly = true;
            colUpdatedAt.ToolTipText = "Fecha de Actualización";
            colUpdatedAt.Visible = false;
            // 
            // colIsEnabled
            // 
            colIsEnabled.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            colIsEnabled.HeaderText = "Act.";
            colIsEnabled.Name = "colIsEnabled";
            colIsEnabled.ReadOnly = true;
            colIsEnabled.Resizable = DataGridViewTriState.True;
            colIsEnabled.SortMode = DataGridViewColumnSortMode.Automatic;
            colIsEnabled.ToolTipText = "Está Activo";
            colIsEnabled.Width = 20;
            // 
            // mnsMain
            // 
            mnsMain.Font = new Font("Liberation Sans Narrow", 9F);
            mnsMain.Items.AddRange(new ToolStripItem[] { tsmiFile });
            mnsMain.Location = new Point(0, 0);
            mnsMain.Name = "mnsMain";
            mnsMain.Padding = new Padding(5, 2, 0, 2);
            mnsMain.Size = new Size(795, 24);
            mnsMain.TabIndex = 6;
            // 
            // tsmiFile
            // 
            tsmiFile.DropDownItems.AddRange(new ToolStripItem[] { tsmiSave, msSeparator, tsmiClose });
            tsmiFile.Name = "tsmiFile";
            tsmiFile.Size = new Size(51, 20);
            tsmiFile.Text = "Archivo";
            // 
            // tsmiSave
            // 
            tsmiSave.Name = "tsmiSave";
            tsmiSave.ShortcutKeys = Keys.Control | Keys.S;
            tsmiSave.Size = new Size(176, 22);
            tsmiSave.Text = "Grabar cambios";
            tsmiSave.Click += tsmiSave_Click;
            // 
            // msSeparator
            // 
            msSeparator.Name = "msSeparator";
            msSeparator.Size = new Size(173, 6);
            // 
            // tsmiClose
            // 
            tsmiClose.Name = "tsmiClose";
            tsmiClose.ShortcutKeys = Keys.Control | Keys.Q;
            tsmiClose.Size = new Size(176, 22);
            tsmiClose.Text = "Cerrar";
            tsmiClose.Click += tsmiClose_Click;
            // 
            // ssrStatus
            // 
            ssrStatus.Items.AddRange(new ToolStripItem[] { tslblInfo, tslblSpace, tslblContext, tsprgLoading });
            ssrStatus.Location = new Point(0, 533);
            ssrStatus.Name = "ssrStatus";
            ssrStatus.Padding = new Padding(1, 0, 12, 0);
            ssrStatus.Size = new Size(795, 22);
            ssrStatus.TabIndex = 7;
            ssrStatus.Text = "statusStrip1";
            // 
            // tslblInfo
            // 
            tslblInfo.Name = "tslblInfo";
            tslblInfo.Size = new Size(0, 17);
            // 
            // tslblSpace
            // 
            tslblSpace.Font = new Font("Liberation Sans Narrow", 9F);
            tslblSpace.Name = "tslblSpace";
            tslblSpace.Size = new Size(782, 17);
            tslblSpace.Spring = true;
            // 
            // tslblContext
            // 
            tslblContext.Image = Properties.Resources.LoadingGif;
            tslblContext.ImageAlign = ContentAlignment.MiddleLeft;
            tslblContext.Name = "tslblContext";
            tslblContext.Size = new Size(94, 17);
            tslblContext.Text = "Procesando...";
            tslblContext.Visible = false;
            // 
            // tsprgLoading
            // 
            tsprgLoading.Name = "tsprgLoading";
            tsprgLoading.Size = new Size(86, 16);
            tsprgLoading.Visible = false;
            // 
            // txtTextToSearch
            // 
            txtTextToSearch.Location = new Point(6, 35);
            txtTextToSearch.Name = "txtTextToSearch";
            txtTextToSearch.PlaceholderText = "Ingrese texto a buscar";
            txtTextToSearch.Size = new Size(667, 20);
            txtTextToSearch.TabIndex = 8;
            txtTextToSearch.KeyPress += txtTextToSearch_KeyPress;
            // 
            // grpFilter
            // 
            grpFilter.AutoSize = true;
            grpFilter.Controls.Add(label1);
            grpFilter.Controls.Add(btnSearch);
            grpFilter.Controls.Add(txtTextToSearch);
            grpFilter.Location = new Point(10, 25);
            grpFilter.Name = "grpFilter";
            grpFilter.Size = new Size(773, 77);
            grpFilter.TabIndex = 9;
            grpFilter.TabStop = false;
            grpFilter.Text = "Filtro";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 18);
            label1.Name = "label1";
            label1.Size = new Size(52, 14);
            label1.TabIndex = 12;
            label1.Text = "Búsqueda:";
            // 
            // btnSearch
            // 
            btnSearch.Image = Properties.Resources.Search;
            btnSearch.Location = new Point(679, 32);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(84, 26);
            btnSearch.TabIndex = 10;
            btnSearch.Text = "Buscar";
            btnSearch.TextAlign = ContentAlignment.MiddleRight;
            btnSearch.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSearch.Click += btnSearch_Click;
            // 
            // frmRawMaterialManagement
            // 
            AutoScaleDimensions = new SizeF(6F, 14F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(795, 555);
            Controls.Add(grpFilter);
            Controls.Add(ssrStatus);
            Controls.Add(mnsMain);
            Controls.Add(tabRawMaterials);
            Font = new Font("Liberation Sans Narrow", 9F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = mnsMain;
            MaximizeBox = false;
            Name = "frmRawMaterialManagement";
            Text = "Gestión de Materias Prima";
            Load += frmRawMaterialManagement_Load;
            tabRawMaterials.ResumeLayout(false);
            tpRawMaterials.ResumeLayout(false);
            tpRawMaterials.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRawMaterials).EndInit();
            mnsMain.ResumeLayout(false);
            mnsMain.PerformLayout();
            ssrStatus.ResumeLayout(false);
            ssrStatus.PerformLayout();
            grpFilter.ResumeLayout(false);
            grpFilter.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnAdd;
        private Button btnRemove;
        private Button btnDisable;
        private TabControl tabRawMaterials;
        private TabPage tpRawMaterials;
        private TabPage tabPage2;
        private MenuStrip mnsMain;
        private ToolStripMenuItem tsmiFile;
        private ToolStripMenuItem tsmiSave;
        private StatusStrip ssrStatus;
        private ToolStripSeparator msSeparator;
        private ToolStripMenuItem tsmiClose;
        private ToolStripStatusLabel tslblInfo;
        private ToolStripStatusLabel tslblSpace;
        private ToolStripStatusLabel tslblContext;
        private ToolStripProgressBar tsprgLoading;
        private TextBox txtTextToSearch;
        private GroupBox grpFilter;
        private Button btnSearch;
        private Label label1;
        private DataGridView dgvRawMaterials;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colName;
        private DataGridViewTextBoxColumn colUNSPSC;
        private DataGridViewTextBoxColumn colUNSPSCDescription;
        private DataGridViewTextBoxColumn colCreatedAt;
        private DataGridViewTextBoxColumn colUpdatedAt;
        private DataGridViewCheckBoxColumn colIsEnabled;
        private Button btnEnable;
    }
}