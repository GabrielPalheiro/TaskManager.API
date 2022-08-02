using System;
using System.Collections.Generic;
using System.Linq;
using TaskManager.API.Models;

namespace TaskManager.API.Data.Repository
{
    public interface ITaskRepository
    {

        void Add(Task task);

        void Att(string id, Task taskAtt);

        IEnumerable<Task> Get();

        Task Get(string id);

        void Delete(string id);

    }
}
