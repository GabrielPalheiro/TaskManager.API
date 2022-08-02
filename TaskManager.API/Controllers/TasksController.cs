using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TaskManager.API.Data.Repository;
using TaskManager.API.Models;
using TaskManager.API.Models.InputModels;

namespace TaskManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {

        private ITaskRepository _taskRepository;

        public TasksController(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }




        // GET: api/tasks
        [HttpGet]
        public IActionResult Get()
        {
            var tasks = _taskRepository.Get();

            return Ok(tasks);
        }

        // GET api/tasks/{id}
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var task = _taskRepository.Get(id);

            if (task == null)
                return NotFound();

            return Ok(task);

        }

        // POST api/tasks
        [HttpPost]
        public IActionResult Post([FromBody] TaskInputModel newTask)
        {
            var task = new Task(newTask.Name, newTask.Details);

            _taskRepository.Add(task);
            return Created("", task);
        }

        // PUT api/tasks/{id}
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] TaskInputModel updatedTask)
        {
            var task = _taskRepository.Get(id);

            if (task == null)
                return NotFound();

            task.UpdateTask(updatedTask.Name, updatedTask.Details, updatedTask.ConcludedIn);

            _taskRepository.Att(id, task);
            return Ok(task);

        }

        // DELETE api/tasks/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var task = _taskRepository.Get(id);

            if (task == null)
                return NotFound();

            _taskRepository.Delete(id);

            return NoContent();
            //resposta padrão para que não tem conteudo porem nao é um erro
        }
    }
}
