using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fly
{
    public interface IFlyable
    {
        void FlyTo(Coordinate newPosition);
        double GetFlyTime(Coordinate newPosition);

    }
}
