using System.Diagnostics.CodeAnalysis;

namespace My.CSharp.Namespace
{
    public static class TestExtensions
    {
        public static bool TryGetBirthday(this Test.READER data, out Date.READER result)
        {
            var field = data.Birthdate;
            
            if (field.which == Test.birthdate.WHICH.Value)
            {
                result = field.Value;
                return true;
            }

            result = default;
            return false;
        }
    }
}
