using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageModeling.Smoothing
{
    public class AddOneSmoothedProbability
    {
        public AddOneSmoothedProbability()
        {

        }

        public double addOneSmoothing(Dictionary<string, int> _wordsCounter, string _currentWord, double _totalCount, double vocabularySize)
        {
            double frequency = 0;

            if (_wordsCounter.ContainsKey(_currentWord))
            {
                frequency = _wordsCounter[_currentWord];
            }

            else
            {
                frequency = 0;
            }

            return ((frequency + 1.0) / (_totalCount + vocabularySize)); 
        }
    }
}
