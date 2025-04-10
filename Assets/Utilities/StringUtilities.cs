using UnityEngine;

public class StringUtilities : MonoBehaviour
{
    /// <summary>
    /// Number presented in Roman numerals
    /// </summary>
    public static string GetRomanNumerals(int i)
    {
        if (i > 999) return "M" + GetRomanNumerals(i - 1000);
        if (i > 899) return "CM" + GetRomanNumerals(i - 900);
        if (i > 499) return "D" + GetRomanNumerals(i - 500);
        if (i > 399) return "CD" + GetRomanNumerals(i - 400);
        if (i > 99) return "C" + GetRomanNumerals(i - 100);
        if (i > 89) return "XC" + GetRomanNumerals(i - 90);
        if (i > 49) return "L" + GetRomanNumerals(i - 50);
        if (i > 39) return "XL" + GetRomanNumerals(i - 40);
        if (i > 9) return "X" + GetRomanNumerals(i - 10);
        if (i > 8) return "IX" + GetRomanNumerals(i - 9);
        if (i > 4) return "V" + GetRomanNumerals(i - 5);
        if (i > 3) return "IV" + GetRomanNumerals(i - 4);
        if (i > 0) return "I" + GetRomanNumerals(i - 1);
        return "";
    }
}
