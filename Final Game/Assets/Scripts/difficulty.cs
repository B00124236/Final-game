using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class difficulty : MonoBehaviour
{
    private Button button;
    private SpawnManager spawnManager;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        spawnManager = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();

        button.onClick.AddListener(Difficulty);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Difficulty()
    {
        Debug.Log(button.gameObject.name + " was clicked");
        spawnManager.startGame();
    }
}
