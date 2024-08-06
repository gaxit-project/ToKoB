using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLevels : MonoBehaviour
{
    public GameObject[] Marumoto;
    public GameObject[] Uetani;
    public GameObject[] Tsujino;
    public GameObject[] Yuasa;
    public GameObject Tunnel;
    public GameObject Flag;
    public int zPos = 10;
    public bool creatingLevel = false;
    public int lvlNum;
    bool StageChange = false;
    int StageCount = 0;
    int CheckPoint=5;
    float delay=5;

    
    int currentStage = 0; // 現在のステージを追跡するインデックス

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        currentStage = Random.Range(0, 4);
    }

    // Update is called once per frame
    void Update()
    {
        if (!creatingLevel)
        {
            switch (currentStage)
            {
                case 0:
                    MarumotoLvl();
                    break;
                case 1:
                    UetaniLvl();
                    break;
                case 2:
                    TsujinoLvl();
                    break;
                case 3:
                    YuasaLvl();
                    break;
            }

            if (StageCount >= CheckPoint)
            {
                TunnelLv1();
                //TunnelLv1();
                creatingLevel = true;
                StartCoroutine(SwitchStageAfterDelay(delay)); // 3秒の待機
                CheckPoint++;
                delay+=3; //生成のスパン遅らす
            }
        }
    }

    void MarumotoLvl()
    {
        lvlNum = Random.Range(0, 9); // 0, 1, 2, 3
        Instantiate(Marumoto[lvlNum], new Vector3(0, 0, zPos), Quaternion.identity);
        zPos += 15;
        StageCount++;
    }

    void UetaniLvl()
    {
        lvlNum = Random.Range(0, 7); // 0, 1, 2, 3
        Instantiate(Uetani[lvlNum], new Vector3(0, 0, zPos), Quaternion.identity);
        zPos += 10;
        StageCount++;
    }

    void TsujinoLvl()
    {
        lvlNum = Random.Range(0, 8); // 0, 1, 2, 3
        Instantiate(Tsujino[lvlNum], new Vector3(0, 0, zPos), Quaternion.identity);
        zPos += 10;
        StageCount++;
    }
    void YuasaLvl()
    {
        lvlNum = Random.Range(0, 5); // 0, 1, 2, 3
        Instantiate(Yuasa[lvlNum], new Vector3(0, 0, zPos), Quaternion.identity);
        zPos += 15;
        StageCount++;
    }

    void TunnelLv1()
    {
        Instantiate(Tunnel, new Vector3(0, 0, zPos), Quaternion.identity);
        zPos += 20;
    }

    void FlagLv1()
    {
        Instantiate(Flag, new Vector3(0, 2, zPos), Quaternion.identity);
    }

    IEnumerator SwitchStageAfterDelay(float delay)
    {
        Debug.Log("ステージ切り替え");
        yield return new WaitForSeconds(delay); // 指定された時間待機
        StageCount = 0;
        currentStage = Random.Range(0, 4); // 次のステージに切り替え（0, 1, 2,3 の範囲でループ）
        creatingLevel = false;
    }
}
