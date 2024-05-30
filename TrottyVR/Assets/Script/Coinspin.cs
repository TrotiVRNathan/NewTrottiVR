using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coinspin : MonoBehaviour
{
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,5,0,Space.World);
    }
}
