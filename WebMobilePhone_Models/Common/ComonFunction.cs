using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMobilePhone_Models.Common
{
   
    public class ComonFunction
    {
        public ComonFunction() { }
        public string ImageTag(string Url)
        {
            string Image = "<br> <img src= " +
                " 'http://" + Url + "' " +
                "style='display: block; margin-left: auto; margin-right: auto; width:780px; height:433px;' /> <br>";
            return Image;
        }
    }
}