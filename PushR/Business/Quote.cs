using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PushR.Business
{
    public class Quote
    {
        public DateTime Date { get; set; }
        public Decimal Amount { get; set; }
        public string Originator { get; set; }
        public int Team { get; set; }
        public string Data { get; set; }
    }
}