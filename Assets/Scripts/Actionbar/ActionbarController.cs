using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionbarController : MonoBehaviour
{
    public static ActionbarController Instance;
    public ActionbarUi[] skill;
    private void Start()
    {
        Instance=this;
    }

}
