using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject UI_PauseMenu;
    private void Update()
    {
        UI_PauseMenu.SetActive(GameManager.Instance.isPaused);
    }
}
