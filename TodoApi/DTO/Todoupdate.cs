using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Antiforgery;

namespace TodoApi.DTO;

public record class Todoupdate
{
   [Required][MinLength(3)] public string title { get; set; }="";
    public string description { get; set; }="";
    public string priority { get; set; }
    public DateTime? duedate { get; set; }
    public bool completed{ get; set; }         

}
