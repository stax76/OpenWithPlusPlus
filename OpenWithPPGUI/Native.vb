Imports System.Runtime.InteropServices

Public Class Native
    Shared Function MAKEWPARAM(low As Int32, high As Int32) As Int32
        Return (low And &HFFFF) Or (high << 16)
    End Function

    Shared Sub HideFocus(handle As IntPtr)
        Const UIS_SET = 1, UISF_HIDEFOCUS = &H1, WM_CHANGEUISTATE = &H127
        SendMessage(handle, WM_CHANGEUISTATE, MAKEWPARAM(UIS_SET, UISF_HIDEFOCUS), 0)
    End Sub

    <DllImport("user32", CharSet:=CharSet.Unicode)>
    Shared Function SendMessage(hWnd As IntPtr,
                                Msg As Int32,
                                wParam As Integer,
                                lParam As Integer) As IntPtr
    End Function

    <DllImport("user32", CharSet:=CharSet.Unicode)>
    Shared Function SendMessage(hWnd As IntPtr,
                                msg As Integer,
                                wParam As Integer,
                                <MarshalAs(UnmanagedType.LPWStr)>
                                lParam As String) As IntPtr
    End Function

    <DllImport("uxtheme", CharSet:=CharSet.Unicode)>
    Shared Function SetWindowTheme(hWnd As IntPtr, pszSubAppName As String, pszSubIdList As String) As Integer
    End Function
End Class