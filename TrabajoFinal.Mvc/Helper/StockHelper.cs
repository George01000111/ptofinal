using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TrabajoFinal.Mvc.Helper
{
    public static class StockHelper
    {

        public static IHtmlString StockProd(
           this HtmlHelper helper, string context,int estado)
        {

            var str= $"<font color=#0000A0>{context}</font>";

            if (Convert.ToInt32(context) < 10){
             str = $"<font color=red>{context}</font>";

            }
           

            if (estado==0)
            {
                str = $"<font color=#808080>{context}</font>";
            }
           

            return new HtmlString(str);




        }

    }
}