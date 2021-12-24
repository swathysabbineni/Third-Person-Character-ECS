using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;

public class LookAtTarget : SystemBase
{
    protected override void OnUpdate()
    {
        
        Entities.WithAll<TargetData>().ForEach((ref RotateData rotateData,in Translation translation, in TargetData targetData) => {

            ComponentDataFromEntity<Translation> translationArray = GetComponentDataFromEntity<Translation>(true);
            if (!translationArray.HasComponent(targetData.lookAtEntity))
            {
                return;
            }
            Translation targetPosition = translationArray[targetData.lookAtEntity];

            rotateData.rotateTargetPosition = targetPosition.Value - translation.Value;
            rotateData.rotateTargetPosition = new float3(rotateData.rotateTargetPosition.x, 0f, rotateData.rotateTargetPosition.z);
        }).Schedule();
    }
}
