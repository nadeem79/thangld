using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

/// <summary>
/// Summary description for Pager
/// </summary>
public class Pager
{

    public int RowCount
    {
        get;
        set;
    }
    public int CurrentPage
    {
        get;
        set;
    }

    public int PageSize
    {
        get;
        set;
    }

    public int PageCount
    {
        get;
        set;
    }

    public int FirstRow
    {
        get;
        set;
    }
    public int LastRow
    {
        get;
        set;
    }
    public string Url
    {
        get;
        protected set;
    }
    public string FirstUrl
    {
        get;
        protected set;
    }
    public string LastUrl
    {
        get;
        protected set;
    }
    public string NextUrl
    {
        get;
        protected set;
    }
    public string PreviousUrl
    {
        get;
        protected set;
    }
    public int NextPage
    {
        get;
        protected set;
    }
    public int PreviousPage
    {
        get;
        protected set;
    }
    public int FrameSize
    {
        get;
        set;
    }
    public Dictionary<int, string> Urls
    {
        get;
        set;
    }

    public Pager(int row, int page, int pageSize, int frameSize)
    {
        this.RowCount = Math.Max(row, 0);
        this.PageSize = pageSize;
        this.PageCount = (int)Math.Ceiling((double)this.RowCount / (double)this.PageSize) - 1;
        this.CurrentPage = Math.Max(1, Math.Min(this.PageCount, page));
        this.FirstRow = this.PageSize * (this.CurrentPage - 1);
        this.LastRow = Math.Min(this.FirstRow + this.PageSize, this.RowCount);
        this.FrameSize = frameSize;
    }
    public Pager(int row, int page, int pageSize) : this(row, page, pageSize, 5) { }
    public Pager(int row, int page) : this(row, page, (int)beans.Configuration.TribalWarsConfiguration.GetNumericConfigurationItem("Common.PageSize").Value, 5) { }
    public Pager(int row) : this(row, 1, (int)beans.Configuration.TribalWarsConfiguration.GetNumericConfigurationItem("Common.PageSize").Value, 5) { }

    public Pager GetInfo(string url)
    {
        this.FirstRow++;
        this.NextPage = this.CurrentPage + 1;
        this.PreviousPage = this.CurrentPage - 1;
        this.Url = url;
        if (!this.Url.Contains('?'))
            this.Url += "?paging=true";

        if (this.CurrentPage != 1)
        {
            this.FirstUrl = this.Url + "&p=1";
            this.PreviousUrl = this.Url + string.Format("&p={0}", this.PreviousPage);
        }

        int start = 1;
        if ((this.CurrentPage - this.FrameSize / 2) > 0)
        {
            if ((this.CurrentPage + this.FrameSize / 2) > this.PageCount)
                start = ((this.PageCount - this.FrameSize) > 0) ? (this.PageCount - this.FrameSize + 1) : 1;
            else
                start = this.CurrentPage - (int)Math.Floor((double)this.FrameSize / 2);
        }
        int end = ((start + this.FrameSize - 1) < this.PageCount) ? (start + this.FrameSize - 1) : this.PageCount;
        this.Urls = new Dictionary<int, string>();
        for (int i = start; i <= end; ++i)
        {
            if (i == this.CurrentPage)
                this.Urls.Add(i, string.Empty);
            else
                this.Urls.Add(i, this.Url + string.Format("&p={0}", i));
        }

        if (this.PageCount != this.CurrentPage)
        {
            this.NextUrl = this.Url + string.Format("&p={0}", this.CurrentPage + 1);
            this.LastUrl = this.Url + string.Format("&p={0}", this.PageCount);
        }


        return this;
    }

    public override string ToString()
    {
        if (this.PageCount > 1)
        {
            StringBuilder str = new StringBuilder();
            if (this.FirstUrl != string.Empty)
                str.Append(string.Format("<a href=\"{0}\"><< Về đầu</a>  ", this.FirstUrl));
            if (this.PreviousUrl != string.Empty)
                str.Append(string.Format("<a href=\"{0}\">< Trước</a> ", this.PreviousUrl));
            foreach (int index in this.Urls.Keys)
            {
                if (this.Urls[index] != string.Empty)
                    str.Append(string.Format("<a href=\"{0}\" class=\"pager_link\">{1}</a> |", this.Urls[index], index));
                else
                    str.Append(string.Format("<b>{0}</b> |", index));
            }
            if (this.NextUrl != string.Empty)
                str.Append(string.Format("<a href=\"{0}\">< Sau</a>", this.NextUrl));
            if (this.LastUrl != string.Empty)
                str.Append(string.Format("<a href=\"{0}\">Về cuối >></a>  ", this.LastUrl));
            return str.ToString();
        }

        return "";
    }
}
