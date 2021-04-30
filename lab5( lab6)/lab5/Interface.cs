using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars
{
    public interface IActions
    {
        void FillUpTank(double Fuel);
        void FillUpTank();
        double DrainFuel(double Fuel);
        void ShowInfo();
        void Move(double distance);
    }
}