using UnityEngine;

public class CameraController : MonoBehaviour
{
     #region parametri de control
     public float panSpeed = 30f;
     public float panBorderThickness = 10f;
     public float scrollSpeed = 5f;
     public float minZ = 10;
     public float maxZ = 80;

     public bool canMove = true;
     public bool canScroll = true;
     public bool mouseControll = true;
     public bool keyControll = true;

     private bool doMovement = true;

     private Camera cam;
     private float targetZoom;
     private float zoomFactor = 3f;
     private float zoomLerpSpeed = 10f;
     private float minZoom = 4.5f;
     private float maxZoom = 9f;
     #endregion

     private void Start()
     {
          cam = Camera.main;
          targetZoom = cam.orthographicSize;
     }
     private void Update()
     {
          if (Input.GetKeyDown(KeyCode.Escape))
          {
               doMovement = !doMovement;
               canMove = doMovement;
          }

          if (!doMovement)
               return;

          if (IsMoveUp())
          {
               transform.Translate(Vector3.up * panSpeed * Time.deltaTime, Space.World);
          }
          if (IsMoveDown())
          {
               transform.Translate(Vector3.down * panSpeed * Time.deltaTime, Space.World);
          }
          if (IsMoveToLeft())
          {
               transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
          }
          if (IsMoveToRight())
          {
               transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
          }

          if (!canScroll)
               return;

          ApplyZoom();
     }

     private bool IsMoveUp()
     {
          if (Input.GetKey("w") && keyControll ||
               (Input.mousePosition.y >= Screen.height - panBorderThickness) && mouseControll)
               return true;

          return false;
     }
     private bool IsMoveDown()
     {
          if (Input.GetKey("s") && keyControll ||
               (Input.mousePosition.y <= panBorderThickness) && mouseControll)
               return true;

          return false;
     }
     private bool IsMoveToRight()
     {
          if (Input.GetKey("d") && keyControll ||
               (Input.mousePosition.x >= Screen.width - panBorderThickness) && mouseControll)
               return true;

          return false;
     }
     private bool IsMoveToLeft()
     {
          if (Input.GetKey("a") && keyControll ||
               (Input.mousePosition.x <= panBorderThickness) && mouseControll)
               return true;

          return false;
     }
     private void ApplyZoom()
     {
          float scroll = Input.GetAxis("Mouse ScrollWheel");
          targetZoom -= scroll * zoomFactor;
          targetZoom = Mathf.Clamp(targetZoom, minZoom, maxZoom);
          cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, targetZoom, Time.deltaTime * zoomLerpSpeed);
     }
}