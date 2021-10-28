

def GameLifePatternTraductor (patternName):
    patternNonsense = open(f"NonsensePattern\{patternName}.txt").read()
    
    
    lines = []
    currentLine = ""
    i = 0
    
    while patternNonsense[i]!="!":
        
        if (patternNonsense[i] == '$'):
            lines.append(currentLine)
            currentLine = ""
            
        elif patternNonsense[i] =="b":
            currentLine+=" "
            
        elif patternNonsense[i] == "o":
            currentLine+="0"
        
        else :
            mult = int(patternNonsense[i])
            i+=1
            try :
                while True:
                    mult = 10 * mult + int(patternNonsense[i])
                    i+=1
            except :
                if (patternNonsense[i] == "o"):
                    char = "0"
                else:
                    char = " "
                currentLine+= mult *char
        i+=1
    
    lines.append(currentLine)
        
    
    translatedPattern = ""
    for line in lines :
        translatedPattern += line + "\n"
    
    print(translatedPattern, file = open(f"TXTPatterns\{patternName}.txt",'w',encoding='utf-8'))
    
    
GameLifePatternTraductor("Bakery Synth")