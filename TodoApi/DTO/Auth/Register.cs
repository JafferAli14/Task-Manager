using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Antiforgery;

namespace TodoApi.DTO.Auth;

public class Register
{
    [Required]   public string username { get; set; }   ="";
    [Required]public string password { get; set; }="";

}
