using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDataCreater : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Create()
    {
        var trans = transform;
        for(int i=0;i<trans.childCount;i++)
        {
            var img = trans.GetComponent<Image>();
            
        }
    }
}
