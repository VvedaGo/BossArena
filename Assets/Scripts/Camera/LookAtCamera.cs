using UnityEngine;

namespace Camera
{
  public class LookAtCamera : MonoBehaviour
  {
    private UnityEngine.Camera _mainCamera;

    private void Start()
    {
      _mainCamera = UnityEngine.Camera.main;
    }

    private void Update()
    {
      Quaternion rotation = _mainCamera.transform.rotation;
      transform.LookAt(transform.position + rotation * Vector3.back, rotation * Vector3.up);
    }
  }
}
