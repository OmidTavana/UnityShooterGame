using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowObject : MonoBehaviour
{
    [SerializeField]
    public GameObject Object;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 player = Object.transform.position;
        this.transform.position = new Vector3(player.x, this.transform.position.y, player.z - 6);
    }
}
