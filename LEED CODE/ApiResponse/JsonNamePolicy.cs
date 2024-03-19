using System.Text;
using System.Text.Json;

namespace LEED_CODE.ApiResponse
{
    public class JsonNamePolicy : JsonNamingPolicy
    {
        public override string ConvertName(string name)
        {
            StringBuilder builder = new StringBuilder();
            var firstChar = builder.Append(char.ToLower(name[0]));

            for(int i = 1; i < name.Length; i++)
            {
                if (char.IsDigit(name[i]) || char.IsUpper(name[i]))
                {
                    builder.Append('_');
                    builder.Append(name[i]);
                }
                else
                {
                    builder.Append(name[i]);
                }
            }
            return builder.ToString();
        }
    }
}
