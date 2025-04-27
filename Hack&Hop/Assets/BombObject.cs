using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombObject : MonoBehaviour
{
    public void removeMe(){
        Destroy(gameObject);
    }
}
