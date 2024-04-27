using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{

    //Äàííûå ìåòîä ðàáîòàåò ïðè íàõîæäåíèè íà áàòóòå
    private void OnTriggerEnter(Collider other)
    {
        // Óâåëè÷èâàåì ñâ-âî ïðûæêà èãðîêà äî 10 ïóíêòîâ
        other.GetComponent<Jump>().jumpStrength = 10;

    }
    //Ñðàáàòûâàåò, êîãäà óõîäèì ñ áàòóòà
    private void OnTriggerExit(Collider other)
    {
        //Âîçâðàùàåò ïðåæíåå ñâ-âî ïðûæêà èãðîêà (2)
        other.GetComponent<Jump>().jumpStrength = 2;
       
    }
}
