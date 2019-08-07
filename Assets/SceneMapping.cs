using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum ScenesNames {
    Home,
    Shooter,
    Assembly
}

[System.Serializable]
public class SceneMap {
    [SerializeField]
    public ScenesNames sceneIndex;
}
public class SceneMapping : MonoBehaviour
{
    public static SceneMapping _Instance;
    private void Awake() {
        _Instance = this;
        DontDestroyOnLoad(this);
    }
    
    [SerializeField]
    List<SceneMap> scenesMaps = new List<SceneMap>();

    public void changeScene(ScenesNames sceneName) {

        SceneManager.LoadScene(sceneName.ToString());
    }
}
