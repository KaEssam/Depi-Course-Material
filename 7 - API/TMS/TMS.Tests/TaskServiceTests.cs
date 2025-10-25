using Moq;
using TMS.App.Dtos;
using TMS.App.Interface;
using TMS.App.Interface.Services;
using TMS.core.Entites;

namespace TMS.Tests
{
    public class TaskServiceTests
    {
        private readonly Mock<ITaskRepository> _mockRepository;
        private readonly TaskService _taskService;

        public TaskServiceTests()
        {
            _mockRepository = new Mock<ITaskRepository>();
            _taskService = new TaskService(_mockRepository.Object);
        }

        [Fact]
        public async Task GetAllTasks_ShouldReturnAllTasks()
        {
            // Arrange
            var taskItems = new List<TaskItem>
            {
                new TaskItem { ID = 1, Title = "Task 1" },
                new TaskItem { ID = 2, Title = "Task 2" },
                new TaskItem { ID = 3, Title = "Task 3" }
            };

            _mockRepository.Setup(repo => repo.GetTaskItems())
                .ReturnsAsync(taskItems);

            // Act
            var result = await _taskService.GetAllTasks();

            // Assert
            Assert.NotNull(result);
            var taskList = result.ToList();
            Assert.Equal(3, taskList.Count);
            Assert.Equal("Task 1", taskList[0].Title);
            Assert.Equal("Task 2", taskList[1].Title);
            Assert.Equal("Task 3", taskList[2].Title);
            _mockRepository.Verify(repo => repo.GetTaskItems(), Times.Once);
        }

        [Fact]
        public async Task GetAllTasks_ShouldReturnEmptyList_WhenNoTasksExist()
        {
            // Arrange
            _mockRepository.Setup(repo => repo.GetTaskItems())
                .ReturnsAsync(new List<TaskItem>());

            // Act
            var result = await _taskService.GetAllTasks();

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
            _mockRepository.Verify(repo => repo.GetTaskItems(), Times.Once);
        }

        [Fact]
        public async Task GetTaskById_ShouldReturnTask_WhenTaskExists()
        {
            // Arrange
            var taskItem = new TaskItem { ID = 1, Title = "Test Task" };
            _mockRepository.Setup(repo => repo.GetTaskItemById(1))
                .ReturnsAsync(taskItem);

            // Act
            var result = await _taskService.GetTaskById(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
            Assert.Equal("Test Task", result.Title);
            _mockRepository.Verify(repo => repo.GetTaskItemById(1), Times.Once);
        }

        [Fact]
        public async Task GetTaskById_ShouldReturnNull_WhenTaskDoesNotExist()
        {
            // Arrange
            _mockRepository.Setup(repo => repo.GetTaskItemById(999))
                .ReturnsAsync((TaskItem?)null);

            // Act
            var result = await _taskService.GetTaskById(999);

            // Assert
            Assert.Null(result);
            _mockRepository.Verify(repo => repo.GetTaskItemById(999), Times.Once);
        }

        [Fact]
        public async Task CreateTask_ShouldCreateAndReturnTask()
        {
            // Arrange
            var createDto = new CreateTaskDto { Title = "New Task" };
            var createdTask = new TaskItem { ID = 1, Title = "New Task" };

            _mockRepository.Setup(repo => repo.CreateTaskItem(It.IsAny<TaskItem>()))
                .ReturnsAsync(createdTask);

            // Act
            var result = await _taskService.CreateTask(createDto);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
            Assert.Equal("New Task", result.Title);
            _mockRepository.Verify(repo => repo.CreateTaskItem(It.Is<TaskItem>(t => t.Title == "New Task")), Times.Once);
        }

        [Fact]
        public async Task UpdateTask_ShouldUpdateAndReturnTask_WhenTaskExists()
        {
            // Arrange
            var updateDto = new UpdateTaskDto { Title = "Updated Task" };
            var updatedTask = new TaskItem { ID = 1, Title = "Updated Task" };

            _mockRepository.Setup(repo => repo.UpdateTaskItem(It.IsAny<TaskItem>()))
                .ReturnsAsync(updatedTask);

            // Act
            var result = await _taskService.UpdateTask(1, updateDto);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
            Assert.Equal("Updated Task", result.Title);
            _mockRepository.Verify(repo => repo.UpdateTaskItem(It.Is<TaskItem>(t => t.ID == 1 && t.Title == "Updated Task")), Times.Once);
        }

        [Fact]
        public async Task UpdateTask_ShouldReturnNull_WhenTaskDoesNotExist()
        {
            // Arrange
            var updateDto = new UpdateTaskDto { Title = "Updated Task" };

            _mockRepository.Setup(repo => repo.UpdateTaskItem(It.IsAny<TaskItem>()))
                .ReturnsAsync((TaskItem?)null);

            // Act
            var result = await _taskService.UpdateTask(999, updateDto);

            // Assert
            Assert.Null(result);
            _mockRepository.Verify(repo => repo.UpdateTaskItem(It.Is<TaskItem>(t => t.ID == 999)), Times.Once);
        }

        [Fact]
        public async Task DeleteTask_ShouldReturnTrue_WhenTaskIsDeleted()
        {
            // Arrange
            _mockRepository.Setup(repo => repo.DeleteTaskItem(1))
                .ReturnsAsync(true);

            // Act
            var result = await _taskService.DeleteTask(1);

            // Assert
            Assert.True(result);
            _mockRepository.Verify(repo => repo.DeleteTaskItem(1), Times.Once);
        }

        [Fact]
        public async Task DeleteTask_ShouldReturnFalse_WhenTaskDoesNotExist()
        {
            // Arrange
            _mockRepository.Setup(repo => repo.DeleteTaskItem(999))
                .ReturnsAsync(false);

            // Act
            var result = await _taskService.DeleteTask(999);

            // Assert
            Assert.False(result);
            _mockRepository.Verify(repo => repo.DeleteTaskItem(999), Times.Once);
        }
    }
}


