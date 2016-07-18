using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Logic
{
    public class MasterService : IMasterService
    {
        private readonly IAlgoService _algoService;

        private readonly IDataService _dataService;

        public IAlgoService GetAlgoService => _algoService;

        public IDataService GetDataService => _dataService;

        public MasterService(IAlgoService algo, IDataService data)
        {
            _algoService = algo;
            _dataService = data;
        }

        public List<int> GetMinValuesFromLists(List<List<int>> args)
        {
            if (args == null || !args.Any())
            {
                throw new InvalidOperationException("No data");
            }

            if (args.Count > 4) throw new ArgumentException();

            List<int> listOfMins = new List<int>(args.Count);

            foreach (List<int> item in args)
            {
                listOfMins.Add(_algoService.MinValue(item));
            }

            return listOfMins;
        }


        public int GetDoubleSum()
        {
            var data = _dataService.GetAllData();
            if (data == null || !data.Any())
            {
                throw new InvalidOperationException("We have no data to process");
            }

            return _algoService.DoubleSum(data);;
        }

        public double GetAverage()
        {
            var data = _dataService.GetAllData();
            if (data == null || !data.Any())
            {
                throw new InvalidOperationException("We have no data to process");
            }
            return _algoService.GetAverage(data);
        }

        public double GetMaxSquare()
        {
            var data = _dataService.GetMax();
            return _algoService.Sqr(data);
        }
    }
}