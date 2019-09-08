# **PomocnikKrzyzowkowicza - Crossword helper**

Mały pomocnik krzyżówkowicza. Wyszukuje słowa, które można utworzyć z posiadanych liter. Dobry do gier typu Words of Wonder.

**_Ważne! Wypakuj plik slowa.zip (spakowany, ze względu na limit wielkości pliku na GitHub)**

**Impoetant! Unzip slowa.zip_**


Small program to check what kind of words you can create (read from dictionary file - slowa.text) from input letters.

You can specify how many characters this words need to be.


There are two versions - console and GUI. Both are fast (console version is faster but not much).

GUI version uses multithreading so your user interface is still responsive.


Search for 3-7 chars long words take about 2 seconds from polish dictionary.




## Dictionary

To switch dictionary, use plain text file with one word per line.

Polish version of dictionary is from SJP.pl - dziękuję/thank you!




## Translation

~~To translate console version, edit strings in resource file. GUI version is harder - all string are in code for now. Wait for update, they will be migrated into resource file aswell.~~


All string now are in program resource file (with GUI elements).

To translate them, just edit resource file. Names should be helpfull to understand what they are. If not, use Google translator or something like that to translate from Polish.

Please, **Do not remove link to my Github**




## Search with pattern

Program (both versions - console and winforms) have option to search with pattern. Just replace unknown letter with asterisk __*__ and program will take care of rest.




## Changes:


**_v. 1.0.3_**:
- Added GUI version
- Performance update
- Added execution timer
- Fixed few bugs


**_v. 1.0.4_**
- Moved strings to resource file
- UI updates
  - there is autocomplete (based on your inputs) now in GUI version. 
- Error management
- Moved some code
- Added option to export output to formated txt file and html file
- Rewrited progress bar to show accurate search progress


----------------------------

### To do...

- [X] GUI
- [ ] Save autocomplete and last save path info
- [ ] Track some fun stats
- [ ] _Overengineer it :+1: :smirk:_
