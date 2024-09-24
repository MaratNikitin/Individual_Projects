using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCore.Domain;

public class Coach: BaseDomainModel
{
    public int CoachId { get; set; }
    public string CoachName { get; set; } = string.Empty;

}
