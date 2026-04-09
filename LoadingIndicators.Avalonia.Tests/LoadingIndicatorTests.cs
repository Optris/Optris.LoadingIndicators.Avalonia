using Avalonia.Controls;
using Avalonia.Headless.XUnit;
using Avalonia.Styling;
using Xunit;

namespace LoadingIndicators.Avalonia.Tests;

public class LoadingIndicatorTests
{
    [AvaloniaFact]
    public void Constructor_SetsDefaultPropertyValues()
    {
        var indicator = new LoadingIndicator();

        Assert.True(indicator.IsActive);
        Assert.Equal(LoadingIndicatorMode.Arc, indicator.Mode);
        Assert.Equal(1d, indicator.SpeedRatio);
    }

    [AvaloniaFact]
    public void IsActive_True_SetsActivePseudoClass()
    {
        var window = new Window { Content = new LoadingIndicator { IsActive = true } };
        window.Show();
        var indicator = (LoadingIndicator)window.Content;

        Assert.Contains(":active", indicator.Classes);
        Assert.DoesNotContain(":inactive", indicator.Classes);

        window.Close();
    }

    [AvaloniaFact]
    public void IsActive_False_SetsInactivePseudoClass()
    {
        var window = new Window { Content = new LoadingIndicator { IsActive = false } };
        window.Show();
        var indicator = (LoadingIndicator)window.Content;

        Assert.Contains(":inactive", indicator.Classes);
        Assert.DoesNotContain(":active", indicator.Classes);

        window.Close();
    }

    [AvaloniaFact]
    public void IsActive_Toggle_SwitchesPseudoClasses()
    {
        var window = new Window { Content = new LoadingIndicator { IsActive = true } };
        window.Show();
        var indicator = (LoadingIndicator)window.Content;

        Assert.Contains(":active", indicator.Classes);

        indicator.IsActive = false;
        Assert.Contains(":inactive", indicator.Classes);
        Assert.DoesNotContain(":active", indicator.Classes);

        indicator.IsActive = true;
        Assert.Contains(":active", indicator.Classes);
        Assert.DoesNotContain(":inactive", indicator.Classes);

        window.Close();
    }

    [AvaloniaTheory]
    [InlineData(LoadingIndicatorMode.Arc)]
    [InlineData(LoadingIndicatorMode.Arcs)]
    [InlineData(LoadingIndicatorMode.ArcsRing)]
    [InlineData(LoadingIndicatorMode.DoubleBounce)]
    [InlineData(LoadingIndicatorMode.FlipPlane)]
    [InlineData(LoadingIndicatorMode.Pulse)]
    [InlineData(LoadingIndicatorMode.Ring)]
    [InlineData(LoadingIndicatorMode.ThreeDots)]
    [InlineData(LoadingIndicatorMode.Wave)]
    public void Mode_SetsCorrespondingTheme(LoadingIndicatorMode mode)
    {
        var indicator = new LoadingIndicator { Mode = mode };

        Assert.NotNull(indicator.Theme);
        Assert.IsType<ControlTheme>(indicator.Theme);
    }

    [AvaloniaTheory]
    [InlineData(LoadingIndicatorMode.Arc)]
    [InlineData(LoadingIndicatorMode.Arcs)]
    [InlineData(LoadingIndicatorMode.ArcsRing)]
    [InlineData(LoadingIndicatorMode.DoubleBounce)]
    [InlineData(LoadingIndicatorMode.FlipPlane)]
    [InlineData(LoadingIndicatorMode.Pulse)]
    [InlineData(LoadingIndicatorMode.Ring)]
    [InlineData(LoadingIndicatorMode.ThreeDots)]
    [InlineData(LoadingIndicatorMode.Wave)]
    public void Mode_EachModeHasDistinctTheme(LoadingIndicatorMode mode)
    {
        var indicator = new LoadingIndicator { Mode = mode };
        var theme = indicator.Theme;

        var otherMode = mode == LoadingIndicatorMode.Arc
            ? LoadingIndicatorMode.Wave
            : LoadingIndicatorMode.Arc;
        indicator.Mode = otherMode;

        Assert.NotEqual(theme, indicator.Theme);
    }

    [AvaloniaFact]
    public void SpeedRatio_AcceptsCustomValues()
    {
        var indicator = new LoadingIndicator { SpeedRatio = 2.5 };

        Assert.Equal(2.5, indicator.SpeedRatio);
    }

    [AvaloniaFact]
    public void AllEnumValues_HaveThemeResources()
    {
        var modes = Enum.GetValues<LoadingIndicatorMode>();
        Assert.Equal(11, modes.Length);

        foreach (var mode in modes)
        {
            var indicator = new LoadingIndicator { Mode = mode };
            Assert.NotNull(indicator.Theme);
        }
    }

    [AvaloniaFact]
    public void Control_RendersInWindow()
    {
        var window = new Window
        {
            Content = new LoadingIndicator
            {
                IsActive = true,
                Mode = LoadingIndicatorMode.Wave,
                Width = 64,
                Height = 64
            }
        };
        window.Show();

        var indicator = (LoadingIndicator)window.Content;
        Assert.True(indicator.IsActive);
        Assert.Equal(LoadingIndicatorMode.Wave, indicator.Mode);

        window.Close();
    }
}
