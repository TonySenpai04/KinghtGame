using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour
{
    [SerializeField] private GameObject[] characterList;
    [SerializeField] private int index;
    [SerializeField] private GameObject loadingScene;
    [SerializeField] private Slider loadingBarFill;
    public string characterName;

    void Start()
    {
     
        index = 0;
        characterList =new GameObject[transform.childCount];
        for(int i = 0; i < transform.childCount; i++)
        {
            characterList[i]=transform.GetChild(i).gameObject;
        }
        foreach(GameObject character in characterList)
        {
            character.SetActive(false);
        }
        if (characterList[0])
        {
            characterList[0].SetActive(true);
        }
       
    }

    public void toggleleft()
    {
        characterList[index].SetActive(false);
        index --;
        if (index < 0)
        {
            index = characterList.Length-1;
        }
       
        characterList[index].SetActive(true);     
    }
    public void toggleright()
    {
        characterList[index].SetActive(false);
        index++;
        if (index == characterList.Length)
        {
            index = 0;
        }
        characterList[index].SetActive(true);
    }
    public void Confirm()
    {
        if (index == 0)
        {
            characterList[index].SetActive(false);
            StartCoroutine(loadSceneAsync(1));
            PlayerPrefs.SetString("SelectedCharacter", characterList[index].name);
            SceneManager.LoadScene("Main");

        }
        if (index == 1)
        {
            characterList[index].SetActive(false);
            StartCoroutine (loadSceneAsync(1));
            PlayerPrefs.SetString("SelectedCharacter", characterList[index].name);
            SceneManager.LoadScene("Main");
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
