using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NHibernate;
using System.Data;

public partial class chat_chat : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request["action"] == "chatheartbeat") { ChatHeartbeat(); }
        if (Request["action"] == "sendchat") { SendChat(); }
        if (Request["action"] == "closechat") { CloseChat(); }
        if (Request["action"] == "startchatsession") { StartChatSession(); }

        if (Session["chatHistory"] == null)
            Session["chatHistory"] = new Dictionary<string, string>();
        if (Session["openChatBoxes"] == null)
            Session["openChatBoxes"] = new Dictionary<string, DateTime>();
        if (Session["tsChatBoxes"] == null)
            Session["tsChatBoxes"] = new Dictionary<string, bool>();
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
        
        cmdGetChatHistory.CommandText = "SELECT * FROM chat where (chat.to=@username AND recd = 0) order by id ASC";
        IDataParameter param = cmdGetChatHistory.CreateParameter();
        param.DbType = DbType.String;
        param.ParameterName = "@username";
        param.Value = Session[Constant.Username];
        cmdGetChatHistory.Parameters.Add(param);

        IDataReader rdrChatHistory = cmdGetChatHistory.ExecuteReader();
        while (rdrChatHistory.Read())
        {
            string message = Sanitize((string)rdrChatHistory["message"]);
            string from = (string)rdrChatHistory["from"];
            
            if (!openChatBoxes.ContainsKey(from) && chatHistory.ContainsKey(from))
                items = chatHistory[from];
            
            items += string.Format("{\"s\": \"0\", \"f\":\"{{0}}\", \"m\": \"{{1}}\"},", (string)rdrChatHistory["from"], message);

            if (!chatHistory.ContainsKey(from))
                chatHistory.Add(from, "");
            chatHistory[from] += string.Format("{\"s\": \"0\", \"f\": \"{{0}}\", \"m\": \"{{1}}\"},", from, message);

            tsChatBoxes.Remove(from);
            openChatBoxes[from] = (DateTime)rdrChatHistory["sent"];
        }
        rdrChatHistory.Close();

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
                        items += string.Format("{\"s\": \"2\",\"f\": \"{0}\", \"m\": \"{{1}}\"},", chatbox, message);
                        if (chatHistory.ContainsKey(chatbox))
                            chatHistory.Add(chatbox, "");

                        chatHistory[chatbox] += string.Format("{\"s\": \"2\", \"f\": \"{0}\", \"m\": \"{{1}}\"},", chatbox, message);

                        tsChatBoxes[chatbox] = true;
                    }
                }
            }
        }

        IDbCommand cmdUpdateRead = session.Connection.CreateCommand();
        cmdUpdateRead.CommandText = "update chat set recd = 1 where chat.to = @username and recd = 0";
        IDataParameter paramUsername = cmdUpdateRead.CreateParameter();
        paramUsername.DbType = DbType.String;
        paramUsername.ParameterName = "@username";
        paramUsername.Value = Session[Constant.Username];
        cmdUpdateRead.Parameters.Add(paramUsername);
        cmdUpdateRead.ExecuteNonQuery();

        Response.ContentType = "application/json";
        Response.Write(string.Format("{		\"items\": [			{0}        ]}", items));
        Response.End();
    }



    protected void SendChat()
    {

    }

    protected void CloseChat()
    {

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
        Response.Write(string.Format("{		\"username\": \"{0}\",		\"items\": [			{1}        ]}", Session[Constant.Username], items));
        Response.End();

    }

    
}
