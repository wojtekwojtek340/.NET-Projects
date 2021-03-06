﻿using BlazorApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Services.User
{
    public interface IUserService
    {
        Task<UserData> GetMe();
        Task<UserData> GetById(int id);
    }
}
