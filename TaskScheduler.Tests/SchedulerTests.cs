﻿using NUnit.Framework;
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
    }
}
