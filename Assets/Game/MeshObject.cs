using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Game
{
    public class SubMesh
    {
        public Vector3[] vertex;
        public Vector2[] uv;
        public int[] tri;
    }
    public class MeshObject
    {
        public List<SubMesh> meshes = new List<SubMesh>();
        List<Vector3> vertex = new List<Vector3>();
        List<Vector2> uv = new List<Vector2>();
        List<int> tri = new List<int>();
        public void Complete()
        {
            vertex.Clear();
            uv.Clear();
            tri.Clear();
            int a = 0;
            for(int i=0;i<meshes.Count;i++)
            {
                var sub = meshes[i];
                vertex.AddRange(meshes[i].vertex);
                uv.AddRange(meshes[i].uv);
                var tmp = meshes[i].tri;
                for (int j = 0; j < tmp.Length; j++)
                    tri.Add(tmp[j] + a);
                a = vertex.Count;
            }
        }
    }
}
