using System.ComponentModel.DataAnnotations;

namespace TodoApi.DTO;

public class Todocreate
{
   [Required][MinLength(3)] public string title{get; set;}="";
    public bool completed{get; set;}=false;
    public string description { get; set; }="";
    public string priority { get; set; }="low";
    public DateTime? duedate { get; set; }

}
