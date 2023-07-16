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
        Player = GameObject.Find("player").transform;
        if (Player != null)
        {
            Ondead();
        }
    }
    public void Ondead()
    {
        if (HPController.Instance.currenthp == 0 )
        {
            PanleRevival.gameObject.SetActive(true);
            SkillUi.SetActive(false);
        }
        else
        {
            PanleRevival.gameObject.SetActive(false);
            SkillUi.SetActive(true);
        }
    }
    public void RevivalPlayer()
    {
        HPController.Instance. currenthp += HPController.Instance. maxHp;
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
        HPController.Instance.currenthp += HPController.Instance.maxHp;
        MPController.Instance.Currentmp += MPController.Instance.Maxmp;
        PanleRevival.gameObject.SetActive(false);
        AnimationPlayer.instance.Animator.SetBool("Idle", true);
        AnimationPlayer.instance.IsDead = false;
        AnimationPlayer.instance.Count = 0;
        SkillUi.SetActive(true);
    }
}
