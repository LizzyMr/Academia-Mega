using Microsoft.AspNetCore.Mvc;
using TaskManager.Models;
using TaskManager.Repositories;
using TaskManager.Services;

namespace TaskManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly ITaskRepository _repo;
        private readonly IEnumerable<INotificationService> _notifiers;

        public TasksController(ITaskRepository repo, IEnumerable<INotificationService> notifiers)
        {
            _repo = repo;
            _notifiers = notifiers;
        }

        // GET /api/tasks
        [HttpGet]  
        public async Task<IEnumerable<TaskItem>> GetAll() =>
            await _repo.GetAllAsync(); 

        // GET /api/tasks/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskItem>> GetById(Guid id)
        {
            var task = await _repo.GetAsync(id);
            if (task == null)
                return NotFound();

            return Ok(task);
        }

        // POST /api/tasks
        [HttpPost]
        public async Task<ActionResult<TaskItem>> Create(TaskItem newTask)
        {
            await _repo.AddAsync(newTask);

            // Notificar a todos los servicios (email y sms)
            foreach (var notifier in _notifiers)
            {
                await notifier.NotifyTaskCreatedAsync(newTask);
            }

            return CreatedAtAction(nameof(GetById), new { id = newTask.id }, newTask);
        }

        // PUT /api/tasks/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, TaskItem updatedTask)
        {
            var existing = await _repo.GetAsync(id);
            if (existing == null)
                return NotFound();

            // Actualizamos los campos necesarios
            existing.Title = updatedTask.Title;
            existing.Description = updatedTask.Description;

            if (updatedTask.IsDone)
                existing.Complete();

            await _repo.UpdateAsync(existing);

            return NoContent();
        }

        // DELETE /api/tasks/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var existing = await _repo.GetAsync(id);
            if (existing == null)
                return NotFound();

            await _repo.DeleteAsync(id);
            return NoContent();
        }
    }
}