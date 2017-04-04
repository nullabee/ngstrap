﻿using System;
using System.Collections.Generic;
using System.Linq;
using api.Models;
using api.Data;

namespace api.Resources
{
    public class TaskResource : IResource<Task>
    {
        private readonly WorkContext context;
        
        public TaskResource(WorkContext context)
        {
            this.context = context;
        }

        public IEnumerable<Task> GetAll()
        {
            return context.Tasks;
        }

        public Task Find(int key)
        {
            return context.Tasks
                .Where(r => r.TaskID.Equals(key))
                .SingleOrDefault();
        }

        public void Add(Task item)
        {
            context.Tasks.Add(item);
            context.SaveChanges();
        }

        public bool Remove(int key)
        {
            var res = Find(key);
            if (res != null)
            {
                context.Tasks.Remove(res);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Update(Task item)
        {
            var res = Find(item.TaskID);
            if (res != null)
            {
                res.Title = item.Title;
                res.Description = item.Description;
                res.UserID = item.UserID;
                context.SaveChanges();
                return true;
            }

            return false;           
        }
    }
}