using UnityEngine;

public class WaveMovement : MonoBehaviour
{
    public MovementAxis movementAxis;

    Vector2 PhaseDelay = new Vector2(0, 360);
    public bool swaysInCircles;
    public float delay;
    public bool randomDelay;
    [SerializeField] private float degreesPerSecond = 15.0f;
    [SerializeField] private float amplitude = 0.5f;
    [SerializeField] private float frequency = 1f;

    // Position Storage Variables
    Vector3 posOffset = new Vector3();
    Vector3 tempPos = new Vector3();

    // Use this for initialization
    void Start()
    {
        // Store the starting position & rotation of the object
        posOffset = transform.position;
        if (randomDelay)
            delay = Random.Range(PhaseDelay.x, PhaseDelay.y);
    }
    public void UpdateReferencePosition()
    {
        posOffset = transform.position;
    }

    public void SwitchOrientation(MovementAxis input)
    {
        posOffset = transform.position;
        movementAxis = input;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // Spin object around Y-Axis
        transform.Rotate(new Vector3(0f, Time.deltaTime * degreesPerSecond, 0f), Space.World);

        switch (movementAxis)
        {
            case MovementAxis.y_Axis_1D:

                // Float up/down with a Sin()
                tempPos = posOffset;
                tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency + delay) * amplitude;
                if (swaysInCircles)
                    tempPos.x += Mathf.Cos(Time.fixedTime * Mathf.PI * frequency + delay) * amplitude;
                transform.position = tempPos;

                break;
            case MovementAxis.x_Axis_1D:
                tempPos = posOffset;
                tempPos.x += Mathf.Cos(Time.fixedTime * Mathf.PI * frequency + delay) * amplitude;
                if (swaysInCircles)
                    tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency + delay) * amplitude;
                transform.position = tempPos;
                break;

        }



    }


}
public enum MovementAxis
{
    x_Axis_1D,
    y_Axis_1D,
    z_Axis_1D,
    xy_Axis_2D,
    xz_Axis_2D,
    yz_Axis_2D,
    xyz_Axis_3D
}

public enum Direction
{
    north,
    south,
    east,
    west,
    none
}
