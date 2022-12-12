using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public abstract class GradeCollection
    {
        protected GradeCollection(long id) {
            Id= id;
        }
        public long Id { get; private set; }
    }
}
