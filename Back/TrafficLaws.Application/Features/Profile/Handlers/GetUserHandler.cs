using MediatR;
using TrafficLaws.Application.Features.Profile.Queries;
using TrafficLaws.Application.Interfaces.Repository;
using TrafficLaws.Application.Responses.User;

namespace TrafficLaws.Application.Features.Profile.Handlers;

public class GetUserHandler : IRequestHandler<GetUserQuery, UserResponse>
{
    private readonly IUserRepository _userRepository;

    public GetUserHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<UserResponse> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetById(Guid.Parse(request.Id), cancellationToken);

        return new UserResponse
        {
            IsSuccessfully = true,
            Name = user.FullName,
            Id = user.Id,
            Email = user.Email,
            EmailConfirm = user.EmailConfirmed,
            UserInfo = user.UserInfo
        };
    }
}