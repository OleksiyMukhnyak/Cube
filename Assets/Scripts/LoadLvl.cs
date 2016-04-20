using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadLvl : MonoBehaviour {

    public void LoadLVL(int lvl)
    {
        SceneManager.LoadScene(lvl);
    }

}
