using System;


namespace TaskManager.API.Models
{
    public class Task
    {
        public Task(string name, string details)
        {
            Id = Guid.NewGuid().ToString();
            Name = name;
            Details = details;
            ConcludedIn = false;
            RegDate = DateTime.Now;
            DateOfConclusion = null;
        }

        public string Id { get; private set; }

        public string Name { get; private set; }

        public string Details { get; private set; }

        public bool ConcludedIn { get; private set; }

        public DateTime RegDate { get; private set; }

        public DateTime? DateOfConclusion { get; private set; }

        public void UpdateTask(string name, string details, bool? concludedIn = false)
        {
            Name = name;
            Details = details;
            ConcludedIn = concludedIn ?? false;
            DateOfConclusion = ConcludedIn ? DateTime.Now : null;

        }

    }
}
