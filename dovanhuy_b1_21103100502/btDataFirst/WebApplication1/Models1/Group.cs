using System;
using System.Collections.Generic;

namespace WebApplication1.Models1;

public partial class Group
{
    public int GroupId { get; set; }

    public string GroupName { get; set; } = null!;

    public string? Description { get; set; }
}
