using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Scene director
/// </summary>
public class SceneDirector : MonoBehaviour
{
    
    protected IEnumerator GoToNextScene(SceneName name)
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(name.ToString());
    }
}
