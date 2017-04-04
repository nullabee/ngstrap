using System;
using System.Buffers;
using System.Linq;
using api.Models;

namespace api.Data
{
    //https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/intro
    public static class MockDataInitialiser
    {
        public static void InitializeMockIfEmpty(DataContext context)
        {
            context.Database.EnsureCreated();

            if (!InitTasks(context)) return;
            InitTasks(context);

        }

        private static bool InitTasks(DataContext context)
        {
            // Look for any students.
            if (context.Tasks.Any())
            {
                return false;   // DB has been seeded
            }

            var tasks = new Task[20];
            for (int c = 0; c < tasks.Length; c++) {
                tasks[c] = new Task()
                {
                    Title = MockTask.Title(c),
                    Description = MockTask.Description(c),
                    UserId = MockTask.UserId(),
                    CreatedDT = MockTask.randDT(true),
                    DueDT = MockTask.randDT(),
                    Priority = MockTask.randPriority(),
                    SystId = MockTask.RandSystId()
                };
            }
            
            foreach (Task w in tasks)
            {
                context.Tasks.Add(w);
            }
            context.SaveChanges();

            return true;
        }

        static class MockTask
        {
            private static Random rand = new Random();

            private static string title = "Update database structure for new module (prod)";
            private static string descr = "New datetime field has been added to keep track of the datetime whenever records are updated.";
            private static string[] apps = new string[]
            {
                "prism", "reki", "leave", "daw."
            };

            public static string Title(int c)
            {
                return title + " " + c;
            }

            public static string Description(int c)
            {
                return descr + " " + c;
            }

            public static string UserId()
            {
                return "tanjavan";
            }

            public static string RandSystId()
            {
                return apps[rand.Next(0, apps.Length)];
            }

            public static DateTime randDT(bool past = false)
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
