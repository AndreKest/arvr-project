using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class TriggerStayHerbert : MonoBehaviour
{
  private bool cleared = false;
  /// <summary>
  /// GameObjekt der Sprechblase
  /// </summary>
  public GameObject speechBubbleObj;

  /// <summary>
  /// Text der Sprechblase die beim bestehen der Station angezeigt wird
  /// </summary>
  [TextArea(10,10)]
  public string speechBubbleText = "";

  private void OnTriggerStay(Collider c)
  {
    speechBubbleObj.SetActive(true);
    if (cleared)
    {
      //Aktiviert die Sprechblase und �ndert den angezeigten Text
      if (speechBubbleObj != null)
      {
          GameObject childText = speechBubbleObj.transform.GetChild(0).gameObject;
          childText.GetComponent<TextMeshPro>().text = speechBubbleText;
          childText.GetComponent<TextMeshPro>().fontSize = 0.068f;
      }
    }
  }

  /// <summary>
  /// Station wurde bew�ltigt. Cleared wird auf true gesetzt.
  /// </summary>
  public void StationCleared()
  {
      cleared = true;
  }
}
