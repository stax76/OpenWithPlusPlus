
Imports System.Runtime.InteropServices

Public Class IconExtractForm
    Private Images As New ImageList

    Public Sub New(filePath As String)
        InitializeComponent()
        Images.ImageSize = SystemInformation.IconSize
        lv.LargeImageList = Images
        lv.View = View.Tile
        lv.FullRowSelect = True
        lv.TileSize = SystemInformation.IconSize
        lv.MultiSelect = False
        Dim iconCount = ExtractIcon(IntPtr.Zero, filePath, -1).ToInt32

        For x = 0 To iconCount - 1
            Dim iconHandle = ExtractIcon(IntPtr.Zero, filePath, x)
            Dim ico = Icon.FromHandle(ExtractIcon(IntPtr.Zero, filePath, x))
            DestroyIcon(iconHandle)
            Dim listItem As New ListViewItem
            listItem.ImageKey = x.ToString
            Images.Images.Add(listItem.ImageKey, ico)
            lv.Items.Add(listItem)
        Next
    End Sub

    Private Sub lv_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lv.SelectedIndexChanged
        bnOK.Enabled = lv.SelectedItems.Count > 0
    End Sub

    Private Sub lv_DoubleClick(sender As Object, e As EventArgs) Handles lv.DoubleClick
        If lv.SelectedItems.Count > 0 Then
            bnOK.PerformClick()
        End If
    End Sub

    <DllImport("shell32.dll")>
    Shared Function ExtractIcon(hInst As IntPtr, fileName As String, index As Integer) As IntPtr
    End Function

    <DllImport("user32.dll")>
    Shared Function DestroyIcon(hIcon As IntPtr) As Boolean
    End Function
End Class
