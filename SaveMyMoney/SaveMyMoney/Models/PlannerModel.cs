using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveMyMoney
{
    public class PlannerModel
    {
        public int Id_user { get; set; }
        public int Expense { get; set; }
        public int Income { get; set; }
        public string Date { get; set; }
        public int Period { get; set; }
    }
}
