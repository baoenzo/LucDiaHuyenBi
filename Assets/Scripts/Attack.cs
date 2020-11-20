using Assets.HeroEditor.Common.CharacterScripts;
using HeroEditor.Common.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Attack : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject hitBox;

    public Character Character;
    public Transform ArmL;
    public Transform ArmR;
    public Button FireButton;
    public Button ReloadButton;
    public bool FixHorizontal;

    private bool _locked;

    void Start()
    {
        hitBox.SetActive(false);
        FireButton.onClick.AddListener(Attack_Event);
    }

    void Update()
    {
        // Dùng để đấm vào mỏ từng thằng
        AttackEnemy();

    }
    IEnumerator DoAttack()
    {
        hitBox.SetActive(true);
        yield return new WaitForSeconds(.1f);
        hitBox.SetActive(false);
    }
    private void LateUpdate()
    {
        // Cập nhật từng khung hình    
        FrameUpdate();
    }

    #region Attack Animation
    private void FrameUpdate()
    {
        if (_locked) return;

        Transform arm;
        Transform weapon;

        switch (Character.WeaponType)
        {
            case WeaponType.Bow:
                arm = ArmL;
                weapon = Character.BowRenderers[3].transform;
                break;
            case WeaponType.Firearms1H:
            case WeaponType.Firearms2H:
                arm = ArmR;
                weapon = Character.Firearm.FireTransform;
                break;
            default:
                return;
        }

        RotateArm(arm, weapon, FixHorizontal ? arm.position + 1000 * Vector3.right : Camera.main.ScreenToWorldPoint(Input.mousePosition), -40, 40);
    }

    private void AttackEnemy()
    {
        _locked = !Character.Animator.GetBool("Ready") || Character.Animator.GetInteger("Dead") > 0;

        if (_locked) return;

        switch (Character.WeaponType)
        {
            case WeaponType.Melee1H:
            case WeaponType.Melee2H:
            case WeaponType.MeleePaired:
                FireButton.onClick.AddListener(() =>
                {
                    Character.Animator.SetTrigger(Time.frameCount % 2 == 0 ? "Slash" : "Jab"); // Play animation randomly
                });
                break;
            case WeaponType.Bow:
                Character.BowShooting.ChargeButtonDown = FireButton;
                Character.BowShooting.ChargeButtonUp = FireButton;
                break;
            case WeaponType.Firearms1H:
            case WeaponType.Firearms2H:
                Character.Firearm.Fire.FireButtonDown = FireButton;
                Character.Firearm.Fire.FireButtonPressed = FireButton;
                Character.Firearm.Fire.FireButtonUp = FireButton;
                Character.Firearm.Reload.ReloadButtonDown = ReloadButton;
                break;
            case WeaponType.Supplies:
                FireButton.onClick.AddListener(() =>
                {
                    Character.Animator.Play(Time.frameCount % 2 == 0 ? "UseSupply" : "ThrowSupply", 0);// Play animation randomly
                });
                break;
        }
    }
    public void RotateArm(Transform arm, Transform weapon, Vector2 target, float angleMin, float angleMax) // TODO: Very hard to understand logic
    {
        target = arm.transform.InverseTransformPoint(target);

        var angleToTarget = Vector2.SignedAngle(Vector2.right, target);
        var angleToFirearm = Vector2.SignedAngle(weapon.right, arm.transform.right) * Math.Sign(weapon.lossyScale.x);
        var angleFix = Mathf.Asin(weapon.InverseTransformPoint(arm.transform.position).y / target.magnitude) * Mathf.Rad2Deg;
        var angle = angleToTarget + angleToFirearm + angleFix;

        angleMin += angleToFirearm;
        angleMax += angleToFirearm;

        var z = arm.transform.localEulerAngles.z;

        if (z > 180) z -= 360;

        if (z + angle > angleMax)
        {
            angle = angleMax;
        }
        else if (z + angle < angleMin)
        {
            angle = angleMin;
        }
        else
        {
            angle += z;
        }

        arm.transform.localEulerAngles = new Vector3(0, 0, angle);
    }
    #endregion

    #region Method


    #endregion

    #region Event
    private void Attack_Event()
    {
       // isAttacking = true;
        StartCoroutine(DoAttack());
    }

    #endregion
}
