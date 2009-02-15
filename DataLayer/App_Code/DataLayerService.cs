using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.Configuration;

/// <summary>
/// Summary description for DataLayerService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class DataLayerService : System.Web.Services.WebService
{
    private static TribalWarsMappingDataContext data = new TribalWarsMappingDataContext(ConfigurationManager.ConnectionStrings[0].ConnectionString);

    public static TribalWarsMappingDataContext Data
    {
        get { return DataLayerService.data; }
    }


    public DataLayerService()
    {

        

    }

    [WebMethod]
    public TribalWarsMappingDataContext GetData()
    {
        return data;
    }

    [WebMethod]
    public void SetData(TribalWarsMappingDataContext data)
    {
        DataLayerService.data = data;
    }

    

}

