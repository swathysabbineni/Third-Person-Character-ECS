using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;

public class FollowTarget : SystemBase
{
    protected override void OnUpdate()
    {
        
        Entities.ForEach((ref MoveData movement ,in TargetData targetData, in Translation translation) => {
            ComponentDataFromEntity<Translation> translationArray = GetComponentDataFromEntity<Translation>(true);
            if(! translationArray.HasComponent(targetData.targetEntity))
            {
                return;
            }
            Translation targetPosition = translationArray[targetData.targetEntity];
            movement.targetDirection = targetPosition.Value - translation.Value;
        }).Schedule();
    }
}
