using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterSearch.Models
{
    public static class Parameters
    {
        public static string MainFolder(string subFolder = "") => @"BetterSearch\" + subFolder;
        public static string Name => "Better Search";
    }
}
