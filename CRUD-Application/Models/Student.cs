using System;
using System.Collections.Generic;

namespace CRUD_Application.Models;

public partial class Student
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? Age { get; set; }

    public string? City { get; set; }

    public string? Phone { get; set; }

    public string? Dob { get; set; }
}
