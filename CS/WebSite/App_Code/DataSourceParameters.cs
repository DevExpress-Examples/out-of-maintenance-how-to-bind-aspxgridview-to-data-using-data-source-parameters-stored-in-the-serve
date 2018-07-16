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

public class DataSourceParameters {
    string dataFile;
    string selectCommand;
    StringDictionary selectParameters;
    public DataSourceParameters(string dataFile, string selectCommand) {
        DataFile = dataFile;
        SelectComand = selectCommand;
        selectParameters = new StringDictionary();
    }
    public string DataFile {
        get { return this.dataFile; }
        set { this.dataFile = value; }
    }
    public string SelectComand {
        get { return this.selectCommand; }
        set { this.selectCommand = value; }
    }
    public StringDictionary SelectParameters {
        get { return this.selectParameters; }
    }
}
