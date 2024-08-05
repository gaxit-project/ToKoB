using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreResult : MonoBehaviour
{
    public TextMeshProUGUI ResultText;

    private int CoinCount;�@//�R�C���̃J�E���g
    public bool OneCount;�@//1�J�E���g���邽�߂̃u�[��
    public int CoinInBox;

    public void CoinDrop()
    {
        ResultText.text = "Your Score is " + CoinGet.CoinCount.ToString();
    }

    IEnumerator CoinPopCoroutine()�@//�G�l�~�[�̃^�[���̏I���A�I����̏������s���R���[�`��
    {
        //�����ɏ���������
        Debug.Log("�C����");
        GameObject obj = (GameObject)Resources.Load("ResultCoin");
        Instantiate(obj, new Vector3(0.0f, 5, -1.5f), Quaternion.identity);


        //1�t���[����~
        yield return new WaitForSeconds(1f);�@//0.5f���Ԃ��X�g�b�v

        //�����ɍĊJ��̏���������
        OneCount = true;
        CoinInBox = CoinInBox - 1;
        //Debug.Log("�^�[���G���h�I");

    }

    // Start is called before the first frame update
    void Start()
    {
        CoinInBox = CoinGet.CoinCount;
        OneCount = true;
    }

    // Update is called once per frame
    void Update()
    {
        /*while (CoinInBox > 0)
        {
            StartCoroutine("CoinPopCoroutine");
        }*/
        if(CoinInBox > 0 && OneCount)
        {
            OneCount = false;
            StartCoroutine("CoinPopCoroutine");
        }
        else if(CoinInBox == 0)
        {
            CoinDrop();
        }
    }
}
