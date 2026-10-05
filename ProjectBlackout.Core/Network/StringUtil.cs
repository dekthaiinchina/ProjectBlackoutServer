using System.Text;

namespace ProjectBlackout.Core.Network
{
    public class StringUtil
    {
        private static StringBuilder builder;

        public StringUtil()
        {
            builder = new StringBuilder();
        }

        public void AppendLine(string text)
        {
            builder.AppendLine(text);
        }

        public string getString()
        {
            if (builder.Length == 0)
            {
                return builder.ToString();
            }
            return builder.Remove(builder.Length - 1, 1).ToString();
        }
    }
}