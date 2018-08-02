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
Imports DevExpress.Web.ASPxGridView
Imports DevExpress.Web.ASPxEditors

Partial Public Class _Default
    Inherits System.Web.UI.Page

    Private Const SessionDataSource1 As String = "SessionDataSource1Key"
    Private Const SessionDataSource2 As String = "SessionDataSource2Key"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        If Session(SessionDataSource1) Is Nothing Then
            Dim parameters1 As New DataSourceParameters("~/App_Data/nwind.mdb", "SELECT [CategoryID], [CategoryName], [Description] FROM [Categories]")
            Session(SessionDataSource1) = parameters1
        End If
        If Session(SessionDataSource2) Is Nothing Then
            Dim parameters2 As New DataSourceParameters("~/App_Data/nwind.mdb", "SELECT [ProductID], [ProductName], [CategoryID], [UnitPrice], [QuantityPerUnit] FROM [Products] WHERE [CategoryID] = @CategoryID")
            parameters2.SelectParameters.Add("CategoryID", "1")
            Session(SessionDataSource2) = parameters2
        End If
        ASPxGridView1.DataBind()
        ASPxGridView2.DataBind()
    End Sub
    Protected Sub ASPxGridView1_DataBinding(ByVal sender As Object, ByVal e As EventArgs)
        TryCast(sender, ASPxGridView).DataSource = RestoreAccessDataSourceFormSessionParameters(SessionDataSource1)
    End Sub
    Protected Sub ASPxComboBox1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        Dim comboBox As ASPxComboBox = TryCast(sender, ASPxComboBox)
        If comboBox.SelectedIndex = -1 Then
            Return
        End If
        Dim parameters As DataSourceParameters = TryCast(Session(SessionDataSource2), DataSourceParameters)
        parameters.SelectParameters("CategoryID") = comboBox.SelectedItem.Value.ToString()
        ASPxGridView2.DataBind()
    End Sub
    Protected Sub ASPxGridView2_DataBinding(ByVal sender As Object, ByVal e As EventArgs)
        TryCast(sender, ASPxGridView).DataSource = RestoreAccessDataSourceFormSessionParameters(SessionDataSource2)
    End Sub
    Protected Function RestoreAccessDataSourceFormSessionParameters(ByVal dataSourceParametersSessionKey As String) As AccessDataSource
        Dim parameters As DataSourceParameters = TryCast(Session(dataSourceParametersSessionKey), DataSourceParameters)
        If parameters Is Nothing Then
            Return Nothing
        End If
        Dim dataSource As New AccessDataSource(parameters.DataFile, parameters.SelectComand)
        For Each key As String In parameters.SelectParameters.Keys
            dataSource.SelectParameters.Add(key, parameters.SelectParameters(key))
        Next key
        Return dataSource
    End Function
End Class
