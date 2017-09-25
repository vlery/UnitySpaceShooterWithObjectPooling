using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cube;
public class CameraOrbit : MonoBehaviour
{
    //public Transform target;
    public float verticalmov = 90f;
    public float horizontalmov = 90f;
    Vector3 pivot;
    Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        //pivot = new Vector3(1,1,1)* grid.GetSize() * grid.GetOffset() * 0.5f;
       // pivot.x -=0.5f * grid.GetOffset();
        //pivot.z -= 0.5f * grid.GetOffset();
        //center.z += 0.5f * grid.GetOffset();
    }

    public void MoveVertical(bool left)
    {
        if (!left)
        {
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
                animator.SetTrigger("Rotate0-90");
            else if (animator.GetCurrentAnimatorStateInfo(0).IsName("Rotate0-90"))
                animator.SetTrigger("Rotate90-180");
            else if (animator.GetCurrentAnimatorStateInfo(0).IsName("Rotate90-180"))
                animator.SetTrigger("Rotate180-270");
            else if (animator.GetCurrentAnimatorStateInfo(0).IsName("Rotate180-270"))
                animator.SetTrigger("Rotate270-360");



            else if (animator.GetCurrentAnimatorStateInfo(0).IsName("Rotate90-0"))
                animator.SetTrigger("Rotate0-90");

            else if (animator.GetCurrentAnimatorStateInfo(0).IsName("Rotate180-90"))
                animator.SetTrigger("Rotate90-180");

            else if (animator.GetCurrentAnimatorStateInfo(0).IsName("Rotate270-180"))
                animator.SetTrigger("Rotate180-270");
            else if (animator.GetCurrentAnimatorStateInfo(0).IsName("Rotate360-270"))
                animator.SetTrigger("Rotate270-360");
        }
        else
        {
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
                animator.SetTrigger("Rotate360-270");
            else if (animator.GetCurrentAnimatorStateInfo(0).IsName("Rotate360-270"))
                animator.SetTrigger("Rotate270-180");
            else if (animator.GetCurrentAnimatorStateInfo(0).IsName("Rotate270-180"))
                animator.SetTrigger("Rotate180-90");
            else if (animator.GetCurrentAnimatorStateInfo(0).IsName("Rotate180-90"))
                animator.SetTrigger("Rotate90-0");


            else if (animator.GetCurrentAnimatorStateInfo(0).IsName("Rotate0-90"))
                animator.SetTrigger("Rotate90-0");

            else if (animator.GetCurrentAnimatorStateInfo(0).IsName("Rotate90-180"))
                animator.SetTrigger("Rotate180-90");

            else if (animator.GetCurrentAnimatorStateInfo(0).IsName("Rotate180-270"))
                animator.SetTrigger("Rotate270-180");
            else if (animator.GetCurrentAnimatorStateInfo(0).IsName("Rotate270-360"))
                animator.SetTrigger("Rotate360-270");
        }
        //float dir = 1;
        //if (!left)
        //    dir *= -1;
        //transform.RotateAround(pivot, Vector3.up, horizontalmov * dir);
    }
    public void MoveHorizontal(bool up)
    {
        //transform.RotateAround(pivot, transform.TransformDirection(Vector3.right), verticalmov);
    }

    public void UpdatePivot(int gridSize, float offset)
    {
        pivot = new Vector3(1, 1, 1) * gridSize * offset * 0.5f;
        pivot.x -= 0.5f * offset;
        pivot.z -= 0.5f * offset;
    }
}
