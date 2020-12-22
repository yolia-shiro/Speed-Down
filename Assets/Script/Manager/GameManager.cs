using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Creatable Object Message")]
    public BoxCollider2D createArea;
    public List<GameObject> creatableObj = new List<GameObject>();
    private float startTime = 0;
    public float createRate;
    private float minX, maxX;

    public float runTime;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance.gameObject);
        }
    }

    public float globalTime;
    // Start is called before the first frame update
    void Start()
    {
        minX = createArea.bounds.min.x;
        maxX = createArea.bounds.max.x;
    }

    // Update is called once per frame
    void Update()
    {
        runTime = Time.timeSinceLevelLoad;
        if (Time.time > startTime)
        {
            CreateEnvironmentObj();
            startTime = Time.time + createRate;
        }
    }

    public void CreateEnvironmentObj()
    {
        ////随机生成的物体
        //Random.Range(0, creatableObj.Count);
        ////随机坐标
        //Random.Range(minX, maxX);
        Instantiate(creatableObj[Random.Range(0, creatableObj.Count)], new Vector3(Random.Range(minX, maxX), createArea.transform.position.y, 0), Quaternion.identity);
    }

    public void Restart()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
