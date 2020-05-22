using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{

    private BoxCollider col;
  

    void Start()
    {
        col = GetComponent<BoxCollider>();
    }

    // void Update()
    // {
    //    if(Input.GetKeyDown(KeyCode.W))
    //     {
    //        //속성
    //        // Debug.Log("col.bounds"+col.bounds);
    //        // Debug.Log("col.bounds.extents"+col.bounds.extents);
    //        // Debug.Log("col.bounds.extents.x"+col.bounds.extents.x);
    //        // Debug.Log("col.size"+col.size);
    //        // Debug.Log("col.center"+col.center);
    //
    //        //메소드
    //        //레이저 쏘기, 감지
    //        if(Input.GetMouseButtonDown(0))
    //         {
    //             Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //             RaycastHit hitInfo;
    //             if(col.Raycast(ray, out hitInfo, 1000))
    //             {
    //                 this.transform.position = hitInfo.point;
    //             }
    //         }
    //     }
    // }
  
   // private void OnTriggerEnter(Collider other)
   // {
   //     
   // }
    private void OnTriggerExit(Collider other)
    {
        other.transform.position = new Vector3(0,2,0);
    }
   //머물고 있는 동안 실행
    private void OnTriggerStay(Collider other)
    {
        other.transform.position += new Vector3(0, 0, 0.01f);
    }
}
