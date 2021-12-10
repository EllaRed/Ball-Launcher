using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BallHandler : MonoBehaviour
{
    // Start is called before the first frame update
    private Camera maincamera;
    public float detachtime;
    private bool isDragging;
    [SerializeField] private Rigidbody2D currentballRigidbody;
    [SerializeField] private SpringJoint2D currentballSpringjoint;
    void Start()
    {
        maincamera= Camera.main;
        detachtime=2f;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentballRigidbody!=null)
        {
            
        
        if (Touchscreen.current.primaryTouch.press.IsPressed())
        {   currentballRigidbody.isKinematic= true;
            isDragging=true;
        
            Vector2 touchpoint= Touchscreen.current.primaryTouch.position.ReadValue();
            Vector3 worldtouchpoint= maincamera.ScreenToWorldPoint(touchpoint);
            currentballRigidbody.isKinematic=true;
            currentballRigidbody.position= worldtouchpoint;
            
        }else
        {
            currentballRigidbody.isKinematic= false;
            if(isDragging)
            {
            LaunchBall();
            isDragging=false;
            }
            

        }
    }
        
    }
    

    private void LaunchBall()
    {
        currentballRigidbody.isKinematic=false;
        currentballRigidbody=null;
        Invoke ("DetachBall", detachtime);
    }

    private void DetachBall(){
        currentballSpringjoint.enabled=false;
        currentballSpringjoint=null;
    }
}
