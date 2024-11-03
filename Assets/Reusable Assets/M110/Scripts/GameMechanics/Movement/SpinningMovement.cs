using UnityEngine;

public class SpinningMovement : MonoBehaviour
{
    [SerializeField]
    MovementAxis axis;

    [SerializeField]
    bool isSpinning;
    [SerializeField]
    bool clockwise;
    [SerializeField]
    float speed;
    [SerializeField]
    bool timeScaleDependent;

    int rotationPrefix { get { return clockwise ? 1 : -1; } }

    private void Update()
    {
        if (isSpinning)
        {
            if (timeScaleDependent)
                transform.Rotate(SpinAroundAxis(axis), speed * Time.deltaTime * rotationPrefix);
            else
                transform.Rotate(SpinAroundAxis(axis), speed * Time.unscaledDeltaTime * rotationPrefix);
        }
    }


    Vector3 SpinAroundAxis(MovementAxis axis)
    {
        switch (axis)
        {
            case MovementAxis.x_Axis_1D:
                return Vector3.right;
            case MovementAxis.y_Axis_1D:
                return Vector3.up;
            case MovementAxis.z_Axis_1D:
                return Vector3.forward;

            default:
                return Vector3.zero;
        }

    }
}
