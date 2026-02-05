using System;
using System.Buffers.Text;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using TodoApi.models;

namespace TodoApi.Data;

public class TodoDbcontext : DbContext
{
    public TodoDbcontext(DbContextOptions<TodoDbcontext> options)
     : base(options)
    {
        
    }
    public DbSet<Todo> Todos {get; set;}
    public DbSet<Users> users{get; set;}
}

