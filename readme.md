Lorem.NET for netstandard
=========================

A .NET library for all things random!  Updated to be a .Net 8 and .Net 9 library.

![GitHub Workflow Status](https://img.shields.io/github/actions/workflow/status/trichards57/Lorem.Universal.NET/build-and-release.yml)
[![Documentation Status](https://readthedocs.org/projects/loremdnxnet/badge/?version=latest)](https://loremdnxnet.readthedocs.io/en/latest/?badge=latest)
[![NuGet](https://img.shields.io/nuget/v/Lorem.Universal.NET.svg?maxAge=2592000)](https://www.nuget.org/packages/Lorem.Universal.NET/)


Usage
-----

### Text Helpers

```csharp
// this will generate a string with three words:
string words = LoremNET.Lorem.Words(3);

// this will generate a string with two to five words:
string words = LoremNET.Lorem.Words(2, 5);

// this will generate a string with five to ten words with "uppercaseFirstLetter" set to "false" and "includePunctuation" set to "true":
string words = LoremNET.Lorem.Words(5, 10, false, true);

// a sentence is the same as "Words" except that it will include punctuation by default and will include a "." at the end of a string:
string sentence = LoremNET.Lorem.Sentence(5, 10);

// a paragraph is a string composed of multiple sentences; this paragraph will have five to six words per sentence, and four to ten sentences:
string paragraph = LoremNET.Lorem.Paragraph(5, 6, 4, 10);

// paragraphs is an array of paragraphs; this method will have eight to nine words per sentence, four to five sentences per paragraph, and one to three paragraphs:
IEnumerable<string> paragraphs = LoremNET.Lorem.Paragraphs(8, 9, 4, 5, 1, 3);
```

Breaking Change : As of v5.0, support for anything other than .Net 8 and .Net 9 has been removed.

### Extras

```csharp
// this will generate a random valid email address:
string email = LoremNET.Lorem.Email();

// this will generate a random hex number (i.e. a color)
string hex = LoremNET.Lorem.HexNumber();

// this will generate a random DateTime object between 1/1/1950 and the current DateTime:
DateTime dateTime = LoremNET.Lorem.DateTime();

// this will generate a random DateTime object between 1/1/1995 and 12/31/2020:
DateTime dateTime = LoremNET.Lorem.DateTime(new DateTime(1995, 1, 1), new DateTime(2020, 12, 31))

// this will return "true" 55% of the time:
bool isTruth = LoremNET.Lorem.Chance(55, 100);

// this will randomly select an item from the group:
string[] numbers = GetNumbers();
string number = LoremNET.Lorem.Random(numbers);

// this will randomly select a value from the enum:
MyEnum value = LoremNET.Lorem.Enum<MyEnum>(); 

```

### RandomHelper

RandomHelper has been removed in v5.0, replaced with Random.Shared provided by the framework.