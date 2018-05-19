using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elon : MonoBehaviour
{
    public GameObject b1;
    public GameObject b2;

    private void Update()
    {
        if (Mathf.RoundToInt(Time.time * 5) % 2 == 0)
        {
            b1.SetActive(false);
            b2.SetActive(true);
        }
        else
        {
            b2.SetActive(false);
            b1.SetActive(true);
        }
    }
}
