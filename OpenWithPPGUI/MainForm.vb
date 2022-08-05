
Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Text.RegularExpressions
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
    Friend WithEvents laName As System.Windows.Forms.Label
    Friend WithEvents laPath As System.Windows.Forms.Label
    Friend WithEvents laArgs As System.Windows.Forms.Label
    Friend WithEvents PropsFlowLayoutPanel As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents bnPath As System.Windows.Forms.Button
    Friend WithEvents bnArguments As System.Windows.Forms.Button
    Friend WithEvents tlpMain As TableLayoutPanel
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents tlpSearch As TableLayoutPanel
    Friend WithEvents bnFileTypes As Button
    Friend WithEvents cbHideWindow As CheckBox
    Friend WithEvents tbWorkingDirectory As TextBox
    Friend WithEvents bnWorkingDirectory As Button
    Friend WithEvents laWorkingDirectory As Label
    Friend WithEvents bnIcon As Button
    Friend WithEvents tbIcon As TextBox
    Friend WithEvents laIcon As Label
    Friend WithEvents cbHidden As CheckBox
    Friend WithEvents tlpListView As TableLayoutPanel
    Friend WithEvents bnClone As Button
    Friend WithEvents bnRemove As Button
    Friend WithEvents llInstallUninstall As LinkLabel
    Friend WithEvents llOptions As LinkLabel
    Friend WithEvents llWebsite As LinkLabel
    Friend WithEvents llExport As LinkLabel
    Friend WithEvents laFilter As Label
    Friend WithEvents tbFilter As TextBox
    Friend WithEvents llAbout As LinkLabel
    Friend WithEvents bnAdd As Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
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
        Me.laPath = New System.Windows.Forms.Label()
        Me.laName = New System.Windows.Forms.Label()
        Me.laArgs = New System.Windows.Forms.Label()
        Me.bnPath = New System.Windows.Forms.Button()
        Me.bnArguments = New System.Windows.Forms.Button()
        Me.PropsFlowLayoutPanel = New System.Windows.Forms.FlowLayoutPanel()
        Me.cbHidden = New System.Windows.Forms.CheckBox()
        Me.cbHideWindow = New System.Windows.Forms.CheckBox()
        Me.tlpMain = New System.Windows.Forms.TableLayoutPanel()
        Me.laFilter = New System.Windows.Forms.Label()
        Me.tbFilter = New System.Windows.Forms.TextBox()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.llInstallUninstall = New System.Windows.Forms.LinkLabel()
        Me.llOptions = New System.Windows.Forms.LinkLabel()
        Me.llWebsite = New System.Windows.Forms.LinkLabel()
        Me.llExport = New System.Windows.Forms.LinkLabel()
        Me.llAbout = New System.Windows.Forms.LinkLabel()
        Me.tlpSearch = New System.Windows.Forms.TableLayoutPanel()
        Me.bnFileTypes = New System.Windows.Forms.Button()
        Me.bnWorkingDirectory = New System.Windows.Forms.Button()
        Me.tbWorkingDirectory = New System.Windows.Forms.TextBox()
        Me.laWorkingDirectory = New System.Windows.Forms.Label()
        Me.tlpListView = New System.Windows.Forms.TableLayoutPanel()
        Me.bnClone = New System.Windows.Forms.Button()
        Me.bnRemove = New System.Windows.Forms.Button()
        Me.bnAdd = New System.Windows.Forms.Button()
        Me.bnIcon = New System.Windows.Forms.Button()
        Me.tbIcon = New System.Windows.Forms.TextBox()
        Me.laIcon = New System.Windows.Forms.Label()
        Me.PropsFlowLayoutPanel.SuspendLayout()
        Me.tlpMain.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.tlpSearch.SuspendLayout()
        Me.tlpListView.SuspendLayout()
        Me.SuspendLayout()
        '
        'tbName
        '
        Me.tbName.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbName.BackColor = System.Drawing.Color.WhiteSmoke
        Me.tbName.Location = New System.Drawing.Point(849, 16)
        Me.tbName.Margin = New System.Windows.Forms.Padding(3, 10, 0, 10)
        Me.tbName.Name = "tbName"
        Me.tbName.Size = New System.Drawing.Size(1135, 55)
        Me.tbName.TabIndex = 1
        '
        'bnCancel
        '
        Me.bnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bnCancel.BackColor = System.Drawing.Color.WhiteSmoke
        Me.bnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.bnCancel.Location = New System.Drawing.Point(1274, 18)
        Me.bnCancel.Margin = New System.Windows.Forms.Padding(18)
        Me.bnCancel.Name = "bnCancel"
        Me.bnCancel.Size = New System.Drawing.Size(200, 75)
        Me.bnCancel.TabIndex = 5
        Me.bnCancel.Text = "&Cancel"
        Me.bnCancel.UseVisualStyleBackColor = False
        '
        'bnOK
        '
        Me.bnOK.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.bnOK.BackColor = System.Drawing.Color.WhiteSmoke
        Me.bnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.bnOK.Location = New System.Drawing.Point(1056, 18)
        Me.bnOK.Margin = New System.Windows.Forms.Padding(160, 0, 0, 0)
        Me.bnOK.Name = "bnOK"
        Me.bnOK.Size = New System.Drawing.Size(200, 75)
        Me.bnOK.TabIndex = 4
        Me.bnOK.Text = "&OK"
        Me.bnOK.UseVisualStyleBackColor = False
        '
        'tbPath
        '
        Me.tbPath.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbPath.BackColor = System.Drawing.Color.WhiteSmoke
        Me.tbPath.Location = New System.Drawing.Point(849, 200)
        Me.tbPath.Margin = New System.Windows.Forms.Padding(3, 10, 0, 10)
        Me.tbPath.Name = "tbPath"
        Me.tbPath.Size = New System.Drawing.Size(1135, 55)
        Me.tbPath.TabIndex = 4
        '
        'tbArguments
        '
        Me.tbArguments.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbArguments.BackColor = System.Drawing.Color.WhiteSmoke
        Me.tbArguments.HideSelection = False
        Me.tbArguments.Location = New System.Drawing.Point(849, 284)
        Me.tbArguments.Margin = New System.Windows.Forms.Padding(3, 10, 0, 10)
        Me.tbArguments.Multiline = True
        Me.tbArguments.Name = "tbArguments"
        Me.tbArguments.Size = New System.Drawing.Size(1135, 170)
        Me.tbArguments.TabIndex = 6
        '
        'cbDirectories
        '
        Me.cbDirectories.Location = New System.Drawing.Point(25, 86)
        Me.cbDirectories.Margin = New System.Windows.Forms.Padding(25, 3, 3, 3)
        Me.cbDirectories.Name = "cbDirectories"
        Me.cbDirectories.Size = New System.Drawing.Size(600, 60)
        Me.cbDirectories.TabIndex = 1
        Me.cbDirectories.Text = "Show for directories"
        '
        'cbSubmenu
        '
        Me.cbSubmenu.Location = New System.Drawing.Point(25, 20)
        Me.cbSubmenu.Margin = New System.Windows.Forms.Padding(25, 20, 3, 3)
        Me.cbSubmenu.Name = "cbSubmenu"
        Me.cbSubmenu.Size = New System.Drawing.Size(600, 60)
        Me.cbSubmenu.TabIndex = 0
        Me.cbSubmenu.Text = "Show in sub menu"
        '
        'tbFileTypes
        '
        Me.tbFileTypes.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbFileTypes.BackColor = System.Drawing.Color.WhiteSmoke
        Me.tbFileTypes.Location = New System.Drawing.Point(849, 107)
        Me.tbFileTypes.Margin = New System.Windows.Forms.Padding(3, 10, 0, 10)
        Me.tbFileTypes.Name = "tbFileTypes"
        Me.tbFileTypes.Size = New System.Drawing.Size(1135, 55)
        Me.tbFileTypes.TabIndex = 2
        '
        'laExt
        '
        Me.laExt.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.laExt.AutoSize = True
        Me.laExt.Location = New System.Drawing.Point(631, 110)
        Me.laExt.Margin = New System.Windows.Forms.Padding(18, 0, 0, 0)
        Me.laExt.Name = "laExt"
        Me.laExt.Size = New System.Drawing.Size(182, 48)
        Me.laExt.TabIndex = 1
        Me.laExt.Text = "File Types:"
        '
        'cbRunAsAdmin
        '
        Me.cbRunAsAdmin.Location = New System.Drawing.Point(25, 218)
        Me.cbRunAsAdmin.Margin = New System.Windows.Forms.Padding(25, 3, 3, 3)
        Me.cbRunAsAdmin.Name = "cbRunAsAdmin"
        Me.cbRunAsAdmin.Size = New System.Drawing.Size(600, 60)
        Me.cbRunAsAdmin.TabIndex = 3
        Me.cbRunAsAdmin.Text = "Run as admin"
        Me.cbRunAsAdmin.UseVisualStyleBackColor = True
        '
        'lv
        '
        Me.lv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lv.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lv.HideSelection = False
        Me.lv.Location = New System.Drawing.Point(18, 88)
        Me.lv.Margin = New System.Windows.Forms.Padding(18, 0, 0, 0)
        Me.lv.Name = "lv"
        Me.tlpMain.SetRowSpan(Me.lv, 7)
        Me.lv.Size = New System.Drawing.Size(595, 1043)
        Me.lv.TabIndex = 0
        Me.lv.UseCompatibleStateImageBehavior = False
        '
        'tbSearch
        '
        Me.tbSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbSearch.BackColor = System.Drawing.Color.WhiteSmoke
        Me.tbSearch.Location = New System.Drawing.Point(0, 16)
        Me.tbSearch.Margin = New System.Windows.Forms.Padding(0)
        Me.tbSearch.Name = "tbSearch"
        Me.tbSearch.Size = New System.Drawing.Size(595, 55)
        Me.tbSearch.TabIndex = 0
        '
        'laPath
        '
        Me.laPath.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.laPath.AutoSize = True
        Me.laPath.Location = New System.Drawing.Point(631, 203)
        Me.laPath.Margin = New System.Windows.Forms.Padding(18, 0, 0, 0)
        Me.laPath.Name = "laPath"
        Me.laPath.Size = New System.Drawing.Size(97, 48)
        Me.laPath.TabIndex = 4
        Me.laPath.Text = "Path:"
        '
        'laName
        '
        Me.laName.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.laName.AutoSize = True
        Me.laName.Location = New System.Drawing.Point(631, 20)
        Me.laName.Margin = New System.Windows.Forms.Padding(18, 20, 0, 20)
        Me.laName.Name = "laName"
        Me.laName.Size = New System.Drawing.Size(123, 48)
        Me.laName.TabIndex = 0
        Me.laName.Text = "Name:"
        '
        'laArgs
        '
        Me.laArgs.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.laArgs.AutoSize = True
        Me.laArgs.Location = New System.Drawing.Point(631, 345)
        Me.laArgs.Margin = New System.Windows.Forms.Padding(18, 0, 0, 0)
        Me.laArgs.Name = "laArgs"
        Me.laArgs.Size = New System.Drawing.Size(202, 48)
        Me.laArgs.TabIndex = 5
        Me.laArgs.Text = "Arguments:"
        '
        'bnPath
        '
        Me.bnPath.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.bnPath.BackColor = System.Drawing.Color.WhiteSmoke
        Me.bnPath.Location = New System.Drawing.Point(2002, 190)
        Me.bnPath.Margin = New System.Windows.Forms.Padding(18, 9, 18, 9)
        Me.bnPath.Name = "bnPath"
        Me.bnPath.Size = New System.Drawing.Size(200, 75)
        Me.bnPath.TabIndex = 5
        Me.bnPath.Text = "Browse..."
        Me.bnPath.UseVisualStyleBackColor = False
        '
        'bnArguments
        '
        Me.bnArguments.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.bnArguments.BackColor = System.Drawing.Color.WhiteSmoke
        Me.bnArguments.Location = New System.Drawing.Point(2002, 331)
        Me.bnArguments.Margin = New System.Windows.Forms.Padding(18, 9, 18, 9)
        Me.bnArguments.Name = "bnArguments"
        Me.bnArguments.Size = New System.Drawing.Size(200, 75)
        Me.bnArguments.TabIndex = 7
        Me.bnArguments.Text = "%paths%"
        Me.bnArguments.UseVisualStyleBackColor = False
        '
        'PropsFlowLayoutPanel
        '
        Me.PropsFlowLayoutPanel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tlpMain.SetColumnSpan(Me.PropsFlowLayoutPanel, 3)
        Me.PropsFlowLayoutPanel.Controls.Add(Me.cbSubmenu)
        Me.PropsFlowLayoutPanel.Controls.Add(Me.cbDirectories)
        Me.PropsFlowLayoutPanel.Controls.Add(Me.cbHidden)
        Me.PropsFlowLayoutPanel.Controls.Add(Me.cbRunAsAdmin)
        Me.PropsFlowLayoutPanel.Controls.Add(Me.cbHideWindow)
        Me.PropsFlowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.PropsFlowLayoutPanel.Location = New System.Drawing.Point(613, 741)
        Me.PropsFlowLayoutPanel.Margin = New System.Windows.Forms.Padding(0)
        Me.PropsFlowLayoutPanel.Name = "PropsFlowLayoutPanel"
        Me.PropsFlowLayoutPanel.Size = New System.Drawing.Size(1608, 390)
        Me.PropsFlowLayoutPanel.TabIndex = 16
        '
        'cbHidden
        '
        Me.cbHidden.Location = New System.Drawing.Point(25, 152)
        Me.cbHidden.Margin = New System.Windows.Forms.Padding(25, 3, 3, 3)
        Me.cbHidden.Name = "cbHidden"
        Me.cbHidden.Size = New System.Drawing.Size(600, 60)
        Me.cbHidden.TabIndex = 2
        Me.cbHidden.Text = "Show only if Ctrl key is pressed"
        Me.cbHidden.UseVisualStyleBackColor = True
        '
        'cbHideWindow
        '
        Me.cbHideWindow.Location = New System.Drawing.Point(25, 284)
        Me.cbHideWindow.Margin = New System.Windows.Forms.Padding(25, 3, 3, 3)
        Me.cbHideWindow.Name = "cbHideWindow"
        Me.cbHideWindow.Size = New System.Drawing.Size(600, 60)
        Me.cbHideWindow.TabIndex = 4
        Me.cbHideWindow.Text = "Run hidden"
        Me.cbHideWindow.UseVisualStyleBackColor = True
        '
        'tlpMain
        '
        Me.tlpMain.BackColor = System.Drawing.Color.Gainsboro
        Me.tlpMain.ColumnCount = 4
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.0!))
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65.0!))
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpMain.Controls.Add(Me.laFilter, 0, 7)
        Me.tlpMain.Controls.Add(Me.tbFilter, 2, 7)
        Me.tlpMain.Controls.Add(Me.FlowLayoutPanel1, 1, 9)
        Me.tlpMain.Controls.Add(Me.PropsFlowLayoutPanel, 1, 8)
        Me.tlpMain.Controls.Add(Me.lv, 0, 2)
        Me.tlpMain.Controls.Add(Me.laPath, 1, 3)
        Me.tlpMain.Controls.Add(Me.tbPath, 2, 3)
        Me.tlpMain.Controls.Add(Me.laName, 1, 1)
        Me.tlpMain.Controls.Add(Me.tbFileTypes, 2, 2)
        Me.tlpMain.Controls.Add(Me.tbName, 2, 1)
        Me.tlpMain.Controls.Add(Me.laExt, 1, 2)
        Me.tlpMain.Controls.Add(Me.tlpSearch, 0, 1)
        Me.tlpMain.Controls.Add(Me.bnPath, 3, 3)
        Me.tlpMain.Controls.Add(Me.bnFileTypes, 3, 2)
        Me.tlpMain.Controls.Add(Me.bnArguments, 3, 4)
        Me.tlpMain.Controls.Add(Me.tbArguments, 2, 4)
        Me.tlpMain.Controls.Add(Me.laArgs, 1, 4)
        Me.tlpMain.Controls.Add(Me.bnWorkingDirectory, 3, 5)
        Me.tlpMain.Controls.Add(Me.tbWorkingDirectory, 2, 5)
        Me.tlpMain.Controls.Add(Me.laWorkingDirectory, 1, 5)
        Me.tlpMain.Controls.Add(Me.tlpListView, 0, 9)
        Me.tlpMain.Controls.Add(Me.bnIcon, 3, 6)
        Me.tlpMain.Controls.Add(Me.tbIcon, 2, 6)
        Me.tlpMain.Controls.Add(Me.laIcon, 1, 6)
        Me.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpMain.Location = New System.Drawing.Point(0, 0)
        Me.tlpMain.Name = "tlpMain"
        Me.tlpMain.RowCount = 10
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpMain.Size = New System.Drawing.Size(2221, 1242)
        Me.tlpMain.TabIndex = 17
        '
        'laFilter
        '
        Me.laFilter.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.laFilter.AutoSize = True
        Me.laFilter.Location = New System.Drawing.Point(631, 673)
        Me.laFilter.Margin = New System.Windows.Forms.Padding(18, 20, 0, 20)
        Me.laFilter.Name = "laFilter"
        Me.laFilter.Size = New System.Drawing.Size(215, 48)
        Me.laFilter.TabIndex = 29
        Me.laFilter.Text = "Regex Filter:"
        '
        'tbFilter
        '
        Me.tbFilter.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbFilter.BackColor = System.Drawing.Color.WhiteSmoke
        Me.tbFilter.Location = New System.Drawing.Point(849, 669)
        Me.tbFilter.Margin = New System.Windows.Forms.Padding(3, 10, 0, 10)
        Me.tbFilter.Name = "tbFilter"
        Me.tbFilter.Size = New System.Drawing.Size(1135, 55)
        Me.tbFilter.TabIndex = 12
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.FlowLayoutPanel1.AutoSize = True
        Me.FlowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpMain.SetColumnSpan(Me.FlowLayoutPanel1, 3)
        Me.FlowLayoutPanel1.Controls.Add(Me.llInstallUninstall)
        Me.FlowLayoutPanel1.Controls.Add(Me.llOptions)
        Me.FlowLayoutPanel1.Controls.Add(Me.llWebsite)
        Me.FlowLayoutPanel1.Controls.Add(Me.llExport)
        Me.FlowLayoutPanel1.Controls.Add(Me.llAbout)
        Me.FlowLayoutPanel1.Controls.Add(Me.bnOK)
        Me.FlowLayoutPanel1.Controls.Add(Me.bnCancel)
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(729, 1131)
        Me.FlowLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(1492, 111)
        Me.FlowLayoutPanel1.TabIndex = 18
        '
        'llInstallUninstall
        '
        Me.llInstallUninstall.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.llInstallUninstall.AutoSize = True
        Me.llInstallUninstall.LinkColor = System.Drawing.Color.DimGray
        Me.llInstallUninstall.Location = New System.Drawing.Point(10, 31)
        Me.llInstallUninstall.Margin = New System.Windows.Forms.Padding(10)
        Me.llInstallUninstall.Name = "llInstallUninstall"
        Me.llInstallUninstall.Size = New System.Drawing.Size(264, 48)
        Me.llInstallUninstall.TabIndex = 0
        Me.llInstallUninstall.TabStop = True
        Me.llInstallUninstall.Text = "Install/Uninstall"
        '
        'llOptions
        '
        Me.llOptions.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.llOptions.AutoSize = True
        Me.llOptions.LinkColor = System.Drawing.Color.DimGray
        Me.llOptions.Location = New System.Drawing.Point(294, 31)
        Me.llOptions.Margin = New System.Windows.Forms.Padding(10)
        Me.llOptions.Name = "llOptions"
        Me.llOptions.Size = New System.Drawing.Size(145, 48)
        Me.llOptions.TabIndex = 1
        Me.llOptions.TabStop = True
        Me.llOptions.Text = "Options"
        '
        'llWebsite
        '
        Me.llWebsite.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.llWebsite.AutoSize = True
        Me.llWebsite.LinkColor = System.Drawing.Color.DimGray
        Me.llWebsite.Location = New System.Drawing.Point(459, 31)
        Me.llWebsite.Margin = New System.Windows.Forms.Padding(10)
        Me.llWebsite.Name = "llWebsite"
        Me.llWebsite.Size = New System.Drawing.Size(148, 48)
        Me.llWebsite.TabIndex = 2
        Me.llWebsite.TabStop = True
        Me.llWebsite.Text = "Website"
        '
        'llExport
        '
        Me.llExport.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.llExport.AutoSize = True
        Me.llExport.LinkColor = System.Drawing.Color.DimGray
        Me.llExport.Location = New System.Drawing.Point(627, 31)
        Me.llExport.Margin = New System.Windows.Forms.Padding(10)
        Me.llExport.Name = "llExport"
        Me.llExport.Size = New System.Drawing.Size(122, 48)
        Me.llExport.TabIndex = 3
        Me.llExport.TabStop = True
        Me.llExport.Text = "Export"
        '
        'llAbout
        '
        Me.llAbout.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.llAbout.AutoSize = True
        Me.llAbout.LinkColor = System.Drawing.Color.DimGray
        Me.llAbout.Location = New System.Drawing.Point(769, 31)
        Me.llAbout.Margin = New System.Windows.Forms.Padding(10)
        Me.llAbout.Name = "llAbout"
        Me.llAbout.Size = New System.Drawing.Size(117, 48)
        Me.llAbout.TabIndex = 6
        Me.llAbout.TabStop = True
        Me.llAbout.Text = "About"
        '
        'tlpSearch
        '
        Me.tlpSearch.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tlpSearch.ColumnCount = 1
        Me.tlpSearch.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpSearch.Controls.Add(Me.tbSearch, 0, 0)
        Me.tlpSearch.Location = New System.Drawing.Point(18, 0)
        Me.tlpSearch.Margin = New System.Windows.Forms.Padding(18, 0, 0, 0)
        Me.tlpSearch.Name = "tlpSearch"
        Me.tlpSearch.RowCount = 1
        Me.tlpSearch.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpSearch.Size = New System.Drawing.Size(595, 88)
        Me.tlpSearch.TabIndex = 19
        '
        'bnFileTypes
        '
        Me.bnFileTypes.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.bnFileTypes.BackColor = System.Drawing.Color.WhiteSmoke
        Me.bnFileTypes.Location = New System.Drawing.Point(2002, 97)
        Me.bnFileTypes.Margin = New System.Windows.Forms.Padding(18, 9, 18, 9)
        Me.bnFileTypes.Name = "bnFileTypes"
        Me.bnFileTypes.Size = New System.Drawing.Size(200, 75)
        Me.bnFileTypes.TabIndex = 3
        Me.bnFileTypes.Text = "All Files"
        Me.bnFileTypes.UseVisualStyleBackColor = False
        '
        'bnWorkingDirectory
        '
        Me.bnWorkingDirectory.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.bnWorkingDirectory.BackColor = System.Drawing.Color.WhiteSmoke
        Me.bnWorkingDirectory.Location = New System.Drawing.Point(2002, 474)
        Me.bnWorkingDirectory.Margin = New System.Windows.Forms.Padding(18, 9, 18, 9)
        Me.bnWorkingDirectory.Name = "bnWorkingDirectory"
        Me.bnWorkingDirectory.Size = New System.Drawing.Size(200, 75)
        Me.bnWorkingDirectory.TabIndex = 9
        Me.bnWorkingDirectory.Text = "Browse..."
        Me.bnWorkingDirectory.UseVisualStyleBackColor = False
        '
        'tbWorkingDirectory
        '
        Me.tbWorkingDirectory.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbWorkingDirectory.BackColor = System.Drawing.Color.WhiteSmoke
        Me.tbWorkingDirectory.HideSelection = False
        Me.tbWorkingDirectory.Location = New System.Drawing.Point(849, 484)
        Me.tbWorkingDirectory.Margin = New System.Windows.Forms.Padding(3, 10, 0, 10)
        Me.tbWorkingDirectory.Name = "tbWorkingDirectory"
        Me.tbWorkingDirectory.Size = New System.Drawing.Size(1135, 55)
        Me.tbWorkingDirectory.TabIndex = 8
        '
        'laWorkingDirectory
        '
        Me.laWorkingDirectory.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.laWorkingDirectory.AutoSize = True
        Me.laWorkingDirectory.Location = New System.Drawing.Point(631, 464)
        Me.laWorkingDirectory.Margin = New System.Windows.Forms.Padding(18, 0, 12, 0)
        Me.laWorkingDirectory.Name = "laWorkingDirectory"
        Me.laWorkingDirectory.Size = New System.Drawing.Size(174, 96)
        Me.laWorkingDirectory.TabIndex = 23
        Me.laWorkingDirectory.Text = "Working" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Directory:"
        '
        'tlpListView
        '
        Me.tlpListView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tlpListView.ColumnCount = 3
        Me.tlpListView.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.0!))
        Me.tlpListView.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36.0!))
        Me.tlpListView.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.0!))
        Me.tlpListView.Controls.Add(Me.bnClone, 2, 0)
        Me.tlpListView.Controls.Add(Me.bnRemove, 1, 0)
        Me.tlpListView.Controls.Add(Me.bnAdd, 0, 0)
        Me.tlpListView.Location = New System.Drawing.Point(18, 1131)
        Me.tlpListView.Margin = New System.Windows.Forms.Padding(18, 0, 0, 0)
        Me.tlpListView.Name = "tlpListView"
        Me.tlpListView.RowCount = 1
        Me.tlpListView.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpListView.Size = New System.Drawing.Size(595, 111)
        Me.tlpListView.TabIndex = 27
        '
        'bnClone
        '
        Me.bnClone.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bnClone.BackColor = System.Drawing.Color.WhiteSmoke
        Me.bnClone.Location = New System.Drawing.Point(422, 18)
        Me.bnClone.Margin = New System.Windows.Forms.Padding(18, 0, 0, 0)
        Me.bnClone.Name = "bnClone"
        Me.bnClone.Size = New System.Drawing.Size(173, 75)
        Me.bnClone.TabIndex = 2
        Me.bnClone.Text = "Cl&one"
        Me.bnClone.UseVisualStyleBackColor = False
        '
        'bnRemove
        '
        Me.bnRemove.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bnRemove.BackColor = System.Drawing.Color.WhiteSmoke
        Me.bnRemove.Location = New System.Drawing.Point(190, 18)
        Me.bnRemove.Margin = New System.Windows.Forms.Padding(0)
        Me.bnRemove.Name = "bnRemove"
        Me.bnRemove.Size = New System.Drawing.Size(214, 75)
        Me.bnRemove.TabIndex = 1
        Me.bnRemove.Text = "&Remove"
        Me.bnRemove.UseVisualStyleBackColor = False
        '
        'bnAdd
        '
        Me.bnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bnAdd.BackColor = System.Drawing.Color.WhiteSmoke
        Me.bnAdd.Location = New System.Drawing.Point(0, 18)
        Me.bnAdd.Margin = New System.Windows.Forms.Padding(0, 0, 18, 0)
        Me.bnAdd.Name = "bnAdd"
        Me.bnAdd.Size = New System.Drawing.Size(172, 75)
        Me.bnAdd.TabIndex = 0
        Me.bnAdd.Text = "&Add"
        Me.bnAdd.UseVisualStyleBackColor = False
        '
        'bnIcon
        '
        Me.bnIcon.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.bnIcon.BackColor = System.Drawing.Color.WhiteSmoke
        Me.bnIcon.Location = New System.Drawing.Point(2002, 569)
        Me.bnIcon.Margin = New System.Windows.Forms.Padding(18, 9, 18, 9)
        Me.bnIcon.Name = "bnIcon"
        Me.bnIcon.Size = New System.Drawing.Size(200, 75)
        Me.bnIcon.TabIndex = 11
        Me.bnIcon.Text = "Browse..."
        Me.bnIcon.UseVisualStyleBackColor = False
        '
        'tbIcon
        '
        Me.tbIcon.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbIcon.BackColor = System.Drawing.Color.WhiteSmoke
        Me.tbIcon.HideSelection = False
        Me.tbIcon.Location = New System.Drawing.Point(849, 579)
        Me.tbIcon.Margin = New System.Windows.Forms.Padding(3, 10, 0, 10)
        Me.tbIcon.Name = "tbIcon"
        Me.tbIcon.Size = New System.Drawing.Size(1135, 55)
        Me.tbIcon.TabIndex = 10
        '
        'laIcon
        '
        Me.laIcon.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.laIcon.AutoSize = True
        Me.laIcon.Location = New System.Drawing.Point(631, 582)
        Me.laIcon.Margin = New System.Windows.Forms.Padding(18, 0, 0, 0)
        Me.laIcon.Name = "laIcon"
        Me.laIcon.Size = New System.Drawing.Size(96, 48)
        Me.laIcon.TabIndex = 26
        Me.laIcon.Text = "Icon:"
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(288.0!, 288.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(2221, 1242)
        Me.Controls.Add(Me.tlpMain)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "MainForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Open with++"
        Me.PropsFlowLayoutPanel.ResumeLayout(False)
        Me.tlpMain.ResumeLayout(False)
        Me.tlpMain.PerformLayout()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.PerformLayout()
        Me.tlpSearch.ResumeLayout(False)
        Me.tlpSearch.PerformLayout()
        Me.tlpListView.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private SelectedItem As Item
    Private TempItems As New List(Of Item)
    Private DLLPath As String = Path.Combine(Application.StartupPath, "OpenWithPPShellExtension.dll")
    Private BlockEvents As Boolean

    Sub New()
        MyBase.New()
        InitializeComponent()

        AddHandler Application.ThreadException, AddressOf ApplicationThreadException

        lv.View = View.Details
        lv.Columns.Add("")
        lv.HeaderStyle = ColumnHeaderStyle.None
        lv.MultiSelect = False
        lv.Sorting = SortOrder.Ascending
        lv.HideSelection = False

        Native.HideFocus(lv.Handle)
        SetCue(tbSearch, "Search", False)
        tbSearch.Focus()

        Width = FontHeight * 50
        Height = FontHeight * 27

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

    Shared Function CloneObject(Of T)(o As Object) As T
        Using ms As New MemoryStream
            Dim bf As New BinaryFormatter
            bf.Serialize(ms, o)
            ms.Position = 0
            Return DirectCast(bf.Deserialize(ms), T)
        End Using
    End Function

    Sub tbName_TextChanged(sender As Object, e As EventArgs) Handles tbName.TextChanged
        If Not BlockEvents AndAlso Not SelectedItem Is Nothing Then
            SelectedItem.Name = tbName.Text
            lv.SelectedItems(0).Text = tbName.Text
        End If
    End Sub

    Sub tbFileTypes_TextChanged(sender As Object, e As EventArgs) Handles tbFileTypes.TextChanged
        If Not BlockEvents AndAlso Not SelectedItem Is Nothing Then
            Dim value = tbFileTypes.Text.ToLower

            If value.Contains(",") Then
                value = value.Replace(",", " ")
            End If

            If value.Contains(";") Then
                value = value.Replace(";", " ")
            End If

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
        If Not BlockEvents AndAlso Not SelectedItem Is Nothing Then
            SelectedItem.SubMenu = cbSubmenu.Checked
        End If
    End Sub

    Sub cbRunAsAdmin_CheckedChanged(sender As Object, e As EventArgs) Handles cbRunAsAdmin.CheckedChanged
        If Not BlockEvents AndAlso Not SelectedItem Is Nothing Then
            SelectedItem.RunAsAdmin = cbRunAsAdmin.Checked
        End If
    End Sub

    Sub tbPath_TextChanged(sender As Object, e As EventArgs) Handles tbPath.TextChanged
        If Not BlockEvents AndAlso Not SelectedItem Is Nothing Then
            SelectedItem.Path = tbPath.Text
        End If
    End Sub

    Sub tbArgs_TextChanged(sender As Object, e As EventArgs) Handles tbArguments.TextChanged
        If Not BlockEvents AndAlso Not SelectedItem Is Nothing Then
            SelectedItem.Arguments = tbArguments.Text
        End If
    End Sub

    Sub cbDirectories_CheckedChanged(sender As Object, e As EventArgs) Handles cbDirectories.CheckedChanged
        If Not BlockEvents AndAlso Not SelectedItem Is Nothing Then
            SelectedItem.Directories = cbDirectories.Checked
        End If
    End Sub

    Sub tbPath_DoubleClick() Handles tbPath.DoubleClick
        Using form As New OpenFileDialog
            If form.ShowDialog = DialogResult.OK Then
                tbPath.Text = form.FileName
            End If
        End Using
    End Sub

    Sub AddItem(item As Item)
        Dim listViewItem = lv.Items.Add(item.Name)
        listViewItem.Tag = item
        listViewItem.Selected = True
        listViewItem.EnsureVisible()
        TempItems.Add(item)
        UpdateControls()
    End Sub

    Sub lv_KeyUp(sender As Object, e As KeyEventArgs) Handles lv.KeyUp
        If e.KeyData = Keys.Delete AndAlso bnRemove.Enabled Then
            bnRemove.PerformClick()
        End If

        UpdateControls()
    End Sub

    Sub lv_MouseUp(sender As Object, e As MouseEventArgs) Handles lv.MouseUp
        UpdateControls()
    End Sub

    Sub UpdateControls()
        BlockEvents = True

        If lv.SelectedItems.Count > 0 Then
            SelectedItem = DirectCast(lv.SelectedItems(0).Tag, Item)
        Else
            SelectedItem = Nothing
        End If

        If Not SelectedItem Is Nothing Then
            PropsFlowLayoutPanel.Enabled = True

            tbFileTypes.Enabled = True
            tbName.Enabled = True
            tbPath.Enabled = True
            tbArguments.Enabled = True
            tbWorkingDirectory.Enabled = True
            tbIcon.Enabled = True

            bnFileTypes.Enabled = True
            bnPath.Enabled = True
            bnArguments.Enabled = True
            bnWorkingDirectory.Enabled = True
            bnIcon.Enabled = True

            laArgs.Enabled = True
            laName.Enabled = True
            laExt.Enabled = True
            laPath.Enabled = True
            laWorkingDirectory.Enabled = True
            laIcon.Enabled = True

            tbName.Text = SelectedItem.Name
            tbPath.Text = SelectedItem.Path
            tbArguments.Text = SelectedItem.Arguments
            tbWorkingDirectory.Text = SelectedItem.WorkingDirectory
            tbFilter.Text = SelectedItem.Filter
            tbIcon.Text = SelectedItem.IconFile

            cbSubmenu.Checked = SelectedItem.SubMenu
            cbDirectories.Checked = SelectedItem.Directories
            cbRunAsAdmin.Checked = SelectedItem.RunAsAdmin
            cbHideWindow.Checked = SelectedItem.HideWindow
            cbHidden.Checked = SelectedItem.Hidden

            If SelectedItem.FileTypesDisplay = "" Then
                tbFileTypes.Text = SelectedItem.FileTypes
            Else
                tbFileTypes.Text = SelectedItem.FileTypesDisplay
            End If

            If SelectedItem.IconFile.ToLower.EndsWith(".exe") OrElse
                SelectedItem.IconFile.ToLower.EndsWith(".dll") Then

                tbIcon.Text += "," & SelectedItem.IconIndex
            End If
        Else
            PropsFlowLayoutPanel.Enabled = False

            tbArguments.Enabled = False
            tbFileTypes.Enabled = False
            tbName.Enabled = False
            tbPath.Enabled = False
            tbWorkingDirectory.Enabled = False
            tbIcon.Enabled = False

            bnArguments.Enabled = False
            bnPath.Enabled = False
            bnWorkingDirectory.Enabled = False
            bnIcon.Enabled = False
            bnFileTypes.Enabled = False

            laWorkingDirectory.Enabled = False
            laIcon.Enabled = False
            laArgs.Enabled = False
            laExt.Enabled = False
            laName.Enabled = False
            laPath.Enabled = False

            cbDirectories.Checked = False
            cbSubmenu.Checked = False
            cbRunAsAdmin.Checked = False
            cbHideWindow.Checked = False
            cbHidden.Checked = False

            tbName.Text = ""
            tbFileTypes.Text = ""
            tbPath.Text = ""
            tbArguments.Text = ""
            tbIcon.Text = ""
        End If

        bnRemove.Enabled = Not SelectedItem Is Nothing
        bnClone.Enabled = Not SelectedItem Is Nothing

        BlockEvents = False
    End Sub

    Sub tbSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles tbSearch.KeyDown
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

    Sub tbSearch_TextChanged(sender As Object, e As EventArgs) Handles tbSearch.TextChanged
        lv.BeginUpdate()
        lv.Items.Clear()

        Dim query = tbSearch.Text.ToLower

        For Each i In TempItems
            If tbSearch.Text = "" OrElse
                i.Name.ToLower.Contains(query) OrElse
                i.Path.ToLower.Contains(query) OrElse
                i.WorkingDirectory.ToLower.Contains(query) OrElse
                i.Filter.ToLower.Contains(query) OrElse
                i.FileTypesDisplay.ToLower.Contains(query) OrElse
                i.Arguments.ToLower.Contains(query) Then

                lv.Items.Add(i.Name).Tag = i
            End If
        Next

        SelectFirst()
        SetColumnWidths()
        lv.EndUpdate()
    End Sub

    Sub bnOK_Click(sender As Object, e As EventArgs) Handles bnOK.Click
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

    Sub bnCancel_Click(sender As Object, e As EventArgs) Handles bnCancel.Click
        Close()
    End Sub

    Sub bnArguments_Click(sender As Object, e As EventArgs) Handles bnArguments.Click
        tbArguments.Focus()
        tbArguments.Text = (tbArguments.Text.Trim + " %paths%").Trim
    End Sub

    Sub bnPath_Click(sender As Object, e As EventArgs) Handles bnPath.Click
        tbPath_DoubleClick()
    End Sub

    Sub MainForm_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        tbSearch.Focus()
        tbArguments.HideSelection = True
    End Sub

    Sub llWebsite_Click(sender As Object, e As EventArgs) Handles llWebsite.Click
        Process.Start("https://github.com/stax76/OpenWithPlusPlus")
    End Sub

    Sub bnFileTypes_Click(sender As Object, e As EventArgs) Handles bnFileTypes.Click
        tbFileTypes.Focus()
        tbFileTypes.Text = "*.*"
    End Sub

    Sub cbHideWindow_CheckedChanged(sender As Object, e As EventArgs) Handles cbHideWindow.CheckedChanged
        If Not BlockEvents AndAlso Not SelectedItem Is Nothing Then
            SelectedItem.HideWindow = cbHideWindow.Checked
        End If
    End Sub

    Private Sub cbHidden_CheckedChanged(sender As Object, e As EventArgs) Handles cbHidden.CheckedChanged
        If Not BlockEvents AndAlso Not SelectedItem Is Nothing Then
            SelectedItem.Hidden = cbHidden.Checked
        End If
    End Sub

    Sub SetCue(tb As TextBox, value As String, hideWhenFocused As Boolean)
        Const EM_SETCUEBANNER = &H1501
        Native.SendMessage(tb.Handle, EM_SETCUEBANNER, If(hideWhenFocused, 0, 1), value)
    End Sub

    Sub llOptions_Click(sender As Object, e As EventArgs) Handles llOptions.Click
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

    Sub llInstallUninstall_Click(sender As Object, e As EventArgs) Handles llInstallUninstall.Click
        If llInstallUninstall.Text = "Install" Then
            If Msg("Confirm to install the Shell Extension." + BR2 +
                   "After the installation the Open with++ location cannot be moved.", "Install Shell Extension",
                   MessageBoxIcon.None, MessageBoxButtons.OKCancel) = DialogResult.OK Then

                Using proc As New Process
                    proc.StartInfo.Verb = "runas"
                    proc.StartInfo.FileName = "regsvr32.exe"
                    proc.StartInfo.Arguments = """" + DLLPath + """"
                    proc.Start()
                End Using
            End If
        Else
            If Msg("Confirm to uninstall the Shell Extension." + BR2 +
                   "Afterwards it's necessary to reboot (or to restart the relevant processes).",
                   "Uninstall Shell Extension", MessageBoxIcon.None, MessageBoxButtons.OKCancel) = DialogResult.OK Then

                Using proc As New Process
                    proc.StartInfo.Verb = "runas"
                    proc.StartInfo.FileName = "regsvr32.exe"
                    proc.StartInfo.Arguments = "/u """ + DLLPath + """"
                    proc.Start()
                End Using
            End If
        End If
    End Sub

    Sub MainForm_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        Using key = Registry.ClassesRoot.OpenSubKey("CLSID\{E7B8ACF5-FC18-4f0d-BC50-D0184481A5DC}")
            If key Is Nothing Then
                llInstallUninstall.Text = "Install"
            Else
                llInstallUninstall.Text = "Uninstall"
            End If
        End Using
    End Sub

    Sub bnWorkingDirectory_Click(sender As Object, e As EventArgs) Handles bnWorkingDirectory.Click
        Using dialog As New FolderBrowserDialog
            If dialog.ShowDialog = DialogResult.OK Then
                tbWorkingDirectory.Text = dialog.SelectedPath
            End If
        End Using
    End Sub

    Sub tbWorkingDirectory_TextChanged(sender As Object, e As EventArgs) Handles tbWorkingDirectory.TextChanged
        If Not BlockEvents AndAlso Not SelectedItem Is Nothing Then
            SelectedItem.WorkingDirectory = tbWorkingDirectory.Text
        End If
    End Sub

    Sub bnIcon_Click(sender As Object, e As EventArgs) Handles bnIcon.Click
        Using dialog As New OpenFileDialog
            dialog.Filter = "*.ico, *.exe, *.dll|*.ico;*.exe;*.dll"

            If dialog.ShowDialog = DialogResult.OK Then
                tbIcon.Text = dialog.FileName
            End If
        End Using
    End Sub

    Sub tbIcon_TextChanged(sender As Object, e As EventArgs) Handles tbIcon.TextChanged
        Dim match = Regex.Match(tbIcon.Text, "^(.+),(\d+)$")

        If Not BlockEvents AndAlso Not SelectedItem Is Nothing Then
            If File.Exists(tbIcon.Text) AndAlso tbIcon.Text.ToLower.EndsWith(".exe") OrElse
                tbIcon.Text.ToLower.EndsWith(".dll") Then

                Using form As New IconExtractForm(tbIcon.Text)
                    If form.ShowDialog() = DialogResult.OK Then
                        tbIcon.Text += "," + form.lv.SelectedIndices(0).ToString
                    Else
                        tbIcon.Text = ""
                    End If
                End Using

                match = Regex.Match(tbIcon.Text, "^(.+),(\d+)$")
            End If

            If match.Success Then
                SelectedItem.IconFile = match.Groups(1).Value
                SelectedItem.IconIndex = CInt(match.Groups(2).Value)
            Else
                SelectedItem.IconFile = tbIcon.Text
                SelectedItem.IconIndex = 0
            End If
        End If
    End Sub

    Sub bnAdd_Click(sender As Object, e As EventArgs) Handles bnAdd.Click
        AddItem(New Item With {.Arguments = "%paths%"})
        tbSearch.Text = ""
        tbName.Focus()
    End Sub

    Sub bnRemove_Click(sender As Object, e As EventArgs) Handles bnRemove.Click
        Dim index = lv.SelectedIndices(0)
        TempItems.Remove(SelectedItem)
        lv.SelectedItems(0).Remove()

        If index > lv.Items.Count - 1 Then
            index = index - 1
        End If

        If index >= 0 Then
            lv.Items(index).Selected = True
        End If

        UpdateControls()
    End Sub

    Sub bnClone_Click(sender As Object, e As EventArgs) Handles bnClone.Click
        AddItem(CloneObject(Of Item)(SelectedItem))
    End Sub

    Sub tbFilter_TextChanged(sender As Object, e As EventArgs) Handles tbFilter.TextChanged
        If Not BlockEvents AndAlso Not SelectedItem Is Nothing Then
            SelectedItem.Filter = tbFilter.Text
        End If
    End Sub

    Sub llAbout_Click(sender As Object, e As EventArgs) Handles llAbout.Click
        MsgInfo(Application.ProductName + " " + Application.ProductVersion.ToString + BR2 + "Copyright (C) 2008-2021 Frank Skare (stax76)" + BR2 + "MIT License")
    End Sub

    Sub llExport_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llExport.LinkClicked
        If Msg("Export to ContextMenuForWindows11?", "Export", MessageBoxIcon.Question, MessageBoxButtons.OKCancel) <> DialogResult.OK Then
            Exit Sub
        End If

        Dim items = TempItems
        items.Sort()

        For Each i In items
            i.FileTypes = SolveMacros(i.FileTypesDisplay)
        Next

        Dim folder = Environment.ExpandEnvironmentVariables("C:\Users\%USERNAME%\AppData\Local\Packages\7061touchwp.CustomContextMenu_1zgtmak8c0kvy\LocalState\custom_commands\")

        Try
            Directory.CreateDirectory(folder)
        Catch
        End Try

        For Each i In g.Settings.Items
            Dim json = "{" + BR +
                "    ""title"": " + EscapeJSON(i.Name) + "," + BR +
                "    ""exe"": " + EscapeJSON(i.Path) + "," + BR +
                "    ""param"": " + EscapeJSON(i.Arguments.Replace("%paths%", """{path}""")) + "," + BR +
                "    ""icon"": " + EscapeJSON(i.IconFile) + "," + BR +
                "    ""acceptExts"": " + EscapeJSON((" " + i.FileTypes).Replace(" ", " .").Replace("*.*", "*")) + "," + BR +
                "    ""acceptDirectory"": " + If(i.Directories, "true", "false") + "," + BR +
                "    ""acceptFile"": " + If(i.FileTypes <> "", "true", "false") + "," + BR +
                "    ""acceptMultipleFilesFlag"": 0," + BR +
                "    ""pathDelimiter"": """"," + BR +
                "    ""paramForMultipleFiles"": """"," + BR +
                "    ""index"": 0" + BR + "}"

            Try
                File.WriteAllText(folder + i.Name + ".json", json)
            Catch
            End Try
        Next
    End Sub

    Function EscapeJSON(value As String) As String
        Return Web.Helpers.Json.Encode(value)
    End Function
End Class
