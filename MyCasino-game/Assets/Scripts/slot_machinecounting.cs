using UnityEngine;

public class slot_machinecounting : MonoBehaviour
{
    public player_movement player;

    public int slotwheelLeft = 0;
    public int slotwheelMiddle = 0;
    public int slotwheelRight = 0;
    public bool activateRoll = false;
    public bool rotationstartleft = false;

    void Start()
    {
        
    }

    void Update()
    {
        if (activateRoll)
        {
            SlotActivated();
            activateRoll = false;
        }
    }

    private void SlotActivated()
    {
        rotationstartleft = true;
        slotwheelLeft = Random.Range(1, 8);
        slotwheelMiddle = Random.Range(1, 8);
        slotwheelRight = Random.Range(1, 8); 

        if (slotwheelLeft == slotwheelMiddle && slotwheelMiddle == slotwheelRight)
        {
            player.geld += 100;
        }
        else if (slotwheelLeft == slotwheelMiddle || slotwheelLeft == slotwheelRight || slotwheelMiddle == slotwheelRight)
        {
            player.geld += 40;
        }
        Debug.Log(slotwheelLeft);
    }
}