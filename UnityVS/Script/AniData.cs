using UnityEngine;

namespace Assets.UnityVS.Script
{
    class Ani:SP//animation data
    {
        #region moth
        static Vector2[] moth0_uv = new Vector2[] { new Vector2(0.296875f, 0.3359375f), new Vector2(0.296875f, 0.7421875f), new Vector2(0.7832031f, 0.7421875f), new Vector2(0.7832031f, 0.3359375f) };
        static Vector2[] moth1_uv = new Vector2[] { new Vector2(0.7832031f, 0.3359375f), new Vector2(0.7832031f, 0.7421875f), new Vector2(0.296875f, 0.7421875f), new Vector2(0.296875f, 0.3359375f) };
        static Vector2[] moth2_uv = new Vector2[] { new Vector2(0.7851563f, 0.4160156f), new Vector2(0.7851563f, 0.7988281f), new Vector2(0.921875f, 0.7988281f), new Vector2(0.921875f, 0.4160156f) };
        static Vector2[] moth3_uv = new Vector2[] { new Vector2(0.921875f, 0.4160156f), new Vector2(0.921875f, 0.7988281f), new Vector2(0.7851563f, 0.7988281f), new Vector2(0.7851563f, 0.4160156f) };
        static Vector2[] moth4_uv = new Vector2[] { new Vector2(0f, 0.6015625f), new Vector2(0f, 0.9980469f), new Vector2(0.2910156f, 0.9980469f), new Vector2(0.2910156f, 0.6015625f) };
        static Vector2[] moth5_uv = new Vector2[] { new Vector2(0.8066406f, 0.9589844f), new Vector2(0.8066406f, 0.9980469f), new Vector2(0.9199219f, 0.9980469f), new Vector2(0.9199219f, 0.9589844f) };
        static Vector2[] moth6_uv = new Vector2[] { new Vector2(0.71875f, 0.84375f), new Vector2(0.71875f, 0.9375f), new Vector2(0.6132813f, 0.9375f), new Vector2(0.6132813f, 0.84375f) };
        static Vector2[] moth7_uv = new Vector2[] { new Vector2(0.8710938f, 0.8242188f), new Vector2(0.8710938f, 0.953125f), new Vector2(0.796875f, 0.953125f), new Vector2(0.796875f, 0.8242188f) };
        static Vector2[] moth8_uv = new Vector2[] { new Vector2(0.9199219f, 0.9589844f), new Vector2(0.9199219f, 0.9980469f), new Vector2(0.8066406f, 0.9980469f), new Vector2(0.8066406f, 0.9589844f) };
        static Vector2[] moth9_uv = new Vector2[] { new Vector2(0.6132813f, 0.84375f), new Vector2(0.6132813f, 0.9375f), new Vector2(0.71875f, 0.9375f), new Vector2(0.71875f, 0.84375f) };
        static Vector2[] moth10_uv = new Vector2[] { new Vector2(0.796875f, 0.8242188f), new Vector2(0.796875f, 0.953125f), new Vector2(0.8710938f, 0.953125f), new Vector2(0.8710938f, 0.8242188f) };
        static Vector2[] moth11_uv = new Vector2[] { new Vector2(0.7265625f, 0.9375f), new Vector2(0.7265625f, 0.9960938f), new Vector2(0.6328125f, 0.9960938f), new Vector2(0.6328125f, 0.9375f) };
        static Vector2[] moth12_uv = new Vector2[] { new Vector2(0.8007813f, 0.8867188f), new Vector2(0.8007813f, 1f), new Vector2(0.7246094f, 1f), new Vector2(0.7246094f, 0.8867188f) };
        static Vector2[] moth13_uv = new Vector2[] { new Vector2(0.609375f, 0.7480469f), new Vector2(0.609375f, 0.9160156f), new Vector2(0.5390625f, 0.9160156f), new Vector2(0.5390625f, 0.7480469f) };
        static Vector2[] moth14_uv = new Vector2[] { new Vector2(0.6328125f, 0.9375f), new Vector2(0.6328125f, 0.9960938f), new Vector2(0.7265625f, 0.9960938f), new Vector2(0.7265625f, 0.9375f) };
        static Vector2[] moth15_uv = new Vector2[] { new Vector2(0.7246094f, 0.8867188f), new Vector2(0.7246094f, 1f), new Vector2(0.8007813f, 1f), new Vector2(0.8007813f, 0.8867188f) };
        static Vector2[] moth16_uv = new Vector2[] { new Vector2(0.5390625f, 0.7480469f), new Vector2(0.5390625f, 0.9160156f), new Vector2(0.609375f, 0.9160156f), new Vector2(0.609375f, 0.7480469f) };
        static Vector2[] moth17_uv = new Vector2[] { new Vector2(0.6308594f, 0.9355469f), new Vector2(0.6308594f, 0.9980469f), new Vector2(0.5429688f, 0.9980469f), new Vector2(0.5429688f, 0.9355469f) };
        static Vector2[] moth18_uv = new Vector2[] { new Vector2(0.5429688f, 0.8203125f), new Vector2(0.5429688f, 0.984375f), new Vector2(0.4570313f, 0.984375f), new Vector2(0.4570313f, 0.8203125f) };
        static Vector2[] moth19_uv = new Vector2[] { new Vector2(0.5429688f, 0.9355469f), new Vector2(0.5429688f, 0.9980469f), new Vector2(0.6308594f, 0.9980469f), new Vector2(0.6308594f, 0.9355469f) };
        static Vector2[] moth20_uv = new Vector2[] { new Vector2(0.4570313f, 0.8203125f), new Vector2(0.4570313f, 0.984375f), new Vector2(0.5429688f, 0.984375f), new Vector2(0.5429688f, 0.8203125f) };
        static Vector2[] moth21_uv = new Vector2[] { new Vector2(0.4375f, 0.8320313f), new Vector2(0.4375f, 0.9921875f), new Vector2(0.3027344f, 0.9921875f), new Vector2(0.3027344f, 0.8320313f) };
        static Vector2[] moth22_uv = new Vector2[] { new Vector2(0.3027344f, 0.8320313f), new Vector2(0.3027344f, 0.9921875f), new Vector2(0.4375f, 0.9921875f), new Vector2(0.4375f, 0.8320313f) };
        static Vector2[] moth23_uv = new Vector2[] { new Vector2(0.3007813f, 0.1230469f), new Vector2(0.3007813f, 0.3027344f), new Vector2(0.4277344f, 0.3027344f), new Vector2(0.4277344f, 0.1230469f) };
        static Vector2[] moth24_uv = new Vector2[] { new Vector2(0.4277344f, 0.1230469f), new Vector2(0.4277344f, 0.3027344f), new Vector2(0.3007813f, 0.3027344f), new Vector2(0.3007813f, 0.1230469f) };
        static Point2[] moth0_r = new Point2[] { new Point2(174f, 0.8334147f), new Point2(7f, 0.8023707f), new Point2(293f, 2.015761f), new Point2(246f, 2.028318f) };
        static Point2[] moth1_r = new Point2[] { new Point2(114f, 2.028318f), new Point2(67f, 2.015761f), new Point2(353f, 0.8023707f), new Point2(186f, 0.8334147f) };
        static Point2[] moth2_r = new Point2[] { new Point2(179f, 1.492515f), new Point2(39f, 0.05002441f), new Point2(274f, 0.5171025f), new Point2(199f, 1.578763f) };
        static Point2[] moth3_r = new Point2[] { new Point2(161f, 1.578763f), new Point2(86f, 0.5171025f), new Point2(321f, 0.05002441f), new Point2(181f, 1.492515f) };
        static Point2[] moth4_r = new Point2[] { new Point2(144f, 0.9781861f), new Point2(36f, 0.984499f), new Point2(324f, 0.989107f), new Point2(217f, 0.9828237f) };
        static Point2[] moth5_r = new Point2[] { new Point2(101f, 0.3983609f), new Point2(79f, 0.3983609f), new Point2(321f, 0.1000488f), new Point2(219f, 0.1000488f) };
        static Point2[] moth6_r = new Point2[] { new Point2(102f, 0.3677688f), new Point2(50f, 0.4661386f), new Point2(348f, 0.3033826f), new Point2(219f, 0.1000488f) };
        static Point2[] moth7_r = new Point2[] { new Point2(168f, 0.4627216f), new Point2(56f, 0.1126735f), new Point2(287f, 0.212523f), new Point2(204f, 0.4965703f) };
        static Point2[] moth8_r = new Point2[] { new Point2(141f, 0.1000488f), new Point2(39f, 0.1000488f), new Point2(281f, 0.3983609f), new Point2(259f, 0.3983609f) };
        static Point2[] moth9_r = new Point2[] { new Point2(141f, 0.1000488f), new Point2(12f, 0.3033826f), new Point2(310f, 0.4661386f), new Point2(258f, 0.3677688f) };
        static Point2[] moth10_r = new Point2[] { new Point2(156f, 0.4965703f), new Point2(73f, 0.212523f), new Point2(304f, 0.1126735f), new Point2(192f, 0.4627216f) };
        static Point2[] moth11_r = new Point2[] { new Point2(103f, 0.3203125f), new Point2(62f, 0.3529487f), new Point2(339f, 0.1755641f), new Point2(222f, 0.09407496f) };
        static Point2[] moth12_r = new Point2[] { new Point2(105f, 0.2672286f), new Point2(34f, 0.461533f), new Point2(353f, 0.3856717f), new Point2(214f, 0.08450511f) };
        static Point2[] moth13_r = new Point2[] { new Point2(167f, 0.6025763f), new Point2(59f, 0.1648049f), new Point2(301f, 0.1648049f), new Point2(193f, 0.6025763f) };
        static Point2[] moth14_r = new Point2[] { new Point2(138f, 0.09407496f), new Point2(21f, 0.1755641f), new Point2(298f, 0.3529487f), new Point2(257f, 0.3203125f) };
        static Point2[] moth15_r = new Point2[] { new Point2(146f, 0.08450511f), new Point2(7f, 0.3856717f), new Point2(326f, 0.461533f), new Point2(255f, 0.2672286f) };
        static Point2[] moth16_r = new Point2[] { new Point2(167f, 0.6025763f), new Point2(59f, 0.1648049f), new Point2(301f, 0.1648049f), new Point2(193f, 0.6025763f) };
        static Point2[] moth17_r = new Point2[] { new Point2(103f, 0.3050879f), new Point2(59f, 0.3470193f), new Point2(343f, 0.1878252f), new Point2(218f, 0.08907621f) };
        static Point2[] moth18_r = new Point2[] { new Point2(166f, 0.5798118f), new Point2(56f, 0.1690102f), new Point2(295f, 0.223716f), new Point2(200f, 0.5980518f) };
        static Point2[] moth19_r = new Point2[] { new Point2(142f, 0.08907621f), new Point2(17f, 0.1878252f), new Point2(301f, 0.3470193f), new Point2(257f, 0.3050879f) };
        static Point2[] moth20_r = new Point2[] { new Point2(160f, 0.5980518f), new Point2(65f, 0.223716f), new Point2(304f, 0.1690102f), new Point2(194f, 0.5798118f) };
        static Point2[] moth21_r = new Point2[] { new Point2(96f, 0.4874524f), new Point2(40f, 0.7602249f), new Point2(355f, 0.588484f), new Point2(225f, 0.07733981f) };
        static Point2[] moth22_r = new Point2[] { new Point2(135f, 0.07733981f), new Point2(5f, 0.588484f), new Point2(320f, 0.7602249f), new Point2(264f, 0.4874524f) };
        static Point2[] moth23_r = new Point2[] { new Point2(145f, 0.4377789f), new Point2(35f, 0.4377789f), new Point2(324f, 0.4422869f), new Point2(216f, 0.4422869f) };
        static Point2[] moth24_r = new Point2[] { new Point2(144f, 0.4422869f), new Point2(36f, 0.4422869f), new Point2(325f, 0.4377789f), new Point2(215f, 0.4377789f) };
        static AnimatEx moth0 = new AnimatEx() { parentid = -1, uv2 = moth0_uv, rect = moth0_r, pivot_p = new Point2(0f, 0f), scale = 1 };
        static AnimatEx moth1 = new AnimatEx() { parentid = -1, uv2 = moth1_uv, rect = moth1_r, pivot_p = new Point2(0f, 0f), scale = 1 };
        static AnimatEx moth2 = new AnimatEx() { parentid = -1, uv2 = moth2_uv, rect = moth2_r, pivot_p = new Point2(0f, 0f), scale = 1 };
        static AnimatEx moth3 = new AnimatEx() { parentid = -1, uv2 = moth3_uv, rect = moth3_r, pivot_p = new Point2(0f, 0f), scale = 1 };
        static AnimatEx moth4 = new AnimatEx() { parentid = -1, uv2 = moth4_uv, rect = moth4_r, pivot_p = new Point2(0f, 0f), scale = 1 };
        static AnimatEx moth5 = new AnimatEx() { parentid = 4, uv2 = moth5_uv, rect = moth5_r, pivot_p = new Point2(138f, 0.2322823f), scale = 1 };
        static AnimatEx moth6 = new AnimatEx() { parentid = 5, uv2 = moth6_uv, rect = moth6_r, pivot_p = new Point2(84f, 0.3062859f), scale = 1 };
        static AnimatEx moth7 = new AnimatEx() { parentid = 6, uv2 = moth7_uv, rect = moth7_r, pivot_p = new Point2(51f, 0.3831312f), scale = 1 };
        static AnimatEx moth8 = new AnimatEx() { parentid = 4, uv2 = moth8_uv, rect = moth8_r, pivot_p = new Point2(222f, 0.2322823f), scale = 1 };
        static AnimatEx moth9 = new AnimatEx() { parentid = 8, uv2 = moth9_uv, rect = moth9_r, pivot_p = new Point2(276f, 0.3062859f), scale = 1 };
        static AnimatEx moth10 = new AnimatEx() { parentid = 9, uv2 = moth10_uv, rect = moth10_r, pivot_p = new Point2(309f, 0.3831312f), scale = 1 };
        static AnimatEx moth11 = new AnimatEx() { parentid = 4, uv2 = moth11_uv, rect = moth11_r, pivot_p = new Point2(78f, 0.1516913f), scale = 1 };
        static AnimatEx moth12 = new AnimatEx() { parentid = 11, uv2 = moth12_uv, rect = moth12_r, pivot_p = new Point2(67f, 0.2626209f), scale = 1 };
        static AnimatEx moth13 = new AnimatEx() { parentid = 12, uv2 = moth13_uv, rect = moth13_r, pivot_p = new Point2(31f, 0.353726f), scale = 1 };
        static AnimatEx moth14 = new AnimatEx() { parentid = 4, uv2 = moth14_uv, rect = moth14_r, pivot_p = new Point2(282f, 0.1516913f), scale = 1 };
        static AnimatEx moth15 = new AnimatEx() { parentid = 14, uv2 = moth15_uv, rect = moth15_r, pivot_p = new Point2(293f, 0.2626209f), scale = 1 };
        static AnimatEx moth16 = new AnimatEx() { parentid = 15, uv2 = moth16_uv, rect = moth16_r, pivot_p = new Point2(329f, 0.353726f), scale = 1 };
        static AnimatEx moth17 = new AnimatEx() { parentid = 4, uv2 = moth17_uv, rect = moth17_r, pivot_p = new Point2(21f, 0.2002501f), scale = 1 };
        static AnimatEx moth18 = new AnimatEx() { parentid = 17, uv2 = moth18_uv, rect = moth18_r, pivot_p = new Point2(58f, 0.266657f), scale = 1 };
        static AnimatEx moth19 = new AnimatEx() { parentid = 4, uv2 = moth19_uv, rect = moth19_r, pivot_p = new Point2(339f, 0.2002501f), scale = 1 };
        static AnimatEx moth20 = new AnimatEx() { parentid = 19, uv2 = moth20_uv, rect = moth20_r, pivot_p = new Point2(302f, 0.266657f), scale = 1 };
        static AnimatEx moth21 = new AnimatEx() { parentid = 4, uv2 = moth21_uv, rect = moth21_r, pivot_p = new Point2(16f, 0.5043754f), scale = 1 };
        static AnimatEx moth22 = new AnimatEx() { parentid = 4, uv2 = moth22_uv, rect = moth22_r, pivot_p = new Point2(344f, 0.5043754f), scale = 1 };
        static AnimatEx moth23 = new AnimatEx() { parentid = -1, uv2 = moth23_uv, rect = moth23_r, pivot_p = new Point2(230f, 0.33f), scale = 1 };
        static AnimatEx moth24 = new AnimatEx() { parentid = -1, uv2 = moth24_uv, rect = moth24_r, pivot_p = new Point2(130f, 0.33f), scale = 1 };
        public static AnimatBaseEx moth = new AnimatBaseEx() {ani_ini=Ani_Motion.Moth_stage0,stage=new AniRun[] {Ani_Motion.Moth_stageA },  ae = new AnimatEx[] { moth0, moth1, moth2, moth3, moth4, moth5, moth6, moth7, moth8, moth9, moth10, moth11, moth12, moth13, moth14, moth15, moth16, moth17, moth18, moth19, moth20, moth21, moth22, moth23, moth24 } };
        #endregion

        #region jifeng
        static Vector2[] jf0_uv = new Vector2[] { new Vector2(0.05405406f, 0.05035971f), new Vector2(0.05405406f, 1f), new Vector2(0.3813814f, 1f), new Vector2(0.3813814f, 0.05035971f) };
        static Vector2[] jf1_uv = new Vector2[] { new Vector2(0.4024024f, 0.2517986f), new Vector2(0.4024024f, 1f), new Vector2(0.972973f, 1f), new Vector2(0.972973f, 0.2517986f) };
        static Vector2[] jf2_uv = new Vector2[] { new Vector2(0.972973f, 0.2517986f), new Vector2(0.972973f, 1f), new Vector2(0.4024024f, 1f), new Vector2(0.4024024f, 0.2517986f) };
        static Point2[] jf0_r = new Point2[] { new Point2(139f, 0.6202948f), new Point2(36f, 0.6938626f), new Point2(322f, 0.7174326f), new Point2(224f, 0.6465522f) };
        static Point2[] jf1_r = new Point2[] { new Point2(95f, 0.7610675f), new Point2(46f, 1.060718f), new Point2(316f, 1.038622f), new Point2(264f, 0.7299568f) };
        static Point2[] jf2_r = new Point2[] { new Point2(96f, 0.7299568f), new Point2(44f, 1.038622f), new Point2(314f, 1.060718f), new Point2(265f, 0.7610675f) };
        static AnimatEx jf0 = new AnimatEx() { parentid = -1, uv2 = jf0_uv, rect = jf0_r, pivot_p = new Point2(0f, 0f), scale = 1 };
        static AnimatEx jf1 = new AnimatEx() { parentid = -1, uv2 = jf1_uv, rect = jf1_r, pivot_p = new Point2(263f, 0.4011854f), scale = 1 };
        static AnimatEx jf2 = new AnimatEx() { parentid = -1, uv2 = jf2_uv, rect = jf2_r, pivot_p = new Point2(97f, 0.4011854f), scale = 1 };
        public static AnimatBaseEx jf = new AnimatBaseEx() {ani_ini=Ani_Motion.jifeng_stage0,stage=new AniRun[] {Ani_Motion.jifeng_stage2,Ani_Motion.jifeng_stage3 }, ae = new AnimatEx[] { jf1, jf2, jf1, jf2, jf0 } };
        #endregion

        #region nouhuo
        static Vector2[] nh0_uv = new Vector2[] { new Vector2(0f, 0.1806452f), new Vector2(0f, 1f), new Vector2(0.4814815f, 1f), new Vector2(0.4814815f, 0.1806452f) };
        static Vector2[] nh1_uv = new Vector2[] { new Vector2(0.7148148f, 0.01935484f), new Vector2(0.7148148f, 1f), new Vector2(0.5444444f, 1f), new Vector2(0.5444444f, 0.01935484f) };
        static Vector2[] nh2_uv = new Vector2[] { new Vector2(0.962963f, 0.006451613f), new Vector2(0.962963f, 1f), new Vector2(0.8f, 1f), new Vector2(0.8f, 0.006451613f) };
        static Vector2[] nh3_uv = new Vector2[] { new Vector2(0.5444444f, 0.01935484f), new Vector2(0.5444444f, 1f), new Vector2(0.7148148f, 1f), new Vector2(0.7148148f, 0.01935484f) };
        static Vector2[] nh4_uv = new Vector2[] { new Vector2(0.8f, 0.006451613f), new Vector2(0.8f, 1f), new Vector2(0.962963f, 1f), new Vector2(0.962963f, 0.006451613f) };
        static Point2[] nh0_r = new Point2[] { new Point2(134f, 0.7071931f), new Point2(45f, 0.7126524f), new Point2(315f, 0.7126524f), new Point2(226f, 0.7071931f) };
        static Point2[] nh1_r = new Point2[] { new Point2(103f, 0.1364394f), new Point2(7f, 1.163853f), new Point2(349f, 1.178238f), new Point2(262f, 0.2287075f) };
        static Point2[] nh2_r = new Point2[] { new Point2(105f, 0.1781524f), new Point2(8f, 1.168955f), new Point2(352f, 1.168955f), new Point2(255f, 0.1781524f) };
        static Point2[] nh3_r = new Point2[] { new Point2(98f, 0.2287075f), new Point2(11f, 1.178238f), new Point2(353f, 1.163853f), new Point2(257f, 0.1364394f) };
        static Point2[] nh4_r = new Point2[] { new Point2(105f, 0.1781524f), new Point2(8f, 1.168955f), new Point2(352f, 1.168955f), new Point2(255f, 0.1781524f) };
        static AnimatEx nh0 = new AnimatEx() { parentid = -1, uv2 = nh0_uv, rect = nh0_r, pivot_p = new Point2(0f, 0f), scale = 1 };
        static AnimatEx nh1 = new AnimatEx() { parentid = -1, uv2 = nh1_uv, rect = nh1_r, pivot_p = new Point2(126f, 0.2515819f), scale = 1 };
        static AnimatEx nh2 = new AnimatEx() { parentid = -1, uv2 = nh2_uv, rect = nh2_r, pivot_p = new Point2(126f, 0.2515819f), scale = 1 };
        static AnimatEx nh3 = new AnimatEx() { parentid = -1, uv2 = nh3_uv, rect = nh3_r, pivot_p = new Point2(234f, 0.2515819f), scale = 1 };
        static AnimatEx nh4 = new AnimatEx() { parentid = -1, uv2 = nh4_uv, rect = nh4_r, pivot_p = new Point2(234f, 0.2515819f), scale = 1 };
        public static AnimatBaseEx nh = new AnimatBaseEx() {ani_ini=Ani_Motion.nh_stage0,stage=new AniRun[] {Ani_Motion.nh_stage1,Ani_Motion.nh_stage2 }, ae = new AnimatEx[] { nh1, nh1, nh1, nh1, nh2, nh3, nh3, nh3, nh3, nh4, nh0 } };
        #endregion

        #region zhihui
        static Vector2[] zhh0_uv = new Vector2[] { new Vector2(0.1451991f, 0.7731093f), new Vector2(0.1451991f, 0.9957983f), new Vector2(0.1217799f, 0.9957983f), new Vector2(0.1217799f, 0.7731093f) };
        static Vector2[] zhh1_uv = new Vector2[] { new Vector2(0.1978923f, 0.7142857f), new Vector2(0.1978923f, 0.9957983f), new Vector2(0.14637f, 0.9957983f), new Vector2(0.14637f, 0.7142857f) };
        static Vector2[] zhh2_uv = new Vector2[] { new Vector2(0.3126464f, 0.7394958f), new Vector2(0.3126464f, 1f), new Vector2(0.2002342f, 1f), new Vector2(0.2002342f, 0.7394958f) };
        static Vector2[] zhh3_uv = new Vector2[] { new Vector2(0.2459016f, 0.4537815f), new Vector2(0.2459016f, 0.7058824f), new Vector2(0.1323185f, 0.7058824f), new Vector2(0.1323185f, 0.4537815f) };
        static Vector2[] zhh4_uv = new Vector2[] { new Vector2(0.1592506f, 0.2857143f), new Vector2(0.1592506f, 0.3697479f), new Vector2(0.03395785f, 0.3697479f), new Vector2(0.03395785f, 0.2857143f) };
        static Vector2[] zhh5_uv = new Vector2[] { new Vector2(0.3220141f, 0.5210084f), new Vector2(0.3220141f, 0.7058824f), new Vector2(0.2482436f, 0.7058824f), new Vector2(0.2482436f, 0.5210084f) };
        static Vector2[] zhh6_uv = new Vector2[] { new Vector2(0.2377049f, 0.184874f), new Vector2(0.2377049f, 0.3613445f), new Vector2(0.2014052f, 0.3613445f), new Vector2(0.2014052f, 0.184874f) };
        static Vector2[] zhh7_uv = new Vector2[] { new Vector2(0.2810304f, 0.1470588f), new Vector2(0.2810304f, 0.3277311f), new Vector2(0.264637f, 0.3277311f), new Vector2(0.264637f, 0.1470588f) };
        static Vector2[] zhh8_uv = new Vector2[] { new Vector2(0.1217799f, 0.7731093f), new Vector2(0.1217799f, 0.9957983f), new Vector2(0.1451991f, 0.9957983f), new Vector2(0.1451991f, 0.7731093f) };
        static Vector2[] zhh9_uv = new Vector2[] { new Vector2(0.14637f, 0.7142857f), new Vector2(0.14637f, 0.9957983f), new Vector2(0.1978923f, 0.9957983f), new Vector2(0.1978923f, 0.7142857f) };
        static Vector2[] zhh10_uv = new Vector2[] { new Vector2(0.2002342f, 0.7394958f), new Vector2(0.2002342f, 1f), new Vector2(0.3126464f, 1f), new Vector2(0.3126464f, 0.7394958f) };
        static Vector2[] zhh11_uv = new Vector2[] { new Vector2(0.1323185f, 0.4537815f), new Vector2(0.1323185f, 0.7058824f), new Vector2(0.2459016f, 0.7058824f), new Vector2(0.2459016f, 0.4537815f) };
        static Vector2[] zhh12_uv = new Vector2[] { new Vector2(0.03395785f, 0.2857143f), new Vector2(0.03395785f, 0.3697479f), new Vector2(0.1592506f, 0.3697479f), new Vector2(0.1592506f, 0.2857143f) };
        static Vector2[] zhh13_uv = new Vector2[] { new Vector2(0.2482436f, 0.5210084f), new Vector2(0.2482436f, 0.7058824f), new Vector2(0.3220141f, 0.7058824f), new Vector2(0.3220141f, 0.5210084f) };
        static Vector2[] zhh14_uv = new Vector2[] { new Vector2(0.2014052f, 0.184874f), new Vector2(0.2014052f, 0.3613445f), new Vector2(0.2377049f, 0.3613445f), new Vector2(0.2377049f, 0.184874f) };
        static Vector2[] zhh15_uv = new Vector2[] { new Vector2(0.264637f, 0.1470588f), new Vector2(0.264637f, 0.3277311f), new Vector2(0.2810304f, 0.3277311f), new Vector2(0.2810304f, 0.1470588f) };
        static Vector2[] zhh16_uv = new Vector2[] { new Vector2(0f, 0.02941176f), new Vector2(0f, 0.407563f), new Vector2(0.03161592f, 0.407563f), new Vector2(0.03161592f, 0.02941176f) };
        static Vector2[] zhh17_uv = new Vector2[] { new Vector2(0.004683841f, 0.4159664f), new Vector2(0.004683841f, 0.9831933f), new Vector2(0.06206089f, 0.9831933f), new Vector2(0.06206089f, 0.4159664f) };
        static Vector2[] zhh18_uv = new Vector2[] { new Vector2(0.08782201f, 0.6428571f), new Vector2(0.08782201f, 0.9915966f), new Vector2(0.06206089f, 0.9915966f), new Vector2(0.06206089f, 0.6428571f) };
        static Vector2[] zhh19_uv = new Vector2[] { new Vector2(0.117096f, 0.6386555f), new Vector2(0.117096f, 0.9915966f), new Vector2(0.09250586f, 0.9915966f), new Vector2(0.09250586f, 0.6386555f) };
        static Vector2[] zhh20_uv = new Vector2[] { new Vector2(0.1288056f, 0.3865546f), new Vector2(0.1288056f, 0.6176471f), new Vector2(0.08899298f, 0.6176471f), new Vector2(0.08899298f, 0.3865546f) };
        static Vector2[] zhh21_uv = new Vector2[] { new Vector2(0.08665106f, 0.4117647f), new Vector2(0.08665106f, 0.6134454f), new Vector2(0.06206089f, 0.6134454f), new Vector2(0.06206089f, 0.4117647f) };
        static Vector2[] zhh22_uv = new Vector2[] { new Vector2(0.06206089f, 0.6428571f), new Vector2(0.06206089f, 0.9915966f), new Vector2(0.08782201f, 0.9915966f), new Vector2(0.08782201f, 0.6428571f) };
        static Vector2[] zhh23_uv = new Vector2[] { new Vector2(0.09250586f, 0.6386555f), new Vector2(0.09250586f, 0.9915966f), new Vector2(0.117096f, 0.9915966f), new Vector2(0.117096f, 0.6386555f) };
        static Vector2[] zhh24_uv = new Vector2[] { new Vector2(0.08899298f, 0.3865546f), new Vector2(0.08899298f, 0.6176471f), new Vector2(0.1288056f, 0.6176471f), new Vector2(0.1288056f, 0.3865546f) };
        static Vector2[] zhh25_uv = new Vector2[] { new Vector2(0.06206089f, 0.4117647f), new Vector2(0.06206089f, 0.6134454f), new Vector2(0.08665106f, 0.6134454f), new Vector2(0.08665106f, 0.4117647f) };
        static Vector2[] zhh26_uv = new Vector2[] { new Vector2(0.5140515f, 0.6344538f), new Vector2(0.5140515f, 0.7436975f), new Vector2(0.5503513f, 0.7436975f), new Vector2(0.5503513f, 0.6344538f) };
        static Vector2[] zhh27_uv = new Vector2[] { new Vector2(0.5152225f, 0.5126051f), new Vector2(0.5152225f, 0.6218488f), new Vector2(0.5515223f, 0.6218488f), new Vector2(0.5515223f, 0.5126051f) };
        static Point2[] zhh0_r = new Point2[] { new Point2(104f, 0.128847f), new Point2(18f, 0.4027039f), new Point2(355f, 0.3840859f), new Point2(225f, 0.04419417f) };
        static Point2[] zhh1_r = new Point2[] { new Point2(98f, 0.3237242f), new Point2(34f, 0.5742055f), new Point2(357f, 0.4771385f), new Point2(207f, 0.05240784f) };
        static Point2[] zhh2_r = new Point2[] { new Point2(92f, 0.7350396f), new Point2(58f, 0.8629189f), new Point2(358f, 0.4533943f), new Point2(207f, 0.03493856f) };
        static Point2[] zhh3_r = new Point2[] { new Point2(91f, 0.7501627f), new Point2(59f, 0.8762547f), new Point2(359f, 0.4531924f), new Point2(207f, 0.01746928f) };
        static Point2[] zhh4_r = new Point2[] { new Point2(95f, 0.8311046f), new Point2(84f, 0.8325721f), new Point2(355f, 0.08629188f), new Point2(186f, 0.0707452f) };
        static Point2[] zhh5_r = new Point2[] { new Point2(126f, 0.576698f), new Point2(89f, 0.4688151f), new Point2(288f, 0.02470529f), new Point2(184f, 0.3367541f) };
        static Point2[] zhh6_r = new Point2[] { new Point2(143f, 0.3796907f), new Point2(84f, 0.2277716f), new Point2(326f, 0.02816837f), new Point2(183f, 0.3050879f) };
        static Point2[] zhh7_r = new Point2[] { new Point2(165f, 0.3391921f), new Point2(85f, 0.08629188f), new Point2(288f, 0.02470529f), new Point2(184f, 0.328961f) };
        static Point2[] zhh8_r = new Point2[] { new Point2(135f, 0.04419417f), new Point2(5f, 0.3840859f), new Point2(342f, 0.4027039f), new Point2(256f, 0.128847f) };
        static Point2[] zhh9_r = new Point2[] { new Point2(153f, 0.05240784f), new Point2(3f, 0.4771385f), new Point2(326f, 0.5742055f), new Point2(262f, 0.3237242f) };
        static Point2[] zhh10_r = new Point2[] { new Point2(153f, 0.03493856f), new Point2(2f, 0.4533943f), new Point2(302f, 0.8629189f), new Point2(268f, 0.7350396f) };
        static Point2[] zhh11_r = new Point2[] { new Point2(153f, 0.01746928f), new Point2(1f, 0.4531924f), new Point2(301f, 0.8762547f), new Point2(269f, 0.7501627f) };
        static Point2[] zhh12_r = new Point2[] { new Point2(174f, 0.0707452f), new Point2(5f, 0.08629188f), new Point2(276f, 0.8325721f), new Point2(265f, 0.8311046f) };
        static Point2[] zhh13_r = new Point2[] { new Point2(176f, 0.3367541f), new Point2(72f, 0.02470529f), new Point2(271f, 0.4688151f), new Point2(234f, 0.576698f) };
        static Point2[] zhh14_r = new Point2[] { new Point2(177f, 0.3050879f), new Point2(34f, 0.02816837f), new Point2(276f, 0.2277716f), new Point2(217f, 0.3796907f) };
        static Point2[] zhh15_r = new Point2[] { new Point2(176f, 0.328961f), new Point2(72f, 0.02470529f), new Point2(275f, 0.08629188f), new Point2(195f, 0.3391921f) };
        static Point2[] zhh16_r = new Point2[] { new Point2(172f, 0.7026908f), new Point2(86f, 0.1018625f), new Point2(274f, 0.1096537f), new Point2(189f, 0.7038625f) };
        static Point2[] zhh17_r = new Point2[] { new Point2(160f, 0.5560064f), new Point2(19f, 0.5633674f), new Point2(340f, 0.5660155f), new Point2(200f, 0.5586894f) };
        static Point2[] zhh18_r = new Point2[] { new Point2(113f, 0.1015625f), new Point2(9f, 0.6165444f), new Point2(353f, 0.6143626f), new Point2(243f, 0.0873464f) };
        static Point2[] zhh19_r = new Point2[] { new Point2(107f, 0.1631298f), new Point2(14f, 0.6290882f), new Point2(359f, 0.6094251f), new Point2(189f, 0.04752158f) };
        static Point2[] zhh20_r = new Point2[] { new Point2(97f, 0.2441953f), new Point2(31f, 0.4662695f), new Point2(357f, 0.3991262f), new Point2(217f, 0.0390625f) };
        static Point2[] zhh21_r = new Point2[] { new Point2(105f, 0.1534913f), new Point2(24f, 0.3672706f), new Point2(357f, 0.3363007f), new Point2(202f, 0.0420716f) };
        static Point2[] zhh22_r = new Point2[] { new Point2(117f, 0.0873464f), new Point2(7f, 0.6143626f), new Point2(351f, 0.6165444f), new Point2(247f, 0.1015625f) };
        static Point2[] zhh23_r = new Point2[] { new Point2(171f, 0.04752158f), new Point2(1f, 0.6094251f), new Point2(346f, 0.6290882f), new Point2(253f, 0.1631298f) };
        static Point2[] zhh24_r = new Point2[] { new Point2(143f, 0.0390625f), new Point2(3f, 0.3991262f), new Point2(329f, 0.4662695f), new Point2(263f, 0.2441953f) };
        static Point2[] zhh25_r = new Point2[] { new Point2(158f, 0.0420716f), new Point2(3f, 0.3363007f), new Point2(336f, 0.3672706f), new Point2(255f, 0.1534913f) };
        static Point2[] zhh26_r = new Point2[] { new Point2(131f, 0.1550737f), new Point2(49f, 0.1550737f), new Point2(309f, 0.1610588f), new Point2(231f, 0.1610588f) };
        static Point2[] zhh27_r = new Point2[] { new Point2(131f, 0.1550737f), new Point2(49f, 0.1550737f), new Point2(309f, 0.1610588f), new Point2(231f, 0.1610588f) };
        static AnimatEx zhh0 = new AnimatEx() { parentid = -1, uv2 = zhh0_uv, rect = zhh0_r, pivot_p = new Point2(30f, 0.1f) };
        static AnimatEx zhh1 = new AnimatEx() { parentid = -1, uv2 = zhh1_uv, rect = zhh1_r, pivot_p = new Point2(65f, 0.15f)};
        static AnimatEx zhh2 = new AnimatEx() { parentid = -1, uv2 = zhh2_uv, rect = zhh2_r, pivot_p = new Point2(60f, 0.4f) };
        static AnimatEx zhh3 = new AnimatEx() { parentid = -1, uv2 = zhh3_uv, rect = zhh3_r, pivot_p = new Point2(110f, 0.3f)};
        static AnimatEx zhh4 = new AnimatEx() { parentid = -1, uv2 = zhh4_uv, rect = zhh4_r, pivot_p = new Point2(110f, 0.4f) };
        static AnimatEx zhh5 = new AnimatEx() { parentid = -1, uv2 = zhh5_uv, rect = zhh5_r, pivot_p = new Point2(120f, 0.4f) };
        static AnimatEx zhh6 = new AnimatEx() { parentid = -1, uv2 = zhh6_uv, rect = zhh6_r, pivot_p = new Point2(140f, 0.4f)};
        static AnimatEx zhh7 = new AnimatEx() { parentid = -1, uv2 = zhh7_uv, rect = zhh7_r, pivot_p = new Point2(160f, 0.4f)};//left7
        static AnimatEx zhh8 = new AnimatEx() { parentid = -1, uv2 = zhh8_uv, rect = zhh8_r, pivot_p = new Point2(330f, 0.1f) };
        static AnimatEx zhh9 = new AnimatEx() { parentid = -1, uv2 = zhh9_uv, rect = zhh9_r, pivot_p = new Point2(290f, 0.15f) };
        static AnimatEx zhh10 = new AnimatEx() { parentid = -1, uv2 = zhh10_uv, rect = zhh10_r, pivot_p = new Point2(300f, 0.4f) };
        static AnimatEx zhh11 = new AnimatEx() { parentid = -1, uv2 = zhh11_uv, rect = zhh11_r, pivot_p = new Point2(250f, 0.3f)};
        static AnimatEx zhh12 = new AnimatEx() { parentid = -1, uv2 = zhh12_uv, rect = zhh12_r, pivot_p = new Point2(250f, 0.4f)};
        static AnimatEx zhh13 = new AnimatEx() { parentid = -1, uv2 = zhh13_uv, rect = zhh13_r, pivot_p = new Point2(240f, 0.4f) };
        static AnimatEx zhh14 = new AnimatEx() { parentid = -1, uv2 = zhh14_uv, rect = zhh14_r, pivot_p = new Point2(220f, 0.4f)};
        static AnimatEx zhh15 = new AnimatEx() { parentid = -1, uv2 = zhh15_uv, rect = zhh15_r, pivot_p = new Point2(200f, 0.4f)};//right15
        static AnimatEx zhh16 = new AnimatEx() { parentid = -1, uv2 = zhh16_uv, rect = zhh16_r, pivot_p = new Point2(180f, 0.4f) };//down16
        static AnimatEx zhh17 = new AnimatEx() { parentid = -1, uv2 = zhh17_uv, rect = zhh17_r, pivot_p = new Point2(0f, 0f), scale = 1 };//main17
        static AnimatEx zhh18 = new AnimatEx() { parentid = 17, uv2 = zhh18_uv, rect = zhh18_r, pivot_p = new Point2(146f, 0.3f), scale = 1 };
        static AnimatEx zhh19 = new AnimatEx() { parentid = 17, uv2 = zhh19_uv, rect = zhh19_r, pivot_p = new Point2(146f, 0.34f), scale = 1 };
        static AnimatEx zhh20 = new AnimatEx() { parentid = 17, uv2 = zhh20_uv, rect = zhh20_r, pivot_p = new Point2(146f, 0.4f), scale = 1 };
        static AnimatEx zhh21 = new AnimatEx() { parentid = 17, uv2 = zhh21_uv, rect = zhh21_r, pivot_p = new Point2(146f, 0.4f), scale = 1 };//left21
        static AnimatEx zhh22 = new AnimatEx() { parentid = 17, uv2 = zhh22_uv, rect = zhh22_r, pivot_p = new Point2(214f, 0.3f), scale = 1 };
        static AnimatEx zhh23 = new AnimatEx() { parentid = 17, uv2 = zhh23_uv, rect = zhh23_r, pivot_p = new Point2(214f, 0.34f), scale = 1 };
        static AnimatEx zhh24 = new AnimatEx() { parentid = 17, uv2 = zhh24_uv, rect = zhh24_r, pivot_p = new Point2(214f, 0.4f), scale = 1 };
        static AnimatEx zhh25 = new AnimatEx() { parentid = 17, uv2 = zhh25_uv, rect = zhh25_r, pivot_p = new Point2(214f, 0.4f), scale = 1 };//right25
        static AnimatEx zhh26 = new AnimatEx() { free = true, parentid = -1, uv2 = zhh26_uv, rect = zhh26_r, pivot_p = new Point2(0f, 0f)};
        static AnimatEx zhh27 = new AnimatEx() { free = true, parentid = -1, uv2 = zhh27_uv, rect = zhh27_r, pivot_p = new Point2(0f, 0f)};
        public static AnimatBaseEx zhh = new AnimatBaseEx() { ani_ini=Ani_Motion.zhh_stage0,stage=new AniRun[] {Ani_Motion.zhh_stage1,Ani_Motion.zhh_stage2 }, ae = new AnimatEx[] { zhh0, zhh1, zhh2, zhh3, zhh4, zhh5, zhh6, zhh7, zhh8, zhh9, zhh10, zhh11, zhh12, zhh13, zhh14, zhh15, zhh16, zhh17, zhh18, zhh19, zhh20, zhh21, zhh22, zhh23, zhh24, zhh25, zhh26, zhh26, zhh27, zhh27 } };//30
        #endregion

        #region bigboom
        static AnimatEx bb00 = new AnimatEx() { parentid = -1, uv2 = uv_def_5x2[0], rect = uv_256x256 };
        static AnimatEx bb01 = new AnimatEx() { parentid = -1, uv2 = uv_def_5x2[1], rect = uv_256x256 };
        static AnimatEx bb02 = new AnimatEx() { parentid = -1, uv2 = uv_def_5x2[2], rect = uv_256x256 };
        static AnimatEx bb03 = new AnimatEx() { parentid = -1, uv2 = uv_def_5x2[3], rect = uv_256x256 };
        static AnimatEx bb04 = new AnimatEx() { parentid = -1, uv2 = uv_def_5x2[4], rect = uv_256x256 };
        static AnimatEx bb05 = new AnimatEx() { parentid = -1, uv2 = uv_def_5x2[5], rect = uv_256x256 };
        static AnimatEx bb06 = new AnimatEx() { parentid = -1, uv2 = uv_def_5x2[6], rect = uv_256x256 };
        static AnimatEx bb07 = new AnimatEx() { parentid = -1, uv2 = uv_def_5x2[7], rect = uv_256x256 };
        static AnimatEx bb08 = new AnimatEx() { parentid = -1, uv2 = uv_def_5x2[8], rect = uv_256x256 };
        static AnimatEx bb09 = new AnimatEx() { parentid = -1, uv2 = uv_def_5x2[9], rect = uv_256x256 };
        public static AnimatBaseEx bigboom = new AnimatBaseEx() { stage=new AniRun[] { Ani_Motion.bb_stage1},ae=new AnimatEx[] { bb00,bb01,bb02,bb03,bb04,bb05,bb06,bb07,bb08,bb09} };
        #endregion

        #region wing guan chuan
        static Vector3[] w_gc_v = new Vector3 [ ]{new Vector3(-1.14453125f, -0.18359375f),new Vector3(-1.14453125f, 0.18359375f),new Vector3(-0.85546875f, 0.18359375f),new Vector3(-0.85546875f, -0.18359375f),
            new Vector3(0.85546875f, -0.18359375f),new Vector3(0.85546875f, 0.18359375f),new Vector3(1.14453125f, 0.18359375f),new Vector3(1.14453125f, -0.18359375f)};
        static Vector2[] w_tuv = new Vector2[] {new Vector2(0,0),new Vector2(0,1),new Vector2(1,1),new Vector2(1,0),
        new Vector2(0,0),new Vector2(0,1),new Vector2(1,1),new Vector2(1,0)};
        public static AnimatBaseEx w_gc = new AnimatBaseEx() { vertex=w_gc_v, uv=w_tuv,tri=tri_def2 };
        #endregion

        #region wing ra2l
        static Point2[] w_ra2l_p = new Point2[] {new Point2(135f,0.4529903f),new Point2(45f,0.4529903f),new Point2(315f,0.4529903f),new Point2(225f,0.4529903f)};
        static AnimatEx wra2l00 = new AnimatEx() {uv2=uv_def_1x1,scale=1,free=true,parentid=-1,rect=w_ra2l_p,location=new Point2(-1,0) };
        static AnimatEx wra2l01 = new AnimatEx() { uv2 = uv_def_1x1, scale = 1, free = true, parentid = -1, rect = w_ra2l_p, location = new Point2(1, 0) };
        public static AnimatBaseEx w_ra2l = new AnimatBaseEx() {stage=new AniRun[] { Ani_Motion.ra2l_stage1}, ae=new AnimatEx[] {wra2l00,wra2l01 } ,tri=tri_def2};
        #endregion
    }
}
