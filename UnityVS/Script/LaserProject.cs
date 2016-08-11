//#define unsafe
//#undef unsafe
//#define x64
//#undef x64
using UnityEngine;
using System.Collections.Generic;
using System;


namespace Assets.UnityVS.Script
{
    struct Point2T
    {
        public float x;
        public float y;
        public int tag;
        public Point2T(float x1, float y1, int t1) { x = x1; y = y1; tag = t1; }
    }
    class LaserProject : IDisposable
    {
        Point2T[] lineA , lineB , v_2 ,Vt1,Vt2 ,lineOut ,point_buff=new Point2T[100]; 
        float down, top, px, py, dx,dy;
        Vector3[] v3;
        Vector2[] uv2;
        int[] tri ;//32*3-6
        int len;
        public LaserProject(Vector2 [] uv_rect)
        {
            px = uv_rect[0].x;
            dx = uv_rect[3].x-px;
            py = uv_rect[0].y;
            dy = uv_rect[1].y-py;
            lineA = new Point2T[2];
            lineB = new Point2T[2];
            Vt1 = new Point2T[2];
            Vt2 = new Point2T[2];
            v_2 = new Point2T[2];
            v3 = new Vector3[128];
            uv2 = new Vector2[128];
            tri = new int[378];//len*3-6
            int c = 0;
            for(int i=0;i<378;i+=6)
            {
                tri[i] = c;
                tri[i + 1] = c + 1;
                tri[i + 2] = c + 3;
                tri[i + 3] = c;
                tri[i + 4] = c + 3;
                tri[i + 5] = c + 2;
                c += 2;
            }
        }
        public void SetLaser(Point2[] P, Point2 location)
        {
            lineOut = new Point2T[2];
            lineOut[0].tag = -1;
            lineOut[1].tag = -1;
            Vt1[0].x = P[0].x + location.x;
            down = Vt1[0].y = P[0].y + location.y;
            lineOut[0].x= Vt1[1].x = P[1].x + location.x;
            lineOut[1].y=lineOut[0].y= Vt1[1].y = P[1].y + location.y;
            lineOut[1].x=Vt2[0].x = P[3].x + location.x;
            Vt2[0].y = P[3].y + location.y;
            Vt2[1].x = P[2].x + location.x;
            top = Vt2[1].y = P[2].y + location.y;
        }
        bool V_LineProjectLine(ref Point2T[] VtA, ref Point2T[] B, ref Point2T O)//垂直线自底向上投影
        {
            Point2 VB = new Point2();
            VB.x = B[1].x - B[0].x;
            if (VB.x == 0)//垂直所以平行
                return false;
            VB.y = B[1].y - B[0].y;
            float x = (VtA[0].x - B[0].x) / VB.x;
            if (x >= 0 & x <= 1)
            {
                float y = VB.y * x + B[0].y;
                if (y > VtA[1].y)
                {
                    O.x = VtA[0].x;
                    O.y = y;
                    return true;
                }
            }
            return false;
        }
        bool LineToVerticalLine(ref Point2T[] VtA, ref Point2T[] B, ref Point2T O)//注意垂直线自底向上
        {
            Point2 VB = new Point2();
            VB.x = B[1].x - B[0].x;
            if (VB.x == 0)//垂直所以平行
                return false;
            VB.y = B[1].y - B[0].y;
            float x = (VtA[0].x - B[0].x) / VB.x;
            if (x >= 0 & x <= 1)
            {
                float y = VB.y * x + B[0].y;
                if (y >= VtA[0].y & y <= VtA[1].y)
                {
                    O.x = VtA[0].x;
                    O.y = y;
                    return true;
                }
            }
            return false;
        }
        bool LineToLine(ref Point2T[] A, ref Point2T[] B, ref Point2T O)//相交线相交点
        {
            float VAx = A[1].x - A[0].x;
            float VAy = A[1].y - A[0].y;
            float VBx = B[1].x - B[0].x;
            float VBy = B[1].y - B[0].y;
            //(V1.y*V2.x-V1.x*V2.y)
            float y = VAy * VBx - VAx * VBy;
            if (y == 0)
                return false;
            //((B.y-A.y)*V2.x+(A.x-B.x)*V2.y)
            float x = (B[0].y - A[0].y) * VBx + (A[0].x - B[0].x) * VBy;
            float d = x / y;
            if (d >= 0 & d <= 1)
            {
                if (VBx == 0)
                {
                    //x2=(A.y+x1*V1.y-B.y)/V2.y
                    y = (A[0].y - B[0].y + d * VAy) / VBy;
                }
                else
                {
                    //x2=(A.x+x1*V1.x-B.x)/V2.x
                    y = (A[0].x - B[0].x + d * VAx) / VBx;
                }
                //location.x=A.x+x1*V1.x
                //location.y=A.x+x1*V1.y
                if (y >= 0 & y <= 1)
                {
                    O.x = A[0].x + d * VAx;
                    O.y = A[0].y + d * VAy;
                    return true;
                }
            }
            return false;
        }
        int GetBottonLine(ref Point2T[] P, ref Point2T[] L)
        {
            float x = P[0].x;
            int index = 0;
            for (int i = 1; i < P.Length; i++)//找最左边的点
            {
                if (P[i].x < x)
                {
                    x = P[i].x;
                    index = i;
                }
                else if (P[i].x == x)
                {
                    if (P[i].y < P[index].y)
                        index = i;
                }
            }
            L[0] = P[index];
            int len = 0;
            if(index==0)
            {
                if (P[0].x < P[1].x)//正向
                {
                    if (P[0].x < P[P.Length - 1].x)
                        if (P[P.Length - 1].y < P[1].y)
                            goto label2;//反向
                    goto label1;
                }
                else//反向
                {
                    goto label2;
                }
            }
            else
            if (index == P.Length - 1)
            {
                if (P[index].x < P[0].x)//正向
                {
                    if (P[index].x < P[index - 1].x)
                        if (P[index - 1].y < P[0].y)
                            goto label2;//反向
                    goto label1;
                }
                else//反向
                {
                    goto label2;
                }
            }
            else
            {
                if (P[index].x < P[index + 1].x)//正向
                {
                    if (P[index].x < P[index - 1].x)
                        if (P[index - 1].y < P[index+ 1].y)
                            goto label2;//反向
                    goto label1;
                }
                else//反向
                {
                    goto label2;
                }
            }
        label1:
            int s = index + 1;
            for (int i = 0; i < P.Length; i++)
            {
                if (s >= P.Length - 1)
                    s = 0;
                if (P[s].x > L[len].x)
                {
                    len++;
                    L[len] = P[s];
                }
                else
                {
                    return len++;
                }
                s++;
            }
        label2:
            s = index - 1;
            for (int i = 0; i < P.Length; i++)
            {
                if (s < 0)
                    s = P.Length - 1;
                if (P[s].x > L[len].x)
                {
                    len++;
                    L[len] = P[s];
                }
                else
                {
                    return len++;
                }
                s--;
            }
            return 0;
        }
        bool GetTruncateLine(ref Point2T[] P)
        {
            Point2T[] L = new Point2T[P.Length];
            int top = GetBottonLine(ref P, ref L);
            Point2T[] tp = new Point2T[top + 2];
            int pc = 0;
            Point2T[] P1 = new Point2T[2];
            for (int i = 0; i < top; i++)
            {
                if (L[i].x > Vt1[0].x & L[i].x < Vt2[0].x)//point inside rect
                {
                    tp[pc] = L[i];
                    pc++;
                }
                P1[0] = L[i];
                P1[1] = L[i + 1];
                if (LineToVerticalLine(ref Vt1, ref P1, ref tp[pc]))
                {
                    pc++;
                }
                if (LineToVerticalLine(ref Vt2, ref P1, ref tp[pc]))
                {
                    pc++;
                    goto label1;
                }
            }
            if (L[top].x > Vt1[0].x & L[top].x < Vt2[0].x)//point inside rect
            {
                tp[pc] = L[top];
                pc++;
            }
        label1:
            if (pc < 2)
            {
                P = null;
                return false;
            }
            else
            {
                P = new Point2T[pc];
                for (int i = 0; i < pc; i++)
                    P[i] = tp[i];
                return true;
            }
        }
        void OverLine(ref Point2T[] lb)
        {
            Point2T tp = new Point2T();
            tp.tag = -1;
            int l1 = 1, l2 = 1,count=0;
            //lineC = new List<Point2T>();
            if (lineOut[0].x < lb[0].x)
            {
                point_buff[count] = lineOut[0]; count++;
            }
            else if (lineOut[0].x > lb[0].x)
            { point_buff[count] = lb[0]; count++; }
            lineA[0] = lineOut[0];
            lineA[1] = lineOut[1];

            lineB[0] = lb[0];
            lineB[1] = lb[1];
            while (l1 < lineOut.Length & l2 < lb.Length)
            {
                if (lineA[0].x > lineB[1].x)
                {
                    point_buff[count] = lineB[1];count++;
                    l2++;
                    if (l2 >= lb.Length)
                        break;
                    lineB[0] = lineB[1];
                    lineB[1] = lb[l2];
                }
                else if (lineB[0].x > lineA[1].x)
                {
                    point_buff[count] = lineA[1];count++;
                    l1++;
                    if (l1 >= lineOut.Length)
                        break;
                    lineA[0] = lineA[1];
                    lineA[1] = lineOut[l1];
                }
                else//project
                {
                    if (lineA[0].x == lineB[0].x)
                    {
                        if (lineA[0].y > lineB[0].y)
                        {
                            point_buff[count] = lineB[0];count++;
                        }
                        else
                        {
                            point_buff[count] = lineA[0];count++;
                        }
                    }
                    else
                    if (lineA[0].x > lineB[0].x)
                    {
                        v_2[0].x = lineA[0].x;
                        v_2[0].y = down;
                        v_2[1] = lineA[0];
                        if (V_LineProjectLine(ref v_2, ref lineB, ref tp))
                        {
                            if (l1 == 1)
                            {
                                point_buff[count] = tp;count++;
                            }
                            point_buff[count] = lineA[0];count++;
                        }
                    }
                    else
                    {
                        v_2[0].x = lineB[0].x;
                        v_2[0].y = down;
                        v_2[1] = lineB[0];
                        if (V_LineProjectLine(ref v_2, ref lineA, ref tp))
                        {
                            if (l2 == 1)
                            {
                                point_buff[count] = tp;count++;
                            }
                            point_buff[count] = lineB[0];count++;
                        }
                    }
                    if (LineToLine(ref lineA, ref lineB, ref tp))
                    {
                        if (lineA[1].y < lineB[1].y)
                            tp.tag = lineA[0].tag;
                        else tp.tag = lineB[0].tag;
                        point_buff[count] = tp;count++;
                    }
                    if (lineA[1].x == lineB[1].x)
                    {
                        l1++;
                        if (l1 >= lineOut.Length)
                            break;
                        lineA[0] = lineA[1];
                        lineA[1] = lineOut[l1];
                        l2++;
                        if (l2 >= lb.Length)
                            break;
                        lineB[0] = lineB[1];
                        lineB[1] = lb[l2];
                    }
                    else
                    if (lineA[1].x > lineB[1].x)
                    {
                        v_2[0].x = lineB[1].x;
                        v_2[0].y = down;
                        v_2[1] = lineB[1];
                        if (V_LineProjectLine(ref v_2, ref lineA, ref tp))
                        {
                            point_buff[count] = lineB[1];count++;
                            if (l2 == lb.Length - 1)
                            {
                                point_buff[count] = tp;count++;
                            }
                        }
                        l2++;
                        if (l2 >= lb.Length)
                            break;
                        lineB[0] = lineB[1];
                        lineB[1] = lb[l2];
                    }
                    else
                    {
                        v_2[0].x = lineA[1].x;
                        v_2[0].y = down;
                        v_2[1] = lineA[1];
                        if (V_LineProjectLine(ref v_2, ref lineB, ref tp))
                        {
                            point_buff[count] = lineA[1];count++;
                            if (l1 == lineOut.Length - 1)
                            { point_buff[count] = tp; count++; }
                        }
                        l1++;
                        if (l1 >= lineOut.Length)
                            break;
                        lineA[0] = lineA[1];
                        lineA[1] = lineOut[l1];
                    }
                    //}
                }
            }
            if (lineA[1].x == lineB[1].x)
            {
                if (lineA[1].y > lineB[1].y)
                 point_buff[count] = lineB[1]; 
                else point_buff[count] = lineA[1];
            }
            else if (lineA[1].x > lineB[1].x)
            {
                point_buff[count] = lineA[1];
            }
            else { point_buff[count] = lineB[1]; }
            count++;
            for (int i = l1 + 1; i < lineOut.Length; i++)
            {
                point_buff[count] = lineOut[i];
                count++;
            }
            for (int i = l2 + 1; i < lb.Length; i++)
            { point_buff[count] = lb[i];count++; }
            lineOut = new Point2T[count];
            for (int i = 0; i < count; i++)
                lineOut[i] = point_buff[i];
        }
        void LineToVertexs()
        {
            float high = top - down;
            float with = Vt2[0].x - Vt1[0].x;
            float x, y;
            int s = 0;
            for (int i = 0; i < lineOut.Length; i++)
            {
                v3[s].x = lineOut[i].x;
                v3[s].y = down;
                s++;
                v3[s].x = lineOut[i].x;
                v3[s].y = lineOut[i].y;
                s--;
                x = (lineOut[i].x - Vt1[0].x) / with*dx+px;
                uv2[s].x = x;
                uv2[s].y = py;
                s++;
                uv2[s].x = x;
                y= (lineOut[i].y - down) / high*dy+py;
                uv2[s].y = y;
                s++;
            }
            len = s;
        }
        public void ProjectRect(ref Point2[] p,int tag)
        {
            Point2T[] temp = new Point2T[p.Length];
            for (int i = 0; i < p.Length; i++)
            {
                temp[i].x = p[i].x;
                temp[i].y = p[i].y;
                temp[i].tag = tag;
            }
            if (GetTruncateLine(ref temp))
            {
                OverLine(ref temp);
            }
        }
        public int Complete(out Point2T[] p2t)
        {
            LineToVertexs();
            p2t = new Point2T[lineOut.Length];
            int count =0,tag;
            for(int i=0;i<lineOut.Length-1;i++)
            {
                tag = lineOut[i].tag;
                if (tag>-1)
                {
                    for(int c=0;c<count;c++)
                    {
                        if(tag==p2t[c].tag)
                        {
                            p2t[c].x += lineOut[i + 1].x - lineOut[i].x;
                            goto label1;
                        }
                    }
                    p2t[count].tag = tag;
                    p2t[count].x += lineOut[i + 1].x - lineOut[i].x;
                    count++;
                label1:;
                }
            }
            return count;
        }
        public void Dispose()
        {
            
        }
        public void UpdateMesh(ref Mesh mesh)
        {
            if (lineOut == null)
                return;
            //int len = lineOut.Length * 2;
            int s = len * 3 - 6;
            Vector3[] tv = new Vector3[len];
            mesh.triangles = null;
            for (int i = 0; i < len; i++)
                tv[i] = v3[i];
            mesh.vertices = tv;
            Vector2[] tu = new Vector2[len];
            mesh.triangles = null;
            for (int i = 0; i < len; i++)
                tu[i] = uv2[i];
            mesh.uv = tu;
            int[] tr = new int[s];
            for (int i = 0; i < s; i++)
                tr[i] = tri[i];
            mesh.triangles = tr;
            //#if unsafe
            //            unsafe
            //            {
            //                fixed (Vector3* vp = &v3[0])
            //                {
            //                    fixed (Vector2* up = &uv2[0])
            //                    {
            //                        fixed (int* p = &tri[0])
            //                        {
            //                            int* ivp = (int*)vp;
            //                            int* iup = (int*)up;
            //                            int* ip = p;
            //#if x64
            //                            ivp -= 2;
            //                            iup -= 2;
            //                            ip -= 2;
            //#else
            //                            ivp--;
            //                            iup--;
            //                            ip--;
            //#endif
            //                            *ivp = len;
            //                            *iup = len;
            //                            *ip = s;
            //                            mesh.triangles = null;
            //                            mesh.vertices = v3;
            //                            mesh.uv = uv2;
            //                            mesh.triangles = tri;
            //                            *ivp = 128;
            //                            *iup = 128;
            //                            *ip = 378;
            //                        }
            //                    }
            //                }
            //            }
            //#endif
        }
    }
}
