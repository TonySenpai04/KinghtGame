using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dondestroy : MonoBehaviour
{
    protected dondestroy instant;
    // Start is called before the first frame update
    private void Awake()
    {
        if (instant != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instant = this;
            DontDestroyOnLoad(gameObject);
            

        }
    }
}
