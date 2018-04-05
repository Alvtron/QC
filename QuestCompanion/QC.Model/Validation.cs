
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace QC.Model
{
    public static class Validation
    {
        public enum General
        {
            EMPTY,
            ALREADY_EXIST,
            DONT_EXIST
        };

        public enum User
        {
            INVALID_USERNAME,
            INVALID_EMAIL,
            INVALID_PASSWORD,
            USER_CREATED
        };

        public enum Username
        {
            EMPTY,
            TOO_SHORT,
            TOO_LONG,
            CONTAINS_ILLEGAL_CHARACTERS,
            ALREADY_EXIST,
            UNAVAILABLE,
            VALID
        };

        public enum Password
        {
            EMPTY,
            TOO_SHORT,
            TOO_LONG,
            NO_SYMBOL,
            NO_NUMBER,
            NO_LOWER_CASE,
            NO_UPPER_CASE,
            VALID
        };

        public enum Email
        {
            EMPTY,
            INVALID,
            VALID
        };

        public static Email ValidateEmail(string email)
        {
            Regex emailRegex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

            if (String.IsNullOrWhiteSpace(email))
            {
                return Email.EMPTY;
            }
            else if (!emailRegex.IsMatch(email))
                return Email.INVALID;
            else
                return Email.VALID;
        }

        internal static Username ValidateUsername(string username)
        {
            const int MIN_LENGTH = 3, MAX_LENGTH = 30;
            Regex validCharacters = new Regex(@"[a-zA-Z0-9¨_]+$");

            if (String.IsNullOrWhiteSpace(username))
            {
                return Username.EMPTY;
            }
            else if (username.Length <= MIN_LENGTH)
            {
                return Username.TOO_SHORT;
            }
            else if (username.Length >= MAX_LENGTH)
            {
                return Username.TOO_LONG;
            }
            else if (!validCharacters.IsMatch(username))
                return Username.CONTAINS_ILLEGAL_CHARACTERS;
            else
                return Username.VALID;
        }

        public static Password ValidatePassword(string password)
        {
            const int MIN_LENGTH = 8, MAX_LENGTH = 100;
            Regex hasNumber = new Regex(@"[0-9]+");
            Regex hasUpperChar = new Regex(@"[A-Z]+");
            Regex hasLowerChar = new Regex(@"[a-z]+");
            Regex hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");

            if (String.IsNullOrWhiteSpace(password))
            {
                return Password.EMPTY;
            }
            else if (password.Length <= MIN_LENGTH)
            {
                return Password.TOO_SHORT;
            }
            else if (password.Length >= MAX_LENGTH)
            {
                return Password.TOO_LONG;
            }
            else if (!hasLowerChar.IsMatch(password))
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
