Imports System
Imports System.Data
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports System.Collections.Specialized

Public Class DataSourceParameters

    Private dataFile_Renamed As String
    Private selectCommand As String

    Private selectParameters_Renamed As StringDictionary
    Public Sub New(ByVal dataFile As String, ByVal selectCommand As String)
        Me.DataFile = dataFile
        SelectComand = selectCommand
        selectParameters_Renamed = New StringDictionary()
    End Sub
    Public Property DataFile() As String
        Get
            Return Me.dataFile_Renamed
        End Get
        Set(ByVal value As String)
            Me.dataFile_Renamed = value
        End Set
    End Property
    Public Property SelectComand() As String
        Get
            Return Me.selectCommand
        End Get
        Set(ByVal value As String)
            Me.selectCommand = value
        End Set
    End Property
    Public ReadOnly Property SelectParameters() As StringDictionary
        Get
            Return Me.selectParameters_Renamed
        End Get
    End Property
End Class
