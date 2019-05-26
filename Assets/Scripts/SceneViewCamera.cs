using Cinemachine;
using UnityEngine;

public class SceneViewCamera : MonoBehaviour
{
    public Transform Target;
    public Vector3 TargetOffset;
    public float Distance = 5.0f;
    public float MaxDistance = 20;
    public float MinDistance = .6f;
    public float XSpeed = 200.0f;
    public float YSpeed = 200.0f;
    public int YMinLimit = -80;
    public int YMaxLimit = 80;
    public int ZoomRate = 40;
    public float PanSpeed = 0.3f;
    public float ZoomDampening = 5.0f;

    private float _xDeg;
    private float _yDeg;
    private float _currentDistance;
    private float _desiredDistance;
    private Quaternion _currentRotation;
    private Quaternion _desiredRotation;
    private Quaternion _rotation;
    private Vector3 _position;
    private CinemachineVirtualCamera _vcam;

    private void Start()
    {
        Init();
    }

    private void OnEnable()
    {
        Init();
    }

    public void Init()
    {
        _vcam = GetComponent<CinemachineVirtualCamera>();

        //If there is no target, create a temporary target at 'distance' from the cameras current viewpoint
        if (!Target)
        {
            var go = new GameObject("Cam Target");
            go.transform.position = transform.position + (transform.forward * Distance);
            Target = go.transform;
        }

        Distance = Vector3.Distance(transform.position, Target.position);
        _currentDistance = Distance;
        _desiredDistance = Distance;

        //be sure to grab the current rotations as starting points.
        _position = transform.position;
        _rotation = transform.rotation;
        _currentRotation = transform.rotation;
        _desiredRotation = transform.rotation;

        _xDeg = Vector3.Angle(Vector3.right, transform.right);
        _yDeg = Vector3.Angle(Vector3.up, transform.up);
    }

    /*
     * Camera logic on LateUpdate to only update after all character movement logic has been handled.
     */
    private void LateUpdate()
    {
        if (!CinemachineCore.Instance.IsLive(_vcam))
        {
//            _vcam.GetCinemachineComponent<CinemachineTrackedDolly>().m_PathPosition = 2;
        }

        // If Control and Alt and Middle button? ZOOM!
        if (Input.GetMouseButton(1) && Input.GetKey(KeyCode.LeftAlt) && Input.GetKey(KeyCode.LeftControl))
        {
            _desiredDistance -= Input.GetAxis("Mouse Y") * Time.deltaTime * ZoomRate * 0.125f *
                               Mathf.Abs(_desiredDistance);
        }
        // If middle mouse and left alt are selected? ORBIT
        else if (Input.GetMouseButton(1))
        {
            _xDeg += Input.GetAxis("Mouse X") * XSpeed * 0.02f;
            _yDeg -= Input.GetAxis("Mouse Y") * YSpeed * 0.02f;

            ////////OrbitAngle

            //Clamp the vertical axis for the orbit
            _yDeg = ClampAngle(_yDeg, YMinLimit, YMaxLimit);
            // set camera rotation
            _desiredRotation = Quaternion.Euler(_yDeg, _xDeg, 0);
            _currentRotation = transform.rotation;

            _rotation = Quaternion.Lerp(_currentRotation, _desiredRotation, Time.deltaTime * ZoomDampening);
            transform.rotation = _rotation;
        }
        // otherwise if middle mouse is selected, we pan by way of transforming the target in screenspace
        else if (Input.GetMouseButton(2))
        {
            //grab the rotation of the camera so we can move in a pseudo local XY space
            Target.rotation = transform.rotation;
            Target.Translate(Vector3.right * -Input.GetAxis("Mouse X") * PanSpeed);
            Target.Translate(transform.up * -Input.GetAxis("Mouse Y") * PanSpeed, Space.World);
        }

        ////////Orbit Position

        // affect the desired Zoom distance if we roll the scrollwheel
        _desiredDistance -= Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * ZoomRate * Mathf.Abs(_desiredDistance);
        //clamp the zoom min/max
        _desiredDistance = Mathf.Clamp(_desiredDistance, MinDistance, MaxDistance);
        // For smoothing of the zoom, lerp distance
        _currentDistance = Mathf.Lerp(_currentDistance, _desiredDistance, Time.deltaTime * ZoomDampening);

        // calculate position based on the new currentDistance
        _position = Target.position - (_rotation * Vector3.forward * _currentDistance + TargetOffset);
        transform.position = _position;
    }

    private static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360)
            angle += 360;
        if (angle > 360)
            angle -= 360;
        return Mathf.Clamp(angle, min, max);
    }
}