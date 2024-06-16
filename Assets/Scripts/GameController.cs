using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.ConstrainedExecution;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public bool isFour = false;
    public GameObject ter;      //地形
    private Vector3 originPosition;

    //绿背景，红箭头：按下的方向按键为箭头的运动方向
    //红背景，绿箭头：按下的方向键为箭头方向
    public List<GameObject> gameobjs;

    //Back
    private float backX = 35;
    private float backY = 28;
    private float backZ1 = 40;
    private float backZ2 = 65;

    //Forward
    private float ForwardX = 80;
    private float ForwardY = 28;
    private float ForwardZ1 = 40;
    private float ForwardZ2 = 65;

    //Up
    private float UpX = 66.6f;
    private float UpY = 25.5f;
    private float UpZ1 = 43.6f;
    private float UpZ2 = 66;

    //Down
    private float DownX = 66.6f;
    private float DownY = 31F;//46.9f;
    private float DownZ1 = 43.6f;
    private float DownZ2 = 66;

    //Right
    private float RightX1 = 71.7f;
    private float RightX2 = 95.4f;
    private float RightY = 27.9f;
    private float RightZ = 50;

    //Left
    private float LeftX1 = 71.7f;
    private float LeftX2 = 95.4f;
    private float LeftY = 27.9f;
    private float LeftZ = 60;

    private float timer = 0;
    private float timerCd = 1;

    private bool isChange = true;

    public List<GameObject> allObjs;
    private int index;              //Back,Forward,Up,Down,Right,Left
    private int index2;

    private int lx = 0;             //类型0：绿背景， 类型1：红背景
    public Camera bg;

    public Text tex;
    private float timerTex = 30f;

    public List<float> timers;      //反应时间数组
    private float allTim;           //总题目
    private float allFalse;         //错误题目
    private float fTimer;           //反应时间

    public Text tip;

    public GameObject overPanel;        //结算面板
    public Text aveTime;                //平均反应时间
    public Text trueF;                  //正确率
    float value;

    private bool isOver = false;

    public void Back()
    {
        SceneManager.LoadScene(0);
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

    // Start is called before the first frame update
    void Start()
    {
        timerTex = DataValue.timer;
        if (isFour)
        {
         //   originPosition = ter.gameObject.transform.position;
        }
       
    }

    private void InputSys()
    {
        if (lx == 0)
        {
            if (isFour)
            {


                //if (index == 0)
                //{
                //    ter.gameObject.transform.position -= new Vector3(1, 0, 0) * Time.deltaTime * 20;
                //}
                //else if (index == 1)
                //{
                //    ter.gameObject.transform.position -= new Vector3(-1, 0, 0) * Time.deltaTime * 20;
                //}
                //else if (index == 2)
                //{
                //    ter.gameObject.transform.position -= new Vector3(0, 1, 0) * Time.deltaTime * 20;
                //}
                //else if (index == 3)
                //{
                //    ter.gameObject.transform.position -= new Vector3(0, -1, 0) * Time.deltaTime * 20;
                //}
                //else if (index == 4)
                //{
                //    ter.gameObject.transform.position -= new Vector3(0, 0, 1) * Time.deltaTime * 20;
                //}
                //else if (index == 5)
                //{
                //    ter.gameObject.transform.position -= new Vector3(0, 0, -1) * Time.deltaTime * 20;
                //}
            }

            if (Input.GetKeyDown(KeyCode.Q) && index == 0)
            {

                
                allTim++;
                timers.Add(fTimer);
                tip.text = "正确";
                tip.gameObject.SetActive(true);
                fTimer = 0;
                isChange = true;
                
            }
            else if (Input.GetKeyDown(KeyCode.E) && index == 1)
            {
                
                allTim++;
                timers.Add(fTimer);
                tip.text = "正确";
                fTimer = 0;
                tip.gameObject.SetActive(true);
                isChange = true;
            }
            else if (Input.GetKeyDown(KeyCode.W) && index == 2)
            {

                allTim++;
                timers.Add(fTimer);
                tip.text = "正确";
                fTimer = 0;
                tip.gameObject.SetActive(true);
                isChange = true;
            }
            else if (Input.GetKeyDown(KeyCode.S) && index == 3)
            {
                
                allTim++;
                timers.Add(fTimer);
                tip.text = "正确";
                fTimer = 0;
                tip.gameObject.SetActive(true);
                isChange = true;
            }
            else if (Input.GetKeyDown(KeyCode.D) && index == 4)
            {
                
                allTim++;
                timers.Add(fTimer);
                tip.text = "正确";
                fTimer = 0;
                tip.gameObject.SetActive(true);
                isChange = true;
            }
            else if (Input.GetKeyDown(KeyCode.A) && index == 5)
            {
            
                allTim++;
                timers.Add(fTimer);
                tip.text = "正确";
                fTimer = 0;
                tip.gameObject.SetActive(true);
                isChange = true;
            }
            else if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.W)
                || Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.E))
            {
                allTim++;
                allFalse++;
                timers.Add(fTimer);
                tip.text = "错误";
                fTimer = 0;
                tip.gameObject.SetActive(true);
                isChange = true;
                //错误
            }
        }
        else
        {
            if (isFour)
            {


                //if (index2 == 0)
                //{
                //    ter.gameObject.transform.position -= new Vector3(1, 0, 0) * Time.deltaTime * 20;
                //}
                //else if (index2 == 1)
                //{
                //    ter.gameObject.transform.position -= new Vector3(-1, 0, 0) * Time.deltaTime * 20;

                //}
                //else if (index2 == 2)
                //{
                //    ter.gameObject.transform.position -= new Vector3(0, 1, 0) * Time.deltaTime * 20;
                //}
                //else if (index2 == 3)
                //{
                //    ter.gameObject.transform.position -= new Vector3(0, -1, 0) * Time.deltaTime * 20;
                //}
                //else if (index2 == 4)
                //{
                //    ter.gameObject.transform.position -= new Vector3(0, 0, 1) * Time.deltaTime * 20;
                //}
                //else if (index2 == 5)
                //{
                //    ter.gameObject.transform.position -= new Vector3(0, 0, -1) * Time.deltaTime * 20;
                //}
            }

            if (Input.GetKeyDown(KeyCode.Q) && index2 == 0)
            {
                
                allTim++;
                timers.Add(fTimer);
                tip.text = "正确";
                fTimer = 0;
                tip.gameObject.SetActive(true);
                isChange = true;
            }
            else if (Input.GetKeyDown(KeyCode.E) && index2 == 1)
            {
               
                allTim++;
                timers.Add(fTimer);
                tip.text = "正确";
                fTimer = 0;
                tip.gameObject.SetActive(true);
                isChange = true;
            }
            else if (Input.GetKeyDown(KeyCode.W) && index2 == 2)
            {
                
                allTim++;
                timers.Add(fTimer);
                tip.text = "正确";
                fTimer = 0;
                tip.gameObject.SetActive(true);
                isChange = true;
            }
            else if (Input.GetKeyDown(KeyCode.S) && index2 == 3)
            {
               
                allTim++;
                timers.Add(fTimer);
                tip.text = "正确";
                fTimer = 0;
                tip.gameObject.SetActive(true);
                isChange = true;
            }
            else if (Input.GetKeyDown(KeyCode.D) && index2 == 4)
            {
                
                allTim++;
                timers.Add(fTimer);
                tip.text = "正确";
                fTimer = 0;
                tip.gameObject.SetActive(true);
                isChange = true;
            }
            else if (Input.GetKeyDown(KeyCode.A) && index2 == 5)
            {
                
                allTim++;
                timers.Add(fTimer);
                tip.text = "正确";
                fTimer = 0;
                tip.gameObject.SetActive(true);
                isChange = true;
            }
            else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.W)
                || Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.E))
            {
                allTim++;
                allFalse++;
                tip.text = "错误";
                fTimer = 0;
                tip.gameObject.SetActive(true);
                isChange = true;
                //错误
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isOver)
        {
            return;
        }
        timerTex -= Time.deltaTime;
        tex.text = timerTex.ToString("0.00") + "s";
        if (timerTex < 0 )
        {
            overPanel.gameObject.SetActive(true);
           
            for (int i = 0; i < timers.Count; i++)
            {
                value += timers[i];
            }
           
            if (isFour)
            {
                DataValue.level4Timer = value / (timers.Count * 1.0f);
                DataValue.level4True = (allTim - allFalse) / allTim * 100;
                aveTime.text = "平均反应时间" + (value / (timers.Count * 1.0f)).ToString() + "s";
                trueF.text = (((allTim - allFalse) / allTim) * 100).ToString() + "%";
            }
            else
            {
                DataValue.level4Timer = ((value / (timers.Count * 1.0f)) + DataValue.level3Timer + DataValue.level2Timer + DataValue.level1Timer) / 4;
                DataValue.level4True = (((allTim - allFalse) / allTim * 100) + DataValue.level3True + DataValue.level2True + DataValue.level1True) / 4;
                aveTime.text = "平均反应时间" + DataValue.level4Timer + "s";
                trueF.text = DataValue.level4True + "%";

            }
           
            isOver = true;
            return;
        }

        if (isChange)
        {
            ChangeIndex();
            for (int i = 0; i < allObjs.Count; i++)
            {
                Destroy(allObjs[i].gameObject);
            }
            allObjs.Clear();
            isChange = false;
        }
        else
        {
            fTimer += Time.deltaTime;
            
                 InputSys();
            
           
            timer += Time.deltaTime;
            if (timer >= timerCd)
            {
               
                SpwonObj();
                timer = 0;
            }
        }
    }

    private void ChangeIndex()
    {
        lx = Random.Range(0, 2);   
        if (lx == 0)
        {
            bg.backgroundColor = Color.white;
        }
        else
        {
            bg.backgroundColor = Color.black;
        }
        index = Random.Range(0, 6);
        //index2 = Random.Range(0, 6);    
        if (index == 0)
        {
            index2 = 1;
        }
        else if (index == 1)
        {
            index2 = 0;
        }
        else if (index == 2)
        {
            index2 = 3;
        }
        else if (index == 3)
        {
            index2 = 2;
        }
        else if (index == 4)
        {
            index2 = 5;
        }
        else if (index == 5)
        {
            index2 = 4;
        }
    }

    private void Index2Go(GameObject go)
    {
        if (index2 == 0)
        {
            go.GetComponent<ArrowMove>().Dir1Move(dir.back);
        }
        else if (index2 == 1)
        {
            go.GetComponent<ArrowMove>().Dir1Move(dir.forward);
        }
        else if (index2 == 2)
        {
            go.GetComponent<ArrowMove>().Dir1Move(dir.up);
        }
        else if (index2 == 3)
        {
            go.GetComponent<ArrowMove>().Dir1Move(dir.down);
        }
        else if (index2 == 4)
        {
            go.GetComponent<ArrowMove>().Dir1Move(dir.right);
        }
        else if (index2 == 5)
        {
            go.GetComponent<ArrowMove>().Dir1Move(dir.left);
        }
    }

    private void SpwonObj()
    {
        if (index == 0)
        {
            Vector3 posi0 = new Vector3(backX, backY, Random.Range(backZ1, backZ2));
            GameObject go = Instantiate(gameobjs[lx],posi0, Quaternion.identity);
            go.GetComponent<ArrowMove>().dir2 = dir.back;
            Index2Go(go);
            allObjs.Add(go);


        }
        else if (index == 1)
        {
            Vector3 posi0 = new Vector3(ForwardX, ForwardY, Random.Range(ForwardZ1, ForwardZ2));
            GameObject go = Instantiate(gameobjs[lx], posi0, Quaternion.identity);
            go.GetComponent<ArrowMove>().dir2 = dir.forward;
            Index2Go(go);
            allObjs.Add(go);

        }
        else if (index == 2)
        {
            Vector3 posi0 = new Vector3(UpX, UpY, Random.Range(UpZ1, UpZ2));
            GameObject go = Instantiate(gameobjs[lx], posi0, Quaternion.identity);
            go.GetComponent<ArrowMove>().dir2 = dir.up;
            Index2Go(go);
            allObjs.Add(go);

        }
        else if (index == 3)
        {
            Vector3 posi0 = new Vector3(DownX, DownY, Random.Range(DownZ1, DownZ2));
            GameObject go = Instantiate(gameobjs[lx], posi0, Quaternion.identity);
            go.GetComponent<ArrowMove>().dir2 = dir.down;
            Index2Go(go);
            allObjs.Add(go);

        }
        else if (index == 4)
        {
            Vector3 posi0 = new Vector3(Random.Range(RightX1,RightX2), RightY, RightZ);
            GameObject go = Instantiate(gameobjs[lx], posi0, Quaternion.identity);
            go.GetComponent<ArrowMove>().dir2 = dir.right;
            Index2Go(go);
            allObjs.Add(go);

        }
        else if (index == 5)
        {
            Vector3 posi0 = new Vector3(Random.Range(LeftX1, LeftX2), LeftY, LeftZ);
            GameObject go = Instantiate(gameobjs[lx], posi0, Quaternion.identity);
            go.GetComponent<ArrowMove>().dir2 = dir.left;
            Index2Go(go);
            allObjs.Add(go);

        }
      
    }

    
}
