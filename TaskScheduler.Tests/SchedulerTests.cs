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

        [Test]
        public void GetTaskSchedulingResult_ShouldReturnScheduledTaskList()
        {
            var a = new Task("a");
            var b = new Task("b");
            var input = new List<Task>() { a, b };
            var expected = new List<Task>() { a, b };
            var scheduler = new Scheduler();
            var result = scheduler.GetTaskSchedulingResult(input);
            for (int i = 0; i < input.Count; i++)
            {
                Assert.That(result[i].Name, Is.EqualTo(expected[i].Name));
            }
        }

        [Test]
        public void GetTaskSchedulingResult_ShouldReturnScheduledTaskListWithTaskADependsOnTaskB()
        {
            var a = new Task("a");
            var b = new Task("b");
            a.Dependency = b;
            var input = new List<Task>() { a, b };
            var expected = new List<Task>() { b, a };
            var scheduler = new Scheduler();
            var result = scheduler.GetTaskSchedulingResult(input);
            for (int i = 0; i < input.Count; i++)
            {
                Assert.That(result[i].Name, Is.EqualTo(expected[i].Name));
            }
        }

        [Test]
        public void GetTaskSchedulingResult_ShouldReturnScheduledTaskListWithTaskADependsOnTaskBAndTaskCDependsTaskD()
        {
            var a = new Task("a");
            var b = new Task("b");
            var c = new Task("c");
            var d = new Task("d");
            a.Dependency = b;
            c.Dependency = d;
            var input = new List<Task>() { a, b, c, d };
            var expected = new List<Task>() { b, a, d, c };
            var scheduler = new Scheduler();
            var result = scheduler.GetTaskSchedulingResult(input);
            for (int i = 0; i < input.Count; i++)
            {
                Assert.That(result[i].Name, Is.EqualTo(expected[i].Name));
            }
        }

        [Test]
        public void GetTaskSchedulingResult_ShouldReturnScheduledTaskListWithTaskADependsOnTaskBAndTaskBDependsTaskC()
        {
            var a = new Task("a");
            var b = new Task("b");
            var c = new Task("c");
            a.Dependency = b;
            b.Dependency = c;
            var input = new List<Task>() { a, b, c };
            var expected = new List<Task>() { c, b, a };
            var scheduler = new Scheduler();
            var result = scheduler.GetTaskSchedulingResult(input);
            for (int i = 0; i < input.Count; i++)
            {
                Assert.That(result[i].Name, Is.EqualTo(expected[i].Name));
            }
        }

        [Test]
        [ExpectedException("Error - this is a cyclic dependency")]
        public void GetTaskSchedulingResult_ShouldReturnScheduledTaskListWithCyclicDependency()
        {
            var a = new Task("a");
            var b = new Task("b");
            var c = new Task("c");
            var d = new Task("d");
            a.Dependency = b;
            b.Dependency = c;
            c.Dependency = a;
            var input = new List<Task>() { a, b, c, d };
            var scheduler = new Scheduler();
            var result = scheduler.GetTaskSchedulingResult(input);
        }
    }
}
