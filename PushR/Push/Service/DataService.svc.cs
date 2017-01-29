using PushR.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace PushR.Push.Service
{
	public class DataService : IDataService
	{
		public void NotifyUpdate(PushData data)
		{
			PushEngine.Instance.PushToClients(data);
		}

        public void NewQuoteRequest(DateTime date, decimal amount, string originator, int team, string data)
        {
            var pushData = new PushData
            {
                DataType = "QuoteRequest",
                Content = new Quote
                {
                    Date = date,
                    Amount = amount,
                    Originator = originator,
                    Team = team,
                    Data = data
                }
            };

            PushEngine.Instance.PushToClients(pushData);
        }
	}
}
