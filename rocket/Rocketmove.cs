using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rocketmove : MonoBehaviour
{   
    Renderer roColor;
    Rigidbody2D rigid;
    float walkspeed = 10f;
    private bool isInvincible = false;

    public GameManager gameManager;
    
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate= 60;
        this.rigid = GetComponent<Rigidbody2D>();
        roColor = gameObject.GetComponent<Renderer>();
    }
    IEnumerator MakeInvincible(float duration)
    {
        isInvincible = true;

        roColor.material.color = Color.yellow;
        
        yield return new WaitForSeconds(duration);

        roColor.material.color = Color.white;
    
        isInvincible = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Star"))
        {
            Destroy(other.gameObject);
            StartCoroutine(MakeInvincible(2f));
        }
        else if(isInvincible && other.CompareTag("stone"))
        {
            Destroy(other.gameObject);
            Debug.Log("펑");
        }
        else if(!isInvincible && other.CompareTag("stone"))
        {
            Destroy(this.gameObject);
            Debug.Log("펑");    
            gameManager.GameOver();
        }
    }



    // Update is called once per frame
    void Update()
    {
        UnityEngine.Vector3 worldpos = Camera.main.WorldToViewportPoint(this.transform.position);
        if (worldpos.x < 0f) worldpos.x = 0f;
        if (worldpos.y < 0f) worldpos.y = 0f;
        if (worldpos.x > 1f) worldpos.x = 1f;
        if (worldpos.y > 1f) worldpos.y = 1f;
        this.transform.position = Camera.main.ViewportToWorldPoint(worldpos);

       float inputX = Input.GetAxisRaw("Horizontal");
       float inputY = Input.GetAxisRaw("Vertical");

       UnityEngine.Vector2 movement = new UnityEngine.Vector2(inputX, inputY).normalized;

        // Rigidbody2D를 사용하여 이동
        rigid.velocity = movement * walkspeed;
        

        if(movement != UnityEngine.Vector2.zero)
        {
            float angle = Mathf.Atan2(movement.y,movement.x)*Mathf.Rad2Deg;
            rigid.rotation = angle-90;
        }           
    }
}
