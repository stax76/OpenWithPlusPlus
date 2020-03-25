<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OptionsForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.bnOK = New System.Windows.Forms.Button()
        Me.bnCancel = New System.Windows.Forms.Button()
        Me.laMacros = New System.Windows.Forms.Label()
        Me.tbMacros = New System.Windows.Forms.TextBox()
        Me.tlpMain = New System.Windows.Forms.TableLayoutPanel()
        Me.flpOkCancel = New System.Windows.Forms.FlowLayoutPanel()
        Me.tlpMacrosTextBox = New System.Windows.Forms.TableLayoutPanel()
        Me.tlpSettingsDirectoryTextBox = New System.Windows.Forms.TableLayoutPanel()
        Me.tbSettingDirectory = New System.Windows.Forms.TextBox()
        Me.laSettingsDirectory = New System.Windows.Forms.Label()
        Me.tlpMain.SuspendLayout()
        Me.flpOkCancel.SuspendLayout()
        Me.tlpMacrosTextBox.SuspendLayout()
        Me.tlpSettingsDirectoryTextBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'bnOK
        '
        Me.bnOK.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.bnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.bnOK.Location = New System.Drawing.Point(0, 0)
        Me.bnOK.Margin = New System.Windows.Forms.Padding(0, 0, 9, 0)
        Me.bnOK.Name = "bnOK"
        Me.bnOK.Size = New System.Drawing.Size(250, 75)
        Me.bnOK.TabIndex = 0
        Me.bnOK.Text = "OK"
        Me.bnOK.UseVisualStyleBackColor = True
        '
        'bnCancel
        '
        Me.bnCancel.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.bnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.bnCancel.Location = New System.Drawing.Point(268, 0)
        Me.bnCancel.Margin = New System.Windows.Forms.Padding(9, 0, 0, 0)
        Me.bnCancel.Name = "bnCancel"
        Me.bnCancel.Size = New System.Drawing.Size(250, 75)
        Me.bnCancel.TabIndex = 1
        Me.bnCancel.Text = "Cancel"
        Me.bnCancel.UseVisualStyleBackColor = True
        '
        'laMacros
        '
        Me.laMacros.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.laMacros.AutoSize = True
        Me.laMacros.Location = New System.Drawing.Point(18, 18)
        Me.laMacros.Margin = New System.Windows.Forms.Padding(18, 18, 0, 9)
        Me.laMacros.Name = "laMacros"
        Me.laMacros.Size = New System.Drawing.Size(144, 48)
        Me.laMacros.TabIndex = 2
        Me.laMacros.Text = "Macros:"
        Me.laMacros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tbMacros
        '
        Me.tbMacros.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbMacros.Location = New System.Drawing.Point(0, 0)
        Me.tbMacros.Margin = New System.Windows.Forms.Padding(0)
        Me.tbMacros.Multiline = True
        Me.tbMacros.Name = "tbMacros"
        Me.tbMacros.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.tbMacros.Size = New System.Drawing.Size(1746, 781)
        Me.tbMacros.TabIndex = 3
        Me.tbMacros.WordWrap = False
        '
        'tlpMain
        '
        Me.tlpMain.ColumnCount = 2
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpMain.Controls.Add(Me.flpOkCancel, 1, 3)
        Me.tlpMain.Controls.Add(Me.tlpMacrosTextBox, 0, 1)
        Me.tlpMain.Controls.Add(Me.tlpSettingsDirectoryTextBox, 1, 2)
        Me.tlpMain.Controls.Add(Me.laSettingsDirectory, 0, 2)
        Me.tlpMain.Controls.Add(Me.laMacros, 0, 0)
        Me.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpMain.Location = New System.Drawing.Point(0, 0)
        Me.tlpMain.Name = "tlpMain"
        Me.tlpMain.RowCount = 4
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpMain.Size = New System.Drawing.Size(1782, 1049)
        Me.tlpMain.TabIndex = 4
        '
        'flpOkCancel
        '
        Me.flpOkCancel.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.flpOkCancel.AutoSize = True
        Me.flpOkCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.flpOkCancel.Controls.Add(Me.bnOK)
        Me.flpOkCancel.Controls.Add(Me.bnCancel)
        Me.flpOkCancel.Location = New System.Drawing.Point(1246, 956)
        Me.flpOkCancel.Margin = New System.Windows.Forms.Padding(0, 9, 18, 18)
        Me.flpOkCancel.Name = "flpOkCancel"
        Me.flpOkCancel.Size = New System.Drawing.Size(518, 75)
        Me.flpOkCancel.TabIndex = 7
        '
        'tlpMacrosTextBox
        '
        Me.tlpMacrosTextBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tlpMacrosTextBox.ColumnCount = 1
        Me.tlpMain.SetColumnSpan(Me.tlpMacrosTextBox, 2)
        Me.tlpMacrosTextBox.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpMacrosTextBox.Controls.Add(Me.tbMacros, 0, 0)
        Me.tlpMacrosTextBox.Location = New System.Drawing.Point(18, 84)
        Me.tlpMacrosTextBox.Margin = New System.Windows.Forms.Padding(18, 9, 18, 9)
        Me.tlpMacrosTextBox.Name = "tlpMacrosTextBox"
        Me.tlpMacrosTextBox.RowCount = 1
        Me.tlpMacrosTextBox.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpMacrosTextBox.Size = New System.Drawing.Size(1746, 781)
        Me.tlpMacrosTextBox.TabIndex = 9
        '
        'tlpSettingsDirectoryTextBox
        '
        Me.tlpSettingsDirectoryTextBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tlpSettingsDirectoryTextBox.AutoSize = True
        Me.tlpSettingsDirectoryTextBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpSettingsDirectoryTextBox.ColumnCount = 1
        Me.tlpSettingsDirectoryTextBox.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpSettingsDirectoryTextBox.Controls.Add(Me.tbSettingDirectory, 0, 0)
        Me.tlpSettingsDirectoryTextBox.Location = New System.Drawing.Point(338, 883)
        Me.tlpSettingsDirectoryTextBox.Margin = New System.Windows.Forms.Padding(9, 9, 18, 9)
        Me.tlpSettingsDirectoryTextBox.Name = "tlpSettingsDirectoryTextBox"
        Me.tlpSettingsDirectoryTextBox.RowCount = 1
        Me.tlpSettingsDirectoryTextBox.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpSettingsDirectoryTextBox.Size = New System.Drawing.Size(1426, 55)
        Me.tlpSettingsDirectoryTextBox.TabIndex = 11
        '
        'tbSettingDirectory
        '
        Me.tbSettingDirectory.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbSettingDirectory.Location = New System.Drawing.Point(0, 0)
        Me.tbSettingDirectory.Margin = New System.Windows.Forms.Padding(0)
        Me.tbSettingDirectory.Name = "tbSettingDirectory"
        Me.tbSettingDirectory.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.tbSettingDirectory.Size = New System.Drawing.Size(1426, 55)
        Me.tbSettingDirectory.TabIndex = 6
        Me.tbSettingDirectory.WordWrap = False
        '
        'laSettingsDirectory
        '
        Me.laSettingsDirectory.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.laSettingsDirectory.AutoSize = True
        Me.laSettingsDirectory.Location = New System.Drawing.Point(18, 886)
        Me.laSettingsDirectory.Margin = New System.Windows.Forms.Padding(18, 0, 0, 0)
        Me.laSettingsDirectory.Name = "laSettingsDirectory"
        Me.laSettingsDirectory.Size = New System.Drawing.Size(311, 48)
        Me.laSettingsDirectory.TabIndex = 5
        Me.laSettingsDirectory.Text = "Settings Directory:"
        Me.laSettingsDirectory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'OptionsForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(288.0!, 288.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(1782, 1049)
        Me.Controls.Add(Me.tlpMain)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "OptionsForm"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Options"
        Me.tlpMain.ResumeLayout(False)
        Me.tlpMain.PerformLayout()
        Me.flpOkCancel.ResumeLayout(False)
        Me.tlpMacrosTextBox.ResumeLayout(False)
        Me.tlpMacrosTextBox.PerformLayout()
        Me.tlpSettingsDirectoryTextBox.ResumeLayout(False)
        Me.tlpSettingsDirectoryTextBox.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents bnOK As System.Windows.Forms.Button
    Friend WithEvents bnCancel As System.Windows.Forms.Button
    Friend WithEvents laMacros As System.Windows.Forms.Label
    Friend WithEvents tbMacros As System.Windows.Forms.TextBox
    Friend WithEvents tlpMain As TableLayoutPanel
    Friend WithEvents tbSettingDirectory As TextBox
    Friend WithEvents laSettingsDirectory As Label
    Friend WithEvents flpOkCancel As FlowLayoutPanel
    Friend WithEvents tlpMacrosTextBox As TableLayoutPanel
    Friend WithEvents tlpSettingsDirectoryTextBox As TableLayoutPanel
End Class
