using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BikeStore_API.Models;

public partial class Part
{
    public int PartId { get; set; }
    public string? PartName { get; set; }
}
