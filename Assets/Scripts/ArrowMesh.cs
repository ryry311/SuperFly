using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[ExecuteInEditorMode]
public class ArrowMesh : MonoBehaviour
{
    private Mesh mesh;
    private Vector3[] vertices;
    private int[] triangles;

    public float width = 1f;
    public float totalHeight = 2f;
    public float topHeight = .5f;

    void Awake()
    {
      mesh = GetComponent<MeshFilter> ().mesh;
    }
    // Start is called before the first frame update
    void Start()
    {
      MakeMeshData();
      CreateMesh();
    }

    void MakeMeshData()
    {
      vertices = new Vector3[] {
        new Vector3(-1 * width / 2, 0f, 0f),
        new Vector3(width / 2, 0f, 0f),
        new Vector3(0f, totalHeight, 0f),
        new Vector3(0f, totalHeight - topHeight, 0f),
      };
      triangles = new int[] {0, 2, 3, 2, 1, 3};
    }

    void CreateMesh()
    {
      //mesh.clear();
      mesh.vertices = vertices;
      mesh.triangles = triangles;
    }
}
