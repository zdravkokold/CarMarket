﻿using HouseRentingSystem.Core.Models.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMarket.Services.Admins
{
    public interface IUserService
    {
        IEnumerable<UserServiceModel> All();
    }
}
