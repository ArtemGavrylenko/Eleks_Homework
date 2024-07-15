﻿
namespace ToDoApp.Data.Models;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<ToDoApp.Data.Models.Task> Tasks { get; set; }
}
