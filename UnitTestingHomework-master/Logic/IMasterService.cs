using System.Collections.Generic;

namespace Logic
{
    public interface IMasterService
    {
        int GetDoubleSum();
        double GetAverage();
        double GetMaxSquare();
        List<int> GetMinValuesFromLists(List<List<int>> args);
    }
}