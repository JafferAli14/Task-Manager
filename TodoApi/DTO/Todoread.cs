namespace TodoApi.DTO;

public class Todoread
{
    public int id { get; set; }
    public string title { get; set; }="";
    public string description { get; set; }="";
    public string priority { get; set; }
    public DateTime? duedate { get; set; }
    public bool completed { get; set; }

}
