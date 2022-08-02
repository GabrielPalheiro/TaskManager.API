using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using TaskManager.API.Data.Configurations;
using TaskManager.API.Models;

namespace TaskManager.API.Data.Repository
{
    public class TaskRepository : ITaskRepository
    {

        private readonly IMongoCollection<Task> _tasks;


        public TaskRepository(IDatabaseConfig databaseConfig)//config das tarefas no mongo
        {
            var client = new MongoClient(databaseConfig.ConnectionString);//pegando connc string
            var database = client.GetDatabase(databaseConfig.DatabaseName);//pegando nome 

            _tasks = database.GetCollection<Task>("tarefas");
        }

        public void Add(Models.Task task)
        {
            _tasks.InsertOne(task);

        }

        public void Att(string id, Task taskAtt)
        {
            _tasks.ReplaceOne(task => task.Id == id, taskAtt);
        }

        public IEnumerable<Task> Get()
        {
            return _tasks.Find(task => true).ToList(); 
            //traz tudo apenas com verificação se for verdadeiro
        }

        public Task Get(string id)
        {
            return _tasks.Find(task => task.Id == id).FirstOrDefault();
            //traz informação de acordo com o id
        }

        public void Delete(string id)
        {
            _tasks.DeleteOne(task => task.Id == id);
        }
    }
}
