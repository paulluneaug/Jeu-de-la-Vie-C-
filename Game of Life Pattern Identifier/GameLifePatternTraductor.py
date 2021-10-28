

def GameLifePatternTraductor (patternName):
    patternNonsense = open(f"NonsensePattern\{patternName}.txt").read()
    print ("File imported")
    
    lines = []
    currentLine = ""
    i = 0
    
    currentChar = patternNonsense[i]
    while currentChar!="!":
        
        if (currentChar == '$'):
            lines, currentLine = ChangeLine(lines, currentLine)
            
            
        elif currentChar =="b":
            currentLine+=" "
            
        elif currentChar == "o":
            currentLine+="0"
        
        elif currentChar != "\n" :
            
            mult = int(currentChar)
            i+=1
            try :
                while True:
                    currentChar = patternNonsense[i]
                    mult = 10 * mult + int(currentChar)
                    i+=1
            except :
                if currentChar == "$":
                    for a in range(mult):
                        lines, currentLine = ChangeLine(lines, currentLine)
                else :
                    
                    if (currentChar == "o"):
                        char = "0"
                    else :
                        char = " "
                    currentLine += mult * char
        i+=1
        currentChar = patternNonsense[i]
    
    lines.append(currentLine)
        
    
    translatedPattern = ""
    for line in lines :
        translatedPattern += line + "\n"
    
    print(translatedPattern, file = open(f"TXTPatterns\{patternName}.txt",'w',encoding='utf-8'))
    
def ChangeLine(allLines, lineToAdd):
    allLines.append(lineToAdd)
    return allLines, ""
    
    
GameLifePatternTraductor("HalfMaxV2")