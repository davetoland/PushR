using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PushR
{
	public partial class Requests : System.Web.UI.Page
	{
        public string FooterText { get; set; }

		protected void Page_Load(object sender, EventArgs e)
		{
            FooterText = "&copy; Copright etc blah blah";
		}
	}
}