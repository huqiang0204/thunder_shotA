using System;
using UnityEngine;

namespace Assets.UnityVS.Script
{
    class SP//StaticParameter
    {

        #region start points
        public static System.Random random = new System.Random();
        public static Point3[] S_RandomDown_1()
        {
            float x = (float)random.NextDouble() * 4 - 2;
            return new Point3[] { new Point3(x,6,0) };
        }
        public static readonly Point3[] S_Up_1 = new Point3[] {new Point3(-2,6,0) };
        public static readonly Point3[] S_Up_2 = new Point3[] { new Point3(-1,6,0)};
        public static readonly Point3[] S_Up_3 = new Point3[] { new Point3(0,7,0)};
        public static readonly Point3[] S_Up_4 = new Point3[] { new Point3(1,6,0)};
        public static readonly Point3[] S_Up_5 = new Point3[] {new Point3(2,6,0)};
        public static readonly Point3[] S_Dwon_2 = new Point3[] { new Point3(-1,6,0),new Point3(1,6,0)};
        public static readonly Point3[] S_Dwon_3 = new Point3[] { new Point3(-2, 6f, 0),new Point3(0,6,0),new Point3(2,6,0)};
        public static readonly Point3[] S_UpLeft_1 = new Point3[] { new Point3(-4,6,45) };
        public static readonly Point3[] S_UpRight_1 = new Point3[] { new Point3(4,6,315) };
        public static readonly Point3[] S_Left_1 = new Point3[] { new Point3(-4,4,90)};
        public static readonly Point3[] S_Left_2 = new Point3[] { new Point3(-4,4,90), new Point3(-4, 3, 90) };
        public static readonly Point3[] S_Right_1 = new Point3[] { new Point3(4,4,270)};
        public static readonly Point3[] S_Right_2 = new Point3[] { new Point3(4,4,270),new Point3(4,3,270)};
        #endregion

        #region zhuji
        public readonly static Vector2[][] uv_zhuji = new Vector2[][]{
            new Vector2[] { new Vector2(0.002439024f,0.1842105f),new Vector2(0.002439024f,0.991228f),new Vector2(0.1097561f,0.991228f),new Vector2(0.1097561f,0.1842105f)},
            new Vector2[] { new Vector2(0.1097561f, 0.1622807f), new Vector2(0.1097561f, 0.9868421f), new Vector2(0.2170732f, 0.9868421f), new Vector2(0.2170732f, 0.1622807f) },
            new Vector2[] { new Vector2(0.2195122f, 0f), new Vector2(0.2195122f, 1f), new Vector2(0.3365854f, 1f), new Vector2(0.3365854f, 0f) },
            new Vector2[] { new Vector2(0.3390244f, 0.1842105f), new Vector2(0.3390244f, 1f), new Vector2(0.5585366f, 1f), new Vector2(0.5585366f, 0.1842105f) },
            new Vector2[] { new Vector2(0.5609756f, 0.004385965f), new Vector2(0.5609756f, 1f), new Vector2(0.7902439f, 1f), new Vector2(0.7902439f, 0.004385965f) },
            new Vector2[] { new Vector2(0.7902439f, 0f), new Vector2(0.7902439f, 1f), new Vector2(1f, 1f), new Vector2(1f, 0f) }
        };
        public readonly static Point2[][] p_zhuji = new Point2[][]
        {
            new Point2[] {new Point2(167f, 0.7390146f), new Point2(13f, 0.7390146f), new Point2(347f, 0.7390146f), new Point2(193f, 0.7390146f) },
            new Point2[] { new Point2(167f, 0.7542199f), new Point2(13f, 0.7542199f), new Point2(347f, 0.7542199f), new Point2(193f, 0.7542199f)},
            new Point2[] { new Point2(168f, 0.9101478f), new Point2(12f, 0.9101478f), new Point2(348f, 0.9101478f), new Point2(192f, 0.9101478f) },
            new Point2[] { new Point2(154f, 0.8071489f), new Point2(26f, 0.8071489f), new Point2(334f, 0.8071489f),  new Point2(206f, 0.8071489f) },
            new Point2[] { new Point2(158f, 0.9597379f), new Point2(22f, 0.9597379f), new Point2(338f, 0.9597379f), new Point2(202f, 0.9597379f)},
            new Point2[] { new Point2(159f, 0.9518754f), new Point2(21f, 0.9518754f), new Point2(339f, 0.9518754f),  new Point2(201f, 0.9518754f) }
        };
        #endregion

        #region zhihui
        public readonly static Vector2[][] uv_zhihui = new Vector2[][] {
            new Vector2[] {new Vector2(0f,0f),new Vector2(0f,1f),new Vector2(0.5217391f,1f),new Vector2(0.5217391f,0f)},
            new Vector2[] { new Vector2(0.5163044f, 0.1386861f), new Vector2(0.5163044f, 1f), new Vector2(0.9076087f, 1f), new Vector2(0.9076087f, 0.1386861f) }
        };
        public readonly static Point2[][] p_zhihui = new Point2[][] {
            new Point2[] { new Point2(167f,1.644879f),new Point2(13f,1.652487f),new Point2(347f,1.652487f),new Point2(193f,1.644879f)},
            new Point2[] { new Point2(169f, 1.411124f), new Point2(11f, 1.411124f), new Point2(349f, 1.411124f), new Point2(191f, 1.411124f) }
        };
        public readonly static Point2[] e_w_zhihui = new Point2[] { new Point2(180f, 0.5234375f), new Point2(22f, 0.396056f), new Point2(0f, 1.15625f), new Point2(338f, 0.396056f)};
        #endregion

        #region angle table 精度1
        public static readonly Point2[] a_t_s_c_360 = new Point2[]{new Point2(0f, 1f),
new Point2(-0.01745241f, 0.9998477f),new Point2(-0.0348995f, 0.9993908f),new Point2(-0.05233596f, 0.9986295f),new Point2(-0.06975647f, 0.9975641f),new Point2(-0.08715574f, 0.9961947f),new Point2(-0.1045285f, 0.9945219f),new Point2(-0.1218693f, 0.9925461f),new Point2(-0.1391731f, 0.9902681f),new Point2(-0.1564345f, 0.9876884f),new Point2(-0.1736482f, 0.9848077f),
new Point2(-0.190809f, 0.9816272f),new Point2(-0.2079117f, 0.9781476f),new Point2(-0.224951f, 0.9743701f),new Point2(-0.2419219f, 0.9702957f),new Point2(-0.258819f, 0.9659258f),new Point2(-0.2756374f, 0.9612617f),new Point2(-0.2923717f, 0.9563048f),new Point2(-0.309017f, 0.9510565f),new Point2(-0.3255681f, 0.9455186f),new Point2(-0.3420201f, 0.9396926f),
new Point2(-0.3583679f, 0.9335804f),new Point2(-0.3746066f, 0.9271839f),new Point2(-0.3907311f, 0.9205049f),new Point2(-0.4067366f, 0.9135455f),new Point2(-0.4226183f, 0.9063078f),new Point2(-0.4383712f, 0.8987941f),new Point2(-0.4539905f, 0.8910065f),new Point2(-0.4694716f, 0.8829476f),new Point2(-0.4848096f, 0.8746197f),new Point2(-0.5f, 0.8660254f),
new Point2(-0.5150381f, 0.8571673f),new Point2(-0.5299193f, 0.8480481f),new Point2(-0.5446391f, 0.8386706f),new Point2(-0.5591929f, 0.8290376f),new Point2(-0.5735765f, 0.8191521f),new Point2(-0.5877852f, 0.809017f),new Point2(-0.601815f, 0.7986355f),new Point2(-0.6156615f, 0.7880108f),new Point2(-0.6293204f, 0.7771459f),new Point2(-0.6427876f, 0.7660444f),
new Point2(-0.656059f, 0.7547096f),new Point2(-0.6691306f, 0.7431448f),new Point2(-0.6819984f, 0.7313537f),new Point2(-0.6946584f, 0.7193398f),new Point2(-0.7071068f, 0.7071068f),new Point2(-0.7193398f, 0.6946584f),new Point2(-0.7313537f, 0.6819984f),new Point2(-0.7431448f, 0.6691306f),new Point2(-0.7547095f, 0.656059f),new Point2(-0.7660444f, 0.6427876f),
new Point2(-0.7771459f, 0.6293204f),new Point2(-0.7880107f, 0.6156615f),new Point2(-0.7986355f, 0.601815f),new Point2(-0.809017f, 0.5877853f),new Point2(-0.8191521f, 0.5735765f),new Point2(-0.8290375f, 0.5591929f),new Point2(-0.8386706f, 0.5446391f),new Point2(-0.8480481f, 0.5299193f),new Point2(-0.8571673f, 0.5150381f),new Point2(-0.8660254f, 0.5f),
new Point2(-0.8746197f, 0.4848097f),new Point2(-0.8829476f, 0.4694716f),new Point2(-0.8910065f, 0.4539905f),new Point2(-0.8987941f, 0.4383712f),new Point2(-0.9063078f, 0.4226182f),new Point2(-0.9135455f, 0.4067366f),new Point2(-0.9205048f, 0.3907312f),new Point2(-0.9271839f, 0.3746066f),new Point2(-0.9335804f, 0.358368f),new Point2(-0.9396926f, 0.3420202f),
new Point2(-0.9455186f, 0.3255681f),new Point2(-0.9510565f, 0.309017f),new Point2(-0.9563047f, 0.2923718f),new Point2(-0.9612617f, 0.2756374f),new Point2(-0.9659258f, 0.2588191f),new Point2(-0.9702957f, 0.2419219f),new Point2(-0.9743701f, 0.224951f),new Point2(-0.9781476f, 0.2079117f),new Point2(-0.9816272f, 0.1908091f),new Point2(-0.9848077f, 0.1736482f),
new Point2(-0.9876884f, 0.1564345f),new Point2(-0.9902681f, 0.1391731f),new Point2(-0.9925461f, 0.1218693f),new Point2(-0.9945219f, 0.1045284f),new Point2(-0.9961947f, 0.0871558f),new Point2(-0.9975641f, 0.06975651f),new Point2(-0.9986295f, 0.05233597f),new Point2(-0.9993908f, 0.0348995f),new Point2(-0.9998477f, 0.01745238f),new Point2(-1f, 0),
new Point2(-0.9998477f, -0.01745235f),new Point2(-0.9993908f, -0.03489946f),new Point2(-0.9986295f, -0.05233594f),new Point2(-0.9975641f, -0.06975648f),new Point2(-0.9961947f, -0.08715577f),new Point2(-0.9945219f, -0.1045284f),new Point2(-0.9925461f, -0.1218693f),new Point2(-0.9902681f, -0.1391731f),new Point2(-0.9876884f, -0.1564344f),new Point2(-0.9848077f, -0.1736482f),
new Point2(-0.9816272f, -0.190809f),new Point2(-0.9781476f, -0.2079116f),new Point2(-0.9743701f, -0.224951f),new Point2(-0.9702957f, -0.2419219f),new Point2(-0.9659258f, -0.258819f),new Point2(-0.9612617f, -0.2756374f),new Point2(-0.9563047f, -0.2923717f),new Point2(-0.9510565f, -0.3090169f),new Point2(-0.9455186f, -0.3255681f),new Point2(-0.9396926f, -0.3420201f),
new Point2(-0.9335805f, -0.3583679f),new Point2(-0.9271839f, -0.3746066f),new Point2(-0.9205049f, -0.3907312f),new Point2(-0.9135455f, -0.4067366f),new Point2(-0.9063078f, -0.4226183f),new Point2(-0.8987941f, -0.4383711f),new Point2(-0.8910066f, -0.4539904f),new Point2(-0.8829476f, -0.4694716f),new Point2(-0.8746197f, -0.4848095f),new Point2(-0.8660254f, -0.5000001f),
new Point2(-0.8571673f, -0.515038f),new Point2(-0.8480482f, -0.5299191f),new Point2(-0.8386706f, -0.5446391f),new Point2(-0.8290376f, -0.5591928f),new Point2(-0.819152f, -0.5735765f),new Point2(-0.809017f, -0.5877852f),new Point2(-0.7986355f, -0.6018151f),new Point2(-0.7880108f, -0.6156614f),new Point2(-0.777146f, -0.6293203f),new Point2(-0.7660444f, -0.6427876f),
new Point2(-0.7547096f, -0.656059f),new Point2(-0.7431448f, -0.6691307f),new Point2(-0.7313537f, -0.6819983f),new Point2(-0.7193399f, -0.6946583f),new Point2(-0.7071068f, -0.7071068f),new Point2(-0.6946585f, -0.7193397f),new Point2(-0.6819983f, -0.7313538f),new Point2(-0.6691306f, -0.7431448f),new Point2(-0.656059f, -0.7547097f),new Point2(-0.6427876f, -0.7660444f),
new Point2(-0.6293205f, -0.7771459f),new Point2(-0.6156614f, -0.7880108f),new Point2(-0.6018151f, -0.7986355f),new Point2(-0.5877852f, -0.8090171f),new Point2(-0.5735765f, -0.8191521f),new Point2(-0.559193f, -0.8290375f),new Point2(-0.5446391f, -0.8386706f),new Point2(-0.5299193f, -0.848048f),new Point2(-0.515038f, -0.8571673f),new Point2(-0.5000001f, -0.8660254f),
new Point2(-0.4848098f, -0.8746197f),new Point2(-0.4694716f, -0.8829476f),new Point2(-0.4539906f, -0.8910065f),new Point2(-0.4383711f, -0.8987941f),new Point2(-0.4226183f, -0.9063078f),new Point2(-0.4067366f, -0.9135455f),new Point2(-0.3907312f, -0.9205049f),new Point2(-0.3746067f, -0.9271838f),new Point2(-0.3583679f, -0.9335805f),new Point2(-0.3420202f, -0.9396926f),
new Point2(-0.3255681f, -0.9455186f),new Point2(-0.309017f, -0.9510565f),new Point2(-0.2923718f, -0.9563047f),new Point2(-0.2756374f, -0.9612617f),new Point2(-0.2588191f, -0.9659258f),new Point2(-0.2419219f, -0.9702957f),new Point2(-0.2249511f, -0.9743701f),new Point2(-0.2079116f, -0.9781476f),new Point2(-0.190809f, -0.9816272f),new Point2(-0.1736483f, -0.9848077f),
new Point2(-0.1564344f, -0.9876884f),new Point2(-0.1391732f, -0.9902681f),new Point2(-0.1218693f, -0.9925461f),new Point2(-0.1045285f, -0.9945219f),new Point2(-0.08715588f, -0.9961947f),new Point2(-0.06975647f, -0.9975641f),new Point2(-0.05233605f, -0.9986295f),new Point2(-0.03489945f, -0.9993908f),new Point2(-0.01745246f, -0.9998477f),new Point2(0, -1f),
new Point2(0.01745239f, -0.9998477f),new Point2(0.03489939f, -0.9993908f),new Point2(0.05233599f, -0.9986295f),new Point2(0.0697564f, -0.9975641f),new Point2(0.08715581f, -0.9961947f),new Point2(0.1045284f, -0.9945219f),new Point2(0.1218692f, -0.9925461f),new Point2(0.1391731f, -0.9902681f),new Point2(0.1564344f, -0.9876884f),new Point2(0.1736482f, -0.9848077f),
new Point2(0.190809f, -0.9816272f),new Point2(0.2079116f, -0.9781476f),new Point2(0.224951f, -0.9743701f),new Point2(0.2419218f, -0.9702957f),new Point2(0.2588191f, -0.9659258f),new Point2(0.2756373f, -0.9612617f),new Point2(0.2923718f, -0.9563047f),new Point2(0.309017f, -0.9510565f),new Point2(0.3255681f, -0.9455186f),new Point2(0.3420202f, -0.9396926f),
new Point2(0.3583679f, -0.9335805f),new Point2(0.3746066f, -0.9271838f),new Point2(0.3907311f, -0.9205049f),new Point2(0.4067365f, -0.9135455f),new Point2(0.4226183f, -0.9063078f),new Point2(0.4383711f, -0.8987941f),new Point2(0.4539905f, -0.8910065f),new Point2(0.4694715f, -0.8829476f),new Point2(0.4848095f, -0.8746198f),new Point2(0.5f, -0.8660254f),
new Point2(0.515038f, -0.8571674f),new Point2(0.5299193f, -0.8480481f),new Point2(0.544639f, -0.8386706f),new Point2(0.559193f, -0.8290375f),new Point2(0.5735764f, -0.8191521f),new Point2(0.5877851f, -0.8090171f),new Point2(0.601815f, -0.7986355f),new Point2(0.6156614f, -0.7880108f),new Point2(0.6293204f, -0.7771459f),new Point2(0.6427876f, -0.7660445f),
new Point2(0.6560589f, -0.7547097f),new Point2(0.6691306f, -0.7431448f),new Point2(0.6819983f, -0.7313538f),new Point2(0.6946584f, -0.7193398f),new Point2(0.7071067f, -0.7071068f),new Point2(0.7193398f, -0.6946583f),new Point2(0.7313537f, -0.6819984f),new Point2(0.7431448f, -0.6691307f),new Point2(0.7547096f, -0.656059f),new Point2(0.7660446f, -0.6427875f),
new Point2(0.777146f, -0.6293203f),new Point2(0.7880107f, -0.6156615f),new Point2(0.7986354f, -0.6018152f),new Point2(0.8090168f, -0.5877854f),new Point2(0.8191521f, -0.5735763f),new Point2(0.8290376f, -0.5591929f),new Point2(0.8386706f, -0.5446391f),new Point2(0.848048f, -0.5299194f),new Point2(0.8571672f, -0.5150383f),new Point2(0.8660254f, -0.4999999f),
new Point2(0.8746197f, -0.4848096f),new Point2(0.8829476f, -0.4694716f),new Point2(0.8910065f, -0.4539907f),new Point2(0.8987939f, -0.4383714f),new Point2(0.9063078f, -0.4226182f),new Point2(0.9135454f, -0.4067366f),new Point2(0.9205048f, -0.3907312f),new Point2(0.9271838f, -0.3746068f),new Point2(0.9335805f, -0.3583678f),new Point2(0.9396927f, -0.3420201f),
new Point2(0.9455186f, -0.3255682f),new Point2(0.9510565f, -0.3090171f),new Point2(0.9563047f, -0.2923719f),new Point2(0.9612617f, -0.2756372f),new Point2(0.9659259f, -0.258819f),new Point2(0.9702957f, -0.2419219f),new Point2(0.9743701f, -0.2249512f),new Point2(0.9781476f, -0.2079119f),new Point2(0.9816272f, -0.1908088f),new Point2(0.9848078f, -0.1736481f),
new Point2(0.9876883f, -0.1564345f),new Point2(0.9902681f, -0.1391733f),new Point2(0.9925461f, -0.1218696f),new Point2(0.9945219f, -0.1045283f),new Point2(0.9961947f, -0.08715571f),new Point2(0.997564f, -0.06975655f),new Point2(0.9986295f, -0.05233612f),new Point2(0.9993908f, -0.03489976f),new Point2(0.9998477f, -0.0174523f),new Point2(1f, 0f),
new Point2(0.9998477f, 0.01745232f),new Point2(0.9993908f, 0.03489931f),new Point2(0.9986296f, 0.05233567f),new Point2(0.997564f, 0.06975657f),new Point2(0.9961947f, 0.08715574f),new Point2(0.9945219f, 0.1045284f),new Point2(0.9925462f, 0.1218691f),new Point2(0.9902681f, 0.1391733f),new Point2(0.9876883f, 0.1564345f),new Point2(0.9848077f, 0.1736481f),
new Point2(0.9816272f, 0.1908089f),new Point2(0.9781476f, 0.2079115f),new Point2(0.97437f, 0.2249512f),new Point2(0.9702957f, 0.2419219f),new Point2(0.9659258f, 0.258819f),new Point2(0.9612617f, 0.2756372f),new Point2(0.9563048f, 0.2923715f),new Point2(0.9510565f, 0.3090171f),new Point2(0.9455186f, 0.3255682f),new Point2(0.9396926f, 0.3420201f),
new Point2(0.9335805f, 0.3583678f),new Point2(0.9271839f, 0.3746064f),new Point2(0.9205048f, 0.3907312f),new Point2(0.9135454f, 0.4067367f),new Point2(0.9063078f, 0.4226182f),new Point2(0.8987941f, 0.438371f),new Point2(0.8910066f, 0.4539903f),new Point2(0.8829476f, 0.4694717f),new Point2(0.8746197f, 0.4848096f),new Point2(0.8660254f, 0.4999999f),
new Point2(0.8571674f, 0.5150379f),new Point2(0.8480483f, 0.529919f),new Point2(0.8386705f, 0.5446391f),new Point2(0.8290376f, 0.5591929f),new Point2(0.8191521f, 0.5735763f),new Point2(0.8090171f, 0.5877851f),new Point2(0.7986354f, 0.6018152f),new Point2(0.7880107f, 0.6156615f),new Point2(0.777146f, 0.6293204f),new Point2(0.7660445f, 0.6427875f),
new Point2(0.7547097f, 0.6560588f),new Point2(0.7431448f, 0.6691307f),new Point2(0.7313536f, 0.6819984f),new Point2(0.7193398f, 0.6946583f),new Point2(0.7071069f, 0.7071066f),new Point2(0.6946585f, 0.7193396f),new Point2(0.6819983f, 0.7313538f),new Point2(0.6691306f, 0.7431449f),new Point2(0.6560591f, 0.7547095f),new Point2(0.6427878f, 0.7660443f),
new Point2(0.6293206f, 0.7771458f),new Point2(0.6156614f, 0.7880108f),new Point2(0.601815f, 0.7986355f),new Point2(0.5877853f, 0.8090169f),new Point2(0.5735766f, 0.8191519f),new Point2(0.5591931f, 0.8290374f),new Point2(0.5446389f, 0.8386706f),new Point2(0.5299193f, 0.8480481f),new Point2(0.5150381f, 0.8571672f),new Point2(0.5000002f, 0.8660253f),
new Point2(0.4848099f, 0.8746195f),new Point2(0.4694715f, 0.8829476f),new Point2(0.4539905f, 0.8910065f),new Point2(0.4383712f, 0.898794f),new Point2(0.4226184f, 0.9063077f),new Point2(0.4067365f, 0.9135455f),new Point2(0.3907311f, 0.9205049f),new Point2(0.3746066f, 0.9271839f),new Point2(0.3583681f, 0.9335804f),new Point2(0.3420204f, 0.9396926f),
new Point2(0.325568f, 0.9455186f),new Point2(0.3090169f, 0.9510565f),new Point2(0.2923717f, 0.9563047f),new Point2(0.2756375f, 0.9612616f),new Point2(0.2588193f, 0.9659258f),new Point2(0.2419218f, 0.9702958f),new Point2(0.224951f, 0.9743701f),new Point2(0.2079118f, 0.9781476f),new Point2(0.1908092f, 0.9816272f),new Point2(0.1736484f, 0.9848077f),
new Point2(0.1564344f, 0.9876884f),new Point2(0.1391731f, 0.9902681f),new Point2(0.1218694f, 0.9925461f),new Point2(0.1045287f, 0.9945219f),new Point2(0.08715603f, 0.9961947f),new Point2(0.06975638f, 0.9975641f),new Point2(0.05233596f, 0.9986295f),new Point2(0.0348996f, 0.9993908f),new Point2(0.01745261f, 0.9998477f),new Point2(0f, 1f),};
        #endregion

        #region angle tabe 精度0.1
        static readonly float[] a_t_s_900 = new float[] 
        { 0,0.001745329f,0.003490653f,0.005235966f,0.006981263f,0.008726539f,0.01047179f,0.01221701f,0.01396219f,0.01570733f,0.01745242f,0.01919745f,0.02094243f,0.02268735f,0.02443219f,0.02617696f,0.02792165f,0.02966626f,0.03141078f,0.0331552f,0.03489951f,0.03664372f,0.03838783f,0.04013181f,0.04187567f,0.0436194f,0.045363f,0.04710646f,0.04884978f,0.05059295f,0.05233597f,0.05407882f,0.05582151f,0.05756404f,0.05930638f,0.06104854f,0.06279052f,0.06453231f,0.06627391f,0.06801529f,0.06975647f,0.07149745f,0.0732382f,0.07497873f,0.07671903f,0.0784591f,0.08019892f,0.08193851f,0.08367784f,0.08541692f,0.08715574f,0.08889429f,0.09063257f,0.09237058f,0.09410831f,0.09584574f,0.09758289f,0.09931974f,0.1010563f,0.1027925f,0.1045284f,0.1062641f,0.1079993f,0.1097343f,0.1114689f,0.1132032f,0.1149371f,0.1166707f,0.1184039f,0.1201368f,0.1218693f,0.1236015f,0.1253332f,0.1270646f,0.1287956f,0.1305262f,0.1322564f,0.1339862f,0.1357155f,0.1374445f,0.1391731f,0.1409012f,0.1426289f,0.1443562f,0.146083f,0.1478094f,0.1495353f,0.1512608f,0.1529859f,0.1547104f,0.1564345f,0.1581581f,0.1598812f,0.1616039f,0.163326f,0.1650477f,0.1667688f,0.1684895f,0.1702096f,0.1719292f,0.1736483f,0.1753668f,0.1770849f,0.1788023f,0.1805193f,0.1822357f,0.1839515f,0.1856668f,0.1873815f,0.1890956f,0.1908092f,0.1925222f,0.1942345f,0.1959463f,0.1976575f,0.1993681f,0.2010781f,0.2027875f,0.2044963f,0.2062044f,0.2079119f,0.2096188f,0.2113251f,0.2130307f,0.2147356f,0.2164399f,0.2181435f,0.2198465f,0.2215488f,0.2232504f,0.2249514f,0.2266516f,0.2283512f,0.2300501f,0.2317483f,0.2334457f,0.2351425f,0.2368385f,0.2385338f,0.2402284f,0.2419223f,0.2436154f,0.2453078f,0.2469994f,0.2486903f,0.2503804f,0.2520698f,0.2537584f,0.2554462f,0.2571332f,0.2588195f,0.260505f,0.2621897f,0.2638735f,0.2655566f,0.2672389f,0.2689203f,0.2706009f,0.2722808f,0.2739597f,0.2756379f,0.2773152f,0.2789916f,0.2806672f,0.282342f,0.2840159f,0.2856889f,0.2873611f,0.2890324f,0.2907028f,0.2923723f,0.2940409f,0.2957087f,0.2973755f,0.2990414f,0.3007064f,0.3023705f,0.3040337f,0.305696f,0.3073573f,0.3090177f,0.3106771f,0.3123356f,0.3139931f,0.3156497f,0.3173054f,0.31896f,0.3206137f,0.3222664f,0.3239181f,0.3255689f,0.3272186f,0.3288674f,0.3305151f,0.3321619f,0.3338076f,0.3354523f,0.337096f,0.3387387f,0.3403803f,0.3420209f,0.3436605f,0.345299f,0.3469365f,0.3485729f,0.3502082f,0.3518425f,0.3534757f,0.3551078f,0.3567389f,0.3583688f,0.3599977f,0.3616254f,0.3632521f,0.3648777f,0.3665021f,0.3681254f,0.3697477f,0.3713687f,0.3729887f,0.3746075f,0.3762252f,0.3778417f,0.3794571f,0.3810713f,0.3826844f,0.3842963f,0.385907f,0.3875166f,0.3891249f,0.3907321f,0.3923381f,0.3939429f,0.3955465f,0.3971489f,0.3987501f,0.4003501f,0.4019488f,0.4035463f,0.4051426f,0.4067377f,0.4083315f,0.4099241f,0.4115154f,0.4131055f,0.4146943f,0.4162819f,0.4178682f,0.4194532f,0.4210369f,0.4226194f,0.4242005f,0.4257804f,0.427359f,0.4289362f,0.4305122f,0.4320869f,0.4336602f,0.4352323f,0.436803f,0.4383723f,0.4399403f,0.441507f,0.4430724f,0.4446364f,0.446199f,0.4477603f,0.4493202f,0.4508787f,0.4524359f,0.4539917f,0.4555461f,0.4570991f,0.4586508f,0.460201f,0.4617499f,0.4632973f,0.4648433f,0.4663879f,0.4679311f,0.4694728f,0.4710132f,0.472552f,0.4740895f,0.4756255f,0.4771601f,0.4786932f,0.4802248f,0.481755f,0.4832837f,0.4848109f,0.4863367f,0.487861f,0.4893838f,0.4909051f,0.4924249f,0.4939432f,0.49546f,0.4969753f,0.4984891f,0.5000014f,0.5015121f,0.5030213f,0.504529f,0.5060351f,0.5075397f,0.5090428f,0.5105443f,0.5120443f,0.5135427f,0.5150395f,0.5165347f,0.5180284f,0.5195205f,0.5210111f,0.5225f,0.5239874f,0.5254731f,0.5269573f,0.5284398f,0.5299207f,0.5314f,0.5328777f,0.5343537f,0.5358281f,0.5373009f,0.5387721f,0.5402416f,0.5417095f,0.5431757f,0.5446402f,0.5461031f,0.5475644f,0.549024f,0.5504819f,0.5519381f,0.5533926f,0.5548455f,0.5562966f,0.5577461f,0.5591939f,0.56064f,0.5620843f,0.563527f,0.5649679f,0.5664071f,0.5678446f,0.5692803f,0.5707144f,0.5721467f,0.5735772f,0.575006f,0.576433f,0.5778583f,0.5792819f,0.5807036f,0.5821236f,0.5835418f,0.5849583f,0.5863729f,0.5877858f,0.5891969f,0.5906062f,0.5920137f,0.5934193f,0.5948232f,0.5962253f,0.5976256f,0.5990239f,0.6004206f,0.6018153f,0.6032083f,0.6045994f,0.6059887f,0.6073761f,0.6087617f,0.6101454f,0.6115272f,0.6129072f,0.6142853f,0.6156616f,0.617036f,0.6184084f,0.6197791f,0.6211478f,0.6225147f,0.6238796f,0.6252427f,0.6266038f,0.627963f,0.6293203f,0.6306757f,0.6320292f,0.6333807f,0.6347303f,0.6360781f,0.6374238f,0.6387676f,0.6401095f,0.6414494f,0.6427873f,0.6441233f,0.6454574f,0.6467894f,0.6481195f,0.6494477f,0.6507738f,0.652098f,0.6534202f,0.6547403f,0.6560585f,0.6573747f,0.658689f,0.6600012f,0.6613113f,0.6626195f,0.6639256f,0.6652297f,0.6665319f,0.6678319f,0.66913f,0.670426f,0.6717199f,0.6730118f,0.6743016f,0.6755894f,0.6768752f,0.6781589f,0.6794405f,0.68072f,0.6819975f,0.6832729f,0.6845462f,0.6858175f,0.6870866f,0.6883537f,0.6896186f,0.6908814f,0.6921422f,0.6934009f,0.6946574f,0.6959118f,0.6971641f,0.6984142f,0.6996623f,0.7009082f,0.702152f,0.7033936f,0.7046331f,0.7058704f,0.7071056f,0.7083386f,0.7095695f,0.7107983f,0.7120248f,0.7132492f,0.7144714f,0.7156914f,0.7169093f,0.718125f,0.7193385f,0.7205498f,0.7217588f,0.7229658f,0.7241704f,0.725373f,0.7265732f,0.7277713f,0.7289672f,0.7301608f,0.7313522f,0.7325414f,0.7337283f,0.7349131f,0.7360955f,0.7372758f,0.7384537f,0.7396295f,0.740803f,0.7419742f,0.7431432f,0.7443099f,0.7454743f,0.7466365f,0.7477964f,0.748954f,0.7501094f,0.7512624f,0.7524132f,0.7535616f,0.7547078f,0.7558517f,0.7569932f,0.7581325f,0.7592695f,0.7604041f,0.7615365f,0.7626665f,0.7637941f,0.7649195f,0.7660425f,0.7671632f,0.7682816f,0.7693976f,0.7705113f,0.7716226f,0.7727316f,0.7738382f,0.7749425f,0.7760444f,0.777144f,0.7782411f,0.7793359f,0.7804283f,0.7815184f,0.7826061f,0.7836913f,0.7847742f,0.7858548f,0.7869329f,0.7880086f,0.7890819f,0.7901528f,0.7912214f,0.7922875f,0.7933511f,0.7944124f,0.7954713f,0.7965277f,0.7975817f,0.7986333f,0.7996824f,0.8007291f,0.8017734f,0.8028152f,0.8038546f,0.8048915f,0.805926f,0.806958f,0.8079876f,0.8090146f,0.8100393f,0.8110614f,0.8120812f,0.8130984f,0.8141131f,0.8151254f,0.8161352f,0.8171425f,0.8181473f,0.8191496f,0.8201494f,0.8211467f,0.8221416f,0.8231339f,0.8241237f,0.825111f,0.8260958f,0.827078f,0.8280578f,0.829035f,0.8300098f,0.8309819f,0.8319516f,0.8329187f,0.8338833f,0.8348453f,0.8358048f,0.8367617f,0.8377161f,0.838668f,0.8396173f,0.840564f,0.8415082f,0.8424498f,0.8433888f,0.8443253f,0.8452592f,0.8461905f,0.8471193f,0.8480454f,0.848969f,0.84989f,0.8508084f,0.8517243f,0.8526375f,0.8535481f,0.8544561f,0.8553615f,0.8562644f,0.8571646f,0.8580621f,0.8589572f,0.8598495f,0.8607393f,0.8616264f,0.8625109f,0.8633928f,0.8642721f,0.8651487f,0.8660226f,0.8668939f,0.8677627f,0.8686287f,0.8694921f,0.8703529f,0.871211f,0.8720664f,0.8729193f,0.8737694f,0.8746169f,0.8754617f,0.8763039f,0.8771433f,0.8779802f,0.8788143f,0.8796457f,0.8804745f,0.8813006f,0.882124f,0.8829448f,0.8837628f,0.8845781f,0.8853908f,0.8862007f,0.887008f,0.8878125f,0.8886144f,0.8894135f,0.8902099f,0.8910037f,0.8917947f,0.892583f,0.8933685f,0.8941513f,0.8949315f,0.8957089f,0.8964835f,0.8972555f,0.8980247f,0.8987911f,0.8995549f,0.9003159f,0.9010741f,0.9018297f,0.9025824f,0.9033324f,0.9040797f,0.9048241f,0.9055659f,0.9063049f,0.9070411f,0.9077746f,0.9085053f,0.9092332f,0.9099584f,0.9106808f,0.9114004f,0.9121172f,0.9128313f,0.9135426f,0.9142511f,0.9149568f,0.9156597f,0.9163598f,0.9170572f,0.9177517f,0.9184435f,0.9191325f,0.9198186f,0.9205019f,0.9211825f,0.9218603f,0.9225352f,0.9232073f,0.9238766f,0.9245431f,0.9252068f,0.9258677f,0.9265258f,0.927181f,0.9278334f,0.9284829f,0.9291297f,0.9297736f,0.9304147f,0.931053f,0.9316884f,0.932321f,0.9329507f,0.9335776f,0.9342017f,0.9348229f,0.9354412f,0.9360567f,0.9366694f,0.9372792f,0.9378861f,0.9384902f,0.9390914f,0.9396898f,0.9402853f,0.940878f,0.9414678f,0.9420547f,0.9426388f,0.9432199f,0.9437982f,0.9443736f,0.9449462f,0.9455158f,0.9460827f,0.9466465f,0.9472076f,0.9477657f,0.9483209f,0.9488733f,0.9494228f,0.9499694f,0.9505131f,0.9510539f,0.9515917f,0.9521267f,0.9526588f,0.953188f,0.9537143f,0.9542377f,0.9547582f,0.9552757f,0.9557904f,0.9563022f,0.956811f,0.9573169f,0.9578199f,0.95832f,0.9588172f,0.9593114f,0.9598027f,0.9602911f,0.9607766f,0.9612592f,0.9617388f,0.9622155f,0.9626892f,0.9631601f,0.963628f,0.9640929f,0.964555f,0.965014f,0.9654702f,0.9659234f,0.9663736f,0.966821f,0.9672654f,0.9677067f,0.9681453f,0.9685808f,0.9690133f,0.969443f,0.9698697f,0.9702934f,0.9707142f,0.971132f,0.9715468f,0.9719587f,0.9723676f,0.9727736f,0.9731766f,0.9735767f,0.9739737f,0.9743678f,0.974759f,0.9751471f,0.9755324f,0.9759145f,0.9762938f,0.9766701f,0.9770434f,0.9774138f,0.9777811f,0.9781455f,0.9785069f,0.9788653f,0.9792207f,0.9795732f,0.9799227f,0.9802691f,0.9806126f,0.9809532f,0.9812906f,0.9816252f,0.9819567f,0.9822853f,0.9826108f,0.9829334f,0.983253f,0.9835696f,0.9838831f,0.9841937f,0.9845013f,0.9848059f,0.9851075f,0.985406f,0.9857016f,0.9859942f,0.9862838f,0.9865704f,0.986854f,0.9871345f,0.9874121f,0.9876866f,0.9879581f,0.9882267f,0.9884922f,0.9887547f,0.9890142f,0.9892707f,0.9895242f,0.9897746f,0.9900221f,0.9902665f,0.9905079f,0.9907463f,0.9909817f,0.991214f,0.9914434f,0.9916697f,0.991893f,0.9921133f,0.9923305f,0.9925448f,0.9927559f,0.9929641f,0.9931693f,0.9933714f,0.9935706f,0.9937666f,0.9939597f,0.9941497f,0.9943367f,0.9945207f,0.9947016f,0.9948795f,0.9950544f,0.9952263f,0.9953951f,0.9955608f,0.9957236f,0.9958833f,0.99604f,0.9961936f,0.9963443f,0.9964918f,0.9966364f,0.9967779f,0.9969164f,0.9970518f,0.9971842f,0.9973136f,0.9974399f,0.9975632f,0.9976835f,0.9978006f,0.9979148f,0.998026f,0.998134f,0.9982391f,0.9983411f,0.9984401f,0.998536f,0.9986289f,0.9987187f,0.9988055f,0.9988893f,0.99897f,0.9990477f,0.9991223f,0.9991939f,0.9992625f,0.9993279f,0.9993904f,0.9994498f,0.9995062f,0.9995595f,0.9996098f,0.999657f,0.9997012f,0.9997423f,0.9997804f,0.9998155f,0.9998475f,0.9998764f,0.9999024f,0.9999252f,0.999945f,0.9999618f,0.9999756f,0.9999862f,0.9999939f,0.9999985f,1f};
        public static float Sin(float ax)
        {
            if (ax >= 360)
                ax -= 360;
            if (ax < 0)
                ax += 360;
            if(ax>270)
            {
                ax = 360 - ax;
                goto label1;
            }else if(ax>180)
            {
                ax -= 180;
                goto label1;
            }else if(ax>90)
            {
                ax = 180 - ax;
            }
            int id =(int)( ax * 10);
            return a_t_s_900[id];
            label1:;
            id = (int)(ax * 10);
            return -a_t_s_900[id];
        }
        public static float Cos(float angle)
        {
            return Sin(angle+90);
        }
        #endregion

        #region vertex def128x128
        public static Vector3[] v_def128 = new Vector3[] {new Vector3(-0.5f,-0.5f),new Vector3(-0.5f,0.5f),new Vector3(0.5f,0.5f),new Vector3(0.5f,-0.5f) };
        
        #endregion

        #region uv_rect
        public readonly static Point2[] uv_64x64 = new Point2[] { new Point2(135f, 0.3535534f), new Point2(45f, 0.3535534f), new Point2(315f, 0.3535534f), new Point2(225f, 0.3535534f) };
        public readonly static Point2[] uv_128x128 = new Point2[] { new Point2(135f, 0.7071068f), new Point2(45f, 0.7071068f), new Point2(315f, 0.7071068f), new Point2(225f, 0.7071068f) };
        public readonly static Point2[] uv_256x256 = new Point2[] { new Point2(135f, 1.414f), new Point2(45f, 1.414f), new Point2(315f, 1.414f), new Point2(225f, 1.414f) };
        #endregion

        #region triangle 1
        public static int[] tri_def = new int[] {0,1,2,0,2,3 };
        public static int[] tri_def2 = new int[] {0,1,2,0,2,3,4,5,6,4,6,7 };
        #endregion

        #region uv_def 1x1
        public static Vector2[] uv_def_1x1 = new Vector2[] { new Vector2(0,0),new Vector2(0,1),new Vector2(1,1),new Vector2(1,0)};
        #endregion

        #region uv_def 3x1
        static Vector2[] def_3x1_00 = new Vector2[] { new Vector2(0f, 0f), new Vector2(0f, 1f), new Vector2(0.3333333f, 1f), new Vector2(0.3333333f, 0f) };
        static Vector2[] def_3x1_01 = new Vector2[] { new Vector2(0.3333333f, 0f), new Vector2(0.3333333f, 1f), new Vector2(0.6666667f, 1f), new Vector2(0.6666667f, 0f) };
        static Vector2[] def_3x1_02 = new Vector2[] { new Vector2(0.6666667f, 0f), new Vector2(0.6666667f, 1f), new Vector2(1f, 1f), new Vector2(1f, 0f) };
        public static Vector2[][] uv_def_3x1 = new Vector2[][] { def_3x1_00, def_3x1_01, def_3x1_02};
        #endregion

        #region uv_def 3x2
        static Vector2[] def_3x2_00 = new Vector2[] { new Vector2(0f, 0f), new Vector2(0f, 0.5f), new Vector2(0.3333333f, 0.5f), new Vector2(0.3333333f, 0f) };
        static Vector2[] def_3x2_01 = new Vector2[] { new Vector2(0.3333333f, 0f), new Vector2(0.3333333f, 0.5f), new Vector2(0.6666667f, 0.5f), new Vector2(0.6666667f, 0f) };
        static Vector2[] def_3x2_02 = new Vector2[] { new Vector2(0.6666667f, 0f), new Vector2(0.6666667f, 0.5f), new Vector2(1f, 0.5f), new Vector2(1f, 0f) };
        static Vector2[] def_3x2_10 = new Vector2[] { new Vector2(0f, 0.5f), new Vector2(0f, 1f), new Vector2(0.3333333f, 1f), new Vector2(0.3333333f, 0.5f) };
        static Vector2[] def_3x2_11 = new Vector2[] { new Vector2(0.3333333f, 0.5f), new Vector2(0.3333333f, 1f), new Vector2(0.6666667f, 1f), new Vector2(0.6666667f, 0.5f) };
        static Vector2[] def_3x2_12 = new Vector2[] { new Vector2(0.6666667f, 0.5f), new Vector2(0.6666667f, 1f), new Vector2(1f, 1f), new Vector2(1f, 0.5f) };
        public static Vector2[][] uv_def_3x2 = new Vector2[][] { def_3x2_00, def_3x2_01, def_3x2_02, def_3x2_10, def_3x2_11, def_3x2_12};
        #endregion

        #region uv_def 4x1
        static Vector2[] def_4x1_00 = new Vector2[] { new Vector2(0f, 0f), new Vector2(0f, 1f), new Vector2(0.25f, 1f), new Vector2(0.25f, 0f) };
        static Vector2[] def_4x1_01 = new Vector2[] { new Vector2(0.25f, 0f), new Vector2(0.25f, 1f), new Vector2(0.5f, 1f), new Vector2(0.5f, 0f) };
        static Vector2[] def_4x1_02 = new Vector2[] { new Vector2(0.5f, 0f), new Vector2(0.5f, 1f), new Vector2(0.75f, 1f), new Vector2(0.75f, 0f) };
        static Vector2[] def_4x1_03 = new Vector2[] { new Vector2(0.75f, 0f), new Vector2(0.75f, 1f), new Vector2(1f, 1f), new Vector2(1f, 0f) };
        public static Vector2[][] uv_def_4x1 = new Vector2[][] { def_4x1_00, def_4x1_01, def_4x1_02, def_4x1_03, };
        #endregion

        #region uv_def 4x2
        static Vector2[] def_4x2_00 = new Vector2[] { new Vector2(0f, 0f), new Vector2(0f, 0.5f), new Vector2(0.25f, 0.5f), new Vector2(0.25f, 0f) };
        static Vector2[] def_4x2_01 = new Vector2[] { new Vector2(0.25f, 0f), new Vector2(0.25f, 0.5f), new Vector2(0.5f, 0.5f), new Vector2(0.5f, 0f) };
        static Vector2[] def_4x2_02 = new Vector2[] { new Vector2(0.5f, 0f), new Vector2(0.5f, 0.5f), new Vector2(0.75f, 0.5f), new Vector2(0.75f, 0f) };
        static Vector2[] def_4x2_03 = new Vector2[] { new Vector2(0.75f, 0f), new Vector2(0.75f, 0.5f), new Vector2(1f, 0.5f), new Vector2(1f, 0f) };
        static Vector2[] def_4x2_10 = new Vector2[] { new Vector2(0f, 0.5f), new Vector2(0f, 1f), new Vector2(0.25f, 1f), new Vector2(0.25f, 0.5f) };
        static Vector2[] def_4x2_11 = new Vector2[] { new Vector2(0.25f, 0.5f), new Vector2(0.25f, 1f), new Vector2(0.5f, 1f), new Vector2(0.5f, 0.5f) };
        static Vector2[] def_4x2_12 = new Vector2[] { new Vector2(0.5f, 0.5f), new Vector2(0.5f, 1f), new Vector2(0.75f, 1f), new Vector2(0.75f, 0.5f) };
        static Vector2[] def_4x2_13 = new Vector2[] { new Vector2(0.75f, 0.5f), new Vector2(0.75f, 1f), new Vector2(1f, 1f), new Vector2(1f, 0.5f) };
        public static Vector2[][] uv_def_4x2 = new Vector2[][] { def_4x2_00, def_4x2_01, def_4x2_02, def_4x2_03, def_4x2_10, def_4x2_11, def_4x2_12, def_4x2_13 };
        #endregion

        #region uv_def 4x3
        static Vector2[] def_4x3_00 = new Vector2[] { new Vector2(0f, 0f), new Vector2(0f, 0.3333333f), new Vector2(0.25f, 0.3333333f), new Vector2(0.25f, 0f) };
        static Vector2[] def_4x3_01 = new Vector2[] { new Vector2(0.25f, 0f), new Vector2(0.25f, 0.3333333f), new Vector2(0.5f, 0.3333333f), new Vector2(0.5f, 0f) };
        static Vector2[] def_4x3_02 = new Vector2[] { new Vector2(0.5f, 0f), new Vector2(0.5f, 0.3333333f), new Vector2(0.75f, 0.3333333f), new Vector2(0.75f, 0f) };
        static Vector2[] def_4x3_03 = new Vector2[] { new Vector2(0.75f, 0f), new Vector2(0.75f, 0.3333333f), new Vector2(1f, 0.3333333f), new Vector2(1f, 0f) };
        static Vector2[] def_4x3_10 = new Vector2[] { new Vector2(0f, 0.3333333f), new Vector2(0f, 0.6666667f), new Vector2(0.25f, 0.6666667f), new Vector2(0.25f, 0.3333333f) };
        static Vector2[] def_4x3_11 = new Vector2[] { new Vector2(0.25f, 0.3333333f), new Vector2(0.25f, 0.6666667f), new Vector2(0.5f, 0.6666667f), new Vector2(0.5f, 0.3333333f) };
        static Vector2[] def_4x3_12 = new Vector2[] { new Vector2(0.5f, 0.3333333f), new Vector2(0.5f, 0.6666667f), new Vector2(0.75f, 0.6666667f), new Vector2(0.75f, 0.3333333f) };
        static Vector2[] def_4x3_13 = new Vector2[] { new Vector2(0.75f, 0.3333333f), new Vector2(0.75f, 0.6666667f), new Vector2(1f, 0.6666667f), new Vector2(1f, 0.3333333f) };
        static Vector2[] def_4x3_20 = new Vector2[] { new Vector2(0f, 0.6666667f), new Vector2(0f, 1f), new Vector2(0.25f, 1f), new Vector2(0.25f, 0.6666667f) };
        static Vector2[] def_4x3_21 = new Vector2[] { new Vector2(0.25f, 0.6666667f), new Vector2(0.25f, 1f), new Vector2(0.5f, 1f), new Vector2(0.5f, 0.6666667f) };
        static Vector2[] def_4x3_22 = new Vector2[] { new Vector2(0.5f, 0.6666667f), new Vector2(0.5f, 1f), new Vector2(0.75f, 1f), new Vector2(0.75f, 0.6666667f) };
        static Vector2[] def_4x3_23 = new Vector2[] { new Vector2(0.75f, 0.6666667f), new Vector2(0.75f, 1f), new Vector2(1f, 1f), new Vector2(1f, 0.6666667f) };
        public static Vector2[][] uv_def_4x3 = new Vector2[][] { def_4x3_00, def_4x3_01, def_4x3_02, def_4x3_03, def_4x3_10, def_4x3_11, def_4x3_12, def_4x3_13, def_4x3_20, def_4x3_21, def_4x3_22, def_4x3_23};
        #endregion

        #region uv_def 4x4
        static Vector2[] def_4x4_1 = new Vector2[] { new Vector2(0f, 0f), new Vector2(0f, 0.25f), new Vector2(0.25f, 0.25f), new Vector2(0.25f, 0f) };
        static Vector2[] def_4x4_2 = new Vector2[] { new Vector2(0.25f, 0f), new Vector2(0.25f, 0.25f), new Vector2(0.5f, 0.25f), new Vector2(0.5f, 0f) };
        static Vector2[] def_4x4_3 = new Vector2[] { new Vector2(0.5f, 0f), new Vector2(0.5f, 0.25f), new Vector2(0.75f, 0.25f), new Vector2(0.75f, 0f) };
        static Vector2[] def_4x4_4 = new Vector2[] { new Vector2(0.75f, 0f), new Vector2(0.75f, 0.25f), new Vector2(1f, 0.25f), new Vector2(1f, 0f) };
        static Vector2[] def_4x4_5 = new Vector2[] { new Vector2(0f, 0.25f), new Vector2(0f, 0.5f), new Vector2(0.25f, 0.5f), new Vector2(0.25f, 0.25f) };
        static Vector2[] def_4x4_6 = new Vector2[] { new Vector2(0.25f, 0.25f), new Vector2(0.25f, 0.5f), new Vector2(0.5f, 0.5f), new Vector2(0.5f, 0.25f) };
        static Vector2[] def_4x4_7 = new Vector2[] { new Vector2(0.5f, 0.25f), new Vector2(0.5f, 0.5f), new Vector2(0.75f, 0.5f), new Vector2(0.75f, 0.25f) };
        static Vector2[] def_4x4_8 = new Vector2[] { new Vector2(0.75f, 0.25f), new Vector2(0.75f, 0.5f), new Vector2(1f, 0.5f), new Vector2(1f, 0.25f), };
        static Vector2[] def_4x4_9 = new Vector2[] { new Vector2(0f, 0.5f), new Vector2(0f, 0.75f), new Vector2(0.25f, 0.75f), new Vector2(0.25f, 0.5f) };
        static Vector2[] def_4x4_10 = new Vector2[] { new Vector2(0.25f, 0.5f), new Vector2(0.25f, 0.75f), new Vector2(0.5f, 0.75f), new Vector2(0.5f, 0.5f), };
        static Vector2[] def_4x4_11 = new Vector2[] { new Vector2(0.5f, 0.5f), new Vector2(0.5f, 0.75f), new Vector2(0.75f, 0.75f), new Vector2(0.75f, 0.5f) };
        static Vector2[] def_4x4_12 = new Vector2[] { new Vector2(0.75f, 0.5f), new Vector2(0.75f, 0.75f), new Vector2(1f, 0.75f), new Vector2(1f, 0.5f) };
        static Vector2[] def_4x4_13 = new Vector2[] { new Vector2(0f, 0.75f), new Vector2(0f, 1f), new Vector2(0.25f, 1f), new Vector2(0.25f, 0.75f) };
        static Vector2[] def_4x4_14 = new Vector2[] { new Vector2(0.25f, 0.75f), new Vector2(0.25f, 1f), new Vector2(0.5f, 1f), new Vector2(0.5f, 0.75f) };
        static Vector2[] def_4x4_15 = new Vector2[] { new Vector2(0.5f, 0.75f), new Vector2(0.5f, 1f), new Vector2(0.75f, 1f), new Vector2(0.75f, 0.75f) };
        static Vector2[] def_4x4_16 = new Vector2[] { new Vector2(0.75f, 0.75f), new Vector2(0.75f, 1f), new Vector2(1f, 1f), new Vector2(1f, 0.75f) };
        public static readonly Vector2[][] uv_def_4x4 = new Vector2[][]{ def_4x4_1,def_4x4_2,def_4x4_3,def_4x4_4,def_4x4_5,
        def_4x4_6,def_4x4_7,def_4x4_8,def_4x4_9,def_4x4_10,def_4x4_11,def_4x4_12,def_4x4_13,def_4x4_14,def_4x4_15,def_4x4_16};

        #endregion

        #region uv_def 5x2
        static Vector2[] def_5x2_00 = new Vector2[] { new Vector2(0f, 0f), new Vector2(0f, 0.5f), new Vector2(0.2f, 0.5f), new Vector2(0.2f, 0f) };
        static Vector2[] def_5x2_01 = new Vector2[] { new Vector2(0.2f, 0f), new Vector2(0.2f, 0.5f), new Vector2(0.4f, 0.5f), new Vector2(0.4f, 0f) };
        static Vector2[] def_5x2_02 = new Vector2[] { new Vector2(0.4f, 0f), new Vector2(0.4f, 0.5f), new Vector2(0.6f, 0.5f), new Vector2(0.6f, 0f) };
        static Vector2[] def_5x2_03 = new Vector2[] { new Vector2(0.6f, 0f), new Vector2(0.6f, 0.5f), new Vector2(0.8f, 0.5f), new Vector2(0.8f, 0f) };
        static Vector2[] def_5x2_04 = new Vector2[] { new Vector2(0.8f, 0f), new Vector2(0.8f, 0.5f), new Vector2(1f, 0.5f), new Vector2(1f, 0f) };
        static Vector2[] def_5x2_10 = new Vector2[] { new Vector2(0f, 0.5f), new Vector2(0f, 1f), new Vector2(0.2f, 1f), new Vector2(0.2f, 0.5f) };
        static Vector2[] def_5x2_11 = new Vector2[] { new Vector2(0.2f, 0.5f), new Vector2(0.2f, 1f), new Vector2(0.4f, 1f), new Vector2(0.4f, 0.5f) };
        static Vector2[] def_5x2_12 = new Vector2[] { new Vector2(0.4f, 0.5f), new Vector2(0.4f, 1f), new Vector2(0.6f, 1f), new Vector2(0.6f, 0.5f) };
        static Vector2[] def_5x2_13 = new Vector2[] { new Vector2(0.6f, 0.5f), new Vector2(0.6f, 1f), new Vector2(0.8f, 1f), new Vector2(0.8f, 0.5f) };
        static Vector2[] def_5x2_14 = new Vector2[] { new Vector2(0.8f, 0.5f), new Vector2(0.8f, 1f), new Vector2(1f, 1f), new Vector2(1f, 0.5f) };
        public static Vector2[][] uv_def_5x2 = new Vector2[][] { def_5x2_00, def_5x2_01, def_5x2_02, def_5x2_03, def_5x2_04, def_5x2_10, def_5x2_11, def_5x2_12, def_5x2_13, def_5x2_14 };
        #endregion

        #region uv_def 6x5
        static Vector2[] def_6x5_00 = new Vector2[] { new Vector2(0f, 0f), new Vector2(0f, 0.2f), new Vector2(0.1666667f, 0.2f), new Vector2(0.1666667f, 0f) };
        static Vector2[] def_6x5_01 = new Vector2[] { new Vector2(0.1666667f, 0f), new Vector2(0.1666667f, 0.2f), new Vector2(0.3333333f, 0.2f), new Vector2(0.3333333f, 0f) };
        static Vector2[] def_6x5_02 = new Vector2[] { new Vector2(0.3333333f, 0f), new Vector2(0.3333333f, 0.2f), new Vector2(0.5f, 0.2f), new Vector2(0.5f, 0f) };
        static Vector2[] def_6x5_03 = new Vector2[] { new Vector2(0.5f, 0f), new Vector2(0.5f, 0.2f), new Vector2(0.6666667f, 0.2f), new Vector2(0.6666667f, 0f) };
        static Vector2[] def_6x5_04 = new Vector2[] { new Vector2(0.6666667f, 0f), new Vector2(0.6666667f, 0.2f), new Vector2(0.8333333f, 0.2f), new Vector2(0.8333333f, 0f) };
        static Vector2[] def_6x5_05 = new Vector2[] { new Vector2(0.8333333f, 0f), new Vector2(0.8333333f, 0.2f), new Vector2(1f, 0.2f), new Vector2(1f, 0f) };
        static Vector2[] def_6x5_10 = new Vector2[] { new Vector2(0f, 0.2f), new Vector2(0f, 0.4f), new Vector2(0.1666667f, 0.4f), new Vector2(0.1666667f, 0.2f) };
        static Vector2[] def_6x5_11 = new Vector2[] { new Vector2(0.1666667f, 0.2f), new Vector2(0.1666667f, 0.4f), new Vector2(0.3333333f, 0.4f), new Vector2(0.3333333f, 0.2f) };
        static Vector2[] def_6x5_12 = new Vector2[] { new Vector2(0.3333333f, 0.2f), new Vector2(0.3333333f, 0.4f), new Vector2(0.5f, 0.4f), new Vector2(0.5f, 0.2f) };
        static Vector2[] def_6x5_13 = new Vector2[] { new Vector2(0.5f, 0.2f), new Vector2(0.5f, 0.4f), new Vector2(0.6666667f, 0.4f), new Vector2(0.6666667f, 0.2f) };
        static Vector2[] def_6x5_14 = new Vector2[] { new Vector2(0.6666667f, 0.2f), new Vector2(0.6666667f, 0.4f), new Vector2(0.8333333f, 0.4f), new Vector2(0.8333333f, 0.2f) };
        static Vector2[] def_6x5_15 = new Vector2[] { new Vector2(0.8333333f, 0.2f), new Vector2(0.8333333f, 0.4f), new Vector2(1f, 0.4f), new Vector2(1f, 0.2f) };
        static Vector2[] def_6x5_20 = new Vector2[] { new Vector2(0f, 0.4f), new Vector2(0f, 0.6f), new Vector2(0.1666667f, 0.6f), new Vector2(0.1666667f, 0.4f) };
        static Vector2[] def_6x5_21 = new Vector2[] { new Vector2(0.1666667f, 0.4f), new Vector2(0.1666667f, 0.6f), new Vector2(0.3333333f, 0.6f), new Vector2(0.3333333f, 0.4f) };
        static Vector2[] def_6x5_22 = new Vector2[] { new Vector2(0.3333333f, 0.4f), new Vector2(0.3333333f, 0.6f), new Vector2(0.5f, 0.6f), new Vector2(0.5f, 0.4f) };
        static Vector2[] def_6x5_23 = new Vector2[] { new Vector2(0.5f, 0.4f), new Vector2(0.5f, 0.6f), new Vector2(0.6666667f, 0.6f), new Vector2(0.6666667f, 0.4f) };
        static Vector2[] def_6x5_24 = new Vector2[] { new Vector2(0.6666667f, 0.4f), new Vector2(0.6666667f, 0.6f), new Vector2(0.8333333f, 0.6f), new Vector2(0.8333333f, 0.4f) };
        static Vector2[] def_6x5_25 = new Vector2[] { new Vector2(0.8333333f, 0.4f), new Vector2(0.8333333f, 0.6f), new Vector2(1f, 0.6f), new Vector2(1f, 0.4f) };
        static Vector2[] def_6x5_30 = new Vector2[] { new Vector2(0f, 0.6f), new Vector2(0f, 0.8f), new Vector2(0.1666667f, 0.8f), new Vector2(0.1666667f, 0.6f) };
        static Vector2[] def_6x5_31 = new Vector2[] { new Vector2(0.1666667f, 0.6f), new Vector2(0.1666667f, 0.8f), new Vector2(0.3333333f, 0.8f), new Vector2(0.3333333f, 0.6f) };
        static Vector2[] def_6x5_32 = new Vector2[] { new Vector2(0.3333333f, 0.6f), new Vector2(0.3333333f, 0.8f), new Vector2(0.5f, 0.8f), new Vector2(0.5f, 0.6f) };
        static Vector2[] def_6x5_33 = new Vector2[] { new Vector2(0.5f, 0.6f), new Vector2(0.5f, 0.8f), new Vector2(0.6666667f, 0.8f), new Vector2(0.6666667f, 0.6f) };
        static Vector2[] def_6x5_34 = new Vector2[] { new Vector2(0.6666667f, 0.6f), new Vector2(0.6666667f, 0.8f), new Vector2(0.8333333f, 0.8f), new Vector2(0.8333333f, 0.6f) };
        static Vector2[] def_6x5_35 = new Vector2[] { new Vector2(0.8333333f, 0.6f), new Vector2(0.8333333f, 0.8f), new Vector2(1f, 0.8f), new Vector2(1f, 0.6f) };
        static Vector2[] def_6x5_40 = new Vector2[] { new Vector2(0f, 0.8f), new Vector2(0f, 1f), new Vector2(0.1666667f, 1f), new Vector2(0.1666667f, 0.8f) };
        static Vector2[] def_6x5_41 = new Vector2[] { new Vector2(0.1666667f, 0.8f), new Vector2(0.1666667f, 1f), new Vector2(0.3333333f, 1f), new Vector2(0.3333333f, 0.8f) };
        static Vector2[] def_6x5_42 = new Vector2[] { new Vector2(0.3333333f, 0.8f), new Vector2(0.3333333f, 1f), new Vector2(0.5f, 1f), new Vector2(0.5f, 0.8f) };
        static Vector2[] def_6x5_43 = new Vector2[] { new Vector2(0.5f, 0.8f), new Vector2(0.5f, 1f), new Vector2(0.6666667f, 1f), new Vector2(0.6666667f, 0.8f) };
        static Vector2[] def_6x5_44 = new Vector2[] { new Vector2(0.6666667f, 0.8f), new Vector2(0.6666667f, 1f), new Vector2(0.8333333f, 1f), new Vector2(0.8333333f, 0.8f) };
        static Vector2[] def_6x5_45 = new Vector2[] { new Vector2(0.8333333f, 0.8f), new Vector2(0.8333333f, 1f), new Vector2(1f, 1f), new Vector2(1f, 0.8f) };
        public static Vector2[][] uv_def_6x5 = new Vector2[][] { def_6x5_00, def_6x5_01, def_6x5_02, def_6x5_03, def_6x5_04, def_6x5_05, def_6x5_10, def_6x5_11, def_6x5_12, def_6x5_13, def_6x5_14, def_6x5_15, def_6x5_20, def_6x5_21, def_6x5_22, def_6x5_23, def_6x5_24, def_6x5_25, def_6x5_30, def_6x5_31, def_6x5_32, def_6x5_33, def_6x5_34, def_6x5_35, def_6x5_40, def_6x5_41, def_6x5_42, def_6x5_43, def_6x5_44, def_6x5_45, };
        #endregion

        #region uv_def 8x1
        static Vector2[] def_8x1_00 = new Vector2[] { new Vector2(0f, 0f), new Vector2(0f, 1f), new Vector2(0.125f, 1f), new Vector2(0.125f, 0f) };
        static Vector2[] def_8x1_01 = new Vector2[] { new Vector2(0.125f, 0f), new Vector2(0.125f, 1f), new Vector2(0.25f, 1f), new Vector2(0.25f, 0f) };
        static Vector2[] def_8x1_02 = new Vector2[] { new Vector2(0.25f, 0f), new Vector2(0.25f, 1f), new Vector2(0.375f, 1f), new Vector2(0.375f, 0f) };
        static Vector2[] def_8x1_03 = new Vector2[] { new Vector2(0.375f, 0f), new Vector2(0.375f, 1f), new Vector2(0.5f, 1f), new Vector2(0.5f, 0f) };
        static Vector2[] def_8x1_04 = new Vector2[] { new Vector2(0.5f, 0f), new Vector2(0.5f, 1f), new Vector2(0.625f, 1f), new Vector2(0.625f, 0f) };
        static Vector2[] def_8x1_05 = new Vector2[] { new Vector2(0.625f, 0f), new Vector2(0.625f, 1f), new Vector2(0.75f, 1f), new Vector2(0.75f, 0f) };
        static Vector2[] def_8x1_06 = new Vector2[] { new Vector2(0.75f, 0f), new Vector2(0.75f, 1f), new Vector2(0.875f, 1f), new Vector2(0.875f, 0f) };
        static Vector2[] def_8x1_07 = new Vector2[] { new Vector2(0.875f, 0f), new Vector2(0.875f, 1f), new Vector2(1f, 1f), new Vector2(1f, 0f) };
        public static Vector2[][] uv_def_8x1 = new Vector2[][] { def_8x1_00, def_8x1_01, def_8x1_02, def_8x1_03, def_8x1_04, def_8x1_05, def_8x1_06, def_8x1_07 };
        #endregion

        #region uv_def 8x6
        static Vector2[] def_8x6_00 = new Vector2[] { new Vector2(0f, 0f), new Vector2(0f, 0.1666667f), new Vector2(0.125f, 0.1666667f), new Vector2(0.125f, 0f) };
        static Vector2[] def_8x6_01 = new Vector2[] { new Vector2(0f, 0f), new Vector2(0f, 0.1666667f), new Vector2(0.125f, 0.1666667f), new Vector2(0.125f, 0f) };
        static Vector2[] def_8x6_02 = new Vector2[] { new Vector2(0f, 0f), new Vector2(0f, 0.1666667f), new Vector2(0.125f, 0.1666667f), new Vector2(0.125f, 0f) };
        static Vector2[] def_8x6_03 = new Vector2[] { new Vector2(0f, 0f), new Vector2(0f, 0.1666667f), new Vector2(0.125f, 0.1666667f), new Vector2(0.125f, 0f) };
        static Vector2[] def_8x6_04 = new Vector2[] { new Vector2(0f, 0f), new Vector2(0f, 0.1666667f), new Vector2(0.125f, 0.1666667f), new Vector2(0.125f, 0f) };
        static Vector2[] def_8x6_05 = new Vector2[] { new Vector2(0f, 0f), new Vector2(0f, 0.1666667f), new Vector2(0.125f, 0.1666667f), new Vector2(0.125f, 0f) };
        static Vector2[] def_8x6_06 = new Vector2[] { new Vector2(0f, 0f), new Vector2(0f, 0.1666667f), new Vector2(0.125f, 0.1666667f), new Vector2(0.125f, 0f) };
        static Vector2[] def_8x6_07 = new Vector2[] { new Vector2(0f, 0f), new Vector2(0f, 0.1666667f), new Vector2(0.125f, 0.1666667f), new Vector2(0.125f, 0f) };
        static Vector2[] def_8x6_10 = new Vector2[] { new Vector2(0f, 0.1666667f), new Vector2(0f, 0.3333333f), new Vector2(0.125f, 0.3333333f), new Vector2(0.125f, 0.1666667f) };
        static Vector2[] def_8x6_11 = new Vector2[] { new Vector2(0f, 0.1666667f), new Vector2(0f, 0.3333333f), new Vector2(0.125f, 0.3333333f), new Vector2(0.125f, 0.1666667f) };
        static Vector2[] def_8x6_12 = new Vector2[] { new Vector2(0f, 0.1666667f), new Vector2(0f, 0.3333333f), new Vector2(0.125f, 0.3333333f), new Vector2(0.125f, 0.1666667f) };
        static Vector2[] def_8x6_13 = new Vector2[] { new Vector2(0f, 0.1666667f), new Vector2(0f, 0.3333333f), new Vector2(0.125f, 0.3333333f), new Vector2(0.125f, 0.1666667f) };
        static Vector2[] def_8x6_14 = new Vector2[] { new Vector2(0f, 0.1666667f), new Vector2(0f, 0.3333333f), new Vector2(0.125f, 0.3333333f), new Vector2(0.125f, 0.1666667f) };
        static Vector2[] def_8x6_15 = new Vector2[] { new Vector2(0f, 0.1666667f), new Vector2(0f, 0.3333333f), new Vector2(0.125f, 0.3333333f), new Vector2(0.125f, 0.1666667f) };
        static Vector2[] def_8x6_16 = new Vector2[] { new Vector2(0f, 0.1666667f), new Vector2(0f, 0.3333333f), new Vector2(0.125f, 0.3333333f), new Vector2(0.125f, 0.1666667f) };
        static Vector2[] def_8x6_17 = new Vector2[] { new Vector2(0f, 0.1666667f), new Vector2(0f, 0.3333333f), new Vector2(0.125f, 0.3333333f), new Vector2(0.125f, 0.1666667f) };
        static Vector2[] def_8x6_20 = new Vector2[] { new Vector2(0f, 0.3333333f), new Vector2(0f, 0.5f), new Vector2(0.125f, 0.5f), new Vector2(0.125f, 0.3333333f) };
        static Vector2[] def_8x6_21 = new Vector2[] { new Vector2(0f, 0.3333333f), new Vector2(0f, 0.5f), new Vector2(0.125f, 0.5f), new Vector2(0.125f, 0.3333333f) };
        static Vector2[] def_8x6_22 = new Vector2[] { new Vector2(0f, 0.3333333f), new Vector2(0f, 0.5f), new Vector2(0.125f, 0.5f), new Vector2(0.125f, 0.3333333f) };
        static Vector2[] def_8x6_23 = new Vector2[] { new Vector2(0f, 0.3333333f), new Vector2(0f, 0.5f), new Vector2(0.125f, 0.5f), new Vector2(0.125f, 0.3333333f) };
        static Vector2[] def_8x6_24 = new Vector2[] { new Vector2(0f, 0.3333333f), new Vector2(0f, 0.5f), new Vector2(0.125f, 0.5f), new Vector2(0.125f, 0.3333333f) };
        static Vector2[] def_8x6_25 = new Vector2[] { new Vector2(0f, 0.3333333f), new Vector2(0f, 0.5f), new Vector2(0.125f, 0.5f), new Vector2(0.125f, 0.3333333f) };
        static Vector2[] def_8x6_26 = new Vector2[] { new Vector2(0f, 0.3333333f), new Vector2(0f, 0.5f), new Vector2(0.125f, 0.5f), new Vector2(0.125f, 0.3333333f) };
        static Vector2[] def_8x6_27 = new Vector2[] { new Vector2(0f, 0.3333333f), new Vector2(0f, 0.5f), new Vector2(0.125f, 0.5f), new Vector2(0.125f, 0.3333333f) };
        static Vector2[] def_8x6_30 = new Vector2[] { new Vector2(0f, 0.5f), new Vector2(0f, 0.6666667f), new Vector2(0.125f, 0.6666667f), new Vector2(0.125f, 0.5f) };
        static Vector2[] def_8x6_31 = new Vector2[] { new Vector2(0f, 0.5f), new Vector2(0f, 0.6666667f), new Vector2(0.125f, 0.6666667f), new Vector2(0.125f, 0.5f) };
        static Vector2[] def_8x6_32 = new Vector2[] { new Vector2(0f, 0.5f), new Vector2(0f, 0.6666667f), new Vector2(0.125f, 0.6666667f), new Vector2(0.125f, 0.5f) };
        static Vector2[] def_8x6_33 = new Vector2[] { new Vector2(0f, 0.5f), new Vector2(0f, 0.6666667f), new Vector2(0.125f, 0.6666667f), new Vector2(0.125f, 0.5f) };
        static Vector2[] def_8x6_34 = new Vector2[] { new Vector2(0f, 0.5f), new Vector2(0f, 0.6666667f), new Vector2(0.125f, 0.6666667f), new Vector2(0.125f, 0.5f) };
        static Vector2[] def_8x6_35 = new Vector2[] { new Vector2(0f, 0.5f), new Vector2(0f, 0.6666667f), new Vector2(0.125f, 0.6666667f), new Vector2(0.125f, 0.5f) };
        static Vector2[] def_8x6_36 = new Vector2[] { new Vector2(0f, 0.5f), new Vector2(0f, 0.6666667f), new Vector2(0.125f, 0.6666667f), new Vector2(0.125f, 0.5f) };
        static Vector2[] def_8x6_37 = new Vector2[] { new Vector2(0f, 0.5f), new Vector2(0f, 0.6666667f), new Vector2(0.125f, 0.6666667f), new Vector2(0.125f, 0.5f) };
        static Vector2[] def_8x6_40 = new Vector2[] { new Vector2(0f, 0.6666667f), new Vector2(0f, 0.8333334f), new Vector2(0.125f, 0.8333334f), new Vector2(0.125f, 0.6666667f) };
        static Vector2[] def_8x6_41 = new Vector2[] { new Vector2(0f, 0.6666667f), new Vector2(0f, 0.8333334f), new Vector2(0.125f, 0.8333334f), new Vector2(0.125f, 0.6666667f) };
        static Vector2[] def_8x6_42 = new Vector2[] { new Vector2(0f, 0.6666667f), new Vector2(0f, 0.8333334f), new Vector2(0.125f, 0.8333334f), new Vector2(0.125f, 0.6666667f) };
        static Vector2[] def_8x6_43 = new Vector2[] { new Vector2(0f, 0.6666667f), new Vector2(0f, 0.8333334f), new Vector2(0.125f, 0.8333334f), new Vector2(0.125f, 0.6666667f) };
        static Vector2[] def_8x6_44 = new Vector2[] { new Vector2(0f, 0.6666667f), new Vector2(0f, 0.8333334f), new Vector2(0.125f, 0.8333334f), new Vector2(0.125f, 0.6666667f) };
        static Vector2[] def_8x6_45 = new Vector2[] { new Vector2(0f, 0.6666667f), new Vector2(0f, 0.8333334f), new Vector2(0.125f, 0.8333334f), new Vector2(0.125f, 0.6666667f) };
        static Vector2[] def_8x6_46 = new Vector2[] { new Vector2(0f, 0.6666667f), new Vector2(0f, 0.8333334f), new Vector2(0.125f, 0.8333334f), new Vector2(0.125f, 0.6666667f) };
        static Vector2[] def_8x6_47 = new Vector2[] { new Vector2(0f, 0.6666667f), new Vector2(0f, 0.8333334f), new Vector2(0.125f, 0.8333334f), new Vector2(0.125f, 0.6666667f) };

        public static Vector2[][] uv_def_8x6 = new Vector2[][] {def_8x6_00,def_8x6_01,def_8x6_02,def_8x6_03,def_8x6_04,def_8x6_05,def_8x6_06,def_8x6_07,
        def_8x6_10,def_8x6_11,def_8x6_12,def_8x6_13,def_8x6_14,def_8x6_15,def_8x6_16,def_8x6_17,def_8x6_20,def_8x6_21,def_8x6_22,def_8x6_23,
        def_8x6_24,def_8x6_25,def_8x6_26,def_8x6_27,def_8x6_30,def_8x6_31,def_8x6_32,def_8x6_33,def_8x6_34,def_8x6_35,def_8x6_36,def_8x6_37,
        def_8x6_40,def_8x6_41,def_8x6_42,def_8x6_43,def_8x6_44,def_8x6_45,def_8x6_46,def_8x6_47};
        #endregion

        #region fix left arc22
        public static readonly Point3[] b_left_arc22 = new Point3[]{
new Point3(-2.8f,5,180),new Point3(-2.8f,5,184),new Point3(-2.8f,5,188),new Point3(-2.8f,5,192),
new Point3(-2.8f,5,196),new Point3(-2.8f,5,200),new Point3(-2.8f,5,204),new Point3(-2.8f,5,208),
new Point3(-2.8f,5,212),new Point3(-2.8f,5,216),new Point3(-2.8f,5,220),new Point3(-2.8f,5,224),
new Point3(-2.8f,5,228),new Point3(-2.8f,5,232),new Point3(-2.8f,5,236),new Point3(-2.8f,5,240),
new Point3(-2.8f,5,244),new Point3(-2.8f,5,248),new Point3(-2.8f,5,252),new Point3(-2.8f,5,256),
new Point3(-2.8f,5,260),new Point3(-2.8f,5,264)};
        #endregion

        #region fix right arc22
        public static readonly Point3[] b_right_arc22 = new Point3[]{
new Point3(2.8f,5,96),new Point3(2.8f,5,100),new Point3(2.8f,5,104),new Point3(2.8f,5,108),
new Point3(2.8f,5,112),new Point3(2.8f,5,116),new Point3(2.8f,5,120),new Point3(2.8f,5,124),
new Point3(2.8f,5,128),new Point3(2.8f,5,132),new Point3(2.8f,5,136),new Point3(2.8f,5,140),
new Point3(2.8f,5,144),new Point3(2.8f,5,148),new Point3(2.8f,5,152),new Point3(2.8f,5,156),
new Point3(2.8f,5,160),new Point3(2.8f,5,164),new Point3(2.8f,5,168),new Point3(2.8f,5,172),
new Point3(2.8f,5,176),new Point3(2.8f,5,180)};
        #endregion

        #region fix line left9 和10进行交叉
        public static readonly Point3[] b_line_leftA = new Point3[]{
new Point3(-2.8f,4.75f,270),new Point3(-2.8f,3.75f,270),new Point3(-2.8f,2.75f,270),new Point3(-2.8f,1.75f,270),
new Point3(-2.8f,0.75f,270),new Point3(-2.8f,-0.25f,270),new Point3(-2.8f,-1.25f,270),new Point3(-2.8f,-2.25f,270),
new Point3(-2.8f,-3.25f,270),new Point3(-2.8f,-4.25f,270)};
        #endregion

        #region fix line left20
        public static readonly Point3[] b_line_leftB = new Point3[]{
new Point3(-2.8f,4.25f,270),new Point3(-2.8f,3.25f,270),new Point3(-2.8f,2.25f,270),new Point3(-2.8f,1.25f,270),
new Point3(-2.8f,0.25f,270),new Point3(-2.8f,-0.75f,270),new Point3(-2.8f,-1.75f,270),new Point3(-2.8f,-2.75f,270),
new Point3(-2.8f,-3.75f,270),new Point3(-2.8f,-4.75f,270)};
        #endregion

        #region fix line right19和20交叉
        public static readonly Point3[] b_line_rightA = new Point3[]{
new Point3(2.8f,4.5f,90),new Point3(2.8f,3.5f,90),new Point3(2.8f,2.5f,90),new Point3(2.8f,1.5f,90),
new Point3(2.8f,0.5f,90),new Point3(2.8f,-0.5f,90),new Point3(2.8f,-1.5f,90),new Point3(2.8f,-2.5f,90),
new Point3(2.8f,-3.5f,90),new Point3(2.8f,-4.5f,90)};
        #endregion

        #region fix line right10
        public static readonly Point3[] b_line_rightB = new Point3[]{
new Point3(2.8f,4f,90),new Point3(2.8f,3f,90),new Point3(2.8f,2f,90),new Point3(2.8f,1f,90),
new Point3(2.8f,0f,90),new Point3(2.8f,-1f,90),new Point3(2.8f,-2f,90),new Point3(2.8f,-3f,90),
new Point3(2.8f,-4f,90)};
        #endregion

        #region fix line top
        public static readonly Point3[] b_line_topA = new Point3[]{new Point3(-2.5f,5f,180),
new Point3(-1.5f,5f,180),new Point3(-0.5f,5f,180),new Point3(0.5f,5f,180),new Point3(1.5f,5f,180),new Point3(2.5f,5f,180)};
        #endregion

        #region fix line top
        public static readonly Point3[] b_line_topB = new Point3[]{new Point3(-2f,5f,180),
            new Point3(-1f,5f,180),new Point3(0f,5f,180),new Point3(1f,5f,180),new Point3(2f,5f,180)};
        #endregion

        #region Circle 36
        public static Point3[] GetCircle36(Vector3 location)
        {
            float x = location.x;
            float y = location.y;
            Point3[] temp = new Point3[36];
            for (int i = 0; i < 36; i++)
                temp[i] = new Point3(x, y, i * 10);
            return temp;
        }
        #endregion

        #region three angle fix
        public static Point3[] GetFixAngle3(Vector3 location)
        {
            float x = location.x;
            float y = location.y;
            return new Point3[] { new Point3(x, y, 0), new Point3(x, y, 120), new Point3(x, y, 240) };
        }
        #endregion

        #region six angle 6
        public static Point3[] GetFiveAngle(float angle,ref Vector3 location)//0-72
        {
            float x = location.x;
            float y = location.y;
            Point3[] p = new Point3[5];
            for(int i=0;i<5;i++)
            {
                p[i].x = x;
                p[i].y = y;
                p[i].z = angle;
                angle += 72;
            }
            return p;
        }
        public static Point3[] GetSixAngle(float angle,ref  Vector3 location)//0-60
        {
            float x = location.x;
            float y = location.y;
            Point3[] p = new Point3[6];
            for (int i = 0; i < 6; i++)
            {
                p[i].x = x;
                p[i].y = y;
                p[i].z = angle;
                angle += 60;
            }
            return p;
        }
        #endregion

        #region mesh left 10
        public static readonly Point3[] fix_line_angle215 = new Point3[]{
new Point3(-2.8f,4.75f,215),new Point3(-2.8f,3.75f,215),new Point3(-2.8f,2.75f,215),new Point3(-2.8f,1.75f,215),
new Point3(-2.8f,0.75f,215),new Point3(-2.8f,-0.25f,215),new Point3(-2.8f,-1.25f,215),new Point3(-2.8f,-2.25f,215),
new Point3(-2.8f,-3.25f,215),new Point3(-2.8f,-4.25f,215)
};
        #endregion

        #region mesh right 10
        public static readonly Point3[] fix_right_angle135 = new Point3[]{
new Point3(2.8f,4.75f,135),new Point3(2.8f,3.75f,135),new Point3(2.8f,2.75f,135),new Point3(2.8f,1.75f,135),
            new Point3(2.8f,0.75f,135),new Point3(2.8f,-0.25f,135),new Point3(2.8f,-1.25f,135),new Point3(2.8f,-2.25f,135),
new Point3(2.8f,-3.25f,135),new Point3(2.8f,-4.25f,135),
};
        #endregion

        #region fix arc down 14
        public static Point3[] GetArcDown14(Vector3 location)
        {
            float x = location.x;
            float y = location.y;
            Point3[] temp = new Point3[14];
            float a = 145;
            for (int i = 0; i < 14; i++)
                temp[i] = new Point3(x, y, a + i * 5);
            return temp;
        }
        #endregion

        #region fix seven angle down 
        public static Point3[] GetsevenAngleA(Vector3 location)
        {
            float x = location.x;
            float y = location.y;
            Point3[] temp = new Point3[7];
            float a = 90;
            for (int i = 0; i < 7; i++)
                temp[i] = new Point3(x, y, a + i * 30);
            return temp;
        }
        #endregion

        #region enemy fix start point
        public static readonly Point3[] e_topline3_01 = new Point3[] {
            new Point3(0,5.5f,0) ,new Point3(-1,5.5f,0),new Point3(-2,5.5f,0)};

        public static readonly Point3[] e_topline3_02 = new Point3[] {
            new Point3(0,5.5f,0) ,new Point3(1,5.5f,0),new Point3(2,5.5f,0)};

        public static readonly Point3[] e_lefttop2_01 = new Point3[] {
            new Point3(-3,5,0),new Point3(-3,4,0)};
        public static readonly Point3[] e_lefttop2_02 = new Point3[] {
            new Point3(-3,4,0),new Point3(-3,3,0) };
        public static readonly Point3[] e_lefttop2_03 = new Point3[] {
            new Point3(-3f,3f,0),new Point3(-3f,2f,0)};
        public static readonly Point3[] e_lefttop2_04 = new Point3[] {
            new Point3(-3f,2f,0),new Point3(-3f,1f,0)};
        public static readonly Point3[] e_lefttop2_05 = new Point3[] {
            new Point3(-3f,1f,0),new Point3(-3f,0f,0)};
        public static readonly Point3[] e_righttop2_01 = new Point3[] {
            new Point3(3f,5f,0),new Point3(3f,4f,0)};
        public static readonly Point3[] e_righttop2_02 = new Point3[] {
            new Point3(3f,4f,0),new Point3(3f,3f,0)};
        public static readonly Point3[] e_righttop2_03 = new Point3[] {
            new Point3(3f,3f,0),new Point3(3f,2f,0)};
        public static readonly Point3[] e_righttop2_04 = new Point3[] {
            new Point3(3f,2f,0),new Point3(3f,1f,0)};
        public static readonly Point3[] e_righttop2_05 = new Point3[] {
            new Point3(3f,1f,0),new Point3(3f,0f,0)};
        #endregion

        #region e_a_edgepoint
        static Point2[] e_a_e00 = new Point2[] { new Point2(130f, 0.5431795f), new Point2(77f, 0.752478f), new Point2(0f, 0.953157f), new Point2(283f, 0.752478f), new Point2(230f, 0.5431795f) };
        static Point2[] e_a_e01 = new Point2[] { new Point2(136f,0.8232833f),new Point2(59f,0.8373965f),new Point2(0f,0.6484846f),new Point2(301f,0.8373965f),new Point2(224f,0.8232833f)};
        static Point2[] e_a_e02 = new Point2[] { new Point2(180f, 0.7422286f), new Point2(92f, 0.7584565f), new Point2(0f, 0.703125f), new Point2(268f, 0.7584565f)};
        static Point2[] e_a_e03 = new Point2[] { new Point2(180f, 0.7421875f), new Point2(73f, 1.037916f), new Point2(0f, 0.7109804f), new Point2(287f, 1.037916f)};
        public static Point2[][] e_a_edge = {e_a_e00,e_a_e01,e_a_e02,e_a_e03 };
        #endregion

        #region e_b_edgepoint
        static Point2[] e_b_e00 = new Point2[] { new Point2(128f, 0.328218f), new Point2(71f, 0.5114056f), new Point2(0f, 0.40625f),new Point2(289f, 0.5114056f), new Point2(232f, 0.328218f) };
        static Point2[] e_b_e01 = new Point2[] { new Point2(180f,0.4453125f),new Point2(95f,0.4236796f),new Point2(47f,0.5859896f),new Point2(313f,0.5859896f),new Point2(265f,0.4236796f)};
        static Point2[] e_b_e02 = new Point2[] { new Point2(180f, 0.46875f), new Point2(64f, 0.7127809f), new Point2(296f, 0.7127809f)};
        static Point2[] e_b_e03 = new Point2[] { new Point2(124f, 0.4832396f), new Point2(42f, 0.4645647f), new Point2(318f, 0.4645647f), new Point2(236f, 0.4832396f)};
        static Point2[] e_b_e04 = new Point2[] { new Point2(180f, 0.46875f), new Point2(76f, 0.6196056f), new Point2(33f, 0.5027391f), new Point2(327f, 0.5027391f), new Point2(284f, 0.6196056f)};
        static Point2[] e_b_e05 = new Point2[] { new Point2(180f, 0.4297585f), new Point2(72f, 0.4694006f), new Point2(0f, 0.570366f), new Point2(288f, 0.4694006f) };
        public static Point2[][] e_b_edge = {e_b_e00,e_b_e01,e_b_e02,e_b_e03,e_b_e04,e_b_e05};
        #endregion

        #region bullet edge point
        public static Point2[] p_r_b03 = new Point2[] { new Point2(146f, 0.433365f), new Point2(34f, 0.433365f), new Point2(326f, 0.433365f), new Point2(214f, 0.433365f) };
        public static Point2[] p_e_b03 = new Point2[] { new Point2(153f, 0.2376079f), new Point2(27f, 0.2445699f), new Point2(333f, 0.2445699f), new Point2(207f, 0.2376079f) };
        public static Point2[] p_r_b04 = new Point2[] { new Point2(158f, 0.371402f), new Point2(22f, 0.3786444f), new Point2(338f, 0.3786444f), new Point2(202f, 0.371402f) };
        public static Point2[] p_e_b04 = new Point2[] { new Point2(180f, 0.2265625f), new Point2(90f, 0.0546875f), new Point2(0f, 0.2578125f), new Point2(270f, 0.0546875f) };
        public static Point2[] p_b_missile01 = new Point2[] { new Point2(166f, 0.2576941f), new Point2(14f, 0.2576941f), new Point2(346f, 0.2576941f), new Point2(194f, 0.2576941f) };
        #endregion

        #region uv_laser02
        public static Vector2[] t_uv_laser02 = new Vector2[] { new Vector2(0f, 0f), new Vector2(0f, 0.2084592f), new Vector2(1f, 0.2084592f), new Vector2(1f, 0f),
        new Vector2(0f,0.2175227f),new Vector2(0f,0.8f),new Vector2(0f,1f),new Vector2(1f,1f),new Vector2(1f,0.8f),new Vector2(1f,0.2175227f)};

        #endregion

        #region boss points
        public static Point2[] p_mothA = new Point2[] { new Point2(180f, 0.7734375f), new Point2(145f, 0.6502704f), new Point2(64f, 0.6184224f), new Point2(0f, 0.7890625f), new Point2(296f, 0.6184224f), new Point2(215f, 0.6502704f) };
        public static Point2[] p_mothB = new Point2[] { new Point2(180f, 0.7734375f), new Point2(91f, 1.836536f), new Point2(0f, 0.7890625f), new Point2(269f, 1.836536f), };
        public static Point2[] p_hjA = new Point2[] { new Point2(0,-1.7465f),new Point2(-1.638f,-0.074f),new Point2(0,0.78864f),new Point2(1.638f,-0.0746f)};
        public static Point2[] p_hjB = new Point2[] { new Point2(0, -1.7465f),new Point2(-1.6936f,-1.183f),new Point2(-2.1127f,0.04899f),new Point2(0, 0.78864f),new Point2(2.1127f,0.04899f),new Point2(1.6936f, -1.183f) };
        public static Point2[] p_a10 = new Point2[] { new Point2(180f, 1.15f), new Point2(80f, 1.31f), new Point2(0f, 1.13f), new Point2(280f, 1.31f) };
        #endregion
    }
}
