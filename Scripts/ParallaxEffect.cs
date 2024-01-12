using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    [SerializeField] float parallaxSpeedX;
    [SerializeField] float parallaxSpeedY;

    [SerializeField] Transform cameraTransform;
    float startPositionCameraY;

    float startPositionX;
    float startPositionY;

    float spriteSizeX;
    float spriteSizeCheck; //za uske spriteove

    private void Start()
    {

        startPositionCameraY = cameraTransform.transform.position.y;

        startPositionX = transform.localPosition.x;
        startPositionY = transform.localPosition.y;

        spriteSizeX = GetComponent<SpriteRenderer>().bounds.size.x;
        spriteSizeCheck = spriteSizeX / 2;
    }

    private void Update()
    {
        float relativeDistance = cameraTransform.position.x * parallaxSpeedX;
        float relativeHeight = (cameraTransform.position.y - startPositionCameraY) * parallaxSpeedY;

        transform.position = new Vector3(startPositionX + relativeDistance, startPositionY + relativeHeight, transform.position.z);

        float relativeCameraDistance = cameraTransform.position.x * (1 - parallaxSpeedX);

        if(relativeCameraDistance > startPositionX + spriteSizeCheck)
        {
            startPositionX += spriteSizeX;
        }

        else if(relativeCameraDistance < startPositionX - spriteSizeCheck)
        {
            startPositionX -= spriteSizeX;
        }
    }
}
