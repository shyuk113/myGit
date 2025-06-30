using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StonStone : MonoBehaviour
{
    [SerializeField] [Range(100f,500f)] float speed =300f;
    public Rigidbody2D st;
    float x,y;

    GameObject rocket;

    void Start()
    {
        this.rocket = GameObject.Find("Rocket");
        // 공에 Rigidbody 컴포넌트를 가져옵니다.
        st = GetComponent<Rigidbody2D>();

        x=Random.Range(-1f,1f);
        y=Random.Range(-1f,1f);

        Vector2 dir =new Vector2(x,y).normalized;

        st.AddForce(dir*speed);
    }

    void Update()
    {
        transform.Rotate(0,0,1f);     
    }

}
