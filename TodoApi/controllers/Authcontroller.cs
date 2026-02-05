using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Data;
using TodoApi.DTO.Auth;
using TodoApi.models;
using TodoApi.Services;

namespace TodoApi.controllers;
[ApiController]
[Route("/api[controller]")]
public class Authcontroller:ControllerBase
{
    private readonly TodoDbcontext _context;
    private Jwttokenservice _tokenservice;
    public Authcontroller(TodoDbcontext context, Jwttokenservice tokenservice)
    {
        _context=context;
        _tokenservice=tokenservice;
    }


    //register post
    [HttpPost("register")]
    public async Task<IActionResult> registerit(Register regdto)
    {
        var un=await _context.users.AnyAsync(u=> u.username==regdto.username);
        if (un)
        {
            return BadRequest("username already exists");
        }
        var user = new Users
        {
            username=regdto.username,
            passwordhash = BCrypt.Net.BCrypt.HashPassword(regdto.password)
        };

        _context.users.Add(user);
        await _context.SaveChangesAsync();

        return Ok("changes made");
    }

    [HttpPost("login")]
    public async Task<IActionResult> login_function(Login logindto)
    {
        var un = await _context.users.FirstOrDefaultAsync(u => u.username==logindto.username);
        if (un==null)
        {
            return Unauthorized("invalid username or password");
        }

        if (!BCrypt.Net.BCrypt.Verify(logindto.password, un.passwordhash))
        {
            return Unauthorized("Invalid username or password");
            
        }

        var token=_tokenservice.createtokens(un);
        
        return Ok(new{token});  
    }

}
