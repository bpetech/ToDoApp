using Microsoft.AspNetCore.Mvc;
using ToDoApp.Data;
using ToDoApp.Commands;
using ToDoApp.Queries;
using MediatR;
using ToDoApp.Entities.DTOs.Models;

namespace ToDoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ToDoController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<ToDoItem>>> GetAll()
        {
            var result = await _mediator.Send(new GetAllToDosQuery());
            return Ok(result);
        }

  
        [HttpGet("GetById/{id}")]
        public async Task<ActionResult<ToDoItem>> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetToDoByIdQuery { Id = id });
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

       
        [HttpPost("Create")]
        public async Task<ActionResult> Create([FromBody] CreateToDoCommand command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = result.ID }, result);
        }

       
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateToDoCommand command)
        {
            if (id != command.ID)
            {
                return BadRequest("ID mismatch between route and body.");
            }

            var result = await _mediator.Send(command);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }


     
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _mediator.Send(new DeleteToDoCommand { ID = id });
            if (result == false)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
