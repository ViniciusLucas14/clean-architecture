using System;

namespace CleanArchMVC.Domain.Interfaces.Account
{
    public interface ISeedUserRoleInitial
    {
        void SeedUsers();
        void SeedRoles();
    }
}