using System;
using System.Collections.Generic;
using System.Linq;
using TheBookCave.Data;
using TheBookCave.Data.EntityModels;
using TheBookCave.Models.ViewModels;

namespace TheBookCave.Repositories {
    public class UserRoleRepo {
        private DataContext _db;

        public UserRoleRepo() {
            _db = new DataContext();
        }
        public List<UserRole> getAllUserRoles() {
            var roles = (from r in _db.AspNetUserRoles
                                select new UserRole {
                                 UserId = r.UserId,
                                 RoleId = r.RoleId   
                                }).ToList();
            return roles;
        }

        public bool updateUserRole(UserRole user) {
            _db.AspNetUserRoles.Update(user);
            _db.SaveChanges();
            return true;
        }
    }
}