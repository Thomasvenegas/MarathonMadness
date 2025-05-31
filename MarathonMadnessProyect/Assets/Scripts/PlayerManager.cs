using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private InputManager inputManager;

    private Animator animator;
    private Vector3 targetPosition;
    private bool isMoving;

    private bool isJumping = false;

    public float lanesDistance = 1f;
    
    void Start()
    {
        inputManager = GetComponent<InputManager>();
        animator = GetComponent<Animator>();
        targetPosition = transform.position;
        isMoving = false;
    }

    private void SelectTargetPosition()
    {
        if (IsBussy()) return;

        float horizontalMovement = inputManager.horizontalMovement.ReadValue<float>();
        float x = transform.position.x;

        if (horizontalMovement == 1 && x <= 0)
        {
            targetPosition = transform.position + Vector3.right * lanesDistance;
            isMoving = true;
        }
        else if (horizontalMovement == -1 && x>=0)
        {
            targetPosition = transform.position + Vector3.left * lanesDistance;
            isMoving = true;
        }
    }

    private void MoveToTargetPosition()
    {
        if (!isMoving) return;

        transform.position = Vector3.Lerp(transform.position, targetPosition, 0.1f);

        // Stop moving when close enough to target
        if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
        {
            transform.position = targetPosition;
            isMoving = false;
        }
    }


    private void CheckForJump(){
        if (IsBussy()){return;}

        if (inputManager.jump.IsPressed()){

            animator.SetTrigger("Jump");
            isJumping = true;

        }
    }

    public void EndJump(){
        isJumping = false;
    }

    private bool IsBussy(){
        return isMoving || isJumping;
    }

    void Update()
    {
        SelectTargetPosition();
        MoveToTargetPosition();
        CheckForJump();
    }
}
