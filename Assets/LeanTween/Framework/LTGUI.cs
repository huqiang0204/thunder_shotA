using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class LTGUI
{
    public static int RECT_LEVELS = 5;
    public static int RECTS_PER_LEVEL = 10;
    public static int BUTTONS_MAX = 24;

    private static LTRect[] levels;
    private static int[] levelDepths;
    private static Rect[] buttons;
    private static int[] buttonLevels;
    private static int[] buttonLastFrame;
    private static LTRect r;
    private static Color color = Color.white;
    private static bool isGUIEnabled = false;
    private static int global_counter = 0;

    public enum Element_Type
    {
        Texture,
        Label
    }

    public static void init()
    {
        if (levels == null)
        {
            levels = new LTRect[RECT_LEVELS * RECTS_PER_LEVEL];
            levelDepths = new int[RECT_LEVELS];
        }
    }

    public static void initRectCheck()
    {
        if (buttons == null)
        {
            buttons = new Rect[BUTTONS_MAX];
            buttonLevels = new int[BUTTONS_MAX];
            buttonLastFrame = new int[BUTTONS_MAX];
            for (int i = 0; i < buttonLevels.Length; i++)
            {
                buttonLevels[i] = -1;
            }
        }
    }

    public static void reset()
    {
        if (isGUIEnabled)
        {
            isGUIEnabled = false;
            for (int i = 0; i < levels.Length; i++)
            {
                levels[i] = null;
            }

            for (int i = 0; i < levelDepths.Length; i++)
            {
                levelDepths[i] = 0;
            }
        }
    }

    public static void update(int updateLevel)
    {
        if (isGUIEnabled)
        {
            init();
            if (levelDepths[updateLevel] > 0)
            {
                color = GUI.color;
                int baseI = updateLevel * RECTS_PER_LEVEL;
                int maxLoop = baseI + levelDepths[updateLevel];// RECTS_PER_LEVEL;//;

                for (int i = baseI; i < maxLoop; i++)
                {
                    r = levels[i];
                    // Debug.Log("r:"+r+" i:"+i);
                    if (r != null /*&& checkOnScreen(r.rect)*/)
                    {
                        //Debug.Log("label:"+r.labelStr+" textColor:"+r.style.normal.textColor);
                        if (r.useColor)
                            GUI.color = r.color;
                        if (r.type == Element_Type.Label)
                        {
                            if (r.style != null)
                                GUI.skin.label = r.style;
                            if (r.useSimpleScale)
                            {
                                GUI.Label(new Rect((r.rect.x + r.margin.x + r.relativeRect.x) * r.relativeRect.width, (r.rect.y + r.margin.y + r.relativeRect.y) * r.relativeRect.height, r.rect.width * r.relativeRect.width, r.rect.height * r.relativeRect.height), r.labelStr);
                            }
                            else
                            {
                                GUI.Label(new Rect(r.rect.x + r.margin.x, r.rect.y + r.margin.y, r.rect.width, r.rect.height), r.labelStr);
                            }
                        }
                        else if (r.type == Element_Type.Texture && r.texture != null)
                        {
                            Vector2 size = r.useSimpleScale ? new Vector2(0f, r.rect.height * r.relativeRect.height) : new Vector2(r.rect.width, r.rect.height);
                            if (r.sizeByHeight)
                            {
                                size.x = (float)r.texture.width / (float)r.texture.height * size.y;
                            }
                            if (r.useSimpleScale)
                            {
                                GUI.DrawTexture(new Rect((r.rect.x + r.margin.x + r.relativeRect.x) * r.relativeRect.width, (r.rect.y + r.margin.y + r.relativeRect.y) * r.relativeRect.height, size.x, size.y), r.texture);
                            }
                            else
                            {
                                GUI.DrawTexture(new Rect(r.rect.x + r.margin.x, r.rect.y + r.margin.y, size.x, size.y), r.texture);
                            }
                        }
                    }
                }
                GUI.color = color;
            }
        }
    }

    public static bool checkOnScreen(Rect rect)
    {
        bool offLeft = rect.x + rect.width < 0f;
        bool offRight = rect.x > Screen.width;
        bool offBottom = rect.y > Screen.height;
        bool offTop = rect.y + rect.height < 0f;

        return !(offLeft || offRight || offBottom || offTop);
    }

    public static void destroy(int id)
    {
        int backId = id & 0xFFFF;
        int backCounter = id >> 16;
        if (id >= 0 && levels[backId] != null && levels[backId].hasInitiliazed && levels[backId].counter == backCounter)
            levels[backId] = null;
    }

    public static void destroyAll(int depth)
    { // clears all gui elements on depth
        int maxLoop = depth * RECTS_PER_LEVEL + RECTS_PER_LEVEL;
        for (int i = depth * RECTS_PER_LEVEL; levels != null && i < maxLoop; i++)
        {
            levels[i] = null;
        }
    }

    public static LTRect label(Rect rect, string label, int depth)
    {
        return LTGUI.label(new LTRect(rect), label, depth);
    }

    public static LTRect label(LTRect rect, string label, int depth)
    {
        rect.type = Element_Type.Label;
        rect.labelStr = label;
        return element(rect, depth);
    }

    public static LTRect texture(Rect rect, Texture texture, int depth)
    {
        return LTGUI.texture(new LTRect(rect), texture, depth);
    }

    public static LTRect texture(LTRect rect, Texture texture, int depth)
    {
        rect.type = Element_Type.Texture;
        rect.texture = texture;
        return element(rect, depth);
    }

    public static LTRect element(LTRect rect, int depth)
    {
        isGUIEnabled = true;
        init();
        int maxLoop = depth * RECTS_PER_LEVEL + RECTS_PER_LEVEL;
        int k = 0;
        if (rect != null)
        {
            destroy(rect.id);
        }
        if (rect.type == LTGUI.Element_Type.Label && rect.style != null)
        {
            if (rect.style.normal.textColor.a <= 0f)
            {
                Debug.LogWarning("Your GUI normal color has an alpha of zero, and will not be rendered.");
            }
        }
        if (rect.relativeRect.width == float.PositiveInfinity)
        {
            rect.relativeRect = new Rect(0f, 0f, Screen.width, Screen.height);
        }
        for (int i = depth * RECTS_PER_LEVEL; i < maxLoop; i++)
        {
            r = levels[i];
            if (r == null)
            {
                r = rect;
                r.rotateEnabled = true;
                r.alphaEnabled = true;
                r.setId(i, global_counter);
                levels[i] = r;
                // Debug.Log("k:"+k+ " maxDepth:"+levelDepths[depth]);
                if (k >= levelDepths[depth])
                {
                    levelDepths[depth] = k + 1;
                }
                global_counter++;
                return r;
            }
            k++;
        }

        Debug.LogError("You ran out of GUI Element spaces");

        return null;
    }

    public static bool hasNoOverlap(Rect rect, int depth)
    {
        initRectCheck();
        bool hasNoOverlap = true;
        bool wasAddedToList = false;
        for (int i = 0; i < buttonLevels.Length; i++)
        {
            // Debug.Log("buttonLastFrame["+i+"]:"+buttonLastFrame[i]);
            //Debug.Log("buttonLevels["+i+"]:"+buttonLevels[i]);
            if (buttonLevels[i] >= 0)
            {
                //Debug.Log("buttonLastFrame["+i+"]:"+buttonLastFrame[i]+" Time.frameCount:"+Time.frameCount);
                if (buttonLastFrame[i] + 1 < Time.frameCount)
                { // It has to have been visible within the current, or
                    buttonLevels[i] = -1;
                    // Debug.Log("resetting i:"+i);
                }
                else
                {
                    //if(buttonLevels[i]>=0)
                    //   Debug.Log("buttonLevels["+i+"]:"+buttonLevels[i]);
                    if (buttonLevels[i] > depth)
                    {
                        /*if(firstTouch().x > 0){
                            Debug.Log("buttons["+i+"]:"+buttons[i] + " firstTouch:");
                            Debug.Log(firstTouch());
                            Debug.Log(buttonLevels[i]);
                        }*/
                        if (pressedWithinRect(buttons[i]))
                        {
                            hasNoOverlap = false; // there is an overlapping button that is higher
                        }
                    }
                }
            }

            if (wasAddedToList == false && buttonLevels[i] < 0)
            {
                wasAddedToList = true;
                buttonLevels[i] = depth;
                buttons[i] = rect;
                buttonLastFrame[i] = Time.frameCount;
            }
        }

        return hasNoOverlap;
    }

    public static bool pressedWithinRect(Rect rect)
    {
        Vector2 vec2 = firstTouch();
        if (vec2.x < 0f)
            return false;
        float vecY = Screen.height - vec2.y;
        return (vec2.x > rect.x && vec2.x < rect.x + rect.width && vecY > rect.y && vecY < rect.y + rect.height);
    }

    public static bool checkWithinRect(Vector2 vec2, Rect rect)
    {
        vec2.y = Screen.height - vec2.y;
        return (vec2.x > rect.x && vec2.x < rect.x + rect.width && vec2.y > rect.y && vec2.y < rect.y + rect.height);
    }

    public static Vector2 firstTouch()
    {
        if (Input.touchCount > 0)
        {
            return Input.touches[0].position;
        }
        else if (Input.GetMouseButton(0))
        {
            return Input.mousePosition;
        }

        return new Vector2(Mathf.NegativeInfinity, Mathf.NegativeInfinity);
    }

}