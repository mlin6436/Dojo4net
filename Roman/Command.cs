using Args;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roman
{
    public class Command
    {
        [ArgsMemberSwitch("v", "value")]
        public string Value { get; set; }
    }
}
