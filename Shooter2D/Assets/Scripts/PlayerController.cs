using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float moveVelocity, rotationSpeed;
    [SerializeField]
    private PlayerInput playerInput;

    private void Start()
    {
        playerInput.OnFireButtonPressed += PlayerInput_OnFireButtonPressed;
    }
    private void OnDisable()
    {
        playerInput.OnFireButtonPressed -= PlayerInput_OnFireButtonPressed;
    }
    private void PlayerInput_OnFireButtonPressed(object sender, System.EventArgs e)
    {
        IWeapon weapon=GetComponentInChildren<IWeapon>();
        if (weapon!=null)
        {
            weapon.Shoot();
        }
    }

    private void FixedUpdate()
    {
        MovePlayer(playerInput.GetMovementVectorNormalized());
        AdjustPlayerRotation(playerInput.GetMovementVectorNormalized());
    }
    private Vector3 ConvertVector2to3(Vector2 vector2)
    { 
        Vector3 newVector= Vector3.zero;
        newVector.x = vector2.x;
        newVector.y = vector2.y;
        return newVector;
    }
    private void MovePlayer(Vector2 directionVector)
    {
        transform.position += ConvertVector2to3(directionVector) * moveVelocity*Time.fixedDeltaTime;
    }
    private void AdjustPlayerRotation(Vector2 directionVector)
    {
        if (directionVector != Vector2.zero)
        {
            Vector2 transformUp2 = new Vector2(transform.up.x, transform.up.y);
            Vector2 newTransformUp2 = Vector2.Lerp(transformUp2,directionVector,Time.fixedDeltaTime*rotationSpeed);
            transform.up = ConvertVector2to3(newTransformUp2);
        }
    }

}
