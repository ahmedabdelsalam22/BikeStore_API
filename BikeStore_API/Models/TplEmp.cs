using System;
using System.Collections.Generic;

namespace BikeStore_API.Models;

public partial class TplEmp
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? Sallary { get; set; }

    public string? City { get; set; }

    public string? Gender { get; set; }
}
