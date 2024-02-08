using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private GameObject startPosition;
    private GameObject respawnPosition;
    // Start is called before the first frame update
    void Start()
    {
        respawnPosition = startPosition;
    }
    
    public void Respawn(){
        gameObject.transform.position = respawnPosition.transform.position;
    }
}