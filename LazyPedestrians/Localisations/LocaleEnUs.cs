using System.Collections.Generic;
using Colossal;

namespace LazyPedestrians.Localisations;

public class LocaleEnUs : IDictionarySource
{
    private readonly Settings m_Settings;

    public LocaleEnUs(Settings settings)
    {
        m_Settings = settings;
    }
    
    public IEnumerable<KeyValuePair<string, string>> ReadEntries(IList<IDictionaryEntryError> errors, Dictionary<string, int> indexCounts)
    {
        return new Dictionary<string, string>
        {
            { m_Settings.GetSettingsLocaleID(), "Lazy Pedestrians" },
            {
                m_Settings.GetOptionLabelLocaleID(
                    nameof(Settings.MultilineText)),
                "REQUIRES SAVE RELOAD"
            },
            {
                m_Settings.GetOptionLabelLocaleID(
                    nameof(Settings.DropdownMultiplier)),
                "Walking Cost Multiplier"
            },
            {
                m_Settings.GetOptionDescLocaleID(
                    nameof(Settings.DropdownMultiplier)),
                "REQUIRES SAVE RELOAD (don't care enough to make these settings apply instantly, PRs welcome!)"
            },
        };
    }

    public void Unload()
    {
        
    }
}