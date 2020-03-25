<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class IconExtractForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
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
        Me.tlpMain = New System.Windows.Forms.TableLayoutPanel()
        Me.flpOkCancel = New System.Windows.Forms.FlowLayoutPanel()
        Me.bnOK = New System.Windows.Forms.Button()
        Me.bnCancel = New System.Windows.Forms.Button()
        Me.lv = New System.Windows.Forms.ListView()
        Me.tlpMain.SuspendLayout()
        Me.flpOkCancel.SuspendLayout()
        Me.SuspendLayout()
        '
        'tlpMain
        '
        Me.tlpMain.ColumnCount = 1
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpMain.Controls.Add(Me.flpOkCancel, 0, 1)
        Me.tlpMain.Controls.Add(Me.lv, 0, 0)
        Me.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpMain.Location = New System.Drawing.Point(0, 0)
        Me.tlpMain.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.tlpMain.Name = "tlpMain"
        Me.tlpMain.RowCount = 2
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpMain.Size = New System.Drawing.Size(1048, 596)
        Me.tlpMain.TabIndex = 0
        '
        'flpOkCancel
        '
        Me.flpOkCancel.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.flpOkCancel.AutoSize = True
        Me.flpOkCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.flpOkCancel.Controls.Add(Me.bnOK)
        Me.flpOkCancel.Controls.Add(Me.bnCancel)
        Me.flpOkCancel.Location = New System.Drawing.Point(510, 475)
        Me.flpOkCancel.Margin = New System.Windows.Forms.Padding(0)
        Me.flpOkCancel.Name = "flpOkCancel"
        Me.flpOkCancel.Size = New System.Drawing.Size(538, 121)
        Me.flpOkCancel.TabIndex = 0
        '
        'bnOK
        '
        Me.bnOK.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.bnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.bnOK.Enabled = False
        Me.bnOK.Location = New System.Drawing.Point(0, 23)
        Me.bnOK.Margin = New System.Windows.Forms.Padding(0)
        Me.bnOK.Name = "bnOK"
        Me.bnOK.Size = New System.Drawing.Size(250, 75)
        Me.bnOK.TabIndex = 0
        Me.bnOK.Text = "OK"
        Me.bnOK.UseVisualStyleBackColor = True
        '
        'bnCancel
        '
        Me.bnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.bnCancel.Location = New System.Drawing.Point(269, 23)
        Me.bnCancel.Margin = New System.Windows.Forms.Padding(19, 23, 19, 23)
        Me.bnCancel.Name = "bnCancel"
        Me.bnCancel.Size = New System.Drawing.Size(250, 75)
        Me.bnCancel.TabIndex = 1
        Me.bnCancel.Text = "Cancel"
        Me.bnCancel.UseVisualStyleBackColor = True
        '
        'lv
        '
        Me.lv.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lv.HideSelection = False
        Me.lv.Location = New System.Drawing.Point(18, 18)
        Me.lv.Margin = New System.Windows.Forms.Padding(18, 18, 18, 0)
        Me.lv.Name = "lv"
        Me.lv.Size = New System.Drawing.Size(1012, 457)
        Me.lv.TabIndex = 1
        Me.lv.UseCompatibleStateImageBehavior = False
        '
        'IconExtractForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(288.0!, 288.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(1048, 596)
        Me.Controls.Add(Me.tlpMain)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "IconExtractForm"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Choose Icon"
        Me.tlpMain.ResumeLayout(False)
        Me.tlpMain.PerformLayout()
        Me.flpOkCancel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents tlpMain As TableLayoutPanel
    Friend WithEvents flpOkCancel As FlowLayoutPanel
    Friend WithEvents bnOK As Button
    Friend WithEvents bnCancel As Button
    Friend WithEvents lv As ListView
End Class
