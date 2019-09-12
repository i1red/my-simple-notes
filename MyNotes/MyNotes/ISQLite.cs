using System;
using System.Collections.Generic;
using System.Text;

namespace MyNotes
{
    public interface ISQLite
    {
        string GetDataBasePath(string filename);
    }
}
