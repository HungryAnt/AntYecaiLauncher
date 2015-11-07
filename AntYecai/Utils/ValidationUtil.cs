using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace AntYecai.Utils
{
    public static class ValidationUtil
    {
        private static readonly Regex LoginNameRegex = new Regex(@"^[a-zA-Z0-9_]{3,16}$");

//        public static void GetErrors(StringBuilder sb, DependencyObject obj)
//        {
//            foreach (var child in LogicalTreeHelper.GetChildren(obj))
//            {
//                TextBox element = child as TextBox;
//                if (element == null) continue;
//
//                if (Validation.GetHasError(element))
//                {
//                    sb.AppendLine(element.Text + " 有错误:");
//                    foreach (var error in Validation.GetErrors(element))
//                    {
//                        sb.AppendLine(" " + error.ErrorContent.ToString());
//                    }
//                }
//                GetErrors(sb, element);
//            }
//        }

        public static bool TryValidateLoginName(String loginName, out string message)
        {
            if (!LoginNameRegex.IsMatch(loginName))
            {
                message = "英文或数字 3-16个字符";
                return false;
            }
            message = String.Empty;
            return true;
        }
    }
}
