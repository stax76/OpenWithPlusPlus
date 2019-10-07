Public Class OptionsForm
    Public Sub New()
        InitializeComponent()

        For Each i In g.Settings.Macros
            tbMacros.Text += i.Name + " = " + i.Value + BR
        Next

        tbSettingDirectory.Text = g.SettingsDir
    End Sub

    Private Sub bnOK_Click(sender As Object, e As EventArgs) Handles bnOK.Click
        DialogResult = DialogResult.OK
        Close()
    End Sub
End Class