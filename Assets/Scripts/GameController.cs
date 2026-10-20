using UnityEngine;
using UnityEngine.Events;

public class GameController : MonoBehaviour
{
    public static GameController instance { get; private set; }



    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(this);
    }

}