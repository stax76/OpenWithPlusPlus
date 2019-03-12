Public Class OptionsForm
    Public Sub New()
        InitializeComponent()

        For Each i In g.Settings.Macros
            tbMacros.Text += i.Name + " = " + i.Value + BR
        Next
    End Sub
End Class