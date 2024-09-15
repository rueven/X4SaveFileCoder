using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace X4.SaveFile.Objects.Implementations
{
    public struct Code
    {
        #region Static Methods

        public static bool TryParse(string? value, out Code result)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                result = default;
                return false;
            }
            var parts = value
                .Split('-', StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length == 2 && IsValidPrefix(parts[0]) && int.TryParse(parts[1], out var id) && IsValidId(id))
            {
                result = new Code()
                {
                    Id = id,
                    Prefix = PrefixToInteger(parts[0])
                };
                return true;
            }
            result = default;
            return false;
        }

        public static Code? Parse(string value)
        {
            if (Code.TryParse(value, out Code result))
            {
                return result;
            }
            return null;
        }

        private static int PrefixToInteger(string value)
        {
            var bytes = ASCIIEncoding
                .Default
                .GetBytes(value)
                .ToList();
            bytes.Insert(0, Byte.MinValue);
            var output = BitConverter
                .ToInt32(bytes.ToArray());
            return output;
        }

        private static string IntegerToPrefix(int value)
        {
            var bytes = BitConverter
                .GetBytes(value);
            var output = ASCIIEncoding
                .Default
                .GetString(bytes.Skip(1).ToArray(), 0, bytes.Length - 1);
            return output;
        }

        private static bool IsValidId(int id) => id > -1 && id < 1000;

        private static bool IsValidPrefix(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length != 3)
            {
                return false;
            }
            return value
                .All(x => Char.IsAsciiLetterUpper(x));
        }

        #endregion

        #region Constants

        public static readonly Code Empty = new Code() { Id = 0, Prefix = 0 };
        public const short MaximumId = 999;
        public const short MinimumId = 0;

        #endregion

        public required int Prefix { get; init; }
        public required int Id { get; init; }

        public string PrefixCode => IntegerToPrefix(this.Prefix);
        public string IdCode => this.Id.ToString("D3");
        public string Value => $"{this.PrefixCode}-{this.IdCode}";

        #region Overrides

        public override string ToString() => this.Value;

        public override bool Equals([NotNullWhen(true)] object? obj)
        {
            return base
                .Equals(obj);
        }

        public override int GetHashCode()
        {
            return this
                .Value
                .GetHashCode();
        }

        #endregion

        #region Operators

        public static bool operator <(Code a, Code b)
        {
            if (a.Prefix < b.Prefix)
            {
                return true;
            }
            return a.Id < b.Id;
        }

        public static bool operator >(Code a, Code b)
        {
            if (a.Prefix > b.Prefix)
            {
                return true;
            }
            return a.Id > b.Id;
        }

        public static bool operator <=(Code a, Code b)
        {
            if (a.Prefix <= b.Prefix)
            {
                return true;
            }
            return a.Id <= b.Id;
        }

        public static bool operator >=(Code a, Code b)
        {
            if (a.Prefix >= b.Prefix)
            {
                return true;
            }
            return a.Id >= b.Id;
        }

        public static bool operator ==(Code a, Code b)
        {
            return a.Value == b.Value;
        }

        public static bool operator !=(Code a, Code b)
        {
            return a.Value != b.Value;
        }

        public static Code operator +(Code a, int b)
        {
            var id = a.Id + b;
            if (IsValidId(id))
            {
                return new Code()
                {
                    Prefix = a.Prefix,
                    Id = id
                };
            }
            throw new ArithmeticException("Id can have minimum value of 0 and maximum value of 999.");
        }

        public static Code operator -(Code a, int b)
        {
            var id = a.Id - b;
            if (IsValidId(id))
            {
                return new Code()
                {
                    Prefix = a.Prefix,
                    Id = id
                };
            }
            throw new ArithmeticException("Id can have minimum value of 0 and maximum value of 999.");
        }

        public static implicit operator Code(string value)
        {
            if (Code.TryParse(value, out var code))
            {
                return code;
            }
            throw new InvalidCastException($"Cannot convert '{value}' to type ComponentCode");
        }

        #endregion
    }
}