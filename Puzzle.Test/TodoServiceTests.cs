using Moq;
using Puzzle.WebApp.Models;
using Puzzle.WebApp.Repositories.Interfaces;
using Puzzle.WebApp.Services;

namespace Puzzle.WebApp.Test
{
    public class TodoServiceTests
    {
        private readonly TodoService _todoService;
        private readonly Mock<IRepository<Todo>> _todoRepoMock = new Mock<IRepository<Todo>>();

        public TodoServiceTests()
        {
            _todoService = new TodoService(_todoRepoMock.Object);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnTodo_WhenTodoExists()
        {
            // Arrange
            var todo = new Todo()
            {
                ID = new Random().Next(),
                Description = "Create Logger Service",
                CreatedDate = DateTime.Now,
            };
            _todoRepoMock.Setup(x => x.GetByIdAsync(todo.ID))
                .ReturnsAsync(todo);

            // Act
            var todoResponse = await _todoService.GetByIdAsync(todo.ID);

            // Assert
            Assert.Equal(todo.ID, todoResponse.ID);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnNothing_WhenTodoDoesNotExist()
        {
            // Arrange
            _todoRepoMock.Setup(x => x.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(() => null);

            // Act
            var todoResponse = await _todoService.GetByIdAsync(new Random().Next());

            // Assert
            Assert.Null(todoResponse);
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnTodoList_WhenAtleastOneRecordExists()
        {
            // Arrange
            var todo1 = new Todo()
            {
                ID = new Random().Next(),
                Description = "Create Logger Service",
                CreatedDate = DateTime.Now,
            };

            var todo2 = new Todo()
            {
                ID = new Random().Next(),
                Description = "Create Comments",
                CreatedDate = DateTime.Now,
            };

            List<Todo> todoList = new List<Todo> { todo1, todo2 };

            _todoRepoMock.Setup(x => x.GetAllAsync())
                .ReturnsAsync(todoList);

            // Act
            var todoResponse = await _todoService.GetAllAsync();

            // Assert
            Assert.Equal(todoList, todoResponse);
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnTodoList_WhenNoRecordExists()
        {
            // Arrange

            List<Todo> todoList = new List<Todo>();

            _todoRepoMock.Setup(x => x.GetAllAsync())
                .ReturnsAsync(todoList);

            // Act
            var todoResponse = await _todoService.GetAllAsync();

            // Assert
            Assert.Equal(todoList, todoResponse);
        }

        [Fact]
        public async Task CreateAsync_ShouldCreateTodo()
        {
            // Arrange
            var todo = new Todo()
            {
                Description = "Create Logger Service",
                CreatedDate = DateTime.Now,
            };
            _todoRepoMock.Setup(x => x.CreateAsync(todo))
                .ReturnsAsync(todo);

            // Act
            var todoResponse = await _todoService.CreateAsync(todo);

            // Assert
            Assert.Equal(todo, todoResponse);
        }

        [Fact]
        public async Task UpdateAsync_ShouldUpdateTodo_WhenTodoExists()
        {
            // Arrange
            var todo = new Todo()
            {
                ID = new Random().Next(),
                Description = "Create Logger Service",
                CreatedDate = DateTime.Now,
            };
            _todoRepoMock.Setup(x => x.UpdateAsync(todo))
                .ReturnsAsync(todo);

            // Act
            var todoResponse = await _todoService.UpdateAsync(todo);

            // Assert
            Assert.Equal(todo, todoResponse);
        }

        [Fact]
        public async Task UpdateAsync_ShouldNotCreateTodoInsteadOfUpdate_WhenTodoDoesNotExist()
        {
            // Arrange
            var todo = new Todo()
            {
                ID = new Random().Next(),
                Description = "Create Logger Service",
                CreatedDate = DateTime.Now,
            };

            var newTodo = new Todo()
            {
                ID = new Random().Next(),
                Description = todo.Description,
                CreatedDate = todo.CreatedDate
            };
            _todoRepoMock.Setup(x => x.UpdateAsync(todo))
                .ReturnsAsync(newTodo);

            // Act
            var todoResponse = await _todoService.UpdateAsync(todo);

            // Assert
            Assert.NotEqual(todo.ID, todoResponse.ID);
            Assert.Equal(todo.Description, todoResponse.Description);
            Assert.Equal(todo.CreatedDate.ToString(), todoResponse.CreatedDate.ToString());
        }

        [Fact]
        public async Task DeleteAsync_ShouldDeleteTodo_WhenTodoExists()
        {
            // Arrange
            var todo = new Todo()
            {
                ID = new Random().Next(),
                Description = "Create Logger Service",
                CreatedDate = DateTime.Now,
            };
            _todoRepoMock.Setup(x => x.GetByIdAsync(todo.ID))
                .ReturnsAsync(todo);

            _todoRepoMock.Setup(x => x.DeleteAsync(todo))
                .ReturnsAsync(true);

            // Act
            var isDeleted = await _todoService.DeleteAsync(todo.ID);

            // Assert
            Assert.True(isDeleted);
        }

        [Fact]
        public async Task DeleteAsync_ShouldDoNothing_WhenTodoDoesNotExist()
        {
            // Arrange
            var todo = new Todo()
            {
                ID = new Random().Next(),
                Description = "Create Logger Service",
                CreatedDate = DateTime.Now,
            };
            _todoRepoMock.Setup(x => x.GetByIdAsync(todo.ID))
                .ReturnsAsync(() => null);

            // Act
            var isDeleted = await _todoService.DeleteAsync(todo.ID);

            // Assert
            Assert.False(isDeleted);
        }
    }
}
