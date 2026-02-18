using TMS.core.Entites;

namespace TMS.App.Interface
{
    public interface ITaskRepository
    {
        Task<IEnumerable<TaskItem>> GetTaskItems();
        Task<TaskItem?> GetTaskItemById(int id);
        Task<TaskItem> CreateTaskItem(TaskItem taskItem);
        Task<TaskItem?> UpdateTaskItem(TaskItem taskItem);
        Task<bool> DeleteTaskItem(int id);
    }
}
