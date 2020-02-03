using UnityEngine;

public class EnemyHealth : MonoBehaviour
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
    private bool EnemyCanAttack;
    private Collider Playercol;
    private bool EnemyAttacking;

    private GameObject playerWeaponHitBox;

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

        playerWeaponHitBox = GameObject.Find("WeaponHitBox");
    }

    void Update()
    {

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

    public void SnackTime()
    {
        cooldown = 0f;
        Playercol.gameObject.GetComponent<Player>().DamagePlayer(damageDealt);
    }

    public void AudioNoise()
    {
        enemyMelee.Play();
    }
}