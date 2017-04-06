using System;
using System.Linq;
using api.Models;

namespace api.Data
{
    //https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/intro
    public static class MockDataInitialiser
    {
        public static void InitializeMockData(DataContext context)
        {
            context.Database.EnsureCreated();
            
            // Look for any tasks.
            if (context.Nuances.Any())
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
                var nuances = new Nuance[]
                {
                    MockTaskFactory.Generate(1, 1000),
                    MockTaskFactory.Generate(2, 2000),
                    MockTaskFactory.Generate(3, 1000),
                    MockTaskFactory.Generate(4, 2000)
                };

                foreach (Nuance n in nuances)
                {
                    context.Nuances.Add(n);
                }
                context.SaveChanges();
            }

        }

        static class MockTaskFactory 
        {
            internal static Nuance Generate(int taskID, int platformID)
            {
                return new Nuance
                {
                    NuanceID = taskID,
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
