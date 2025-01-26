using System;

namespace Common.ViewModels
{
    public class AuthVMR
    {
        public string Token { get; set; } // Token JWT generado
        public string Email { get; set; } // Email del usuario autenticado
        public string Role { get; set; }  // Rol del usuario (Admin/Doctor)
        public DateTime Expiration { get; set; } // Fecha de expiración del token
    }
}
