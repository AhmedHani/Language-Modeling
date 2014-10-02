using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageModeling.Smoothing
{
    //http://en.wikipedia.org/wiki/Good%E2%80%93Turing_frequency_estimation

    public class GoodTuringSmoothedProbabilty
    {
        public Dictionary<string, double> _wordsCounter;
        public Dictionary<double, double> _numberOfUnigramsAndFrequency;
        public double _totalCount;
        public string _currentWord;
        public int _numberOfUnigrams;

        public GoodTuringSmoothedProbabilty()
        {

        }

        public GoodTuringSmoothedProbabilty(string _currentWord)
        {
            this._currentWord = _currentWord;
        }

        public GoodTuringSmoothedProbabilty(Dictionary<string, double> _wordsCounter, Dictionary<double, double> _numberOfUnigramsAndFrequency, double _totalCount, string _currentWord, int _numberOfUnigrams)
        {
            this._numberOfUnigrams = _numberOfUnigrams;
            this._currentWord = _currentWord;
            this._wordsCounter = _wordsCounter;
            this._totalCount = _totalCount;
            this._numberOfUnigramsAndFrequency = _numberOfUnigramsAndFrequency;
        }

        public double startGoodTuring()
        {
            _totalCount = 0;

            foreach (string i in _wordsCounter.Keys)
            {
                double tempCount = _wordsCounter[i];

                if (!_numberOfUnigramsAndFrequency.ContainsKey((double)tempCount + 1.0))
                {
                    _numberOfUnigramsAndFrequency[tempCount + 1] = 0;
                }

                double newCount = (tempCount + 1) * ((double)_numberOfUnigramsAndFrequency[tempCount + 1])
                    /
                    (_numberOfUnigramsAndFrequency[tempCount]);

                _wordsCounter[i] = newCount;
                _totalCount += newCount;
            }

            if (_wordsCounter.ContainsKey(_currentWord))
            {
                return _wordsCounter[_currentWord] / _totalCount;
            }

            return _numberOfUnigramsAndFrequency[1.0] / _numberOfUnigrams;
        }

        
    }
}
