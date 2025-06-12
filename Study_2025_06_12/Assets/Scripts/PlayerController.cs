using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rigid2D;
    private float jumpForce = 680.0f;
    private float walkForce = 30.0f;
    private float maxWalkSpeed = 2.0f;

    private void Start()
    {
        Application.targetFrameRate = 60;
        QualitySettings.vSyncCount = 0;
        this.rigid2D = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        // �����Ѵ�.
        if(Input.GetKeyDown(KeyCode.Space))
        {
            this.rigid2D.AddForce(transform.up * this.jumpForce);
        }

        // �¿� �̵�
        int Key = 0;
        if (Input.GetKey(KeyCode.RightArrow)) Key = 1;
        if (Input.GetKey(KeyCode.LeftArrow)) Key = -1;

        // �÷��̾��� �ӵ�
        float speedx = Mathf.Abs(this.rigid2D.velocity.x);

        // ���ǵ� ����
        if(speedx < this.maxWalkSpeed)
        {
            this.rigid2D.AddForce(transform.right * Key * this.walkForce);
        }
    }
}
