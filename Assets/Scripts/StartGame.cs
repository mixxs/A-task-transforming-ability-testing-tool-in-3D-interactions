using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    public InputField gameField;
    public InputField gameField2;
    public InputField gameField3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Load()
    {
        DataValue.timer = int.Parse(gameField.text);
        DataValue.arrowScale = int.Parse(gameField2.text);
        DataValue.arrowSpeed = int.Parse(gameField3.text);
        DataValue.level1Timer = 0;
        DataValue.level2Timer = 0;
        DataValue.level3Timer = 0;
        DataValue.level4Timer = 0;
        DataValue.level1True = 0;
        DataValue.level2True = 0;
        DataValue.level3True = 0;
        DataValue.level4True = 0;
        SceneManager.LoadScene(1);
    }
}
