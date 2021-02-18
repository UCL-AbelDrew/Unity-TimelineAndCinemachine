using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class DirectorAnimationCurve : MonoBehaviour
{
    // Animate this moving from 0-1 in the TimeLine;
    public float m_curvePosition;
    public AnimationCurve m_animationCurve;
    public PlayableDirector m_playableDirector;

    public bool m_playOnAwake;

    private PlayableGraph m_playableGraph;
    private bool m_evaluateCurve;
    private float m_frameTime;

    private void Start()
    {
        m_playableGraph = m_playableDirector.playableGraph;
        if (m_playOnAwake)
        {
            BeginCurve();
        }

    }

    public void BeginCurve()
    {
        m_evaluateCurve = true;
    }

    private void FixedUpdate()
    {
        if (m_evaluateCurve)
        {
            m_frameTime = m_animationCurve.Evaluate(m_curvePosition);
            m_frameTime *= Time.deltaTime;

            try
            {
                m_playableGraph.Evaluate(m_frameTime);
            }
            catch
            {
                Debug.Log("Playable Graph not found, it may have been destroyed: ");
                m_evaluateCurve = false;
            }
        }
    }
}
