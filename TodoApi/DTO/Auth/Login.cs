using System.ComponentModel.DataAnnotations;

namespace TodoApi.DTO.Auth;

public class Login
{
   [Required] public string username { get; set; }="";
   [Required] public string password { get; set; }="";
    
}
