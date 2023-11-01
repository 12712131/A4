using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryMove : MonoBehaviour
{
    public float speed;
    public Vector3 centerPos = new Vector2 (13.5f, -14.5f);
    float time;
    Vector3 startPos;
    public void Init(Vector3 startPos)
    {
        this.startPos = startPos;
        print("startpos = " + this.startPos);
        transform.position = startPos; 
    }


    // Update is called once per frame
    void Update()
    {
        if (startPos != Vector3.zero) 
        {
            time += (Time.deltaTime*speed);
            transform.position = Vector3.Lerp(startPos, startPos + 2 *(centerPos - startPos), time);
            if (time >= 1) {
                Destroy(gameObject);
            }
        }
    }
}
