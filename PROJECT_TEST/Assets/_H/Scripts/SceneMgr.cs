using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneMgr : MonoBehaviour
{
    //씬매니져 싱글톤 만들기
    //씬매니져는 시작, 게임, 종료씬 등 모든 씬들을 관리해야 한다
    //또한 씬매니져는 씬이 변경돼도 삭제되면 안된다.

    public static SceneMgr Instance;

    private void Awake()
    {
        //씬매니져가 존재한다면
        //새로 생성되는 씬매니져 옵젝트는 삭제하고 바로 빠져나온다
        if(Instance)
        {
            DestroyImmediate(gameObject);
            return;
        }
        Instance = this;
        //오브젝트를 삭제하지 않고 씬을 Load
        DontDestroyOnLoad(gameObject);
    }

    public void LoadScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }
}
