using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NHibernate;
using System.Data;
using System.Collections.Specialized;

public partial class chat_cometchat_receive : System.Web.UI.Page
{

    protected ListDictionary response = new ListDictionary();
    protected int TimeStamp
    {
        get;
        set;
    }

    protected void GetStatus()
    {
        ISession session = (ISession)Context.Items[Constant.NHibernateSessionSign];
        int userId = (int)Session[Constant.NormalUserSessionSign];

        IDbCommand cmdGetStatus = session.Connection.CreateCommand();
        cmdGetStatus.CommandText = "select chat_status.message, chat_status.status from chat_status where user_id = @userid";
        IDbDataParameter paramUserId = cmdGetStatus.CreateParameter();
        paramUserId.DbType = DbType.Int32;
        paramUserId.ParameterName = "@userid";
        paramUserId.Value = userId;
        cmdGetStatus.Parameters.Add(paramUserId);
        session.Transaction.Enlist(cmdGetStatus);

        IDataReader readerGetStatus = cmdGetStatus.ExecuteReader(CommandBehavior.SingleRow);
        ListDictionary chat = new ListDictionary();
        if (readerGetStatus.Read())
        {
            chat.Add("message", readerGetStatus["message"]);
            chat.Add("status", readerGetStatus["status"]);
        }
        else
        {
            chat.Add("message", string.Empty);
            chat.Add("status", string.Empty);
        }
        readerGetStatus.Close();

        if (chat["status"] == string.Empty)
            chat["status"] = "available";
        else if (chat["status"] == "offline")
            ((ListDictionary)Session["chat_sessionvars"])["buddylist"] = 0;

        if (chat["message"]==string.Empty)
		    chat["message"] = "I'm " + TextUtility.UppercaseFirst(chat["status"].ToString());

        ListDictionary status = new ListDictionary();
        status["message"] = chat["message"];
        status["status"] = chat["status"];

        response["userstatus"] = status;


    }

    protected void GetBuddyList()
    {
        ISession session = (ISession)Context.Items[Constant.NHibernateSessionSign];
        int userId = (int)Session[Constant.NormalUserSessionSign];

        DateTime time = DateTime.Now;

        if ((Session["cometchat_buddytime"] == null) || (Request["initialize"] == "1") || (Session["cometchat_buddytime"] != null) && ((DateTime.Now - (DateTime)Session["cometchat_buddytime"]).Seconds > 60))
        {
            IDbCommand cmdGetBuddy = session.Connection.CreateCommand();
            cmdGetBuddy.CommandText = "select users.id as userid, user.username, user.last_update, chat_status.message, chat_status.status from userlist join users on  userlist.relationid = users.id left join chat_status on users.id = chat_status.userid where userlist.friend = 'yes' and userlist.userid = @userId order by username asc";
            IDbDataParameter paramUserId = cmdGetBuddy.CreateParameter();
            paramUserId.DbType = DbType.Int32;
            paramUserId.ParameterName = "@userid";
            paramUserId.Value = userId;
            cmdGetBuddy.Parameters.Add(paramUserId);
            session.Transaction.Enlist(cmdGetBuddy);

            IDataReader readerGetBuddyList = cmdGetBuddy.ExecuteReader();
            ListDictionary chat = new ListDictionary();
            IList<ListDictionary> buddyList = new List<ListDictionary>();
            

            while (readerGetBuddyList.Read())
            {
                string status = readerGetBuddyList["status"].ToString();

                if ((time - (DateTime)readerGetBuddyList["last_update"]).Seconds < 120 && status != "invisible" && status != "offline")
                {
                    if (status != "busy")
                        status = "available";
                }
                else
                    status = "offline";

                string message = readerGetBuddyList["message"].ToString();
                if (string.IsNullOrEmpty(message))
                    message = "I'm " + TextUtility.UppercaseFirst(status);


                ListDictionary buddy = new ListDictionary();
                buddy["id"] = readerGetBuddyList["userid"];
                buddy["name"] = readerGetBuddyList["username"];
                buddy["status"] = status;
                buddy["message"] = message;
                buddy["time"] = readerGetBuddyList["last_update"];
                buddyList.Add(buddy);
            }
            readerGetBuddyList.Close();

            Session["cometchat_buddytime"] = time;

            if (buddyList.Count > 0)
                response["buddylist"] = buddyList;

        }
    }

    protected void GetLastTimestamp()
    {
        if (this.TimeStamp == 0)
        {

        }
    }

    protected void FetchMessages()
    {
        ISession session = (ISession)Context.Items[Constant.NHibernateSessionSign];
        string username = (string)Session[Constant.Username];
	    int timestamp = 0;

        IDbCommand cmdGetMessages = session.Connection.CreateCommand();
        cmdGetMessages.CommandText = "select chat.id, chat.from_user, chat.to_user, chat.message, chat.sent, chat.read from chat where (chat.to_user = @username1 or chat.from_user = @username2) and (chat.id > @timestamp or (chat.to_user = @username3 and chat.unread != true)) order by chat.id";
	
        IDbDataParameter paramUsername1 = cmdGetMessages.CreateParameter();
        paramUsername1.DbType = DbType.String;
        paramUsername1.ParameterName = "@username1";
        paramUsername1.Value = username;
        IDbDataParameter paramUsername2 = cmdGetMessages.CreateParameter();
        paramUsername2.DbType = DbType.String;
        paramUsername2.ParameterName = "@username2";
        paramUsername2.Value = username;
        IDbDataParameter paramUsername3 = cmdGetMessages.CreateParameter();
        paramUsername3.DbType = DbType.String;
        paramUsername3.ParameterName = "@username3";
        paramUsername3.Value = username;
        IDbDataParameter paramTimeStamp = cmdGetMessages.CreateParameter();
        paramTimeStamp.DbType = DbType.Int32;
        paramTimeStamp.ParameterName = "@timestamp";
        paramTimeStamp.Value = Request["timestamp"];
        cmdGetMessages.Parameters.Add(paramUsername1);
        cmdGetMessages.Parameters.Add(paramUsername2);
        cmdGetMessages.Parameters.Add(paramUsername3);
        cmdGetMessages.Parameters.Add(paramTimeStamp);

        session.Transaction.Enlist(cmdGetMessages);
        IDataReader readerGetMessages = cmdGetMessages.ExecuteReader();
        IList<ListDictionary> messages = new List<ListDictionary>();
        while (readerGetMessages.Read())
        {
            int self = 0;
            int old = 0;
            if (readerGetMessages["from"]==username)
            {
                self = 1;
                old = 1;
            }
            
            ListDictionary message = new ListDictionary();
            message["id"] = readerGetMessages["id"];
            message["from"] = readerGetMessages["from"];
            message["message"] = readerGetMessages["message"];
            message["self"] = self;
            message["old"] = old;
            messages.Add(message);

            if (self==0 &&old==0 && (bool)readerGetMessages["unread"])
            {
                if (Session["cometchat_user_" + message["from"]]==null)
                    Session["cometchat_user_" + message["from"]] = new List<ListDictionary>();

                ListDictionary messageFrom = new ListDictionary();
                messageFrom["id"] = readerGetMessages["id"];
                messageFrom["from"] = readerGetMessages["from_user"];
                messageFrom["message"] = readerGetMessages["message"];
                messageFrom["self"] = 0;
                messageFrom["old"] = 1;

                ((List<ListDictionary>)Session["cometchat_user_" + message["from"]]).Add(messageFrom);

            }

            timestamp = (int)readerGetMessages["id"];
                
        }
        
        if (messages.Count>0) 
        {
            IDbCommand cmdSetReadAll = session.Connection.CreateCommand();
		    cmdSetReadAll.CommandText = "update chat set chat.unread = false where chat.to_user = @username and cometchat.id <= @timestamp";
            paramUsername1 = cmdSetReadAll.CreateParameter();
            paramUsername1.DbType = DbType.String;
            paramUsername1.ParameterName = "@username";
            paramUsername1.Value = username;
            paramTimeStamp = cmdSetReadAll.CreateParameter();
            paramTimeStamp.DbType = DbType.Int32;
            paramTimeStamp.ParameterName = "@timestamp";
            paramTimeStamp.Value = Request["timestamp"];

            cmdSetReadAll.Parameters.Add(paramUsername1);
            cmdSetReadAll.Parameters.Add(paramTimeStamp);

            session.Transaction.Enlist(cmdSetReadAll);
            cmdSetReadAll.ExecuteNonQuery();
	    }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["chat_sessionvars"] == null)
            Session["chat_sessionvars"] = new ListDictionary();



    }
}
