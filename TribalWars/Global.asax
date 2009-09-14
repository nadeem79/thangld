<%@ Application Language="C#" %>

<script runat="server">
    
    void Application_Start(object sender, EventArgs e) 
    {
        // Code that runs on application startup
        //log4net.Config.XmlConfigurator.Configure();
        HibernatingRhinos.NHibernate.Profiler.Appender.NHibernateProfiler.Initialize();
        Application.Add(Constant.UserLoginCount, 0);
        NHibernate.ISession session = NHibernateHelper.CreateSession();
        beans.TribalWarsEngine.Start(session);
        session.Close();

        beans.ISystemLogger fileLog = new FileLog(Server.MapPath("~/systemlog.txt"));

        beans.ServicesList.LogService.SystemLoggers.Add(fileLog);
            
    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  Code that runs on application shutdown

    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        // Code that runs when an unhandled error occurs

    }

    void Session_Start(object sender, EventArgs e) 
    {
        Application.Lock();
        int count = (int)Application[Constant.UserLoginCount];
        count++;
        Application[Constant.UserLoginCount] = count;
        Application.UnLock();
        // Code that runs when a new session is started

    }

    void Session_End(object sender, EventArgs e) 
    {
        Application.Lock();
        int count = (int)Application[Constant.UserLoginCount];
        count--;
        Application[Constant.UserLoginCount] = count;
        Application.UnLock();
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }

    void Application_BeginRequest(object sender, EventArgs e)
    {
        //HttpApplication app = (HttpApplication)sender;
        //string acceptEncoding = app.Request.Headers["Accept-Encoding"];
        //System.IO.Stream prevUncompressedStream = app.Response.Filter;

        //if (acceptEncoding == null || acceptEncoding.Length == 0)
        //    return;

        //acceptEncoding = acceptEncoding.ToLower();

        //if (acceptEncoding.Contains("gzip"))
        //{
        //    // gzip
        //    app.Response.Filter = new System.IO.Compression.GZipStream(prevUncompressedStream, System.IO.Compression.CompressionMode.Compress);
        //    app.Response.AppendHeader("Content-Encoding",
        //        "gzip");
        //}
        //else if (acceptEncoding.Contains("deflate"))
        //{
        //    // defalte
        //    app.Response.Filter = new System.IO.Compression.DeflateStream(prevUncompressedStream, System.IO.Compression.CompressionMode.Compress);
        //    app.Response.AppendHeader("Content-Encoding",
        //        "deflate");
        //}
    }
       
</script>
