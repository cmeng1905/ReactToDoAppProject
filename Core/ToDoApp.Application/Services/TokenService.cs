using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Application.Abstractions.Services;
using ToDoApp.Application.Options;

namespace ToDoApp.Application.Services
{
    public class TokenService(JwtAuth _jwtAuth) : ITokenService
    {
    }
}
