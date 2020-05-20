using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.Model
{
    //class for response message
    public class Response
    {
        public string status { get; set; }
        public string message { get; set; }
        public string data { get; set; }
    }
}
