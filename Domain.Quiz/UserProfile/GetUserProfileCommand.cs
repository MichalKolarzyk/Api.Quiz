using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Quiz.UserProfile
{
    public class GetUserProfileCommand : IRequest<GetUserProfileResponse>
    {
        public Guid AccountId { get; set; }
    }
}
