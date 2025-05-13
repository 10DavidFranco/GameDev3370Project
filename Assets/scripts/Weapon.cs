using UnityEngine;

public class weapon : MonoBehaviour
{
    public Transform firepoint;
    public GameObject bulletPrefab;
    Animator animator;
    AudioSource AudioSource;
    void Start()
    {
       animator = GetComponent<Animator>();     
        AudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            animator.SetBool("isAttacking",true);
            Shoot();
            AudioSource.Play();
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
