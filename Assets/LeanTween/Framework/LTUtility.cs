using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class LTUtility
{
    public static Vector3[] reverse(Vector3[] arr)
    {
        int length = arr.Length;
        int left = 0;
        int right = length - 1;

        for (; left < right; left += 1, right -= 1)
        {
            Vector3 temporary = arr[left];
            arr[left] = arr[right];
            arr[right] = temporary;
        }
        return arr;
    }
}
