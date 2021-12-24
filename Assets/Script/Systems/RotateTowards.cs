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
       
        
        Entities.ForEach((ref Translation translation, ref Rotation rotation, in MoveData movement, in RotateData rotateData) => {

            if (!movement.targetDirection.Equals(float3.zero))
            {
                quaternion targetRotation = quaternion.LookRotationSafe(movement.targetDirection, math.up());
                rotation.Value = math.slerp(rotation.Value, targetRotation, rotateData.rotateSpeed);
            }
        }).Schedule();
    }
}
