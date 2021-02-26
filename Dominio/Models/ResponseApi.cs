using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class ResponseApi
    {
        public int cantidad { get; set; }
        public int inicio { get; set; }
        public List<Province> provincias { get; set; }
        public Parametro parametros { get; set; }
        public int total { get; set; }
    }
}
