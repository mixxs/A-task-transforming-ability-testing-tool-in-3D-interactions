using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Level2Controller : MonoBehaviour
{
    public List<GameObject> gameobjs;
    public List<Vector3> originPosition;

    private int index;

    public Text tip;

    public GameObject overPanel;        //结算面板
    public Text aveTime;                //平均反应时间
    public Text trueF;                  //正确率

    public List<float> timers;      //反应时间数组
    private float allTim;           //总题目
    private float allFalse;         //错误题目
    private float fTimer;           //反应时间

    private float tTimer;           //总时间
    public Text timerTex;

    float value;

    private bool isOver = false;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < gameobjs.Count; i++)
        {
            originPosition[i] = gameobjs[i].transform.position;
            gameobjs[i].gameObject.transform.localScale *= DataValue.arrowScale;
        }
        tTimer = DataValue.timer;
        Rand();
    }

    public void ExportTimersToFile()
    {
        string desktopPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop);
        string timestamp = System.DateTime.Now.ToString("yyyyMMdd_HHmmss");
        string filePath = Path.Combine(desktopPath, $"timers_{timestamp}.txt");

        using (StreamWriter writer = new StreamWriter(filePath))
        {
            foreach (float timer in timers)
            {
                writer.WriteLine(timer.ToString());
            }
            float percentage = allTim != 0 ? ((allTim - allFalse) / allTim) * 100 : 0;
            writer.WriteLine("正确率：" + percentage.ToString() + "%");
        }

        Debug.Log("Timers exported to " + filePath);
    }

    // Update is called once per frame
    void Update()
    {
        if (isOver)
        {
            return;
        }
        tTimer -= Time.deltaTime;
        timerTex.text = tTimer.ToString("0.00") + "s";
        if (tTimer < 0)
        {
            for (int i = 0; i < timers.Count; i++)
            {
                value += timers[i];
            }
            overPanel.gameObject.SetActive(true);
            aveTime.text = "平均反应时间" + (value / (timers.Count * 1.0f)).ToString() + "s";
            trueF.text = (((allTim - allFalse) / allTim) * 100).ToString() + "%";

            DataValue.level2Timer = value / (timers.Count * 1.0f);
            DataValue.level2True = (allTim - allFalse) / allTim *100;
            isOver = true;
        }
        fTimer += Time.deltaTime;
        if (index == 0)
        {
            for (int i = 0; i < gameobjs.Count; i++)
            {
                gameobjs[i].gameObject.transform.position += Time.deltaTime * new Vector3(0, 1, 0) * DataValue.arrowSpeed;
            }

            if (Input.GetKeyDown(KeyCode.W))
            {
                timers.Add(fTimer);
                Rand();
                tip.gameObject.SetActive(true);
                tip.text = "正确";
            }
            else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Q))
            {
                tip.gameObject.SetActive(true);
                tip.text = "错误";
                allFalse++;
                Rand();
            }

        }
        else if (index == 1)
        {
            for (int i = 0; i < gameobjs.Count; i++)
            {
                gameobjs[i].gameObject.transform.position += Time.deltaTime * new Vector3(0, -1, 0) * DataValue.arrowSpeed;
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                tip.gameObject.SetActive(true);
                timers.Add(fTimer);
                tip.text = "正确";
                Rand(); 
            }
            else if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Q))
            {
                tip.gameObject.SetActive(true);
                allFalse++;
                tip.text = "错误";
                Rand();
            }
        }
        else if (index == 2)
        {
            for (int i = 0; i < gameobjs.Count; i++)
            {
                gameobjs[i].gameObject.transform.position += Time.deltaTime * new Vector3(0, 0, -1) * DataValue.arrowSpeed;
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                tip.gameObject.SetActive(true);
                timers.Add(fTimer);
                tip.text = "正确";
                Rand();
            }
            else if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Q))
            {
                tip.gameObject.SetActive(true);
                allFalse++;
                tip.text = "错误";
                Rand();
            }
        }
        else if (index == 3)
        {
            for (int i = 0; i < gameobjs.Count; i++)
            {
                gameobjs[i].gameObject.transform.position += Time.deltaTime * new Vector3(0, 0, 1) * DataValue.arrowSpeed;
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                tip.gameObject.SetActive(true);
                timers.Add(fTimer);
                tip.text = "正确";
                Rand();
            }
            else if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Q))
            {
                tip.gameObject.SetActive(true);
                allFalse++;
                tip.text = "错误";
                Rand();
            }
        }
        else if (index == 4)
        {
            for (int i = 0; i < gameobjs.Count; i++)
            {
                gameobjs[i].gameObject.transform.position += Time.deltaTime * new Vector3(-1, 0, 0) * DataValue.arrowSpeed;
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                tip.gameObject.SetActive(true);
                timers.Add(fTimer);
                tip.text = "正确";
                Rand();
            }
            else if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.Q))
            {
                tip.gameObject.SetActive(true);
                allFalse++;
                tip.text = "错误";
                Rand();
            }
        }
        else if (index == 5)
        {
            for (int i = 0; i < gameobjs.Count; i++)
            {
                gameobjs[i].gameObject.transform.position += Time.deltaTime * new Vector3(1, 0, 0) * DataValue.arrowSpeed;
            }


            if (Input.GetKeyDown(KeyCode.Q))
            {
                tip.gameObject.SetActive(true);
                timers.Add(fTimer);
                tip.text = "正确";
                Rand();
            }
            else if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.E))
            {
                tip.gameObject.SetActive(true);
                allFalse++;
                tip.text = "错误";
                Rand();
            }
        }

    }

    private void Rand()
    {
        for (int i = 0; i < gameobjs.Count; i++)
        {
            gameobjs[i].gameObject.SetActive(false);
            gameobjs[i].gameObject.transform.position = originPosition[i];
        }
        Invoke("Init", 1);

    }

    private void Init()
    {
        allTim++;
        for (int i = 0; i < gameobjs.Count; i++)
        {
            gameobjs[i].gameObject.SetActive(false);
            gameobjs[i].gameObject.transform.position = originPosition[i];
        }
       

        int indexv = Random.Range(0, gameobjs.Count);
        gameobjs[indexv].gameObject.SetActive(true);

        //index = Random.Range(0, gameobjs.Count);
        if (indexv == 0)
        {
            index = 1;
        }
        else if (indexv == 1)
        {
            index = 0;
        }
        else if (indexv == 2)
        {
            index = 3;
        }
        else if (indexv == 3)
        {
            index = 2;
        }
        else if (indexv == 4)
        {
            index = 5;
        }
        else if (indexv == 5)
        {
            index = 4;
        }
        fTimer = 0;
    }
}
