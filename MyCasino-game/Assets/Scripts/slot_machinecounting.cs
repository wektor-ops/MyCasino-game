using UnityEngine;

public class slot_machinecounting : MonoBehaviour
{
    public player_movement player;
    public slotwheelLEFT left;
    public slotwheelMIDDLE middle;
    public slotwheelRIGHT right;

    public int slotwheelLeft = 0;
    public int slotwheelMiddle = 0;
    public int slotwheelRight = 0;

    public bool activateRoll = false;
    public bool rotationstartleft = false;
    public bool rotationstartmiddle = false;
    public bool rotationstartright = false;

    private bool isRolling = false; // Sperrt mehrfaches Starten

    public bool IsRolling()
    {
        return isRolling;
    }

    void Update()
    {
        if (activateRoll && !isRolling)
        {
            activateRoll = false;
            SlotActivated();
        }

        if (isRolling && !middle.isSpinning && !right.isSpinning && !left.isSpinning)
        {
            isRolling = false;
            CheckResult();
        }
    }

    private void SlotActivated()
    {
        isRolling = true;
        rotationstartleft = true;
        rotationstartmiddle = true;
        rotationstartright = true;
        middle.isSpinning = true;
        right.isSpinning = true;
        left.isSpinning = true;
        slotwheelLeft = Random.Range(1, 9);
        slotwheelMiddle = Random.Range(1, 9);
        slotwheelRight = Random.Range(1, 9);
    }

    private void CheckResult()
    {
        if (slotwheelLeft == slotwheelMiddle && slotwheelMiddle == slotwheelRight)
        {
            player.geld += 350;
        }
        else if (slotwheelLeft == slotwheelMiddle || slotwheelLeft == slotwheelRight || slotwheelMiddle == slotwheelRight)
        {
            player.geld += 20;
        }

        Debug.Log(slotwheelLeft + " " + slotwheelMiddle + " " + slotwheelRight + " = " + player.geld);
    }
}
