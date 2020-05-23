using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    private Light the_Light;

    private float targetIntensity;
    private float currentIntensity;



    void Start()
    {
        the_Light = GetComponent<Light>();
        currentIntensity = the_Light.intensity;
        targetIntensity = Random.Range(0.4f, 1f);
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(targetIntensity - currentIntensity) >= 0.01)
        {
            if (targetIntensity - currentIntensity >= 0)
                currentIntensity += Time.deltaTime * 3f;
            else
                currentIntensity -= Time.deltaTime * 3f;

            the_Light.intensity = currentIntensity;
            the_Light.range = currentIntensity + 10;

        }
        else
        {
            targetIntensity = Random.Range(0.4f, 1f);
        }
    }
}
