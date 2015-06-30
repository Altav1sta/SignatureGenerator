# SignatureGenerator
- User input the full path to file which is to be checked (notice that you can use file with any extension and any size*)
- User input the size of block in which we split whole file (if it was entered empty string or wrong type of data it will 
be set default 1Mb value)
- After pressing Enter program will compute hash-code of every block of this file using MD5 hash-function and will display 
it on the screen

*you can chose files which byte-length is less or equals 9 223 372 036 854 775 807 (i.e. Int64.MaxValue)
