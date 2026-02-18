using Microsoft.AspNetCore.Mvc;
using Moq;
using TMS.APIs.Controllers;
using TMS.App.Dtos;
using TMS.App.Interface.Services;

namespace TMS.Tests
{
    public class TasksControllerTests
    {
        private readonly Mock<ITaskService> _mockService;
        private readonly TasksController _controller;

        public TasksControllerTests()
        {
            _mockService = new Mock<ITaskService>();
            _controller = new TasksController(_mockService.Object);
        }

        [Fact]
        public async Task GetTasks_ShouldReturnOkWithAllTasks()
        {
            // Arrange
            var tasks = new List<TaskDto>
            {
                new TaskDto { Id = 1, Title = "Task 1" },
                new TaskDto { Id = 2, Title = "Task 2" }
            };

            _mockService.Setup(service => service.GetAllTasks())
                .ReturnsAsync(tasks);

            // Act
            var result = await _controller.GetTasks();

            // Assert
            var actionResult = Assert.IsType<ActionResult<IEnumerable<TaskDto>>>(result);
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var returnedTasks = Assert.IsAssignableFrom<IEnumerable<TaskDto>>(okResult.Value);
            Assert.Equal(2, returnedTasks.Count());
            _mockService.Verify(service => service.GetAllTasks(), Times.Once);
        }

        [Fact]
        public async Task GetTask_ShouldReturnOkWithTask_WhenTaskExists()
        {
            // Arrange
            var task = new TaskDto { Id = 1, Title = "Test Task" };
            _mockService.Setup(service => service.GetTaskById(1))
                .ReturnsAsync(task);

            // Act
            var result = await _controller.GetTask(1);

            // Assert
            var actionResult = Assert.IsType<ActionResult<TaskDto>>(result);
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var returnedTask = Assert.IsType<TaskDto>(okResult.Value);
            Assert.Equal(1, returnedTask.Id);
            Assert.Equal("Test Task", returnedTask.Title);
            _mockService.Verify(service => service.GetTaskById(1), Times.Once);
        }

        [Fact]
        public async Task GetTask_ShouldReturnNotFound_WhenTaskDoesNotExist()
        {
            // Arrange
            _mockService.Setup(service => service.GetTaskById(999))
                .ReturnsAsync((TaskDto?)null);

            // Act
            var result = await _controller.GetTask(999);

            // Assert
            var actionResult = Assert.IsType<ActionResult<TaskDto>>(result);
            Assert.IsType<NotFoundResult>(actionResult.Result);
            _mockService.Verify(service => service.GetTaskById(999), Times.Once);
        }

        [Fact]
        public async Task CreateTask_ShouldReturnCreatedAtAction_WithValidTask()
        {
            // Arrange
            var createDto = new CreateTaskDto { Title = "New Task" };
            var createdTask = new TaskDto { Id = 1, Title = "New Task" };

            _mockService.Setup(service => service.CreateTask(createDto))
                .ReturnsAsync(createdTask);

            // Act
            var result = await _controller.CreateTask(createDto);

            // Assert
            var actionResult = Assert.IsType<ActionResult<TaskDto>>(result);
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(actionResult.Result);
            var returnedTask = Assert.IsType<TaskDto>(createdAtActionResult.Value);
            Assert.Equal(1, returnedTask.Id);
            Assert.Equal("New Task", returnedTask.Title);
            Assert.Equal("GetTask", createdAtActionResult.ActionName);
            _mockService.Verify(service => service.CreateTask(createDto), Times.Once);
        }

        [Fact]
        public async Task CreateTask_ShouldReturnBadRequest_WhenModelStateIsInvalid()
        {
            // Arrange
            var createDto = new CreateTaskDto { Title = "" };
            _controller.ModelState.AddModelError("Title", "Required");

            // Act
            var result = await _controller.CreateTask(createDto);

            // Assert
            var actionResult = Assert.IsType<ActionResult<TaskDto>>(result);
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(actionResult.Result);
            _mockService.Verify(service => service.CreateTask(It.IsAny<CreateTaskDto>()), Times.Never);
        }

        [Fact]
        public async Task UpdateTask_ShouldReturnOk_WhenTaskExists()
        {
            // Arrange
            var updateDto = new UpdateTaskDto { Title = "Updated Task" };
            var updatedTask = new TaskDto { Id = 1, Title = "Updated Task" };

            _mockService.Setup(service => service.UpdateTask(1, updateDto))
                .ReturnsAsync(updatedTask);

            // Act
            var result = await _controller.UpdateTask(1, updateDto);

            // Assert
            var actionResult = Assert.IsType<ActionResult<TaskDto>>(result);
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var returnedTask = Assert.IsType<TaskDto>(okResult.Value);
            Assert.Equal(1, returnedTask.Id);
            Assert.Equal("Updated Task", returnedTask.Title);
            _mockService.Verify(service => service.UpdateTask(1, updateDto), Times.Once);
        }

        [Fact]
        public async Task UpdateTask_ShouldReturnNotFound_WhenTaskDoesNotExist()
        {
            // Arrange
            var updateDto = new UpdateTaskDto { Title = "Updated Task" };
            _mockService.Setup(service => service.UpdateTask(999, updateDto))
                .ReturnsAsync((TaskDto?)null);

            // Act
            var result = await _controller.UpdateTask(999, updateDto);

            // Assert
            var actionResult = Assert.IsType<ActionResult<TaskDto>>(result);
            Assert.IsType<NotFoundResult>(actionResult.Result);
            _mockService.Verify(service => service.UpdateTask(999, updateDto), Times.Once);
        }

        [Fact]
        public async Task UpdateTask_ShouldReturnBadRequest_WhenModelStateIsInvalid()
        {
            // Arrange
            var updateDto = new UpdateTaskDto { Title = "" };
            _controller.ModelState.AddModelError("Title", "Required");

            // Act
            var result = await _controller.UpdateTask(1, updateDto);

            // Assert
            var actionResult = Assert.IsType<ActionResult<TaskDto>>(result);
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(actionResult.Result);
            _mockService.Verify(service => service.UpdateTask(It.IsAny<int>(), It.IsAny<UpdateTaskDto>()), Times.Never);
        }

        [Fact]
        public async Task DeleteTask_ShouldReturnNoContent_WhenTaskIsDeleted()
        {
            // Arrange
            _mockService.Setup(service => service.DeleteTask(1))
                .ReturnsAsync(true);

            // Act
            var result = await _controller.DeleteTask(1);

            // Assert
            Assert.IsType<NoContentResult>(result);
            _mockService.Verify(service => service.DeleteTask(1), Times.Once);
        }

        [Fact]
        public async Task DeleteTask_ShouldReturnNotFound_WhenTaskDoesNotExist()
        {
            // Arrange
            _mockService.Setup(service => service.DeleteTask(999))
                .ReturnsAsync(false);

            // Act
            var result = await _controller.DeleteTask(999);

            // Assert
            Assert.IsType<NotFoundResult>(result);
            _mockService.Verify(service => service.DeleteTask(999), Times.Once);
        }
    }
}



