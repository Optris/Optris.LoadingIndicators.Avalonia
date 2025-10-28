using Avalonia;
using Avalonia.Controls.Metadata;
using Avalonia.Controls.Primitives;
using Avalonia.Styling;

namespace LoadingIndicators.Avalonia;

[PseudoClasses(INACTIVE_STATE, ACTIVE_STATE)]
public class LoadingIndicator : TemplatedControl
{
    private const string INACTIVE_STATE = ":inactive";
    private const string ACTIVE_STATE = ":active";

    // ReSharper disable InconsistentNaming
    public static readonly StyledProperty<bool> IsActiveProperty =
        AvaloniaProperty.Register<LoadingIndicator, bool>(nameof(IsActive), true);
    public static readonly StyledProperty<LoadingIndicatorMode> ModeProperty =
        AvaloniaProperty.Register<LoadingIndicator, LoadingIndicatorMode>(nameof(Mode));
    public static readonly StyledProperty<double> SpeedRatioProperty =
        AvaloniaProperty.Register<LoadingIndicator, double>(nameof(SpeedRatio), 1.5);
    public static readonly StyledProperty<double> ThicknessProperty =
        AvaloniaProperty.Register<LoadingIndicator, double>(nameof(Thickness), 4);
    // ReSharper restore InconsistentNaming

    public bool IsActive
    {
        get => GetValue(IsActiveProperty);
        set => SetValue(IsActiveProperty, value);
    }
    public LoadingIndicatorMode Mode
    {
        get => GetValue(ModeProperty);
        set => SetValue(ModeProperty, value);
    }
    public double SpeedRatio
    {
        get => GetValue(SpeedRatioProperty);
        set => SetValue(SpeedRatioProperty, value);
    }
    public double Thickness
    {
        get => GetValue(ThicknessProperty);
        set => SetValue(ThicknessProperty, value);
    }

    private static readonly Dictionary<LoadingIndicatorMode, ControlTheme> _themes;

    static LoadingIndicator()
    {
        if (!TryGetThemes(out _themes))
            throw new NullReferenceException("Failed to get control themes");
    }

    public LoadingIndicator()
    {
        UpdateTheme();
    }

    protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
    {
        base.OnApplyTemplate(e);
        UpdateVisualStates();
    }

    protected override void OnPropertyChanged(AvaloniaPropertyChangedEventArgs change)
    {
        base.OnPropertyChanged(change);
        if (change.Property == IsActiveProperty)
            UpdateVisualStates();
        else if (change.Property == ModeProperty)
            UpdateTheme();
    }

    private static bool TryGetThemes(out Dictionary<LoadingIndicatorMode, ControlTheme> controlThemes)
    {
        controlThemes = [];
        if (Application.Current is null)
            return false;
        foreach (LoadingIndicatorMode mode in Enum.GetValues(typeof(LoadingIndicatorMode)))
        {
            if (!Application.Current.TryGetResource(Enum.GetName(typeof(LoadingIndicatorMode), mode)!, null, out var resource))
                continue;
            if (resource is not ControlTheme theme)
                continue;
            controlThemes.Add(mode, theme);
        }
        return controlThemes.Count > 0;
    }

    private void UpdateTheme()
    {
        if (_themes.TryGetValue(Mode, out var theme))
            Theme = theme;
    }

    private void UpdateVisualStates()
    {
        PseudoClasses.Remove(ACTIVE_STATE);
        PseudoClasses.Remove(INACTIVE_STATE);
        PseudoClasses.Add(IsActive ? ACTIVE_STATE : INACTIVE_STATE);
    }
}