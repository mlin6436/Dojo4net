using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskScheduler.Tests
{
    [TestFixture]
    public class SchedulerTests
    {
        [Test]
        public void GetTaskSchedulingResult_ShouldReturnEmptyTaskListIfInputIsEmpty()
        {
            List<Task> input = null;
            List<Task> expected = null;
            var scheduler = new Scheduler();
            var result = scheduler.GetTaskSchedulingResult(input);
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
