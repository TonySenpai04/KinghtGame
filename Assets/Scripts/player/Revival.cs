using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Revival : MonoBehaviour
{
    [SerializeField] private GameObject PanleRevival;
    [SerializeField] private GameObject SkillUi;
    [SerializeField] private Transform Player;
    [SerializeField] private Transform PointStart;
    private void FixedUpdate()
    {
        Ondead();
        Player = GameObject.Find("player").transform;
    }
    public void Ondead()
    {
        if (HPController.Instance.currenthp == 0)
        {
            PanleRevival.gameObject.SetActive(true);
            SkillUi.SetActive(false);
        }
    }
    public void RevivalPlayer()
    {
        HPController.Instance. currenthp += HPController.Instance. maxhp;
        MPController.Instance.Currentmp += MPController.Instance.Maxmp;
        PanleRevival.gameObject.SetActive(false);
        AnimationPlayer.instance.Animator.SetBool("Idle", true);
        AnimationPlayer.instance.IsDead = false;
        AnimationPlayer.instance.Count = 0;
        Gold_Diamond.instance.Diamond -= 1;
        SkillUi.SetActive(true);
    }
    public void BackHome()
    {
        Player.transform.position = PointStart.transform.position;
        HPController.Instance.currenthp += HPController.Instance.maxhp;
        MPController.Instance.Currentmp += MPController.Instance.Maxmp;
        PanleRevival.gameObject.SetActive(false);
        AnimationPlayer.instance.Animator.SetBool("Idle", true);
        AnimationPlayer.instance.IsDead = false;
        AnimationPlayer.instance.Count = 0;
        SkillUi.SetActive(true);
    }
}
