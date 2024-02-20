using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneGenerato : MonoBehaviour
{
    public GameObject StonePrefab;
    public GameObject StarPrefab;

    public GameObject BigPrefab;
    float span1=3.0f;
    float delta1 = 0;

    float span2=20.0f;
    float delta2=0;

    float span3=8.0f;
    float delta3=0;

    void Update()
    {
        this.delta1+=Time.deltaTime;
        if(this.delta1>this.span1)
        {
            this.delta1=0;
            GameObject item = Instantiate(StonePrefab);
            float x = Random.Range(-8f,8f);
            float y = 4.5f;
            item.transform.position = new Vector2(x,y);
        }

        this.delta2+=Time.deltaTime;
        if(this.delta2>this.span2)
        {
            this.delta2=0;
            GameObject item = Instantiate(StarPrefab);
            float x = Random.Range(-8f,8f);
            float y = Random.Range(-4f,4f);
            item.transform.position = new Vector2(x,y);
        }
        this.delta3+=Time.deltaTime;
        if(this.delta3>this.span3)
        {
            this.delta3=0;
             GameObject item = Instantiate(BigPrefab);
            float x = Random.Range(-8f,8f);
            float y = 4.5f;
            item.transform.position = new Vector2(x,y);
        }

    }
}
