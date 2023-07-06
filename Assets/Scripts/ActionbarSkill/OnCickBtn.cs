using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnCickBtn : MonoBehaviour
{
    [SerializeField] private Button[] actionsButton;
    private KeyCode action1,action2,action3;
    void Start()
    {
        action1 = KeyCode.Alpha1;
        action2 = KeyCode.Alpha2;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(action1))
        {
            ActionButtonOnclick(0);
        }
        if (InputManager.Instance.IsSkill2)
        {
            ActionButtonOnclick(1);
        }
    }
    private  void ActionButtonOnclick(int index)
    {
        actionsButton[index].onClick.Invoke();
    }
}
