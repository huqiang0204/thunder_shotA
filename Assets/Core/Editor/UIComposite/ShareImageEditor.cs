using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UGUI;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ShareImageHelper), true)]
[CanEditMultipleObjects]
public class ShareImageEditor : Editor
{
    public void OnEnable()
    {
        (target as ShareImageHelper).Refresh();
    }
}
