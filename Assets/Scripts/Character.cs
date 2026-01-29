using UnityEngine;
using DG.Tweening;

public class Character : MonoBehaviour
{
    private Rigidbody characterRigidbody;
    [SerializeField]

    private CharacterData characterData;
    [SerializeField]

    private Animator CharacterAnimator;
    [SerializeField]

    private float jumpforce = 5f;
    [SerializeField]

    private float distanceToMove = 2f;
    [SerializeField]

    private float moveDuration = 0.2f;

    private bool isGrounded = true;

    private bool isMoving = false;

    private void Start()
    {
        CharacterAnimator.Play(characterData.runAnimationName, 0, 0f);
        characterRigidbody = GetComponent <Rigidbody>();
    }


    public void Jump()
    {
        if (isGrounded)
        {
            CharacterAnimator.Play(characterData.jumpAnimationName, 0, 0f);
            characterRigidbody.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
            isGrounded = false;
        }
    }
    
public void MoveDown()
    {
        if (!isGrounded)
        {
            characterRigidbody.AddForce(Vector3.down * jumpforce, ForceMode.Impulse);
        }
        CharacterAnimator.Play(characterData.rollAnimationName, 0, 3f);
    }

    public void MoveLeft()
    {
        Move(Vector3.left);
    }

    public void MoveRight()
    {
        Move(Vector3.right);
    }

private void Move (Vector3 direction)
    {
        if (isMoving) return;
        CharacterAnimator.Play(characterData.moveAnimationName, 3, 0f);
        isMoving = true;
        Vector3 targetPosition = transform.position + direction * distanceToMove;

        transform.DOMove(targetPosition, moveDuration).SetEase(Ease.OutQuad).OnComplete(() =>
        {
            isMoving = false;
        });
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            CharacterAnimator.Play(characterData.runAnimationName, 0, 0f);
            isGrounded = true;
        }
    }
}
