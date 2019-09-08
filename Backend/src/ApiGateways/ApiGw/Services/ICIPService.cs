using ApiGw.Authentication.Models;
using ApiGw.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiGw.Services
{
    public interface ICIPService
    {
        Task<EmissorViewModel> EmissorLoginAsync(AuthModel authModel);
    }
}
