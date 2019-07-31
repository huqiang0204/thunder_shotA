using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Game
{
    public class Effect
    {
        public Vector2 Position;
        public float Angle;
        public Vector3[] vertex;
        public Vector2[] uv;
        public virtual void Update() { }
    }
}
