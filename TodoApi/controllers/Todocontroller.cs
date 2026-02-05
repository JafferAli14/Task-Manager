using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using TodoApi.Data;
using TodoApi.DTO;
using TodoApi.Migrations;
using TodoApi.models;
// using System.Linq;

namespace TodoApi.controllers;

[ApiController]
[Route("api/[Controller]")]
public class Todocontroller : ControllerBase
{

    private readonly TodoDbcontext _context;
    public Todocontroller(TodoDbcontext context)
    {
        _context=context;
    }

    //get

    [HttpGet]
    public async Task<IActionResult> Getresult(){

        var tasks=await _context.Todos.ToListAsync();
        var dto_list= tasks.Select(t=> new Todoread
        {
            id=t.id,
            title=t.title,
            completed=t.completed

        });
        return Ok(dto_list);

    }
    
    //get by id
    [HttpGet("{id}")]
    public async Task<IActionResult> getbyid(int id)
    {
        var taskid= await _context.Todos.FirstOrDefaultAsync(t=> t.id == id);

        if (taskid == null)
        {
            return NotFound("notfound");
        }
        var dto=new Todoread {
            id=taskid.id,
            title=taskid.title,
            completed=taskid.completed
        };

        return Ok(dto);
    }

    
    //single post
    [HttpPost]
    public async Task< IActionResult> Create(Todocreate dto)
    {
            var task=new Todo
            {
                title=dto.title,
                completed=dto.completed
            };
            _context.Todos.Add(task);
            await _context.SaveChangesAsync();

            var readtask=new Todoread
            {
                id=task.id,
                title=task.title,
                completed=task.completed
            };

        return CreatedAtAction(nameof(getbyid),new{id=task.id},readtask);
    }


    [HttpPost("BATCH")]
    public async Task<IActionResult> createmultiple(List<Todocreate> createdto)
    {
        var tasks=createdto.Select(dto=> new Todo
        {
            title=dto.title,
            completed=dto.completed
        });

        _context.Todos.AddRange(tasks);
        await _context.SaveChangesAsync();

        var readdto=tasks.Select(t=>new Todoread
        {
            id=t.id,
            title=t.title,
            completed=t.completed
        });

        return CreatedAtAction(nameof(getbyid),null,readdto);
    }



    //update todo
    [HttpPut("{id}")]
    public async Task< IActionResult> Update(int id,Todoupdate updatedto)
    {
        var tasktoedit= await _context.Todos.FirstOrDefaultAsync(t=>t.id==id);
        if (tasktoedit == null)
        {
            return NoContent();
        }

        tasktoedit.title=updatedto.title;
        tasktoedit.completed=updatedto.completed;

        await _context.SaveChangesAsync();
        
        return Ok(tasktoedit);
    }


    //delete task
    [HttpDelete("{id}")]
    public async Task< IActionResult> delete(int id)
    {
        var tasktodelete=await _context.Todos.FirstOrDefaultAsync(t=>t.id==id);
        
        if(tasktodelete == null)
        {
            return NoContent();
        }

        _context.Todos.Remove (tasktodelete);
        await _context.SaveChangesAsync();
        return Ok("task deleted");
    }

}
