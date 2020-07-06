namespace TEST
{
    public static class Extensions
    {
        /// <summary>
        /// Returns what follows after the first occurence of a given character
        /// </summary>
        /// <param name="s"></param>
        /// <param name="separator"></param>
        /// <returns></returns>
        public static string GetAfter(this string s, string separator)
        {
            int index = s.IndexOf(separator);
            if (index < 0) 
                return null;
            return s.Substring(s.IndexOf(separator) + separator.Length);
        }
        
        /// <summary>
        /// Returns what follows before the first occurence of a given character
        /// </summary>
        /// <param name="s"></param>
        /// <param name="separator"></param>
        /// <returns></returns>
        public static string GetBefore(this string s, string separator)
        {
            int index = s.IndexOf(separator);
            if (index < 0) 
                return null;
            return s.Substring(0,s.IndexOf(separator));
        }
    }
    
}