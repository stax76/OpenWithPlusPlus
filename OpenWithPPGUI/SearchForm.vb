Imports Microsoft.Win32
Imports System.IO

Public Class SearchForm
    Private Filepaths As New List(Of String)
    Private Items As New List(Of ItemAttribute)
    Private Images As New ImageList
    Private Worker As New Threading.Thread(AddressOf SearchExePaths)

    Public Sub New()
        InitializeComponent()
        StartPosition = FormStartPosition.CenterParent
        Images.ImageSize = New Size(FontHeight * 2, FontHeight * 2)
        lv.LargeImageList = Images
        lv.View = View.Tile
        lv.FullRowSelect = True
        lv.TileSize = New Size(lv.Width - SystemInformation.VerticalScrollBarWidth - 6, FontHeight * 3)
        lv.MultiSelect = False
        lv.Columns.AddRange({New ColumnHeader(), New ColumnHeader(), New ColumnHeader()})
        KeyPreview = True
        Native.SetWindowTheme(lv.Handle, "explorer", Nothing)
        tbSearch.SetCue("Search", False)
        Worker.Start()
    End Sub

    Sub SearchExePaths()
        Using k = Registry.ClassesRoot.OpenSubKey("Applications")
            If Not k Is Nothing Then
                For Each i In k.GetSubKeyNames
                    Using k2 = k.OpenSubKey(i + "\shell\open\command")
                        If Not k2 Is Nothing Then
                            AddFile(CStr(k2.GetValue(Nothing)))
                        End If
                    End Using
                Next
            End If
        End Using

        Using k = Registry.ClassesRoot
            For Each i In k.GetSubKeyNames
                Using k2 = k.OpenSubKey(i + "\shell\open\command")
                    If Not k2 Is Nothing Then
                        AddFile(CStr(k2.GetValue(Nothing)))
                    End If
                End Using
            Next
        End Using

        Using k = Registry.LocalMachine.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths")
            For Each i In k.GetSubKeyNames
                Using k2 = k.OpenSubKey(i)
                    AddFile(CStr(k2.GetValue(Nothing)))
                End Using
            Next
        End Using

        If Not File.Exists(g.PathsFile) Then
            Dim content = ""

            For Each i In Directory.GetFiles(Environment.SystemDirectory)
                If i.EndsWith(".exe") Then
                    content += i + BR
                End If
            Next

            File.WriteAllText(g.PathsFile, content)
        End If

        For Each i In File.ReadAllLines(g.PathsFile)
            AddFile(i)
        Next
    End Sub

    Sub AddFile(ByVal value As String)
        If Not value Is Nothing AndAlso _
            (value.Contains(".exe") OrElse _
             value.ToUpper.Contains(".EXE")) Then

            If Not value.Contains(".exe") Then
                value = value.Replace(".EXE", ".exe")
            End If

            If Not value.EndsWith(".exe") Then
                Dim length = value.IndexOf(".exe") + 4
                value = value.Substring(0, length)
            End If

            If value.StartsWith("""") Then
                value = value.TrimStart(""""c)
            End If

            If value.Contains("%") Then
                value = Environment.ExpandEnvironmentVariables(value)
            End If

            If Not Filepaths.Contains(value.ToUpper) AndAlso File.Exists(value) Then
                Filepaths.Add(value.ToUpper)

                Dim info = FileVersionInfo.GetVersionInfo(value)
                Dim item As New ItemAttribute

                item.Path = value
                item.Company = info.CompanyName
                item.Name = GetName(info, value)
                item.Arguments = "%paths%"

                AddToList(item)
            End If
        End If
    End Sub

    Sub AddToList(ByVal item As ItemAttribute)
        item.Image = Drawing.Icon.ExtractAssociatedIcon(item.Path).ToBitmap
        item.UpdateSearchValue()

        SyncLock Items
            Items.Add(item)
        End SyncLock

        If Items.Count = 50 AndAlso Not IsDisposed Then
            Invoke(New Action(AddressOf Populate))
        End If
    End Sub

    Function GetName(ByVal info As FileVersionInfo, ByVal filepath As String) As String
        For Each i In New String() {info.FileDescription, info.ProductName}
            If i <> "" Then
                Return i
            End If
        Next

        Return Path.GetFileNameWithoutExtension(filepath)
    End Function

    Private Sub tbSearch_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles tbSearch.TextChanged
        Populate()
    End Sub

    Sub Populate()
        lv.Items.Clear()
        Dim query = tbSearch.Text.ToLower

        SyncLock Items
            For Each i In Items
                If tbSearch.Text = "" OrElse i.SearchValue.Contains(query) Then
                    AddItemToListView(i)
                End If
            Next
        End SyncLock

        If lv.Items.Count > 0 Then
            lv.Items(0).Selected = True
            tbSearch.Focus()
        End If
    End Sub

    Sub AddItemToListView(ByVal item As ItemAttribute)
        If lv.Items.Count < 50 Then
            Dim lvi As New ListViewItem
            lvi.Text = item.Name
            lvi.ImageKey = item.Path
            lvi.SubItems.Add(item.Company)
            lvi.Tag = item

            If Not Images.Images.ContainsKey(item.Path) Then
                Images.Images.Add(item.Path, item.Image)
            End If

            lv.Items.Add(lvi)
        End If
    End Sub

    Private Sub lv_DoubleClick(ByVal sender As Object, ByVal e As EventArgs) Handles lv.DoubleClick
        Confirm()
    End Sub

    Sub Confirm()
        If lv.SelectedItems.Count = 1 Then DialogResult = DialogResult.OK
    End Sub

    Private Sub bBrowse_Click(ByVal sender As Object, ByVal e As EventArgs) Handles bBrowse.Click
        Using f As New OpenFileDialog
            If f.ShowDialog = DialogResult.OK Then
                Using sw = File.AppendText(g.PathsFile)
                    sw.WriteLine(f.FileName)
                End Using

                AddFile(f.FileName)
                tbSearch.Text = Path.GetFileNameWithoutExtension(f.FileName)
            End If
        End Using
    End Sub

    Private Sub SearchForm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                Confirm()
            Case Keys.Escape
                Close()
        End Select

        If lv.Items.Count > 0 Then
            If lv.SelectedIndices.Count = 0 Then lv.Items(0).Selected = True

            Dim sel As Integer

            Select Case e.KeyData
                Case Keys.Up
                    e.Handled = True
                    sel = -1
                Case Keys.Down
                    e.Handled = True
                    sel = 1
            End Select

            If sel <> 0 Then
                sel = lv.SelectedItems(0).Index + sel
                If sel < 0 Then sel = 0
                If sel >= lv.Items.Count Then sel = lv.Items.Count - 1
                lv.Items(sel).Selected = True
                lv.Items(sel).EnsureVisible()
            End If
        End If
    End Sub
End Class