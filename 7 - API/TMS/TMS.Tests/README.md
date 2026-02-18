# TMS Unit Tests

This directory contains comprehensive unit tests for the Task Management System (TMS) project.

## Test Coverage

The test suite includes **32 unit tests** covering all major components of the application:

### 1. TaskServiceTests (9 tests)

Tests for the `TaskService` class that handles task business logic:

- ✅ GetAllTasks_ShouldReturnAllTasks
- ✅ GetAllTasks_ShouldReturnEmptyList_WhenNoTasksExist
- ✅ GetTaskById_ShouldReturnTask_WhenTaskExists
- ✅ GetTaskById_ShouldReturnNull_WhenTaskDoesNotExist
- ✅ CreateTask_ShouldCreateAndReturnTask
- ✅ UpdateTask_ShouldUpdateAndReturnTask_WhenTaskExists
- ✅ UpdateTask_ShouldReturnNull_WhenTaskDoesNotExist
- ✅ DeleteTask_ShouldReturnTrue_WhenTaskIsDeleted
- ✅ DeleteTask_ShouldReturnFalse_WhenTaskDoesNotExist

### 2. UserServiceTests (6 tests)

Tests for the `UserService` class that handles user authentication:

- ✅ Register_ShouldCreateUserAndReturnToken
- ✅ Register_ShouldGenerateValidJwtToken
- ✅ Login_ShouldReturnToken_WhenCredentialsAreValid
- ✅ Login_ShouldGenerateValidJwtToken
- ✅ Login_ShouldThrowUnauthorizedException_WhenUserNotFound
- ✅ Login_ShouldThrowUnauthorizedException_WhenPasswordIsIncorrect

### 3. TasksControllerTests (10 tests)

Tests for the `TasksController` API endpoints:

- ✅ GetTasks_ShouldReturnOkWithAllTasks
- ✅ GetTask_ShouldReturnOkWithTask_WhenTaskExists
- ✅ GetTask_ShouldReturnNotFound_WhenTaskDoesNotExist
- ✅ CreateTask_ShouldReturnCreatedAtAction_WithValidTask
- ✅ CreateTask_ShouldReturnBadRequest_WhenModelStateIsInvalid
- ✅ UpdateTask_ShouldReturnOk_WhenTaskExists
- ✅ UpdateTask_ShouldReturnNotFound_WhenTaskDoesNotExist
- ✅ UpdateTask_ShouldReturnBadRequest_WhenModelStateIsInvalid
- ✅ DeleteTask_ShouldReturnNoContent_WhenTaskIsDeleted
- ✅ DeleteTask_ShouldReturnNotFound_WhenTaskDoesNotExist

### 4. AuthControllerTests (7 tests)

Tests for the `AuthController` API endpoints:

- ✅ Register_ShouldReturnOkWithToken_WhenRegistrationSucceeds
- ✅ Register_ShouldReturnBadRequest_WhenRegistrationFails
- ✅ Register_ShouldAcceptValidCredentials
- ✅ Login_ShouldReturnOkWithToken_WhenCredentialsAreValid
- ✅ Login_ShouldReturnUnauthorized_WhenCredentialsAreInvalid
- ✅ Login_ShouldReturnInternalServerError_WhenUnexpectedErrorOccurs
- ✅ Login_ShouldAcceptValidCredentials

## Technologies Used

- **xUnit**: Testing framework
- **Moq**: Mocking framework for creating test doubles
- **Microsoft.AspNetCore.Mvc.Testing**: For testing ASP.NET Core controllers
- **.NET 8.0**: Target framework

## Running the Tests

### Run all tests:

```bash
dotnet test
```

### Run tests with detailed output:

```bash
dotnet test --verbosity normal
```

### Run tests with coverage (if configured):

```bash
dotnet test --collect:"XPlat Code Coverage"
```

### Run specific test class:

```bash
dotnet test --filter "FullyQualifiedName~TaskServiceTests"
```

### Run specific test method:

```bash
dotnet test --filter "FullyQualifiedName~GetAllTasks_ShouldReturnAllTasks"
```

## Test Structure

Each test follows the **AAA pattern** (Arrange-Act-Assert):

```csharp
[Fact]
public async Task MethodName_ShouldExpectedBehavior_WhenCondition()
{
    // Arrange - Set up test data and mock dependencies
    var mockRepository = new Mock<IRepository>();
    mockRepository.Setup(repo => repo.Method()).ReturnsAsync(data);

    // Act - Execute the method being tested
    var result = await service.Method();

    // Assert - Verify the expected outcome
    Assert.NotNull(result);
    Assert.Equal(expected, result);
}
```

## Mocking Strategy

All tests use **Moq** to mock dependencies:

- Repository interfaces (`ITaskRepository`, `IUserRepository`) are mocked in service tests
- Service interfaces (`ITaskService`, `IUserService`) are mocked in controller tests
- This ensures **unit isolation** - each component is tested independently

## Test Results

Latest test run: **32/32 tests passed** ✅

```
Test Run Successful.
Total tests: 32
     Passed: 32
 Total time: 0.5733 Seconds
```

## Adding New Tests

When adding new functionality:

1. Create a new test class or add to existing ones
2. Follow the naming convention: `MethodName_ShouldExpectedBehavior_WhenCondition`
3. Use Moq to mock dependencies
4. Follow the AAA pattern
5. Test both success and failure scenarios
6. Verify method calls using `Verify()`

Example:

```csharp
_mockRepository.Verify(repo => repo.GetTaskItemById(1), Times.Once);
```

## Project Dependencies

The test project references:

- `TMS.APIs` - API controllers
- `TMS.App` - Application services and DTOs
- `TMS.core` - Domain entities

## Notes

- Tests use `Mock<T>` objects to simulate repository and service behavior
- JWT token generation is tested to ensure tokens have valid structure (3 parts)
- Controller tests verify HTTP status codes and return types
- Service tests verify business logic and data transformation


