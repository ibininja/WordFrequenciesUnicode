# WordFrequenciesUnicode
Simple Script to calculate frequencies of words in a given File. 
I used this script primarily to compare contents of viral and highly scored students papers and compared the mostly used words of each student and weather a theme existed. Also this script helped me extract words from viral posts to utilize for other uses as well. This script could be used in conjunction with other scripts to create nice things.


The current script:
- Reads Data from file
- Outputs results to a desired file
- Rewrites to an existing file if desired.

In the App.config file:
<code>    
    <add key="rewrite" value="1" />
    <add key="storePath" value="C:\Users\Ibrahim\My Documents\" />
    <add key="fileName" value="WriteCounts.txt" />
    <add key="sourceFilePath" value="C:\Users\Ibrahim\My Documents\" />
    <add key="sourceFileName" value="SourceFile.txt" />
</code>
