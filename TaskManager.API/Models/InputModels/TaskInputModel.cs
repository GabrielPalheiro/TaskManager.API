﻿namespace TaskManager.API.Models.InputModels
{
    public class TaskInputModel
    {

        public string Name { get;  set; }

        public string Details { get;  set; }

        public bool? ConcludedIn { get; private set; }
    }
}
