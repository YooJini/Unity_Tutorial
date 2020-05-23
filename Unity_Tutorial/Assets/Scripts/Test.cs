using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Test : MonoBehaviour
{
    ParticleSystem ps;

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        ps.Play();
        ps.Emit(1); // ()개수 입력
    }

    

}
