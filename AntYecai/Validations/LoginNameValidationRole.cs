using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace AntYecai.Validations
{
    public class LoginNameValidationRole : ValidationRule
    {
        private static readonly Regex Regex = new Regex(@"^[a-zA-Z0-9_]{3,16}$");

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (!Regex.IsMatch(value as String))
            {
                return new ValidationResult(false, "只能使用英文或数字,长度为3-16字符");   
            }
            return new ValidationResult(true, null);
        }
    }
}
