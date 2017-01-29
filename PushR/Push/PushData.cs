using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Linq;

namespace PushR.Push
{
    [DataContract]
	public class PushData
	{
        [DataMember]
		public string DataType { get; set; }

        [DataMember]
		public object Content { get; set; }
	}
}