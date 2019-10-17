using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.IO;

namespace RPSBRresultsAnalyzer
{
    class Program
    {
        static void Main()
        {
            Analyzer analyzer = new Analyzer();
            analyzer.BeginAnalysis();
        }
    }
}
