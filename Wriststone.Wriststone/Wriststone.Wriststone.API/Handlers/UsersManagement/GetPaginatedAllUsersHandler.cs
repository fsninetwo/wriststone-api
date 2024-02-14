using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using Wriststone.Wriststone.Data.Models;
using Wriststone.Wriststone.Services.IServices;
using Wriststone.Common.Domain.Pagination;

namespace Wriststone.Wriststone.API.Handlers.UsersManagement
{
    public class GetPaginatedAllUsersRequest : IRequest<PagedList<UsersManagementDTO>> 
    {
        public GetPaginatedAllUsersRequest(PaginationParameters pagination)
        {
            Pagination = pagination;
        }

        public PaginationParameters Pagination { get; }
    }

    public class GetPaginatedAllUsersHandler : IRequestHandler<GetPaginatedAllUsersRequest, PagedList<UsersManagementDTO>>
    {
        private readonly IUserManagementService _userManagementService;

        public GetPaginatedAllUsersHandler(IUserManagementService userManagementService)
        {
            _userManagementService = userManagementService;
        }

        public async Task<PagedList<UsersManagementDTO>> Handle(GetPaginatedAllUsersRequest request, CancellationToken cancellationToken)
        {
            var users = await _userManagementService.GetPaginatedAllUsersAsync(request.Pagination);

            return users;
        }
    }
}
