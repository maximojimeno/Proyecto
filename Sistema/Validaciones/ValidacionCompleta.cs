using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Controls;

namespace Sistema.Validaciones
{
     class ValidacionCompleta : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string mensaje = value as string;
            if(mensaje!=null)
            {
                if (mensaje.Length <= 0)
                    return new ValidationResult(false, "No puede estar vacio");
                return ValidationResult.ValidResult;
            }
            return new ValidationResult(false, "Favor llenar el campo:(");
        }
    }
}
