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
        if (help != null)
        {
            var dat = help.datas;
            for (int i = 0; i < dat.Count; i++)
            {
                int index = i + 1;
                dat[i].foldout = EditorGUILayout.Foldout(dat[i].foldout, "child"+index);
                if(dat[i].foldout)
                {
                    dat[i].localPosition = EditorGUILayout.Vector3Field("LocalPosition", dat[i].localPosition);
                    dat[i].Angle = EditorGUILayout.Vector3Field("LocalAngle", dat[i].Angle);
                    dat[i].localScale = EditorGUILayout.Vector3Field("LocalScale", dat[i].localScale);
                    dat[i].sizeDelta = EditorGUILayout.Vector2Field("SizeDelta", dat[i].sizeDelta);
                    dat[i].pivot = EditorGUILayout.Vector2Field("Pivot", dat[i].pivot);
                    dat[i].color = EditorGUILayout.ColorField(dat[i].color);
                    var o = EditorGUILayout.ObjectField(dat[i].sprite, typeof(Sprite), true);
                    dat[i].SetSprite(o as Sprite);
                    dat[i].fillAmount = EditorGUILayout.Slider(dat[i].fillAmount, 0, 1);
                    if (GUILayout.Button("Remove"))
                    {
                        dat.RemoveAt(i);
                        break;
                    }
                   
                }
            }
            help.Refresh();
        }
        if (GUILayout.Button("AddTrans"))
        {
            help.AddSon();
            help.Refresh();
        }
        serializedObject.ApplyModifiedProperties();
    }
    protected virtual void OnEnable()
    {
        (target as ShareImageHelper).ReLoad();
    }
}
