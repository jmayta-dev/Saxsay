namespace MW.SAXSAY.Core.Presentation.WinForm;

partial class frmMdiSaxsay
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
        components = new System.ComponentModel.Container();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMdiSaxsay));
        ssrMdi = new StatusStrip();
        tslblUser = new ToolStripStatusLabel();
        tslblSpace = new ToolStripStatusLabel();
        tslblVersion = new ToolStripStatusLabel();
        tvwMenu = new TreeView();
        cmsMenuAddDropFavorite = new ContextMenuStrip(components);
        tsminAddFavorites = new ToolStripMenuItem();
        tsmiRemoveFavorites = new ToolStripMenuItem();
        imgMdi = new ImageList(components);
        tlpSidebar = new TableLayoutPanel();
        tsrMenuStrip = new ToolStrip();
        tsddbFavorites = new ToolStripDropDownButton();
        lblFilterMenu = new Label();
        txtFilterOptionMenu = new TextBox();
        tsrContentStrip = new ToolStrip();
        tsbtnShowHide = new ToolStripButton();
        toolStripSeparator1 = new ToolStripSeparator();
        tslblBreadcrumb = new ToolStripLabel();
        tsddbUserOptions = new ToolStripDropDownButton();
        tsmiLogout = new ToolStripMenuItem();
        ssrMdi.SuspendLayout();
        cmsMenuAddDropFavorite.SuspendLayout();
        tlpSidebar.SuspendLayout();
        tsrMenuStrip.SuspendLayout();
        tsrContentStrip.SuspendLayout();
        SuspendLayout();
        // 
        // ssrMdi
        // 
        ssrMdi.Items.AddRange(new ToolStripItem[] { tslblUser, tslblSpace, tslblVersion });
        ssrMdi.Location = new Point(0, 549);
        ssrMdi.Name = "ssrMdi";
        ssrMdi.Size = new Size(985, 22);
        ssrMdi.TabIndex = 1;
        ssrMdi.Text = "statusStrip1";
        // 
        // tslblUser
        // 
        tslblUser.Name = "tslblUser";
        tslblUser.Size = new Size(83, 17);
        tslblUser.Text = "Administrador";
        // 
        // tslblSpace
        // 
        tslblSpace.Name = "tslblSpace";
        tslblSpace.Size = new Size(832, 17);
        tslblSpace.Spring = true;
        // 
        // tslblVersion
        // 
        tslblVersion.Name = "tslblVersion";
        tslblVersion.Size = new Size(55, 17);
        tslblVersion.Text = "v00.00.00";
        // 
        // tvwMenu
        // 
        tvwMenu.ContextMenuStrip = cmsMenuAddDropFavorite;
        tvwMenu.Dock = DockStyle.Fill;
        tvwMenu.Font = new Font("Liberation Sans Narrow", 9F);
        tvwMenu.ImageIndex = 0;
        tvwMenu.ImageList = imgMdi;
        tvwMenu.Location = new Point(3, 72);
        tvwMenu.Name = "tvwMenu";
        tvwMenu.SelectedImageIndex = 0;
        tvwMenu.Size = new Size(194, 474);
        tvwMenu.TabIndex = 6;
        tvwMenu.NodeMouseDoubleClick += tvwMenu_NodeMouseDoubleClick;
        // 
        // cmsMenuAddDropFavorite
        // 
        cmsMenuAddDropFavorite.Items.AddRange(new ToolStripItem[] { tsminAddFavorites, tsmiRemoveFavorites });
        cmsMenuAddDropFavorite.Name = "cmsMenuAddDropFavorite";
        cmsMenuAddDropFavorite.Size = new Size(175, 48);
        // 
        // tsminAddFavorites
        // 
        tsminAddFavorites.Name = "tsminAddFavorites";
        tsminAddFavorites.Size = new Size(174, 22);
        tsminAddFavorites.Text = "Agregar a favoritos";
        // 
        // tsmiRemoveFavorites
        // 
        tsmiRemoveFavorites.Enabled = false;
        tsmiRemoveFavorites.Name = "tsmiRemoveFavorites";
        tsmiRemoveFavorites.Size = new Size(174, 22);
        tsmiRemoveFavorites.Text = "Quitar de favoritos";
        // 
        // imgMdi
        // 
        imgMdi.ColorDepth = ColorDepth.Depth32Bit;
        imgMdi.ImageStream = (ImageListStreamer)resources.GetObject("imgMdi.ImageStream");
        imgMdi.TransparentColor = Color.Transparent;
        imgMdi.Images.SetKeyName(0, "MissingFile.png");
        imgMdi.Images.SetKeyName(1, "FolderClosed.png");
        imgMdi.Images.SetKeyName(2, "WindowsForm.png");
        // 
        // tlpSidebar
        // 
        tlpSidebar.ColumnCount = 1;
        tlpSidebar.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        tlpSidebar.Controls.Add(tsrMenuStrip, 0, 0);
        tlpSidebar.Controls.Add(lblFilterMenu, 0, 1);
        tlpSidebar.Controls.Add(txtFilterOptionMenu, 0, 2);
        tlpSidebar.Controls.Add(tvwMenu, 0, 3);
        tlpSidebar.Dock = DockStyle.Left;
        tlpSidebar.Location = new Point(0, 0);
        tlpSidebar.Name = "tlpSidebar";
        tlpSidebar.RowCount = 4;
        tlpSidebar.RowStyles.Add(new RowStyle());
        tlpSidebar.RowStyles.Add(new RowStyle());
        tlpSidebar.RowStyles.Add(new RowStyle());
        tlpSidebar.RowStyles.Add(new RowStyle());
        tlpSidebar.Size = new Size(200, 549);
        tlpSidebar.TabIndex = 10;
        // 
        // tsrMenuStrip
        // 
        tsrMenuStrip.Items.AddRange(new ToolStripItem[] { tsddbFavorites });
        tsrMenuStrip.Location = new Point(0, 0);
        tsrMenuStrip.Name = "tsrMenuStrip";
        tsrMenuStrip.Size = new Size(200, 25);
        tsrMenuStrip.TabIndex = 11;
        tsrMenuStrip.Text = "toolStrip2";
        // 
        // tsddbFavorites
        // 
        tsddbFavorites.Image = Properties.Resources.DelegateProtected;
        tsddbFavorites.ImageTransparentColor = Color.Magenta;
        tsddbFavorites.Name = "tsddbFavorites";
        tsddbFavorites.Size = new Size(84, 22);
        tsddbFavorites.Text = "Favoritos";
        // 
        // lblFilterMenu
        // 
        lblFilterMenu.AutoSize = true;
        lblFilterMenu.BackColor = SystemColors.Control;
        lblFilterMenu.Dock = DockStyle.Fill;
        lblFilterMenu.Font = new Font("Liberation Sans Narrow", 9F, FontStyle.Bold);
        lblFilterMenu.Location = new Point(3, 27);
        lblFilterMenu.Margin = new Padding(3, 2, 3, 2);
        lblFilterMenu.Name = "lblFilterMenu";
        lblFilterMenu.Size = new Size(194, 14);
        lblFilterMenu.TabIndex = 8;
        lblFilterMenu.Text = "FILTRAR OPCIONES";
        lblFilterMenu.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // txtFilterOptionMenu
        // 
        txtFilterOptionMenu.Dock = DockStyle.Fill;
        txtFilterOptionMenu.Font = new Font("Liberation Sans Narrow", 9F);
        txtFilterOptionMenu.Location = new Point(3, 46);
        txtFilterOptionMenu.Name = "txtFilterOptionMenu";
        txtFilterOptionMenu.Size = new Size(194, 20);
        txtFilterOptionMenu.TabIndex = 7;
        // 
        // tsrContentStrip
        // 
        tsrContentStrip.Items.AddRange(new ToolStripItem[] { tsbtnShowHide, toolStripSeparator1, tslblBreadcrumb, tsddbUserOptions });
        tsrContentStrip.Location = new Point(200, 0);
        tsrContentStrip.Name = "tsrContentStrip";
        tsrContentStrip.Size = new Size(785, 25);
        tsrContentStrip.TabIndex = 12;
        tsrContentStrip.Text = "toolStrip1";
        // 
        // tsbtnShowHide
        // 
        tsbtnShowHide.DisplayStyle = ToolStripItemDisplayStyle.Image;
        tsbtnShowHide.Image = Properties.Resources.TableFillLeft;
        tsbtnShowHide.ImageTransparentColor = Color.Magenta;
        tsbtnShowHide.Name = "tsbtnShowHide";
        tsbtnShowHide.Size = new Size(23, 22);
        tsbtnShowHide.Text = "toolStripButton1";
        tsbtnShowHide.Click += tsbtnShowHide_Click;
        // 
        // toolStripSeparator1
        // 
        toolStripSeparator1.Name = "toolStripSeparator1";
        toolStripSeparator1.Size = new Size(6, 25);
        // 
        // tslblBreadcrumb
        // 
        tslblBreadcrumb.Name = "tslblBreadcrumb";
        tslblBreadcrumb.Size = new Size(72, 22);
        tslblBreadcrumb.Text = "Breadcrumb";
        tslblBreadcrumb.Visible = false;
        // 
        // tsddbUserOptions
        // 
        tsddbUserOptions.Alignment = ToolStripItemAlignment.Right;
        tsddbUserOptions.DropDownItems.AddRange(new ToolStripItem[] { tsmiLogout });
        tsddbUserOptions.Image = (Image)resources.GetObject("tsddbUserOptions.Image");
        tsddbUserOptions.ImageTransparentColor = Color.Magenta;
        tsddbUserOptions.Name = "tsddbUserOptions";
        tsddbUserOptions.Size = new Size(111, 22);
        tsddbUserOptions.Text = "Jheison Mayta";
        // 
        // tsmiLogout
        // 
        tsmiLogout.Name = "tsmiLogout";
        tsmiLogout.Size = new Size(143, 22);
        tsmiLogout.Text = "Cerrar Sesión";
        tsmiLogout.Click += tsmiLogout_Click;
        // 
        // frmMdiSaxsay
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(985, 571);
        Controls.Add(tsrContentStrip);
        Controls.Add(tlpSidebar);
        Controls.Add(ssrMdi);
        Icon = (Icon)resources.GetObject("$this.Icon");
        IsMdiContainer = true;
        Name = "frmMdiSaxsay";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "SAXSAY ::: Sistema de Gestión de Recetas";
        FormClosing += frmMdiSaxsay_FormClosing;
        Load += frmMdiSaxsay_Load;
        ssrMdi.ResumeLayout(false);
        ssrMdi.PerformLayout();
        cmsMenuAddDropFavorite.ResumeLayout(false);
        tlpSidebar.ResumeLayout(false);
        tlpSidebar.PerformLayout();
        tsrMenuStrip.ResumeLayout(false);
        tsrMenuStrip.PerformLayout();
        tsrContentStrip.ResumeLayout(false);
        tsrContentStrip.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private StatusStrip ssrMdi;
    private ToolStripStatusLabel tslblUser;
    private ToolStripStatusLabel tslblSpace;
    private ToolStripStatusLabel tslblVersion;
    private TreeView tvwMenu;
    private TableLayoutPanel tlpSidebar;
    private TextBox txtFilterOptionMenu;
    private Label lblFilterMenu;
    private ToolStripMenuItem toolStripTextBox1;
    private ToolStrip tsrContentStrip;
    private ToolStripLabel tslblBreadcrumb;
    private ImageList imgMdi;
    private ToolStripSplitButton tsspbUserOptions;
    private ToolStripMenuItem tsmiLogout;
    private ToolStripDropDownButton tsddbUserOptions;
    private ToolStrip tsrMenuStrip;
    private ToolStripButton tsbtnShowHide;
    private ToolStripDropDownButton tsddbFavorites;
    private ToolStripSeparator toolStripSeparator1;
    private ContextMenuStrip cmsMenuAddDropFavorite;
    private ToolStripMenuItem tsminAddFavorites;
    private ToolStripMenuItem tsmiRemoveFavorites;
}
