using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagement;

public class ButtonEvent : MonoBehaviour
{
    //시작버튼 클릭했을 때
    public void OnStartButtonClick()
    {
        //SceneManager.LoadScene("GameScene");
        SceneMgr.Instance.LoadScene("GameScene");
    }

    public void StartIntoGame()
    {
        //LoadDelay(); coroutine은 일반적인 함수처럼 실행하면 안된다.

        //startCoroutine을 사용해야 한다.
        StartCoroutine(LoadDelay());
    }

    IEnumerator LoadDelay()
    {
        yield return new WaitForSeconds(1f);
        SceneMgr.Instance.LoadScene("GameScene");
    }

    public void OnExitButtonClick()
    {
        Application.Quit();
    }

    //메뉴버튼 클릭했을 때
    public void OnMenuButtonClick()
    {
    }

    public void OnOptionButtonClick()
    {

    }
}
