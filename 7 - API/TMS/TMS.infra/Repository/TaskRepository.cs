using Microsoft.EntityFrameworkCore;
using TMS.App.Interface;
using TMS.core.Entites;
using TMS.infra.Data;

namespace TMS.infra.Repository
{
    public class TaskRepository : ITaskRepository
    {
        private readonly AppDbContext _context;

        public TaskRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TaskItem>> GetTaskItems()
        {
            return await _context.Tasks.ToListAsync();
        }

        public async Task<TaskItem?> GetTaskItemById(int id)
        {
            return await _context.Tasks.FindAsync(id);
        }

        public async Task<TaskItem> CreateTaskItem(TaskItem taskItem)
        {
            _context.Tasks.Add(taskItem);
            await _context.SaveChangesAsync();
            return taskItem;
        }

        public async Task<TaskItem?> UpdateTaskItem(TaskItem taskItem)
        {
            var existingTask = await _context.Tasks.FindAsync(taskItem.ID);
            if (existingTask == null)
                return null;

            existingTask.Title = taskItem.Title;
            await _context.SaveChangesAsync();
            return existingTask;
        }

        public async Task<bool> DeleteTaskItem(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null)
                return false;

            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
