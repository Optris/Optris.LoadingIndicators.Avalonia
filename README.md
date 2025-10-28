# LoadingIndicators.Avalonia
[![Nuget](https://img.shields.io/nuget/v/LoadingIndicators.Avalonia)](https://www.nuget.org/packages/LoadingIndicators.Avalonia)

![Demo](https://raw.githubusercontent.com/der-floh/LoadingIndicators.Avalonia/master/.github/demo.gif)

[Online demo](https://der-floh.github.io/LoadingIndicators.Avalonia)

LoadingIndicators.Avalonia is an adaptation for Avalonia of the [LoadingIndicators.WPF](https://github.com/zeluisping/LoadingIndicators.WPF) collection of 9 animated loading indicators.


## Themes
- Arc
- Arc Ease
- Arc Grow
- Arcs
- Arcs Ring
- Double Bounce
- FlipPlane
- Pulse
- Ring
- Three Dots
- Wave

## Features
- Easy activation/deactivation
- Easy theme change
- Adjustable animation speed

## Usage
1. Add Styles in `App.axaml`
```xml
<Application.Styles>
    <FluentTheme />
    <StyleInclude Source="avares://LoadingIndicators.Avalonia/LoadingIndicators.axaml" />
</Application.Styles>
```

2. Add indicator and select mode
```xml
<LoadingIndicator IsActive="{Binding IsBusy}" Mode="Arcs" SpeedRatio="1.5" Thickness="4" />
```
