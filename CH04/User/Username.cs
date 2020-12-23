using System;
using System.Text.RegularExpressions;

namespace User
{
    public class Username
    {
        public string Value { get; private set; }
        private const string validUsernamePattern = @"^[a-z0-9]{1,8}$";

        public Username(string username)
        {
            if (username is null)
            {
                throw new ArgumentNullException(nameof(username));
            }
            if (!Regex.IsMatch(username, validUsernamePattern))
            {
                throw new ArgumentException(nameof(username),
                  "Invalid username");
            }
            this.Value = username;
        }

        public override string ToString() => base.ToString();

        public override int GetHashCode() => Value.GetHashCode();

        public override bool Equals(object obj)
        {
            return obj is Username other && other.Value == Value;
        }

        public static implicit operator string(Username username)
        {
            return username.Value;
        }

        public static bool operator ==(Username a, Username b)
        {
            return a.Value == b.Value;
        }

        public static bool operator !=(Username a, Username b)
        {
            return !(a == b);
        }
    }
}