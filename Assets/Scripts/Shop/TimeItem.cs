using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeItem : MonoBehaviour
{
    public float CurrentTime;
    public int Timeitem;
    public TextMeshProUGUI TextTime;
    public int TimeP;
    public static TimeItem Instance;
    public bool Isuse;
    // Start is called before the first frame update
    void Start()
    {
        CurrentTime = Timeitem;
        TimeP = 0;
        Instance = this;
        Isuse = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.T))
        {
            Isuse = true;
        }
        if (Isuse == true)
        {
            CountDown();
        }
    }
    public void CountDown()
    {
        CurrentTime -= 1 * Time.deltaTime;
        if (CurrentTime < 60)
        {
            TextTime.text = CurrentTime.ToString("0") + "s";
        }
        else
        {
            TextTime.text = TimeP.ToString("0") + "p";
        }
        if(CurrentTime <= 0)
        {
            CurrentTime = 0;
            gameObject.SetActive(false);
            Isuse = false;
        }
        else if(
           CurrentTime > 0)
        {
            gameObject.SetActive(true);
        }
        TimeP = (int)(CurrentTime / 60);
        
    }

   
}
