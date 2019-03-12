Imports System.IO
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Text

Imports Microsoft.Win32
Imports Microsoft.VisualBasic

Public Class g
    Public Shared ShellItems As New List(Of String)
    Public Shared Settings As AppSettings
    Public Shared SettingsDir As String = Application.StartupPath + "\"

    Public Shared Sub LoadSettings()
        If File.Exists(SettingsDir + "Settings.xml") Then
            g.Settings = XMLSerializerHelp.LoadXML(Of AppSettings)(SettingsDir + "Settings.xml")
        Else
            g.Settings = New AppSettings
        End If
    End Sub

    Public Shared Sub SaveSettings()
        XMLSerializerHelp.SaveXML(SettingsDir + "Settings.xml", g.Settings)
    End Sub
End Class

<Serializable()>
Public Class AppSettings
    Public Sub New()
    End Sub

    <XmlArrayItem("Item", GetType(ItemAttribute))>
    Public Items As New List(Of ItemAttribute)

    <XmlArrayItem("Macro", GetType(Macro))>
    Public Macros As New List(Of Macro)
End Class

Public Class Macro
    Property Name As String = ""
    Property Value As String = ""
End Class

<Serializable()>
Public Class ItemAttribute
    Inherits Attribute
    Implements IComparable

    Public Name As String = ""
    Public Path As String = ""
    Public Arguments As String = ""
    Public SubMenu As Boolean = True
    Public FileTypes As String = ""
    Public FileTypesDisplay As String = ""
    Public Directories As Boolean
    Public RunAsAdmin As Boolean
    Public AllFiles As Boolean

    <XmlIgnoreAttribute()> Public Company As String
    <XmlIgnoreAttribute()> Public SearchValue As String
    <XmlIgnoreAttribute()> Public Image As Image

    Public Function CompareTo(ByVal obj As Object) As Integer Implements System.IComparable.CompareTo
        Return Me.Name.CompareTo(DirectCast(obj, ItemAttribute).Name)
    End Function

    Sub UpdateSearchValue()
        SearchValue = (Name + Path + FileTypes + Arguments + Company).ToLower
    End Sub
End Class

Public Class XMLSerializerHelp
    Public Shared Sub SaveXML(ByVal path As String, ByVal obj As Object)
        Dim s As New XmlSerializer(obj.GetType)

        Using w As New XmlTextWriter(path, Encoding.UTF8)
            w.Formatting = Formatting.Indented
            s.Serialize(w, obj)
        End Using
    End Sub

    Public Shared Function LoadXML(Of T)(ByVal path As String) As T
        Dim s As New XmlSerializer(GetType(T))

        Using r As New XmlTextReader(path)
            Return DirectCast(s.Deserialize(r), T)
        End Using
    End Function
End Class

Public Module MainModule
    Public Const BR As String = vbCrLf
    Public Const BR2 As String = vbCrLf + vbCrLf

    Sub MsgInfo(ByVal text As String)
        Msg(text, Application.ProductName, MessageBoxIcon.Information)
    End Sub

    Sub MsgError(ByVal text As String)
        Msg(text, Application.ProductName, MessageBoxIcon.Error)
    End Sub

    Sub MsgWarn(ByVal text As String)
        Msg(text, Application.ProductName, MessageBoxIcon.Warning)
    End Sub

    Function Msg(ByVal text As String,
                 ByVal title As String,
                 ByVal icon As MessageBoxIcon) As DialogResult

        Return Msg(text, title, icon, MessageBoxButtons.OK)
    End Function

    Function Msg(ByVal text As String,
                 ByVal title As String,
                 ByVal icon As MessageBoxIcon,
                 ByVal buttons As MessageBoxButtons) As DialogResult

        Return MessageBox.Show(text, title, buttons, icon)
    End Function
End Module

Public Class RegistryHelp
    Shared Sub Write(ByVal obj As RegistryKey, ByVal key As String, ByVal name As String, ByVal value As Object)
        Dim k = obj.OpenSubKey(key, True)

        If k Is Nothing Then
            k = obj.CreateSubKey(key, RegistryKeyPermissionCheck.ReadWriteSubTree)
        End If

        k.SetValue(name, value)
        k.Close()
    End Sub

    Public Shared Sub DeleteKey(ByVal rootKey As RegistryKey, ByVal key As String)
        Dim k = rootKey.OpenSubKey(key)

        If Not k Is Nothing Then
            Dim names = k.GetSubKeyNames
            k.Close()

            For Each i In names
                DeleteKey(rootKey, key + "\" + i)
            Next

            rootKey.DeleteSubKey(key, True)
        End If
    End Sub

    Public Shared Sub DeleteValue(ByVal rootKey As RegistryKey, ByVal key As String, ByVal value As String)
        Using k = rootKey.OpenSubKey(key)
            k.DeleteValue(value, False)
        End Using
    End Sub

    Public Shared Function GetString(ByVal rootKey As RegistryKey, ByVal key As String, ByVal name As String) As String
        Return GetValue(Of String)(rootKey, key, name)
    End Function

    Public Shared Function GetValue(Of T)(ByVal rootKey As RegistryKey, ByVal key As String, ByVal name As String) As T
        Using k = rootKey.OpenSubKey(key)
            If Not k Is Nothing Then
                Dim r = k.GetValue(name)

                If Not r Is Nothing Then
                    Return DirectCast(r, T)
                End If
            End If
        End Using
    End Function
End Class