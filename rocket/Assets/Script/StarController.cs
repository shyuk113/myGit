using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarController : MonoBehaviour
{
    [SerializeField] [Range(100f,150f)] float speed =100f;
    public Rigidbody2D star;
    float x,y;

    GameObject rocket;

    void Start()
    {
        this.rocket = GameObject.Find("Rocket");
        // 공에 Rigidbody 컴포넌트를 가져옵니다.
        star = GetComponent<Rigidbody2D>();

        x=Random.Range(-1f,1f);
        y=Random.Range(-1f,1f);

        Vector2 dir =new Vector2(x,y).normalized;

        star.AddForce(dir*speed);
        Invoke("DestroyObject", 10f);
    }
    void DestroyObject()
    {
        Destroy(gameObject);
    }
    void Update()
    {
        transform.Rotate(0,0,1f);     
    }

}
