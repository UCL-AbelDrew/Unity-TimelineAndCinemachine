using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class RedefineMeshBounds : MonoBehaviour
{
    public bool m_redefine;
    public SkinnedMeshRenderer m_skinnedMeshRenderer;
 
   
    void Update()
    {
        if (m_redefine)
        {
            Redefine();
            m_redefine = false;
        }
        
    }

    private void Redefine()
    {
        Mesh mesh = m_skinnedMeshRenderer.sharedMesh;
        mesh.RecalculateBounds();
    }

}
