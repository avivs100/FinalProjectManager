using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Grade
    {
        public int ID;
        public string Description { get; set; } = null!;
        public int GradeCollectionId { get; set; }
        public int Score { get; set; }
        public int Precentage { get; set; }
        public string Name { get; set; }
    }
}
