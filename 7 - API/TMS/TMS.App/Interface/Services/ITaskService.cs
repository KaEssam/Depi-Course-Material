using TMS.App.Dtos;

namespace TMS.App.Interface.Services
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskDto>> GetAllTasks();
        Task<TaskDto?> GetTaskById(int id);
        Task<TaskDto> CreateTask(CreateTaskDto createTaskDto);
        Task<TaskDto?> UpdateTask(int id, UpdateTaskDto updateTaskDto);
        Task<bool> DeleteTask(int id);
    }
}
