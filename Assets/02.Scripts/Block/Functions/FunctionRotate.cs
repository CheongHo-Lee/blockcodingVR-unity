using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunctionRotate : MonoBehaviour
{
    public bool rotateCheck = false;
    public int num;
    public Animator rotate;
    public Transform sunrise;
    public Transform sunset;
    public float journeyTime = 1.0F;
    private float startTime;
    public void Start()
    {
        num = 1;
        startTime = Time.time;
    }
    //public IEnumerator RightRotate()
    //{
    //    GameObject player;
    //    player = GameObject.FindGameObjectWithTag("Player");
    //    Vector3 startAngle = player.transform.eulerAngles;
    //    Debug.Log(startAngle);
    //    startAngle.y += 90;
    //    Vector3 endAngle = startAngle;
    //    Debug.Log(endAngle);
    //    float checkTime = 0;
    //    float directionTime = 1;    // ����ð�
    //    while (checkTime < directionTime)
    //    {
    //        yield return new WaitForFixedUpdate();
    //        checkTime += Time.fixedDeltaTime;
    //        transform.transform.eulerAngles = Vector3.Lerp(startAngle, endAngle, checkTime / directionTime);
    //    }
    //    yield return new WaitForSeconds(0.3f);
    //}

    public IEnumerator RightRotate() ///���������� 90�� ȸ��
    {
        GameObject player;
        player = GameObject.FindGameObjectWithTag("Player");
        rotate = player.GetComponent<Animator>();
        rotate.SetBool("TurnRight", true);
        float checkTime = 0;
        float directionTime = 1;    // ����ð�
        while (true)
        {
            player.transform.Rotate(0, 90 * Time.deltaTime, 0);
            
            checkTime += Time.deltaTime;
            if(checkTime > directionTime)
            {
                rotate.SetBool("TurnRight", false);
                break;
            }
            yield return null;
        } 
        //yield return new WaitForSeconds(0.3f);
    }

    public IEnumerator LeftRotate() ///�������� 90�� ȸ��
    {
        GameObject player;
        player = GameObject.FindGameObjectWithTag("Player");
        rotate = player.GetComponent<Animator>();
        rotate.SetBool("TurnRight", true);
        float checkTime = 0;
        float directionTime = 1;    // ����ð�
        while (true)
        {
            player.transform.Rotate(0, -90 * Time.deltaTime, 0);

            checkTime += Time.deltaTime;
            if (checkTime > directionTime)
            {
                rotate.SetBool("TurnRight", false);
                break;
            }
            yield return null;
        }
        //yield return new WaitForSeconds(0.3f);
    }
    public IEnumerator BackRotate() ///���������� 180�� ȸ��
    {
        GameObject player;
        player = GameObject.FindGameObjectWithTag("Player");
        rotate = player.GetComponent<Animator>();
        rotate.SetBool("TurnRight", true);
        float checkTime = 0;
        float directionTime = 1;    // ����ð�
        while (true)
        {
            player.transform.Rotate(0, 180 * Time.deltaTime, 0);

            checkTime += Time.deltaTime;
            if (checkTime > directionTime)
            {
                rotate.SetBool("TurnRight", false);
                break;
            }
            yield return null;
        }
        //yield return new WaitForSeconds(0.3f);
    }
}
