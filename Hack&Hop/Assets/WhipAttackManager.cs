using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class WhipAttackManager : EnemyMissiveManager
{
    public override void DestroyMe(Transform collisiontransform){
        float realCollisionY = math.abs(collisiontransform.transform.position.y);
        float realGameobjectY = math.abs(gameObject.transform.position.y);
        if(realGameobjectY>=realCollisionY) return;
        Destroy(gameObject);
    }

}