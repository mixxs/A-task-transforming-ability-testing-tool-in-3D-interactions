using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelBac : MonoBehaviour
{
    private Button btn;

    // Start is called before the first frame update
    void Start()
    {
        btn = this.GetComponent<Button>();

        btn.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("Level");
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
