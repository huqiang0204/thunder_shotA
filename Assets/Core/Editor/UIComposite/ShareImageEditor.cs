using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ShareImageHelper), true)]
[CanEditMultipleObjects]
public class ShareImageEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        var help = target as ShareImageHelper;
        EditorGUILayout.Space();
        serializedObject.Update();
        if (GUILayout.Button("AddTrans"))
        {
            help.AddSon();
            help.Refresh();
        }
        if(help!=null)
        {
            var dat = help.datas;
            for(int i=0;i<dat.Count;i++)
            {
                var v = EditorGUILayout.Vector3Field("LocalPosition", dat[i].localPosition);
                dat[i].localPosition = v;
                var a = EditorGUILayout.Vector3Field("LocalAngle", dat[i].Angle);
                dat[i].Angle = a;
                var s = EditorGUILayout.Vector3Field("LocalScale", dat[i].localScale);
                dat[i].localScale = s;
                var sd = EditorGUILayout.Vector2Field("SizeDelta", dat[i].sizeDelta);
                dat[i].sizeDelta = sd;
                var p = EditorGUILayout.Vector2Field("Pivot", dat[i].pivot);
                dat[i].pivot = p;
                var c = EditorGUILayout.ColorField( dat[i].color);
                dat[i].color= c;
                var o = EditorGUILayout.ObjectField(dat[i].sprite,typeof(Sprite),true);
                dat[i].SetSprite(o as Sprite);
                if (GUILayout.Button("Remove"))
                {
                    dat.RemoveAt(i);
                    break;
                }
            }
            help.Refresh();
        }
        serializedObject.ApplyModifiedProperties();
    }
}
