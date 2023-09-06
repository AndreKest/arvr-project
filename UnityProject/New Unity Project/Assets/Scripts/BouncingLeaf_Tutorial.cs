using UnityEngine;

public class BouncingLeaf_Tutorial : MonoBehaviour
{
	
    public int id;
    public bool music = true;
    private float speed = 1.5f;
    private float height = 0.1f;
    private float startY = 10.25f;
	private Vector3 endScale = new Vector3(15.0f, 35.0f, 10.0f);	
	//private Vector3 endScale = new Vector3(373.9335f, 1000.0f, 207.2226f);
	public bool showLeaf = false;
	public Station Station;

	void Start()
	{
		startY = transform.position.y;
		
	}
    // Update is called once per frame
    void Update()
    {
        //Station bestanden

		if(showLeaf & transform.localScale.x < endScale.x)
		{
			transform.localScale +=new Vector3(endScale.x/50.0f, endScale.y/50.0f, endScale.z/50.0f);
		}

            music = true;

            //Rotation
            transform.Rotate(0f, 20 * Time.deltaTime, 0f, Space.Self);

            //Bounce
            var pos = transform.position;
            var newY = startY + height * Mathf.Sin(Time.time * speed);
            transform.position = new Vector3(pos.x, newY, pos.z);
        
    }


}

