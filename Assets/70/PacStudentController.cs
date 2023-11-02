using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PacStudentController : MonoBehaviour
{
    public LevelGenerator levelGenerator;
    public ParticleCtrl dust;
    public ParticleCtrl particleCollision;
    public float speed = 2;

    Vector2 lastInput;
    Vector2 currentInput;

    Vector2 MapPos;
    Vector2 NextMapPos;
    Vector2 Pos
    {
        get { return new Vector2(MapPos.x, -MapPos.y); }
    }
    Vector2 NextPos
    {
        get { return new Vector2(NextMapPos.x, -NextMapPos.y); }
    }

    // Start is called before the first frame update
    void Start()
    {
        MapPos = new Vector2(1, 1);
        transform.position = Pos;
        lastInput = Vector2.right;
        SetNextPos();
    }

    float time;
    // Update is called once per frame
    void Update()
    {
        MyInput();

        if (currentInput != Vector2.zero)
        {
            time += (Time.deltaTime *speed);
            transform.position = Vector3.Lerp(Pos, NextPos, time);
            

            if (Vector3.Distance(transform.position, NextPos) <=0.01f)
            {
                transform.position = NextPos;
                MapPos = NextMapPos;
                SetNextPos();
                time = 0;
                dust.Playing = false;

            }
            else
            {
                dust.Playing = true;
            }
        }

    }

    bool CollisionOne;
    public void SetNextPos()
    {
        print(123);
        if (MapPos.x == 0 || MapPos.x == 27)
        {
            Transmit();
            return;
        }
        if (levelGenerator.Accessible(MapPos + lastInput))
        {
            transform.right = new Vector2(lastInput.x, -lastInput.y);
            currentInput = lastInput;
            NextMapPos = MapPos + lastInput;
            CollisionOne = false;
        }
        else
        {
            if (!CollisionOne)
            {
                particleCollision.Playing = true;
                CollisionOne = true;
            }
        }

    }


    void MyInput()
    {
        if (Input.GetKeyDown(KeyCode.A) && levelGenerator.Accessible(NextMapPos + Vector2.left))
        {
            lastInput = Vector2.left;
        }
        if (Input.GetKeyDown(KeyCode.W) && levelGenerator.Accessible(NextMapPos + Vector2.down))
        {
            lastInput = Vector2.down;
        }
        if (Input.GetKeyDown(KeyCode.S) && levelGenerator.Accessible(NextMapPos + Vector2.up))
        {
            lastInput = Vector2.up;
        }
        if (Input.GetKeyDown(KeyCode.D) && levelGenerator.Accessible(NextMapPos + Vector2.right))
        {
            lastInput = Vector2.right;
        }
    }

  
    void Transmit()
    {
        if (MapPos.x == 0)
        {
            MapPos = new Vector2(27, MapPos.y);
        }
        else if (MapPos.x == 27)
        {
            MapPos = new Vector2(0, MapPos.y);
        }
        transform.position = Pos;
        NextMapPos = MapPos + currentInput;
    }

}
