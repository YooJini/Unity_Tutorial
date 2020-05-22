using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Vector3 rotation;
    //
    // void Start()
    // {
    //     rotation = this.transform.eulerAngles;
    // }
    [SerializeField]//private으로 선언한 것을 inspector에 강제로 나타나게 함
    private GameObject go_camera;
   
    void Update()
    {
        transform.RotateAround(go_camera.transform.position, Vector3.up, 100 * Time.deltaTime);
        
        if (Input.GetKey(KeyCode.W))
        {
            //이동
            // this.transform.position = this.transform.position + new Vector3(0, 0, 1) * Time.deltaTime;
            // this.transform.Translate(new Vector3(0, 0, 1) * Time.deltaTime);

            //회전
            // rotation = rotation + new Vector3(90, 0, 0) * Time.deltaTime;
            // this.transform.rotation = Quaternion.Euler(rotation);
            //Quaternion을 사용하는 이유
            //오일러각도에서는 한 축이 90도로 고정되면 다른 축이 고장나버리는 현상이 일어남

            //크기 조절
            //this.transform.localScale = this.transform.localScale + new Vector3(2, 2, 2)*Time.deltaTime;

            //정규화 벡터(방향만을 알려주는 녀석) new Vector(0,0,1)
            //forward, up, right

            //카메라를 바라봐라
            //this.transform.LookAt(go_camera.transform.position);
           
        }
    }
}
