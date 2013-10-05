using UnityEngine;
using System.Collections;

public class GameViewCamera : MonoBehaviour
{
	public Camera gameCam;
	private Camera cam;
	
	public Vector2 TopAspectRatio;
	
	void Start()
	{
		height = Screen.height;
		width = Screen.width;
		cam = this.GetComponent<Camera>();
		updateView();
		
		
	}
	
	private int height = 0;
	private int width = 0;
	
	public void Update()
	{
		if(height != Screen.height || width != Screen.width)
		{
			height = Screen.height;
			width = Screen.width;
			
			updateView();
		}
	}
	
	private void updateView()
	{
		if(TopAspectRatio.x <= 0)
			TopAspectRatio.x = 1;
		if(TopAspectRatio.y <= 0)
			TopAspectRatio.y = 1;
		
		float topRatio = ((float)width / TopAspectRatio.x * TopAspectRatio.y) / (float)height;
		gameCam.rect = new Rect(0, 1-topRatio, 1, topRatio);
		
		// rects build from the bottom left to the top right
		float ratio;
		if(height - ((float)height * topRatio) > width)
		{
			ratio = (float)width / ((float)height - ((float)height * topRatio));
			cam.rect = new Rect(0, 0, 1, ratio);
		}
		else
		{
			ratio = ((float)height - ((float)height * topRatio)) / (float)width;
			cam.rect = new Rect(1 - ratio, 0, ratio, 1);
		}
	}
}
