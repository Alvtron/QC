
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace QuestCompanion.Model
{
    public static class Validation
    {
        public enum Password
        {
            TOO_SHORT,
            TOO_LONG,
            NO_SYMBOL,
            NO_NUMBER,
            NO_LOWER_CASE,
            NO_UPPER_CASE,
            EMPTY,
            VALID,
            UNASSIGNED
        };

        public enum Email
        {
            INVALID,
            VALID
        };

        public static Email IsValidEmail(string email)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);

            if (!match.Success)
                return Email.INVALID;
            else
                return Email.VALID;
        }

        public static Password IsValidPassword(string password)
        {
            const int MIN_LENGTH = 8, MAX_LENGTH = 100;
            Regex hasNumber = new Regex(@"[0-9]+");
            Regex hasUpperChar = new Regex(@"[A-Z]+");
            Regex hasLowerChar = new Regex(@"[a-z]+");
            Regex hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");

            if (password.Length < MIN_LENGTH)
            {
                return Password.TOO_SHORT;
            }
            else if (password.Length > MAX_LENGTH)
            {
                return Password.TOO_LONG;
            }
            else if (String.IsNullOrWhiteSpace(password))
            {
                return Password.EMPTY;
            }
            if (!hasLowerChar.IsMatch(password))
            {
                return Password.NO_LOWER_CASE;
            }
            else if (!hasUpperChar.IsMatch(password))
            {
                return Password.NO_UPPER_CASE;
            }
            else if (!hasNumber.IsMatch(password))
            {
                return Password.NO_NUMBER;
            }
            else if (!hasSymbols.IsMatch(password))
            {
                return Password.NO_SYMBOL;
            }
            else
            {
                return Password.VALID;
            }
        }
    }
}
