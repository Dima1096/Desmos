using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesmosTest.Models
{
    public class AllureCategoryModel
    {
        public string Name { get; set; }
        public List<string> MatchedStatuses { get; set; }
    }
}
