using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class LTEvent
{
    public int id;
    public object data;

    public LTEvent(int id, object data)
    {
        this.id = id;
        this.data = data;
    }
}
