using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LanguageModeling.NGrams
{
    public class Unigram
    {
        public string regularExpression;
        public HashSet<string> words;
        public Dictionary<string, double> wordsCounter;
        public double totalCount;
        public HashSet<string> wordsCollection;
        public double vocublarySize;
        public Dictionary<double, double> numberOfUnigramsAndFrequency;
        public int numberOfUnigrams;

        public Unigram(HashSet<string> words)
        {
            this.regularExpression = "('?\\w+|\\p{P})";
            this.words = words;
            this.wordsCounter = new Dictionary<string, double>();
            this.totalCount = 0;
            this.vocublarySize = 0.0;
            this.wordsCollection = new HashSet<string>();
            this.numberOfUnigramsAndFrequency = new Dictionary<double, double>();
            this.numberOfUnigrams = 0;
        }

        public void train()
        {
            Regex regex = new Regex(regularExpression);

            foreach (string word in words)
            {
                Match matcher = regex.Match(word)
                ;
                while (matcher.Success)
                {
                    Group grp = matcher.Groups[0];
                    CaptureCollection cc = grp.Captures;
                    Capture c = cc[0];
                    wordsCollection.Add(c.ToString());
             
                    double counter = 0;

                    if (wordsCounter.ContainsKey(c.ToString()))
                    {
                        counter = wordsCounter[c.ToString()];
                        numberOfUnigramsAndFrequency[counter] = numberOfUnigramsAndFrequency[counter] - 1;
                    }

                    wordsCounter[c.ToString()] = counter + 1;

                    if (!numberOfUnigramsAndFrequency.ContainsKey(counter + 1))
                    {
                        numberOfUnigramsAndFrequency[counter + 1] = 1;
                    }

                    else
                    {
                        numberOfUnigramsAndFrequency[counter + 1] = numberOfUnigramsAndFrequency[counter + 1] + 1;
                    }

                    totalCount++;
                    numberOfUnigrams++;
                    matcher = matcher.NextMatch();
                }
            }
            vocublarySize = wordsCollection.Count;
            
        }

        public Dictionary<string, double> afterParsing()
        {
            return wordsCounter;
        }

        public Dictionary<double, double> test()
        {
            return numberOfUnigramsAndFrequency;
        }
    }
}
