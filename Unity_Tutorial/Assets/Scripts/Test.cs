using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    [SerializeField] private Text txt_name;
    [SerializeField] private Image img_name;
    [SerializeField] private Sprite sprite;

    private bool isCoolTime = false;
    private float currentTime = 5f;
    private float delayTime = 5f;

    private void Update()
    {
       //Color color = img_name.color;
       //color.a = 0f;
       //img_name.color = color;

        if(isCoolTime)
        {
            currentTime -= Time.deltaTime;
            img_name.fillAmount = currentTime/delayTime;

            if(currentTime<=0)
            {
                isCoolTime = false;
                currentTime = 5f;
                img_name.fillAmount = currentTime;
            }
        }
    }
    public void Change()
    {
        txt_name.text = "변경됨";
        isCoolTime = true;

    }


}
