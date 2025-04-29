using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PushableObject : MonoBehaviour
{
    public float pushSpeed = 5f; // Örneğin 5 birim/sn
    public int modeDirection = 1; //1 = left -1= right
    public bool IsMoving
    {
        get { return isMoving; }
        set
        {
            isMoving = value;
            Debug.Log(value);
        }
    }

    private bool isMoving;
    private Rigidbody2D rb;

    void Start()
    {
        isMoving = false;
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = rb.bodyType = RigidbodyType2D.Kinematic;
        // Başlangıçta hareket etmiyor, setter bunu zaten ayarlıyor.
    }

    public void PushObject()
    {
        IsMoving = true;
        rb.bodyType = rb.bodyType = RigidbodyType2D.Dynamic;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<BombObject>(out BombObject component))
        {
            Debug.Log("değiyor");
            component.removeMe();
        }
    }


void FixedUpdate()
{
    if (IsMoving)
    {
        rb.velocity = new Vector2(modeDirection*-pushSpeed, 0f);
    }
}

}
