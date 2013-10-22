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

            for (int i = 0; i < input.Count; i++)
            {
                if (result.Contains(input[i]))
                {
                    continue;
                }

                GetDependency(result, input[i], input.Count);
            }

            return result;
        }

        private Task GetDependency(List<Task> input, Task task, int maxTaskNumber)
        {
            if (maxTaskNumber-- == 0)
            {
                throw new Exception("Error - this is a cyclic dependency");
            }

            if (task.Dependency != null)
            {
                GetDependency(input, task.Dependency, maxTaskNumber);
            }

            input.Add(task);

            return task;
        }
    }
}

