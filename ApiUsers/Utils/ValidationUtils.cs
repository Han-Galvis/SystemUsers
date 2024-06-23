using ApiUsers.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace ApiUsers.Utils
{
    public  class ValidationUtils
    {

        public List<ValidationErrorResponse> ValidateUser(User user)
        {
            try{
                List<ValidationErrorResponse> val = new List<ValidationErrorResponse>();
                string pattern = @"^[a-zA-Z ]+$";
                string mail = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
                if (user == null)
                {
                    val.Add(new ValidationErrorResponse { Message = "No ingresó información para el usuario" });
                }
                else
                {
                    if (string.IsNullOrEmpty(user.Fullname))
                    {
                        val.Add(new ValidationErrorResponse { Message = "No ingresó información en el nombre" });
                    }
                    if (string.IsNullOrEmpty(user.Email))
                    {
                        val.Add(new ValidationErrorResponse { Message = "No ingresó información en el email" });
                    }
                    if (string.IsNullOrEmpty(user.Password))
                    {
                        val.Add(new ValidationErrorResponse { Message = "No ingresó información de la contraseña" });
                    }
                    if (!Regex.IsMatch(user.Email, mail))
                    {
                        val.Add(new ValidationErrorResponse { Message = "Ingrese correctamente el correo" });
                    }
                    if (!Regex.IsMatch(user.Fullname, pattern))
                    {
                        val.Add(new ValidationErrorResponse { Message = "Ingreso un caracter especial en el nombre" });
                    }
                }
                return val;

            }
            catch(Exception ex) {
                List<ValidationErrorResponse> err = new List<ValidationErrorResponse>();
                err.Add(new ValidationErrorResponse { Message = ex.Message });
                return err;
            }

        }
    }
}
