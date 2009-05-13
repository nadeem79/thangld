using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace beans
{
    public class Error
    {
        public string Text
        { get; set; }

        public Error(string error)
        {
            this.Text = error;
        }
    }
}
