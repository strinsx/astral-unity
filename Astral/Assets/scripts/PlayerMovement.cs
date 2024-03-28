/*
	Created by @DawnosaurDev at youtube.com/c/DawnosaurStudios
	Thanks so much for checking this out and I hope you find it helpful! 
	If you have any further queries, questions or feedback feel free to reach out on my twitter or leave a comment on youtube :D

	Feel free to use this in your own games, and I'd love to see anything you make!
 */

using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Scriptable object which holds all the player's movement parameters. If you don't want to use it
    //just paste in all the parameters, though you will need to manuly change all references in this script

    //HOW TO: to add the scriptable object, right-click in the project window -> create -> Player Data
    //Next, drag it into the slot in playerMovement on your player

    public PlayerData Data;

    #region Variables
    //Components
    public Rigidbody2D RB { get; private set; }

    //Variables control the various actions the player can perform at any time.
    //These are fields which can are public allowing for other sctipts to read them
    //but can only be privately written to.
    public bool IsFacingRight { get; private set; }
    private bool isSkillKeyPressed;
    public bool IsJumping { get; private set; }
    public bool IsWallJumping { get; private set; }
    public bool IsSliding { get; private set; }
    private bool isGrounded;
    public Animator animator;
    private bool isTouchingWall;
    //Timers (also all fields, could be private and a method returning a bool could be used)
    public float LastOnGroundTime { get; private set; }
    public float LastOnWallTime { get; private set; }
    public float LastOnWallRightTime { get; private set; }
    public float LastOnWallLeftTime { get; private set; }

    //Jump
    private bool _isJumpCut;
    private bool _isJumpFalling;
    private bool wasGrounded;

    //Wall Jump
    private float _wallJumpStartTime;
    private int _lastWallJumpDir;
    private bool isTouchingtheWalls;
    private Vector2 _moveInput;
    private float _moveInputFloat;
    public ParticleSystem dust;
    public ParticleSystem onLand;
    public bool canDoubleJump;
    public float LastPressedJumpTime { get; private set; }

    //Dash 
    public float dashSpeed;
    public float dashTime;
    public float startDash;
    public float dashEnergyCost;
    private int direction;
    public EnergyBar energyBar;
    

    private AudioSource audioSource;

    //Set all of these up in the inspector
    [Header("Checks")]
    [SerializeField] private AudioClip jumnpSoundClip;
    [SerializeField] private AudioClip landSoundsClip;
    [SerializeField] private AudioClip dashSoundClip;


    [SerializeField] private Transform _groundCheckPoint;
    //Size of groundCheck depends on the size of your character generally you want them slightly small than width (for ground) and height (for the wall check)
    [SerializeField] private Vector2 _groundCheckSize = new Vector2(0.49f, 0.03f);
    [Space(5)]
    [SerializeField] private Transform _frontWallCheckPoint;
    [SerializeField] private Transform _backWallCheckPoint;
    [SerializeField] private Vector2 _wallCheckSize = new Vector2(0.5f, 1f);

    [Header("Layers & Tags")]
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private LayerMask _wallLayer;

    #endregion

    private void Awake()
    {
        RB = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        SetGravityScale(Data.gravityScale);
        IsFacingRight = true;
        audioSource = GetComponent<AudioSource>();
        dashTime = startDash;
    }

    private void Update()
    {


        if(isSkillKeyPressed)
        {
            _moveInput = Vector2.zero;


        }
        else
        {

            #region TIMERS
            LastOnGroundTime -= Time.deltaTime;
            LastOnWallTime -= Time.deltaTime;
            LastOnWallRightTime -= Time.deltaTime;
            LastOnWallLeftTime -= Time.deltaTime;
            wasCheck();
            LastPressedJumpTime -= Time.deltaTime;
            #endregion

            #region INPUT HANDLER
            _moveInput.x = Input.GetAxisRaw("Horizontal");
            _moveInput.y = Input.GetAxisRaw("Vertical");

        }

      

        Grounded();


        #region FALLING ANIMATION OPTIMIZED - Rafales
        // Check if the character is falling
        if (!Physics2D.OverlapBox(_groundCheckPoint.position, _groundCheckSize, 0, _groundLayer) &&
     RB.velocity.y < 0 || isTouchingWall)
        {
            // Trigger the falling animation
            animator.SetBool("isFalling", true);
            animator.SetBool("isJumping", false);
            OnLandParticle();
        }
  



        else if (!IsJumping && !IsWallJumping)
        {
            // Reset the falling animation trigger if not falling
            animator.SetBool("isFalling", false);
        }




        #endregion



        if (_moveInput.x != 0)
            CheckDirectionToFace(_moveInput.x > 0);

        if ( Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.J))
        {
            OnJumpInput();

        }

        if (Input.GetKeyUp(KeyCode.I) || Input.GetKeyUp(KeyCode.O) || Input.GetKeyUp(KeyCode.P))
        {
            OnJumpUpInput();
        }


        #endregion

        #region COLLISION CHECKS
        if (!IsJumping)
        {
            //Ground Check
            if (Physics2D.OverlapBox(_groundCheckPoint.position, _groundCheckSize, 0, _groundLayer) && !IsJumping) //checks if set box overlaps with ground
            {

               

                LastOnGroundTime = Data.coyoteTime; //if so sets the lastff to coyoteTime

            }

            //Left Wall Check
            if (((Physics2D.OverlapBox(_frontWallCheckPoint.position, _wallCheckSize, 0, _wallLayer) && IsFacingRight)
                    || (Physics2D.OverlapBox(_backWallCheckPoint.position, _wallCheckSize, 0, _wallLayer) && !IsFacingRight)) && !IsWallJumping)
                LastOnWallRightTime = Data.coyoteTime;

            //Right Wall Check
            if (((Physics2D.OverlapBox(_frontWallCheckPoint.position, _wallCheckSize, 0, _wallLayer) && !IsFacingRight)
                || (Physics2D.OverlapBox(_backWallCheckPoint.position, _wallCheckSize, 0, _wallLayer) && IsFacingRight)) && !IsWallJumping)
                LastOnWallLeftTime = Data.coyoteTime;

            //Two checks needed for both left and right walls since whenever the play turns the wall checkPoints swap sides
            LastOnWallTime = Mathf.Max(LastOnWallLeftTime, LastOnWallRightTime);
        }




        if (Mathf.Abs(_moveInput.x) > 0 && Physics2D.OverlapBox(_groundCheckPoint.position, _groundCheckSize, 0, _groundLayer) != null)
        {
            animator.SetBool("isRunning", true);
            if(!audioSource.isPlaying && !IsJumping && !IsWallJumping && !IsSliding)
            {
                audioSource.Play();
            }
        }
        else
        {
            animator.SetBool("isRunning", false);
            if (audioSource.isPlaying && !IsJumping && !IsWallJumping && !IsSliding)
            {
                audioSource.Stop();
            }
        }


        #endregion

        #region DASH

        if(Input.GetKeyDown(KeyCode.Q) && Time.time >= startDash) 
        {
            direction = IsFacingRight ? 1 : -1;
            StartCoroutine(Dash());
        }


        #endregion

        #region JUMP CHECKS
        if (IsJumping && RB.velocity.y < 0)
        {
            if (!Physics2D.OverlapBox(_groundCheckPoint.position, _groundCheckSize, 0, _groundLayer))
            {
                IsJumping = false;
                if (!IsWallJumping)
                    _isJumpFalling = true;
                    Debug.Log("Onland");
            }
        }

        if (IsWallJumping && Time.time - _wallJumpStartTime > Data.wallJumpTime)
        {
            IsWallJumping = false;

        }

        if (LastOnGroundTime > 0 && !IsJumping && !IsWallJumping)
        {
            _isJumpCut = false;
            if (!IsJumping)
                _isJumpFalling = false;



        }

        //Jump
        if (CanJump() && LastPressedJumpTime > 0)
        {
            IsJumping = true;
            IsWallJumping = false;

            // 
            _isJumpCut = false;
            _isJumpFalling = false;
            Jump();
            animator.SetBool("isJumping", true);
            SoundEffectManager.instance.JumpClip(jumnpSoundClip, transform, 1f);
        }
        #endregion



        #region SLIDE CHECKS
        if (CanSlide() && ((LastOnWallLeftTime > 0 && _moveInput.x < 0) || (LastOnWallRightTime > 0 && _moveInput.x > 0)))
        {
            IsSliding = true;
            animator.SetBool("isFalling", true);
        }
        else
            IsSliding = false;
        #endregion

        #region GRAVITY
        //Higher gravity if we've released the jump input or are falling
        if (IsSliding)
        {
            SetGravityScale(0);
        }
        else if (RB.velocity.y < 0 && _moveInput.y < 0)
        {
            //Much higher gravity if holding down
            SetGravityScale(Data.gravityScale * Data.fastFallGravityMult);
            //Caps maximum fall speed, so when falling over large distances we don't accelerate to insanely high speeds
            RB.velocity = new Vector2(RB.velocity.x, Mathf.Max(RB.velocity.y, -Data.maxFastFallSpeed));
        }
        else if (_isJumpCut)
        {
            //Higher gravity if jump button released
            SetGravityScale(Data.gravityScale * Data.jumpCutGravityMult);
            RB.velocity = new Vector2(RB.velocity.x, Mathf.Max(RB.velocity.y, -Data.maxFallSpeed));
        }
        else if ((IsJumping || IsWallJumping || _isJumpFalling) && Mathf.Abs(RB.velocity.y) < Data.jumpHangTimeThreshold)
        {
            SetGravityScale(Data.gravityScale * Data.jumpHangGravityMult);
        }
        else if (RB.velocity.y < 0)
        {
            //Higher gravity if falling
            SetGravityScale(Data.gravityScale * Data.fallGravityMult);
            //Caps maximum fall speed, so when falling over large distances we don't accelerate to insanely high speeds
            RB.velocity = new Vector2(RB.velocity.x, Mathf.Max(RB.velocity.y, -Data.maxFallSpeed));
        }
        else
        {
            //Default gravity if standing on a platform or moving upwards
            SetGravityScale(Data.gravityScale);
        }
        #endregion
    }

    private void FixedUpdate()
    {



     

        //Handle Run
        if (IsWallJumping)
        {
            Run(Data.wallJumpRunLerp);
        }
        else
        {
            Run(1);
        }


        //Handle Slide
        if (IsSliding)
            Slide();

    }

    #region INPUT CALLBACKS
    //Methods which whandle input detected in Update()
    public void OnJumpInput()
    {
        if (CanJump() || CanWallJump())
        {
            LastPressedJumpTime = Data.jumpInputBufferTime;
            animator.SetBool("isJumping", true);
        }
    }

    public void OnJumpUpInput()
    {
        if (CanJumpCut() || CanWallJumpCut())
            _isJumpCut = true;
    }
    #endregion

    #region GENERAL METHODS
    public void SetGravityScale(float scale)
    {
        RB.gravityScale = scale;
    }
    #endregion

    //MOVEMENT METHODS
    #region RUN METHODS
    private void Run(float lerpAmount)
    {
        //Calculate the direction we want to move in and our desired velocity
        float targetSpeed = _moveInput.x * Data.runMaxSpeed;
        //We can reduce are control using Lerp() this smooths changes to are direction and speed
        targetSpeed = Mathf.Lerp(RB.velocity.x, targetSpeed, lerpAmount);

        #region Calculate AccelRate
        float accelRate;

        //Gets an acceleration value based on if we are accelerating (includes turning) 
        //or trying to decelerate (stop). As well as applying a multiplier if we're air borne.
        if (LastOnGroundTime > 0)
            accelRate = (Mathf.Abs(targetSpeed) > 0.01f) ? Data.runAccelAmount : Data.runDeccelAmount;
        else
            accelRate = (Mathf.Abs(targetSpeed) > 0.01f) ? Data.runAccelAmount * Data.accelInAir : Data.runDeccelAmount * Data.deccelInAir;
           
        
        #endregion

        #region Add Bonus Jump Apex Acceleration
        //Increase are acceleration and maxSpeed when at the apex of their jump, makes the jump feel a bit more bouncy, responsive and natural
        if ((IsJumping || IsWallJumping || _isJumpFalling) && Mathf.Abs(RB.velocity.y) < Data.jumpHangTimeThreshold)
        {
            accelRate *= Data.jumpHangAccelerationMult;
            targetSpeed *= Data.jumpHangMaxSpeedMult;
            animator.SetTrigger("Fall");
        }
        #endregion

        #region Conserve Momentum
        //We won't slow the player down if they are moving in their desired direction but at a greater speed than their maxSpeed
        if (Data.doConserveMomentum && Mathf.Abs(RB.velocity.x) > Mathf.Abs(targetSpeed) && Mathf.Sign(RB.velocity.x) == Mathf.Sign(targetSpeed) && Mathf.Abs(targetSpeed) > 0.01f && LastOnGroundTime < 0)
        {
            //Prevent any deceleration from happening, or in other words conserve are current momentum
            //You could experiment with allowing for the player to slightly increae their speed whilst in this "state"
            accelRate = 0;
        }
        #endregion

        //Calculate difference between current velocity and desired velocity
        float speedDif = targetSpeed - RB.velocity.x;
        //Calculate force along x-axis to apply to thr player

        float movement = speedDif * accelRate;

        //Convert this to a vector and apply to rigidbody
        RB.AddForce(movement * Vector2.right, ForceMode2D.Force);

        /*
		 * For those interested here is what AddForce() will do
		 * RB.velocity = new Vector2(RB.velocity.x + (Time.fixedDeltaTime  * speedDif * accelRate) / RB.mass, RB.velocity.y);
		 * Time.fixedDeltaTime is by default in Unity 0.02 seconds equal to 50 FixedUpdate() calls per second
		*/
    }

    private void Turn()
    {
        //stores scale and flips the player along the x axis, 
      
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
        IsFacingRight = !IsFacingRight;
        createDust();
    }
    #endregion

    #region JUMP METHODS
    private void Jump()
    {
        //Ensures we can't call Jump multiple times from one press
        LastPressedJumpTime = 0;
        LastOnGroundTime = 0;

        #region Perform Jump
        //We increase the force applied if we are falling
        //This means we'll always feel like we jump the same amount 
        //(setting the player's Y velocity to 0 beforehand will likely work the same, but I find this more elegant :D)
        float force = Data.jumpForce;
        
    
        
            if (isGrounded)
            {
            force -= RB.velocity.y;
            createDust();
            RB.AddForce(Vector2.up * force, ForceMode2D.Impulse);

            }
           
            
            
        
        #endregion
    }

    
    #endregion

    #region OTHER MOVEMENT METHODS
    private void Slide()
    {
        //Works the same as the Run but only in the y-axis
        //THis seems to work fine, buit maybe you'll find a better way to implement a slide into this system
        float speedDif = Data.slideSpeed - RB.velocity.y;
        float movement = speedDif * Data.slideAccel;
        //So, we clamp the movement here to prevent any over corrections (these aren't noticeable in the Run)
        //The force applied can't be greater than the (negative) speedDifference * by how many times a second FixedUpdate() is called. For more info research how force are applied to rigidbodies.
        movement = Mathf.Clamp(movement, -Mathf.Abs(speedDif) * (1 / Time.fixedDeltaTime), Mathf.Abs(speedDif) * (1 / Time.fixedDeltaTime));

        RB.AddForce(movement * Vector2.up);
    }
    #endregion


    #region CHECK METHODS
    public void CheckDirectionToFace(bool isMovingRight)
    {
        if (isMovingRight != IsFacingRight)
            Turn();
    }

    private bool CanJump()
    {
        return LastOnGroundTime > 0 && !IsJumping;
    }

    private bool CanWallJump()
    {
        return LastPressedJumpTime > 0 && Physics2D.OverlapBox(_frontWallCheckPoint.position, _wallCheckSize, 0, _wallLayer) != null && LastOnGroundTime <= 0;


    }

    private bool CanJumpCut()
    {
        return IsJumping && RB.velocity.y > 0;
    }

    private bool CanWallJumpCut()
    {
        return false;
    }

    public bool CanSlide()
    {
        if (LastOnWallTime > 0 && !IsJumping && !IsWallJumping && LastOnGroundTime <= 0)
        {
            return true;
        }

        else
            return false;
    }
    
    private bool iswasGrouded(){

    return Physics2D.OverlapBox(_groundCheckPoint.position, _groundCheckSize, 0, _groundLayer);

    }





    #endregion


    #region EDITOR METHODS
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(_groundCheckPoint.position, _groundCheckSize);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(_frontWallCheckPoint.position, _wallCheckSize);
        Gizmos.DrawWireCube(_backWallCheckPoint.position, _wallCheckSize);
    }
    #endregion
    

private IEnumerator Dash()
{
    if (energyBar != null && energyBar.CanAttack(dashEnergyCost))
    {
        isSkillKeyPressed = true;

        animator.SetTrigger("dash");
        SoundEffectManager.instance.JumpClip(dashSoundClip, transform, 1f);

        // Deduct energy cost for dash
        energyBar.UseEnergy(dashEnergyCost);

        RB.velocity = new Vector2(direction * dashSpeed, RB.velocity.y);

        startDash = Time.time + dashTime;

        yield return new WaitForSeconds(dashTime);

        isSkillKeyPressed = false;
    }
    else
    {
        Debug.Log("Not enough energy for dash!");
    }
}

    void wasCheck()
    {
        isTouchingWall = (Physics2D.OverlapBox(_frontWallCheckPoint.position, _wallCheckSize, 0, _wallLayer) != null ||
                      Physics2D.OverlapBox(_backWallCheckPoint.position, _wallCheckSize, 0, _wallLayer) != null) && !IsWallJumping;
    }
    void Grounded()
    {
        isGrounded = Physics2D.OverlapBox(_groundCheckPoint.position, _groundCheckSize, 0, _groundLayer);
        isTouchingtheWalls = Physics2D.OverlapBox(_groundCheckPoint.position, _groundCheckSize, 0, _wallLayer);


    }

    void createDust()
    {
        dust.Play();
        
    }

    void OnLandParticle()
    {
        onLand.Play();
    }
}

// created by Dawnosaur :D