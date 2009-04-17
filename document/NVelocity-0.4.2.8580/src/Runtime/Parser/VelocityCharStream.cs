namespace NVelocity.Runtime.Parser {
    using System;

    /// <summary>  NOTE : This class was originally an ASCII_CharStream autogenerated
    /// by Javacc.  It was then modified via changing class name with appropriate
    /// fixes for CTORS, and mods to readChar().
    ///
    /// This is safe because we *always* use Reader with this class, and never a
    /// InputStream.  This guarantees that we have a correct stream of 16-bit
    /// chars - all encoding transformations have been done elsewhere, so we
    /// believe that there is no risk in doing this.  Time will tell :)
    /// </summary>

    /// <summary> An implementation of interface CharStream, where the stream is assumed to
    /// contain only ASCII characters (without unicode processing).
    /// </summary>

    public sealed class VelocityCharStream : CharStream {
	public int Column {
	    get {
		return bufcolumn[bufpos];
	    }

	}
	public int Line {
	    get {
		return bufline[bufpos];
	    }

	}
	public int EndColumn {
	    get {
		return bufcolumn[bufpos];
	    }

	}
	public int EndLine {
	    get {
		return bufline[bufpos];
	    }

	}
	public int BeginColumn {
	    get {
		return bufcolumn[tokenBegin];
	    }

	}
	public int BeginLine {
	    get {
		return bufline[tokenBegin];
	    }

	}
	public const bool staticFlag = false;
	internal int bufsize;
	internal int available;
	internal int tokenBegin;
	public int bufpos = - 1;
	private int[] bufline;
	private int[] bufcolumn;

	private int column = 0;
	private int line = 1;

	private bool prevCharIsCR = false;
	private bool prevCharIsLF = false;

	private System.IO.TextReader inputStream;

	private char[] buffer;
	private int maxNextCharInd = 0;
	private int inBuf = 0;

	private void ExpandBuff(bool wrapAround) {
	    char[] newbuffer = new char[bufsize + 2048];
	    int[] newbufline = new int[bufsize + 2048];
	    int[] newbufcolumn = new int[bufsize + 2048];

	    //UPGRADE_NOTE: Exception 'java.lang.Throwable' was converted to ' ' which has different behavior. 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="jlca1100"'
	    try {
		if (wrapAround) {
		    Array.Copy(buffer, tokenBegin, newbuffer, 0, bufsize - tokenBegin);
		    Array.Copy(buffer, 0, newbuffer, bufsize - tokenBegin, bufpos);
		    buffer = newbuffer;

		    Array.Copy(bufline, tokenBegin, newbufline, 0, bufsize - tokenBegin);
		    Array.Copy(bufline, 0, newbufline, bufsize - tokenBegin, bufpos);
		    bufline = newbufline;

		    Array.Copy(bufcolumn, tokenBegin, newbufcolumn, 0, bufsize - tokenBegin);
		    Array.Copy(bufcolumn, 0, newbufcolumn, bufsize - tokenBegin, bufpos);
		    bufcolumn = newbufcolumn;

		    maxNextCharInd = (bufpos += (bufsize - tokenBegin));
		} else {
		    Array.Copy(buffer, tokenBegin, newbuffer, 0, bufsize - tokenBegin);
		    buffer = newbuffer;

		    Array.Copy(bufline, tokenBegin, newbufline, 0, bufsize - tokenBegin);
		    bufline = newbufline;

		    Array.Copy(bufcolumn, tokenBegin, newbufcolumn, 0, bufsize - tokenBegin);
		    bufcolumn = newbufcolumn;

		    maxNextCharInd = (bufpos -= tokenBegin);
		}
	    } catch (System.Exception t) {
		throw new System.ApplicationException(t.Message);
	    }


	    bufsize += 2048;
	    available = bufsize;
	    tokenBegin = 0;
	}

	private void  FillBuff() {
	    if (maxNextCharInd == available) {
		if (available == bufsize) {
		    if (tokenBegin > 2048) {
			bufpos = maxNextCharInd = 0;
			available = tokenBegin;
		    } else if (tokenBegin < 0)
			bufpos = maxNextCharInd = 0;
		    else
			ExpandBuff(false);
		} else if (available > tokenBegin)
		    available = bufsize;
		else if ((tokenBegin - available) < 2048)
		    ExpandBuff(true);
		else
		    available = tokenBegin;
	    }

	    int i;
	    try {
		// NOTE:  java streams return -1 when done
		// NOTE: java throws java.io.IOException when anything goes wrong - .Net will throw
		// a System.ObjectDisposedException when the reader is closed
		try {
		    i = inputStream.Read(buffer, maxNextCharInd, available - maxNextCharInd);
		} catch (Exception ex) {
		    throw new System.IO.IOException("exception reading from inputStream", ex);
		}
		if (i <= 0) {
		    inputStream.Close();
		    throw new System.IO.IOException();
		} else
		    maxNextCharInd += i;
		return ;
	    } catch (System.IO.IOException e) {
		--bufpos;
		backup(0);
		if (tokenBegin == - 1)
		    tokenBegin = bufpos;
		throw e;
	    }
	}

	public char BeginToken() {
	    tokenBegin = - 1;
	    char c = readChar();
	    tokenBegin = bufpos;

	    return c;
	}

	private void  UpdateLineColumn(char c) {
	    column++;

	    if (prevCharIsLF) {
		prevCharIsLF = false;
		line += (column = 1);
	    } else if (prevCharIsCR) {
		prevCharIsCR = false;
		if (c == '\n') {
		    prevCharIsLF = true;
		} else
		    line += (column = 1);
	    }

	    switch (c) {
		case '\r':
		    prevCharIsCR = true;
		    break;

		case '\n':
		    prevCharIsLF = true;
		    break;

		case '\t':
		    column--;
		    column += (8 - (column & 7));
		    break;

		default:
		    break;

	    }

	    bufline[bufpos] = line;
	    bufcolumn[bufpos] = column;
	}

	public char readChar() {
	    if (inBuf > 0) {
		--inBuf;

		/*
		*  was : return (char)((char)0xff & buffer[(bufpos == bufsize - 1) ? (bufpos = 0) : ++bufpos]);
		*/
		return buffer[(bufpos == bufsize - 1)?(bufpos = 0):++bufpos];
	    }

	    if (++bufpos >= maxNextCharInd)
		FillBuff();

	    /*
	    *  was : char c = (char)((char)0xff & buffer[bufpos]);
	    */
	    char c = buffer[bufpos];

	    UpdateLineColumn(c);
	    return (c);
	}

	/// <deprecated>
	/// </deprecated>
	/// <seealso cref=" #getEndColumn
	///
	/// "/>


	/// <deprecated>
	/// </deprecated>
	/// <seealso cref=" #getEndLine
	///
	/// "/>

	public void  backup(int amount) {

	    inBuf += amount;
	    if ((bufpos -= amount) < 0)
		bufpos += bufsize;
	}

	public VelocityCharStream(System.IO.TextReader dstream, int startline, int startcolumn, int buffersize) {
	    inputStream = dstream;
	    line = startline;
	    column = startcolumn - 1;

	    available = bufsize = buffersize;
	    buffer = new char[buffersize];
	    bufline = new int[buffersize];
	    bufcolumn = new int[buffersize];
	}

	public VelocityCharStream(System.IO.TextReader dstream, int startline, int startcolumn):this(dstream, startline, startcolumn, 4096) {}
	public void  ReInit(System.IO.TextReader dstream, int startline, int startcolumn, int buffersize) {
	    inputStream = dstream;
	    line = startline;
	    column = startcolumn - 1;

	    if (buffer == null || buffersize != buffer.Length) {
		available = bufsize = buffersize;
		buffer = new char[buffersize];
		bufline = new int[buffersize];
		bufcolumn = new int[buffersize];
	    }
	    prevCharIsLF = prevCharIsCR = false;
	    tokenBegin = inBuf = maxNextCharInd = 0;
	    bufpos = - 1;
	}

	public void  ReInit(System.IO.TextReader dstream, int startline, int startcolumn) {
	    ReInit(dstream, startline, startcolumn, 4096);
	}

	// TODO - I am still not sure what place regular Streams will play - so I will just stick with Text* streams
	//	public VelocityCharStream(System.IO.Stream dstream, int startline, int startcolumn, int buffersize):this(new System.IO.TextReader(dstream), startline, startcolumn, 4096) {
	//	}
	//
	//	public VelocityCharStream(System.IO.Stream dstream, int startline, int startcolumn):this(dstream, startline, startcolumn, 4096) {
	//	}
	//
	//	public void  ReInit(System.IO.Stream dstream, int startline, int startcolumn, int buffersize) {
	//	    ReInit(new System.IO.TextReader(dstream), startline, startcolumn, 4096);
	//	}
	//	public void  ReInit(System.IO.Stream dstream, int startline, int startcolumn) {
	//	    ReInit(dstream, startline, startcolumn, 4096);
	//	}
	public System.String GetImage() {
	    if (bufpos >= tokenBegin) {
		Int32 len = (bufpos - tokenBegin + 1)>buffer.Length ? buffer.Length : (bufpos - tokenBegin + 1);
		//return new String(buffer, tokenBegin, bufpos - tokenBegin + 1);
		return new String(buffer, tokenBegin, len);
	    } else {
		return new String(buffer, tokenBegin, bufsize - tokenBegin) + new String(buffer, 0, bufpos + 1);
	    }
	}

	public char[] GetSuffix(int len) {
	    char[] ret = new char[len];

	    if ((bufpos + 1) >= len)
		Array.Copy(buffer, bufpos - len + 1, ret, 0, len);
	    else {
		Array.Copy(buffer, bufsize - (len - bufpos - 1), ret, 0, len - bufpos - 1);
		Array.Copy(buffer, 0, ret, len - bufpos - 1, bufpos + 1);
	    }

	    return ret;
	}

	public void  Done() {
	    buffer = null;
	    bufline = null;
	    bufcolumn = null;
	}

	/// <summary> Method to adjust line and column numbers for the start of a token.<BR>
	/// </summary>
	public void  adjustBeginLineColumn(int newLine, int newCol) {
	    int start = tokenBegin;
	    int len;

	    if (bufpos >= tokenBegin) {
		len = bufpos - tokenBegin + inBuf + 1;
	    } else {
		len = bufsize - tokenBegin + bufpos + 1 + inBuf;
	    }

	    int i = 0, j = 0, k = 0;
	    int nextColDiff = 0, columnDiff = 0;

	    while (i < len && bufline[j = start % bufsize] == bufline[k = ++start % bufsize]) {
		bufline[j] = newLine;
		nextColDiff = columnDiff + bufcolumn[k] - bufcolumn[j];
		bufcolumn[j] = newCol + columnDiff;
		columnDiff = nextColDiff;
		i++;
	    }

	    if (i < len) {
		bufline[j] = newLine++;
		bufcolumn[j] = newCol + columnDiff;

		while (i++ < len) {
		    if (bufline[j = start % bufsize] != bufline[++start % bufsize])
			bufline[j] = newLine++;
		    else
			bufline[j] = newLine;
		}
	    }

	    line = bufline[j];
	    column = bufcolumn[j];
	}
    }
}
