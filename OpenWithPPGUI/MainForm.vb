Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Threading
Imports Microsoft.Win32

Public Class MainForm
    Inherits Form

#Region " Designer "
    Protected Overloads Overrides Sub Dispose(disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents tbName As System.Windows.Forms.TextBox
    Friend WithEvents bnCancel As System.Windows.Forms.Button
    Friend WithEvents bnOK As System.Windows.Forms.Button
    Friend WithEvents laExt As System.Windows.Forms.Label
    Friend WithEvents tbFileTypes As System.Windows.Forms.TextBox
    Friend WithEvents cbSubmenu As System.Windows.Forms.CheckBox
    Friend WithEvents tbArguments As System.Windows.Forms.TextBox
    Friend WithEvents tbPath As System.Windows.Forms.TextBox
    Friend WithEvents cbDirectories As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents cbRunAsAdmin As System.Windows.Forms.CheckBox
    Friend WithEvents lv As System.Windows.Forms.ListView
    Friend WithEvents tbSearch As System.Windows.Forms.TextBox
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbAdd As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbRemove As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbClone As System.Windows.Forms.ToolStripButton
    Friend WithEvents laName As System.Windows.Forms.Label
    Friend WithEvents laPath As System.Windows.Forms.Label
    Friend WithEvents laArgs As System.Windows.Forms.Label
    Friend WithEvents PropsFlowLayoutPanel As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents bnPath As System.Windows.Forms.Button
    Friend WithEvents bnArguments As System.Windows.Forms.Button
    Friend WithEvents MainTableLayoutPanel As TableLayoutPanel
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents ToolStripDropDownButton3 As ToolStripDropDownButton
    Friend WithEvents miOpenWebsite As ToolStripMenuItem
    Friend WithEvents miAbout As ToolStripMenuItem
    Friend WithEvents bnFileTypes As Button
    Friend WithEvents cbHideWindow As CheckBox
    Friend WithEvents tsbInstallUninstall As ToolStripButton
    Friend WithEvents tsbOptions As ToolStripButton
    Friend WithEvents tsMain As System.Windows.Forms.ToolStrip
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.tbName = New System.Windows.Forms.TextBox()
        Me.bnCancel = New System.Windows.Forms.Button()
        Me.bnOK = New System.Windows.Forms.Button()
        Me.tbPath = New System.Windows.Forms.TextBox()
        Me.tbArguments = New System.Windows.Forms.TextBox()
        Me.cbDirectories = New System.Windows.Forms.CheckBox()
        Me.cbSubmenu = New System.Windows.Forms.CheckBox()
        Me.tbFileTypes = New System.Windows.Forms.TextBox()
        Me.laExt = New System.Windows.Forms.Label()
        Me.cbRunAsAdmin = New System.Windows.Forms.CheckBox()
        Me.lv = New System.Windows.Forms.ListView()
        Me.tbSearch = New System.Windows.Forms.TextBox()
        Me.tsMain = New System.Windows.Forms.ToolStrip()
        Me.tsbAdd = New System.Windows.Forms.ToolStripButton()
        Me.tsbRemove = New System.Windows.Forms.ToolStripButton()
        Me.tsbOptions = New System.Windows.Forms.ToolStripButton()
        Me.tsbClone = New System.Windows.Forms.ToolStripButton()
        Me.tsbInstallUninstall = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripDropDownButton3 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.miOpenWebsite = New System.Windows.Forms.ToolStripMenuItem()
        Me.miAbout = New System.Windows.Forms.ToolStripMenuItem()
        Me.laPath = New System.Windows.Forms.Label()
        Me.laName = New System.Windows.Forms.Label()
        Me.laArgs = New System.Windows.Forms.Label()
        Me.bnPath = New System.Windows.Forms.Button()
        Me.bnArguments = New System.Windows.Forms.Button()
        Me.PropsFlowLayoutPanel = New System.Windows.Forms.FlowLayoutPanel()
        Me.cbHideWindow = New System.Windows.Forms.CheckBox()
        Me.MainTableLayoutPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.bnFileTypes = New System.Windows.Forms.Button()
        Me.tsMain.SuspendLayout()
        Me.PropsFlowLayoutPanel.SuspendLayout()
        Me.MainTableLayoutPanel.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'tbName
        '
        Me.tbName.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbName.Location = New System.Drawing.Point(813, 93)
        Me.tbName.Margin = New System.Windows.Forms.Padding(3, 10, 0, 10)
        Me.tbName.Name = "tbName"
        Me.tbName.Size = New System.Drawing.Size(1320, 55)
        Me.tbName.TabIndex = 0
        '
        'bnCancel
        '
        Me.bnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.bnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.bnCancel.Location = New System.Drawing.Point(245, 15)
        Me.bnCancel.Margin = New System.Windows.Forms.Padding(15)
        Me.bnCancel.Name = "bnCancel"
        Me.bnCancel.Size = New System.Drawing.Size(230, 70)
        Me.bnCancel.TabIndex = 11
        Me.bnCancel.Text = "Cancel"
        '
        'bnOK
        '
        Me.bnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.bnOK.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.bnOK.Location = New System.Drawing.Point(0, 15)
        Me.bnOK.Margin = New System.Windows.Forms.Padding(0, 15, 0, 15)
        Me.bnOK.Name = "bnOK"
        Me.bnOK.Size = New System.Drawing.Size(230, 70)
        Me.bnOK.TabIndex = 10
        Me.bnOK.Text = "OK"
        '
        'tbPath
        '
        Me.tbPath.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbPath.Location = New System.Drawing.Point(813, 246)
        Me.tbPath.Margin = New System.Windows.Forms.Padding(3, 10, 0, 10)
        Me.tbPath.Name = "tbPath"
        Me.tbPath.Size = New System.Drawing.Size(1320, 55)
        Me.tbPath.TabIndex = 0
        '
        'tbArguments
        '
        Me.tbArguments.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbArguments.HideSelection = False
        Me.tbArguments.Location = New System.Drawing.Point(813, 321)
        Me.tbArguments.Margin = New System.Windows.Forms.Padding(3, 10, 0, 10)
        Me.tbArguments.Name = "tbArguments"
        Me.tbArguments.Size = New System.Drawing.Size(1320, 55)
        Me.tbArguments.TabIndex = 0
        '
        'cbDirectories
        '
        Me.cbDirectories.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cbDirectories.Location = New System.Drawing.Point(20, 86)
        Me.cbDirectories.Margin = New System.Windows.Forms.Padding(20, 3, 3, 3)
        Me.cbDirectories.Name = "cbDirectories"
        Me.cbDirectories.Size = New System.Drawing.Size(600, 60)
        Me.cbDirectories.TabIndex = 0
        Me.cbDirectories.Text = "Show for directories"
        '
        'cbSubmenu
        '
        Me.cbSubmenu.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cbSubmenu.Location = New System.Drawing.Point(20, 20)
        Me.cbSubmenu.Margin = New System.Windows.Forms.Padding(20, 20, 3, 3)
        Me.cbSubmenu.Name = "cbSubmenu"
        Me.cbSubmenu.Size = New System.Drawing.Size(600, 60)
        Me.cbSubmenu.TabIndex = 0
        Me.cbSubmenu.Text = "Show in sub menu"
        '
        'tbFileTypes
        '
        Me.tbFileTypes.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbFileTypes.Location = New System.Drawing.Point(813, 171)
        Me.tbFileTypes.Margin = New System.Windows.Forms.Padding(3, 10, 0, 10)
        Me.tbFileTypes.Name = "tbFileTypes"
        Me.tbFileTypes.Size = New System.Drawing.Size(1320, 55)
        Me.tbFileTypes.TabIndex = 2
        '
        'laExt
        '
        Me.laExt.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.laExt.AutoSize = True
        Me.laExt.Location = New System.Drawing.Point(605, 174)
        Me.laExt.Margin = New System.Windows.Forms.Padding(15, 0, 3, 0)
        Me.laExt.Name = "laExt"
        Me.laExt.Size = New System.Drawing.Size(182, 48)
        Me.laExt.TabIndex = 1
        Me.laExt.Text = "File Types:"
        '
        'cbRunAsAdmin
        '
        Me.cbRunAsAdmin.Location = New System.Drawing.Point(20, 152)
        Me.cbRunAsAdmin.Margin = New System.Windows.Forms.Padding(20, 3, 3, 3)
        Me.cbRunAsAdmin.Name = "cbRunAsAdmin"
        Me.cbRunAsAdmin.Size = New System.Drawing.Size(600, 60)
        Me.cbRunAsAdmin.TabIndex = 1
        Me.cbRunAsAdmin.Text = "Run as admin"
        Me.cbRunAsAdmin.UseVisualStyleBackColor = True
        '
        'lv
        '
        Me.lv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lv.HideSelection = False
        Me.lv.Location = New System.Drawing.Point(15, 164)
        Me.lv.Margin = New System.Windows.Forms.Padding(15, 3, 3, 3)
        Me.lv.Name = "lv"
        Me.MainTableLayoutPanel.SetRowSpan(Me.lv, 4)
        Me.lv.Size = New System.Drawing.Size(572, 805)
        Me.lv.TabIndex = 1
        Me.lv.UseCompatibleStateImageBehavior = False
        '
        'tbSearch
        '
        Me.tbSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbSearch.Location = New System.Drawing.Point(0, 10)
        Me.tbSearch.Margin = New System.Windows.Forms.Padding(0)
        Me.tbSearch.Name = "tbSearch"
        Me.tbSearch.Size = New System.Drawing.Size(572, 55)
        Me.tbSearch.TabIndex = 0
        '
        'tsMain
        '
        Me.tsMain.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tsMain.AutoSize = False
        Me.MainTableLayoutPanel.SetColumnSpan(Me.tsMain, 4)
        Me.tsMain.Dock = System.Windows.Forms.DockStyle.None
        Me.tsMain.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.tsMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.tsMain.ImageScalingSize = New System.Drawing.Size(48, 48)
        Me.tsMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbAdd, Me.tsbRemove, Me.tsbClone, Me.tsbInstallUninstall, Me.tsbOptions, Me.ToolStripDropDownButton3})
        Me.tsMain.Location = New System.Drawing.Point(0, 0)
        Me.tsMain.Name = "tsMain"
        Me.tsMain.Size = New System.Drawing.Size(2364, 80)
        Me.tsMain.TabIndex = 14
        '
        'tsbAdd
        '
        Me.tsbAdd.AutoToolTip = False
        Me.tsbAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbAdd.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbAdd.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.tsbAdd.Name = "tsbAdd"
        Me.tsbAdd.Padding = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.tsbAdd.Size = New System.Drawing.Size(209, 74)
        Me.tsbAdd.Text = "      Add      "
        '
        'tsbRemove
        '
        Me.tsbRemove.AutoToolTip = False
        Me.tsbRemove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbRemove.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbRemove.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.tsbRemove.Name = "tsbRemove"
        Me.tsbRemove.Size = New System.Drawing.Size(212, 74)
        Me.tsbRemove.Text = "   Remove   "
        '
        'tsbOptions
        '
        Me.tsbOptions.AutoToolTip = False
        Me.tsbOptions.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbOptions.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbOptions.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.tsbOptions.Name = "tsbOptions"
        Me.tsbOptions.Size = New System.Drawing.Size(209, 74)
        Me.tsbOptions.Text = "   Options   "
        '
        'tsbClone
        '
        Me.tsbClone.AutoToolTip = False
        Me.tsbClone.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbClone.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbClone.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.tsbClone.Name = "tsbClone"
        Me.tsbClone.Size = New System.Drawing.Size(215, 74)
        Me.tsbClone.Text = "     Clone     "
        '
        'tsbInstallUninstall
        '
        Me.tsbInstallUninstall.AutoToolTip = False
        Me.tsbInstallUninstall.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbInstallUninstall.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbInstallUninstall.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.tsbInstallUninstall.Name = "tsbInstallUninstall"
        Me.tsbInstallUninstall.Size = New System.Drawing.Size(268, 74)
        Me.tsbInstallUninstall.Text = "Install/Uninstall"
        '
        'ToolStripDropDownButton3
        '
        Me.ToolStripDropDownButton3.AutoToolTip = False
        Me.ToolStripDropDownButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripDropDownButton3.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miOpenWebsite, Me.miAbout})
        Me.ToolStripDropDownButton3.Image = CType(resources.GetObject("ToolStripDropDownButton3.Image"), System.Drawing.Image)
        Me.ToolStripDropDownButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton3.Name = "ToolStripDropDownButton3"
        Me.ToolStripDropDownButton3.Size = New System.Drawing.Size(206, 71)
        Me.ToolStripDropDownButton3.Text = "    Help    "
        '
        'miOpenWebsite
        '
        Me.miOpenWebsite.Name = "miOpenWebsite"
        Me.miOpenWebsite.Size = New System.Drawing.Size(538, 66)
        Me.miOpenWebsite.Text = "Website"
        '
        'miAbout
        '
        Me.miAbout.Name = "miAbout"
        Me.miAbout.Size = New System.Drawing.Size(538, 66)
        Me.miAbout.Text = "About"
        '
        'laPath
        '
        Me.laPath.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.laPath.AutoSize = True
        Me.laPath.Location = New System.Drawing.Point(605, 249)
        Me.laPath.Margin = New System.Windows.Forms.Padding(15, 0, 3, 0)
        Me.laPath.Name = "laPath"
        Me.laPath.Size = New System.Drawing.Size(97, 48)
        Me.laPath.TabIndex = 4
        Me.laPath.Text = "Path:"
        '
        'laName
        '
        Me.laName.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.laName.AutoSize = True
        Me.laName.Location = New System.Drawing.Point(605, 96)
        Me.laName.Margin = New System.Windows.Forms.Padding(15, 0, 3, 0)
        Me.laName.Name = "laName"
        Me.laName.Size = New System.Drawing.Size(123, 48)
        Me.laName.TabIndex = 0
        Me.laName.Text = "Name:"
        '
        'laArgs
        '
        Me.laArgs.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.laArgs.AutoSize = True
        Me.laArgs.Location = New System.Drawing.Point(605, 324)
        Me.laArgs.Margin = New System.Windows.Forms.Padding(15, 0, 3, 0)
        Me.laArgs.Name = "laArgs"
        Me.laArgs.Size = New System.Drawing.Size(202, 48)
        Me.laArgs.TabIndex = 5
        Me.laArgs.Text = "Arguments:"
        '
        'bnPath
        '
        Me.bnPath.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.bnPath.Location = New System.Drawing.Point(2148, 238)
        Me.bnPath.Margin = New System.Windows.Forms.Padding(15, 0, 15, 0)
        Me.bnPath.Name = "bnPath"
        Me.bnPath.Size = New System.Drawing.Size(200, 70)
        Me.bnPath.TabIndex = 7
        Me.bnPath.Text = "Browse..."
        '
        'bnArguments
        '
        Me.bnArguments.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.bnArguments.Location = New System.Drawing.Point(2148, 313)
        Me.bnArguments.Margin = New System.Windows.Forms.Padding(15, 0, 15, 0)
        Me.bnArguments.Name = "bnArguments"
        Me.bnArguments.Size = New System.Drawing.Size(200, 70)
        Me.bnArguments.TabIndex = 8
        Me.bnArguments.Text = "%paths%"
        Me.bnArguments.UseVisualStyleBackColor = True
        '
        'PropsFlowLayoutPanel
        '
        Me.PropsFlowLayoutPanel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MainTableLayoutPanel.SetColumnSpan(Me.PropsFlowLayoutPanel, 3)
        Me.PropsFlowLayoutPanel.Controls.Add(Me.cbSubmenu)
        Me.PropsFlowLayoutPanel.Controls.Add(Me.cbDirectories)
        Me.PropsFlowLayoutPanel.Controls.Add(Me.cbRunAsAdmin)
        Me.PropsFlowLayoutPanel.Controls.Add(Me.cbHideWindow)
        Me.PropsFlowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.PropsFlowLayoutPanel.Location = New System.Drawing.Point(593, 389)
        Me.PropsFlowLayoutPanel.Name = "PropsFlowLayoutPanel"
        Me.PropsFlowLayoutPanel.Size = New System.Drawing.Size(1768, 580)
        Me.PropsFlowLayoutPanel.TabIndex = 16
        '
        'cbHideWindow
        '
        Me.cbHideWindow.Location = New System.Drawing.Point(20, 218)
        Me.cbHideWindow.Margin = New System.Windows.Forms.Padding(20, 3, 3, 3)
        Me.cbHideWindow.Name = "cbHideWindow"
        Me.cbHideWindow.Size = New System.Drawing.Size(600, 60)
        Me.cbHideWindow.TabIndex = 2
        Me.cbHideWindow.Text = "Run hidden"
        Me.cbHideWindow.UseVisualStyleBackColor = True
        '
        'MainTableLayoutPanel
        '
        Me.MainTableLayoutPanel.ColumnCount = 4
        Me.MainTableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.85802!))
        Me.MainTableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.MainTableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 69.14198!))
        Me.MainTableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.MainTableLayoutPanel.Controls.Add(Me.FlowLayoutPanel1, 2, 6)
        Me.MainTableLayoutPanel.Controls.Add(Me.bnArguments, 3, 4)
        Me.MainTableLayoutPanel.Controls.Add(Me.PropsFlowLayoutPanel, 1, 5)
        Me.MainTableLayoutPanel.Controls.Add(Me.tbArguments, 2, 4)
        Me.MainTableLayoutPanel.Controls.Add(Me.lv, 0, 2)
        Me.MainTableLayoutPanel.Controls.Add(Me.laPath, 1, 3)
        Me.MainTableLayoutPanel.Controls.Add(Me.laArgs, 1, 4)
        Me.MainTableLayoutPanel.Controls.Add(Me.tbPath, 2, 3)
        Me.MainTableLayoutPanel.Controls.Add(Me.tsMain, 0, 0)
        Me.MainTableLayoutPanel.Controls.Add(Me.laName, 1, 1)
        Me.MainTableLayoutPanel.Controls.Add(Me.tbFileTypes, 2, 2)
        Me.MainTableLayoutPanel.Controls.Add(Me.tbName, 2, 1)
        Me.MainTableLayoutPanel.Controls.Add(Me.laExt, 1, 2)
        Me.MainTableLayoutPanel.Controls.Add(Me.TableLayoutPanel1, 0, 1)
        Me.MainTableLayoutPanel.Controls.Add(Me.bnPath, 3, 3)
        Me.MainTableLayoutPanel.Controls.Add(Me.bnFileTypes, 3, 2)
        Me.MainTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MainTableLayoutPanel.Location = New System.Drawing.Point(0, 0)
        Me.MainTableLayoutPanel.Name = "MainTableLayoutPanel"
        Me.MainTableLayoutPanel.RowCount = 7
        Me.MainTableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.MainTableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.MainTableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.MainTableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.MainTableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.MainTableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.MainTableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.MainTableLayoutPanel.Size = New System.Drawing.Size(2364, 1078)
        Me.MainTableLayoutPanel.TabIndex = 17
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.FlowLayoutPanel1.AutoSize = True
        Me.FlowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.MainTableLayoutPanel.SetColumnSpan(Me.FlowLayoutPanel1, 2)
        Me.FlowLayoutPanel1.Controls.Add(Me.bnOK)
        Me.FlowLayoutPanel1.Controls.Add(Me.bnCancel)
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(1871, 975)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(490, 100)
        Me.FlowLayoutPanel1.TabIndex = 18
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.tbSearch, 0, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(15, 83)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(15, 3, 3, 3)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(572, 75)
        Me.TableLayoutPanel1.TabIndex = 19
        '
        'bnFileTypes
        '
        Me.bnFileTypes.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.bnFileTypes.Location = New System.Drawing.Point(2148, 163)
        Me.bnFileTypes.Margin = New System.Windows.Forms.Padding(15, 0, 15, 0)
        Me.bnFileTypes.Name = "bnFileTypes"
        Me.bnFileTypes.Size = New System.Drawing.Size(200, 70)
        Me.bnFileTypes.TabIndex = 20
        Me.bnFileTypes.Text = "All Files"
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(288.0!, 288.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(2364, 1078)
        Me.Controls.Add(Me.MainTableLayoutPanel)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "MainForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Open with++"
        Me.tsMain.ResumeLayout(False)
        Me.tsMain.PerformLayout()
        Me.PropsFlowLayoutPanel.ResumeLayout(False)
        Me.MainTableLayoutPanel.ResumeLayout(False)
        Me.MainTableLayoutPanel.PerformLayout()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private SelectedItem As Item
    Private TempItems As New List(Of Item)
    Private DLLPath As String = Path.Combine(Application.StartupPath, "OpenWithPPShellExtension.dll")

    Public Sub New()
        MyBase.New()
        InitializeComponent()

        AddHandler Application.ThreadException, AddressOf ApplicationThreadException
        Text += " " + Application.ProductVersion.ToString

        lv.View = View.Details
        lv.Columns.Add("")
        lv.HeaderStyle = ColumnHeaderStyle.None
        lv.MultiSelect = False
        lv.Sorting = SortOrder.Ascending
        lv.HideSelection = False
        Native.HideFocus(lv.Handle)

        SetCue(tbSearch, "Search", False)
        tbSearch.Focus()

        Dim margin = tsbAdd.Margin
        margin.Left = CInt(FontHeight * 0.33)
        tsbAdd.Margin = margin

        g.LoadSettings()

        If g.Settings.Items.Count > 0 Then
            TempItems = CloneObject(Of List(Of Item))(g.Settings.Items)

            For Each i In TempItems
                lv.Items.Add(i.Name).Tag = i
            Next
        End If

        SetColumnWidths()
        SelectFirst()
        Native.SetWindowTheme(lv.Handle, "explorer", Nothing)
    End Sub

    <STAThread()>
    Public Shared Sub Main()
        Application.SetCompatibleTextRenderingDefault(False)
        Application.Run(New MainForm)
    End Sub

    Shared Sub ApplicationThreadException(sender As Object, e As ThreadExceptionEventArgs)
        MsgError(e.Exception.ToString)
    End Sub

    Sub SelectFirst()
        If lv.Items.Count > 0 Then
            lv.Items(0).Selected = True
            lv.Items(0).EnsureVisible()
        End If

        UpdateControls()
    End Sub

    Sub SetColumnWidths()
        Dim scrollbarWidth As Integer

        If lv.Items.Count > 0 AndAlso (lv.Height - lv.Items(0).Bounds.Height) < lv.Items(0).Bounds.Height * lv.Items.Count Then
            scrollbarWidth = SystemInformation.VerticalScrollBarWidth
        End If

        lv.Columns(0).Width = lv.Width - scrollbarWidth - 5
    End Sub

    Public Shared Function CloneObject(Of T)(o As Object) As T
        Using ms As New MemoryStream
            Dim bf As New BinaryFormatter
            bf.Serialize(ms, o)
            ms.Position = 0
            Return DirectCast(bf.Deserialize(ms), T)
        End Using
    End Function

    Sub tbName_TextChanged(sender As Object, e As EventArgs) Handles tbName.TextChanged
        If tbName.Focused AndAlso Not SelectedItem Is Nothing Then
            SelectedItem.Name = tbName.Text
            lv.SelectedItems(0).Text = tbName.Text
        End If
    End Sub

    Sub tbExt_TextChanged(sender As Object, e As EventArgs) Handles tbFileTypes.TextChanged
        If tbFileTypes.Focused AndAlso Not SelectedItem Is Nothing Then
            Dim value = tbFileTypes.Text.ToLower
            If value.Contains(",") Then value = value.Replace(",", " ")
            If value.Contains(";") Then value = value.Replace(";", " ")

            While value.Contains("  ")
                value = value.Replace("  ", " ")
            End While

            SelectedItem.FileTypesDisplay = value.Trim
        End If
    End Sub

    Function SolveMacros(value As String) As String
        For Each macro In g.Settings.Macros
            If value.Contains(macro.Name) Then
                value = value.Replace(macro.Name, macro.Value)
            End If
        Next

        Return value
    End Function

    Sub cbSubmenu_CheckedChanged(sender As Object, e As EventArgs) Handles cbSubmenu.CheckedChanged
        If cbSubmenu.Focused AndAlso Not SelectedItem Is Nothing Then
            SelectedItem.SubMenu = cbSubmenu.Checked
        End If
    End Sub

    Sub cbRunAsAdmin_CheckedChanged(sender As Object, e As EventArgs) Handles cbRunAsAdmin.CheckedChanged
        If cbRunAsAdmin.Focused AndAlso Not SelectedItem Is Nothing Then
            SelectedItem.RunAsAdmin = cbRunAsAdmin.Checked
        End If
    End Sub

    Sub tbPath_TextChanged(sender As Object, e As EventArgs) Handles tbPath.TextChanged
        If tbPath.Focused AndAlso Not SelectedItem Is Nothing Then
            SelectedItem.Path = tbPath.Text
        End If
    End Sub

    Sub tbArgs_TextChanged(sender As Object, e As EventArgs) Handles tbArguments.TextChanged
        If tbArguments.Focused AndAlso Not SelectedItem Is Nothing Then
            SelectedItem.Arguments = tbArguments.Text
        End If
    End Sub

    Sub cbDirectories_CheckedChanged(sender As Object, e As EventArgs) Handles cbDirectories.CheckedChanged
        If cbDirectories.Focused AndAlso Not SelectedItem Is Nothing Then
            SelectedItem.Directories = cbDirectories.Checked
        End If
    End Sub

    Private Sub tbPath_DoubleClick() Handles tbPath.DoubleClick
        tbPath.Focus()

        Using form As New OpenFileDialog
            If form.ShowDialog = DialogResult.OK Then
                tbPath.Text = form.FileName
            End If
        End Using
    End Sub

    Sub AddItem(item As Item)
        Dim lvi = lv.Items.Add(item.Name)
        lvi.Tag = item
        lvi.Selected = True
        lvi.EnsureVisible()
        TempItems.Add(item)
        UpdateControls()
    End Sub

    Private Sub lv_KeyUp(sender As Object, e As KeyEventArgs) Handles lv.KeyUp
        If e.KeyData = Keys.Delete AndAlso tsbRemove.Enabled Then
            tsbRemove.PerformClick()
        End If

        UpdateControls()
    End Sub

    Private Sub lv_MouseUp(sender As Object, e As MouseEventArgs) Handles lv.MouseUp
        UpdateControls()
    End Sub

    Sub UpdateControls()
        If lv.SelectedItems.Count > 0 Then
            SelectedItem = DirectCast(lv.SelectedItems(0).Tag, Item)
        Else
            SelectedItem = Nothing
        End If

        If Not SelectedItem Is Nothing Then
            PropsFlowLayoutPanel.Enabled = True
            tbArguments.Enabled = True
            tbFileTypes.Enabled = True
            tbName.Enabled = True
            tbPath.Enabled = True
            bnArguments.Enabled = True
            bnPath.Enabled = True
            bnFileTypes.Enabled = True
            laArgs.Enabled = True
            laExt.Enabled = True
            laName.Enabled = True
            laPath.Enabled = True

            tbName.Text = SelectedItem.Name

            If SelectedItem.FileTypesDisplay = "" Then
                tbFileTypes.Text = SelectedItem.FileTypes
            Else
                tbFileTypes.Text = SelectedItem.FileTypesDisplay
            End If

            tbPath.Text = SelectedItem.Path
            tbArguments.Text = SelectedItem.Arguments

            cbSubmenu.Checked = SelectedItem.SubMenu
            cbDirectories.Checked = SelectedItem.Directories
            cbRunAsAdmin.Checked = SelectedItem.RunAsAdmin
            cbHideWindow.Checked = SelectedItem.HideWindow
        Else
            PropsFlowLayoutPanel.Enabled = False
            tbArguments.Enabled = False
            tbFileTypes.Enabled = False
            tbName.Enabled = False
            tbPath.Enabled = False
            bnArguments.Enabled = False
            bnPath.Enabled = False
            bnFileTypes.Enabled = False
            laArgs.Enabled = False
            laExt.Enabled = False
            laName.Enabled = False
            laPath.Enabled = False
            cbDirectories.Checked = False
            cbSubmenu.Checked = False
            cbRunAsAdmin.Checked = False
            cbHideWindow.Checked = False

            tbName.Text = ""
            tbFileTypes.Text = ""
            tbPath.Text = ""
            tbArguments.Text = ""
        End If

        tsbRemove.Enabled = Not SelectedItem Is Nothing
        tsbClone.Enabled = Not SelectedItem Is Nothing
    End Sub

    Private Sub tbSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles tbSearch.KeyDown
        If lv.SelectedItems.Count > 0 Then
            Dim index = lv.SelectedItems(0).Index

            Select Case e.KeyData
                Case Keys.Up
                    index -= 1
                    e.Handled = True
                Case Keys.Down
                    index += 1
                    e.Handled = True
            End Select

            If index < 0 Then
                index = 0
            ElseIf index >= lv.Items.Count Then
                index = lv.Items.Count - 1
            End If

            If index <> lv.SelectedItems(0).Index Then
                lv.Items(index).Selected = True
                UpdateControls()
            End If
        End If
    End Sub

    Private Sub tbSearch_TextChanged(sender As Object, e As EventArgs) Handles tbSearch.TextChanged
        lv.BeginUpdate()
        lv.Items.Clear()

        Dim query = tbSearch.Text.ToLower

        For Each i In TempItems
            If tbSearch.Text = "" OrElse
                i.Name.ToLower.Contains(query) OrElse
                i.Path.ToLower.Contains(query) OrElse
                i.FileTypes.ToLower.Contains(query) OrElse
                i.Arguments.ToLower.Contains(query) Then

                lv.Items.Add(i.Name).Tag = i
            End If
        Next

        SelectFirst()
        SetColumnWidths()
        lv.EndUpdate()
    End Sub

    Private Sub bnOK_Click(sender As Object, e As EventArgs) Handles bnOK.Click
        g.Settings.Items = TempItems
        g.Settings.Items.Sort()

        For Each i In g.Settings.Items
            i.FileTypes = SolveMacros(i.FileTypesDisplay)
        Next

        g.SaveSettings()
        WriteRegistryValues()
        Close()
    End Sub

    Sub WriteRegistryValues()
        RegistryHelp.SetValue(Registry.CurrentUser, "Software\OpenWithPP", "Reload", 1)
        RegistryHelp.SetValue(Registry.CurrentUser, "Software\OpenWithPP", "SettingsLocation", g.SettingsDir + "Settings.xml")
        RegistryHelp.SetValue(Registry.CurrentUser, "Software\OpenWithPP", "ExeLocation", Application.ExecutablePath)
        RegistryHelp.SetValue(Registry.CurrentUser, "Software\OpenWithPP", "ExeDir", Application.StartupPath + "\")
    End Sub

    Private Sub bnCancel_Click(sender As Object, e As EventArgs) Handles bnCancel.Click
        Close()
    End Sub

    Private Sub tsbAdd_Click(sender As Object, e As EventArgs) Handles tsbAdd.Click
        AddItem(New Item With {.Arguments = "%paths%"})
        tbSearch.Text = ""
    End Sub

    Private Sub tsbRemove_Click(sender As Object, e As EventArgs) Handles tsbRemove.Click
        Dim i = lv.SelectedIndices(0)
        TempItems.Remove(SelectedItem)
        lv.SelectedItems(0).Remove()
        If i > lv.Items.Count - 1 Then i = i - 1
        If i >= 0 Then lv.Items(i).Selected = True
        UpdateControls()
    End Sub

    Private Sub tsbClone_Click(sender As Object, e As EventArgs) Handles tsbClone.Click
        AddItem(CloneObject(Of Item)(SelectedItem))
    End Sub

    Private Sub bnArguments_Click(sender As Object, e As EventArgs) Handles bnArguments.Click
        tbArguments.Focus()
        tbArguments.Text = (tbArguments.Text.Trim + " %paths%").Trim
    End Sub

    Private Sub bnPath_Click(sender As Object, e As EventArgs) Handles bnPath.Click
        tbPath_DoubleClick()
    End Sub

    Private Sub MainForm_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        tbSearch.Focus()
        tbArguments.HideSelection = True
    End Sub

    Private Sub miOpenWebsite_Click(sender As Object, e As EventArgs) Handles miOpenWebsite.Click
        Process.Start("https://github.com/stax76/OpenWithPlusPlus")
    End Sub

    Private Sub miAbout_Click(sender As Object, e As EventArgs) Handles miAbout.Click
        MsgInfo(Application.ProductName + " " + Application.ProductVersion.ToString + BR2 + "Copyright © 2008-2019 Frank Skare (stax76)" + BR2 + "MIT License")
    End Sub

    Private Sub bnFileTypes_Click(sender As Object, e As EventArgs) Handles bnFileTypes.Click
        tbFileTypes.Focus()
        tbFileTypes.Text = "*.*"
    End Sub

    Private Sub cbHideWindow_CheckedChanged(sender As Object, e As EventArgs) Handles cbHideWindow.CheckedChanged
        If cbHideWindow.Focused AndAlso Not SelectedItem Is Nothing Then
            SelectedItem.HideWindow = cbHideWindow.Checked
        End If
    End Sub

    Sub SetCue(tb As TextBox, value As String, hideWhenFocused As Boolean)
        Const EM_SETCUEBANNER = &H1501
        Native.SendMessage(tb.Handle, EM_SETCUEBANNER, If(hideWhenFocused, 0, 1), value)
    End Sub

    Private Sub tsbOptions_Click(sender As Object, e As EventArgs) Handles tsbOptions.Click
        Using form As New OptionsForm
            If form.ShowDialog = DialogResult.OK Then
                g.Settings.Macros.Clear()
                Dim lines = form.tbMacros.Text.Split({BR}, StringSplitOptions.RemoveEmptyEntries)

                For Each line In lines
                    If line.Contains("=") Then
                        g.Settings.Macros.Add(New Macro() With {
                                              .Name = line.Substring(0, line.IndexOf("=")).Trim,
                                              .Value = line.Substring(line.IndexOf("=") + 1).Trim})
                    End If
                Next

                If Directory.Exists(form.tbSettingDirectory.Text) Then
                    g.SettingsDir = form.tbSettingDirectory.Text

                    If Not g.SettingsDir.EndsWith("\") Then
                        g.SettingsDir += "\"
                    End If
                Else
                    MsgError("Settings directory does not exist.")
                End If
            End If
        End Using
    End Sub

    Private Sub tsbInstallUninstall_Click(sender As Object, e As EventArgs) Handles tsbInstallUninstall.Click
        If tsbInstallUninstall.Text = "   Install   " Then
            If Msg("Confirm to install the Shell Extension.", "Install Shell Extension",
                   MessageBoxIcon.None, MessageBoxButtons.OKCancel) = DialogResult.OK Then

                Using proc As New Process
                    proc.StartInfo.Verb = "runas"
                    proc.StartInfo.FileName = "regsvr32"
                    proc.StartInfo.Arguments = """" + DLLPath + """"
                    proc.Start()
                End Using
            End If
        Else
            If Msg("Confirm to uninstall the Shell Extension and afterwards reboot, logout or restart the relevant processes.",
                   "Uninstall Shell Extension", MessageBoxIcon.None, MessageBoxButtons.OKCancel) = DialogResult.OK Then

                Using proc As New Process
                    proc.StartInfo.Verb = "runas"
                    proc.StartInfo.FileName = "regsvr32"
                    proc.StartInfo.Arguments = "/u """ + DLLPath + """"
                    proc.Start()
                End Using
            End If
        End If
    End Sub

    Private Sub MainForm_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        Using key = Registry.ClassesRoot.OpenSubKey("CLSID\{E7B8ACF5-FC18-4f0d-BC50-D0184481A5DC}")
            If key Is Nothing Then
                tsbInstallUninstall.Text = "   Install   "
            Else
                tsbInstallUninstall.Text = "   Uninstall   "
            End If
        End Using
    End Sub
End Class