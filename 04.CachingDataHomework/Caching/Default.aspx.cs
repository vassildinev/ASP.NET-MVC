using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Caching
{
    public partial class _Default : Page
    {
        private DateTime GetToday()
        {
            if (this.Context.Cache.Get("Today") == null)
            {
                this.Context.Cache.Add("Today", DateTime.Now, null, DateTime.Now.AddMinutes(10), TimeSpan.Zero, System.Web.Caching.CacheItemPriority.Default, null);
            }

            return (DateTime)this.Context.Cache.Get("Today");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Label.Text = this.GetToday().ToString();
        }
    }
}