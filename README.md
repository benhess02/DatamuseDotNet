# DatamuseDotNet
 A .NET library for using the [Datamuse API](https://www.datamuse.com/api/).
## Examples
### Words that rhyme with "car"
```C#
DatamuseClient client = new DatamuseClient();
DatamuseResultItem[] results = client.Rhymes("Car");
```
Most other client methods such as `MeansLike`, `SoundsLike`, `Triggers`, ect. can be used to replace `Rhymes` in this example.
### Completion suggestions
The `Suggestions` method can be used to retrieve a set of completion suggestions for a prefix.
```C#
DatamuseClient client = new DatamuseClient();
DatamuseResultItem[] results = client.Suggestions("How to ");
```
In the example above, `results` will contain the following set of results:
```
how to compute calendars
how to learn lines
hot to trot
how do you do
how to
hop to it
how tos
how do you like
how do you like them apples
down to earth
```
### Custom requests
Request modifiers can be used with the `Words` and `Suggestions` methods to make customized requests:
```C#
DatamuseClient client = new DatamuseClient();
DatamuseResultItem[] results = client.Words(
    new RelationModifier("car", RelationType.Rhyme),
    new VocabularyModifier("enwiki"),
    new MaxResultsModifier(5)
);
```
In the example above, a request is made for a maximum of 5 results that rhyme with "car" from the `enwiki` vocabulary.
### Wildcards
Wildcards can be used to search for spellings that meet certain conditions.
```C#
DatamuseClient client = new DatamuseClient();
DatamuseResultItem[] results = client.SpelledLike(Wildcard.EndsWith("ing"));
```
In the example above, a request is made for words ending in "ing".
### Full example
The following is a full example that writes a set of words ending in "ing" to the console:
```C#
using System;
using DatamuseDotNet;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            DatamuseClient client = new DatamuseClient();
            DatamuseResultItem[] results = client.SpelledLike(Wildcard.EndsWith("ing"));
            for(int i = 0; i < results.Length; i++)
            {
                Console.WriteLine(results[i].word);
            }
            Console.ReadLine();
        }
    }
}
```
