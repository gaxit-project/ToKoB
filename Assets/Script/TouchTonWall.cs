using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TatchTonWall : MonoBehaviour
{
    private HPDecrease hpDecrease; // HPDecrease �X�N���v�g�ւ̎Q�Ƃ�ǉ�

    public bool OneCount;�@//1�J�E���g���邽�߂̃u�[��

    // Start is called before the first frame update

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "TonnWall" /*&& OneCount == true*/)
        {
            Debug.Log("�ǂɏՓˁI");
            this.transform.position = new Vector3(0, transform.position.y, transform.position.z);
            //StartCoroutine(hpDecrease.DestroyImagesCoroutine()); // �摜�j��R���[�`��
            //OneCount = false;
        }
        /*else if (collision.gameObject.tag == "TonnOut")
        {
            OneCount = true;
        }*/
    }

    void Start()
    {
        GameObject gameManagerObj = GameObject.Find("GameManager"); // GameManager�I�u�W�F�N�g���擾
        hpDecrease = gameManagerObj.GetComponent<HPDecrease>(); // HPDecrease�X�N���v�g���擾
        OneCount = true;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
