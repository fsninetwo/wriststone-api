﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wriststone.Common.Domain.Pagination;
using Wriststone.Wriststone.Data.Models;

namespace Wriststone.Wriststone.Services.IServices
{
    public interface IUserManagementService
    {
        Task<IList<UsersManagementDTO>> GetAllUsersAsync();

        Task<PagedList<UsersManagementDTO>> GetPaginatedAllUsersAsync(PaginationParameters pagination);

        Task<IList<string>> GetAllUserRolesAsync();

        Task UpdateUserAsync(UsersManagementEditDTO updateUsers);

        Task RemoveUserAsync(long userId);

        Task<UsersManagementEditDTO> GetUserAsync(long userId);
        
    }
}
