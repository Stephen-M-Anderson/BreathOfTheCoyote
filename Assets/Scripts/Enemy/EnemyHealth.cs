using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    //private CharacterControl ccRef;
    public float maxHealth = 15;                    // The amount of health the enemy starts the game with.
    public float currentHealth;                     //Also all damage variables
    public float fireballDamage = 8;
    public float damageTaken = 5;
    public float maxDistance = 10;
    public int damageDealt = 1;
    public float cooldown;
    public float distance;
    public GameObject holder; // This is specifically for when it enters 
    public GameObject player;
    private TriggerSpawn triggerSpawn;
    private Animator playerAnimator;
    public Animator animate;
    public bool isDead;                             //Checks whether the enemy is Dead
    public bool isDamaged;  //Checks to see if player is hit and then they must be damaged
    public bool stupidboolname;
    public bool johnCena; //This bool is literally jsut a bool that was added so that we can use it for a timer between actions. 
    public BoxCollider boxCollider;

    //All of this is our different audio stuff
    private AudioSource enemyWalking;
    private AudioSource enemyHit;
    private AudioSource enemyMelee;
    private AudioSource enemyDeath;
    private bool playdead;
    private bool collided;
    private bool Enemycollided;
    private float hittimer; // Currently we have an issue with having melee hit multiple times, this timer is to make sure it only hits once 
    private float Cenatimer;
    private bool EnemyCanAttack; //Cooldown for enemy attack
    private Collider Playercol;
    private bool EnemyAttacking;

    private GameObject playerWeaponHitBox;

    //starting up grabbing animator, collider and setting currenthealth
    void Awake()
    {
        animate = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider>();

        currentHealth = maxHealth;
    }

    //grabbing and prepping all variables for audio, triggers, and colliders
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

        playerWeaponHitBox = GameObject.Find("WeaponHitBox");
    }

    void Update()
    {
        //runs if enemy is hit by any damaging ability
        if (johnCena && currentHealth > 0)
        {
            animate.SetBool("TakingHit", true);
            animate.SetBool("Attack", false);

            enemyWalking.Stop();
            enemyHit.Play();
            cooldown = 0f;
        }
        //runs when enemy dies
        else if (currentHealth <= 0 && playdead)
        {
            enemyDeath.Play();
            animate.Play("Die");
            Invoke("Dead", 2.0f);
            playdead = false;
        }

        //this timer is to make sure enemy only takes damage once
        if (johnCena)//set a timer for cena
        {
            Cenatimer += Time.deltaTime;
        }

        if (johnCena && Cenatimer > 1f)
        {
            johnCena = false;
            Cenatimer = 0f;
        }
        //sets animations back to false
        if (animate.GetBool("TakingHit") && johnCena == false)
        {
            animate.SetBool("TakingHit", false);
        }
        
        
        //This portion is basic animation and movement stuff for enemies to move towards player
        transform.LookAt(player.transform);
        distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance > maxDistance && playdead) // move enemy towar player
        {
            animate.SetBool("Idle", false);
            animate.SetBool("Movement", true);
            animate.SetBool("Attack", false);

            transform.position += transform.forward * 5 * Time.deltaTime;
            EnemyCanAttack = false;
            if (!enemyWalking.isPlaying)
            {
                enemyWalking.Play();
            }

        }
        //If player is in range
        else if (distance <= maxDistance)//moved attacking down
        {
            EnemyCanAttack = true;
        }
        
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
        }

        if (!Enemycollided && EnemyCanAttack && !johnCena && playdead) //enemy hasnt collided but is in range and hasnt been hit
        {
            Enemycollided = true;
            animate.SetBool("Idle", false);
            animate.SetBool("Movement", false);
            animate.SetBool("Attack", true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
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
                //Debug.Log("Hit By:" + other.gameObject.name + "Current HP = " + currentHealth);
            }
        }

        else if (other.gameObject.GetComponent<FireballMovement>() != null)
        {
            currentHealth -= fireballDamage;
            animate.SetBool("Attack", false);
            johnCena = true;
        }
    }

    void Dead()
    {
        triggerSpawn.permanentSleep = true;
        Destroy(gameObject);
    }
    //More explanation this is for if enemy damages player
    public void SnackTime()
    {
        cooldown = 0f;
        Playercol.gameObject.GetComponent<Player>().DamagePlayer(damageDealt);
    }
    //audio for enemy attacking
    public void AudioNoise()
    {
        enemyMelee.Play();
    }
}