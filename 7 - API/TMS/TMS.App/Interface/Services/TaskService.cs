using TMS.App.Dtos;
using TMS.App.Interface;
using TMS.core.Entites;

namespace TMS.App.Interface.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _repository;

        public TaskService(ITaskRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<TaskDto>> GetAllTasks()
        {
            var tasks = await _repository.GetTaskItems();
            return tasks.Select(MapToDto);
        }

        public async Task<TaskDto?> GetTaskById(int id)
        {
            var task = await _repository.GetTaskItemById(id);
            return task != null ? MapToDto(task) : null;
        }

        public async Task<TaskDto> CreateTask(CreateTaskDto createTaskDto)
        {
            var taskItem = new TaskItem
            {
                Title = createTaskDto.Title
            };

            var createdTask = await _repository.CreateTaskItem(taskItem);
            return MapToDto(createdTask);
        }

        public async Task<TaskDto?> UpdateTask(int id, UpdateTaskDto updateTaskDto)
        {
            var taskItem = new TaskItem
            {
                ID = id,
                Title = updateTaskDto.Title
            };

            var updatedTask = await _repository.UpdateTaskItem(taskItem);
            return updatedTask != null ? MapToDto(updatedTask) : null;
        }

        public async Task<bool> DeleteTask(int id)
        {
            return await _repository.DeleteTaskItem(id);
        }

        private static TaskDto MapToDto(TaskItem taskItem)
        {
            return new TaskDto
            {
                Id = taskItem.ID,
                Title = taskItem.Title
            };
        }
    }
}
