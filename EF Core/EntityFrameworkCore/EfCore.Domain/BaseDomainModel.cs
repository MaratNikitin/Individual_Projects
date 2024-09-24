using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCore.Domain;

public abstract class BaseDomainModel
{
    public DateTime CreatedDate { get; set; }
}
