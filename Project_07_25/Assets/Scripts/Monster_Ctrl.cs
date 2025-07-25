using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;

public class Monster_Ctrl : MonoBehaviour
{
    private Rigidbody2D rd;
    [SerializeField] private float MonsterSpeed;
    [SerializeField] private Image MonsterImg;
    private float MonsterHp = 1;
    private float Damage;
    private float Armor = 0;
    private float timing = 2;
    private void Start()
    {
        rd = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        MoveMonster();
        ArmorSeting();
        MonsterDeath();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Hero")
        {
            Destroy(gameObject);
        }
        if(collision.gameObject.tag == "Bullet")
        {
            Damage = 0.25f - Armor;
            if(Damage <= 0.01f)
            {
                Damage = 0.01f;
            }
            MonsterHp -= Damage;
            MonsterImg.fillAmount = MonsterHp;
            if(MonsterHp <= 0)
            {
                Game_Mgr.point += 1;
                Destroy(gameObject);
            }
        }
    }
    private void ArmorSeting()
    {
        if((int)Time.time >= timing)
        {
            timing += 2f;
            Armor += 0.01f;
        }
    }
    private void MoveMonster()
    {
        rd.velocity = Vector2.left * MonsterSpeed;
    }
    private void MonsterDeath()
    {
        if(CamResol.m_VpWMin.x - 0.5f > transform.position.x)
        {
            Destroy(gameObject);
        }
        if(Hero_Ctrl.CharacterHp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
