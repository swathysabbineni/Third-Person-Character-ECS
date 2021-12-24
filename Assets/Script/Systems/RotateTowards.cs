using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;

public class RotateTowards : SystemBase
{
    protected override void OnUpdate()
    {
       
        
        Entities.ForEach((ref Translation translation, ref Rotation rotation, in RotateData rotateData) => {

            if (!rotateData.rotateTargetPosition.Equals(float3.zero))
            {
                quaternion targetRotation = quaternion.LookRotationSafe(rotateData.rotateTargetPosition, math.up());
                rotation.Value = math.slerp(rotation.Value, targetRotation, rotateData.rotateSpeed);
            }
        }).Schedule();
    }
}
