using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NHibernate;
using System.Data;
using System.Data.SqlClient;

public partial class chat_chat : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["chatHistory"] == null)
            Session["chatHistory"] = new Dictionary<string, string>();
        if (Session["openChatBoxes"] == null)
            Session["openChatBoxes"] = new Dictionary<string, DateTime>();
        if (Session["tsChatBoxes"] == null)
            Session["tsChatBoxes"] = new Dictionary<string, bool>();

        if (Request["action"] == "chatheartbeat") { ChatHeartbeat(); }
        if (Request["action"] == "sendchat") { SendChat(); }
        if (Request["action"] == "closechat") { CloseChat(); }
        if (Request["action"] == "startchatsession") { StartChatSession(); }

        
    }

    protected string Sanitize(string message)
    {
        message = HttpUtility.HtmlEncode(message);
        message = message.Replace("\n\r", "\n");
        message = message.Replace("\r\n", "\n");
        message = message.Replace("\n", "<br />");

        return message;
    }



    protected void ChatHeartbeat()
    {
	    ISession session = (ISession)Context.Items[Constant.NHibernateSessionSign];
        Dictionary<string, DateTime> openChatBoxes = Session["openChatBoxes"] as Dictionary<string, DateTime>;
        Dictionary<string, string> chatHistory = Session["chatHistory"] as Dictionary<string, string>;
        Dictionary<string, bool> tsChatBoxes = Session["tsChatBoxes"] as Dictionary<string, bool>;
        string items = "";
        IDbCommand cmdGetChatHistory = session.Connection.CreateCommand();
        
        cmdGetChatHistory.CommandText = "SELECT * FROM chat where ([to]=@username AND recd = 0) order by id ASC";
        IDataParameter param = cmdGetChatHistory.CreateParameter();
        param.DbType = DbType.String;
        param.ParameterName = "@username";
        param.Value = Session[Constant.Username];
        cmdGetChatHistory.Parameters.Add(param);

        session.Transaction.Enlist(cmdGetChatHistory);

        IDataReader row = cmdGetChatHistory.ExecuteReader();
        while (row.Read())
        {
            string message = Sanitize((string)row["message"]);
            string from = (string)row["from"];
            
            if (!openChatBoxes.ContainsKey(from) && chatHistory.ContainsKey(from))
                items = chatHistory[from];

            items += string.Format("&DFDF\"s\": \"0\", \"f\":\"{0}\", \"m\": \"{1}\"&FDFD,", (string)row["from"], message).Replace("&DFDF", "{").Replace("&FDFD", "}");

            if (!chatHistory.ContainsKey(from))
                chatHistory.Add(from, "");
            chatHistory[from] += string.Format("&DFDF\"s\": \"0\", \"f\": \"{0}\", \"m\": \"{1}\"&FDFD,", from, message).Replace("&DFDF", "{").Replace("&FDFD", "}");

            tsChatBoxes.Remove(from);
            openChatBoxes[from] = (DateTime)row["sent"];
        }
        row.Close();
        

        if (openChatBoxes.Count > 0)
        {
            foreach (string chatbox in openChatBoxes.Keys)
            {
                if (tsChatBoxes.ContainsKey(chatbox))
                {
                    DateTime time = openChatBoxes[chatbox];
                    TimeSpan t = DateTime.Now - time;
                    string message = string.Format("Sent at {0}", time);

                    if (t > TimeSpan.FromMinutes(3))
                    {
                        items += string.Format("&DFDF\"s\": \"2\",\"f\": \"{0}\", \"m\": \"{1}\"&FDFD,", chatbox, message).Replace("&DFDF", "{").Replace("&FDFD", "}");
                        if (chatHistory.ContainsKey(chatbox))
                            chatHistory.Add(chatbox, "");

                        chatHistory[chatbox] += string.Format("&DFDF\"s\": \"2\", \"f\": \"{0}\", \"m\": \"{1}\"&FDFD,", chatbox, message).Replace("&DFDF", "{").Replace("&FDFD", "}");

                        tsChatBoxes[chatbox] = true;
                    }
                }
            }
        }

        IDbCommand cmdUpdateRead = session.Connection.CreateCommand();
        cmdUpdateRead.CommandText = "update chat set recd = 1 where [to] = @username and recd = 0";
        IDataParameter paramUsername = cmdUpdateRead.CreateParameter();
        paramUsername.DbType = DbType.String;
        paramUsername.ParameterName = "@username";
        paramUsername.Value = Session[Constant.Username];
        cmdUpdateRead.Parameters.Add(paramUsername);
        session.Transaction.Enlist(cmdUpdateRead);
        cmdUpdateRead.ExecuteNonQuery();

        Response.ContentType = "application/json";
        Response.Write(string.Format("&DFDF		\"items\": [			{0}        ]&FDFD", items).Replace("&DFDF", "{").Replace("&FDFD", "}"));
        Response.End();
    }



    protected void SendChat()
    {
        ISession session = (ISession)Context.Items[Constant.NHibernateSessionSign];
        string from = (string)Session[Constant.Username];
	    string to = Request["to"];
	    string message = Request["message"];
        Dictionary<string, DateTime> openChatBoxes = Session["openChatBoxes"] as Dictionary<string, DateTime>;
        Dictionary<string, string> chatHistory = Session["chatHistory"] as Dictionary<string, string>;
        Dictionary<string, bool> tsChatBoxes = Session["tsChatBoxes"] as Dictionary<string, bool>;

        openChatBoxes[to] = DateTime.Now;
        string messagesan = this.Sanitize(message);
        if (chatHistory.ContainsKey(to))
            chatHistory[to] = "";

        chatHistory[to] += string.Format("&DFDF			\"s\": \"1\",			\"f\": \"{0}\",			\"m\": \"{1}\"	   &FDFD,", to, messagesan).Replace("&DFDF", "{").Replace("&FDFD", "}");
        tsChatBoxes.Remove(to);

        IDbCommand cmdInsertChat = session.Connection.CreateCommand();
        cmdInsertChat.CommandText = "insert into chat ([from],[to],message,sent) values (@from, @to, @message, @time)";

        IDataParameter paramFrom = cmdInsertChat.CreateParameter();
        paramFrom.DbType = DbType.String;
        paramFrom.ParameterName = "@from";
        paramFrom.Value = from;
        cmdInsertChat.Parameters.Add(paramFrom);

        IDataParameter paramTo = cmdInsertChat.CreateParameter();
        paramTo.DbType = DbType.String;
        paramTo.ParameterName = "@to";
        paramTo.Value = to;
        cmdInsertChat.Parameters.Add(paramTo);

        IDataParameter paramMessage = cmdInsertChat.CreateParameter();
        paramMessage.DbType = DbType.String;
        paramMessage.ParameterName = "@message";
        paramMessage.Value = message;
        cmdInsertChat.Parameters.Add(paramMessage);

        IDataParameter paramTime = cmdInsertChat.CreateParameter();
        paramTime.DbType = DbType.DateTime;
        paramTime.ParameterName = "@time";
        paramTime.Value = DateTime.Now;
        cmdInsertChat.Parameters.Add(paramTime);

        session.Transaction.Enlist(cmdInsertChat);
        cmdInsertChat.ExecuteNonQuery();

        Response.End();
    }

    protected void CloseChat()
    {
        Dictionary<string, DateTime> openChatBoxes = Session["openChatBoxes"] as Dictionary<string, DateTime>;
        openChatBoxes.Remove(Request["chatbox"]);
        Response.End();
    }

    protected string ChatBoxSession(string chatbox)
    {
        string items = string.Empty;

        Dictionary<string, string> chatHistory = Session["chatHistory"] as Dictionary<string, string>;
        if (chatHistory.ContainsKey(chatbox))
            items = chatHistory[chatbox];

	    return items;
    }

    protected void StartChatSession()
    {
        string items = string.Empty;

        Dictionary<string, DateTime> openChatBoxes = Session["openChatBoxes"] as Dictionary<string, DateTime>;
        if (openChatBoxes.Count > 0)
            foreach (string chatbox in openChatBoxes.Keys)
                items += ChatBoxSession(chatbox);

        Response.ContentType = "application/json";
        Response.Write("{" + string.Format("\r\n		\"username\": \"{0}\",\r\n		\"items\": [\r\n			{1}\r\n        ]", Session[Constant.Username], items) + "}");
        Response.End();

    }

    
}
