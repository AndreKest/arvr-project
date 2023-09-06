using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationFence : Station
{
	[HideInInspector]
	public AudioSource audioSource;
	
	public string enterSound;
	public string clearedSound;

    // Start is called before the first frame update

    /// <summary>
    /// Liste an Items die nach fertigstellung der Station verschwinden sollen.
    /// </summary>
    public List<GameObject> ItemsToHide;
    public void HideItems()
    {
        foreach (var i in ItemsToHide)
        {
            Renderer r;
            if(i.TryGetComponent<Renderer>(out r))
                r.enabled = false;
        }
    }
	
	public void enterStation()
	{
		if(!Completed){
			FindObjectOfType<AudioManager>().PlaySound(enterSound);	
		}	
	}

    public void exitStation()
    {
        FindObjectOfType<AudioManager>().StopSound(enterSound);
        FindObjectOfType<AudioManager>().StopSound(clearedSound);
    }

    public void completedStation()
    {
        FindObjectOfType<AudioManager>().PlaySound(clearedSound);
        StartCoroutine(wait(FindObjectOfType<AudioManager>().getAudioSource(clearedSound).clip.length));
    }

    public IEnumerator wait(float lenght)
    {
        yield return new WaitForSeconds(lenght);
        Item.GetComponent<BouncingLeaf>().Drop();
    }


}
