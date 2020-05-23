using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField]
    private GameObject go_Target;
    
    [SerializeField]
    private float speed;
    
    private Vector3 difValue;

    //private Camera theCam;

    void Start()
    {
        difValue = transform.position - go_Target.transform.position;
        difValue = new Vector3(Mathf.Abs(difValue.x), Mathf.Abs(difValue.y), Mathf.Abs(difValue.z));

       
    }

    // Update is called once per frame
    void Update()
    {
       //Lerp --> 부드럽게 움직이도록 해줌 
       this.transform.position = Vector3.Lerp(this.transform.position, go_Target.transform.position + difValue, speed);
    }
}
