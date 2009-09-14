using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using beans;

/// <summary>
/// Summary description for FileLog
/// </summary>
public class FileLog:beans.ISystemLogger
{

    public string Filename
    {
        get;
        set;
    }

    public FileLog(string filename)
    {
        this.Filename = filename;
    }

    #region ISystemLogger Members



    public void Log(string username, string message)
    {

        FileStream fileStream = new FileStream(this.Filename, FileMode.Append, FileAccess.Write);

        StreamWriter writer = new StreamWriter(fileStream, System.Text.Encoding.UTF8);

        writer.Write(DateTime.Now.ToString("dd/MM/yyyy hh:mm - "));

        if (username != "")
            writer.Write(username);
        writer.WriteLine(message);

        writer.Close();
        fileStream.Close();
    }

    #endregion
}
