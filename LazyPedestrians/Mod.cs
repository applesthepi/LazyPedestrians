using System.Reflection;
using Colossal.IO.AssetDatabase;
using Colossal.Logging;
using Game;
using Game.Modding;
using Game.Net;
using Game.Rendering;
using Game.SceneFlow;
using Game.Serialization;
using Game.Tools;
using JetBrains.Annotations;
using LazyPedestrians.Localisations;

namespace LazyPedestrians
{
    [UsedImplicitly]
    public class Mod : IMod
    {
        public static ILog log = LogManager.GetLogger($"{nameof(LazyPedestrians)}.{nameof(Mod)}").SetShowsErrorsInUI(true);
        public static Settings m_Settings;

        public void OnLoad(UpdateSystem updateSystem)
        {
            log.Info(nameof(OnLoad));

            m_Settings = new Settings(this);
            AssetDatabase.global.LoadSettings(nameof(LazyPedestrians), m_Settings, new Settings(this));
            m_Settings.RegisterInOptionsUI();
            
            GameManager.instance.localizationManager.AddSource("en-US", new LocaleEnUs(m_Settings));

            updateSystem.UpdateAfter<PedestrianCostSystem>(SystemUpdatePhase.LoadSimulation);
        }

        public void OnDispose()
        {
            
        }
    }
}
