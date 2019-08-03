using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotFix;
using huqiang.Data;
using huqiang.UI;

public class HotFixPage:UIPage
{
    IlRuntime runtime;
    public override void Initial(ModelElement parent, object dat = null)
    {
        var data = dat as byte[];
        if(data!=null)
        {
            runtime = new IlRuntime(data,parent);
        }
    }
    public override void ReSize()
    {
        if (runtime != null)
            runtime.RuntimeReSize();
    }
    public override void Update(float time)
    {
        if (runtime != null)
            runtime.RuntimeUpdate(time);
    }
    public override void Cmd(DataBuffer dat)
    {
        if (runtime != null)
            runtime.RuntimeCmd(dat);
    }
    public override void Cmd(string cmd, object dat)
    {
        base.Cmd(cmd, dat);
    }
}
