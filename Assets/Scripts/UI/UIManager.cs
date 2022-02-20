using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject stopMenu;
    private void Update()
    {
        stopMenu.SetActive(GameManager.Instance.isPaused);
    }

}
