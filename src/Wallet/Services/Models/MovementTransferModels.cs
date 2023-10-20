using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Services.Models
{
    public class MovementTransferModel
    {
        public Guid Id { get; set; }
        public required string NameAccountOrigin { get; set; }
        public required string NameAccountDestiny { get; set; }


    }
}
