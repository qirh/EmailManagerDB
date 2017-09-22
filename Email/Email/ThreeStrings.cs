using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Email
{
    class ThreeStrings
    {
        public string subject;     
        public string from;      
        public string body;    

        public ThreeStrings(string subject, string from, string body)
        {
            this.subject = subject;
            this.from = from;
            this.body = body;
        }
    }
}
