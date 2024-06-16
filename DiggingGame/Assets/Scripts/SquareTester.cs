using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareTester : MonoBehaviour
{
    Vector2 topRight, topLeft, bottomRight, bottomLeft;
    Vector2 topCentre, rightCentre, bottomCentre, leftCentre;

    [SerializeField] private float gridScale;
    [SerializeField] private MeshFilter meshFilter;

    private List<Vector3> vertices = new List<Vector3>();
    private List<int> triangles = new List<int>();

    [Header("Configuration")]
    [SerializeField] private bool topRightState;
    [SerializeField] private bool bottomRightState;
    [SerializeField] private bool bottomLeftState;
    [SerializeField] private bool topLeftState;




    private void Start()
    {
        topRight = gridScale * Vector2.one/2 ;
        bottomRight = topRight + Vector2.down * gridScale;
        bottomLeft = bottomRight + Vector2.left * gridScale;
        topLeft = bottomLeft + Vector2.up * gridScale ;

        topCentre = topRight + Vector2.left * gridScale / 2;
        rightCentre = bottomRight + Vector2.up * gridScale / 2;
        bottomCentre = bottomLeft + Vector2.right * gridScale / 2;
        leftCentre = topLeft + Vector2.down * gridScale / 2;


        Mesh mesh = new Mesh();

        vertices.Clear();
        triangles.Clear();

        Triangulate(GetConfiguration());

        mesh.vertices = vertices.ToArray();
        mesh.triangles = triangles.ToArray();

        meshFilter.mesh = mesh;

    }

    private int GetConfiguration()
    {
        int configuration = 0;

        if (topRightState)
            configuration += 1;

        if (bottomRightState)
            configuration += 2;

        if (bottomLeftState)
            configuration += 4;

        if (topLeftState)
            configuration += 8;

        return configuration;

    }

    private void Triangulate(int configuration)
    {
        switch (configuration)
        {
            case 0:
                break;

            case 1:
                vertices.AddRange(new Vector3[] { topRight, topCentre, rightCentre });
                triangles.AddRange(new int[] { 0, 1, 2 });
                break;
            case 2:
                vertices.AddRange(new Vector3[] { bottomRight, rightCentre, bottomCentre });
                triangles.AddRange(new int[] { 0, 1, 2 });
                break;
            case 3:
                vertices.AddRange(new Vector3[] { topRight, bottomRight, bottomCentre, topCentre });
                triangles.AddRange(new int[] { 0, 1, 2, 0, 2, 3 });
                break;
            case 4:
                vertices.AddRange(new Vector3[] { bottomLeft, bottomCentre, leftCentre });
                triangles.AddRange(new int[] { 0, 1, 2 });
                break;
            case 5:
                vertices.AddRange(new Vector3[] { topRight, rightCentre, bottomCentre, bottomLeft, leftCentre, topCentre });
                triangles.AddRange(new int[] { 0, 1, 2, 0, 2, 3, 0, 3 ,4 , 0, 4 ,5 });
                break;
            case 6:
                vertices.AddRange(new Vector3[] { rightCentre, bottomRight, bottomLeft, leftCentre});
                triangles.AddRange(new int[] { 0,1,2,0,2,3 });
                break;
            case 7:
                vertices.AddRange(new Vector3[] { topRight, bottomRight, bottomLeft, leftCentre, topCentre });
                triangles.AddRange(new int[] { 0, 1, 2, 0, 2, 3, 0, 3, 4 });
                break;
            case 8:
                vertices.AddRange(new Vector3[] { leftCentre, topLeft, topCentre});
                triangles.AddRange(new int[] { 0, 1, 2 });
                break;
            case 9:
                vertices.AddRange(new Vector3[] { topRight, rightCentre, leftCentre, topLeft});
                triangles.AddRange(new int[] { 0, 1, 2, 0, 2, 3});
                break;
            case 10:
                vertices.AddRange(new Vector3[] { rightCentre, bottomRight, bottomCentre, leftCentre, topLeft, topCentre  });
                triangles.AddRange(new int[] { 0, 1, 2, 0, 2, 3, 0, 3, 4, 0, 4, 5 });
                break;
            case 11:
                vertices.AddRange(new Vector3[] { topRight, bottomRight, bottomCentre, leftCentre, topLeft });
                triangles.AddRange(new int[] { 0, 1, 2, 0, 2, 3, 0, 3, 4 });
                break;
            case 12:
                vertices.AddRange(new Vector3[] { bottomCentre, bottomLeft, topLeft, topCentre });
                triangles.AddRange(new int[] { 0, 1, 2, 0, 2, 3 });
                break;
            case 13:
                vertices.AddRange(new Vector3[] { topRight, rightCentre, bottomCentre, bottomLeft, topLeft });
                triangles.AddRange(new int[] { 0, 1, 2, 0, 2, 3, 0, 3, 4 });
                break;
            case 14:
                vertices.AddRange(new Vector3[] { rightCentre, bottomRight, bottomLeft, topLeft, topCentre });
                triangles.AddRange(new int[] { 0, 1, 2, 0, 2, 3, 0, 3, 4 });
                break;
            case 15:
                vertices.AddRange(new Vector3[] { topRight, bottomRight, bottomLeft, topLeft });
                triangles.AddRange(new int[] { 0, 1, 2, 0, 2, 3});
                break;

        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        Gizmos.DrawSphere(topRight, gridScale/8f);
        Gizmos.DrawSphere(bottomRight, gridScale / 8f);
        Gizmos.DrawSphere(bottomLeft, gridScale / 8f);
        Gizmos.DrawSphere(topLeft, gridScale / 8f);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(topCentre, gridScale / 16f);
        Gizmos.DrawWireSphere(rightCentre, gridScale / 16f);
        Gizmos.DrawWireSphere(bottomCentre, gridScale / 16f);
        Gizmos.DrawWireSphere(leftCentre, gridScale / 16f);
    }

    private void Update()
    {
        Mesh mesh = new Mesh();

        vertices.Clear();
        triangles.Clear();

        Triangulate(GetConfiguration());

        mesh.vertices = vertices.ToArray();
        mesh.triangles = triangles.ToArray();

        meshFilter.mesh = mesh;
    }


}
