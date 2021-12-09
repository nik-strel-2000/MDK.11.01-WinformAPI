using System;
using System.Collections.Generic;
using System.Text;

namespace ConnectApi.Models
{
    public partial class Json
    {
        public int Id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string gender { get; set; }
        public int? age { get; set; }
    }
}
