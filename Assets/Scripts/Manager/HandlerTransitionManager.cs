using EasyTransition;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlerTransitionManager : BaseManager<HandlerTransitionManager>
{
    public TransitionSettings transition;
    public float startDelay;

    public void LoadScene(string _sceneName)
    {
        TransitionManager.Instance().Transition(_sceneName, transition, startDelay);
    }
}
