using UnityEngine;

namespace asim.unity.extensions
{
    /// <summary>
    /// Extension Class for Unity Assets/StreamingAssets/Resources etc..
    /// </summary>
    public static class AssetsExtentions
    {
        /// <summary>
        /// Read a text asset and return it as lines of strings
        /// </summary>
        public static string[] ReadLinesTextAsset(TextAsset textasset)
        {
            string[] tilemapstring = textasset.text.Split('\n');

            return tilemapstring;
        }

        /// <summary>
        /// Read a text asset and return it as lines of char array
        /// </summary>
        public static char[][] ReadCharArrayTextAsset(TextAsset textasset)
        {
            string[] tilemapstring = ReadLinesTextAsset(textasset);
            return TextExtension.StringArrayToCharArray(tilemapstring);
        }
    }
}