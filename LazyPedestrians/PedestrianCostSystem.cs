using Colossal.Logging;
using Colossal.Serialization.Entities;
using Game;
using Game.Pathfind;
using Game.Prefabs;
using Unity.Entities;

namespace LazyPedestrians;

public partial class PedestrianCostSystem : GameSystemBase 
{
    protected override void OnUpdate()
    {
        
    }

    protected override void OnGameLoadingComplete(Purpose purpose, GameMode mode)
    {
        base.OnGameLoadingComplete(purpose, mode);
        
        ILog log = LogManager.GetLogger(nameof(LazyPedestrians)).SetShowsErrorsInUI(true);
        
        var entities = EntityManager.CreateEntityQuery(
            ComponentType.ReadWrite<PathfindPedestrianData>()
        ).ToEntityArray(Unity.Collections.Allocator.Persistent);

        foreach (var entity in entities)
        {
            var costs = EntityManager.GetComponentData<PathfindPedestrianData>(entity);

            string value = Mod.m_Settings.DropdownMultiplier;

            var offsetScale = Settings.ValueFromKey(Mod.m_Settings.DropdownMultiplier);
            costs.m_WalkingCost.m_Value.y += offsetScale.Item1;
            costs.m_WalkingCost.m_Value.y *= offsetScale.Item2;
            
            EntityManager.SetComponentData(entity, costs);
        }
    }
}