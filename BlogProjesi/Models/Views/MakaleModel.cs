using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static BlogProjesi.Context.BlogContext;

namespace BlogProjesi.Models.Views
{
    
    public class MakaleModel
    {
        public Makaleler Makele { get; set; }
        public string  Detay { get; set; }
        public string Action { get; set; }
        public string BtnValue { get; set; }
        public string BtnClass { get; set; }
    }
}
