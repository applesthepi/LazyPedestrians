using System;
using Colossal.IO.AssetDatabase;
using Game.Modding;
using Game.Settings;
using Game.UI;
using Game.UI.Widgets;

namespace LazyPedestrians;

[FileLocation(nameof(LazyPedestrians))]
public partial class Settings : ModSetting
{
    public Settings(IMod mod) : base(mod)
    {
        SetDefaults();
    }

    public override void SetDefaults()
    {
        DropdownMultiplier = "Few Blocks";
    }

    [SettingsUIDropdown(typeof(Settings), nameof(GetStringDropdownItems))]
    public string DropdownMultiplier { get; set; } = "Few";

    public DropdownItem<string>[] GetStringDropdownItems()
    {
        var items = new DropdownItem<string>[]
        {
            new DropdownItem<string>
            {
                value = "Timbuktu",
                displayName = "[x1] Timbuktu (Vanilla)",
            },
            new DropdownItem<string>
            {
                value = "Few",
                displayName = "[x10] Few Blocks",
            },
            new DropdownItem<string>
            {
                value = "Couple",
                displayName = "[x20] Couple Blocks",
            },
        };

        return items;
    }

    public static Tuple<float, float> ValueFromKey(string key)
    {
        return key switch
        {
            "Timbuktu" => new Tuple<float, float>(0.0f, 1.0f),
            "Few" => new Tuple<float, float>(1.0f, 10.0f),
            "Couple" => new Tuple<float, float>(1.0f, 20.0f),
            _ => new Tuple<float, float>(0.0f, 1.0f),
        };
    }
}