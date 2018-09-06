using NMA_Wall.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;

namespace NMA_Wall
{
    /// <summary>
    /// Summary description for NMA
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
    [ScriptService]
    public class NMA : WebService
    {
        public NMA()
        {

        }

        Respository db = new Respository();

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetComments(double lat, double lon, double dist = 10.0)
        {
            return (new JavaScriptSerializer()).Serialize(db.MessageGetInRange(lat, lon, dist).Where(m => m.IsVaild).ToArray());
        }
    }
}
