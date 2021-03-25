using UnityEngine;

public class BaseObject : MonoBehaviour
{
     public int iD;
     public int price;
     public float lerpDuration;
     public float lifeDuration;

     private Vector3 lastPoint;
     private Vector3 targetPoint;
     private Vector3 tempTargetPoint;
     private float elapsedTime;
     private bool newTarget;

     private float timeToLive;

     private void Start()
     {
          Revive();
          elapsedTime = 0;
          lastPoint = transform.position;
          targetPoint = transform.position;
          newTarget = false;
     }
     private void Update()
     {
          timeToLive -= Time.deltaTime;
          if (timeToLive <= 0)
               Destroy(gameObject);

          if (elapsedTime < lerpDuration && newTarget)
          {
               transform.position = Vector3.Lerp(lastPoint, targetPoint, elapsedTime / lerpDuration);
          }
          else
          {
               newTarget = false;
               transform.position = targetPoint;
               lastPoint = transform.position;

               if (targetPoint != tempTargetPoint)
               {
                    newTarget = true;
                    targetPoint = tempTargetPoint;
               }
               
               elapsedTime = 0;
          }

          elapsedTime += Time.deltaTime;
     }

     public void SetTargetPosition(Vector3 position)
     {
          tempTargetPoint = position;
     }
     public void SetForcedTargetPosition(Vector3 position)
     {

          tempTargetPoint = position;
     }
     public void Revive()
     {
          timeToLive = lifeDuration;
     }
}
