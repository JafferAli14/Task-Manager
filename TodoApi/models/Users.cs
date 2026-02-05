using System.ComponentModel.DataAnnotations;

namespace TodoApi.models;

public class Users
{
    public int id { get; set; }
   [Required] public string username { get; set; }="";
    [Required ]public string passwordhash { get; set; }="";

}
