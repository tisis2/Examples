using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using Avalonia;
using Avalonia.Collections;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Media;
using Avalonia.Media.Immutable;

namespace AccessViolationWithPaths;

public class Curve : Control
{
    private IEnumerable<(double x, double y)> points = Array.Empty<(double x, double y)>();

    public static readonly DirectProperty<Curve, IEnumerable<(double x, double y)>> PointsProperty =
        AvaloniaProperty.RegisterDirect<Curve, IEnumerable<(double x, double y)>>(
            nameof(Points),
            o => o.Points,
            (o, v) => o.Points = v,
            Array.Empty<(double x, double y)>()
        );

    public IEnumerable<(double x, double y)> Points
    {
        get => points;
        set => SetAndRaise(PointsProperty, ref points, value);
    }

    #region ReadOnlyProperties

    private IList<Point> actualPoints = new List<Point>();

    public static readonly DirectProperty<Curve, IList<Point>> ActualPointsProperty =
        AvaloniaProperty.RegisterDirect<Curve, IList<Point>>(
            nameof(ActualPoints), o => o.ActualPoints);

    public IList<Point> ActualPoints
    {
        get => actualPoints;
        private set => SetAndRaise(ActualPointsProperty, ref actualPoints, value);
    }

    #endregion


    static Curve()
    {
        PointsProperty.Changed.AddClassHandler<Curve>((curve, x) =>
        {
            if (x.OldValue is INotifyCollectionChanged oldCollection)
            {
                oldCollection.CollectionChanged -= curve.PointsChanged;
            }

            if (x.NewValue is INotifyCollectionChanged collection)
            {
                collection.CollectionChanged += curve.PointsChanged;
            }
        });

        AffectsRender<Curve>(PointsProperty);
    }

    private void PointsChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {
        InvalidateVisual();
    }

    public override void Render(DrawingContext context)
    {
        ActualPoints = Points.Select(p => new Point(p.x, p.y)).ToList();

        var pen = new Pen(
            Brushes.Red,
            1,
            lineJoin: PenLineJoin.Round);

        context.DrawGeometry(null, pen, new PolylineGeometry(ActualPoints, false));

        base.Render(context);
    }
}