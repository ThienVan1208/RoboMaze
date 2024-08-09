using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightEffect : MonoBehaviour
{
    // Start is called before the first frame update
    public Light light_effect;
    public Coroutine currCo;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(currCo == null)
        {
            currCo = StartCoroutine(LightOnOff());
        }
    }
    public IEnumerator LightOnOff()
    {
        yield return new WaitForSeconds(5f);
        light_effect.color = Color.white;
        yield return new WaitForSeconds(0.2f);
        light_effect.color = Color.black;
        yield return new WaitForSeconds(0.2f);
        light_effect.color = Color.white;
        yield return new WaitForSeconds(0.2f);
        light_effect.color = Color.black;
        currCo = null;
    }
}
