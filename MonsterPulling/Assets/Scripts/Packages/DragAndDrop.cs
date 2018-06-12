using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour {

    public static DragAndDrop instance;
    public float distance;
    public float time;
    private RaycastHit hit;
    private Ray ray;
    public LayerMask layerMask;
    public float offsetObjectDrag;
    private Vector3 dragPosition;
    private Transform pickObject;
    public float distancePick;
    private GameObject packageObject;
    public bool isPickObject;
    public float distanceBetweenObjects;

    public List<Transform> packages = new List<Transform>();

    public LayerMask layerMaskDrop;
    public float distanceDrop;


    private void Awake()
    {
        instance = this;
        
    }
    private void Update()
    {
          ray = Camera.main.ScreenPointToRay(Input.mousePosition);
             if (Physics.Raycast(ray, out hit, distance, layerMask))
             {

                if (Input.GetMouseButtonDown(0))
                {
                    hit.rigidbody.isKinematic = true;
                //packageObject = hit.collider.gameObject;
                pickObject = hit.collider.gameObject.transform;
                pickObject.parent = transform;
                packages.Add(pickObject);
                for (int i = 0; i < packages.Count; i++)
                   {
                    switch (i)
                    {
                        case 0:
                            packages[i].localPosition = new Vector3(-0.26f, 0.16f, -0.086f);
                            break;

                        case 1:
                            packages[i].localPosition = new Vector3(0, 0.07f, -0.05f);
                            break;

                        case 2:
                            packages[i].localPosition = new Vector3(0.3f, 0.13f, -0.05f);
                            break;
                    }
                    
                        isPickObject = true;
                   }
                
                }
             }
            
        if (isPickObject)
        {
            Ray rayDrop = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitDrop;
            if (packages.Count -1 < 0)
            {
                isPickObject = false;
            }
            if (Physics.Raycast(rayDrop, out hitDrop, distanceDrop, layerMaskDrop))
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    
                    packages[packages.Count -1 ].parent = null;
                    packages[packages.Count -1].transform.position = hitDrop.point;
                    packages.RemoveAt(packages.Count - 1);
                    packages[packages.Count - 1].GetComponent<Rigidbody>().isKinematic = false;
                    
                    
                }
            }
        }
       
                
            
    }

}
