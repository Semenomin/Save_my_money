using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveMyMoney
{
    public class RegistrationModel
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Rep_Password { get; set; }
        public string Name { get; set; }
    }
}
