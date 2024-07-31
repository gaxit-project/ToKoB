using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerControll : MonoBehaviour
{
    public float moveSpeed = 3f; // 前進速度
    public float acceleration = 0.01f; // 加速
    public float leftRightSpeed = 4f; // 左右移動
    public float upwardForce = 10f; // ジャンプ力
    private Rigidbody rb;
    private bool isGrounded; // フラグを追加
    private Countdown countdown; // Countdownスクリプトへの参照を追加
    public TextMeshProUGUI countdownText; //旗に触れたら時間変更
    private Time time; // Time スクリプトへの参照を追加
     private Animator animator; // Animatorコンポーネントへの参照

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); // このGameObjectにアタッチされているRigidbodyコンポーネントを取得
        animator = GetComponent<Animator>(); // Animatorコンポーネントを取得
        GameObject gameManagerObj = GameObject.Find("GameManager"); // GameManagerオブジェクトを取得

        if (gameManagerObj != null)
        {
            countdown = gameManagerObj.GetComponent<Countdown>(); // Countdownスクリプトを取得
            time = gameManagerObj.GetComponent<Time>(); // Timeスクリプトを取得
        }
        else
        {
            Debug.LogError("GameManager オブジェクトが見つかりません");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (countdown != null && countdown.start) // カウントダウンが終了したかどうか
        {
            
            //-----------------移動、ジャンプのスクリプト----------------------
            transform.Translate(Vector3.forward * UnityEngine.Time.deltaTime * moveSpeed, Space.World);
            moveSpeed += UnityEngine.Time.deltaTime * acceleration;
            animator.SetBool("Run",true); // 走り出す

            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(Vector3.left * UnityEngine.Time.deltaTime * leftRightSpeed);
            }

            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate(Vector3.left * UnityEngine.Time.deltaTime * leftRightSpeed * -1);
            }

            if (Input.GetKeyDown(KeyCode.Space) && isGrounded && rb != null)
            {
                rb.AddForce(Vector3.up * upwardForce, ForceMode.Impulse);
                isGrounded = false; // ジャンプ後は空中にいるとする
                animator.SetTrigger("Jump"); // ジャンプのトリガーを設定
                Debug.Log("ジャンプ");
            }
        }
    }

    //-------------------ジャンプするときに地面についているかどうか-----------------------------
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Road")
        {
            isGrounded = true; // "Road"タグのオブジェクトと接触したときにフラグをtrueにする
            Debug.Log("地面に触れる");
        }
    }
}
