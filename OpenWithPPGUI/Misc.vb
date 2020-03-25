
Imports System.IO
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Text

Imports Microsoft.Win32
Imports Microsoft.VisualBasic

Public Class g
    Shared Property Settings As AppSettings

    Private Shared SettingsDirValue As String

    Shared Property SettingsDir As String
        Get
            If SettingsDirValue = "" Then
                SettingsDirValue = RegistryHelp.GetString(Registry.CurrentUser, "Software\OpenWithPP", "SettingsDir")

                If Not Directory.Exists(SettingsDirValue) Then
                    SettingsDirValue = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\Open with++\"

                    If Not Directory.Exists(SettingsDirValue) Then
                        Directory.CreateDirectory(SettingsDirValue)
                    End If
                End If

                If Not SettingsDirValue.EndsWith("\") Then
                    SettingsDirValue += "\"
                End If
            End If

            Return SettingsDirValue
        End Get
        Set(value As String)
            SettingsDirValue = value
            RegistryHelp.SetValue(Registry.CurrentUser, "Software\OpenWithPP", "SettingsDir", value)
        End Set
    End Property

    Shared Sub LoadSettings()
        If File.Exists(SettingsDir + "Settings.xml") Then
            g.Settings = LoadXML(Of AppSettings)(SettingsDir + "Settings.xml")

            'backward compatibility
            For Each item In g.Settings.Items
                If item.AllFiles Then
                    item.FileTypesDisplay = "*.*"
                    item.AllFiles = False
                End If
            Next
        Else
            g.Settings = New AppSettings
            g.Settings.Macros.Add(New Macro() With {.Name = "%video%", .Value = "mpg avi vob mp4 d2v mkv avs 264 mov wmv part flv ifo h264 asf webm dgi mpeg mpv y4m avc hevc 265 h265 m2v m2ts vpy mts webm ts m4v part"})
            g.Settings.Macros.Add(New Macro() With {.Name = "%audio%", .Value = "mp2 mp3 ac3 wav w64 m4a dts dtsma dtshr dtshd eac3 thd thd+ac3 ogg mka aac opus flac mpa"})
            g.Settings.Macros.Add(New Macro() With {.Name = "%subtitle%", .Value = "sub sup idx ass aas srt"})
            g.Settings.Macros.Add(New Macro() With {.Name = "%image%", .Value = "png jpg jpeg gif bmp"})
        End If
    End Sub

    Shared Sub SaveSettings()
        If Not Directory.Exists(SettingsDir) Then
            Directory.CreateDirectory(SettingsDir)
        End If

        SaveXML(SettingsDir + "Settings.xml", g.Settings)
    End Sub

    Shared Sub SaveXML(path As String, obj As Object)
        Using writer As New XmlTextWriter(path, Encoding.UTF8)
            writer.Formatting = Formatting.Indented
            Dim serializer As New XmlSerializer(obj.GetType)
            serializer.Serialize(writer, obj)
        End Using
    End Sub

    Shared Function LoadXML(Of T)(path As String) As T
        Using reader As New XmlTextReader(path)
            Dim serializer As New XmlSerializer(GetType(T))
            Return DirectCast(serializer.Deserialize(reader), T)
        End Using
    End Function
End Class

<Serializable()>
Public Class AppSettings
    Public Sub New()
    End Sub

    <XmlArrayItem("Item", GetType(Item))>
    Public Items As New List(Of Item)

    <XmlArrayItem("Macro", GetType(Macro))>
    Public Macros As New List(Of Macro)
End Class

Public Class Macro
    Property Name As String = ""
    Property Value As String = ""
End Class

<Serializable()>
Public Class Item
    Implements IComparable

    Public AllFiles As Boolean
    Public Arguments As String = ""
    Public Directories As Boolean
    Public FileTypes As String = ""
    Public FileTypesDisplay As String = ""
    Public HideWindow As Boolean
    Public IconFile As String = ""
    Public IconIndex As Integer
    Public Name As String = ""
    Public Path As String = ""
    Public RunAsAdmin As Boolean
    Public SubMenu As Boolean = True
    Public WorkingDirectory As String = ""

    Public Function CompareTo(obj As Object) As Integer Implements System.IComparable.CompareTo
        Return Name.CompareTo(DirectCast(obj, Item).Name)
    End Function
End Class

Public Module MainModule
    Public Const BR As String = vbCrLf
    Public Const BR2 As String = vbCrLf + vbCrLf

    Sub MsgInfo(text As Object)
        Msg(text, Nothing, MessageBoxIcon.Information)
    End Sub

    Sub MsgError(text As Object)
        Msg(text, Nothing, MessageBoxIcon.Error)
    End Sub

    Sub MsgWarn(text As Object)
        Msg(text, Nothing, MessageBoxIcon.Warning)
    End Sub

    Function Msg(text As Object, title As String, icon As MessageBoxIcon) As DialogResult
        Return Msg(text, title, icon, MessageBoxButtons.OK)
    End Function

    Function Msg(text As Object, title As String, icon As MessageBoxIcon,
                 buttons As MessageBoxButtons) As DialogResult

        If title = "" Then
            title = Application.ProductName
        End If

        Return MessageBox.Show(CStr(text), title, buttons, icon)
    End Function
End Module

Public Class RegistryHelp
    Shared Sub SetValue(key As RegistryKey, subKeyName As String, valueName As String, value As Object)
        Dim subKey = key.OpenSubKey(subKeyName, True)

        If subKey Is Nothing Then
            subKey = key.CreateSubKey(subKeyName, RegistryKeyPermissionCheck.ReadWriteSubTree)
        End If

        subKey.SetValue(valueName, value)
        subKey.Close()
    End Sub

    Shared Function GetString(rootKey As RegistryKey, key As String, name As String) As String
        Return GetValue(Of String)(rootKey, key, name)
    End Function

    Shared Function GetValue(Of T)(rootKey As RegistryKey, subKeyName As String, valueName As String) As T
        Using subKey = rootKey.OpenSubKey(subKeyName)
            If Not subKey Is Nothing Then
                Dim value = subKey.GetValue(valueName)

                If Not value Is Nothing Then
                    Return DirectCast(value, T)
                End If
            End If
        End Using
    End Function
End Class
