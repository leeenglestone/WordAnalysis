namespace WordAnalysis.ConsoleApplication
{
    public class Letter
    {
        public string Value { get; set; }
        public int StartingWith { get; set; }
        public double StartingWithPercentage { get; set; }
        public int EndingWith { get; set; }
        public double EndingWithPercentage { get; set; }
        public int DoubleLetters { get; set; }
    }
}
