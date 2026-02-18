using Moq;
using TMS.App.Dtos;
using TMS.App.Interface;
using TMS.App.Interface.Services;
using TMS.core.Entites;

namespace TMS.Tests
{
    public class UserServiceTests
    {
        private readonly Mock<IUserRepository> _mockRepository;
        private readonly UserService _userService;

        public UserServiceTests()
        {
            _mockRepository = new Mock<IUserRepository>();
            _userService = new UserService(_mockRepository.Object);
        }

        [Fact]
        public async Task Register_ShouldCreateUserAndReturnToken()
        {
            // Arrange
            var registerDto = new RegisterDto
            {
                UserName = "testuser",
                PassWord = "password123"
            };

            var createdUser = new User
            {
                Id = 1,
                UserName = "testuser",
                Password = "password123"
            };

            _mockRepository.Setup(repo => repo.CreateUser(It.IsAny<User>()))
                .ReturnsAsync(createdUser);

            // Act
            var result = await _userService.Register(registerDto);

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.token);
            Assert.NotEmpty(result.token);
            _mockRepository.Verify(repo => repo.CreateUser(It.Is<User>(u =>
                u.UserName == "testuser" && u.Password == "password123")), Times.Once);
        }

        [Fact]
        public async Task Login_ShouldReturnToken_WhenCredentialsAreValid()
        {
            // Arrange
            var loginDto = new LoginDto
            {
                UserName = "testuser",
                PassWord = "password123"
            };

            var user = new User
            {
                Id = 1,
                UserName = "testuser",
                Password = "password123"
            };

            _mockRepository.Setup(repo => repo.GetUser("password123", "testuser"))
                .ReturnsAsync(user);

            // Act
            var result = await _userService.Login(loginDto);

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.token);
            Assert.NotEmpty(result.token);
            _mockRepository.Verify(repo => repo.GetUser("password123", "testuser"), Times.Once);
        }

        [Fact]
        public async Task Login_ShouldThrowUnauthorizedException_WhenUserNotFound()
        {
            // Arrange
            var loginDto = new LoginDto
            {
                UserName = "invaliduser",
                PassWord = "wrongpassword"
            };

            _mockRepository.Setup(repo => repo.GetUser("wrongpassword", "invaliduser"))
                .ReturnsAsync((User?)null);

            // Act & Assert
            var exception = await Assert.ThrowsAsync<UnauthorizedAccessException>(
                async () => await _userService.Login(loginDto));

            Assert.Equal("Invalid username or password", exception.Message);
            _mockRepository.Verify(repo => repo.GetUser("wrongpassword", "invaliduser"), Times.Once);
        }

        [Fact]
        public async Task Login_ShouldThrowUnauthorizedException_WhenPasswordIsIncorrect()
        {
            // Arrange
            var loginDto = new LoginDto
            {
                UserName = "testuser",
                PassWord = "wrongpassword"
            };

            _mockRepository.Setup(repo => repo.GetUser("wrongpassword", "testuser"))
                .ReturnsAsync((User?)null);

            // Act & Assert
            var exception = await Assert.ThrowsAsync<UnauthorizedAccessException>(
                async () => await _userService.Login(loginDto));

            Assert.Equal("Invalid username or password", exception.Message);
        }

        [Fact]
        public async Task Register_ShouldGenerateValidJwtToken()
        {
            // Arrange
            var registerDto = new RegisterDto
            {
                UserName = "testuser",
                PassWord = "password123"
            };

            var createdUser = new User
            {
                Id = 1,
                UserName = "testuser",
                Password = "password123"
            };

            _mockRepository.Setup(repo => repo.CreateUser(It.IsAny<User>()))
                .ReturnsAsync(createdUser);

            // Act
            var result = await _userService.Register(registerDto);

            // Assert
            Assert.NotNull(result.token);
            // JWT tokens have three parts separated by dots
            var tokenParts = result.token.Split('.');
            Assert.Equal(3, tokenParts.Length);
        }

        [Fact]
        public async Task Login_ShouldGenerateValidJwtToken()
        {
            // Arrange
            var loginDto = new LoginDto
            {
                UserName = "testuser",
                PassWord = "password123"
            };

            var user = new User
            {
                Id = 1,
                UserName = "testuser",
                Password = "password123"
            };

            _mockRepository.Setup(repo => repo.GetUser("password123", "testuser"))
                .ReturnsAsync(user);

            // Act
            var result = await _userService.Login(loginDto);

            // Assert
            Assert.NotNull(result.token);
            // JWT tokens have three parts separated by dots
            var tokenParts = result.token.Split('.');
            Assert.Equal(3, tokenParts.Length);
        }
    }
}



