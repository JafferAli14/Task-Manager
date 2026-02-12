using System.ComponentModel.DataAnnotations;

namespace TodoApi.models;

public class Todo
{
    public int id { get; set; }
    [Required][StringLength(50)][MinLength(3)]public required string title { get; set; }
    public string priority { get; set; }="low";
    public string  description { get; set; }="";
    public bool completed { get; set; }=false;
    public DateTime? duedate { get; set; }
    public int userid{get; set;}
    public Users user { get; set; }

}
