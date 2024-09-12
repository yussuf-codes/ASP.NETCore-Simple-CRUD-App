using System;
using API.Exceptions;
using API.Models;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NotesController : ControllerBase
{
    private readonly NotesService _notesService;
    
    public NotesController(NotesService notesService)
    {
        _notesService = notesService;
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        try
        {
            _notesService.Delete(id);
            return NoContent();
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    [HttpGet]
    public IActionResult Get() => Ok(_notesService.Get());

    [HttpGet("{id:int}")]
    public IActionResult Get(int id)
    {
        try
        {
            return Ok(_notesService.Get(id));
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    [HttpPost]
    public IActionResult Post(Note obj)
    {
        Note note = _notesService.Add(obj);
        return CreatedAtRoute(nameof(Get), new { id = note.Id }, note);
    }

    [HttpPut("{id:int}")]
    public IActionResult Put(int id, Note obj)
    {
        try
        {
            _notesService.Update(id, obj);
            return NoContent();
        }
        catch (InvalidOperationException)
        {
            return BadRequest();
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }
}
