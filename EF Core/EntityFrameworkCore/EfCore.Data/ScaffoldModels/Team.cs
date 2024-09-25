using System;
using System.Collections.Generic;

namespace EfCore.Data.ScaffoldModels;

public partial class Team
{
    public int TeamId { get; set; }

    public string TeamName { get; set; } = null!;

    public DateTime CreatedDate { get; set; }
}
