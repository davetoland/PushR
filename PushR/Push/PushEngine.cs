using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace PushR.Push
{
	public class PushEngine
	{
		#region Singleton
		private static object _mutex = new object();
		private static PushEngine _instance = null;
		public static PushEngine Instance
		{
			get
			{
				if (_instance == null)
					lock (_mutex)
						if (_instance == null)
							_instance = new PushEngine();

				return _instance;
			}
		}
		#endregion Singleton

		private IHubContext _hub = null;

		private PushEngine()
		{
			_hub = GlobalHost.ConnectionManager.GetHubContext<PushHub>();
		}

		public void PushToClients(PushData data)
		{
            Group group = GroupManager.Instance.GetGroupForDataType(data.DataType);
            if (group != null) _hub.Clients.Group(group.Name).receiveData(data);
		}
	}
}