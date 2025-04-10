namespace ScottPlotCookbook.Recipes.PlotTypes;

public class LinePlot : ICategory
{
    public Chapter Chapter => Chapter.PlotTypes;
    public string CategoryName => "Line Plot";
    public string CategoryDescription => "Line plots can be placed on the plot in coordinate " +
        "space using a Start, End, and an optional LineStyle.";

    public class LineQuickStart : RecipeBase
    {
        public override string Name => "Line Plot Quickstart";
        public override string Description => "Line plots are placed with a start and end " +
            "location in coordinate space. Their styles can be customized.";

        [Test]
        public override void Execute()
        {
            myPlot.Add.Line(1, 12, 12, 0);
            myPlot.Add.Line(7, 9, 42, 9);
            myPlot.Add.Line(30, 17, 30, 1);
        }
    }

    public class LinePlotStyles : RecipeBase
    {
        public override string Name => "Line Plot Shapes";
        public override string Description => "Line plots can be styled using a LineStyle.";

        [Test]
        public override void Execute()
        {
            ScottPlot.Colormaps.Viridis colormap = new();

            for (int i = 0; i < 10; i++)
            {
                // add a line
                Coordinates start = Generate.RandomCoordinates();
                Coordinates end = Generate.RandomCoordinates();
                var line = myPlot.Add.Line(start, end);

                // customize the line
                line.LineColor = Generate.RandomColor(colormap);
                line.LineWidth = Generate.RandomInteger(1, 4);
                line.LinePattern = Generate.RandomLinePattern();

                // customize markers
                line.MarkerLineColor = line.LineStyle.Color;
                line.MarkerShape = Generate.RandomMarkerShape();
                line.MarkerSize = Generate.RandomInteger(5, 15);
            }
        }
    }

    public class LinePlotLegendQWER : RecipeBase
    {
        public override string Name => "Line Plot Legend";
        public override string Description => "Line plots with labels appear in the legend.";

        [Test]
        public override void Execute()
        {
            var sin = myPlot.Add.Signal(Generate.Sin());
            sin.LegendText = "Sine";

            var cos = myPlot.Add.Signal(Generate.Cos());
            cos.LegendText = "Cosine";

            var line = myPlot.Add.Line(1, 12, 12, 0);
            line.LineWidth = 3;
            line.MarkerSize = 10;
            line.LegendText = "Line Plot";

            myPlot.ShowLegend(Alignment.UpperRight);
        }
    }

    public class LinePlotMarkerOrder : RecipeBase
    {
        public override string Name => "Line and Marker Order";
        public override string Description => "Markers may be displayed at the ends of lines, " +
            "and a flag controls whether the markers are drawn above or below the line.";

        [Test]
        public override void Execute()
        {
            var line1 = myPlot.Add.Line(0, 0, 1, 1);
            line1.LineColor = Colors.Orange;
            line1.LineWidth = 5;
            line1.MarkerColor = Colors.Red;
            line1.MarkerSize = 20;
            line1.MarkerShape = MarkerShape.FilledCircle;
            line1.LineOnTop = true; // render order is controlled here

            var line2 = myPlot.Add.Line(1, 0, 2, 1);
            line2.LineColor = Colors.Orange;
            line2.LineWidth = 5;
            line2.MarkerColor = Colors.Red;
            line2.MarkerSize = 20;
            line2.MarkerShape = MarkerShape.FilledCircle;
            line2.MarkersOnTop = true; // render order is controlled here
        }
    }
}

