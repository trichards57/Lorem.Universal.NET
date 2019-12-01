Lorem Class
===========

The main class for generating random content.

Namespace
---------
LoremNET

Assembly
--------

* Lorem.Universal.NET

Methods
-------

Chance(int successes, int attempts)
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

Returns true *successes* times out of *attempts*.

successes
  The number of times the functions should return true (on average) in *attempts* 
  number of attempts.  
attempts 
  The number of attempts used to scale *successes*.

Exceptions
##########

**ArgumentOutOfRangeException**

* *successes* is negative
* *attempts* is less than 1
* *successes* is greater than *attempts*

DateTime(int startYear = 1950, int startMonth = 1, int startDay = 1)
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

Returns a random DateTime greater than or equal to the given date and 
less than DateTime.Now.

startYear
  The minimum year (default 1950).
startMonth
  The minimum month (default 1).
startDay
  The minimum day (default 1).

The smallest difference between two different results will be one minute. 

DateTime(DateTime min)
~~~~~~~~~~~~~~~~~~~~~~

Returns a random DateTime greater than or equal to *min* and less than 
DateTime.Now.

min
  The minimum date.

The smallest difference between two different results will be one minute.

DateTime(DateTime min, DateTime max)
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

Returns a random DateTime greater than or equal to *min* and less than *max*.

min
  The minimum date.
max
  The maximum date.

The smallest difference between two different results will be one minute.
The code was originally taken from http://stackoverflow.com/a/1483677/234132.

Exceptions
##########

**ArgumentException**
 
* *max* is less than *min*.

Email()
~~~~~~~

Returns a random email address of the type random1@random2.com.  This does not
randomise the top level domain.

Enum<TEnum>()
~~~~~~~~~~~~~

Returns a random item from *TEnum*.

Exceptions
##########

**ArgumentException**

* *TEnum* is not an enum.

HexNumber(int digits)
~~~~~~~~~~~~~~~~~~~~~

Returns a string of hexadecimal digits, *digits* characters long.

digits
  The number of digits to return.

Exceptions
##########

**ArgumentOutOfRangeException**

* *digits* is less than 0.

Integer(int min, int max)
~~~~~~~~~~~~~~~~~~~~~~~~~~

Returns a random integer between *min* and *max*.

min
  The minimum number to return.
max
  The maximum number to return.

Exceptions
##########

**ArgumentException**

* *max* is less than *min*.

Letter()
~~~~~~~~

Returns a random lowercase character between 'a' and 'z' (inclusive).


Number(long min, long max)
~~~~~~~~~~~~~~~~~~~~~~~~~~

Returns a random long integer between *min* and *max*.

min
  The minimum number to return
max
  The maximum number to return

The code was originally taken from http://stackoverflow.com/a/6651661/234132

Exceptions
##########

**ArgumentException**

* *max* must be greater than or equal to *min*.

Paragraph(int wordCount, int sentenceCount)
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

Returns a random paragraph with *sentenceCount* sentences and *wordCount* words per sentence.

wordCount
  The number of words per sentence
sentenceCount
  The number of sentences

Exceptions
##########

**ArgumentOutOfRangeException**

* *wordCount* must be greater than zero.
* *sentenceCount* must be greater than zero.

Paragraph(int wordCountMin, int wordCountMax, int sentenceCount)
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

Returns a random paragraph with *sentenceCount* sentences and *wordCountMin* to *wordCountMax* words per sentence.

wordCountMin
  The minimum number of words per sentence
wordCountMax
  The maximum number of words per sentence
sentenceCount
  The number of sentences

Exceptions
##########

**ArgumentOutOfRangeException**

* *wordCountMax* must be greater than zero.
* *wordCountMin* must be greater than zero.
* *sentenceCount* must be greater than zero.

**ArgumentException**

* *wordCountMax* must be greater than or equal to *wordCountMin*.

Paragraph(int wordCountMin, int wordCountMax, int sentenceCountMin, int sentenceCountMax)
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

Returns a random paragraph with *sentenceCountMin* to *sentenceCountMax* sentences and *wordCountMin* to *wordCountMax* words per sentence.

wordCountMin
  The minimum number of words per sentence
wordCountMax
  The maximum number of words per sentence
sentenceCountMin
  The minimum number of sentences
sentenceCountMax
  The maximum number of sentences

Exceptions
##########

**ArgumentOutOfRangeException**

* *wordCountMax* must be greater than zero.
* *wordCountMin* must be greater than zero.
* *sentenceCountMax* must be greater than zero.
* *sentenceCountMin* must be greater than zero.

**ArgumentException**

* *wordCountMax* must be greater than or equal to *wordCountMin*.
* *sentenceCountMax* must be greater than or equal to *sentenceCountMin*.

Paragraphs(int wordCount, int sentenceCount, int paragraphCount)
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

Returns *paragraphCount* paragraphs with *sentenceCount* sentences per paragraph and *wordCount* words per sentence.

wordCount
  The number of words
sentenceCount
  The number of sentences
paragraphCount
  The number of paragraphs

Paragraphs(int wordCountMin, int wordCountMax, int sentenceCount, int paragraphCount)
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

Returns *paragraphCount* paragraphs with *sentenceCount* sentences per paragraph and *wordCountMin* to *wordCountMax* words per sentence.

wordCountMin
  The minimum number of words per sentence
wordCountMax
  The maximum number of words per sentence
sentenceCount
  The number of sentences
paragraphCount
  The number of paragraphs

Exceptions
##########

**ArgumentException**

* *wordCountMax* must be greater than or equal to *wordCountMin*.

Paragraphs(int wordCountMin, int wordCountMax, int sentenceCountMin, int sentenceCountMax, int paragraphCount)
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

Returns *paragraphCount* paragraphs with *sentenceCountMin* to *sentenceCountMax* sentences per paragraph and *wordCountMin* to *wordCountMax* words per sentence.

wordCountMin
  The minimum number of words per sentence
wordCountMax
  The maximum number of words per sentence
sentenceCountMin
  The minimum number of sentences per paragraph
sentenceCountMax
  The maximum number of sentences per paragraph
paragraphCount
  The number of paragraphs

Exceptions
##########

**ArgumentException**

* *wordCountMax* must be greater than or equal to *wordCountMin*.
* *sentenceCountMax* must be greater than or equal to *sentenceCountMin*.

Paragraphs(int wordCountMin, int wordCountMax, int sentenceCountMin, int sentenceCountMax, int paragraphCountMin, int paragraphCountMax)
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

Returns *paragraphCountMin* to *paragraphCountMax* paragraphs with *sentenceCountMin* to *sentenceCountMax* sentences per paragraph and *wordCountMin* to *wordCountMax* words per sentence.

wordCountMin
  The minimum number of words per sentence
wordCountMax
  The maximum number of words per sentence
sentenceCountMin
  The minimum number of sentences per paragraph
sentenceCountMax
  The maximum number of sentences per paragraph
paragraphCountMin
  The minimum number of paragraphs
paragraphCountMax
  The maximum number of paragraphs

Exceptions
##########

**ArgumentException**

* *wordCountMax* must be greater than or equal to *wordCountMin*.
* *sentenceCountMax* must be greater than or equal to *sentenceCountMin*.
* *paragraphCountMax* must be greater than or equal to *paragraphCountMin*.

Random<T>(T[] items)
~~~~~~~~~~~~~~~~~~~~

Picks a random item from the provided array.

items
  The items to pick from.

Exceptions
##########

**ArgumentNullException**

* *items* must not be null.

**ArgumentException**

* *items* must contain one or more items.

Sentence(int wordCount)
~~~~~~~~~~~~~~~~~~~~~~~

Creates a random sentence with *wordCount* words.

wordCount
  The number of words

Sentence(int wordCountMin, int wordCountMax)
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

Creates a random sentence with *wordCountMin* to *wordCountMax* words.

wordCountMin
  The minimum number of words per sentence
wordCountMax
  The maximum number of words per sentence

Exceptions
##########

**ArgumentException**

* *wordCountMax* must be greater than or equal to *wordCountMin*.

Words(int wordCount, bool uppercaseFirstLetter = true, bool includePunctuation = false)
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

Creates a string containing *wordCount* words.

wordCount
  The number of words
uppercaseFirstLetter
  If true, makes the first letter uppercase
includePunctuation
  If true, includes punctuation in the words

Words(int wordCountMin, int wordCountMax, bool uppercaseFirstLetter = true, bool includePunctuation = false)
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

Creates a string containing *wordCountMin* to *wordCountMax* words.

wordCountMin
  The minimum number of words
wordCountMax
  The maximum number of words
uppercaseFirstLetter
  If true, makes the first letter uppercase
includePunctuation
  If true, includes punctuation in the words

Exceptions
##########

**ArgumentException**

* *wordCountMax* must be greater than or equal to *wordCountMin*.