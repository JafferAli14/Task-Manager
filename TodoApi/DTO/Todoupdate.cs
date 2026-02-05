using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Antiforgery;

namespace TodoApi.DTO;

public record class Todoupdate
{
   [Required][MinLength(3)] public string title { get; set; }="";
    public bool completed{ get; set; }         

}
