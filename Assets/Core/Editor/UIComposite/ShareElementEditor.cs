﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ShareElementHelper), true)]
[CanEditMultipleObjects]
public class ShareElementEditor:Editor
{
    Vector3 pos;
    Vector3 angle;
    Vector2 size;
    Vector2 pivot;
    private Editor editor;
    private void OnEnable()
    {
        var trans = (target as ShareElementHelper).transform as RectTransform;
        pos = trans.localPosition;
        angle = trans.localEulerAngles;
        size = trans.sizeDelta;
        pivot = trans.pivot;
    }
    public override void OnInspectorGUI()
    {
        var help = target as ShareElementHelper;
        if(help!=null)
        {
            var col = help.color;
            help.color= EditorGUILayout.ColorField(col);
            var o = EditorGUILayout.ObjectField(help.sprite, typeof(Sprite), true);
            help.SetSprite(o as Sprite);
            help.fillAmount = EditorGUILayout.Slider(help.fillAmount, 0, 1);
        }
        bool changed = GUI.changed;
        if (GUILayout.Button("SetNativeSize"))
        {
            changed = true;
            help.SetNactiveSize();
        }
    
        var trans = help.transform as RectTransform;
        if(trans.localPosition!=pos)
        {
            pos = trans.localPosition;
            changed = trans;
        }
        if(trans.localEulerAngles!=angle)
        {
            angle = trans.localEulerAngles;
            changed = trans;
        }
        if(trans.sizeDelta!=size)
        {
            size = trans.sizeDelta;
            changed = trans;
        }
        if(trans.pivot!=pivot)
        {
            pivot = trans.pivot;
            changed = true;
        }
        if (changed)
        {
            RefreshParent(help.transform.parent);
        }
    }
    bool RefreshParent(Transform trans)
    {
        var help = trans.GetComponent<ShareImageHelper>();
        if(help!=null)
        {
            help.Refresh();
            var rect = (help.transform as RectTransform);
             var s=rect.sizeDelta;
            if(s.x>100)
                s.x--;
            else s.x++;
            rect.sizeDelta = s;
            return true;
        }else if(trans.parent!=null)
        {
            return RefreshParent(trans.parent);
        }
        return false;
    }
}
