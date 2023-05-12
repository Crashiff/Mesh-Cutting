using System.Collections.Generic;
using UnityEngine;

public class GeneratedMesh
{
    public List<Vector3> Vertices { get; set; } = new List<Vector3>();
    public List<Vector3> Normals { get; set; } = new List<Vector3>();
    public List<Vector2> UVs { get; set; } = new List<Vector2>();
    public List<List<int>> SubmeshIndices { get; set; } = new List<List<int>>();

    public void AddTriangle(MeshTriangle _triangle)
    {
        int currentVerticeCount = Vertices.Count;

        Vertices.AddRange(_triangle.Vertices);
        Normals.AddRange(_triangle.Normals);
        UVs.AddRange(_triangle.UVs);

        if (SubmeshIndices.Count < _triangle.SubmeshIndex + 1)
        {
            for (int i = SubmeshIndices.Count; i < _triangle.SubmeshIndex + 1; i++)
            {
                SubmeshIndices.Add(new List<int>());
            }
        }

        for (int i = 0; i < 3; i++)
        {
            SubmeshIndices[_triangle.SubmeshIndex].Add(currentVerticeCount + i);
        }
    }

    public void AddTriangle(Vector3[] _vertices, Vector3[] _normals, Vector2[] _uvs, int _submeshIndex, Vector4[] _tangents = null)
    {
        int currentVerticeCount = Vertices.Count;

        Vertices.AddRange(_vertices);
        Normals.AddRange(_normals);
        UVs.AddRange(_uvs);

        if (SubmeshIndices.Count < _submeshIndex + 1)
        {
            for (int i = SubmeshIndices.Count; i < _submeshIndex + 1; i++)
            {
                SubmeshIndices.Add(new List<int>());
            }
        }

        for (int i = 0; i < 3; i++)
        {
            SubmeshIndices[_submeshIndex].Add(currentVerticeCount + i);
        }
    }

    public Mesh GetGeneratedMesh()
    {
        Mesh mesh = new Mesh();
        mesh.SetVertices(Vertices);
        mesh.SetNormals(Normals);
        mesh.SetUVs(0, UVs);
        mesh.SetUVs(1, UVs);

        mesh.subMeshCount = SubmeshIndices.Count;
        for (int i = 0; i < SubmeshIndices.Count; i++)
        {
            mesh.SetTriangles(SubmeshIndices[i], i);
        }
        return mesh;
    }
}
