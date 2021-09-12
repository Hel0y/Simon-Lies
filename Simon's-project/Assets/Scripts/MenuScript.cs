using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void NatvScene() {
        SceneManager.LoadScene("Narrativa1");
    }public void PlayScene() {
        SceneManager.LoadScene("Game-part1-Scene");
    } public void CreditScene() {
        SceneManager.LoadScene("Credit-Scene");
    }public void Menu() {
        SceneManager.LoadScene("Menu");
    }public void ConfScene() {
        SceneManager.LoadScene("Conf-Scene");
    }
}
