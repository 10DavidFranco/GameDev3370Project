using UnityEngine;


//Ideas left to implement:
//Instantiating plate on even trigger from attack animation
//SPawning bigger plates at faster frequencies when below half health.

public class schweller_script : MonoBehaviour
{
    public static float targetTime = 10.0f;
    private float targetTimecopy = targetTime;
    public float waitAfterAttack;
    public float timeOfAttack;
    private Animator anim_rs;
    public GameObject player;
    float attack_decider;
    public bool has_attacked;
    public bool onceflag = false;

    public Transform plateAttackPoint;
    public GameObject platePrefab;
    //public Transform treeAttackPoint;
    //public GameObject treePrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim_rs = GetComponent<Animator>();
        anim_rs.SetBool("is_attacking", false);
        has_attacked = false;
    }

    // Update is called once per frame
    void Update()
    {

        //Invoke("DetermineAttack", 2.0f);

        //anim_rs.Play("schweller_attack");
        //anim_rs.Play("schweller_idle");
        Attack();
    }

    

    void Attack()
    {
        Debug.Log("Decreasing time!!!");
        targetTime -= Time.deltaTime;
        Debug.Log(targetTime);
        if(targetTime <= 0.0f)
        {
            timerEnded();
            
        }
    }

    void timerEnded()
    {
        //float attackDecider;
        Debug.Log("Timer has ended!");
        anim_rs.SetBool("is_attacking", true);
        if (!onceflag)
        {

            if(targetTime <= timeOfAttack)
            {

                //attackDecider = Random.Range(0.1f, 10.0f);


                
                    GameObject plate = Instantiate(platePrefab, plateAttackPoint.position, plateAttackPoint.rotation);
                //fun idea to play with the tranform of the plate...
                //back up idea if the tree does not work: He will roll plates of various random sizes at you...
                    float scale = Random.Range(2.0f, 4.0f);
                    plate.transform.localScale = new Vector3(scale, scale, scale);
                    onceflag = true;
                
               
            }
            
        }
        
        if(targetTime <= waitAfterAttack)
        {
            timerReset();
        }
        
    }

    void timerReset()
    {
        targetTime = Random.Range(3.0f, 5.0f);
        anim_rs.SetBool("is_attacking", false);
        onceflag = false;
    }

    //void DetermineAttack()
    //{
    //    attack_decider = Random.Range(-10.0f, 10.0f);
    //    anim_rs.Play("schweller_attack");
    //    if (attack_decider <= 0.0f)
    //    {
    //        Debug.Log("Low attack");
    //        //anim_rs.Play("schweller_attack");
    //        //Invoke("AttackB", 2.0f);
    //        AttackB();
    //    }
    //    else
    //    {
    //        Debug.Log("High attack");
    //        //anim_rs.Play("schweller_attack");
    //        //Invoke("AttackA", 2.0f);
    //        AttackA();
    //    }

    //    anim_rs.Play("schweller_idle");
    //}

    //void AttackA()
    //{
    //    //anim_rs.SetBool("is_attacking", false);


    //}
    //void AttackB()
    //{
    //    //anim_rs.SetBool("is_attacking", false);
    //}
    //void CheckHit()
    //{

    //}
}
