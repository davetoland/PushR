using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace PushR.Push.Service
{
	[ServiceContract]
	public interface IDataService
	{
        [OperationContract]
        void NotifyUpdate(PushData data);

		[OperationContract]
        void NewQuoteRequest(DateTime date, decimal amount, string originator, int team, string data);
	}
}
