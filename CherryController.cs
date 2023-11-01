using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryController : MonoBehaviour
{
    public GameObject cherry;
    public float timeInterval = 10;
    public Vector2 min = new Vector2(-17,-32);
    public Vector2 max = new Vector2(44,3);
    float time;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > timeInterval) 
        {
            CreatCherry();
            time = 0;
        }
    }

    void CreatCherry()
    {
        
        CherryMove cm = Instantiate(cherry).GetComponent<CherryMove>();
        cm.Init(RandomPos());
    }

    Vector2 RandomPos()
    {
        Vector3 pos = Vector3.zero;
        int i = Random.Range(0, 3);
        switch (i)
        {
            case 0:
                pos = new Vector3(min.x, Random.Range(min.y, max.y));
                break;
            case 1:
                pos = new Vector3(max.x, Random.Range(min.y, max.y));
                break;
            case 2:
                pos = new Vector3(Random.Range(min.x, max.x),min.y);
                break;
            case 3:
                pos = new Vector3(Random.Range(min.x, max.x), max.y);
                break;
        }
        print("pos =" +pos);
        return pos;

    }
}
