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
        float h = Input.GetAxis("Horizontal"); // 默认返回0， 按下键(a 或者 左方向键)后返回值是[-1, 0), 按下键(d 或者 右方向键)后返回值是(0, 1]可以模拟左右移动
        float v = Input.GetAxis("Vertical"); // 默认返回0，控制前后移动
        rd.AddForce(new Vector3(h, 0, v));
    }

    private void OnTriggerEnter(Collider collision)
    {
        string tag = collision.gameObject.tag;
        if (tag == "food")
        {
            score++;
            ScoreText.text = "分数: " + score;
            Destroy(collision.gameObject);
            checkWin();
        }
    }
    private void checkWin()
    {
        if(score >=3)
        {
            // 激活胜利文本
            WinText.SetActive(true);
            // 3秒后触发restart函数
            Invoke("restart", 3f);
        }
    }

    private void restart()
    {
        Debug.Log("重新开始");
        SceneManager.LoadScene(0);
    }
}
