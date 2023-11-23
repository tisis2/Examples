using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading;

namespace AccessViolationWithPaths.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public ObservableCollection<(double x, double y)> Points { get; } = new();

    private Random rnd = new(42);
    private PeriodicTimer timer = new PeriodicTimer(TimeSpan.FromMilliseconds(1));

    public MainWindowViewModel()
    {
        GeneratePoints();
    }

    private async void GeneratePoints()
    {
        while (await timer.WaitForNextTickAsync())
        {
            for (int i = 0; i < 10; i++)
            {
                Points.Add((rnd.NextDouble() * 1240, rnd.NextDouble() * 800));
            }
        }
    }
}