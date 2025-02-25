using Microsoft.AspNetCore.Components;

namespace BlazorOpenApi;

public class OpenApiUiPalette : ICloneable
{
    public string BackgroundLighter { get; set; } = "#0000001f";
    public string BackgroundDarker  { get; set; } = "#00000055";
    public string BackgroundDarkest { get; set; } = "#000000AA";

    public string ForegroundNormal  { get; set; } = "#e4e4e4";
    public string ForegroundLighter { get; set; } = "#ffffff";
    public string ForegroundDarker  { get; set; } = "#A0A0A0";
    public string ForegroundDarkest { get; set; } = "#808080";

    public string[/*8*/] Background { get; set; } = [
        "#3655a3",
        "#7a7620",
        "#9f4b1e",
        "#7e1b29",
        "#52628b",
        "#851192",
        "#266b67",
        "#456f2b"
        ];

    public string[/*8*/] Foreground { get; set; } = [
        "#7d98de",
        "#ded971",
        "#eda279",
        "#e97d8d",
        "#b1c0e6",
        "#e571f2",
        "#98e6e1",
        "#54b319"
        ];

    public MarkupString AsMarkupString => new MarkupString(
$@"
<style>
    .openapi-ui {{
        --oa-bg-lighter: {BackgroundLighter};
        --oa-bg-darker:  {BackgroundDarker };
        --oa-bg-darkest: {BackgroundDarkest};

        --oa-fg-normal:  {ForegroundNormal };
        --oa-fg-lighter: {ForegroundLighter};
        --oa-fg-darker:  {ForegroundDarker };
        --oa-fg-darkest: {ForegroundDarkest};

        {string.Join("\n        ", Background.Select((x,i) => $"--oa-bg-{i+1}: {x};"))}

        {string.Join("\n        ", Foreground.Select((x, i) => $"--oa-fg-{i+1}: {x};"))}
    }}
</style>
");

    public OpenApiUiPalette Clone()
    {
        var other = new OpenApiUiPalette
        {
            BackgroundLighter = BackgroundLighter,
            BackgroundDarker  = BackgroundDarker,
            BackgroundDarkest = BackgroundDarkest,

            ForegroundNormal  = ForegroundNormal,
            ForegroundLighter = ForegroundLighter,
            ForegroundDarker  = ForegroundDarker,
            ForegroundDarkest = ForegroundDarkest,

            Background        = (string[])Background.Clone(),
            Foreground        = (string[])Foreground.Clone()
        };

        return other;
    }

    object ICloneable.Clone() => Clone();
}
