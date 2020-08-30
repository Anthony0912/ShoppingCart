using ShoppingCartEntities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingCartDAL;
using System.Text.RegularExpressions;


namespace ShoppingCartBOL
{
    public class UserBOL
    {
        private UserDAL udal;
        private const string EXPEMAIL = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
        public UserBOL()
        {
            udal = new UserDAL();
        }
        public EUser Login(EUser eu)
        {
            if (string.IsNullOrEmpty(eu.Email) || string.IsNullOrEmpty(eu.Password) || 
                !(Regex.IsMatch(eu.Email, EXPEMAIL)) || eu.Password.Length < 8)
            {
                throw new Exception("El correo o contraseña son incorrectos.");
            }
            return udal.getAllUser(eu);
        }
        public void SignUp(EUser eu)
        {
            if (string.IsNullOrEmpty(eu.Name) || string.IsNullOrEmpty(eu.Lastname) ||
                string.IsNullOrEmpty(eu.Email) || string.IsNullOrEmpty(eu.Password))
            {
                throw new Exception("No es posible crear su cuenta.");
            }
            if (!Regex.IsMatch(eu.Email, EXPEMAIL))
            {
                throw new Exception("El formato del correo es invalido.");
            }
            //if (udal.getAllUser(eu) != null)
            //{
            //    throw new Exception("El correo ya existe.");
            //}
            udal.SignUp(eu);
        }
        public void UpdateUser(EUser eu)
        {
            if (string.IsNullOrEmpty(eu.Name) || string.IsNullOrEmpty(eu.Lastname) ||
                string.IsNullOrEmpty(eu.Email) || string.IsNullOrEmpty(eu.Password))
            {
                throw new Exception("No es posible crear su cuenta.");
            }
            udal.UpdateUser(eu);
        }
        
    }
}
