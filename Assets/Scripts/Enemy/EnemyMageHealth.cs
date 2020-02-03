using UnityEngine;

public class EnemyMageHealth : MonoBehaviour
{

    //private CharacterControl ccRef;
    public float maxHealth = 15;                    // The amount of health the enemy starts the game with.
    public float currentHealth;
    public float fireballDamage = 8;
    public float damageTaken = 5;
    public float maxDistance = 10;
    public int damageDealt = 1;
    public float cooldown;
    public float distance;
    public GameObject holder;
    public GameObject player;
    private TriggerSpawn triggerSpawn;
    private Animator playerAnimator;
    public Animator animate;
    public bool isDead;                             //Checks whether the enemy is Dead
    public bool isDamaged;
    public bool stupidboolname;
    public bool johnCena;
    public BoxCollider boxCollider;

    private AudioSource enemyWalking;
    private AudioSource enemyHit;
    private AudioSource enemyMelee;
    private AudioSource enemyDeath;

    private bool playdead;
    private bool collided;
    private bool Enemycollided;
    private float hittimer;
    private float Cenatimer;
    private float Watcher;
    private bool EnemyCanAttack;
    private Collider Playercol;
    private bool EnemyAttacking;

    void Awake()
    {
        animate = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider>();

        currentHealth = maxHealth;
    }

    void Start()
    {
        holder = GameObject.Find("TrialOfStrength");
        triggerSpawn = holder.GetComponent<TriggerSpawn>();
        player = GameObject.FindWithTag("Player");
        playerAnimator = player.GetComponent<Animator>();

        enemyDeath = GameObject.Find("EnemyDeath").GetComponent<AudioSource>();
        enemyMelee = GameObject.Find("EnemyMelee").GetComponent<AudioSource>();
        enemyHit = GameObject.Find("EnemyHit").GetComponent<AudioSource>();
        enemyWalking = GameObject.Find("EnemyWalking").GetComponent<AudioSource>();

        playdead = true;
        EnemyCanAttack = false;
        Playercol = player.GetComponent<CapsuleCollider>();
    }

    void Update()
    {
        /*
        if (johnCena)
        {
            animate.SetBool("TakingHit", true);
            johnCena = false;

            //enemyWalking.Stop();
            enemyHit.Play();
        }
        else if (animate.GetBool("TakingHit") && johnCena == false)
        {
            Debug.Log("It reached");
            animate.SetBool("TakingHit", false);
        }

        cooldown += Time.deltaTime;

        transform.LookAt(player.transform);
        distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance > maxDistance)
        {
            animate.SetBool("Idle", false);
            animate.SetBool("Movement", true);
            transform.position += transform.forward * 5 * Time.deltaTime;

            if (!enemyWalking.isPlaying)
            {
                //enemyWalking.Play();
            }

        }

        else if (distance <= maxDistance)
        {
            if (cooldown >= 3f)
            {
                Debug.Log("Attack Cooldown: " + cooldown);

                animate.SetBool("Idle", false);
                animate.SetBool("Movement", false);
                animate.SetBool("Attack", true);

                //enemyWalking.Stop();
                enemyMelee.Play();
                cooldown = 0f;
            }
            if (cooldown > 1f && cooldown < 3f)
            {
                animate.SetBool("Attack", false);
            }
        }

        if (currentHealth <= 0 && playdead)
        {
            enemyDeath.Play();
            animate.Play("Die");
            Invoke("Dead", 2.0f);
            playdead = false;
        }
        */

        if (johnCena && currentHealth > 0)
        {
            animate.SetBool("TakingHit", true);
            animate.SetBool("Attack", false);

            enemyWalking.Stop();
            enemyHit.Play();
            cooldown = 0f;
        }
        else if (currentHealth <= 0 && playdead)
        {
            enemyDeath.Play();
            animate.Play("Die");
            Invoke("Dead", 2.0f);
            playdead = false;
        }


        if (johnCena)//set a timer for cena
        {
            Cenatimer += Time.deltaTime;
        }

        if (johnCena && Cenatimer > 1f)
        {
            johnCena = false;
            Cenatimer = 0f;
        }

        if (animate.GetBool("TakingHit") && johnCena == false)
        {
            animate.SetBool("TakingHit", false);
        }

        transform.LookAt(player.transform);
        distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance < maxDistance && playdead && !johnCena && !animate.GetBool("Attack")) // move enemy towar player
        {
            animate.SetBool("Idle", false);
            animate.SetBool("Movement", true);

            transform.position -= transform.forward * 8 * Time.deltaTime;
            EnemyCanAttack = false;
            if (!enemyWalking.isPlaying)
            {
                enemyWalking.Play();
            }
            Debug.Log("Running");
        }
        else if (distance >= maxDistance)//moved attacking down
        {
            EnemyCanAttack = true;
            Debug.Log("Attacking");

        }
        EnemyCanAttack = true;

        //else { }

        if (collided)  //added these 2 iff statements for a timer to only allow hits every .9 seconds
        {
            hittimer += Time.deltaTime;
        }

        if (collided && hittimer > .85f)
        {
            collided = false;
            hittimer = 0f;
        }

        if (Enemycollided && !johnCena)//added these 2 if statements for a timer to only allow attacks every .9 seconds
        {
            cooldown += Time.deltaTime;
        }
        if (Enemycollided && cooldown > 2f)
        {
            Enemycollided = false;
            cooldown = 0f;
           //animate.SetBool("Attack", false);

        }
        if (animate.GetBool("Attack"))  //next three if statements check if the attack animation bool is borken or frozen and sets them to false.
        {
            Watcher += Time.deltaTime;
        }
        if (!animate.GetBool("Attack"))
        {
            Watcher = 0f;
        }        
        if (animate.GetBool("Attack") && Watcher > 1.3f)
        {
            animate.SetBool("Attack", false);
            Watcher = 0f;
        }

        if (!Enemycollided && EnemyCanAttack && !johnCena && playdead) //enemy hasnt collided but is in range and hasnt been hit
        {
            Enemycollided = true;
            animate.SetBool("Idle", false);
            animate.SetBool("Movement", false);
            animate.SetBool("Attack", true);

            enemyMelee.Play();
            cooldown = 0f;
            //Playercol.gameObject.GetComponent<Player>().DamagePlayer(damageDealt);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        /*
        Debug.Log("Running here " + other);
        if (other.gameObject.tag == "Weapon" && playerAnimator.GetInteger("AttackValue") == 1 ||
            other.gameObject.tag == "Weapon" && playerAnimator.GetInteger("AttackValue") == 2 ||
            other.gameObject.tag == "Weapon" && playerAnimator.GetInteger("AttackValue") == 3)
        {

            currentHealth -= damageTaken;
            johnCena = true;
            animate.SetBool("Attack", false);

            Debug.Log("Hit By:" + other.gameObject.name);

            other.gameObject.GetComponent<AudioSource>().Play();
        }

        else if (other.gameObject.GetComponent<FireballMovement>() != null)
        {
            //Debug.Log(currentHealth);
            currentHealth -= fireballDamage;
            animate.SetBool("Attack", false);
            johnCena = true;

        }

        else if (other.gameObject.tag == "Player" && animate.GetBool("Attack"))
        {
            other.gameObject.GetComponent<Player>().DamagePlayer(damageDealt);
        }
        */

        if (other.gameObject.CompareTag("Weapon") && playerAnimator.GetInteger("AttackValue") == 1 ||
            other.gameObject.CompareTag("Weapon") && playerAnimator.GetInteger("AttackValue") == 2 ||
            other.gameObject.CompareTag("Weapon") && playerAnimator.GetInteger("AttackValue") == 3)
        {
            if (!collided) // added this if statement to only allow hit every .9 second
            {
                collided = true;
                johnCena = true;
                animate.SetBool("Attack", false);
                currentHealth -= damageTaken;
                other.gameObject.GetComponent<AudioSource>().Play();
                Debug.Log("Hit By:" + other.gameObject.name + "Current HP = " + currentHealth);
            }
        }

        else if (other.gameObject.GetComponent<FireballMovement>() != null)
        {
            currentHealth -= fireballDamage;
            //animate.SetBool("Attack", false);
            johnCena = true;
        }
    }

    void Dead()
    {
        triggerSpawn.permanentSleep = true;
        Destroy(gameObject);
    }

    void stopanim()
    {
        animate.SetBool("Attack", false);
        animate.SetBool("Idle", true);

    }
}