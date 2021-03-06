﻿using System;
using ExpenseManagement.Models;
using ExpenseManagement.Repository;
using Microsoft.AspNetCore.Identity;

namespace ExpenseManagement.Service
{
    public class RoleService:IRoleService
    {
        private IRoleRepository roleRepository;
        public RoleService(IRoleRepository roleRepository)
        {
            this.roleRepository = roleRepository;
        }

       

        public IdentityRole GetRole(string roleName)
        {
            return roleRepository.GetRole(roleName);
        }
    }
}
