using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartEntities
{
    public class EUser
    {
        public string Name { set; get; }
        public string Lastname { set; get; }
        public string Birthday { set; get; }
        public string Country { set; get; }
        public string State { set; get; }
        public string Place { set; get; }
        public int Postal { set; get; }
        public string Direction_1 { set; get; }
        public string Direction_2 { set; get; }
        public string Email { set; get; }
        public string Password { set; get; }
    }
}
