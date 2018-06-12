using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public enum ColorEnemy {red, yellow, purple, blue, green};
    public ColorEnemy colorEnemy;
    public float timeToPull;
    public float timeToCombinate;
    public AnimationCurve animationCurve;
    private Rigidbody rb;
    private string myTag;

    private int collisionsCounter;
    private GameObject thisObj;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    

    public void MoveToWeapon(GameObject obj)
    {
        thisObj = obj;
        if (thisObj == this.gameObject)
        {
            MoveToWeaponTween();
        }
    }

    

    private void MoveToWeaponTween()
    {
        if (collisionsCounter <= 1)
        {
            Vector3 startPos = transform.position;
            Vector3 endPos = WeaponController.Instance.jointWeapon.position;
            Vector3 startScale = transform.localScale = new Vector3(1, 1, 1);
            Vector3 endScale = transform.localScale = Vector3.zero;
            TweenController.Tween(gameObject, "enemy", false, 0, 1, timeToPull, (tween) => {
                Vector3 pos = Vector3.Lerp(startPos, endPos, tween.progress);
                Vector3 scale = Vector3.Lerp(startScale, endScale, tween.progress);
                transform.position = pos;
                transform.localScale = scale;
            }, (tween)=> {
                WeaponController.Instance.ChargedBulletUI(thisObj);
            });
        }
    }

    private void CombinateScale()
    {
        Vector3 startScale = transform.localScale;
        Vector3 endScale = Vector3.one * 2;
        TweenController.Tween(gameObject, "CombinateScale", false, 0, 1, timeToCombinate, (tween) => {
            Vector3 scale = Vector3.Lerp(startScale, endScale, animationCurve.Evaluate(tween.progress));
            transform.localScale = scale;
        });
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag(gameObject.tag + "Bullet"))
        {
            collisionsCounter++;
            if (collisionsCounter < 2)
            {
                CombinateScale();
                other.gameObject.SetActive(false);
                collisionsCounter++;
            }
            else
            {
                other.gameObject.SetActive(false);
                Destroy(gameObject);
            }
        }
    }

}
