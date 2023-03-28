using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Rigidbody rd;
    public int score;
    public Text ScoreText;
    public GameObject WinText;
    // Start is called before the first frame update
    void Start()
    {
        rd = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //rd.AddForce(Vector3.right);
        float h = Input.GetAxis("Horizontal"); // Ĭ�Ϸ���0�� ���¼�(a ���� �����)�󷵻�ֵ��[-1, 0), ���¼�(d ���� �ҷ����)�󷵻�ֵ��(0, 1]����ģ�������ƶ�
        float v = Input.GetAxis("Vertical"); // Ĭ�Ϸ���0������ǰ���ƶ�
        rd.AddForce(new Vector3(h, 0, v));
    }

    private void OnTriggerEnter(Collider collision)
    {
        string tag = collision.gameObject.tag;
        if (tag == "food")
        {
            score++;
            ScoreText.text = "����: " + score;
            Destroy(collision.gameObject);
            checkWin();
        }
    }
    private void checkWin()
    {
        if(score >=3)
        {
            // ����ʤ���ı�
            WinText.SetActive(true);
            // 3��󴥷�restart����
            Invoke("restart", 3f);
        }
    }

    private void restart()
    {
        Debug.Log("���¿�ʼ");
        SceneManager.LoadScene(0);
    }
}
