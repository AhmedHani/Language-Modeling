using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using LanguageModeling.Smoothing;

namespace LanguageModeling
{
    public class Perplexity
    {
        // PP(W) = Sqrt(1 / PRODUCT (1 / P(wi, w1 .. wN)) ^ N
        public Dictionary<string, double> _wordsCounter;
        public Dictionary<double, double> _numberOfUnigramsAndFrequency;
        public double _totalCount;
        public string _currentWord;
        public int _numberOfUnigrams;
        public HashSet<string> testData;
        
        public Perplexity(Dictionary<string, double> _wordsCounter, Dictionary<double, double> _numberOfUnigramsAndFrequency, double _totalCount, int _numberOfUnigrams, string _currentWord, HashSet<string> testData)
        {
            this._numberOfUnigrams = _numberOfUnigrams;
            this._currentWord = _currentWord;
            this._wordsCounter = _wordsCounter;
            this._totalCount = _totalCount;
            this._numberOfUnigramsAndFrequency = _numberOfUnigramsAndFrequency;
            this.testData = testData;
        }

        public double perplexity()
        {
            double resultedProduct = 1;
            double N = 0;
            List<double> products = new List<double>();

            string regularExpression = "('?\\w+|\\p{P})";

            Regex regex = new Regex(regularExpression);
            GoodTuringSmoothedProbabilty gto = new GoodTuringSmoothedProbabilty(_wordsCounter, _numberOfUnigramsAndFrequency, _totalCount, _currentWord, _numberOfUnigrams);

            foreach (string word in testData)
            {
                Match matcher = regex.Match(word)
                ;
                while (matcher.Success)
                {
                    Group grp = matcher.Groups[0];
                    CaptureCollection cc = grp.Captures;
                    Capture c = cc[0];

                    products.Add(gto.startGoodTuring());
                    N++;

                    matcher.NextMatch();
                }

            }

            double power = 1.0 / N;

            foreach (double i in products)
            {
                resultedProduct = resultedProduct * Math.Pow(i, power);
            }

            return 1 / resultedProduct;
        }
    }
}
