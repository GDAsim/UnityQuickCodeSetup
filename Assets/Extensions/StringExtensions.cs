public static class StringExtensions
{
    //====================================================================================================
    //====================================================================================================

    /// <summary>
    /// returns true if the entire string is numeric
    /// </summary>
    public static bool IsNumeric(this string str)
    {
        if (string.IsNullOrEmpty(str))
        {
            return false;
        }

        foreach (char c in str)
        {
            if (c < '0' || c > '9') return false;
        }

        return true;
    }

    /// <summary>
    /// returns true if any part of the string is numeric
    /// </summary>
    public static bool HasNumeric(this string str)
    {
        if (string.IsNullOrEmpty(str))
        {
            return false;
        }

        foreach (char c in str)
        {
            if (c >= '0' && c <= '9') return true;
        }

        return true;
    }

    /// <summary>
    /// returns true if the entire string is alpha
    /// https://www.ssec.wisc.edu/~tomw/java/unicode.html#x0000
    /// </summary>
    public static bool IsAlpha(this string str)
    {
        if (string.IsNullOrEmpty(str))
        {
            return false;
        }

        foreach (char c in str)
        {
            if (c < 'A')// A to Z == 65 to 90
            {
                return false;
            }

            if (c > 90 && c < 97) // a to z == 97 to 122
            {
                return false;
            }

            if (c > 122)
            {
                return false;
            }
        }

        return true;
    }


    /// <summary>
    /// returns true if the entire string is alphanumeric
    /// https://www.ssec.wisc.edu/~tomw/java/unicode.html#x0000
    /// </summary>
    public static bool IsAlphaNumeric(this string str)
    {
        if (string.IsNullOrEmpty(str))
        {
            return false;
        }

        foreach (char c in str)
        {
            if (c < 48) // 0 to 9 == 48 to 57 
            {
                return false;
            }

            if (c > 57 && c < 65) // A to Z == 65 to 90
            {
                return false;
            }

            if (c > 90 && c < 97) // a to z == 97 to 122
            {
                return false;
            }

            if (c > 122)
            {
                return false;
            }
        }

        return true;
    }

    //====================================================================================================
    //====================================================================================================
}
