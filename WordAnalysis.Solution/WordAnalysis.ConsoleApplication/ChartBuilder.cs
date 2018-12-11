using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;

namespace WordAnalysis.ConsoleApplication
{
    public class ChartBuilder
    {
        public static Chart GetChart(IDictionary<string, int> data, string title)
        {
            var chart = new Chart();
            chart.Width = 600;
            chart.Titles.Add(title);

            var series = new Series();
            series.Points.DataBindXY(data.Keys, data.Values);
            chart.Series.Add(series);

            var chartArea = new ChartArea();
            chartArea.AxisX.Interval = 1;
            chartArea.AxisX.Title = "Letter";
            chartArea.AxisX.MajorGrid.Enabled = false;
            chartArea.AxisX.MinorGrid.Enabled = false;
            chartArea.AxisY.Title = "Frequency";
            chartArea.AxisY.LabelStyle.Format = "{0:0,}K";

            chart.ChartAreas.Add(chartArea);

            return chart;
        }

        public static Chart GetChart(IDictionary<int, int> data, string title, string xAxis, string yAxis)
        {
            var chart = new Chart();
            chart.Width = 600;
            chart.Titles.Add(title);

            var series = new Series();
            series.Points.DataBindXY(data.Keys, data.Values);
            chart.Series.Add(series);

            var chartArea = new ChartArea();
            chartArea.AxisX.Interval = 1;
            chartArea.AxisX.Title = xAxis;
            chartArea.AxisX.MajorGrid.Enabled = false;
            chartArea.AxisX.MinorGrid.Enabled = false;
            chartArea.AxisY.Title = yAxis;
            chartArea.AxisY.LabelStyle.Format = "{0:0,}K";

            chart.ChartAreas.Add(chartArea);

            return chart;
        }

        public static void SaveChart(Chart chart, string filePath)
        {
            chart.SaveImage(filePath, ChartImageFormat.Png);
        }

        public static void SaveLetterFrequencyChart(SortedDictionary<string, int> letterFrequency)
        {
            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "charts/letter-frequency.png");
            ChartBuilder.SaveChart(ChartBuilder.GetChart(letterFrequency, "Letter Frequency"), filePath);
        }

        public static void SaveLetterStartingWithChart(List<Letter> letters)
        {
            var data = letters.OrderBy(x => x.Value).ToDictionary(x => x.Value, x => x.StartingWith);
            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "charts/letter-ending-with.png");
            ChartBuilder.SaveChart(ChartBuilder.GetChart(data, "Ending With Frequency"), filePath);
        }

        public static void SaveLetterEndingWithChart(List<Letter> letters)
        {
            var data = letters.OrderBy(x => x.Value).ToDictionary(x => x.Value, x => x.EndingWith);
            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "charts/letter-starting-with.png");
            ChartBuilder.SaveChart(ChartBuilder.GetChart(data, "Starting With Frequency"), filePath);
        }

        public static void SaveWordLengthFrequencyChart(SortedDictionary<int, int> wordLengthFrequency)
        {
            var data = wordLengthFrequency.ToDictionary(x => x.Key, x => x.Value);
            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "charts/word-length-with.png");
            ChartBuilder.SaveChart(ChartBuilder.GetChart(data, "Word Length Frequency", "Word Length", "Frequency"), filePath);
        }

        public static void SaveDoubleLetterFrequencyChart(SortedDictionary<string, int> doubleLetterFrequency)
        {
            var data = doubleLetterFrequency.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "charts/double-letters.png");
            ChartBuilder.SaveChart(ChartBuilder.GetChart(data, "Double Letter Frequency"), filePath);
        }
    }
}
