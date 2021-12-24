using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
public class ProcessInputData : SystemBase
{
    protected override void OnUpdate()
    {
        float inputH = Input.GetAxis("Horizontal");
        float inputV = Input.GetAxis("Vertical");

        Entities.ForEach((ref RawInputData rawInputData, ref MoveData moveData) => {
            // Implement the work to perform for each entity here.
            // You should only access data that is local or that is a
            // field on this job. Note that the 'rotation' parameter is
            // marked as 'in', which means it cannot be modified,
            // but allows this job to run in parallel with other jobs
            // that want to read Rotation component data.
            // For example,
            //     translation.Value += math.mul(rotation.Value, new float3(0, 0, 1)) * deltaTime;

            rawInputData.inputH = inputH;
            rawInputData.inputV = inputV;
            moveData.targetDirection = new float3(rawInputData.inputH, 0, rawInputData.inputV);
        }).Schedule();
    }
}
