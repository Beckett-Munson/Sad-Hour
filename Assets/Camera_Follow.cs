using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow : MonoBehaviour
{
public GameObject Player;
private SpriteRenderer background;
private Camera camera;

public float adjust;
public float yadjust;


// Start is called before the first frame update
void Start()
{
    background = GameObject.FindWithTag("Background").GetComponent<SpriteRenderer>();
    camera = GameObject.FindObjectOfType<Camera>();
}

// Update is called once per frame
void Update()
{
var xPos = Player.transform.position.x;

var BackroundSize = background.sprite.bounds.extents*2 * background.transform.localScale.x;

float screenAspect = (float) Screen.width / (float) Screen.height;
float cameraHeightHalf = GetComponent<Camera>().orthographicSize;
float cameraWidthHalf = screenAspect * cameraHeightHalf;
float cameraWidth = 2.0f * cameraWidthHalf;

if(xPos > 0) {
xPos = Mathf.Min(xPos, BackroundSize.x - (cameraWidthHalf + adjust));
}

else {
xPos = Mathf.Max(xPos, -BackroundSize.x + (cameraWidthHalf + adjust));
}


var yPos = Player.transform.position.y;

if(yPos > 0) {
yPos = Mathf.Min(Player.transform.position.y, BackroundSize.y/2 - (cameraHeightHalf + yadjust));
}

if(yPos <= 0) {
yPos = Mathf.Max(Player.transform.position.y, -BackroundSize.y/2 + (cameraHeightHalf + yadjust));
}

transform.position = new Vector3 (xPos, yPos, -9);
}
}
