using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using aspdotnet_core_demo.Models;
using aspdotnet_core_demo.dto;

namespace aspdotnet_core_demo.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private List<ToDoItem> _todoItems = new List<ToDoItem>()
        {
            new ToDoItem("dishes", "do them"),
        new ToDoItem("kichen", "clean"),
                    new ToDoItem("shopping", "buy eggs")


    };

        [HttpGet]
        public IActionResult GetTodo(int id)
        {
            ToDoItem foundTodoItem = null;
            foreach (var todoItem in _todoItems)
            {
                if (todoItem.Id == id)
                {
                    foundTodoItem = todoItem;
                }
            }
            if (foundTodoItem == null) return NotFound($"item id: {id} not found");
            else
                return Ok(foundTodoItem);
            //return Ok($"found item; title - {foundTodoItem.Title}, description: {foundTodoItem.Description}");
        }

    [HttpPost]
        public IActionResult CreateTodo(ExampleDto toDoItemDto)
        {
            var todoItem = new ToDoItem(toDoItemDto.Title, toDoItemDto.Description);
            _todoItems.Add(todoItem);
            return Ok(_todoItems);
            //return Ok($"your new list item is; id: {todoItem.Id}. title is {todoItem.Title} and description is: {todoItem.Description}");
        }
    }
}
