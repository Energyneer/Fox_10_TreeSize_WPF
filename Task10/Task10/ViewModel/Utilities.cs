using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task10.ViewModel
{
    class Utilities
    {
        static readonly string[] SizeSuffixes =
                   { "bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };

        static readonly Dictionary<string, string> Extends = new Dictionary<string, string> { 
            { "exe", "Application" },
            { "doc", "Document" },
            { "docx", "Document" },
            { "pdf", "Acrobat Doc." },
            { "txt", "Text" } };

        public static string DisplaySize(long size, SizeFormat format)
        {
            switch (format)
            {
                case SizeFormat.AUTO: return AutoSize(size);
                case SizeFormat.KiB: return NotAuto(size, 1);
                case SizeFormat.MiB: return NotAuto(size, 2);
                case SizeFormat.GiB: return NotAuto(size, 3);
            }
            return "Error";
        }

        private static string AutoSize(Int64 value, int decimalPlaces = 1)
        {
            if (decimalPlaces < 0) { throw new ArgumentOutOfRangeException("decimalPlaces"); }
            if (value < 0) { return "-" + AutoSize(-value, decimalPlaces); }
            if (value == 0) { return string.Format("{0:n" + decimalPlaces + "} bytes", 0); }
            int mag = (int)Math.Log(value, 1024);
            decimal adjustedSize = (decimal)value / (1L << (mag * 10));
            if (Math.Round(adjustedSize, decimalPlaces) >= 1000)
            {
                mag += 1;
                adjustedSize /= 1024;
            }

            return string.Format("{0:n" + decimalPlaces + "} {1}",
                adjustedSize,
                SizeSuffixes[mag]);
        }

        private static string NotAuto(long size, int level)
        {
            double result = size;
            for (int i = 0; i < level; i++)
            {
                result /= 1024.0;
            }
            return string.Format("{0:0.00}", result) + " " + SizeSuffixes[level];
        }

        public static string GetFileType(string ext)
        {
            if (Extends.ContainsKey(ext))
                return Extends.GetValueOrDefault(ext);
            return "File";
        }
    }
}
