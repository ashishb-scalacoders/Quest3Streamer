using UnityEngine;

public class TransformController : MonoBehaviour
{
    private float moveStep = 0.05f;
    private float rotateStep = 1.0f;
    private float scaleStep = 0.05f;

    // Movement methods along the correct axes
    public void MoveForward() => transform.Translate(moveStep, 0, 0); // Z positive
    public void MoveBackward() => transform.Translate(-moveStep, 0, 0); // Z negative
    public void MoveRight() => transform.Translate(0, moveStep, 0); // X positive
    public void MoveLeft() => transform.Translate(0, -moveStep, 0); // X negative
    public void MoveUp() => transform.Translate(0, 0, -moveStep); // Y positive
    public void MoveDown() => transform.Translate(0, 0, moveStep); // Y negative

    // Rotation methods around the Y axis (vertical axis)
    public void RotateRight() => transform.Rotate(0, 0, -rotateStep); // Rotate around Y positive
    public void RotateLeft() => transform.Rotate(0, 0, rotateStep); // Rotate around Y negative

    // Scale methods
    public void IncreaseScale() => transform.localScale += Vector3.one * scaleStep;
    public void DecreaseScale() => transform.localScale -= Vector3.one * scaleStep;

    // Reset Transform to default position, rotation, and scale
    public void ResetTransform()
    {
        transform.position = Vector3.zero;
        transform.rotation = Quaternion.identity;
        transform.localScale = Vector3.one;
    }
}
