using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public List<Transform> m_Path;

    public Transform m_Root;

    public int m_Index;

    public int m_Dic;

    void Start()
    {
         for(int i=0;i<m_Root.childCount;i++)
        {
            m_Path.Add(m_Root.GetChild(i));
        }

        m_Index = 1;
    }
 
    void Update()
    {
        Vector3 Dir  = m_Path[m_Index].position - transform.position;  

        float angle = Vector3.SignedAngle(Vector3.right, Dir, Vector3.forward);
       
        Quaternion rotation = Quaternion.Euler(0, 0, angle);  
        
        transform.rotation = rotation; 

        transform.Translate(Vector3.right * Time.deltaTime * 2);

        float dis = Vector3.Distance(m_Path[m_Index].position, transform.position);
        if (dis < 0.1f)
        {
            m_Index++;

            if (m_Index >= m_Path.Count)
            {
                m_Index = 0;
            }
        }

    }
}
