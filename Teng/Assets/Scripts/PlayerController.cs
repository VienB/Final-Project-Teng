using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum LANE { Left = -3, Mid = 0, Right = 3 }
public enum HitX { Left, Mid, Right, None }
public enum HitY { Up, Mid, Down, Low, None }
public enum HitZ { Forward, Mid, Backward, None }
public class PlayerController : MonoBehaviour
{
    private Buttons buttons;
    private Animator npcAnimator;
    public float npcYPos = 1.5f;
    private float npcZPos = -1.2f;
    private NPCController npcController;
    public LANE mLane = LANE.Mid;
    private LANE lastLane;

    private CharacterController charControl;
    public Animator playerAnimator;

    [HideInInspector]
    public bool goRight, goLeft, goUp, goDown;
    public bool gameOver;
    public bool inJump;
    public bool inRoll;

    public float SpeedDodge = 10f;
    public float jumpForce = 7f;
    public float forwardSpeed = 7.0f;
    private float y;
    private float x;
    private float ColliderHeight;
    private float ColliderCenterY;

    public HitX hit_x = HitX.None;
    public HitY hit_y = HitY.None;
    public HitZ hit_z = HitZ.None;
    

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartGame());
        npcAnimator = GameObject.Find("Enemy").GetComponent<Animator>();
        npcController = GameObject.Find("Enemy").GetComponent<NPCController>();
        buttons = GameObject.Find("BUTTONS").GetComponent<Buttons>();
        charControl = GetComponent<CharacterController>();
        ColliderHeight = charControl.height;
        ColliderCenterY = charControl.center.y;
        playerAnimator = GetComponent<Animator>();
        playerAnimator.SetFloat("Blend", 1.0f);
        transform.position = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver == false && buttons.gamePause == false)
        {
            goRight = Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow);
            goLeft = Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow);
            goUp = Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow);
            goDown = Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow);

            if (goRight)
            {
                if (mLane == LANE.Mid)
                {
                    lastLane = mLane;
                    mLane = LANE.Right;
                    playerAnimator.Play("DodgeLeft");
                }
                else if (mLane == LANE.Left)
                {
                    lastLane = mLane;
                    mLane = LANE.Mid;
                    playerAnimator.Play("DodgeLeft");
                }
                else
                {
                    lastLane = mLane;
                    playerAnimator.Play("Stumble_R");
                }
            }
            else if (goLeft)
            {
                if (mLane == LANE.Mid)
                {
                    lastLane = mLane;
                    mLane = LANE.Left;
                    playerAnimator.Play("DodgeRight");
                }
                else if (mLane == LANE.Right)
                {
                    lastLane = mLane;
                    mLane = LANE.Mid;
                    playerAnimator.Play("DodgeRight");
                }
                else
                {
                    lastLane = mLane;
                    playerAnimator.Play("Stumble_L");
                }
            }
        }
        if (gameOver == false && buttons.gamePause == false)
        {
            x = Mathf.Lerp(x, (int)mLane, Time.deltaTime * SpeedDodge);
            Vector3 moveVector = new Vector3(x - transform.position.x, y * Time.deltaTime, forwardSpeed * Time.deltaTime);
            charControl.Move(moveVector);
            playerJump();
            playerRoll();
        }
    }
    public IEnumerator StartGame()
    {
        yield return new WaitForSeconds(1.75f);
        gameOver = false;
    }

    public void GameOver()
    {
        gameOver = true;
    }
    public void playerJump()
    {

        if (charControl.isGrounded)
        {
            if (playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Falling"))
            {
                playerAnimator.Play("Landing");
                inJump = false;
            }
            if (goUp)
            {
                y = jumpForce;
                playerAnimator.CrossFadeInFixedTime("Jump", 0.1f);
                inJump = true;
            }
        }
        else
        {
            y -= jumpForce * 2 * Time.deltaTime;
            if (playerAnimator.velocity.y < -0.1f)
                playerAnimator.Play("Falling");

        }
    }
    internal float RollCounter;
    public void playerRoll()
    {
        RollCounter -= Time.deltaTime;

        if (RollCounter <= 0f)
        {
            RollCounter = 0f;
            charControl.center = new Vector3(0, ColliderCenterY, 0);
            charControl.height = ColliderHeight;
            inRoll = false;
        }
        if (goDown && inRoll == false)
        {
            y = -10.0f;

            RollCounter = 0.2f;
            charControl.center = new Vector3(0, ColliderCenterY / 2f, 0);
            charControl.height = ColliderHeight / 2f;
            playerAnimator.CrossFadeInFixedTime("Roll", 0.5f);

            inRoll = true;
            inJump = false;
        }
    }
    public void CharacterColliding(Collider col)
    {
        hit_x = GetHitX(col);
        hit_y = GetHitY(col);
        hit_z = GetHitZ(col);
        if (gameOver == false)
        {
            if (hit_z == HitZ.Forward && hit_x == HitX.Mid)
            {
                if (npcController.offset.z < npcController.nearPlayer.z)
                {
                    if (hit_y == HitY.Low)
                    {
                        playerAnimator.Play("Stumle_M");
                        ResettingCollision();
                        npcAnimator.Play("Rolling");
                        npcController.offset = new Vector3(0.0f, npcYPos, npcZPos);
                    }
                }
                else
                {
                    playerAnimator.Play("Death");
                    ResettingCollision();
                    gameOver = true;
                    npcAnimator.Play("Death");
                    npcController.comparisonOffset = new Vector3(0.0f, npcYPos, npcZPos);
                    npcController.offset = new Vector3(0.0f, npcYPos, npcZPos);
                }

                if (hit_y == HitY.Down)
                {
                    playerAnimator.Play("DeathMid");
                    ResettingCollision();
                    gameOver = true;
                    npcAnimator.Play("Death");
                    npcController.comparisonOffset = new Vector3(0.0f, npcYPos, npcZPos);
                    npcController.offset = new Vector3(0.0f, npcYPos, npcZPos);
                }
                else if (hit_y == HitY.Mid)
                {
                    playerAnimator.Play("DeathMid");
                    ResettingCollision();
                    gameOver = true;
                    npcAnimator.Play("Death");
                    npcController.comparisonOffset = new Vector3(0.0f, npcYPos, npcZPos);
                    npcController.offset = new Vector3(0.0f, npcYPos, npcZPos);
                }
                else if (hit_y == HitY.Up)
                {
                    playerAnimator.Play("DeathMid");
                    ResettingCollision();
                    gameOver = true;
                    npcAnimator.Play("Death");
                    npcController.comparisonOffset = new Vector3(0.0f, npcYPos, npcZPos);
                    npcController.offset = new Vector3(0.0f, npcYPos, npcZPos);
                }
            }
            else if (hit_z == HitZ.Mid)
            {
                if (npcController.offset.z < npcController.nearPlayer.z)
                {
                    if (hit_x == HitX.Right)
                    {
                        mLane = lastLane;
                        playerAnimator.Play("Stumble_R_Mid");
                        ResettingCollision();
                        npcAnimator.Play("Rolling");
                        npcController.offset = new Vector3(0.0f, npcYPos, npcZPos);
                    }
                    else if (hit_x == HitX.Left)
                    {
                        mLane = lastLane;
                        playerAnimator.Play("Stumble_L_Mid");
                        ResettingCollision();
                        npcAnimator.Play("Rolling");
                        npcController.offset = new Vector3(0.0f, npcYPos, npcZPos);
                    }
                }
                else if (npcController.offset.z == npcController.nearPlayer.z)
                {
                    if (hit_x == HitX.Right)
                    {
                        playerAnimator.Play("DeathRight");
                        ResettingCollision();
                        gameOver = true;
                        npcAnimator.Play("Death");
                        npcController.comparisonOffset = new Vector3(0.0f, npcYPos, npcZPos);
                        npcController.offset = new Vector3(0.0f, npcYPos, npcZPos);
                    }
                    else if (hit_x == HitX.Left)
                    {
                        playerAnimator.Play("DeathLeft");
                        ResettingCollision();
                        gameOver = true;
                        npcAnimator.Play("Death");
                        npcController.comparisonOffset = new Vector3(0.0f, npcYPos, npcZPos);
                        npcController.offset = new Vector3(0.0f, npcYPos, npcZPos);
                    }
                }
            }
        }
    }
    private void ResettingCollision()
    {
        hit_x = HitX.None;
        hit_y = HitY.None;
        hit_z = HitZ.None;
    }

    public HitX GetHitX(Collider col)
    {
        Bounds playerBounds = charControl.bounds;
        Bounds colliderBounds = col.bounds;
        float minimumX = Mathf.Max(colliderBounds.min.x, playerBounds.min.x);
        float maximumX = Mathf.Min(colliderBounds.max.x, playerBounds.max.x);
        float averageOfBoth = (minimumX + maximumX) / 2f - colliderBounds.min.x;
        HitX hit;
        if (averageOfBoth > colliderBounds.size.x - 0.33f)
        {
            hit = HitX.Right;
        }
        else if (averageOfBoth < 0.33f)
        {
            hit = HitX.Left;
        }
        else
        {
            hit = HitX.Mid;
        }
        return hit;
    }
    public HitY GetHitY(Collider col)
    {
        Bounds playerBounds = charControl.bounds;
        Bounds colliderBounds = col.bounds;
        float minimumY = Mathf.Max(colliderBounds.min.y, playerBounds.min.y);
        float maximumY = Mathf.Min(colliderBounds.max.y, playerBounds.max.y);
        float averageOfBoth = ((minimumY + maximumY) / 2f - playerBounds.min.y) / playerBounds.size.y;
        HitY hit;
        if (averageOfBoth < 0.17f)
            hit = HitY.Low;
        else if (averageOfBoth < 0.33f)
            hit = HitY.Down;
        else if (averageOfBoth < 0.66f)
            hit = HitY.Mid;
        else
            hit = HitY.Up;
        return hit;
    }
    public HitZ GetHitZ(Collider col)
    {
        Bounds playerBounds = charControl.bounds;
        Bounds colliderBounds = col.bounds;
        float minimumZ = Mathf.Max(colliderBounds.min.z, playerBounds.min.z);
        float maximumZ = Mathf.Min(colliderBounds.max.z, playerBounds.max.z);
        float averageOfBoth = ((minimumZ + maximumZ) / 2f - playerBounds.min.z) / playerBounds.size.z;
        HitZ hit;
        if (averageOfBoth < 0.33f)
            hit = HitZ.Backward;
        else if (averageOfBoth < 0.66f)
            hit = HitZ.Mid;
        else
            hit = HitZ.Forward;
        return hit;
    }
}