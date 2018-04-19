using System.Text;

namespace PaySharp.Core.Utils
{
    public enum StringCase
    {
        /// <summary>
        /// 蛇形策略
        /// </summary>
        Snake,

        /// <summary>
        /// 骆驼策略
        /// </summary>
        Camel,

        /// <summary>
        /// 不执行策略
        /// </summary>
        None
    }

    internal enum SnakeCaseState
    {
        Start,
        Lower,
        Upper,
        NewWord
    }

    public static class StringUtil
    {
        /// <summary>
        /// 将字符串转换为蛇形策略
        /// </summary>
        /// <param name="s">字符串</param>
        /// <returns></returns>
        public static string ToSnakeCase(this string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return s;
            }

            StringBuilder sb = new StringBuilder();
            SnakeCaseState state = SnakeCaseState.Start;

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == ' ')
                {
                    if (state != SnakeCaseState.Start)
                    {
                        state = SnakeCaseState.NewWord;
                    }
                }
                else if (char.IsUpper(s[i]))
                {
                    switch (state)
                    {
                        case SnakeCaseState.Upper:
                            bool hasNext = (i + 1 < s.Length);
                            if (i > 0 && hasNext)
                            {
                                char nextChar = s[i + 1];
                                if (!char.IsUpper(nextChar) && nextChar != '_')
                                {
                                    sb.Append('_');
                                }
                            }
                            break;
                        case SnakeCaseState.Lower:
                        case SnakeCaseState.NewWord:
                            sb.Append('_');
                            break;
                    }

                    sb.Append(char.ToLowerInvariant(s[i]));

                    state = SnakeCaseState.Upper;
                }
                else if (s[i] == '_')
                {
                    sb.Append('_');
                    state = SnakeCaseState.Start;
                }
                else
                {
                    if (state == SnakeCaseState.NewWord)
                    {
                        sb.Append('_');
                    }

                    sb.Append(s[i]);
                    state = SnakeCaseState.Lower;
                }
            }

            return sb.ToString();
        }

        /// <summary>
        /// 将字符串转换为骆驼策略
        /// </summary>
        /// <param name="s">字符串</param>
        /// <returns></returns>
        public static string ToCamelCase(this string s)
        {
            if (string.IsNullOrEmpty(s) || !char.IsUpper(s[0]))
            {
                return s;
            }

            char[] chars = s.ToCharArray();

            for (int i = 0; i < chars.Length; i++)
            {
                if (i == 1 && !char.IsUpper(chars[i]))
                {
                    break;
                }

                bool hasNext = (i + 1 < chars.Length);
                if (i > 0 && hasNext && !char.IsUpper(chars[i + 1]))
                {
                    if (char.IsSeparator(chars[i + 1]))
                    {
                        chars[i] = char.ToLowerInvariant(chars[i]);
                    }

                    break;
                }

                chars[i] = char.ToLowerInvariant(chars[i]);
            }

            return new string(chars);
        }
    }
}
