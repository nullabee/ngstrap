using System;
using System.Linq;
using api.Models;

namespace api.Data
{
    //https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/intro
    public static class MockDataInitialiser
    {
        public static void InitializeMockData(WorkContext context)
        {
            context.Database.EnsureCreated();
            
            // Look for any tasks.
            if (context.Tasks.Any())
            {
                return;   // DB has been seeded
            }

            // Add platforms
            {
                var platforms = new Platform[]
                {
                    new Platform { PlatformID = 1000, PlatformName = "E-Leave" },
                    new Platform { PlatformID = 2000, PlatformName = "E-Tender" }
                };

                foreach (Platform p in platforms)
                {
                    context.Platforms.Add(p);
                }
                context.SaveChanges();
            }

            // Add tasks 
            {
                var tasks = new Task[]
                {
                    MockTaskFactory.Generate(1, 1000),
                    MockTaskFactory.Generate(2, 2000),
                    MockTaskFactory.Generate(3, 1000),
                    MockTaskFactory.Generate(4, 2000)
                };

                foreach (Task t in tasks)
                {
                    context.Tasks.Add(t);
                }
                context.SaveChanges();
            }

        }

        static class MockTaskFactory 
        {
            internal static Task Generate(int taskID, int platformID)
            {
                return new Task
                {
                    TaskID = taskID,
                    Title = "Task " + taskID,
                    Description = "Descr " + taskID,
                    UserID = "javan",
                    CreatedDT = randDT(),
                    DueDT = randDT(),
                    Priority = randPriority(),
                    PlatformID = platformID
                };
            }

            static Random rand = new Random();

            static DateTime randDT(bool past = false)
            {
                int m = past ? -1 : 1;
                return DateTime.Now
                    .AddDays((past ? 0 : 3) + m * rand.Next(0, 2))
                    .AddHours(m * rand.Next(0, 24))
                    .AddMinutes(m * rand.Next(0, 60))
                    .AddSeconds(m * rand.Next(0, 60));
            }

            public static Priority randPriority()
            {
                return (Priority)rand.Next(0, 2);
            }

        }

    }
}
