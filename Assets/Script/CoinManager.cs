using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public CoinScript target;
    //public TextMesh Coin�Ǘ�;
    public TextMeshProUGUI CountCoinText;

    private int CoinCount;�@//�R�C���̃J�E���g
    public bool OneCount;�@//1�J�E���g���邽�߂̃u�[��

    // Start is called before the first frame update
    void OnDisable()
    {
        target.OnDestroyed.RemoveAllListeners();
    }

    void OnEnable()�@//����������ۃX�N���v�g������ꂽ�I�u�W�F�N�g�̏���
    {
        target.OnDestroyed.AddListener(() => {
            if (OneCount)
            {
                HowMuchCoin();
                Debug.Log("�R�C���J�E���g�I");
            }
            //Destroy(gameObject, 0.0f);
            //CloseDoor.SetActive(false);   // �����ɂ���
        });
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

    void Start()
    {
        OneCount = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
