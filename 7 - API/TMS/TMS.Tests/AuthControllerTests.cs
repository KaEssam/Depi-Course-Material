using Microsoft.AspNetCore.Mvc;
using Moq;
using TMS.APIs.Controllers;
using TMS.App.Dtos;
using TMS.App.Interface.Services;

namespace TMS.Tests
{
    public class AuthControllerTests
    {
        private readonly Mock<IUserService> _mockService;
        private readonly AuthController _controller;

        public AuthControllerTests()
        {
            _mockService = new Mock<IUserService>();
            _controller = new AuthController(_mockService.Object);
        }

        [Fact]
        public async Task Register_ShouldReturnOkWithToken_WhenRegistrationSucceeds()
        {
            // Arrange
            var registerDto = new RegisterDto
            {
                UserName = "newuser",
                PassWord = "password123"
            };

            var authResponse = new AuthResponse("generated.jwt.token");

            _mockService.Setup(service => service.Register(registerDto))
                .ReturnsAsync(authResponse);

            // Act
            var result = await _controller.Register(registerDto);

            // Assert
            var actionResult = Assert.IsType<ActionResult<AuthResponse>>(result);
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var returnedResponse = Assert.IsType<AuthResponse>(okResult.Value);
            Assert.Equal("generated.jwt.token", returnedResponse.token);
            _mockService.Verify(service => service.Register(registerDto), Times.Once);
        }

        [Fact]
        public async Task Register_ShouldReturnBadRequest_WhenRegistrationFails()
        {
            // Arrange
            var registerDto = new RegisterDto
            {
                UserName = "existinguser",
                PassWord = "password123"
            };

            _mockService.Setup(service => service.Register(registerDto))
                .ThrowsAsync(new Exception("Username already exists"));

            // Act
            var result = await _controller.Register(registerDto);

            // Assert
            var actionResult = Assert.IsType<ActionResult<AuthResponse>>(result);
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(actionResult.Result);
            _mockService.Verify(service => service.Register(registerDto), Times.Once);
        }

        [Fact]
        public async Task Login_ShouldReturnOkWithToken_WhenCredentialsAreValid()
        {
            // Arrange
            var loginDto = new LoginDto
            {
                UserName = "testuser",
                PassWord = "password123"
            };

            var authResponse = new AuthResponse("generated.jwt.token");

            _mockService.Setup(service => service.Login(loginDto))
                .ReturnsAsync(authResponse);

            // Act
            var result = await _controller.Login(loginDto);

            // Assert
            var actionResult = Assert.IsType<ActionResult<AuthResponse>>(result);
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var returnedResponse = Assert.IsType<AuthResponse>(okResult.Value);
            Assert.Equal("generated.jwt.token", returnedResponse.token);
            _mockService.Verify(service => service.Login(loginDto), Times.Once);
        }

        [Fact]
        public async Task Login_ShouldReturnUnauthorized_WhenCredentialsAreInvalid()
        {
            // Arrange
            var loginDto = new LoginDto
            {
                UserName = "testuser",
                PassWord = "wrongpassword"
            };

            _mockService.Setup(service => service.Login(loginDto))
                .ThrowsAsync(new UnauthorizedAccessException("Invalid username or password"));

            // Act
            var result = await _controller.Login(loginDto);

            // Assert
            var actionResult = Assert.IsType<ActionResult<AuthResponse>>(result);
            var unauthorizedResult = Assert.IsType<UnauthorizedObjectResult>(actionResult.Result);
            _mockService.Verify(service => service.Login(loginDto), Times.Once);
        }

        [Fact]
        public async Task Login_ShouldReturnInternalServerError_WhenUnexpectedErrorOccurs()
        {
            // Arrange
            var loginDto = new LoginDto
            {
                UserName = "testuser",
                PassWord = "password123"
            };

            _mockService.Setup(service => service.Login(loginDto))
                .ThrowsAsync(new Exception("Database connection error"));

            // Act
            var result = await _controller.Login(loginDto);

            // Assert
            var actionResult = Assert.IsType<ActionResult<AuthResponse>>(result);
            var objectResult = Assert.IsType<ObjectResult>(actionResult.Result);
            Assert.Equal(500, objectResult.StatusCode);
            _mockService.Verify(service => service.Login(loginDto), Times.Once);
        }

        [Fact]
        public async Task Register_ShouldAcceptValidCredentials()
        {
            // Arrange
            var registerDto = new RegisterDto
            {
                UserName = "validuser123",
                PassWord = "SecurePassword!123"
            };

            var authResponse = new AuthResponse("valid.jwt.token");

            _mockService.Setup(service => service.Register(registerDto))
                .ReturnsAsync(authResponse);

            // Act
            var result = await _controller.Register(registerDto);

            // Assert
            var actionResult = Assert.IsType<ActionResult<AuthResponse>>(result);
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            Assert.NotNull(okResult.Value);
            _mockService.Verify(service => service.Register(registerDto), Times.Once);
        }

        [Fact]
        public async Task Login_ShouldAcceptValidCredentials()
        {
            // Arrange
            var loginDto = new LoginDto
            {
                UserName = "validuser123",
                PassWord = "SecurePassword!123"
            };

            var authResponse = new AuthResponse("valid.jwt.token");

            _mockService.Setup(service => service.Login(loginDto))
                .ReturnsAsync(authResponse);

            // Act
            var result = await _controller.Login(loginDto);

            // Assert
            var actionResult = Assert.IsType<ActionResult<AuthResponse>>(result);
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            Assert.NotNull(okResult.Value);
            _mockService.Verify(service => service.Login(loginDto), Times.Once);
        }
    }
}



