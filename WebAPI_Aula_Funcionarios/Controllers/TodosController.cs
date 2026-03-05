using Microsoft.AspNetCore.Mvc;
using WebAPI_Aula_Funcionarios.Models;

namespace WebAPI_Aula_Funcionarios.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodosController : ControllerBase
    {
        private static List<TodoModel> todos = new List<TodoModel>
        {
            new TodoModel { Id = 1, Title = "Learn .NET API", IsCompleted = false },
            new TodoModel { Id = 2, Title = "Create CI Pipeline", IsCompleted = false },
            new TodoModel { Id = 3, Title = "Upload Artifact to Nexus", IsCompleted = false }
        };

        [HttpGet]
        public IActionResult GetTodos()
        {
            return Ok(todos);
        }

        [HttpGet("{id}")]
        public IActionResult GetTodo(int id)
        {
            var todo = todos.FirstOrDefault(t => t.Id == id);

            if (todo == null)
                return NotFound();

            return Ok(todo);
        }

        [HttpPost]
        public IActionResult CreateTodo(TodoModel todo)
        {
            todo.Id = todos.Count + 1;
            todos.Add(todo);

            return Ok(todo);
        }
    }
}