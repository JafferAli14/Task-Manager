using System;
using System.ComponentModel.DataAnnotations;

namespace TodoApi.models;

public class Todo
{
    public int id { get; set; }
    [Required][StringLength(50)][MinLength(3)]public required string title { get; set; }
    public bool completed { get; set; }=false;
}
