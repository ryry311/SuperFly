using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[ExecuteInEditorMode]
public class BellyMesh : MonoBehaviour
{
    private Mesh mesh;
    private Vector3[] vertices;
    private int[] triangles;

    public float height = .5f;

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
      GameObject player = GameObject.Find("Player");
      ArrowMesh arrowMesh = player.GetComponent<ArrowMesh>();

      vertices = new Vector3[] {
        new Vector3(-1f * arrowMesh.width / 2f, 0f, 0f),
        new Vector3(arrowMesh.width / 2f, 0f, 0f),
        new Vector3(0f, arrowMesh.totalHeight - arrowMesh.topHeight, 0f),
        new Vector3(0f, arrowMesh.totalHeight - arrowMesh.topHeight - height, 0f),
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
