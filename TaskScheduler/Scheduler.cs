using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskScheduler
{
    public class Scheduler
    {
        public List<Task> GetTaskSchedulingResult(List<Task> input)
        {
            if (input == null)
            {
                return null;
            }

            var result = new List<Task>();

            for (int i = 0; i < input.Count; i++ )
            {
                result.Add(input[i]);
            }

            return result;
        }
    }
}
