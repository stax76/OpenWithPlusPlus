Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Text
Imports System.Threading
Imports Microsoft.Win32

Public Class MainForm
    Inherits Form

#Region " Designer "
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
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
    Friend WithEvents lExt As System.Windows.Forms.Label
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
    Friend WithEvents cbAllFiles As System.Windows.Forms.CheckBox
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbAdd As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbRemove As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbClone As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents PropsFlowLayoutPanel As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents bnPath As System.Windows.Forms.Button
    Friend WithEvents bnArguments As System.Windows.Forms.Button
    Friend WithEvents ToolStripDropDownButton1 As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents OptionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReplaceInPathToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripDropDownButton2 As ToolStripDropDownButton
    Friend WithEvents InstallToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UninstallToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MainTableLayoutPanel As TableLayoutPanel
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents OpenSettingsFolderToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripDropDownButton3 As ToolStripDropDownButton
    Friend WithEvents OpenWebsiteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OpenHelpToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As ToolStripMenuItem
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
        Me.lExt = New System.Windows.Forms.Label()
        Me.cbAllFiles = New System.Windows.Forms.CheckBox()
        Me.cbRunAsAdmin = New System.Windows.Forms.CheckBox()
        Me.lv = New System.Windows.Forms.ListView()
        Me.tbSearch = New System.Windows.Forms.TextBox()
        Me.tsMain = New System.Windows.Forms.ToolStrip()
        Me.tsbAdd = New System.Windows.Forms.ToolStripButton()
        Me.tsbRemove = New System.Windows.Forms.ToolStripButton()
        Me.tsbClone = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripDropDownButton1 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.ReplaceInPathToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenSettingsFolderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OptionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripDropDownButton2 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.InstallToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UninstallToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripDropDownButton3 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.OpenHelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenWebsiteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.bnPath = New System.Windows.Forms.Button()
        Me.bnArguments = New System.Windows.Forms.Button()
        Me.PropsFlowLayoutPanel = New System.Windows.Forms.FlowLayoutPanel()
        Me.MainTableLayoutPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
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
        Me.tbName.Location = New System.Drawing.Point(803, 90)
        Me.tbName.Margin = New System.Windows.Forms.Padding(3, 10, 0, 10)
        Me.tbName.Name = "tbName"
        Me.tbName.Size = New System.Drawing.Size(1188, 55)
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
        Me.tbPath.Location = New System.Drawing.Point(803, 240)
        Me.tbPath.Margin = New System.Windows.Forms.Padding(3, 10, 0, 10)
        Me.tbPath.Name = "tbPath"
        Me.tbPath.Size = New System.Drawing.Size(1188, 55)
        Me.tbPath.TabIndex = 0
        '
        'tbArguments
        '
        Me.tbArguments.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbArguments.HideSelection = False
        Me.tbArguments.Location = New System.Drawing.Point(803, 315)
        Me.tbArguments.Margin = New System.Windows.Forms.Padding(3, 10, 0, 10)
        Me.tbArguments.Name = "tbArguments"
        Me.tbArguments.Size = New System.Drawing.Size(1188, 55)
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
        Me.tbFileTypes.Location = New System.Drawing.Point(803, 165)
        Me.tbFileTypes.Margin = New System.Windows.Forms.Padding(3, 10, 0, 10)
        Me.tbFileTypes.Name = "tbFileTypes"
        Me.tbFileTypes.Size = New System.Drawing.Size(1188, 55)
        Me.tbFileTypes.TabIndex = 2
        '
        'lExt
        '
        Me.lExt.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lExt.AutoSize = True
        Me.lExt.Location = New System.Drawing.Point(595, 168)
        Me.lExt.Margin = New System.Windows.Forms.Padding(15, 0, 3, 0)
        Me.lExt.Name = "lExt"
        Me.lExt.Size = New System.Drawing.Size(182, 48)
        Me.lExt.TabIndex = 1
        Me.lExt.Text = "File Types:"
        '
        'cbAllFiles
        '
        Me.cbAllFiles.Location = New System.Drawing.Point(20, 152)
        Me.cbAllFiles.Margin = New System.Windows.Forms.Padding(20, 3, 3, 3)
        Me.cbAllFiles.Name = "cbAllFiles"
        Me.cbAllFiles.Size = New System.Drawing.Size(600, 60)
        Me.cbAllFiles.TabIndex = 3
        Me.cbAllFiles.Text = "Show for all file types"
        Me.cbAllFiles.UseVisualStyleBackColor = True
        '
        'cbRunAsAdmin
        '
        Me.cbRunAsAdmin.Location = New System.Drawing.Point(20, 218)
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
        Me.lv.Location = New System.Drawing.Point(15, 158)
        Me.lv.Margin = New System.Windows.Forms.Padding(15, 3, 3, 3)
        Me.lv.Name = "lv"
        Me.MainTableLayoutPanel.SetRowSpan(Me.lv, 4)
        Me.lv.Size = New System.Drawing.Size(562, 811)
        Me.lv.TabIndex = 1
        Me.lv.UseCompatibleStateImageBehavior = False
        '
        'tbSearch
        '
        Me.tbSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbSearch.Location = New System.Drawing.Point(0, 7)
        Me.tbSearch.Margin = New System.Windows.Forms.Padding(0)
        Me.tbSearch.Name = "tbSearch"
        Me.tbSearch.Size = New System.Drawing.Size(562, 55)
        Me.tbSearch.TabIndex = 0
        '
        'tsMain
        '
        Me.tsMain.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tsMain.AutoSize = False
        Me.MainTableLayoutPanel.SetColumnSpan(Me.tsMain, 4)
        Me.tsMain.Dock = System.Windows.Forms.DockStyle.None
        Me.tsMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.tsMain.ImageScalingSize = New System.Drawing.Size(48, 48)
        Me.tsMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbAdd, Me.tsbRemove, Me.tsbClone, Me.ToolStripDropDownButton1, Me.ToolStripDropDownButton2, Me.ToolStripDropDownButton3})
        Me.tsMain.Location = New System.Drawing.Point(0, 0)
        Me.tsMain.Name = "tsMain"
        Me.tsMain.Size = New System.Drawing.Size(2092, 80)
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
        'ToolStripDropDownButton1
        '
        Me.ToolStripDropDownButton1.AutoToolTip = False
        Me.ToolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripDropDownButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ReplaceInPathToolStripMenuItem, Me.OpenSettingsFolderToolStripMenuItem, Me.OptionsToolStripMenuItem})
        Me.ToolStripDropDownButton1.Image = CType(resources.GetObject("ToolStripDropDownButton1.Image"), System.Drawing.Image)
        Me.ToolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton1.Name = "ToolStripDropDownButton1"
        Me.ToolStripDropDownButton1.Size = New System.Drawing.Size(222, 77)
        Me.ToolStripDropDownButton1.Text = "     Tools    "
        '
        'ReplaceInPathToolStripMenuItem
        '
        Me.ReplaceInPathToolStripMenuItem.Name = "ReplaceInPathToolStripMenuItem"
        Me.ReplaceInPathToolStripMenuItem.Size = New System.Drawing.Size(600, 54)
        Me.ReplaceInPathToolStripMenuItem.Text = "Replace in path of all items..."
        '
        'OpenSettingsFolderToolStripMenuItem
        '
        Me.OpenSettingsFolderToolStripMenuItem.Name = "OpenSettingsFolderToolStripMenuItem"
        Me.OpenSettingsFolderToolStripMenuItem.Size = New System.Drawing.Size(600, 54)
        Me.OpenSettingsFolderToolStripMenuItem.Text = "Open settings folder..."
        '
        'OptionsToolStripMenuItem
        '
        Me.OptionsToolStripMenuItem.Name = "OptionsToolStripMenuItem"
        Me.OptionsToolStripMenuItem.Size = New System.Drawing.Size(600, 54)
        Me.OptionsToolStripMenuItem.Text = "Options..."
        '
        'ToolStripDropDownButton2
        '
        Me.ToolStripDropDownButton2.AutoToolTip = False
        Me.ToolStripDropDownButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripDropDownButton2.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.InstallToolStripMenuItem, Me.UninstallToolStripMenuItem})
        Me.ToolStripDropDownButton2.Image = CType(resources.GetObject("ToolStripDropDownButton2.Image"), System.Drawing.Image)
        Me.ToolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton2.Name = "ToolStripDropDownButton2"
        Me.ToolStripDropDownButton2.Size = New System.Drawing.Size(315, 77)
        Me.ToolStripDropDownButton2.Text = " Install/Uninstall "
        '
        'InstallToolStripMenuItem
        '
        Me.InstallToolStripMenuItem.Name = "InstallToolStripMenuItem"
        Me.InstallToolStripMenuItem.Size = New System.Drawing.Size(285, 54)
        Me.InstallToolStripMenuItem.Text = "Install"
        '
        'UninstallToolStripMenuItem
        '
        Me.UninstallToolStripMenuItem.Name = "UninstallToolStripMenuItem"
        Me.UninstallToolStripMenuItem.Size = New System.Drawing.Size(285, 54)
        Me.UninstallToolStripMenuItem.Text = "Uninstall"
        '
        'ToolStripDropDownButton3
        '
        Me.ToolStripDropDownButton3.AutoToolTip = False
        Me.ToolStripDropDownButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripDropDownButton3.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenHelpToolStripMenuItem, Me.OpenWebsiteToolStripMenuItem, Me.AboutToolStripMenuItem})
        Me.ToolStripDropDownButton3.Image = CType(resources.GetObject("ToolStripDropDownButton3.Image"), System.Drawing.Image)
        Me.ToolStripDropDownButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton3.Name = "ToolStripDropDownButton3"
        Me.ToolStripDropDownButton3.Size = New System.Drawing.Size(206, 77)
        Me.ToolStripDropDownButton3.Text = "    Help    "
        '
        'OpenHelpToolStripMenuItem
        '
        Me.OpenHelpToolStripMenuItem.Name = "OpenHelpToolStripMenuItem"
        Me.OpenHelpToolStripMenuItem.Size = New System.Drawing.Size(468, 54)
        Me.OpenHelpToolStripMenuItem.Text = "Open Help"
        '
        'OpenWebsiteToolStripMenuItem
        '
        Me.OpenWebsiteToolStripMenuItem.Name = "OpenWebsiteToolStripMenuItem"
        Me.OpenWebsiteToolStripMenuItem.Size = New System.Drawing.Size(468, 54)
        Me.OpenWebsiteToolStripMenuItem.Text = "Open Website"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(468, 54)
        Me.AboutToolStripMenuItem.Text = "About"
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(595, 243)
        Me.Label2.Margin = New System.Windows.Forms.Padding(15, 0, 3, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(97, 48)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Path:"
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(595, 93)
        Me.Label1.Margin = New System.Windows.Forms.Padding(15, 0, 3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(123, 48)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Name:"
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(595, 318)
        Me.Label3.Margin = New System.Windows.Forms.Padding(15, 0, 3, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(202, 48)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Arguments:"
        '
        'bnPath
        '
        Me.bnPath.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.bnPath.Location = New System.Drawing.Point(2006, 232)
        Me.bnPath.Margin = New System.Windows.Forms.Padding(15, 0, 15, 0)
        Me.bnPath.Name = "bnPath"
        Me.bnPath.Size = New System.Drawing.Size(70, 70)
        Me.bnPath.TabIndex = 7
        Me.bnPath.Text = "..."
        Me.bnPath.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.bnPath.UseVisualStyleBackColor = True
        '
        'bnArguments
        '
        Me.bnArguments.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.bnArguments.Location = New System.Drawing.Point(2006, 307)
        Me.bnArguments.Margin = New System.Windows.Forms.Padding(15, 0, 15, 0)
        Me.bnArguments.Name = "bnArguments"
        Me.bnArguments.Size = New System.Drawing.Size(70, 70)
        Me.bnArguments.TabIndex = 8
        Me.bnArguments.Text = "%"
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
        Me.PropsFlowLayoutPanel.Controls.Add(Me.cbAllFiles)
        Me.PropsFlowLayoutPanel.Controls.Add(Me.cbRunAsAdmin)
        Me.PropsFlowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.PropsFlowLayoutPanel.Location = New System.Drawing.Point(583, 383)
        Me.PropsFlowLayoutPanel.Name = "PropsFlowLayoutPanel"
        Me.PropsFlowLayoutPanel.Size = New System.Drawing.Size(1506, 586)
        Me.PropsFlowLayoutPanel.TabIndex = 16
        '
        'MainTableLayoutPanel
        '
        Me.MainTableLayoutPanel.ColumnCount = 4
        Me.MainTableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.78054!))
        Me.MainTableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.MainTableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 67.21946!))
        Me.MainTableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.MainTableLayoutPanel.Controls.Add(Me.FlowLayoutPanel1, 2, 6)
        Me.MainTableLayoutPanel.Controls.Add(Me.bnArguments, 3, 4)
        Me.MainTableLayoutPanel.Controls.Add(Me.PropsFlowLayoutPanel, 1, 5)
        Me.MainTableLayoutPanel.Controls.Add(Me.tbArguments, 2, 4)
        Me.MainTableLayoutPanel.Controls.Add(Me.lv, 0, 2)
        Me.MainTableLayoutPanel.Controls.Add(Me.Label2, 1, 3)
        Me.MainTableLayoutPanel.Controls.Add(Me.Label3, 1, 4)
        Me.MainTableLayoutPanel.Controls.Add(Me.tbPath, 2, 3)
        Me.MainTableLayoutPanel.Controls.Add(Me.bnPath, 3, 3)
        Me.MainTableLayoutPanel.Controls.Add(Me.tsMain, 0, 0)
        Me.MainTableLayoutPanel.Controls.Add(Me.Label1, 1, 1)
        Me.MainTableLayoutPanel.Controls.Add(Me.tbFileTypes, 2, 2)
        Me.MainTableLayoutPanel.Controls.Add(Me.tbName, 2, 1)
        Me.MainTableLayoutPanel.Controls.Add(Me.lExt, 1, 2)
        Me.MainTableLayoutPanel.Controls.Add(Me.TableLayoutPanel1, 0, 1)
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
        Me.MainTableLayoutPanel.Size = New System.Drawing.Size(2092, 1078)
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
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(1599, 975)
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
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(562, 69)
        Me.TableLayoutPanel1.TabIndex = 19
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(288.0!, 288.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(2092, 1078)
        Me.Controls.Add(Me.MainTableLayoutPanel)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
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

    Private SelectedItem As ItemAttribute
    Private TempItems As New List(Of ItemAttribute)
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

        tbSearch.SetCue("Search", False)

        Dim margin = tsbAdd.Margin
        margin.Left = CInt(FontHeight * 0.33)
        tsbAdd.Margin = margin
        g.LoadSettings()

        If g.Settings.Items.Count > 0 Then
            TempItems = CloneObject(Of List(Of ItemAttribute))(g.Settings.Items)

            For Each i In TempItems
                lv.Items.Add(i.Name).Tag = i
            Next
        End If

        SetColumnWidths()
        SelectFirst()
        Native.SetWindowTheme(lv.Handle, "explorer", Nothing)
        tbSearch.Focus()
    End Sub

    <STAThread()>
    Public Shared Sub Main()
        If Environment.GetCommandLineArgs.Length > 1 Then
            Dim args = Environment.GetCommandLineArgs.Skip(2)

            Select Case Environment.GetCommandLineArgs(1)
                Case "-CopyPaths"
                    Clipboard.SetText(String.Join(BR, args.ToArray))
                Case Else
                    MsgError("A unknown command line switch was used.")
            End Select
        Else
            Application.SetCompatibleTextRenderingDefault(False)
            Application.Run(New MainForm)
        End If
    End Sub

    Shared Sub ApplicationThreadException(sender As Object, e As ThreadExceptionEventArgs)
        MsgError(e.Exception.Message)
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

    Public Shared Function CloneObject(Of T)(ByVal o As Object) As T
        Using ms As New MemoryStream
            Dim bf As New BinaryFormatter
            bf.Serialize(ms, o)
            ms.Position = 0
            Return DirectCast(bf.Deserialize(ms), T)
        End Using
    End Function

    Sub tbName_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles tbName.TextChanged
        If tbName.Focused AndAlso Not SelectedItem Is Nothing Then
            SelectedItem.Name = tbName.Text
            lv.SelectedItems(0).Text = tbName.Text
        End If
    End Sub

    Sub tbExt_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles tbFileTypes.TextChanged
        If tbFileTypes.Focused AndAlso Not SelectedItem Is Nothing Then
            Dim value = tbFileTypes.Text.ToLower
            If value.Contains(",") Then value = value.Replace(",", " ")
            If value.Contains(";") Then value = value.Replace(";", " ")

            While value.Contains("  ")
                If value.Contains("  ") Then value = value.Replace("  ", " ")
            End While

            SelectedItem.FileTypesDisplay = value.Trim
        End If
    End Sub

    Function SolveMacros(ByVal value As String) As String
        For Each i In g.Settings.Macros
            If value.Contains(i.Name) Then
                value = value.Replace(i.Name, i.Value)
            End If
        Next

        Return value
    End Function

    Sub cbSubmenu_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbSubmenu.CheckedChanged
        If cbSubmenu.Focused AndAlso Not SelectedItem Is Nothing Then
            SelectedItem.SubMenu = cbSubmenu.Checked
        End If
    End Sub

    Sub cbRunAsAdmin_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbRunAsAdmin.CheckedChanged
        If cbRunAsAdmin.Focused AndAlso Not SelectedItem Is Nothing Then
            SelectedItem.RunAsAdmin = cbRunAsAdmin.Checked
        End If
    End Sub

    Sub tbPath_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles tbPath.TextChanged
        If tbPath.Focused AndAlso Not SelectedItem Is Nothing Then
            SelectedItem.Path = tbPath.Text
        End If
    End Sub

    Sub tbArgs_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles tbArguments.TextChanged
        If tbArguments.Focused AndAlso Not SelectedItem Is Nothing Then
            SelectedItem.Arguments = tbArguments.Text
        End If
    End Sub

    Sub cbDirectories_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbDirectories.CheckedChanged
        If cbDirectories.Focused AndAlso Not SelectedItem Is Nothing Then
            SelectedItem.Directories = cbDirectories.Checked
        End If
    End Sub

    Private Sub tbPath_DoubleClick() Handles tbPath.DoubleClick
        Using f As New SearchForm
            If f.ShowDialog() = DialogResult.OK Then
                Dim item = DirectCast(f.lv.SelectedItems(0).Tag, ItemAttribute)

                tbPath.Focus()
                tbPath.Text = item.Path

                If tbName.Text = "" Then
                    tbName.Focus()
                    tbName.Text = item.Name
                End If
            End If
        End Using
    End Sub

    Sub AddItem(ByVal item As ItemAttribute)
        Dim lvi = lv.Items.Add(item.Name)
        lvi.Tag = item
        lvi.Selected = True
        lvi.EnsureVisible()
        TempItems.Add(item)
        UpdateControls()
    End Sub

    Private Sub lv_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles lv.KeyUp
        If e.KeyData = Keys.Delete AndAlso tsbRemove.Enabled Then
            tsbRemove.PerformClick()
        End If

        UpdateControls()
    End Sub

    Private Sub lv_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles lv.MouseUp
        UpdateControls()
    End Sub

    Sub UpdateControls()
        If lv.SelectedItems.Count > 0 Then
            SelectedItem = DirectCast(lv.SelectedItems(0).Tag, ItemAttribute)
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

            tbName.Text = SelectedItem.Name

            If SelectedItem.FileTypesDisplay = "" Then
                tbFileTypes.Text = SelectedItem.FileTypes
            Else
                tbFileTypes.Text = SelectedItem.FileTypesDisplay
            End If

            tbPath.Text = SelectedItem.Path
            tbArguments.Text = SelectedItem.Arguments

            cbAllFiles.Checked = SelectedItem.AllFiles
            cbSubmenu.Checked = SelectedItem.SubMenu
            cbDirectories.Checked = SelectedItem.Directories
            cbRunAsAdmin.Checked = SelectedItem.RunAsAdmin
        Else
            PropsFlowLayoutPanel.Enabled = False
            tbArguments.Enabled = False
            tbFileTypes.Enabled = False
            tbName.Enabled = False
            tbPath.Enabled = False
            bnArguments.Enabled = False
            bnPath.Enabled = False

            tbName.Text = ""
            tbFileTypes.Text = ""
            tbPath.Text = ""
            tbArguments.Text = ""

            cbAllFiles.Checked = False
            cbDirectories.Checked = False
            cbSubmenu.Checked = False
            cbRunAsAdmin.Checked = False
        End If

        tsbRemove.Enabled = Not SelectedItem Is Nothing
        tsbClone.Enabled = Not SelectedItem Is Nothing
    End Sub

    Private Sub tbSearch_Enter(ByVal sender As Object, ByVal e As EventArgs) Handles tbSearch.Enter
        For Each i In TempItems
            i.UpdateSearchValue()
        Next
    End Sub

    Private Sub tbSearch_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles tbSearch.KeyDown
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

    Private Sub tbSearch_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles tbSearch.TextChanged
        lv.BeginUpdate()
        lv.Items.Clear()

        Dim query = tbSearch.Text.ToLower

        For Each i In TempItems
            If tbSearch.Text = "" OrElse i.SearchValue.Contains(query) Then
                lv.Items.Add(i.Name).Tag = i
            End If
        Next

        SelectFirst()
        SetColumnWidths()
        lv.EndUpdate()
    End Sub

    Private Sub cbAllFiles_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbAllFiles.CheckedChanged
        If cbAllFiles.Focused AndAlso Not SelectedItem Is Nothing Then
            SelectedItem.AllFiles = cbAllFiles.Checked
        End If

        tbFileTypes.Enabled = Not cbAllFiles.Checked
    End Sub

    Private Sub bnOK_Click(ByVal sender As Object, ByVal e As EventArgs) Handles bnOK.Click
        g.Settings.Items = TempItems
        g.Settings.Items.Sort()

        For Each i In g.Settings.Items
            If Not i.FileTypesDisplay Is Nothing Then
                i.FileTypes = SolveMacros(i.FileTypesDisplay)
            End If
        Next

        g.SaveSettings()
        Reg()
        Close()
    End Sub

    Sub Reg()
        RegistryHelp.Write(Registry.CurrentUser, "Software\OpenWithPP", "Reload", 1)
        RegistryHelp.Write(Registry.CurrentUser, "Software\OpenWithPP", "SettingsLocation", g.SettingsDir + "Settings.xml")
        RegistryHelp.Write(Registry.CurrentUser, "Software\OpenWithPP", "ExeLocation", Application.ExecutablePath)
        RegistryHelp.Write(Registry.CurrentUser, "Software\OpenWithPP", "ExeDir", Application.StartupPath + "\")
    End Sub

    Private Sub bnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles bnCancel.Click
        Close()
    End Sub

    Private Sub miOpenFolder_Click(ByVal sender As Object, ByVal e As EventArgs)
        Process.Start(Path.GetDirectoryName(tbPath.Text))
    End Sub

    Private Sub tsbAdd_Click(ByVal sender As Object, ByVal e As EventArgs) Handles tsbAdd.Click
        AddItem(New ItemAttribute With {.Arguments = "%paths%"})
        tbSearch.Text = ""
    End Sub

    Private Sub tsbRemove_Click(ByVal sender As Object, ByVal e As EventArgs) Handles tsbRemove.Click
        Dim i = lv.SelectedIndices(0)
        TempItems.Remove(SelectedItem)
        lv.SelectedItems(0).Remove()
        If i > lv.Items.Count - 1 Then i = i - 1
        If i >= 0 Then lv.Items(i).Selected = True
        UpdateControls()
    End Sub

    Private Sub tsbClone_Click(ByVal sender As Object, ByVal e As EventArgs) Handles tsbClone.Click
        AddItem(CloneObject(Of ItemAttribute)(SelectedItem))
    End Sub

    Private Sub bnArguments_Click(ByVal sender As Object, ByVal e As EventArgs) Handles bnArguments.Click
        tbArguments.Focus()

        If tbArguments.Text = "" Then
            tbArguments.Text = "%paths%"
        Else
            tbArguments.Text += " %paths%"
        End If
    End Sub

    Private Sub bnPath_Click(ByVal sender As Object, ByVal e As EventArgs) Handles bnPath.Click
        tbPath_DoubleClick()
    End Sub

    Private Sub OptionsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles OptionsToolStripMenuItem.Click
        Using f As New OptionsForm
            If f.ShowDialog = DialogResult.OK Then
                g.Settings.Macros.Clear()
                Dim a = f.tbMacros.Text.Split({BR}, StringSplitOptions.RemoveEmptyEntries)

                For Each i In a
                    If i <> "" AndAlso i.Contains("=") Then
                        Dim a2 = i.Split("="c)

                        If a2.Length > 1 AndAlso a2(0) <> "" AndAlso a2(1) <> "" Then
                            g.Settings.Macros.Add(New Macro() With {.Name = a2(0).Trim, .Value = a2(1).Trim})
                        End If
                    End If
                Next
            End If
        End Using
    End Sub

    Private Sub ReplaceInPathToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReplaceInPathToolStripMenuItem.Click
        Using f As New ReplaceForm
            If f.ShowDialog = DialogResult.OK Then
                If f.tbSearch.Text <> "" Then
                    For Each i In TempItems
                        If i.Path.Contains(f.tbSearch.Text) Then
                            If Msg("Replace following item?" + BR2 + i.Name + BR2 + i.Path, Application.ProductName, MessageBoxIcon.Question, MessageBoxButtons.OKCancel) = DialogResult.OK Then
                                i.Path = i.Path.Replace(f.tbSearch.Text, f.tbReplace.Text)
                            End If
                        End If
                    Next
                End If

                UpdateControls()
            End If
        End Using
    End Sub

    Private Sub InstallToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InstallToolStripMenuItem.Click
        Dim p As New Process
        p.StartInfo.Verb = "runas"
        p.StartInfo.FileName = "regsvr32.exe"
        p.StartInfo.Arguments = """" + DLLPath + """"
        p.Start()
        Reg()
    End Sub

    Private Sub UninstallToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UninstallToolStripMenuItem.Click
        Dim p As New Process
        p.StartInfo.Verb = "runas"
        p.StartInfo.FileName = "C:\Windows\System32\regsvr32.exe"
        p.StartInfo.Arguments = "/u """ + DLLPath + """"
        p.Start()
    End Sub

    Private Sub MainForm_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        tbSearch.Focus()
        tbArguments.HideSelection = True
    End Sub

    Private Sub OpenSettingsFolderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenSettingsFolderToolStripMenuItem.Click
        Process.Start(g.SettingsDir)
    End Sub

    Private Sub OpenWebsiteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenWebsiteToolStripMenuItem.Click
        Process.Start("https://github.com/stax76/OpenWithPlusPlus")
    End Sub

    Private Sub OpenHelpToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenHelpToolStripMenuItem.Click
        Process.Start(GetAssociatedApplication(".txt"), Application.StartupPath + "\readme.md")
    End Sub

    Function GetAssociatedApplication(ext As String) As String
        Dim c = 0UI

        'ASSOCF_VERIFY, ASSOCSTR_EXECUTABLE
        If 1 = AssocQueryString(&H40, 2, ext, Nothing, Nothing, c) Then
            If c > 0 Then
                Dim sb As New StringBuilder(CInt(c))

                'ASSOCF_VERIFY, ASSOCSTR_EXECUTABLE
                If 0 = AssocQueryString(&H40, 2, ext, Nothing, sb, c) Then
                    Dim ret = sb.ToString
                    If File.Exists(ret) Then Return ret
                End If
            End If
        End If
    End Function

    <DllImport("Shlwapi.dll", SetLastError:=True, CharSet:=CharSet.Unicode)>
    Shared Function AssocQueryString(
        flags As UInteger,
        str As UInteger,
        pszAssoc As String,
        pszExtra As String,
        pszOut As StringBuilder,
        ByRef pcchOut As UInteger) As UInteger
    End Function

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        MsgInfo(Application.ProductName + " " + Application.ProductVersion.ToString + BR2 + "Copyright © Frank Skare" + BR2 + "MIT License")
    End Sub
End Class