using System;
using System.Collections.Generic;
using System.Text;

namespace UtulsLibrary.Exceptions
{
    public class NoteFoundException:Exception
    {
        public NoteFoundException(string message) : base(message) 
        { 
        }
    }
}
