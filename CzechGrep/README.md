# Grep with Czech language support

## Description

For a text file given, the program searches for all occurences of given patterns.
The patterns can be in Czech language, with the program searching for all possible
forms of the pattern (including plural and grammatical cases)

## Usage

CzechGrep.exe [options] pattern1, ..., patternN

### Options
 
- --dry - show only possible variations of given patterns
- --offline - search only for the exact form of the pattern
- --force-online - force re-downloading the file containing all forms
- --help - show this help
