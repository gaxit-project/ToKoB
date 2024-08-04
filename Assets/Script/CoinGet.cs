using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CoinGet : MonoBehaviour
{
    public TextMeshProUGUI CountCoinText;

    public static int CoinCount;�@//�R�C���̃J�E���g
    public bool OneCount;�@//1�J�E���g���邽�߂̃u�[��

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            HowMuchCoin();
        }
        else if (collision.gameObject.tag == "TsujinoTest")
        {
            SceneManager.LoadScene("Clear");
        }
    }

    public void HowMuchCoin()
    {
        OneCount = false;                                                                              //�^�[���̃J�E���g�𕡐���s��Ȃ��悤�ɂ��邽��
        CoinCount++;                                                                                       //�^�[�����J�E���g
        Debug.Log(CoinCount);
        CountCoinText.text = "Score : " + CoinCount.ToString();
        StartCoroutine("ReCoinCountCoroutine");
    }

    IEnumerator ReCoinCountCoroutine()�@//�G�l�~�[�̃^�[���̏I���A�I����̏������s���R���[�`��
    {
        //�����ɏ���������
        Debug.Log("�C����");


        //1�t���[����~
        yield return new WaitForSeconds(0.5f);�@//0.5f���Ԃ��X�g�b�v

        //�����ɍĊJ��̏���������
        OneCount = true;
        //Debug.Log("�^�[���G���h�I");

    }

    // Start is called before the first frame update
    void Start()
    {
        OneCount = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
