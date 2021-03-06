using System;
using System.Collections.Generic;
using System.Text;

namespace PersonInfo
{
    interface IRobot : IIdentifiable
    {
        string Model { get; }
    }
}
