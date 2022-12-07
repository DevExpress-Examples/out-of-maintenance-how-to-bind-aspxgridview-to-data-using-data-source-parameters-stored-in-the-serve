using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Specialized;
using DevExpress.Web;

public partial class _Default : System.Web.UI.Page 
{
    const string SessionDataSource1 = "SessionDataSource1Key";
    const string SessionDataSource2 = "SessionDataSource2Key";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session[SessionDataSource1] == null) {
            DataSourceParameters parameters1 = new DataSourceParameters("~/App_Data/nwind.mdb",
                "SELECT [CategoryID], [CategoryName], [Description] FROM [Categories]");
            Session[SessionDataSource1] = parameters1;
        }
        if (Session[SessionDataSource2] == null) {
            DataSourceParameters parameters2 = new DataSourceParameters("~/App_Data/nwind.mdb",
                "SELECT [ProductID], [ProductName], [CategoryID], [UnitPrice], [QuantityPerUnit] FROM [Products] WHERE [CategoryID] = @CategoryID");
            parameters2.SelectParameters.Add("CategoryID", "1");
            Session[SessionDataSource2] = parameters2;
        }
        ASPxGridView1.DataBind();
        ASPxGridView2.DataBind();
    }
    protected void ASPxGridView1_DataBinding(object sender, EventArgs e) {
        (sender as ASPxGridView).DataSource = RestoreAccessDataSourceFormSessionParameters(SessionDataSource1);
    }
    protected void ASPxComboBox1_SelectedIndexChanged(object sender, EventArgs e) {
        ASPxComboBox comboBox = sender as ASPxComboBox;
        if(comboBox.SelectedIndex == -1) return;
        DataSourceParameters parameters = Session[SessionDataSource2] as DataSourceParameters;
        parameters.SelectParameters["CategoryID"] = comboBox.SelectedItem.Value.ToString();
        ASPxGridView2.DataBind();
    }
    protected void ASPxGridView2_DataBinding(object sender, EventArgs e) {
        (sender as ASPxGridView).DataSource = RestoreAccessDataSourceFormSessionParameters(SessionDataSource2);
    }
    protected AccessDataSource RestoreAccessDataSourceFormSessionParameters(string dataSourceParametersSessionKey) {
        DataSourceParameters parameters = Session[dataSourceParametersSessionKey] as DataSourceParameters;
        if (parameters == null) return null;
        AccessDataSource dataSource = new AccessDataSource(parameters.DataFile, parameters.SelectComand);
        foreach (string key in parameters.SelectParameters.Keys)
            dataSource.SelectParameters.Add(key, parameters.SelectParameters[key]);
        return dataSource;
    }
}
