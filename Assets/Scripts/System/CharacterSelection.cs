using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour
{
    [SerializeField] private GameObject[] CharacterList;
    [SerializeField] private int index;
    [SerializeField] private GameObject loadingScene;
    [SerializeField] private Slider loadingBarFill;

    void Start()
    {
     
        index = 0;
        CharacterList =new GameObject[transform.childCount];
        for(int i = 0; i < transform.childCount; i++)
        {
            CharacterList[i]=transform.GetChild(i).gameObject;
        }
        foreach(GameObject character in CharacterList)
        {
            character.SetActive(false);
        }
        if (CharacterList[0])
        {
            CharacterList[0].SetActive(true);
        }
       
    }

    public void toggleleft()
    {
        CharacterList[index].SetActive(false);
        index --;
        if (index < 0)
        {
            index = CharacterList.Length-1;
        }
       
        CharacterList[index].SetActive(true);     
    }
    public void toggleright()
    {
        CharacterList[index].SetActive(false);
        index++;
        if (index == CharacterList.Length)
        {
            index = 0;
        }
        CharacterList[index].SetActive(true);
    }
    public void Confirm()
    {
        if (index == 0)
        {
            CharacterList[index].SetActive(false);
           StartCoroutine(loadSceneAsync(1));
        }
        if (index == 1)
        {
            CharacterList[index].SetActive(false);
            StartCoroutine (loadSceneAsync(2));
        }
    }
    IEnumerator loadSceneAsync(int index)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(index);
        loadingScene.SetActive(true);
        while(!operation.isDone)
        {
            float value = Mathf.Clamp01(operation.progress / .9f);
            loadingBarFill.value = value;
            yield return null;
        }
    }
}
