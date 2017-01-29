using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;

namespace PushR.Push
{
	public class PushHub : Hub
	{
        public override Task OnConnected()
        {
            //log the connection attempt here, and/or check that the user comes from a specific IP, etc

            return base.OnConnected();
        }

        public bool JoinGroup(string connectionId, string group, string token)
		{
            bool result = false;

            try
            {
                //decrypt the token into a user id (or throw)
                string userId = SecurityManager.Instance.Decrypt(token);

                //get User from user id
                User user = UserManager.Instance.RetrieveUser(userId);

                //if User exists
                if (user != null)
                {
                    //if the group exists
                    if (GroupManager.Instance.GetGroup(group) != null)
                    {
                        //add the user to it
                        Groups.Add(connectionId, group);
                        result = true;
                    }
                }
            }
            catch {}
            
            return result;
		}
	}
}