Imports System.Globalization
Imports System.Runtime.CompilerServices

Public Module Extensions
    <Extension()>
    Sub SetCue(ByVal tb As TextBox, ByVal value As String, ByVal hideWhenFocused As Boolean)
        Const EM_SETCUEBANNER = &H1501
        Native.SendMessage(tb.Handle, EM_SETCUEBANNER, If(hideWhenFocused, 0, 1), value)
    End Sub

    <Extension()>
    Function ToTitleCase(ByVal value As String) As String
        Return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value.ToLower)
    End Function
End Module