# **PomocnikKrzyzowkowicza - Crossword helper**

Mały pomocnik krzyżówkowicza. Wyszukuje słowa, które można utworzyć z posiadanych liter. Dobry do gier typu Words of Wonder.

**_Ważne! Wypakuj plik slowa.zip (spakowany, ze względu na limit wielkości pliku na GitHub)
Impoetant! Unzip slowa.zip_**

Small program to check what kind of words you can create (read from dictionary file - slowa.text) from input letters.
You can specify how many characters this words need to be.

There are two versions - console and GUI. Both are fast (console version is faster but not much).
GUI version uses multithreading so your user interface is still responsive.

Search for 3-7 chars long words take about 2 seconds from polish dictionary.


**Dictionary**

To switch dictionary, use plain text file with one word per line.
Polish version of dictionary is from SJP.pl - dziękuję/thank you!

**Translation**

To translate **console** version, edit strings in resource file.
GUI version is harder - all string are in code for now. Wait for update, they will be migrated into resource file aswell.

**Search with pattern**

Program (both versions - console and winforms) have option to search with pattern. Just replace unknown letter with asterisk __*__ and program will take care of rest.

_once again, thanks to SJP.pl for providing dictionary._
