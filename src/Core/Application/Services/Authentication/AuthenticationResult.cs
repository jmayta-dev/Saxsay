using MW.SAXSAY.Core.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW.SAXSAY.Core.Application.Services.Authentication
{
    public record AuthenticationResult(
        UserId UserId,
        string Username,
        string FirstName,
        string LastName,
        string Email,
        bool IsActive,
        DateTimeOffset DateJoined,
        Session? Session
    );
}
