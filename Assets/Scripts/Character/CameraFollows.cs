using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollows : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
     GameObject Character;
     [SerializeField]
     Vector3 Offset;
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        this.transform.position=Vector3.Lerp(this.transform.position,Character.transform.position-Offset,0.5f);
    }
}
