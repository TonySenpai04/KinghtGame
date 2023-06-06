using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject panelSelectionChracter;
    [SerializeField] private GameObject SelectionChracter;
    [SerializeField] private GameObject panelLoading;
    void Start()
    {
        panelSelectionChracter.SetActive(false);
        SelectionChracter.SetActive(false);
        panelLoading.SetActive(false);
    }

    // Update is called once per frame

    public void StartGame()
    {
        gameObject.SetActive(false);
        panelSelectionChracter.SetActive(true);
        SelectionChracter.SetActive(true);
    }
    public void QuitGame()
    {
        Application.Quit();
    }

}
