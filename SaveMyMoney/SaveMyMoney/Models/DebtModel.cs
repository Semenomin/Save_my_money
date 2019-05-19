using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveMyMoney
{
    public class DebtModel
    {
        public int Id { get; set; }
        public string From_who { get; set; }
        public string Date { get; set; }
        public float Expence { get; set; }
        public float Income { get; set; }
        public string Return_Date { get; set; }
        public int Jar { get; set; }
        public string Description { get; set; }
    }
}
