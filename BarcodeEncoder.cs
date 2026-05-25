using System;
using System.Collections.Generic;
using System.Text;

namespace NetBarcodeDotNet
{
    public static class BarcodeEncoder
    {
        #region Code 128 Patterns
        // Code 128 width patterns (6 values per character representing bar, space, bar, space, bar, space widths)
        private static readonly string[] Code128Patterns = new string[]
        {
            "212222", "222122", "222221", "121223", "121322", "131222", "122213", "122312", "132212", "221213", // 0-9
            "221312", "231212", "112232", "122132", "122231", "113222", "123122", "123221", "223211", "221132", // 10-19
            "221231", "213212", "223112", "312131", "311222", "321122", "321221", "312212", "322112", "322211", // 20-29
            "212123", "212321", "232121", "111323", "131123", "131321", "112313", "132113", "132311", "211313", // 30-39
            "231113", "231311", "112133", "112331", "132131", "113123", "113321", "133121", "313121", "211331", // 40-49
            "231131", "213113", "213311", "213131", "311123", "311321", "331121", "312113", "312311", "332111", // 50-59
            "314111", "221411", "431111", "111224", "111422", "121124", "121421", "141122", "141221", "112214", // 60-69
            "112412", "122114", "122411", "142112", "142211", "241211", "221114", "413111", "241112", "134111", // 70-79
            "111242", "121142", "121241", "114212", "124112", "124211", "411212", "421112", "421211", "212141", // 80-89
            "214121", "412121", "111143", "111341", "131141", "114113", "114311", "411113", "411311", "113141", // 90-99
            "114131", "311141", "411131" // 100-102
        };

        private const string Code128StartB = "211214";
        private const string Code128Stop = "2331112"; // stop uses 13 modules

        private static string WidthPatternToBinary(string pattern)
        {
            var sb = new StringBuilder();
            bool isBar = true;
            foreach (char c in pattern)
            {
                int width = c - '0';
                sb.Append(isBar ? new string('1', width) : new string('0', width));
                isBar = !isBar;
            }
            return sb.ToString();
        }
        #endregion

        #region Code 39 Patterns
        private static readonly Dictionary<char, string> Code39Patterns = new Dictionary<char, string>
        {
            {'0', "10100110110"}, {'1', "11010010101"}, {'2', "10110010101"}, {'3', "11011001010"}, 
            {'4', "10100110101"}, {'5', "11010011010"}, {'6', "10110011010"}, {'7', "10100101101"}, 
            {'8', "11010010110"}, {'9', "10110010110"}, {'A', "11010100101"}, {'B', "10110100101"}, 
            {'C', "11011010010"}, {'D', "10101100101"}, {'E', "11010110010"}, {'F', "10110110010"}, 
            {'G', "10101001101"}, {'H', "11010100110"}, {'I', "10110100110"}, {'J', "10101100110"}, 
            {'K', "11010101001"}, {'L', "10110101001"}, {'M', "11011010100"}, {'N', "10101101001"}, 
            {'O', "11010110100"}, {'P', "10110110100"}, {'Q', "10101011001"}, {'R', "11010101100"}, 
            {'S', "10110101100"}, {'T', "10101101100"}, {'U', "11001010101"}, {'V', "10011010101"}, 
            {'W', "11001101010"}, {'X', "10010110101"}, {'Y', "11001011010"}, {'Z', "10011011010"}, 
            {'-', "10010101101"}, {'.', "11001010110"}, {' ', "10011010110"}, {'*', "10010110110"}, 
            {'$', "10010010010"}, {'/', "10010010100"}, {'+', "10010100100"}, {'%', "10010010010"}
        };
        #endregion

        #region EAN-13 / EAN-8 Digits
        private static readonly string[] EanLeftA = { "0001101", "0011001", "0010011", "0111101", "0100011", "0110001", "0101111", "0111011", "0110111", "0001011" };
        private static readonly string[] EanLeftB = { "0100111", "0110011", "0011011", "0100001", "0011101", "0111001", "0000101", "0010001", "0001001", "0010111" };
        private static readonly string[] EanRightC = { "1110010", "1100110", "1101100", "1000010", "1011100", "1001110", "1010000", "1000100", "1001000", "1110100" };
        
        // EAN-13 structure mapping based on first digit
        private static readonly string[] Ean13Parity = { "AAAAAA", "AABABB", "AABBAB", "AABBBA", "ABAABB", "ABBAAB", "ABBBAA", "ABABAB", "ABABBA", "ABBABA" };
        #endregion

        public static string Encode(string text, string type)
        {
            if (string.IsNullOrEmpty(text)) return string.Empty;

            try
            {
                switch (type)
                {
                    case "Code 39":
                        return EncodeCode39(text.ToUpper());
                    case "EAN-13":
                        return EncodeEan13(text);
                    case "EAN-8":
                        return EncodeEan8(text);
                    case "Code 128":
                    default:
                        return EncodeCode128(text);
                }
            }
            catch
            {
                return string.Empty; // Fail gracefully by returning blank
            }
        }

        public static string EncodeCode128(string text)
        {
            // Standard Code 128 Set B Encoding
            var sb = new StringBuilder();
            
            // Add Start B
            sb.Append(WidthPatternToBinary(Code128StartB));
            
            int checksum = 104; // Start B value
            int position = 1;

            foreach (char c in text)
            {
                int val = c - 32;
                if (val < 0 || val > 102) val = 0; // Fallback to Space if out of bounds

                sb.Append(WidthPatternToBinary(Code128Patterns[val]));
                checksum += val * position;
                position++;
            }

            int checkVal = checksum % 103;
            sb.Append(WidthPatternToBinary(Code128Patterns[checkVal]));

            // Add Stop
            sb.Append(WidthPatternToBinary(Code128Stop));

            return sb.ToString();
        }

        public static string EncodeCode39(string text)
        {
            // Prepare clean Code 39 string with asterisks
            string cleaned = text;
            if (!cleaned.StartsWith("*")) cleaned = "*" + cleaned;
            if (!cleaned.EndsWith("*")) cleaned += "*";

            var sb = new StringBuilder();
            foreach (char c in cleaned)
            {
                if (Code39Patterns.TryGetValue(c, out string? pattern))
                {
                    sb.Append(pattern);
                    sb.Append('0'); // gap between characters
                }
            }
            
            if (sb.Length > 0) sb.Length--; // Remove final gap character
            return sb.ToString();
        }

        public static string EncodeEan13(string text)
        {
            // Parse only numeric digits
            var digits = new List<int>();
            foreach (char c in text)
            {
                if (char.IsDigit(c)) digits.Add(c - '0');
            }

            if (digits.Count < 12) return string.Empty; // Insufficient length

            // Pad or trim to 12 digits
            while (digits.Count > 12) digits.RemoveAt(digits.Count - 1);

            // Compute EAN-13 Checksum (13th digit)
            int sum = 0;
            for (int i = 0; i < 12; i++)
            {
                sum += digits[i] * (i % 2 == 0 ? 1 : 3);
            }
            int checksum = (10 - (sum % 10)) % 10;
            digits.Add(checksum);

            var sb = new StringBuilder();
            
            // Left Guard
            sb.Append("101");

            // Encode left-hand digits (1-6) using parity structure based on 0th digit
            int firstDigit = digits[0];
            string parity = Ean13Parity[firstDigit];

            for (int i = 1; i <= 6; i++)
            {
                int val = digits[i];
                if (parity[i - 1] == 'A')
                    sb.Append(EanLeftA[val]);
                else
                    sb.Append(EanLeftB[val]);
            }

            // Center Guard
            sb.Append("01010");

            // Encode right-hand digits (7-12) + checksum
            for (int i = 7; i <= 12; i++)
            {
                sb.Append(EanRightC[digits[i]]);
            }

            // Right Guard
            sb.Append("101");

            return sb.ToString();
        }

        public static string EncodeEan8(string text)
        {
            // Parse only digits
            var digits = new List<int>();
            foreach (char c in text)
            {
                if (char.IsDigit(c)) digits.Add(c - '0');
            }

            if (digits.Count < 7) return string.Empty;

            // Trim to 7 digits
            while (digits.Count > 7) digits.RemoveAt(digits.Count - 1);

            // Compute EAN-8 Checksum
            int sum = 0;
            for (int i = 0; i < 7; i++)
            {
                sum += digits[i] * (i % 2 == 0 ? 3 : 1);
            }
            int checksum = (10 - (sum % 10)) % 10;
            digits.Add(checksum);

            var sb = new StringBuilder();

            // Left Guard
            sb.Append("101");

            // Encode Left hand 4 digits
            for (int i = 0; i < 4; i++)
            {
                sb.Append(EanLeftA[digits[i]]);
            }

            // Center Guard
            sb.Append("01010");

            // Encode Right hand 4 digits (includes checksum)
            for (int i = 4; i < 8; i++)
            {
                sb.Append(EanRightC[digits[i]]);
            }

            // Right Guard
            sb.Append("101");

            return sb.ToString();
        }

        public static string GetChecksumDigitEan13(string text)
        {
            var digits = new List<int>();
            foreach (char c in text)
            {
                if (char.IsDigit(c)) digits.Add(c - '0');
            }
            if (digits.Count < 12) return "";
            int sum = 0;
            for (int i = 0; i < 12; i++)
            {
                sum += digits[i] * (i % 2 == 0 ? 1 : 3);
            }
            return ((10 - (sum % 10)) % 10).ToString();
        }
    }
}
