﻿using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;

/// <summary>
/// Summary description for BussinessLayerService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class BussinessLayerService : System.Web.Services.WebService
{

    public BussinessLayerService()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
        //DataLayer.BussinessLayerService service = new DataLayer.BussinessLayerService();
        //service.
    }

    [WebMethod]
    public string HelloWorld()
    {
        
        return "Hello World";
    }

}

