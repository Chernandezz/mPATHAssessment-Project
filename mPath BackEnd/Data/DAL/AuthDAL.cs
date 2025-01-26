using System;
using System.Linq;
using Model.Models;
using Common.ViewModels;
using Common.Helpers; // Asegúrate de agregar esto

namespace Data.DAL
{
    public class AuthDAL
    {
        public static AuthVMR Login(string email, string passwordHash)
        {
            using (var db = DbConnection.Create())
            {
                var user = db.Users
                    .Where(x => x.Email == email && x.PasswordHash == passwordHash && !x.IsDeleted)
                    .Select(x => new AuthVMR
                    {
                        Email = x.Email,
                        Role = x.Role
                    })
                    .FirstOrDefault();

                return user;
            }
        }

        public static bool Register(string email, string password, string role)
        {
            using (var db = DbConnection.Create())
            {
                // Validar si el usuario ya existe
                if (db.Users.Any(x => x.Email == email))
                    return false;

                var passwordHash = Utils.EncryptPassword(password);

                db.Users.Add(new Users
                {
                    Email = email,
                    PasswordHash = passwordHash,
                    Role = role,
                    IsDeleted = false
                });

                db.SaveChanges();
                return true;
            }
        }
    }
}
