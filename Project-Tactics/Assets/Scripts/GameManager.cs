using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Unit sUnit;
    public TileMap map;
    public static GameManager instance;

    // Start is called before the first frame update
    private void Awake()
    {
        
    }

    private void Start()
    {
        if (instance == null) { instance = this; } else { if (instance != this) { Destroy(gameObject); } };
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame

    public static GameManager SeekManager()
    {
        return GameManager.FindObjectOfType<GameManager>();
    }

}
