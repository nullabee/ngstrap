using System;
using System.Linq;
using api.Models;
using api.Data;


namespace api.Dev
{
    public static class WorkerDBInitialiser
    {
        public static void InitializeMockIfEmpty(WorkerContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Workers.Any())
            {
                return;   // DB has been seeded
            }

            var workers = new Worker[]
            {
                new Worker { FirstName = "John", LastName = "Doe", Email = "john@example.com"},
                new Worker { FirstName = "Mary", LastName = "Moe", Email = "mary@example.com"},
                new Worker { FirstName = "July", LastName = "Dooley", Email = "july@example.com"}
            };

            foreach (Worker w in workers)
            {
                context.Workers.Add(w);
            }
            context.SaveChanges();

        }
    }
}
