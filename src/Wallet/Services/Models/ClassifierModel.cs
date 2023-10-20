using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Services.Models
{
    public class ClassifierModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public ClassifierModel()
        {
            Name = string.Empty;
        }

    }
}
