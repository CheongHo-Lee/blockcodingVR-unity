using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class player_holder : MonoBehaviour
{
    #region �ܺ� �Լ� ����
    GameObject Blocks;

    #endregion
    public Image StartButton = null;

    //Panel Main Loop �ȿ� �ڽĵ� ������ ����
    public IEnumerator Go() //��ŸƮW��ư�� �������� ����Ǵ� �ڷ�ƾ�Լ�
    {
        yield return new WaitForSeconds(1f); //1�� ������
        ///�����гο� ����

        //GameObject Blocks = GameObject.Find("Main/Canvas/Panel Main Loop").gameObject;
        Blocks = GameObject.Find("Canvas").transform.Find("Panel").transform.Find("Panel Main Loop").gameObject; //Panel Main Loop�� ����
        int nSize = Blocks.transform.childCount; //Panel Main Loop�� �ڽĵ� ����
        for (int i = 0; i < nSize; i++)
        {
            GameObject Child = Blocks.transform.GetChild(i).gameObject; // Panel Main Loop�� �ڽĿ�����Ʈ ����
            ///����� �Լ��� �� �ҷ�����
            FunctionMove FunctionMove = Child.GetComponent<FunctionMove>();  //�ڽĿ�����Ʈ�� FunctionMove �Լ� �ҷ�����
            FunctionJump FunctionJump = Child.GetComponent<FunctionJump>();
            FunctionRotate FunctionRotate = Child.GetComponent<FunctionRotate>();  //�ڽĿ�����Ʈ�� FunctionRotate �Լ� �ҷ�����
            FunctionFor FunctionFor = Child.GetComponent<FunctionFor> (); //�ڽĿ�����Ʈ�� FunctionFor �Լ� �ҷ�����
            FunctionClass FunctionClass = Child.GetComponent<FunctionClass>();

            ///���ʷ� �Լ����� �ִ��� üũ�ϱ�
            if (FunctionMove)   //FunctionMove ��, �̵� ����϶� ����
            {
                yield return StartCoroutine(FunctionMove.MoveZ()); //z�� 1 �̵�
            }
            else if (!FunctionMove && FunctionJump) // ȸ�� ��� �϶� ����
            {
                if (Child.tag == "Jump") //����
                    yield return StartCoroutine(FunctionJump.Jump());
            }
            else if (!FunctionMove && !FunctionJump &&  FunctionRotate) // ȸ�� ��� �϶� ����
            {
                if (Child.tag == "Rotate_R") //������ ȸ��
                    yield return StartCoroutine(FunctionRotate.RightRotate());
                else if (Child.tag == "Rotate_L") //���� ȸ��
                    yield return StartCoroutine(FunctionRotate.LeftRotate());
                else if (Child.tag == "Rotate_B") //������ ȸ��
                    yield return StartCoroutine(FunctionRotate.BackRotate());
            }
            else if (!FunctionMove && !FunctionJump &&  !FunctionRotate && FunctionFor)
            {
                yield return StartCoroutine(FunctionFor.For()); //z�� 1 �̵�
            }

            else if (!FunctionMove && !FunctionJump &&  !FunctionRotate && FunctionFor)
            {
                yield return StartCoroutine(FunctionFor.For()); //z�� 1 �̵�
            }
            else if (!FunctionMove && !FunctionJump &&  !FunctionRotate && !FunctionFor && FunctionClass)
            {
                yield return StartCoroutine(FunctionClass.Function()); //z�� 1 �̵�
            }

        }
    }

   
    public void OnClickButton() //��ŸƮ ��ư �������� ����
    {
        StartCoroutine(Go());
        StartButton.enabled = false;
    }
}