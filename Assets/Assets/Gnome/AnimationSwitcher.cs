//using UnityEngine;

//public class GardenGnomeAnimation : MonoBehaviour
//{
//    public MeshRenderer upObjectWalkRenderer;
//    public MeshRenderer leftObjectWalkRenderer;
//    public MeshRenderer rightObjectWalkRenderer;

//    public MeshRenderer upObjectIdleRenderer;
//    public MeshRenderer leftObjectIdleRenderer;
//    public MeshRenderer rightObjectIdleRenderer;

//    public MeshRenderer upObjectActionRenderer;
//    public MeshRenderer leftObjectActionRenderer;
//    public MeshRenderer rightObjectActionRenderer;

//    public float speedThreshold = 0.1f;

//    private Vector3 lastPosition;

//    void Start()
//    {
//        lastPosition = transform.position;
//        DeactivateAllRenderers();
//    }

//    void Update()
//    {
//        UpdateDirection();
//    }

//    private void UpdateDirection()
//    {
//        Vector3 currentPosition = transform.position;
//        Vector3 direction = (currentPosition - lastPosition).normalized;
//        float speed = (currentPosition - lastPosition).magnitude / Time.deltaTime;

//        lastPosition = currentPosition;

//        if (gardenGnome.WePlant)
//        {
//            if (direction.y > Mathf.Abs(direction.x))
//            {
//                if (direction.y > 0)
//                {
//                    ActivateRenderer(upObjectActionRenderer);
//                }
//            }
//            else
//            {
//                if (direction.x > 0)
//                {
//                    ActivateRenderer(rightObjectActionRenderer);
//                }
//                else
//                {
//                    ActivateRenderer(leftObjectActionRenderer);
//                }
//            }
//        }
//        else if (speed > speedThreshold)
//        {
//            if (direction.y > Mathf.Abs(direction.x))
//            {
//                if (direction.y > 0)
//                {
//                    ActivateRenderer(upObjectWalkRenderer);
//                }
//            }
//            else
//            {
//                if (direction.x > 0)
//                {
//                    ActivateRenderer(rightObjectWalkRenderer);
//                }
//                else
//                {
//                    ActivateRenderer(leftObjectWalkRenderer);
//                }
//            }
//        }
//        else
//        {
//            if (direction.y > Mathf.Abs(direction.x))
//            {
//                if (direction.y > 0)
//                {
//                    ActivateRenderer(upObjectIdleRenderer);
//                }
//            }
//            else
//            {
//                if (direction.x > 0)
//                {
//                    ActivateRenderer(rightObjectIdleRenderer);
//                }
//                else
//                {
//                    ActivateRenderer(leftObjectIdleRenderer);
//                }
//            }
//        }
//    }

//    private void ActivateRenderer(MeshRenderer rendererToActivate)
//    {
//        DeactivateAllRenderers();
//        rendererToActivate.enabled = true;
//    }

//    private void DeactivateAllRenderers()
//    {
//        upObjectWalkRenderer.enabled = false;
//        leftObjectWalkRenderer.enabled = false;
//        rightObjectWalkRenderer.enabled = false;
//        upObjectIdleRenderer.enabled = false;
//        leftObjectIdleRenderer.enabled = false;
//        rightObjectIdleRenderer.enabled = false;
//        upObjectActionRenderer.enabled = false;
//        leftObjectActionRenderer.enabled = false;
//        rightObjectActionRenderer.enabled = false;
//    }
//}