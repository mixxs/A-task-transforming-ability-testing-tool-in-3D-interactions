using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum dir
{
    left,
    right,
    up,
    down,
    forward,
    back
}

public class ArrowMove : MonoBehaviour
{
    public dir dir1;
    public dir dir2;

    public GameObject arrow;

    // Start is called before the first frame update
    void Start()
    {
        this.transform.localScale *= DataValue.arrowScale;
    }

    // Update is called once per frame
    void Update()
    {
        Dir2(dir2);
    }

    /// <summary>
    /// 移动方向
    /// </summary>
    public void Dir1Move(dir d)
    {
        switch (d)
        {
            case dir.left:
                arrow.transform.localEulerAngles = new Vector3(180, 75, 90);
                break;
            case dir.right:
                arrow.transform.localEulerAngles = new Vector3(180, 260, 90);
                break;
            case dir.up:
                arrow.transform.localEulerAngles = new Vector3(180, 260, 0);
                break;
            case dir.down:
                arrow.transform.localEulerAngles = new Vector3(180, 260, 180);
                break;
            case dir.forward:
                arrow.transform.localEulerAngles = new Vector3(90, 0, 90);
                break;
            case dir.back:
                arrow.transform.localEulerAngles = new Vector3(90, 180, 270);
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// 箭头方向
    /// </summary>
    public void Dir2(dir d)
    {
        switch (d)
        {
            case dir.left:
                this.transform.position -= new Vector3(0, 0, 1) * Time.deltaTime * 5 * DataValue.arrowSpeed;
                break;
            case dir.right:
                this.transform.position += new Vector3(0, 0, 1) * Time.deltaTime * 5 * DataValue.arrowSpeed;
                break;
            case dir.up:
                this.transform.position += new Vector3(0, 1, 0) * Time.deltaTime * 5 * DataValue.arrowSpeed;
                break;
            case dir.down:
                this.transform.position -= new Vector3(0, 1, 0) * Time.deltaTime * 5 * DataValue.arrowSpeed;
                break;
            case dir.forward:
                this.transform.position -= new Vector3(1, 0, 0) * Time.deltaTime *  5 * DataValue.arrowSpeed;
                break;
            case dir.back:
                this.transform.position += new Vector3(1, 0, 0) * Time.deltaTime * 5 * DataValue.arrowSpeed;
                break;
            default:
                break;
        }
    }
}
