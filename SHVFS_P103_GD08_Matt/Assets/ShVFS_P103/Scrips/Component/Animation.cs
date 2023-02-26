using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{

    private int IswalkingID = Animator.StringToHash("Iswalking");
    private Animator anim;
    private Transform myTran;
    private Vector3 lastUpd, NowUpd;
    public enum Mystate
    {
        stand,
        run,
    };
    Mystate myState;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        myTran = gameObject.GetComponent<Transform>();
        NowUpd = lastUpd =myTran.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        NowUpd = myTran.position;
        CheckRun(lastUpd, NowUpd);
        lastUpd = myTran.position;
    }
    void CheckRun(Vector3 i, Vector3 w)
    {
        if(i==w||Time.time<=0.02f)
        {
            if(myState!=Mystate.stand)
            {
                anim.SetBool(IswalkingID, false);
                myState = Mystate.stand;
            }
        }
        else
        {
            if(myState!=Mystate.run)
            {
                anim.SetBool(IswalkingID, true);
                myState=Mystate.run;
            }
        }
    }
}
