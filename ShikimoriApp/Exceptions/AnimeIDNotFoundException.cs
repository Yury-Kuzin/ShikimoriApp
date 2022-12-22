using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShikimoriApp.Exceptions
{
    public class AnimeIDNotFoundException : Exception
    {
        public AnimeIDNotFoundException(string message) : base(message) { }
    }
}
