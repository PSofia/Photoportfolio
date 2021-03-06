﻿using Photoportfolio.Entities;
using Photoportfolio.Infrastructure.Core;
using System.Collections.Generic;

namespace Photoportfolio.Infrastructure.Services.Abstract
{
    public interface IMembershipService
    {
        MembershipContext ValidateUser(string username, string password);
        User CreateUser(string username, string email, string password, int[] roles);
        User GetUser(int userId);
        List<Role> GetUserRoles(string username);
    }
}
