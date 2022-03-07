using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportScript : MonoBehaviour
{
    #region references

    public SceneManagement sm;
    public string sceneName;

    #endregion

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            sm.ChangeScene(sceneName);
        }
    }

}
