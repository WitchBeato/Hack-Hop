using Unity.VisualScripting;
using UnityEngine;

public class WhipAttackManager : EnemyMissiveManager
{
    public override void DestroyMe(Transform collisiontransform){
        if(gameObject.transform.position.y>=collisiontransform.transform.position.y) return;
        Debug.Log("yer:"+collisiontransform.transform.position.y);
        Debug.Log("yer:"+collisiontransform.transform.position.y);
        Destroy(gameObject);
    }

}