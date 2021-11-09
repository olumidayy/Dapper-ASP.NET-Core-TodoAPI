using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TodoAPI.Data.Repositories;
using TodoAPI.Domain.Repositories;
using TodoAPI.DTOs;

namespace TodoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodosController : ControllerBase
    {
        private readonly ILogger<TodosController> _logger;
        private readonly ITodoRepository _todosRepository;

        public TodosController(ILogger<TodosController> logger, ITodoRepository todosRepository)
        {
            _logger = logger;
            _todosRepository = todosRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                 var Data = await _todosRepository.GetAll();
                return Ok(new {
                    Success = true,
                    Message = "All todo items returned.",
                    Data
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("{todoId}")]
        public async Task<IActionResult> GetById(Guid todoId)
        {
            try
            {
                var todo = await _todosRepository.GetById(todoId);
                if(todo == null) return NotFound();
                return Ok(new {
                    success = true,
                    message = "One todo item returned.",
                    data = todo
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("users/{userId}")]
        public async Task<IActionResult> GetByUserId(Guid userId)
        {
            try
            {
                var Data = await _todosRepository.GetByUser(userId);
                return Ok(new {
                    Success = true,
                    Message = "Todo items returned.",
                    Data
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTodoDTO createTodoDTO, Guid userId)
        {
            try
            {
                await _todosRepository.Create(createTodoDTO, userId);
                return Ok(new {
                    Success = true,
                    Message = "Todo item created."
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPatch]
        [Route("{todoId}")]
        public async Task<IActionResult> Update(UpdateTodoDTO updateTodoDTO, Guid todoId)
        {
            try
            {
                await _todosRepository.Update(updateTodoDTO, todoId);
                return Ok(new {
                    Success = true,
                    Message = "Todo item updated."
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        [Route("{todoId}")]
        public async Task<IActionResult> Delete(Guid todoId)
        {
            try
            {
                await _todosRepository.Delete(todoId);
                return Ok(new {
                    Success = true,
                    Message = "Todo deleted."
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }
    }
}
