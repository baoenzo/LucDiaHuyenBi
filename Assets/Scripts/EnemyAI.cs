using Assets.HeroEditor.Common.CharacterScripts;
using HeroEditor.Common.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyAI : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public GameObject cha;
    private Transform target;
    Character character;
    Rigidbody2D rb;

    public BoxCollider2D boxEnemy;
    private BoxCollider2D boxPlayer;

    public Character Character;
    public Transform ArmL;
    public Transform ArmR;
    public bool FixHorizontal;

    private bool _locked ,isPlayer;
    void Start()
    {

        target = cha.GetComponent<Transform>();
        character = GetComponent<Character>();
        rb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        boxPlayer = rb.GetComponentInChildren<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        FollowCharacter();
        float x = rb.transform.localPosition.x;
        Flip(x);
        AutoAttackPlayer();
    }

    // Kẻ địch tự động đuổi theo người chơi
    private void FollowCharacter()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        if (!rb.IsSleeping())
        {
            character.Animator.SetBool("Run", true);
        }
        else
        {
            character.Animator.SetBool("Run", true);
        }
    }
    private void Flip(float x)
    {
        transform.localScale = new Vector3(-1, 1, 0);
        if(x > 8)
        {
            transform.localScale = new Vector3(1, 1, 0);
        }
    }

    private void AutoAttackPlayer()
    {
        isPlayer = true;
        if (boxEnemy.bounds.Intersects(boxPlayer.bounds))
        {
           
            AttackPlayer(isPlayer);
        }
        else
        {
            isPlayer = false;
        }
    }

    #region Attack Animation


    private void AttackPlayer(bool isPlayer)
    {
        _locked = !Character.Animator.GetBool("Ready") || Character.Animator.GetInteger("Dead") > 0;

        if (_locked) return;

        switch (Character.WeaponType)
        {
            case WeaponType.Melee1H:
            case WeaponType.Melee2H:
            case WeaponType.MeleePaired:
                if (isPlayer)
                {
                    Character.Animator.SetTrigger(Time.frameCount % 2 == 0 ? "Slash" : "Jab"); // Play animation randomly
                }
                break;
            //case WeaponType.Bow:
            //    Character.BowShooting.ChargeButtonDown = FireButton;
            //    Character.BowShooting.ChargeButtonUp = FireButton;
            //    break;
            //case WeaponType.Firearms1H:
            //case WeaponType.Firearms2H:
            //    Character.Firearm.Fire.FireButtonDown = FireButton;
            //    Character.Firearm.Fire.FireButtonPressed = FireButton;
            //    Character.Firearm.Fire.FireButtonUp = FireButton;
            //    Character.Firearm.Reload.ReloadButtonDown = ReloadButton;
            //    break;
            case WeaponType.Supplies:
                if (isPlayer)
                { 
                    Character.Animator.Play(Time.frameCount % 2 == 0 ? "UseSupply" : "ThrowSupply", 0);// Play animation randomly
                }
                break;
        }
    }

    #endregion
}
