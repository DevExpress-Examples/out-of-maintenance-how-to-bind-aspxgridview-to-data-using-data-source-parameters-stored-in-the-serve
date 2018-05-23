<%@ Page Language="vb" AutoEventWireup="true" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<%@ Register Assembly="DevExpress.Web.ASPxGridView.v9.1" Namespace="DevExpress.Web.ASPxGridView"
    TagPrefix="dxwgv" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v9.1" Namespace="DevExpress.Web.ASPxEditors"
    TagPrefix="dxe" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>How to bind ASPxGridView to data using data source parameters stored in server
        session</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>
                Data source without select parameters</h2>
            <dxwgv:ASPxGridView ID="ASPxGridView1" runat="server" OnDataBinding="ASPxGridView1_DataBinding">
            </dxwgv:ASPxGridView>
            <h2>
                Data source with select parameters</h2>
            <table>
                <tr>
                    <td>
                        <dxe:ASPxLabel ID="ASPxLabel1" runat="server" Text="Category id: ">
                        </dxe:ASPxLabel>
                    </td>
                    <td>
                        <dxe:ASPxComboBox runat="server" ID="ASPxComboBox1" AutoPostBack="true" SelectedIndex="0"
                            DataSourceID="AccessDataSource1" ValueType="System.String" ValueField="CategoryID"
                            TextField="CategoryID" OnSelectedIndexChanged="ASPxComboBox1_SelectedIndexChanged">
                        </dxe:ASPxComboBox>
                    </td>
                </tr>
            </table>
            <dxwgv:ASPxGridView ID="ASPxGridView2" runat="server" OnDataBinding="ASPxGridView2_DataBinding">
            </dxwgv:ASPxGridView>
        </div>
    </form>
    <asp:AccessDataSource ID="AccessDataSource1" runat="server" DataFile="~/App_Data/nwind.mdb"
        SelectCommand="SELECT [CategoryID] FROM [Categories]"></asp:AccessDataSource>
    <asp:AccessDataSource ID="AccessDataSource2" runat="server" DataFile="~/App_Data/nwind.mdb"
        SelectCommand="SELECT [ProductID], [ProductName], [CategoryID], [UnitPrice], [QuantityPerUnit] FROM [Products]">
    </asp:AccessDataSource>
</body>
</html>
