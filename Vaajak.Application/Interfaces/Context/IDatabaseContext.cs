using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vaajak.Domain.Entities;

namespace Vaajak.Application.Interfaces.Context
{
    public interface IDatabaseContext
    {
        DbSet<Vocab> Vocabs { get; set; }
        DbSet<Package> Packages { get; set; }
        DbSet<Example> Examples { get; set; }
        DbSet<Translate> Translates { get; set; }
    }
}
