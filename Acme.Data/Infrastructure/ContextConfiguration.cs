using System.Collections.Generic;
using System.ComponentModel.Composition;

namespace Acme.Data.Infrastructure
{
    public class ContextConfiguration
    {
        [ImportMany(typeof(IEntityConfiguration))]
        public IEnumerable<IEntityConfiguration> Configurations { get; set; }
    }
}
