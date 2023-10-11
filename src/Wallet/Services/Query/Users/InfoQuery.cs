using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Domain.UserAggregate;
using Template.Services.Models;
using Xunit.Sdk;

namespace Template.Services.Query.Users
{
    public class InfoQuery : IRequest<InfoUserModel>
    {
    }
}
