using System;
using System.Collections.Generic;

namespace EfCore.Data.ScaffoldModels;

public partial class Coach
{
    public int CoachId { get; set; }

    public string CoachName { get; set; } = null!;

    public DateTime CreatedDate { get; set; }
}
