using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerMove : MonoBehaviour
{
    private bool goMove = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (goMove)
        {
            this.transform.position += new Vector3(0, 0, 1) * Time.deltaTime * 10;
            if (this.transform.position.z >= 100)
            {
                goMove = false;
            }
        }
        else
        {
            this.transform.position -= new Vector3(0, 0, 1) * Time.deltaTime * 10;
            if (this.transform.position.z <= -100)
            {
                goMove = true;
            }
        }
    }
}
