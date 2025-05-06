using UnityEngine;

public class weapon : MonoBehaviour
{
    public Transform firepoint;
    public GameObject bulletPrefab;
    Animator animator;

    void Start()
    {
       animator = GetComponent<Animator>();     
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            animator.SetBool("isAttacking",true);
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
    }

    public void endAttack()
    {
        animator.SetBool("isAttacking",false);
    }

}
