Imports System.Runtime.InteropServices

Public Class Native
    Shared Function MAKEWPARAM(ByVal low As Int32, ByVal high As Int32) As Int32
        Return (low And &HFFFF) Or (high << 16)
    End Function

    Shared Sub HideFocus(handle As IntPtr)
        Const UIS_SET = 1, UISF_HIDEFOCUS = &H1, WM_CHANGEUISTATE = &H127
        SendMessage(handle, WM_CHANGEUISTATE, MAKEWPARAM(UIS_SET, UISF_HIDEFOCUS), 0)
    End Sub

    <DllImport("user32", CharSet:=CharSet.Unicode)>
    Shared Function SendMessage(ByVal hWnd As IntPtr,
                                ByVal Msg As Int32,
                                ByVal wParam As Integer,
                                ByVal lParam As Integer) As IntPtr
    End Function

    <DllImport("user32", CharSet:=CharSet.Unicode)>
    Shared Function SendMessage(ByVal hWnd As IntPtr,
                                ByVal msg As Integer,
                                ByVal wParam As Integer,
                                <MarshalAs(UnmanagedType.LPWStr)>
                                ByVal lParam As String) As IntPtr
    End Function

    <DllImport("uxtheme", CharSet:=CharSet.Unicode)>
    Shared Function SetWindowTheme(ByVal hWnd As IntPtr,
                                   ByVal pszSubAppName As String,
                                   ByVal pszSubIdList As String) As Integer
    End Function
End Class