using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponController : MonoBehaviour
{

    public static WeaponController Instance;
    private RaycastHit hit;
    private GameObject hitObject;
    public Transform jointWeapon;
    public float distanceToDetect;

    public float forceShootting;
    public LayerMask layerMask;
    public Transform parentBullets;
    private string currentTag;

    private int ChargedBulletsCounter;
    public int limitChargedBullets;

    public Transform chargedBulletsContainer;
    public GameObject redImage, blueImage, yellowImage, greenImage, purpleImage;
    private int bulletBlue, bulletGreen, bulletYellow, bulletPurple, bulletRed;
    public List<GameObject> iconsChargedBullets = new List<GameObject>();

    private GameObject bulletPlaceholder;

    public List<GameObject> bulletsEnemy = new List<GameObject>();

    public List<GameObject> bulletsEnemyYellow = new List<GameObject>();
    public List<GameObject> bulletsEnemyRed = new List<GameObject>();
    public List<GameObject> bulletsEnemyPurple = new List<GameObject>();
    public List<GameObject> bulletsEnemyGreen = new List<GameObject>();
    public List<GameObject> bulletstEnemyBlue = new List<GameObject>();

    private void Awake()
    {
        Instance = this;
    }


    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, distanceToDetect, layerMask))
            {
                hitObject = hit.collider.gameObject;
                currentTag = hitObject.tag;
                Enemy enemy = hitObject.GetComponent<Enemy>();
                enemy.MoveToWeapon(hitObject);
                ChargedBulletsCounter = 0;
                bulletPlaceholder = GetFreeBulletEnemy();
                bulletsEnemy.Add(bulletPlaceholder);
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            
            if (bulletsEnemy.Count > 0)
            {

                
                PrepareBulletEnemy(bulletsEnemy[bulletsEnemy.Count - 1]);

                switch (bulletsEnemy[bulletsEnemy.Count -1].gameObject.tag)
                {
                    case "BlueBullet":


                        iconsChargedBullets.Remove(blueImage);
                        blueImage.SetActive(false);
                        blueImage.transform.SetParent(null);



                        break;
                    case "YellowBullet":


                        iconsChargedBullets.Remove(yellowImage);
                        yellowImage.SetActive(false);
                        yellowImage.transform.SetParent(null);


                        break;
                    case "RedBullet":


                        iconsChargedBullets.Remove(redImage);
                        redImage.SetActive(false);
                        redImage.transform.SetParent(null);


                        break;
                    case "PurpleBullet":


                        iconsChargedBullets.Remove(purpleImage);
                        purpleImage.SetActive(false);
                        purpleImage.transform.SetParent(null);


                        break;
                    case "GreenBullet":


                        iconsChargedBullets.Remove(greenImage);
                        greenImage.SetActive(false);
                        greenImage.transform.SetParent(null);


                        break;
                }

                bulletsEnemy.RemoveAt(bulletsEnemy.Count - 1);
            }
        }
    }

    public GameObject GetFreeBulletEnemy()
    {
       
        switch (currentTag)
        {
            case "Blue":
                for (int i = 0; i < bulletstEnemyBlue.Count; i++)
                {
                    if (bulletstEnemyBlue[i].activeSelf == false)
                    {
                        return bulletstEnemyBlue[i];
                    }
                }
                break;
            case "Green":
                for (int i = 0; i < bulletsEnemyGreen.Count; i++)
                {
                    if (bulletsEnemyGreen[i].activeSelf == false)
                    {
                        return bulletsEnemyGreen[i];
                    }
                }
                break;
            case "Purple":
                for (int i = 0; i < bulletsEnemyPurple.Count; i++)
                {
                    if (bulletsEnemyPurple[i].activeSelf == false)
                    {
                        return bulletsEnemyPurple[i];
                    }
                }
                break;
            case "Red":
                for (int i = 0; i < bulletsEnemyRed.Count; i++)
                {
                    if (bulletsEnemyRed[i].activeSelf == false)
                    {
                        return bulletsEnemyRed[i];
                    }
                }
                break;
            case "Yellow":
                for (int i = 0; i < bulletsEnemyYellow.Count; i++)
                {
                    if (bulletsEnemyYellow[i].activeSelf == false)
                    {
                        return bulletsEnemyYellow[i];
                    }
                }
                break;
        }
        return null;
    }

    private void PrepareBulletEnemy(GameObject obj)
    {
        if (obj != null)
        {
            obj.transform.position = jointWeapon.position;
            obj.transform.forward = jointWeapon.transform.forward;
            obj.SetActive(true);
        }
    }

    public void ChargedBulletUI(GameObject obj)
    {
        switch (obj.tag)
        {
            case "Blue":
                bulletBlue++;
                iconsChargedBullets.Add(blueImage);
                blueImage.SetActive(true);
                blueImage.transform.SetParent(chargedBulletsContainer);
                break;
            case "Yellow":
                bulletYellow++;
                iconsChargedBullets.Add(yellowImage);
                yellowImage.SetActive(true);
                yellowImage.transform.SetParent(chargedBulletsContainer);
                break;
            case "Red":
                bulletRed++;
                iconsChargedBullets.Add(redImage);
                redImage.SetActive(true);
                redImage.transform.SetParent(chargedBulletsContainer);
                break;
            case "Purple":
                bulletPurple++;
                iconsChargedBullets.Add(purpleImage);
                purpleImage.SetActive(true);
                purpleImage.transform.SetParent(chargedBulletsContainer);
                break;
            case "Green":
                bulletGreen++;
                iconsChargedBullets.Add(greenImage);
                greenImage.SetActive(true);
                greenImage.transform.SetParent(chargedBulletsContainer);
                break;
        }
    }
}
