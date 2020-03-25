
Class OptionsForm
    Public Sub New()
        InitializeComponent()

        For Each macro In g.Settings.Macros
            tbMacros.Text += macro.Name + " = " + macro.Value + BR
        Next

        tbSettingDirectory.Text = g.SettingsDir
    End Sub
End Class
