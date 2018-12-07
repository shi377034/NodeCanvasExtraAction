using NodeCanvas.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskTest
{

    public Status Run(int state)
    {
        Status status = Status.Success;
        switch(state)
        {
            case 0:
                status = Status.Success;
                break;
            case 1:
                status = Status.Running;
                break;
            case 2:
                status = Status.Failure;
                break;
        }
        return status;
    }
}
