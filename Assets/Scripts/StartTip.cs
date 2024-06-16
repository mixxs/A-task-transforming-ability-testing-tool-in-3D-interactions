using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartTip : MonoBehaviour
{
    public Button tip;

    // Start is called before the first frame update
    void Start()
    {
        tip.onClick.AddListener(Onre);
        Time.timeScale = 0;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Onre()
    {
        this.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
