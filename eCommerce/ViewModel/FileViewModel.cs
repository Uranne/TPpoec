using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eCommerce.ViewModel
{
    public class FileViewModel
    {
        public HttpPostedFileBase Image {get;set;}
        public int IdProduit { get; set; }
    }
}