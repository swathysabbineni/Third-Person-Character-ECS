using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public class ConvertCamera : MonoBehaviour, IConvertGameObjectToEntity
{
    public EntityManager entityManager;
    public Entity targetEntity, lookAtEntity;
    public float3 offset;
    public float moveSpeed;
    public float rotateSpeed;
    // Start is called before the first frame update
   
    //initialize 
    private void Awake()
    {
        entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
    }

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        dstManager.AddComponent<CopyTransformToGameObject>(entity);
        dstManager.AddComponentData(entity, new MoveData {moveSpeed = moveSpeed });
        dstManager.AddComponentData(entity, new TargetData { followEntity = targetEntity, lookAtEntity= lookAtEntity, targetOffset = offset });
        dstManager.AddComponentData(entity, new RotateData {rotateSpeed = rotateSpeed });
    }
}
