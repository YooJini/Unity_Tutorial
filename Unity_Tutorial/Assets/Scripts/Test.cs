using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{

    private Rigidbody myRigid;
    private Vector3 rotation;

    void Start()
    {
        myRigid = GetComponent<Rigidbody>();
        rotation = this.transform.eulerAngles;
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            //MovePosition, MoveRotation: 관성과 질량의 영향을 받지 않음 
            rotation += new Vector3(90, 0, 0) * Time.deltaTime;
            myRigid.MoveRotation(Quaternion.Euler(rotation));

            //AddForce, AddTorque: 관성과 질량의 영향을 받음 -> 자연스러움
            myRigid.AddForce(Vector3.forward);
            myRigid.AddTorque(Vector3.up);

            //폭발물 구현시 유용
            myRigid.AddExplosionForce(10, this.transform.right, 10);
        }
    }
}
