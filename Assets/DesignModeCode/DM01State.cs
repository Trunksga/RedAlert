
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DM01State : MonoBehaviour
{
    private void Start()
    {
        Context context = new Context();
        context.SetState(new ConcreteStateA(context));
        context.Handle(5);
        context.Handle(10);
        context.Handle(30);
        context.Handle(5);
    }
}

public class Context
{
    private IState mState;
    public void SetState(IState state)
    {
        mState = state;
    }

    public void Handle(int args)
    {
        mState.Handle(args);
    }
}

public interface IState
{
      void Handle(int args);
}


public class ConcreteStateA : IState
{
    private Context mContext;
    public ConcreteStateA(Context context)
    {
        mContext = context;
    }

    public  void Handle(int args)
    {
        Debug.Log("ConscreteStateA.Handle" + args);
        if (args > 10)
        {
            //
            mContext.SetState(new ConcreteStateB(mContext));
        }
    } 
}

public class ConcreteStateB : IState
{
    private Context mContext;
    public ConcreteStateB(Context context)
    {
        mContext = context;
    }

    public void Handle(int args)
    {
        Debug.Log("ConscreteStateB.Handle" + args);
        if (args <= 10)
        {
            //
            mContext.SetState(new ConcreteStateA(mContext));
        }
    }
}